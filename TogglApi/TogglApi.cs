using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TogglWatcher.TogglApi.Models;

namespace TogglWatcher.TogglApi
{
    public class TogglApi : ITogglApi, IDisposable
    {
        private readonly HttpClient _client;
        public readonly string _token;

        private bool _authenticated = false;

        public TogglApi(string apiToken)
        {
            _token = apiToken;
            _client = new HttpClient();
        }

        public async Task<TogglTimeEntry> GetCurrentTimeEntry()
        {
            try
            {
                var togglRespRaw = await ValidateResponseAndGetString(() => _client.GetAsync("https://www.toggl.com/api/v8/time_entries/current"));

                var togglResp = JsonConvert.DeserializeObject<TogglResponse<TogglTimeEntry>>(togglRespRaw);

                return togglResp.Data;
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"couldn't get current time entry: {e.Message}");
            }
        }

        public void Dispose()
        {
            _client.Dispose();
        }

        public string GetApiToken()
        {
            return _token;
        }

        private async Task Authenticate()
        {
            try
            {
                var encodedToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_token}:api_token"));

                var message = new HttpRequestMessage(HttpMethod.Post, "https://www.toggl.com/api/v8/sessions");
                message.Content = new StringContent("");
                message.Headers.Authorization = new AuthenticationHeaderValue("Basic", encodedToken);

                var resp = await _client.SendAsync(message);

                resp.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                throw new Exception($"couldn't authenticate with specified token: {e.Message}");
            }
        }

        private async Task<HttpResponseMessage> ValidateResponse(Func<Task<HttpResponseMessage>> func)
        {
            if (!_authenticated)
            {
                await Authenticate();

                _authenticated = true;
            }

            var resp = await func();

            if (resp.StatusCode == HttpStatusCode.Forbidden)
            {
                await Authenticate();

                resp = await func();
            }

            resp.EnsureSuccessStatusCode();

            return resp;
        }

        private async Task<string> ValidateResponseAndGetString(Func<Task<HttpResponseMessage>> func)
        {
            var resp = await ValidateResponse(func);

            return await resp.Content.ReadAsStringAsync();
        }
    }
}
