using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRRDesktop.Models;
using BRRDesktop.Services;

namespace BRRDesktop
{
    public partial class AddResidentForm : Form
    {
        private Guna.UI2.WinForms.Guna2TextBox txtFirst;
        private Guna.UI2.WinForms.Guna2TextBox txtLast;
        private Guna.UI2.WinForms.Guna2TextBox txtAge;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;

        private Guna.UI2.WinForms.Guna2ComboBox cbGender;
        private Guna.UI2.WinForms.Guna2ComboBox cbPurok;
        private Guna.UI2.WinForms.Guna2ComboBox cbPWD;

        private Guna.UI2.WinForms.Guna2Button btnSave;

        public AddResidentForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            SetupUI();
        }

        // =========================
        // UI
        // =========================

        private void SetupUI()
        {
            // FORM

            this.Text =
                "Add Resident";

            this.Size =
                new Size(950, 650);

            this.StartPosition =
                FormStartPosition.CenterParent;

            this.FormBorderStyle =
                FormBorderStyle.None;

            this.BackColor =
                Color.FromArgb(241, 245, 249);

            // =========================
            // CLOSE BUTTON
            // =========================

            Guna.UI2.WinForms.Guna2Button btnClose =
                new Guna.UI2.WinForms.Guna2Button();

            btnClose.Text = "X";

            btnClose.Size =
                new Size(42, 42);

            btnClose.Location =
                new Point(885, 15);

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

            // =========================
            // TITLE
            // =========================

            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Add New Resident";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    24,
                    FontStyle.Bold
                );

            lblTitle.ForeColor =
                Color.FromArgb(15, 23, 42);

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(25, 25);

            Controls.Add(lblTitle);

            // =========================
            // SUBTITLE
            // =========================

            Label lblSub =
                new Label();

            lblSub.Text =
                "Register a new barangay resident";

            lblSub.Font =
                new Font(
                    "Segoe UI",
                    10
                );

            lblSub.ForeColor =
                Color.Gray;

            lblSub.AutoSize = true;

            lblSub.Location =
                new Point(40, 70);

            Controls.Add(lblSub);

            // =========================
            // MAIN PANEL
            // =========================

            Guna.UI2.WinForms.Guna2Panel panel =
                new Guna.UI2.WinForms.Guna2Panel();

            panel.Size =
                new Size(870, 500);

            panel.Location =
                new Point(35, 110);

            panel.FillColor =
                Color.White;

            panel.BorderRadius = 20;

            panel.ShadowDecoration.Enabled = true;

            panel.ShadowDecoration.Depth = 15;

            Controls.Add(panel);

            // =========================
            // FIRST NAME
            // =========================

            CreateLabel(
                panel,
                "First Name",
                40,
                40
            );

            txtFirst =
                CreateTextbox(
                    40,
                    65
                );

            panel.Controls.Add(txtFirst);

            // =========================
            // LAST NAME
            // =========================

            CreateLabel(
                panel,
                "Last Name",
                320,
                40
            );

            txtLast =
                CreateTextbox(
                    320,
                    65
                );

            panel.Controls.Add(txtLast);

            // =========================
            // AGE
            // =========================

            CreateLabel(
                panel,
                "Age",
                600,
                40
            );

            txtAge =
                CreateTextbox(
                    600,
                    65
                );

            txtAge.Width = 180;

            txtAge.KeyPress +=
                TxtAge_KeyPress;

            panel.Controls.Add(txtAge);

            // =========================
            // GENDER
            // =========================

            CreateLabel(
                panel,
                "Gender",
                40,
                150
            );

            cbGender =
                CreateComboBox(
                    40,
                    175
                );

            cbGender.Items.AddRange(
                new string[]
                {
                    "Male",
                    "Female"
                });

            panel.Controls.Add(cbGender);

            // =========================
            // PUROK
            // =========================

            CreateLabel(
                panel,
                "Purok",
                320,
                150
            );

            cbPurok =
                CreateComboBox(
                    320,
                    175
                );

            cbPurok.Items.AddRange(
                new string[]
                {
                    "Purok 1",
                    "Purok 2",
                    "Purok 3",
                    "Purok 4"
                });

            panel.Controls.Add(cbPurok);

            // =========================
            // PWD
            // =========================

            CreateLabel(
                panel,
                "PWD Status",
                600,
                150
            );

            cbPWD =
                CreateComboBox(
                    600,
                    175
                );

            cbPWD.Width = 180;

            cbPWD.Items.AddRange(
                new string[]
                {
                    "Yes",
                    "No"
                });

            panel.Controls.Add(cbPWD);

            // =========================
            // ADDRESS
            // =========================

            CreateLabel(
                panel,
                "Address",
                40,
                260
            );

