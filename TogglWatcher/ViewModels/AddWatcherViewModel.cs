using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using TogglWatcher.Models;

namespace TogglWatcher.ViewModels
{
    public class AddWatcherViewModel : ViewModelBase
    {
        string name;
        string apiToken;

        public AddWatcherViewModel()
        {
            var createEnabled = this
                .WhenAnyValue(x => x.Name, x => x.ApiToken, (name, apiToken) => new { Name = name, ApiToken = apiToken })
                .Select(x => !string.IsNullOrEmpty(x.Name) && !string.IsNullOrEmpty(x.ApiToken));

            Create = ReactiveCommand.Create(
                () => new Watcher { Name = Name, ApiToken = ApiToken, Notify = Notify },
                createEnabled);
            Back = ReactiveCommand.Create(() => {});
        }

        public string Name { 
            get => name; 
            set => this.RaiseAndSetIfChanged(ref name, value);
        }

        public string ApiToken
        {
            get => apiToken;
            set => this.RaiseAndSetIfChanged(ref apiToken, value);
        }

        public bool Notify { get; set; }

        public ReactiveCommand<Unit, Watcher> Create { get; }
        public ReactiveCommand<Unit, Unit> Back { get; }
    }
}
