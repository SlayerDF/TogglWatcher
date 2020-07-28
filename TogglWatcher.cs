using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher
{
    [Serializable]
    public class TogglWatcher : IDisposable, ISerializable
    {
        private TogglApi.TogglApi _api;
        private Timer _timer;
        private int _checkIntervalSeconds;

        public TogglTimeEntry LastEntry { get; private set; }

        public string Name { get; set; }
        public bool NotificationEnabled { get; set; }
        public int CheckIntervalSeconds { 
            get => _checkIntervalSeconds; 
            set
            {
                _checkIntervalSeconds = value;

                _timer.Change(1000 * _checkIntervalSeconds, 1000 * _checkIntervalSeconds);
            }
        }

        public delegate void EventHandler(TogglTimeEntry entry, bool notification);
        public event EventHandler StatusChanged; 

        public TogglWatcher(string apiToken, string name, int checkIntervalSeconds = 60, bool notificationEnabled = false)
        {
            _api = new TogglApi.TogglApi(apiToken);
            _checkIntervalSeconds = checkIntervalSeconds;
            _timer = new Timer(CheckTogglStatus, null, 1000 * _checkIntervalSeconds, 1000 * _checkIntervalSeconds);

            Name = name;
            NotificationEnabled = notificationEnabled;
        }

        public TogglWatcher(SerializationInfo info, StreamingContext context) : this(
            (string)info.GetValue("api_token", typeof(string)),
            (string)info.GetValue("name", typeof(string)),
            (int)info.GetValue("check_interval_seconds", typeof(int)),
            (bool)info.GetValue("notification_enabled", typeof(bool))
        ) {}

        public async Task<List<TogglTimeEntry>> GetTodayEntries()
        {
            var from = DateTime.Today;
            var to = from.AddDays(1).AddTicks(-1);

            return await _api.GetTimeEntries(from, to);
        }

        public void Refresh()
        {
            _api.GetCurrentTimeEntry().ContinueWith(task =>
            {
                if (task.IsCanceled) return;

                var changed = task.Result?.Id != LastEntry?.Id;

                LastEntry = task.Result;

                StatusChanged?.Invoke(task.Result, NotificationEnabled && changed);
            });
        }

        private void CheckTogglStatus(object state)
        {
            if (StatusChanged == null) return;

            Refresh();
        }

        public void Dispose()
        {
            _api.Dispose();
            _timer.Dispose();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("api_token", _api.GetApiToken(), typeof(string));
            info.AddValue("name", Name, typeof(string));
            info.AddValue("notification_enabled", NotificationEnabled, typeof(bool));
            info.AddValue("check_interval_seconds", CheckIntervalSeconds, typeof(int));
        }
    }
}
