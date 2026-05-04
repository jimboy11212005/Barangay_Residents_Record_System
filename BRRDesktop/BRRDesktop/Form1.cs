using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BarangayAdminDesktop; // keep if MainForm lives in that namespace

namespace BRRDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            btnLogin.Text = "Logging in...";

            try
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Please enter username and password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // payload — adjust property names if your API expects different (email / username)
                var loginData = new
                {
                    Username = txtEmail.Text,
                    Password = txtPassword.Text
                };

                var loginResponse = await ApiHelper.Post<LoginResponse>("/auth/login", loginData);

                if (string.IsNullOrEmpty(loginResponse?.Token))
                {
                    MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // persist token for subsequent API calls
                ApiHelper.Token = loginResponse.Token;
                Session.Token = loginResponse.Token;
                Session.AdminName = !string.IsNullOrWhiteSpace(loginResponse.FullName) ? loginResponse.FullName : loginResponse.Username;

                var displayName = !string.IsNullOrWhiteSpace(loginResponse.FullName) ? loginResponse.FullName : loginResponse.Username;
                var rolesText = loginResponse.Roles != null && loginResponse.Roles.Any()
                    ? string.Join(", ", loginResponse.Roles)
                    : loginResponse.Role ?? "(none)";

                MessageBox.Show($"✅ Login successful!\nUser: {displayName}\nRoles: {rolesText}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm main = new MainForm();
                main.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                // Try to extract server JSON {"message": "..."} if present
                string msg = ex.Message;
                try
                {
                    var idx = ex.Message.IndexOf('{');
                    if (idx >= 0)
                    {
                        var jsonPart = ex.Message.Substring(idx);
                        var jo = JObject.Parse(jsonPart);
                        if (jo["message"] != null) msg = jo["message"].ToString();
                        else if (jo["error"] != null) msg = jo["error"].ToString();
                        else msg = jo.ToString();
                    }
                }
                catch
                {
                    // ignore parse errors — keep original message
                }

                MessageBox.Show($"Login failed: {msg}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }
    }

    // Simplified LoginResponse — only what Form1 displays
    public class LoginResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonIgnore]
        public string FirstName { get; private set; }

        [JsonProperty("firstName")]
        private string FirstNameCamel { set { FirstName = value; } }

        [JsonProperty("first_name")]
        private string FirstNameSnake { set { FirstName = value; } }

        [JsonIgnore]
        public string LastName { get; private set; }

        [JsonProperty("lastName")]
        private string LastNameCamel { set { LastName = value; } }

        [JsonProperty("last_name")]
        private string LastNameSnake { set { LastName = value; } }

        [JsonIgnore]
        public string FullName
        {
            get
            {
                var parts = new List<string>();
                if (!string.IsNullOrWhiteSpace(FirstName)) parts.Add(FirstName);
                if (!string.IsNullOrWhiteSpace(LastName)) parts.Add(LastName);
                if (parts.Count > 0) return string.Join(" ", parts).Trim();
                return Username;
            }
        }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("roles")]
        private List<string> RolesList { get; set; }

        [JsonIgnore]
        public List<string> Roles
        {
            get
            {
                if (RolesList != null && RolesList.Count > 0) return RolesList;
                if (string.IsNullOrWhiteSpace(Role)) return new List<string>();
                return Role.Split(',').Select(s => s.Trim()).Where(s => !string.IsNullOrEmpty(s)).ToList();
            }
        }
    }
}