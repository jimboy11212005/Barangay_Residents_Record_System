namespace BRRDesktop
{
    partial class ReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnGenResident = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnGenHousehold = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.dgvResults = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2ShadowPanel3.SuspendLayout();
            this.guna2ShadowPanel1.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 100;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2ShadowPanel3
            // 
            this.guna2ShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel3.Controls.Add(this.btnGenResident);
            this.guna2ShadowPanel3.FillColor = System.Drawing.Color.DarkSlateGray;
            this.guna2ShadowPanel3.ForeColor = System.Drawing.Color.RosyBrown;
            this.guna2ShadowPanel3.Location = new System.Drawing.Point(79, 44);
            this.guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            this.guna2ShadowPanel3.Radius = 10;
            this.guna2ShadowPanel3.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel3.Size = new System.Drawing.Size(222, 55);
            this.guna2ShadowPanel3.TabIndex = 6;
            // 
            // btnGenResident
            // 
            this.btnGenResident.AutoRoundedCorners = true;
            this.btnGenResident.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenResident.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenResident.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenResident.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenResident.FillColor = System.Drawing.Color.Transparent;
            this.btnGenResident.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenResident.ForeColor = System.Drawing.Color.White;
            this.btnGenResident.Location = new System.Drawing.Point(22, 8);
            this.btnGenResident.Name = "btnGenResident";
            this.btnGenResident.Size = new System.Drawing.Size(180, 38);
            this.btnGenResident.TabIndex = 0;
            this.btnGenResident.Text = "Generate Resident Report";
            this.btnGenResident.UseTransparentBackground = true;
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.btnGenHousehold);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.DarkSlateGray;
            this.guna2ShadowPanel1.ForeColor = System.Drawing.Color.RosyBrown;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(79, 105);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Radius = 10;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(222, 55);
            this.guna2ShadowPanel1.TabIndex = 7;
            // 
            // btnGenHousehold
            // 
            this.btnGenHousehold.AutoRoundedCorners = true;
            this.btnGenHousehold.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenHousehold.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenHousehold.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenHousehold.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenHousehold.FillColor = System.Drawing.Color.Transparent;
            this.btnGenHousehold.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenHousehold.ForeColor = System.Drawing.Color.White;
            this.btnGenHousehold.Location = new System.Drawing.Point(22, 8);
            this.btnGenHousehold.Name = "btnGenHousehold";
            this.btnGenHousehold.Size = new System.Drawing.Size(180, 38);
            this.btnGenHousehold.TabIndex = 1;
            this.btnGenHousehold.Text = "Generate Household Report";
            this.btnGenHousehold.UseTransparentBackground = true;
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.dgvResults);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.DarkSlateGray;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(493, 35);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 10;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(323, 386);
            this.guna2ShadowPanel2.TabIndex = 7;
            // 
            // dgvResults
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResults.ColumnHeadersHeight = 4;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvResults.Location = new System.Drawing.Point(22, 14);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.Size = new System.Drawing.Size(282, 356);
            this.dgvResults.TabIndex = 0;
            this.dgvResults.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvResults.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvResults.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvResults.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvResults.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvResults.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvResults.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvResults.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvResults.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvResults.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResults.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvResults.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvResults.ThemeStyle.HeaderStyle.Height = 4;
            this.dgvResults.ThemeStyle.ReadOnly = false;
            this.dgvResults.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvResults.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvResults.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResults.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvResults.ThemeStyle.RowsStyle.Height = 22;
            this.dgvResults.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvResults.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(828, 484);
            this.Controls.Add(this.guna2ShadowPanel2);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.guna2ShadowPanel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReportForm";
            this.Text = "ReportForm";
            this.guna2ShadowPanel3.ResumeLayout(false);
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2Button btnGenHousehold;
        private Guna.UI2.WinForms.Guna2Button btnGenResident;
        private Guna.UI2.WinForms.Guna2DataGridView dgvResults;
    }
}