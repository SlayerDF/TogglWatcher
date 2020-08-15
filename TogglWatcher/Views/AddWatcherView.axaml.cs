using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TogglWatcher.Views
{
    public class AddWatcherView : UserControl
    {
        public AddWatcherView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
