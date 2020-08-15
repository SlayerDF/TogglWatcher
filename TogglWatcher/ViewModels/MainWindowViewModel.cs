using ReactiveUI;
using System;
using System.Reactive;
using System.Reactive.Linq;
using TogglWatcher.Models;
using TogglWatcher.Services.Database;

namespace TogglWatcher.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase watcherPanelContent;

        public MainWindowViewModel(IDatabase db)
        {
            WatcherPanelContent = WatcherList = new WatcherListViewModel(db.Watchers);

            var watcherSelected = this
                .WhenAnyValue(x => x.WatcherList.SelectedItem)
                .Select(x => x != null);

            EditWatcherCommand = ReactiveCommand.Create(EditWatcher, watcherSelected);
            RemoveWatcherCommand = ReactiveCommand.Create(RemoveWatcher, watcherSelected);
        }

        public ViewModelBase WatcherPanelContent {
            get => watcherPanelContent;
            private set => this.RaiseAndSetIfChanged(ref watcherPanelContent, value);
        }

        public WatcherListViewModel WatcherList;

        public ReactiveCommand<Unit, Unit> EditWatcherCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveWatcherCommand { get; }

        public void AddWatcher()
        {
            var vm = new AddWatcherViewModel();

            Observable.Merge(
                vm.Create,
                vm.Back.Select(_ => (Watcher)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        WatcherList.Items.Add(model);
                    }

                    WatcherPanelContent = WatcherList;
                });

            WatcherPanelContent = vm;
        }

        private void EditWatcher()
        {
            var watcher = WatcherList.SelectedItem;

            var vm = new AddWatcherViewModel
            {
                Name = watcher.Name,
                ApiToken = watcher.ApiToken,
                Notify = watcher.Notify
            };

            Observable.Merge(
                vm.Create,
                vm.Back.Select(_ => (Watcher)null))
                .Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        watcher.Name = model.Name;
                        watcher.ApiToken = model.ApiToken;
                        watcher.Notify = model.Notify;
                    }

                    WatcherPanelContent = WatcherList;
                });

            WatcherPanelContent = vm;
        }

        private void RemoveWatcher()
        {
            var watcher = WatcherList.SelectedItem;

            WatcherList.Items.Remove(watcher);
        }
    }
}
