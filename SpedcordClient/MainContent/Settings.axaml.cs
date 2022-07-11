using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SpedcordClient.ViewModels.MainContent;

namespace SpedcordClient.MainContent
{
    public partial class Settings : UserControl
    {

        public Settings()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
