using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpedcordClient.Views
{
    public partial class DummyView : UserControl
    {
        public DummyView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
