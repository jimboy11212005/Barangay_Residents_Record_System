using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BRRDesktop.Models;
using BRRDesktop.Services;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Newtonsoft.Json;

namespace BRRDesktop
{
    public partial class Dashboard : Form
    {
        private Panel contentPanel;

        public Dashboard()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            SetupDashboard();
        }

        private async void SetupDashboard()
        {
            // =========================
            // FORM
            // =========================

            this.Size = new Size(1366, 768);

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.BackColor =
                System.Drawing.Color.AliceBlue;

            // =========================
            // SIDEBAR
            // =========================

            Panel sidebar = new Panel();

            sidebar.Width = 220;

            sidebar.Height = this.Height;

            sidebar.Dock = DockStyle.Left;

            sidebar.BackColor =
                System.Drawing.Color.FromArgb(15, 23, 42);

            Controls.Add(sidebar);

            // =========================
            // LOGO
            // =========================

            Label lblLogo = new Label();

            lblLogo.Text =
                "🏠 BRR SYSTEM";

            lblLogo.Font =
                new Font(
                    "Segoe UI",
                    17,
                    FontStyle.Bold
                );

            lblLogo.ForeColor =
                System.Drawing.Color.White;

            lblLogo.AutoSize = true;

            lblLogo.Location =
                new Point(25, 35);

            sidebar.Controls.Add(lblLogo);

            // =========================
            // MENU BUTTON METHOD
            // =========================

            Guna.UI2.WinForms.Guna2Button CreateMenuButton(
                string text,
                Point location,
                System.Drawing.Color fillColor
            )
            {
                Guna.UI2.WinForms.Guna2Button btn =
                    new Guna.UI2.WinForms.Guna2Button();

                btn.Text = text;

                btn.Size =
                    new Size(185, 45);

                btn.Location = location;

                btn.FillColor = fillColor;

                btn.BorderRadius = 12;

                btn.Font =
                    new Font(
                        "Segoe UI",
                        10,
                        FontStyle.Bold
                    );

                btn.ForeColor =
                    System.Drawing.Color.White;

                btn.HoverState.FillColor =
                    System.Drawing.Color.FromArgb(59, 130, 246);

                sidebar.Controls.Add(btn);

                return btn;
            }

            var btnDashboard =
                CreateMenuButton(
                    "Dashboard",
                    new Point(18, 140),
                    System.Drawing.Color.FromArgb(37, 99, 235)
                );

            var btnResidents =
                CreateMenuButton(
                    "Residents",
                    new Point(18, 200),
                    System.Drawing.Color.FromArgb(30, 41, 59)
                );

            var btnExit =
                CreateMenuButton(
                    "Exit",
                    new Point(18, 680),
                    System.Drawing.Color.FromArgb(239, 68, 68)
                );

            btnExit.Click += (s, e) =>
            {
                Application.Exit();
            };

            // =========================
            // CONTENT PANEL
            // =========================

            contentPanel = new Panel();

            contentPanel.Location =
                new Point(220, 0);

            contentPanel.Size =
                new Size(
                    this.Width - 220,
                    this.Height
                );

            contentPanel.BackColor =
                System.Drawing.Color.AliceBlue;

            Controls.Add(contentPanel);

            // =========================
            // TITLE
            // =========================

            Label lblTitle = new Label();

            lblTitle.Text =
                "Dashboard Overview";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    27,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                System.Drawing.Color.FromArgb(15, 23, 42);

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(60, 30);

            contentPanel.Controls.Add(lblTitle);

            // =========================
            // SUBTITLE
            // =========================

            Label lblSub = new Label();

            lblSub.Text =
                "Welcome to Our Community";

            lblSub.Font =
                new Font(
                    "Segoe UI",
                    11
                );

            lblSub.ForeColor =
                System.Drawing.Color.Gray;

            lblSub.AutoSize = true;

            lblSub.Location =
                new Point(65, 78);

            contentPanel.Controls.Add(lblSub);

            try
            {
                // =========================
                // API
                // =========================

                string response =
                    await ApiService.GetData(
                        "residents"
                    );

                List<Resident> residents =
                    JsonConvert.DeserializeObject
                    <List<Resident>>(response)
                    ?? new List<Resident>();

                // =========================
                // COUNTS
                // =========================

                int totalResidents =
                    residents.Count;

                int children =
                    residents.Where(r => r.Age <= 12).Count();

                int adults =
                    residents.Where(r =>
                        r.Age >= 18 &&
                        r.Age <= 59
                    ).Count();

                int seniors =
                    residents.Where(r => r.Age >= 60).Count();

                int pwd =
                    residents.Where(r =>
                        r.PwdStatus == "Yes"
                    ).Count();

                // =========================
                // CARDS
                // =========================

                CreateCard(
                    "Total Residents",
                    totalResidents.ToString(),
                    new Point(60, 130),
                    System.Drawing.Color.FromArgb(37, 99, 235)
                );

                CreateCard(
                    "Children",
                    children.ToString(),
                    new Point(275, 130),
                    System.Drawing.Color.FromArgb(16, 185, 129)
                );

                CreateCard(
                    "Adults",
                    adults.ToString(),
                    new Point(490, 130),
                    System.Drawing.Color.FromArgb(249, 115, 22)
                );

                CreateCard(
                    "Seniors",
                    seniors.ToString(),
                    new Point(705, 130),
                    System.Drawing.Color.FromArgb(239, 68, 68)
                );

                CreateCard(
                    "PWD",
                    pwd.ToString(),
                    new Point(920, 130),
                    System.Drawing.Color.FromArgb(168, 85, 247)
                );

                // =========================
                // PIE CHART PANEL
                // =========================

                Guna.UI2.WinForms.Guna2Panel chartPanel =
                    new Guna.UI2.WinForms.Guna2Panel();

                chartPanel.Size =
                    new Size(430, 350);

                chartPanel.Location =
                    new Point(60, 290);

                chartPanel.FillColor =
                    System.Drawing.Color.White;

                chartPanel.BorderRadius = 20;

                chartPanel.ShadowDecoration.Enabled = true;

                chartPanel.ShadowDecoration.Depth = 15;

                contentPanel.Controls.Add(chartPanel);

                // TITLE

                Label lblChart = new Label();

                lblChart.Text =
                    "Residents by Purok";

                lblChart.Font =
                    new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                lblChart.ForeColor =
                    System.Drawing.Color.FromArgb(15, 23, 42);

                lblChart.AutoSize = true;

                lblChart.Location =
                    new Point(20, 15);

                chartPanel.Controls.Add(lblChart);

                // =========================
                // PIE CHART
                // =========================
                LiveCharts.WinForms.PieChart pieChart = new LiveCharts.WinForms.PieChart();

                pieChart.Location =
                    new Point(20, 55);

                pieChart.Size =
                    new Size(360, 230);

                pieChart.BackColor =
                    System.Drawing.Color.White;

                pieChart.LegendLocation =
                    LegendLocation.Right;

                pieChart.InnerRadius = 40;

                pieChart.DisableAnimations = true;

                SeriesCollection series =
                    new SeriesCollection();

                int colorIndex = 0;

                System.Drawing.Color[] colors =
                {
                    System.Drawing.Color.FromArgb(59,130,246),
                    System.Drawing.Color.FromArgb(16,185,129),
                    System.Drawing.Color.FromArgb(249,115,22),
                    System.Drawing.Color.FromArgb(239,68,68),
                    System.Drawing.Color.FromArgb(168,85,247),
                    System.Drawing.Color.FromArgb(14,165,233)
                };

                var purokGroups =
                    residents
                    .Where(x => !string.IsNullOrEmpty(x.Purok))
                    .GroupBy(x => x.Purok)
                    .Select(g => new
                    {
                        Purok = g.Key,
                        Count = g.Count()
                    });

                foreach (var item in purokGroups)
                {
                    var drawingColor =
                        colors[colorIndex % colors.Length];

                    var mediaColor =
                        System.Windows.Media.Color.FromRgb(
                            drawingColor.R,
                            drawingColor.G,
                            drawingColor.B
                        );

                    series.Add(
                        new PieSeries
                        {
                            Title = item.Purok,

                            Values =
                                new ChartValues<int>
                                {
                                    item.Count
                                },

                            DataLabels = true,

                            FontSize = 11,

                            Foreground =
                                System.Windows.Media.Brushes.White,

                            Fill =
                                new System.Windows.Media.SolidColorBrush(mediaColor)
                        }
                    );

                    colorIndex++;
                }

                pieChart.Series = series;

                chartPanel.Controls.Add(pieChart);

                // =========================
                // RECENT PANEL
                // =========================

                Guna.UI2.WinForms.Guna2Panel recentPanel =
                    new Guna.UI2.WinForms.Guna2Panel();

                recentPanel.Size =
                    new Size(560, 350);

                recentPanel.Location =
                    new Point(510, 290);

                recentPanel.FillColor =
                    System.Drawing.Color.White;

                recentPanel.BorderRadius = 20;

                recentPanel.ShadowDecoration.Enabled = true;

                recentPanel.ShadowDecoration.Depth = 15;

                contentPanel.Controls.Add(recentPanel);

                // TITLE

                Label lblRecent =
                    new Label();

                lblRecent.Text =
                    "Recent Registered Residents";

                lblRecent.Font =
                    new Font(
                        "Segoe UI",
                        14,
                        FontStyle.Bold
                    );

                lblRecent.ForeColor =
                    System.Drawing.Color.FromArgb(15, 23, 42);

                lblRecent.AutoSize = true;

                lblRecent.Location =
                    new Point(20, 15);

                recentPanel.Controls.Add(lblRecent);

                // DATAGRIDVIEW

                Guna.UI2.WinForms.Guna2DataGridView dgv =
                    new Guna.UI2.WinForms.Guna2DataGridView();

                dgv.Size =
                    new Size(520, 250);

                dgv.Location =
                    new Point(20, 55);

                dgv.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;

                dgv.RowHeadersVisible = false;

                dgv.BackgroundColor =
                    System.Drawing.Color.White;

                dgv.AllowUserToAddRows = false;

                dgv.ReadOnly = true;

                dgv.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgv.ThemeStyle.HeaderStyle.BackColor =
                    System.Drawing.Color.FromArgb(15, 23, 42);

                dgv.ThemeStyle.HeaderStyle.ForeColor =
                    System.Drawing.Color.White;

                dgv.ThemeStyle.RowsStyle.SelectionBackColor =
                    System.Drawing.Color.FromArgb(219, 234, 254);

                dgv.DataSource =
                    residents
                    .OrderByDescending(r => r.ResidentId)
                    .Take(10)
                    .ToList();

                recentPanel.Controls.Add(dgv);

                // BUTTON EVENT

                btnResidents.Click += (s, e) =>
                {
                    ResidentForm form =
                        new ResidentForm();

                    form.Show();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // =========================
        // CREATE CARD
        // =========================

        private void CreateCard(
            string title,
            string value,
            Point location,
            System.Drawing.Color color
        )
        {
            Guna.UI2.WinForms.Guna2Panel card =
                new Guna.UI2.WinForms.Guna2Panel();

            card.Size =
                new Size(190, 110);

            card.Location =
                location;

            card.FillColor =
                color;

            card.BorderRadius = 18;

            card.ShadowDecoration.Enabled = true;

            card.ShadowDecoration.Depth = 12;

            Label lblTitle =
                new Label();

            lblTitle.Text = title;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                System.Drawing.Color.White;

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(18, 18);

            card.Controls.Add(lblTitle);

            Label lblValue =
                new Label();

            lblValue.Text = value;

            lblValue.Font =
                new Font(
                    "Segoe UI",
                    28,
                    FontStyle.Bold
                );

            lblValue.ForeColor =
                System.Drawing.Color.White;

            lblValue.AutoSize = true;

            lblValue.Location =
                new Point(18, 45);

            card.Controls.Add(lblValue);

            contentPanel.Controls.Add(card);
        }
    }
}