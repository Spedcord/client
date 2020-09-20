using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpedcordClient.api;

namespace SpedcordClient
{
    static class Program
    {
        public static long DISCORD_ID = -1;
        public static string KEY = null;

        public static readonly bool Dev = Environment.GetEnvironmentVariable("SPEDCORD_DEV") != null
                                          && Environment.GetEnvironmentVariable("SPEDCORD_DEV").Equals("true");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var apiClient = new ApiClient();

            var dirPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SpedcordClient";
            var settingsPath = dirPath + "\\settings.txt";

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            if (!File.Exists(settingsPath))
            {
                File.Create(settingsPath);
            }

            var lines = File.ReadLines(settingsPath);
            lines.ForEach(s =>
            {
                if (s.StartsWith("ID="))
                {
                    DISCORD_ID = long.Parse(s.Substring(3));
                }

                if (s.StartsWith("KEY="))
                {
                    KEY = s.Substring(4);
                }
            });

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if ((DISCORD_ID == -1 || KEY == null) || !apiClient.CheckAuth(DISCORD_ID, KEY))
            {
                Application.Run(new LoginForm(apiClient));
                return;
            }

            Application.Run(new MainForm(apiClient));
        }
    }
}