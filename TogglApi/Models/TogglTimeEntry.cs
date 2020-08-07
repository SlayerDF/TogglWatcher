using System;

namespace TogglWatcher.TogglApi.Models
{
    public class TogglTimeEntry
	{
		private long _duration;
		private string _description = "(no description)";

        public int Id { get; set; }
		public int Wid { get; set; }
		public int Pid { get; set; }
		public bool Billable { get; set; }
		public DateTime Start { get; set; }
		public DateTime Stop { get; set; }
		public DateTime End => Stop != default ? Stop : Start.AddSeconds(Duration);
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
		public string Description { 
			get => _description;
			set {
				_description = value;

				if (string.IsNullOrEmpty(value)) _description = "(no description)";
			}
		}
		public DateTime At { get; set; }
    }
}
