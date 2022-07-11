using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Text;
using WebViewControl;

namespace SpedcordClient.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private string address;
        private string currentAddress;

        public LoginViewModel()
        {
            CurrentAddress = "https://spedcord.xyz";
            ButtonLoginClick = ReactiveCommand.Create(() => { });
        }

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

        public string Address
        {
            get => address;
            set => this.RaiseAndSetIfChanged(ref address, value);
        }

        public string CurrentAddress
        {
            get => currentAddress;
            set => this.RaiseAndSetIfChanged(ref currentAddress, value);
        }

        public ReactiveCommand<Unit, Unit> ButtonLoginClick { get; }
    }
}
