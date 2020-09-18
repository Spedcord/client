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

namespace SpedcordClient
{
    public partial class MainForm : MaterialForm
    {
        private readonly ApiClient _apiClient;
        private Company _company;
        private Job[] _jobs = new Job[0];
        private readonly List<double> _avgSpeedList = new List<double>();
        private SCSTelemetry _data;
        private float _dist = -1;
        private User _user = null;

        private bool _send = true;
        private int _tick;

        public MainForm(ApiClient apiClient)
        {
            _apiClient = apiClient;

            var scsSdkTelemetry = new SCSSdkTelemetry();
            scsSdkTelemetry.Data += Telemetry_Data;
            scsSdkTelemetry.JobStarted += Telemetry_JobStarted;
            scsSdkTelemetry.JobDelivered += Telemetry_JobDelivered;
            scsSdkTelemetry.JobCancelled += Telemetry_JobCancelled;

            InitializeComponent();

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
        }

        private void Telemetry_JobCancelled(object sender, EventArgs e)
        {
            //SEND JOB DATA
            statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "Not on a job");
            //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
            _dist = -1;

            _apiClient.CancelJob(Program.DISCORD_ID, Program.KEY);

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateJobs));
                Invoke(new Action(UpdateUser));
            }
        }

        private void Telemetry_JobDelivered(object sender, EventArgs e)
        {
            //SEND JOB DATA
            statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "Not on a job");
            //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
            _dist = -1;

            if (!_send)
            {
                _send = true;
                return;
            }

            _apiClient.EndJob(Program.DISCORD_ID, Program.KEY, _data.JobValues.Income);

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateJobs));
                Invoke(new Action(UpdateUser));
            }
        }

        private void Telemetry_JobStarted(object sender, EventArgs e)
        {
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

                if (data.SpecialEventsValues.OnJob)
                {
                    _data = data;


                    if (_dist == -1 && data.NavigationValues.NavigationDistance != 0)
                    {
                        // New job started
                        _dist = data.NavigationValues.NavigationDistance;

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

                    var avgSpeed = Math.Floor(_avgSpeedList.Count == 0 ? 0 : _avgSpeedList.Sum() / _avgSpeedList.Count);

                    var progress = Math.Floor((_dist - data.NavigationValues.NavigationDistance) / _dist * 100);
                    var str = $"Route: {data.JobValues.CitySource} -> {data.JobValues.CityDestination}\n" +
                              $"Cargo: {data.JobValues.CargoValues.Name} ({Math.Floor(data.JobValues.CargoValues.Mass) / 1000}t)" +
                              $"\nEst. income: {data.JobValues.Income}$\nTruck: {data.TruckValues.ConstantsValues.Brand} " +
                              $"{data.TruckValues.ConstantsValues.Name}\nSpeed: {speed} Kph\nAvg. speed: {avgSpeed} KmH\n" +
                              $"Progress: {progress}%";

                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
                    statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "On a job");
                }
                else
                {
                    //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
                    var speed = Math.Floor(data.TruckValues.CurrentValues.DashboardValues.Speed.Kph);
                    if (speed < 0) speed = 0;

                    var str = $"Truck: {data.TruckValues.ConstantsValues.Brand} " +
                              $"{data.TruckValues.ConstantsValues.Name}\nSpeed: {speed} KmH";

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
            _user = _apiClient.GetUser(Program.DISCORD_ID);
            if (_user != null)
            {
                if (_user.Oauth != null)
                {
                    nameLabel.Text = "Username: " + _user.Oauth.Name + "#" + _user.Oauth.Discriminator;
                    balanceLabel.Text = "Balance: $" + $"{_user.Balance:#,0.##}";
                    userAvatar.ImageLocation = "https://cdn.discordapp.com/avatars/" + _user.DiscordId + "/" +
                                               _user.Oauth.Avatar + ".png?size=128";
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

                _company = _apiClient.GetCompany(_user.CompanyId);
                if (_company == null)
                {
                    companyLabel.Text = "Company: None";
                }
                else
                {
                    Debug.WriteLine(_company.ToString());
                    companyLabel.Text = "Company: " + _company.Name;
                    companyBalanceLabel.Text = "Company balance: $" + $"{_company.Balance:#,0.##}";

                    if (_company.GetRole(_user.DiscordId).Permissions != 0) manageCompanyButton.Enabled = true;
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

        private void reloadButton_Click(object sender, EventArgs e)
        {
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
            var form = new ManageCompanyForm(_user, _company, _apiClient);
            form.Show();

            manageCompanyButton.Enabled = false;
            form.Disposed += (o, args) => { manageCompanyButton.Enabled = true; };
        }
    }
}