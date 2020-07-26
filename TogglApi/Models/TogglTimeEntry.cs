using System;

namespace TogglWatcher.TogglApi.Models
{
    public class TogglTimeEntry
	{
		private long _duration;

        public int Id { get; set; }
		public int Wid { get; set; }
		public int Pid { get; set; }
		public bool Billable { get; set; }
		public DateTime Start { get; set; }
		public long Duration {
			get => _duration;
			set
			{
				_duration = value;

				if (_duration < 0)
                {
					_duration += (int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
				}
			}
		}
		public string Description { get; set; }
		public DateTime At { get; set; }
    }
}
