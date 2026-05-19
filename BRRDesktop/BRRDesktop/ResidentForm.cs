using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRRDesktop.Models;
using BRRDesktop.Services;
using Newtonsoft.Json;

namespace BRRDesktop
{
    public partial class ResidentForm : Form
    {
        private Guna.UI2.WinForms.Guna2DataGridView dgv;

        private List<Resident> residentList =
            new List<Resident>();

        private Guna.UI2.WinForms.Guna2TextBox txtSearch;

        private Guna.UI2.WinForms.Guna2ComboBox cbPurok;

        private Guna.UI2.WinForms.Guna2ComboBox cbGender;

        public ResidentForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            SetupUI();

            Load += async (s, e) =>
            {
                await LoadResidents();
            };
        }

        // =========================
        // LOAD RESIDENTS
        // =========================

        private async Task LoadResidents()
        {
            try
            {
                string response =
                    await ApiService.GetData(
                        "residents"
                    );

                residentList =
                    JsonConvert.DeserializeObject
                    <List<Resident>>(response)
                    ?? new List<Resident>();

                LoadGrid(residentList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
        }

        // =========================
        // LOAD GRID
        // =========================

        private void LoadGrid(
            List<Resident> residents
        )
        {
            dgv.DataSource = null;

            dgv.DataSource =
                residents.Select(r => new
                {
                    ID = r.ResidentId,

                    FirstName = r.FirstName,

                    LastName = r.LastName,

                    Gender = r.Gender,

                    Address = r.Address,

                    Age = r.Age,

                    Purok = r.Purok,

                    PWD = r.PwdStatus
                }).ToList();
        }

        // =========================
        // FILTER
        // =========================

        private void ApplyFilters()
        {
            var filtered =
                residentList.AsQueryable();

            // SEARCH

            if (!string.IsNullOrWhiteSpace(
                txtSearch.Text))
            {
                filtered =
                    filtered.Where(r =>
                        r.FirstName
                            .ToLower()
                            .Contains(
                                txtSearch.Text.ToLower()
                            )
                        ||
                        r.LastName
                            .ToLower()
                            .Contains(
                                txtSearch.Text.ToLower()
                            )
                    );
            }

            // PUROK

            if (cbPurok.SelectedIndex > 0)
            {
                filtered =
                    filtered.Where(r =>
                        r.Purok ==
                        cbPurok.Text
                    );
            }

            // GENDER

            if (cbGender.SelectedIndex > 0)
            {
                filtered =
                    filtered.Where(r =>
                        r.Gender ==
                        cbGender.Text
                    );
            }

            LoadGrid(filtered.ToList());
        }

        // =========================
        // UI
        // =========================

        private void SetupUI()
        {
            // FORM

            this.Text =
                "Residents";

            this.Size =
                new Size(1280, 720);

            this.StartPosition =
                FormStartPosition.CenterScreen;

            this.BackColor =
                Color.FromArgb(241, 245, 249);

            this.FormBorderStyle =
                FormBorderStyle.None;

            // =========================
            // HEADER
            // =========================

            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Residents Management";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    26,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(30, 20);

            Controls.Add(lblTitle);

            Label lblSub =
                new Label();

            lblSub.Text =
                "Manage and monitor all barangay residents";

            lblSub.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            lblSub.ForeColor =
                Color.Gray;

            lblSub.AutoSize = true;

            lblSub.Location =
                new Point(35, 70);

            Controls.Add(lblSub);

            // =========================
            // ADD BUTTON
            // =========================

            Guna.UI2.WinForms.Guna2Button btnAdd =
                new Guna.UI2.WinForms.Guna2Button();

            btnAdd.Text =
                "+ Add Resident";

            btnAdd.Size =
                new Size(180, 45);

            btnAdd.Location =
                new Point(1020, 35);

            btnAdd.FillColor =
                Color.FromArgb(37, 99, 235);

            btnAdd.BorderRadius = 12;

            btnAdd.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnAdd.Click += async (s, e) =>
            {
                AddResidentForm form =
                    new AddResidentForm();

                if (form.ShowDialog() ==
                    DialogResult.OK)
                {
                    await LoadResidents();
                }
            };

            Controls.Add(btnAdd);

            // =========================
            // MAIN PANEL
            // =========================

            Guna.UI2.WinForms.Guna2Panel mainPanel =
                new Guna.UI2.WinForms.Guna2Panel();

            mainPanel.Size =
                new Size(1210, 560);

            mainPanel.Location =
                new Point(30, 110);

            mainPanel.FillColor =
                Color.White;

            mainPanel.BorderRadius = 20;

            mainPanel.ShadowDecoration.Enabled = true;

            mainPanel.ShadowDecoration.Depth = 15;

            Controls.Add(mainPanel);

            // =========================
            // SEARCH
            // =========================

            txtSearch =
                new Guna.UI2.WinForms.Guna2TextBox();

            txtSearch.PlaceholderText =
                "Search resident...";

            txtSearch.Size =
                new Size(250, 42);

            txtSearch.Location =
                new Point(25, 25);

            txtSearch.BorderRadius = 10;

            txtSearch.TextChanged +=
                (s, e) =>
                {
                    ApplyFilters();
                };

            mainPanel.Controls.Add(txtSearch);

            // =========================
            // PUROK FILTER
            // =========================

            cbPurok =
                new Guna.UI2.WinForms.Guna2ComboBox();

            cbPurok.Size =
                new Size(160, 42);

            cbPurok.Location =
                new Point(290, 25);

            cbPurok.BorderRadius = 10;

            cbPurok.Items.AddRange(
                new string[]
                {
                    "All Purok",
                    "Purok 1",
                    "Purok 2",
                    "Purok 3",
                    "Purok 4"
                });

            cbPurok.SelectedIndex = 0;

            cbPurok.SelectedIndexChanged +=
                (s, e) =>
                {
                    ApplyFilters();
                };

            mainPanel.Controls.Add(cbPurok);

            // =========================
            // GENDER FILTER
            // =========================

            cbGender =
                new Guna.UI2.WinForms.Guna2ComboBox();

            cbGender.Size =
                new Size(160, 42);

            cbGender.Location =
                new Point(470, 25);

            cbGender.BorderRadius = 10;

            cbGender.Items.AddRange(
                new string[]
                {
                    "All Gender",
                    "Male",
                    "Female"
                });

            cbGender.SelectedIndex = 0;

            cbGender.SelectedIndexChanged +=
                (s, e) =>
                {
                    ApplyFilters();
                };

            mainPanel.Controls.Add(cbGender);

            // =========================
            // REFRESH BUTTON
            // =========================

            Guna.UI2.WinForms.Guna2Button btnRefresh =
                new Guna.UI2.WinForms.Guna2Button();

            btnRefresh.Text =
                "Refresh";

            btnRefresh.Size =
                new Size(130, 42);

            btnRefresh.Location =
                new Point(650, 25);

            btnRefresh.FillColor =
                Color.FromArgb(30, 41, 59);

            btnRefresh.BorderRadius = 10;

            btnRefresh.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold
                );

            btnRefresh.Click += async (s, e) =>
            {
                await LoadResidents();
            };

            mainPanel.Controls.Add(btnRefresh);

            // =========================
            // DATAGRIDVIEW
            // =========================

            dgv =
                new Guna.UI2.WinForms.Guna2DataGridView();

            dgv.Size =
                new Size(1160, 430);

            dgv.Location =
                new Point(25, 90);

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowHeadersVisible = false;

            dgv.BackgroundColor =
                Color.White;

            dgv.BorderStyle =
                BorderStyle.None;

            dgv.AllowUserToAddRows = false;

            dgv.ReadOnly = true;

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgv.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(248, 250, 252);

            dgv.ThemeStyle.HeaderStyle.BackColor =
                Color.FromArgb(15, 23, 42);

            dgv.ThemeStyle.HeaderStyle.ForeColor =
                Color.White;

            dgv.ThemeStyle.RowsStyle.SelectionBackColor =
                Color.FromArgb(219, 234, 254);

            dgv.ColumnHeadersHeight = 40;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            mainPanel.Controls.Add(dgv);

            // =========================
            // CLOSE BUTTON
            // =========================

            Guna.UI2.WinForms.Guna2Button btnClose =
                new Guna.UI2.WinForms.Guna2Button();

            btnClose.Text = "X";

            btnClose.Size =
                new Size(42, 42);

            btnClose.Location =
                new Point(1210, 20);

            btnClose.FillColor =
                Color.FromArgb(239, 68, 68);

            btnClose.BorderRadius = 10;

            btnClose.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnClose.Click += (s, e) =>
            {
                this.Close();
            };

            Controls.Add(btnClose);
        }
    }
}