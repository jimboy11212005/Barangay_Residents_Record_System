using System;
using System.Drawing;
using System.Windows.Forms;

namespace BRRDesktop
{
    internal class Theme
    {
        // 🎨 MODERN COLORS (softer + cleaner)
        public static Color Bg = Color.FromArgb(24, 24, 28);
        public static Color Card = Color.FromArgb(36, 36, 40);
        public static Color Accent = Color.FromArgb(0, 153, 255);
        public static Color AccentHover = Color.FromArgb(0, 120, 215);
        public static Color Text = Color.FromArgb(230, 230, 230);
        public static Color SubText = Color.Gray;
        public static Color InputBg = Color.FromArgb(50, 50, 55);
        public static Color Border = Color.FromArgb(70, 70, 75);
        public static Color Danger = Color.FromArgb(220, 80, 80);

        // 🌙 APPLY DARK MODE
        public static void ApplyDark(Form form)
        {
            form.BackColor = Bg;
            form.ForeColor = Text;

            foreach (Control ctrl in form.Controls)
            {
                StyleControl(ctrl);
            }
        }

        // 🎯 STYLE CONTROLS
        private static void StyleControl(Control ctrl)
        {
            // 🧱 Containers
            if (ctrl is Panel || ctrl is GroupBox)
            {
                ctrl.BackColor = Card;
                ctrl.ForeColor = Text;
            }

            // 🔘 Buttons (modern flat with hover)
            if (ctrl is Button btn)
            {
                btn.BackColor = Accent;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Cursor = Cursors.Hand;

                btn.Padding = new Padding(10, 5, 10, 5);

                // Hover effect
                btn.MouseEnter += (s, e) => btn.BackColor = AccentHover;
                btn.MouseLeave += (s, e) => btn.BackColor = Accent;

                // Click effect
                btn.MouseDown += (s, e) => btn.BackColor = Color.FromArgb(0, 100, 180);
                btn.MouseUp += (s, e) => btn.BackColor = AccentHover;
            }

            // 🧾 TextBoxes
            if (ctrl is TextBox txt)
            {
                txt.BackColor = InputBg;
                txt.ForeColor = Text;
                txt.BorderStyle = BorderStyle.FixedSingle;

                txt.Padding = new Padding(5);

                // Focus highlight
                txt.Enter += (s, e) => txt.BackColor = Color.FromArgb(60, 60, 65);
                txt.Leave += (s, e) => txt.BackColor = InputBg;
            }

            // 🏷 Labels
            if (ctrl is Label lbl)
            {
                lbl.ForeColor = Text;
            }

            // 📊 DataGridView (clean table style)
            if (ctrl is DataGridView dgv)
            {
                dgv.BackgroundColor = Card;
                dgv.BorderStyle = BorderStyle.None;
                dgv.EnableHeadersVisualStyles = false;
                dgv.RowHeadersVisible = false;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = Accent;
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                dgv.DefaultCellStyle.BackColor = InputBg;
                dgv.DefaultCellStyle.ForeColor = Text;
                dgv.DefaultCellStyle.SelectionBackColor = Accent;
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;

                dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 50);

                dgv.GridColor = Border;
            }

            // 🔁 Apply to children
            foreach (Control child in ctrl.Controls)
            {
                StyleControl(child);
            }
        }
    }
}