using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
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

            var user = _apiClient.GetUser(Program.DISCORD_ID);
            if (user != null)
            {
                if (user.Oauth != null)
                {
                    nameLabel.Text = "Username: " + user.Oauth.Name + "#" + user.Oauth.Discriminator;
                    userAvatar.ImageLocation = "https://cdn.discordapp.com/avatars/" + user.DiscordId + "/" +
                                               user.Oauth.Avatar + ".png?size=128";
                    userAvatar.Load();
                }
                else
                {
                    nameLabel.Text = "User ID: " + user.Id;
                }

                var company = _apiClient.GetCompany(user.CompanyId);
                if (company == null)
                {
                    companyLabel.Text = "Company ID: " + user.CompanyId;
                }
                else
                {
                    companyLabel.Text = "Company: " + company.name;
                }

                foreach (var job in apiClient.GetJobs(user.DiscordId))
                {
                    var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(job.EndedAt).LocalDateTime;
                    jobList.Items.Add($"[{dateTime.ToShortDateString()}] {job.FromCity} -> " +
                                      $"{job.ToCity}: {job.Cargo} ({job.CargoWeight}t)");
                }
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
                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
                    dist = -1;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception);
                    throw;
                }
            }).Start();
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
                    
                    
                }

                if (!jobInfoLabel.Visible)
                {
                    jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, true);
                }

                double speed = Math.Floor(data.Drivetrain.SpeedKmh);
                if (speed < 0)
                {
                    speed = 0;
                }

                double progress = Math.Floor(((dist - data.Job.NavigationDistanceLeft) / (dist)) * 100);
                var str = $"Route: {data.Job.CitySource} -> {data.Job.CityDestination}\n" +
                          $"Cargo: {data.Job.Cargo} ({Math.Floor(data.Job.Mass) / 1000}t)\nEst. income: " +
                          $"{data.Job.Income}$\nTruck: {data.Manufacturer} {data.Truck}\nSpeed: {speed} KmH" +
                          $"\nProgress: {progress}%";

                jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Text, str);
                statusLabel.SetPropertyThreadSafe(() => statusLabel.Text, "On a job");
            }
            else
            {
                jobInfoLabel.SetPropertyThreadSafe(() => jobInfoLabel.Visible, false);
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

        private void materialListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}