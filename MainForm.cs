using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Ets2SdkClient;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SpedcordClient
{
    public partial class MainForm : MaterialForm
    {
        private ApiClient _apiClient;
        private Ets2Telemetry data = null;
        private float dist = -1;
        private bool send = true;
        private Job[] _jobs = new Job[0];
        private List<double> avgSpeedList = new List<double>();
        private int tick = 0;

        public MainForm(ApiClient apiClient)
        {
            _apiClient = apiClient;

            Ets2SdkTelemetry telemetry = new Ets2SdkTelemetry();
            telemetry.Data += TeleData;
            telemetry.JobStarted += TeleJobStart;
            telemetry.JobFinished += TeleJobEnd;

            InitializeComponent();

            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600, Primary.Red700,
                Primary.Red500, Accent.Red200,
                TextShade.WHITE
            );

            this.jobList.DoubleClick += new EventHandler(JobClickHandler);

            UpdateUser();
            UpdateJobs();
        }

        private void UpdateUser()
        {
            var user = _apiClient.GetUser(Program.DISCORD_ID);
            if (user != null)
            {
                if (user.Oauth != null)
                {
                    nameLabel.Text = "Username: " + user.Oauth.Name + "#" + user.Oauth.Discriminator;
                    balanceLabel.Text = "Balance: " + user.Balance + "$";
                    userAvatar.ImageLocation = "https://cdn.discordapp.com/avatars/" + user.DiscordId + "/" +
                                               user.Oauth.Avatar + ".png?size=128";
                    userAvatar.Load();
                }
                else
                {
                    nameLabel.Text = "Failed to fetch username";
                }

                var company = _apiClient.GetCompany(user.CompanyId);
                if (company == null)
                {
                    companyLabel.Text = "Company: None";
                }
                else
                {
                    companyLabel.Text = "Company: " + company.name;
                }
            }
        }

        private void UpdateJobs()
        {
            jobList.Items.Clear();

            _jobs = _apiClient.GetJobs(Program.DISCORD_ID) ?? new Job[0];
            var tmpArr = new Job[_jobs.Length];
            for (var i = 0; i < _jobs.Length; i++)
            {
                tmpArr[_jobs.Length - 1 - i] = _jobs[i];
            }

            _jobs = tmpArr;

            foreach (var job in _jobs)
            {
                var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(job.EndedAt).LocalDateTime;
                var str = $"[{dateTime.ToShortDateString()}] {job.FromCity} -> " +
                          $"{job.ToCity}: {job.Cargo} ({job.CargoWeight}t)";

                while (TextRenderer.MeasureText(str, jobList.Font).Width > (jobList.Width - 12))
                {
                    str = str.Substring(0, str.Length - 4) + "...";
                }

                jobList.Items.Add(str);
            }
        }

        private void TeleJobEnd(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                try
                {
                    //SEND JOB DATA
                    statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "Not on a job");
                    //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
                    dist = -1;

                    if (!send)
                    {
                        send = true;
                        return;
                    }

                    _apiClient.EndJob(Program.DISCORD_ID, Program.KEY, data.Job.Income);

                    if (InvokeRequired)
                    {
                        this.Invoke(new Action(UpdateJobs));
                        this.Invoke(new Action(UpdateUser));
                    }
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                    throw;
                }
            }).Start();


            avgSpeedList.Clear();
        }

        private void TeleJobStart(object sender, EventArgs e)
        {
        }

        private void TeleData(Ets2Telemetry data, bool newtimestamp)
        {
            if (data.Job.OnJob)
            {
                this.data = data;

                if (dist == -1 && data.Job.NavigationDistanceLeft != 0)
                {
                    // New job started
                    dist = data.Job.NavigationDistanceLeft;

                    var response = _apiClient.StartJob(Program.DISCORD_ID, Program.KEY, new Job()
                    {
                        FromCity = data.Job.CitySource,
                        ToCity = data.Job.CityDestination,
                        Cargo = data.Job.Cargo,
                        CargoWeight = data.Job.Mass / 1000f,
                        Truck = data.Manufacturer + " " + data.Truck
                    });
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                        {
                            MessageBox.Show("Unauthorized", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("You already have a running job! Please cancel the job.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        send = false;
                    }
                }

                if (!jobInfoLabel.Visible)
                {
                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, true);
                }

                var speed = Math.Floor(data.Drivetrain.SpeedKmh);
                if (speed < 0)
                {
                    speed = 0;
                }


                if (tick >= 100)
                {
                    avgSpeedList.Add(speed);
                    tick = 0;
                }
                else
                {
                    tick++;
                }

                var avgSpeed = Math.Floor(avgSpeedList.Count == 0 ? 0 : avgSpeedList.Sum() / avgSpeedList.Count);

                var progress = Math.Floor(((dist - data.Job.NavigationDistanceLeft) / (dist)) * 100);
                var str = $"Route: {data.Job.CitySource} -> {data.Job.CityDestination}\n" +
                          $"Cargo: {data.Job.Cargo} ({Math.Floor(data.Job.Mass) / 1000}t)\nEst. income: " +
                          $"{data.Job.Income}$\nTruck: {data.Manufacturer} {data.Truck}\nSpeed: {speed} KmH" +
                          $"\nAvg. speed: {avgSpeed} KmH\nProgress: {progress}%";

                jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
                statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "On a job");
            }
            else
            {
                //jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
                var speed = Math.Floor(data.Drivetrain.SpeedKmh);
                if (speed < 0)
                {
                    speed = 0;
                }

                var str = $"Truck: {data.Manufacturer} {data.Truck}\nSpeed: {speed} KmH";

                jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
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
            if (idx < 0 || idx >= _jobs.Length)
            {
                return;
            }

            var job = _jobs[idx];
            var startDate = (new DateTime(1970, 1, 1)).AddMilliseconds(job.StartedAt);
            var endDate = (new DateTime(1970, 1, 1)).AddMilliseconds(job.EndedAt);
            var timeSpan = endDate.Subtract(startDate);

            MessageBox.Show($"ID: {job.Id}\nRoute: {job.FromCity} -> {job.ToCity}\nCargo: {job.Cargo} " +
                            $"({job.CargoWeight}t)\nTruck: {job.Truck}\nIncome: {job.Pay}$\nTime: {timeSpan.Hours}h " +
                            $"{timeSpan.Minutes}m {timeSpan.Seconds}s", "Job #" + job.Id, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}