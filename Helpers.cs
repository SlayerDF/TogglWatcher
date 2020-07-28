using System;
using System.Collections.Generic;

namespace TogglWatcher
{
    public static class Helpers
    {
        public static string StringifySecondsDuration(long seconds)
        {
            var durationOffset = DateTimeOffset.FromUnixTimeSeconds(seconds);

            var parts = new List<string>();
            if (durationOffset.Hour > 0) parts.Add($"{durationOffset.Hour}h");
            if (durationOffset.Minute > 0) parts.Add($"{durationOffset.Minute}m");
            if (durationOffset.Second > 0) parts.Add($"{durationOffset.Second}s");

            return string.Join(' ', parts);
        }

        public static string TruncateString(string str, int maxLength = 10)
        {
            return str.Length > maxLength - 3 ? str.Substring(0, maxLength - 3) + "..." : str;
        }

        public static DateTime BeginningOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day);
        }
    }
}
