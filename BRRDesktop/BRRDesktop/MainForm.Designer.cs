namespace BarangayAdminDesktop
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnLogout = new Guna.UI2.WinForms.Guna2ImageButton();
            this.lblAdminName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.panelMain = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panelSidebar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.btnReports = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnResidents = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnHousehold = new Guna.UI2.WinForms.Guna2ImageButton();
            this.btnDashboard = new Guna.UI2.WinForms.Guna2ImageButton();
            this.panelHeader.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.guna2ShadowPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 300;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Controls.Add(this.lblAdminName);
            this.panelHeader.Controls.Add(this.guna2HtmlLabel1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(947, 90);
            this.panelHeader.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Transparent;
            this.btnLogout.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnLogout.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnLogout.ImageRotate = 0F;
            this.btnLogout.ImageSize = new System.Drawing.Size(40, 40);
            this.btnLogout.Location = new System.Drawing.Point(831, 39);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnLogout.Size = new System.Drawing.Size(44, 38);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.UseTransparentBackground = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click_1);
            // 
            // lblAdminName
            // 
            this.lblAdminName.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminName.Font = new System.Drawing.Font("MV Boli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblAdminName.Location = new System.Drawing.Point(649, 50);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(79, 18);
            this.lblAdminName.TabIndex = 1;
            this.lblAdminName.Text = "Brgy.Secretary";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(82, 24);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(561, 52);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Barangay Residents Record";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMain.BackgroundImage")));
            this.panelMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMain.FillColor = System.Drawing.Color.Transparent;
            this.panelMain.ForeColor = System.Drawing.Color.Transparent;
            this.panelMain.Location = new System.Drawing.Point(128, -17);
            this.panelMain.Name = "panelMain";
            this.panelMain.Radius = 50;
            this.panelMain.ShadowColor = System.Drawing.Color.Transparent;
            this.panelMain.Size = new System.Drawing.Size(838, 482);
            this.panelMain.TabIndex = 2;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2CustomGradientPanel1.BackgroundImage")));
            this.guna2CustomGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2CustomGradientPanel1.Controls.Add(this.panelSidebar);
            this.guna2CustomGradientPanel1.Controls.Add(this.panelMain);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(-10, 87);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(957, 468);
            this.guna2CustomGradientPanel1.TabIndex = 0;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelSidebar.Controls.Add(this.guna2ShadowPanel2);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(140, 468);
            this.panelSidebar.TabIndex = 3;
            // 
            // guna2ShadowPanel2
            // 
            this.guna2ShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.Controls.Add(this.btnReports);
            this.guna2ShadowPanel2.Controls.Add(this.btnResidents);
            this.guna2ShadowPanel2.Controls.Add(this.btnHousehold);
            this.guna2ShadowPanel2.Controls.Add(this.btnDashboard);
            this.guna2ShadowPanel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.guna2ShadowPanel2.Location = new System.Drawing.Point(16, 9);
            this.guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            this.guna2ShadowPanel2.Radius = 20;
            this.guna2ShadowPanel2.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel2.Size = new System.Drawing.Size(117, 434);
            this.guna2ShadowPanel2.TabIndex = 3;
            this.guna2ShadowPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2ShadowPanel2_Paint);
            // 
            // btnReports
            // 
            this.btnReports.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReports.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnReports.ImageRotate = 0F;
            this.btnReports.Location = new System.Drawing.Point(20, 315);
            this.btnReports.Name = "btnReports";
            this.btnReports.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnReports.Size = new System.Drawing.Size(82, 54);
            this.btnReports.TabIndex = 3;
            // 
            // btnResidents
            // 
            this.btnResidents.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnResidents.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnResidents.Image = ((System.Drawing.Image)(resources.GetObject("btnResidents.Image")));
            this.btnResidents.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnResidents.ImageRotate = 0F;
            this.btnResidents.Location = new System.Drawing.Point(20, 229);
            this.btnResidents.Name = "btnResidents";
            this.btnResidents.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnResidents.Size = new System.Drawing.Size(82, 60);
            this.btnResidents.TabIndex = 2;
            // 
            // btnHousehold
            // 
            this.btnHousehold.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnHousehold.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnHousehold.Image = ((System.Drawing.Image)(resources.GetObject("btnHousehold.Image")));
            this.btnHousehold.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnHousehold.ImageRotate = 0F;
            this.btnHousehold.Location = new System.Drawing.Point(20, 140);
            this.btnHousehold.Name = "btnHousehold";
            this.btnHousehold.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnHousehold.Size = new System.Drawing.Size(82, 57);
            this.btnHousehold.TabIndex = 1;
            // 
            // btnDashboard
            // 
            this.btnDashboard.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDashboard.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageOffset = new System.Drawing.Point(0, 0);
            this.btnDashboard.ImageRotate = 0F;
            this.btnDashboard.Location = new System.Drawing.Point(20, 47);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnDashboard.Size = new System.Drawing.Size(82, 61);
            this.btnDashboard.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 542);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.guna2ShadowPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2ShadowPanel panelMain;
        private Guna.UI2.WinForms.Guna2GradientPanel panelHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblAdminName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton btnLogout;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2Panel panelSidebar;
        private Guna.UI2.WinForms.Guna2ImageButton btnReports;
        private Guna.UI2.WinForms.Guna2ImageButton btnResidents;
        private Guna.UI2.WinForms.Guna2ImageButton btnHousehold;
        private Guna.UI2.WinForms.Guna2ImageButton btnDashboard;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
    }
}