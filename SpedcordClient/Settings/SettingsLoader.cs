using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpedcordClient.Settings
{
    public class SettingsLoader
    {
        private static readonly string _settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SpedcordClient");
        private static readonly string _settingsFile = Path.Combine(_settingsPath, "Settings.json");

        public static Settings LoadSettings()
        {
            if (!File.Exists(_settingsFile)) 
                return new Settings()
                {
                    SelectedLanguage = "EN",
                };
            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(_settingsFile));
        }

        public static void SaveSettings(Settings settings)
        {
            Directory.CreateDirectory(_settingsPath);
            File.WriteAllText(_settingsFile, JsonConvert.SerializeObject(settings, Formatting.Indented));
        }
    }
}
