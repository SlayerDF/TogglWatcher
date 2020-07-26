using System.Threading.Tasks;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher.TogglApi
{
    public interface ITogglApi
    {
        public Task<TogglTimeEntry> GetCurrentTimeEntry();
    }
}
