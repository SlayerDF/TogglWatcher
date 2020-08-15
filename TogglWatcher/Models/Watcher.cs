using System;
using System.Collections.Generic;
using System.Text;

namespace TogglWatcher.Models
{
    public class Watcher
    {
        public string Name { get; set; }
        public string ApiToken { get; set; }
        public bool Notify { get; set; }
    }
}
