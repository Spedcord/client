using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpedcordClient.ViewModels.MainContent
{

    public class SettingsViewModel : ViewModelBase
    {
        public ObservableCollection<string> Languages
        {
            get { return Localizer.Localizer.Instance.GetLanguages(); }
        }
        public string Language
        {
            get { return Localizer.Localizer.Instance.Language; }
            set
            {
                Program.Settings.SelectedLanguage = value;
                Settings.SettingsLoader.SaveSettings(Program.Settings);
                Localizer.Localizer.Instance.LoadLanguage(value);
            }
        }

        private string tokenHideChar = "*";
        public string TokenHideChar
        {
            get => tokenHideChar;
            set => this.RaiseAndSetIfChanged(ref tokenHideChar, value);
        }

        public void ShowToken()
        {
            TokenHideChar = "\0";
        }

        public void HideToken()
        {
            TokenHideChar = "*";
        }

        public void BtnLogoutClick()
        {
            MainViewModel.ChangePage(0);
        }
    }
}
