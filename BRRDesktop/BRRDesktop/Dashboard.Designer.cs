namespace BRRDesktop
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.lblPWD = new System.Windows.Forms.Label();
            this.lblTotalResidents = new System.Windows.Forms.Label();
            this.lblSeniors = new System.Windows.Forms.Label();
            this.lblChildren = new System.Windows.Forms.Label();
            this.lblAdults = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 300;
            this.guna2Elipse1.TargetControl = this;
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.BackColor = System.Drawing.Color.White;
            this.lblPWD.Font = new System.Drawing.Font("Showcard Gothic", 20.25F);
            this.lblPWD.ForeColor = System.Drawing.Color.BlueViolet;
            this.lblPWD.Location = new System.Drawing.Point(588, 276);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.Size = new System.Drawing.Size(31, 33);
            this.lblPWD.TabIndex = 3;
            this.lblPWD.Text = "0";
            // 
            // lblTotalResidents
            // 
            this.lblTotalResidents.AutoSize = true;
            this.lblTotalResidents.BackColor = System.Drawing.Color.LightCoral;
            this.lblTotalResidents.Font = new System.Drawing.Font("Showcard Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalResidents.ForeColor = System.Drawing.Color.White;
            this.lblTotalResidents.Location = new System.Drawing.Point(286, 132);
            this.lblTotalResidents.Name = "lblTotalResidents";
            this.lblTotalResidents.Size = new System.Drawing.Size(32, 36);
            this.lblTotalResidents.TabIndex = 3;
            this.lblTotalResidents.Text = "0";
            // 
            // lblSeniors
            // 
            this.lblSeniors.AutoSize = true;
            this.lblSeniors.BackColor = System.Drawing.Color.White;
            this.lblSeniors.Font = new System.Drawing.Font("Showcard Gothic", 20.25F);
            this.lblSeniors.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblSeniors.Location = new System.Drawing.Point(450, 276);
            this.lblSeniors.Name = "lblSeniors";
            this.lblSeniors.Size = new System.Drawing.Size(31, 33);
            this.lblSeniors.TabIndex = 3;
            this.lblSeniors.Text = "0";
            // 
            // lblChildren
            // 
            this.lblChildren.AutoSize = true;
            this.lblChildren.BackColor = System.Drawing.Color.White;
            this.lblChildren.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChildren.ForeColor = System.Drawing.Color.Orange;
            this.lblChildren.Location = new System.Drawing.Point(175, 275);
            this.lblChildren.Name = "lblChildren";
            this.lblChildren.Size = new System.Drawing.Size(31, 33);
            this.lblChildren.TabIndex = 2;
            this.lblChildren.Text = "0";
            // 
            // lblAdults
            // 
            this.lblAdults.AutoSize = true;
            this.lblAdults.BackColor = System.Drawing.Color.White;
            this.lblAdults.Font = new System.Drawing.Font("Showcard Gothic", 20.25F);
            this.lblAdults.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAdults.Location = new System.Drawing.Point(313, 276);
            this.lblAdults.Name = "lblAdults";
            this.lblAdults.Size = new System.Drawing.Size(31, 33);
            this.lblAdults.TabIndex = 3;
            this.lblAdults.Text = "0";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Location = new System.Drawing.Point(61, 36);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(668, 436);
            this.guna2Panel1.TabIndex = 4;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(791, 514);
            this.Controls.Add(this.lblTotalResidents);
            this.Controls.Add(this.lblPWD);
            this.Controls.Add(this.lblSeniors);
            this.Controls.Add(this.lblAdults);
            this.Controls.Add(this.lblChildren);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Label lblPWD;
        private System.Windows.Forms.Label lblSeniors;
        private System.Windows.Forms.Label lblAdults;
        private System.Windows.Forms.Label lblChildren;
        private System.Windows.Forms.Label lblTotalResidents;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
    }
}