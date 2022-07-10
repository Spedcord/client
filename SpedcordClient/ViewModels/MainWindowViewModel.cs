using ReactiveUI;
using System;

namespace SpedcordClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainWindowViewModel()
        {

            Program.Settings = SpedcordClient.Settings.SettingsLoader.LoadSettings();
            Localizer.Localizer.Instance.LoadLanguage(Program.Settings.SelectedLanguage);

            var w = new LoginViewModel();
            w.ButtonLoginClick.Subscribe(o =>
            {
                // We have to change to a dummy view first due to some weird bug with WebViews.
                // If we don't do this the controls in the MainView wouldn't show up
                Content = new DummyViewModel();
                Content = new MainViewModel();
            });
            Content = w;
        }
    }
}
