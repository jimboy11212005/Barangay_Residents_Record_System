using System;
using System.Windows.Forms;
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
        public static string BaseUrl =
            "https://localhost:7283/api/";

        public static HttpClient client =
            new HttpClient();

        // =========================
        // GET
        // =========================

        public static async Task<string>
            GetData(string endpoint)
        {
            try
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(
                        "Bearer",
                        SessionManager.Token
                    );

                HttpResponseMessage response =
                    await client.GetAsync(
                        BaseUrl + endpoint
                    );

                response.EnsureSuccessStatusCode();

                return await response.Content
                    .ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );

                return "";
            }
        }

        // =========================
        // POST
        // =========================

        public static async Task<string>
            PostData(string endpoint, object data)
        {
            try
            {
                var json =
                    JsonConvert.SerializeObject(data);

                var content =
                    new StringContent(
                        json,
                        Encoding.UTF8,
                        "application/json"
                    );

                HttpResponseMessage response =
                    await client.PostAsync(
                        BaseUrl + endpoint,
                        content
                    );

                response.EnsureSuccessStatusCode();

                return await response.Content
                    .ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );

                return "";
            }
        }
    }
}