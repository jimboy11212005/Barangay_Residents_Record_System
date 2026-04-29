using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace BRRDesktop
{
    public partial class Form1 : Form
    {
        public static string token = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var data = new
                    {
                        email = txtEmail.Text,
                        password = txtPassword.Text
                    };

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("http://localhost:3000/api/auth/login", content);

                    var result = await response.Content.ReadAsStringAsync();

                    dynamic obj = JsonConvert.DeserializeObject(result);

                    token = obj.token;

                    Dashboard dash = new Dashboard();
                    dash.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
