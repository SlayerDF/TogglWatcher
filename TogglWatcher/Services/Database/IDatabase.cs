using System.Collections.Generic;
using TogglWatcher.Models;

namespace TogglWatcher.Services.Database
{
    public interface IDatabase
    {
        public IEnumerable<Watcher> Watchers { get; set; }
    }
}
