using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRRDesktop.Services; // keep if MainForm lives in that namespace
using BRRDesktop.Models;
using BRRDesktop.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            LoginModel login = new LoginModel()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Text
            };

            try
            {
                var response = await ApiService.PostData("auth/login", login);

                JObject obj = JObject.Parse(response);

                SessionManager.Token = obj["token"].ToString();
                SessionManager.Username = obj["username"].ToString();
                SessionManager.Role = obj["role"].ToString();

                MessageBox.Show("Login Successful");

                Dashboard dashboard = new Dashboard();
                dashboard.Show();

                this.Hide();
            }
            catch
            {
                MessageBox.Show("Invalid Login Credentials");
            }



            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private void chkShowPassword_CheckedChanged_1(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
    }
}