using Avalonia;
using Avalonia.Platform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpedcordClient.Localizer
{
    public class Localizer : INotifyPropertyChanged
    {
        private const string IndexerName = "Item";
        private const string IndexerArrayName = "Item[]";
        private Dictionary<string, string> m_Strings = null;
        private ObservableCollection<string> languages = new() { "EN", "DE" };

        public Localizer()
        {
        }

        public ObservableCollection<string> GetLanguages()
        {
            return languages;
        }

        public bool LoadLanguage(string language)
        {
            Language = language;
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();

            Uri uri = new Uri($"avares://SpedcordClient/Assets/i18n/{language}.json");
            if (assets.Exists(uri))
            {
                using (StreamReader sr = new(assets.Open(uri), Encoding.UTF8))
                {
                    m_Strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                }
                Invalidate();

                return true;
            }
            return false;
        }

        public string Language { get; private set; }

        public string this[string key]
        {
            get
            {
                if (m_Strings != null && m_Strings.TryGetValue(key, out string res))
                    return res.Replace("\\n", "\n");
                return $"{Language}:{key}";
            }
        }

        public static Localizer Instance { get; set; } = new Localizer();
        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(IndexerArrayName));
        }
    }
}
