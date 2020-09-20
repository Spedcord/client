using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SCSSdkClient;
using SCSSdkClient.Object;
using SpedcordClient.api;
using SpedcordClient.discord;
using User = SpedcordClient.api.User;

namespace SpedcordClient
{
    public partial class MainForm : MaterialForm
    {
        private readonly ApiClient _apiClient;
        private readonly DiscordController _discordController;
        public Company Company;
        private Job[] _jobs = new Job[0];
        private SCSTelemetry _data;
        private float _dist = -1;
        private float _income = -1;
        public User User;

        private readonly List<double> _avgSpeedList = new List<double>();
        private bool _inProgress;
        private bool _send = true;
        private int _tick;
        private long[] _lastPos = {0, 0};

        public MainForm(ApiClient apiClient)
        {
            _apiClient = apiClient;
            _discordController = new DiscordController(699032105715236934);

            var scsSdkTelemetry = new SCSSdkTelemetry();
            scsSdkTelemetry.Data += Telemetry_Data;
            scsSdkTelemetry.JobStarted += Telemetry_JobStarted;
            scsSdkTelemetry.JobDelivered += Telemetry_JobDelivered;
            scsSdkTelemetry.JobCancelled += Telemetry_JobCancelled;

            InitializeComponent();

            Disposed += (sender, args) => _discordController.Dispose();

            // Create a material theme manager and add the form to manage (this)
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600, Primary.Red700,
                Primary.Red500, Accent.Red200,
                TextShade.WHITE
            );

            jobList.DoubleClick += JobClickHandler;

            UpdateUser();
            UpdateJobs();

            _discordController.UpdateActivity(false, 0, null);
        }

        private void Telemetry_JobCancelled(object sender, EventArgs e)
        {
            _inProgress = false;

            //SEND JOB DATA
            statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "Not on a job");
            //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
            _dist = -1;
            _lastPos = new long[] {0, 0};

