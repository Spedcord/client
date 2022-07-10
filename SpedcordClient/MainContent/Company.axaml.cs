using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpedcordClient.MainContent
{
    public partial class Company : UserControl
    {
        public Company()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
