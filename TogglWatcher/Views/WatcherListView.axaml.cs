using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TogglWatcher.Views
{
    public class WatcherListView : UserControl
    {
        public WatcherListView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
