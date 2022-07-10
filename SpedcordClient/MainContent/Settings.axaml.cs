using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpedcordClient.MainContent
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
