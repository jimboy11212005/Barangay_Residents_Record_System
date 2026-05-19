using System;
using System.Drawing;
using System.Windows.Forms;
using BRRDesktop.Helpers;
using BRRDesktop.Models;
using BRRDesktop.Services;
using Newtonsoft.Json.Linq;

namespace BRRDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // FORM
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(220, 220, 220);

            // MAIN PANEL
            Guna.UI2.WinForms.Guna2Panel mainPanel =
                new Guna.UI2.WinForms.Guna2Panel();

            mainPanel.Size = new Size(760, 410);
            mainPanel.Location = new Point(20, 20);
            mainPanel.FillColor = Color.White;
            mainPanel.BorderRadius = 20;

            Controls.Add(mainPanel);

            // =========================
            // LEFT PANEL
            // =========================
            Panel leftPanel = new Panel();

            leftPanel.Size = new Size(280, 410);
            leftPanel.Location = new Point(0, 0);

            leftPanel.BackColor =
                Color.FromArgb(37, 99, 235);

            mainPanel.Controls.Add(leftPanel);

            // TITLE
            Label lblTitle = new Label();

            lblTitle.Text =
                "Barangay\nResidents\nRecords System";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold
                );

            lblTitle.ForeColor = Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(35, 90);

            leftPanel.Controls.Add(lblTitle);

            // DESCRIPTION
            Label lblDesc = new Label();

            lblDesc.Text =
                "Securely manage residents\nrecords with a modern\nand efficient system.";

            lblDesc.Font =
                new Font("Segoe UI", 10);

            lblDesc.ForeColor =
                Color.WhiteSmoke;

            lblDesc.AutoSize = true;

            lblDesc.Location =
                new Point(40, 220);

            leftPanel.Controls.Add(lblDesc);

            // =========================
            // RIGHT PANEL
            // =========================
            Panel rightPanel = new Panel();

            rightPanel.Size = new Size(480, 410);

            rightPanel.Location =
                new Point(280, 0);

            rightPanel.BackColor = Color.White;

            mainPanel.Controls.Add(rightPanel);

            // CLOSE BUTTON
            Label btnClose = new Label();

            btnClose.Text = "✕";

            btnClose.Font =
                new Font(
                    "Segoe UI",
                    14,
                    FontStyle.Bold
                );

            btnClose.ForeColor = Color.Gray;

            btnClose.AutoSize = true;

            btnClose.Cursor = Cursors.Hand;

            btnClose.Location =
                new Point(430, 15);

            btnClose.Click += (s, e) =>
            {
                Application.Exit();
            };

            rightPanel.Controls.Add(btnClose);

            // WELCOME LABEL
            Label lblWelcome = new Label();

            lblWelcome.Text =
                "Welcome Back";

            lblWelcome.Font =
                new Font(
                    "Segoe UI",
                    22,
                    FontStyle.Bold
                );

            lblWelcome.ForeColor =
                Color.FromArgb(30, 41, 59);

            lblWelcome.AutoSize = true;

            lblWelcome.Location =
                new Point(110, 60);

            rightPanel.Controls.Add(lblWelcome);

            // SUBTITLE
            Label lblSub = new Label();

            lblSub.Text =
                "Login to continue";

            lblSub.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            lblSub.ForeColor = Color.Gray;

            lblSub.AutoSize = true;

            lblSub.Location =
                new Point(155, 105);

            rightPanel.Controls.Add(lblSub);

            // USERNAME TEXTBOX
            Guna.UI2.WinForms.Guna2TextBox txtUsername =
                new Guna.UI2.WinForms.Guna2TextBox();

            txtUsername.PlaceholderText =
                "Username";

            txtUsername.Size =
                new Size(300, 45);

            txtUsername.Location =
                new Point(90, 160);

            txtUsername.BorderRadius = 10;

            txtUsername.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            rightPanel.Controls.Add(txtUsername);

            // PASSWORD TEXTBOX
            Guna.UI2.WinForms.Guna2TextBox txtPassword =
                new Guna.UI2.WinForms.Guna2TextBox();

            txtPassword.PlaceholderText =
                "Password";

            txtPassword.PasswordChar = '●';

            txtPassword.Size =
                new Size(300, 45);

            txtPassword.Location =
                new Point(90, 225);

            txtPassword.BorderRadius = 10;

            txtPassword.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            rightPanel.Controls.Add(txtPassword);

            // SHOW PASSWORD BUTTON
            Guna.UI2.WinForms.Guna2Button btnShow =
                new Guna.UI2.WinForms.Guna2Button();

            btnShow.Text = "👁";

            btnShow.Size =
                new Size(45, 45);

            btnShow.Location =
                new Point(395, 255);

            btnShow.BorderRadius = 10;

            btnShow.FillColor = Color.White;

            btnShow.ForeColor = Color.Gray;

            btnShow.BorderThickness = 1;

            btnShow.BorderColor =
                Color.LightGray;

            bool showPassword = false;

            btnShow.Click += (s, e) =>
            {
                showPassword = !showPassword;

                if (showPassword)
                {
                    txtPassword.PasswordChar = '\0';
                    btnShow.Text = "🙈";
                }
                else
                {
                    txtPassword.PasswordChar = '●';
                    btnShow.Text = "👁";
                }
            };

            rightPanel.Controls.Add(btnShow);

            // LOGIN BUTTON
            Guna.UI2.WinForms.Guna2Button btnLogin =
                new Guna.UI2.WinForms.Guna2Button();

            btnLogin.Text = "LOGIN";

            btnLogin.Size =
                new Size(300, 45);

            btnLogin.Location =
                new Point(90, 330);

            btnLogin.BorderRadius = 10;

            btnLogin.FillColor =
                Color.FromArgb(37, 99, 235);

            btnLogin.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnLogin.HoverState.FillColor =
                Color.FromArgb(29, 78, 216);

            btnLogin.Click += async (s, e) =>
            {
                LoginModel login =
                    new LoginModel()
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text
                    };

                try
                {
                    btnLogin.Enabled = false;

                    btnLogin.Text =
                        "PLEASE WAIT...";

                    string response =
                        await ApiService.PostData(
                            "auth/login",
                            login
                        );

                    JObject obj =
                        JObject.Parse(response);

                    SessionManager.Token =
                        obj["token"].ToString();

                    Dashboard dashboard =
                        new Dashboard();

                    dashboard.Show();

                    this.Hide();
                }
                catch
                {
                    MessageBox.Show(
                        "Invalid Username or Password",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                finally
                {
                    btnLogin.Enabled = true;

                    btnLogin.Text = "LOGIN";
                }
            };

            rightPanel.Controls.Add(btnLogin);

            
        }
    }
}