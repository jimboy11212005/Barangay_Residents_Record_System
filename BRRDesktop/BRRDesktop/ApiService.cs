using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BRRDesktop.Helpers;
using Newtonsoft.Json;

namespace BRRDesktop.Services
{
    public static class ApiService
    {
        public static string BaseUrl = "https://localhost:7001/api/";

        public static HttpClient client = new HttpClient();

        public static async Task<string> PostData(string endpoint, object data)
        {
            var json = JsonConvert.SerializeObject(data);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(BaseUrl + endpoint, content);

            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> GetData(string endpoint)
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", SessionManager.Token);

            var response = await client.GetAsync(BaseUrl + endpoint);

            return await response.Content.ReadAsStringAsync();
        }
    }
}