            _apiClient.CancelJob(Program.DISCORD_ID, Program.KEY);
            _discordController.UpdateActivity(false, 0, null);

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateJobs));
                Invoke(new Action(UpdateUser));
            }
            else
            {
                UpdateJobs();
                UpdateUser();
            }
        }

        private void Telemetry_JobDelivered(object sender, EventArgs e)
        {
            _inProgress = false;

            //SEND JOB DATA
            statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "Not on a job");
            //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
            _dist = -1;
            _lastPos = new long[] {0, 0};

            if (!_send)
            {
                _send = true;
                return;
            }

            _apiClient.EndJob(Program.DISCORD_ID, Program.KEY, _income);

            _income = -1;

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateJobs));
                Invoke(new Action(UpdateUser));
                Invoke(new Action(() => _discordController.UpdateActivity(false, 0, null)));
            }
            else
            {
                UpdateJobs();
                UpdateUser();
                _discordController.UpdateActivity(false, 0, null);
            }
        }

        private void Telemetry_JobStarted(object sender, EventArgs e)
        {
            _inProgress = true;
        }

        private void Telemetry_Data(SCSTelemetry data, bool updated)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new TelemetryData(Telemetry_Data), data, updated);
                    return;
                }

                if (data.SpecialEventsValues.OnJob && _inProgress)
                {
                    _data = data;


                    if (_dist == -1f && data.NavigationValues.NavigationDistance != 0)
                    {
                        // New job started
                        _dist = data.NavigationValues.NavigationDistance;

                        _discordController.UpdateActivity(true, DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                            _data.JobValues.CitySource + " -> " + _data.JobValues.CityDestination);

                        var response = _apiClient.StartJob(Program.DISCORD_ID, Program.KEY, new Job
                        {
                            FromCity = data.JobValues.CitySource,
                            ToCity = data.JobValues.CityDestination,
                            Cargo = data.JobValues.CargoValues.Name,
                            CargoWeight = data.JobValues.CargoValues.Mass / 1000f,
                            Truck = data.TruckValues.ConstantsValues.Brand + " " + data.TruckValues.ConstantsValues.Name
                        });
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            if (response.StatusCode == HttpStatusCode.Unauthorized)
                                MessageBox.Show("Unauthorized", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show("You already have a running job! Please cancel the job.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                            _send = false;
                        }
                    }

                    if (!jobInfoLabel.Visible) jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, true);

                    var speed = Math.Floor(data.TruckValues.CurrentValues.DashboardValues.Speed.Kph);
                    if (speed < 0) speed = 0;


                    if (_tick >= 100)
                    {
                        _avgSpeedList.Add(speed);
                        _tick = 0;
                    }
                    else
                    {
                        _tick++;
                    }

                    if (_avgSpeedList.Count == 100) _avgSpeedList.Remove(_avgSpeedList[0]);
                    if (data.JobValues.Income > _income) _income = data.JobValues.Income;

                    var avgSpeed = Math.Floor(_avgSpeedList.Count == 0 ? 0 : _avgSpeedList.Sum() / _avgSpeedList.Count);

                    var posVal = data.TruckValues.CurrentValues.PositionValue.Position;
                    var lastX = _lastPos[0];
                    var lastZ = _lastPos[1];
                    var currX = (long) posVal.X;
                    var currZ = (long) posVal.Z;
                    var dist = Math.Sqrt(Math.Pow(lastX - currX, 2) + Math.Pow(lastZ - currZ, 2));
                    
                    if (dist >= 100)
                    {
                        _lastPos[0] = currX;
                        _lastPos[1] = currZ;
                        new Thread(() =>
                            {
                                var res = _apiClient.PostPosition(Program.DISCORD_ID, Program.KEY, currX, currZ);
                                Debug.WriteLine(res.StatusCode);
                                Debug.WriteLine(res.Response);
                            })
                            .Start();
                    }

                    var str = $"Route: {data.JobValues.CitySource} -> {data.JobValues.CityDestination}\n" +
                              $"Cargo: {data.JobValues.CargoValues.Name} ({Math.Floor(data.JobValues.CargoValues.Mass) / 1000}t)" +
                              $"\nEst. income: {data.JobValues.Income}$\nTruck: {data.TruckValues.ConstantsValues.Brand} " +
                              $"{data.TruckValues.ConstantsValues.Name}\nSpeed: {speed} KpH\nAvg. speed: {avgSpeed} KpH";

                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
                    statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "On a job");
                }
                else
                {
                    //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
                    var speed = Math.Floor(data.TruckValues.CurrentValues.DashboardValues.Speed.Kph);
                    if (speed < 0) speed = 0;

                    var str = $"Truck: {data.TruckValues.ConstantsValues.Brand} " +
                              $"{data.TruckValues.ConstantsValues.Name}\nSpeed: {speed} KpH";

                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
                }
            }
            catch (Exception e)
            {
                // Telemetry was closed
            }
        }

        private void UpdateUser()
        {
            User = _apiClient.GetUser(Program.DISCORD_ID);
            if (User != null)
            {
                if (User.Oauth != null)
                {
                    nameLabel.Text = "Username: " + User.Oauth.Name + "#" + User.Oauth.Discriminator;
                    balanceLabel.Text = "Balance: $" + $"{User.Balance:#,0.##}";
                    userAvatar.ImageLocation = "https://cdn.discordapp.com/avatars/" + User.DiscordId + "/" +
                                               User.Oauth.Avatar + ".png?size=128";
                    try
                    {
                        userAvatar.Load();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    nameLabel.Text = "Failed to fetch username";
                }

                Company = _apiClient.GetCompany(User.CompanyId);
                if (Company == null)
                {
                    companyLabel.Text = "Company: None";
                }
                else
                {
                    Debug.WriteLine(Company.ToString());
                    companyLabel.Text = "Company: " + Company.Name;
                    companyBalanceLabel.Text = "Company balance: $" + $"{Company.Balance:#,0.##}";

                    if (Company.GetRole(User.DiscordId).Permissions != 0) manageCompanyButton.Enabled = true;
                }
            }
        }

        private void UpdateJobs()
        {
            jobList.Items.Clear();

            _jobs = _apiClient.GetJobs(Program.DISCORD_ID) ?? new Job[0];
            var tmpArr = new Job[_jobs.Length >= 40 ? 40 : _jobs.Length];
            for (var i = 0; i < tmpArr.Length; i++) tmpArr[_jobs.Length - 1 - i] = _jobs[i];

            _jobs = tmpArr;

            foreach (var job in _jobs)
            {
                var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(job.EndedAt).LocalDateTime;
                var str = $"[{dateTime.ToShortDateString()}] {job.FromCity} -> " +
                          $"{job.ToCity}: {job.Cargo} ({job.CargoWeight}t)";

                while (TextRenderer.MeasureText(str, jobList.Font).Width > jobList.Width - 12)
                    str = str.Substring(0, str.Length - 4) + "...";

                jobList.Items.Add(str);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        public void Reload()
        {
            reloadButton_Click(null, null);
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            UpdateUser();
            UpdateJobs();
        }

        private void JobClickHandler(object sender, EventArgs e)
        {
            var idx = jobList.SelectedIndex;
            if (idx < 0 || idx >= _jobs.Length) return;

            var job = _jobs[idx];
            var startDate = new DateTime(1970, 1, 1).AddMilliseconds(job.StartedAt);
            var endDate = new DateTime(1970, 1, 1).AddMilliseconds(job.EndedAt);
            var timeSpan = endDate.Subtract(startDate);

            MessageBox.Show($"ID: {job.Id}\nRoute: {job.FromCity} -> {job.ToCity}\nCargo: {job.Cargo} " +
                            $"({job.CargoWeight}t)\nTruck: {job.Truck}\nIncome: {job.Pay}$\nTime: {timeSpan.Hours}h " +
                            $"{timeSpan.Minutes}m {timeSpan.Seconds}s", "Job #" + job.Id, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void manageCompanyButton_Click(object sender, EventArgs e)
        {
            var form = new ManageCompanyForm(User, Company, _apiClient, this);
            form.Show();

            manageCompanyButton.Enabled = false;
            form.Disposed += (o, args) => { manageCompanyButton.Enabled = true; };
        }
    }
}