            txtAddress =
                new Guna.UI2.WinForms.Guna2TextBox();

            txtAddress.Size =
                new Size(740, 90);

            txtAddress.Location =
                new Point(40, 285);

            txtAddress.Multiline = true;

            txtAddress.BorderRadius = 10;

            panel.Controls.Add(txtAddress);

            // =========================
            // SAVE BUTTON
            // =========================

            btnSave =
                new Guna.UI2.WinForms.Guna2Button();

            btnSave.Text =
                "Save Resident";

            btnSave.Size =
                new Size(190, 48);

            btnSave.Location =
                new Point(590, 410);

            btnSave.FillColor =
                Color.FromArgb(37, 99, 235);

            btnSave.BorderRadius = 12;

            btnSave.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnSave.Click +=
                BtnSave_Click;

            panel.Controls.Add(btnSave);

            // =========================
            // CANCEL BUTTON
            // =========================

            Guna.UI2.WinForms.Guna2Button btnCancel =
                new Guna.UI2.WinForms.Guna2Button();

            btnCancel.Text =
                "Cancel";

            btnCancel.Size =
                new Size(130, 48);

            btnCancel.Location =
                new Point(440, 410);

            btnCancel.FillColor =
                Color.Gray;

            btnCancel.BorderRadius = 12;

            btnCancel.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            btnCancel.Click += (s, e) =>
            {
                this.Close();
            };

            panel.Controls.Add(btnCancel);
        }

        // =========================
        // SAVE
        // =========================

        private async void BtnSave_Click(
            object sender,
            EventArgs e
        )
        {
            // VALIDATION

            if (
                string.IsNullOrWhiteSpace(
                    txtFirst.Text
                )
                ||
                string.IsNullOrWhiteSpace(
                    txtLast.Text
                )
                ||
                string.IsNullOrWhiteSpace(
                    txtAge.Text
                )
                ||
                string.IsNullOrWhiteSpace(
                    txtAddress.Text
                )
                ||
                cbGender.SelectedIndex < 0
                ||
                cbPurok.SelectedIndex < 0
                ||
                cbPWD.SelectedIndex < 0
            )
            {
                MessageBox.Show(
                    "Please complete all fields."
                );

                return;
            }

            try
            {
                btnSave.Enabled = false;

                btnSave.Text =
                    "Saving...";

                Resident resident =
                    new Resident()
                    {
                        FirstName =
                            txtFirst.Text,

                        LastName =
                            txtLast.Text,

                        Age =
                            int.Parse(
                                txtAge.Text
                            ),

                        Gender =
                            cbGender.Text,

                        Purok =
                            cbPurok.Text,

                        Address =
                            txtAddress.Text,

                        PwdStatus = cbPWD.Text
                    };

                await ApiService.PostData(
                    "residents",
                    resident
                );

                MessageBox.Show(
                    "Resident added successfully!"
                );

                this.DialogResult =
                    DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                );
            }
            finally
            {
                btnSave.Enabled = true;

                btnSave.Text =
                    "Save Resident";
            }
        }

        // =========================
        // AGE ONLY NUMBER
        // =========================

        private void TxtAge_KeyPress(
            object sender,
            KeyPressEventArgs e
        )
        {
            if (
                !char.IsControl(e.KeyChar)
                &&
                !char.IsDigit(e.KeyChar)
            )
            {
                e.Handled = true;
            }
        }

        // =========================
        // LABEL
        // =========================

        private void CreateLabel(
            Control parent,
            string text,
            int x,
            int y
        )
        {
            Label lbl =
                new Label();

            lbl.Text = text;

            lbl.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold
                );

            lbl.ForeColor =
                Color.FromArgb(30, 41, 59);

            lbl.AutoSize = true;

            lbl.Location =
                new Point(x, y);

            parent.Controls.Add(lbl);
        }

        // =========================
        // TEXTBOX
        // =========================

        private Guna.UI2.WinForms.Guna2TextBox CreateTextbox(
            int x,
            int y
        )
        {
            Guna.UI2.WinForms.Guna2TextBox txt =
                new Guna.UI2.WinForms.Guna2TextBox();

            txt.Size =
                new Size(220, 42);

            txt.Location =
                new Point(x, y);

            txt.BorderRadius = 10;

            return txt;
        }

        // =========================
        // COMBOBOX
        // =========================

        private Guna.UI2.WinForms.Guna2ComboBox CreateComboBox(
            int x,
            int y
        )
        {
            Guna.UI2.WinForms.Guna2ComboBox cb =
                new Guna.UI2.WinForms.Guna2ComboBox();

            cb.Size =
                new Size(220, 42);

            cb.Location =
                new Point(x, y);

            cb.BorderRadius = 10;

            return cb;
        }
    }
}