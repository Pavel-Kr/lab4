using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace lab4.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            Width = 450;
            Height = 450;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
