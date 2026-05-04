using System;
using System.Windows.Forms;
using BRRDesktop;

namespace BarangayAdminDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // Ensure designer controls are wired to their handlers (designer file may not have events assigned)
            if (btnDashboard != null) btnDashboard.Click += btnDashboard_Click;
            if (btnHousehold != null) btnHousehold.Click += btnHousehold_Click;
            if (btnResidents != null) btnResidents.Click += btnResidents_Click;
            if (btnReports != null) btnReports.Click += btnReports_Click;
            if (btnLogout != null) btnLogout.Click += btnLogout_Click;

            // Display admin name (designer label is named `guna2HtmlLabel2`)
            try
            {
                if (!string.IsNullOrWhiteSpace(Session.AdminName))
                    lblAdminName.Text = Session.AdminName;
            }
            catch
            {
                // ignore if label missing or something unexpected; safe fallback
            }

            // Load initial dashboard view
            LoadForm(new Dashboard());
        }

        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e) => LoadForm(new Dashboard());
        private void btnHousehold_Click(object sender, EventArgs e) => LoadForm(new HouseholdForm());
        private void btnResidents_Click(object sender, EventArgs e) => LoadForm(new ResidentForm());
        private void btnReports_Click(object sender, EventArgs e) => LoadForm(new ReportForm());
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Token = "";
            var login = new Form1();
            login.Show();
            this.Close();
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {

        }
    }
}