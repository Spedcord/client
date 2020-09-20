using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using SpedcordClient.api;

namespace SpedcordClient
{
    public partial class LoginForm : MaterialForm
    {
        private ApiClient _apiClient;

        public LoginForm(ApiClient apiClient)
        {
            this._apiClient = apiClient;

            InitializeComponent();

            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Red600, Primary.Red700,
                Primary.Red500, Accent.Red200,
                TextShade.WHITE
            );
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (discordIdInput.Text.Equals("") || Regex.Matches("\\s+", discordIdInput.Text).Count != 0)
            {
                MessageBox.Show("Discord ID input cannot be empty!", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (keyInput.Text.Equals("") || Regex.Matches("\\s+", keyInput.Text).Count != 0)
            {
                MessageBox.Show("Key input cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long discordId;
            try
            {
                discordId = long.Parse(discordIdInput.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid Discord ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string key = keyInput.Text;

            if (!_apiClient.CheckAuth(discordId, key))
            {
                MessageBox.Show("Invalid credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SpedcordClient";
            var settingsPath = dirPath + "\\settings.txt";

            File.WriteAllLines(settingsPath, new List<string>()
            {
                "ID=" + discordId,
                "KEY=" + key
            });

            Program.DISCORD_ID = discordId;
            Program.KEY = key;


            var mainForm = new MainForm(_apiClient);
            Hide();
            mainForm.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start((Program.Dev ? "http://localhost:81" : "https://api.spedcord.xyz") +
                                             "/user/register");
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to get your Discord ID:\n1. Enable developer mode (https://discordia.me/" +
                            "en/developer-mode)\n2. Right click your name in any chat field and click \"Copy ID\"" +
                            "\n\nHow to get your key:\n1. Send \"&key\" as a private message to the official Spedcord " +
                            "Bot (Spedcord Bot#9681)", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}