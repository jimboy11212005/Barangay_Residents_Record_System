using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BRRDesktop
{
    public static class ApiHelper
    {
        // Your existing ApiHelper.cs - BaseUrl FIXED
        private static readonly string BaseUrl = "http://localhost:5271/api/"; // ✅ Your port
        public static string Token { get; set; } = "";

        private static readonly HttpClient client;

        static ApiHelper()
        {
            var handler = new HttpClientHandler();
            // NOTE: Accepting all server certificates is convenient for development with self-signed certs.
            // Remove or tighten this in production.
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

            client = new HttpClient(handler)
            {
                BaseAddress = new Uri(BaseUrl, UriKind.Absolute),
                Timeout = TimeSpan.FromSeconds(30)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static void SetAuthHeader()
        {
            client.DefaultRequestHeaders.Authorization = null;
            if (!string.IsNullOrEmpty(Token))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }

        private static string NormalizeEndpoint(string endpoint) =>
            string.IsNullOrEmpty(endpoint) ? string.Empty : endpoint.TrimStart('/');

        public static async Task<T> Post<T>(string endpoint, object data)
        {
            try
            {
                SetAuthHeader();

                var requestUri = NormalizeEndpoint(endpoint);
                var json = data == null ? string.Empty : JsonConvert.SerializeObject(data);

                using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                {
                    var response = await client.PostAsync(requestUri, content).ConfigureAwait(false);
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (!response.IsSuccessStatusCode)
                        throw new Exception($"API Error: {response.StatusCode} - {result}");

                    if (typeof(T) == typeof(string))
                        return (T)(object)result;

                    return JsonConvert.DeserializeObject<T>(result);
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Cannot reach API. Check if backend is running and URL is correct.", ex);
            }
        }

        // Raw (string) overload for convenience
        public static Task<string> Post(string endpoint, object data) => Post<string>(endpoint, data);

        public static async Task<T> Get<T>(string endpoint)
        {
            SetAuthHeader();

            var requestUri = NormalizeEndpoint(endpoint);
            var response = await client.GetAsync(requestUri).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Error: {response.StatusCode} - {result}");

            if (typeof(T) == typeof(string))
                return (T)(object)result;

            return JsonConvert.DeserializeObject<T>(result);
        }

        public static Task<string> Get(string endpoint) => Get<string>(endpoint);

        public static async Task<T> Delete<T>(string endpoint)
        {
            SetAuthHeader();

            var requestUri = NormalizeEndpoint(endpoint);
            var response = await client.DeleteAsync(requestUri).ConfigureAwait(false);
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"API Error: {response.StatusCode} - {result}");

            if (typeof(T) == typeof(string))
                return (T)(object)result;

            return JsonConvert.DeserializeObject<T>(result);
        }

        public static Task<string> Delete(string endpoint) => Delete<string>(endpoint);
    }
}