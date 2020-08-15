using System.Collections.Generic;
using TogglWatcher.Models;

namespace TogglWatcher.Services.Database
{
    public class FakeDatabase : IDatabase
    {
        public IEnumerable<Watcher> Watchers { get; set; } = new List<Watcher>
        {
            new Watcher() { Name = "MyToggl", ApiToken = "ApiToken", Notify = true }
        };
    }
}
