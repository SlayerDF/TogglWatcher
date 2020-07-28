using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher.TogglApi
{
    public interface ITogglApi
    {
        public Task<TogglTimeEntry> GetCurrentTimeEntry();
        public Task<List<TogglTimeEntry>> GetTimeEntries(DateTime from, DateTime to);
    }
}
