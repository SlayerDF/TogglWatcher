using ReactiveUI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TogglWatcher.Models;

namespace TogglWatcher.ViewModels
{
    public class WatcherListViewModel : ViewModelBase
    {
        Watcher selectedItem;

        public WatcherListViewModel(IEnumerable<Watcher> items)
        {
            Items = new ObservableCollection<Watcher>(items);
        }

        public ObservableCollection<Watcher> Items { get; }

        public Watcher SelectedItem {
            get => selectedItem;
            set => this.RaiseAndSetIfChanged(ref selectedItem, value);
        }
    }
}
