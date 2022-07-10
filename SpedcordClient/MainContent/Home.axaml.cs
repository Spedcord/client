using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpedcordClient.MainContent
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
