using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;

namespace TogglWatcher.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            Closing += (s, e) =>
            {
                if ((Application.Current as App).NotifyIcon != null)
                {
                    Dispatcher.UIThread.Post(() =>
                    {
                        ((Window)s).Hide();
                    });
                    (Application.Current as App).NotifyIcon.Visible = true;

                    e.Cancel = true;
                }
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
