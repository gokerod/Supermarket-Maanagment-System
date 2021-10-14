namespace Abadir
{
    partial class PasswordChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordChange));
            this.loginElipse = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.loginFormPanel = new System.Windows.Forms.Panel();
            this.btnChangePasswordClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.txtOldPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtNewPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btnChangePassword = new Bunifu.Framework.UI.BunifuThinButton2();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtChangePasswordEmployeeID = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.loginFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangePasswordClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginElipse
            // 
            this.loginElipse.ElipseRadius = 5;
            this.loginElipse.TargetControl = this;
            // 
            // loginFormPanel
            // 
            this.loginFormPanel.Controls.Add(this.btnChangePasswordClose);
            this.loginFormPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginFormPanel.Location = new System.Drawing.Point(0, 0);
            this.loginFormPanel.Name = "loginFormPanel";
            this.loginFormPanel.Size = new System.Drawing.Size(270, 30);
            this.loginFormPanel.TabIndex = 0;
            // 
            // btnChangePasswordClose
            // 
            this.btnChangePasswordClose.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePasswordClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangePasswordClose.Image = ((System.Drawing.Image)(resources.GetObject("btnChangePasswordClose.Image")));
            this.btnChangePasswordClose.ImageActive = null;
            this.btnChangePasswordClose.Location = new System.Drawing.Point(240, 0);
            this.btnChangePasswordClose.Name = "btnChangePasswordClose";
            this.btnChangePasswordClose.Size = new System.Drawing.Size(30, 30);
            this.btnChangePasswordClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnChangePasswordClose.TabIndex = 1;
            this.btnChangePasswordClose.TabStop = false;
            this.btnChangePasswordClose.Zoom = 10;
            this.btnChangePasswordClose.Click += new System.EventHandler(this.btnChangePasswordClose_Click);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtOldPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOldPassword.HintForeColor = System.Drawing.Color.Empty;
            this.txtOldPassword.HintText = "";
            this.txtOldPassword.isPassword = false;
            this.txtOldPassword.LineFocusedColor = System.Drawing.Color.SeaGreen;
            this.txtOldPassword.LineIdleColor = System.Drawing.Color.Gray;
            this.txtOldPassword.LineMouseHoverColor = System.Drawing.Color.SeaGreen;
            this.txtOldPassword.LineThickness = 3;
            this.txtOldPassword.Location = new System.Drawing.Point(39, 181);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(195, 44);
            this.txtOldPassword.TabIndex = 2;
            this.txtOldPassword.Text = "Old Password";
            this.txtOldPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNewPassword.HintForeColor = System.Drawing.Color.Empty;
            this.txtNewPassword.HintText = "";
            this.txtNewPassword.isPassword = false;
            this.txtNewPassword.LineFocusedColor = System.Drawing.Color.SeaGreen;
            this.txtNewPassword.LineIdleColor = System.Drawing.Color.Gray;
            this.txtNewPassword.LineMouseHoverColor = System.Drawing.Color.SeaGreen;
            this.txtNewPassword.LineThickness = 3;
            this.txtNewPassword.Location = new System.Drawing.Point(39, 233);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(195, 44);
            this.txtNewPassword.TabIndex = 3;
            this.txtNewPassword.Text = "New Password";
            this.txtNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.ActiveBorderThickness = 1;
            this.btnChangePassword.ActiveCornerRadius = 20;
            this.btnChangePassword.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnChangePassword.ActiveForecolor = System.Drawing.Color.White;
            this.btnChangePassword.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnChangePassword.BackColor = System.Drawing.SystemColors.Control;
            this.btnChangePassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnChangePassword.BackgroundImage")));
            this.btnChangePassword.ButtonText = "CHANGE";
            this.btnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangePassword.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassword.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnChangePassword.IdleBorderThickness = 1;
            this.btnChangePassword.IdleCornerRadius = 20;
            this.btnChangePassword.IdleFillColor = System.Drawing.Color.White;
            this.btnChangePassword.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnChangePassword.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnChangePassword.Location = new System.Drawing.Point(78, 286);
            this.btnChangePassword.Margin = new System.Windows.Forms.Padding(5);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(98, 36);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(39, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtChangePasswordEmployeeID
            // 
            this.txtChangePasswordEmployeeID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChangePasswordEmployeeID.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtChangePasswordEmployeeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtChangePasswordEmployeeID.HintForeColor = System.Drawing.Color.Empty;
            this.txtChangePasswordEmployeeID.HintText = "";
            this.txtChangePasswordEmployeeID.isPassword = false;
            this.txtChangePasswordEmployeeID.LineFocusedColor = System.Drawing.Color.SeaGreen;
            this.txtChangePasswordEmployeeID.LineIdleColor = System.Drawing.Color.Gray;
            this.txtChangePasswordEmployeeID.LineMouseHoverColor = System.Drawing.Color.SeaGreen;
            this.txtChangePasswordEmployeeID.LineThickness = 3;
            this.txtChangePasswordEmployeeID.Location = new System.Drawing.Point(39, 129);
            this.txtChangePasswordEmployeeID.Margin = new System.Windows.Forms.Padding(4);
            this.txtChangePasswordEmployeeID.Name = "txtChangePasswordEmployeeID";
            this.txtChangePasswordEmployeeID.Size = new System.Drawing.Size(195, 44);
            this.txtChangePasswordEmployeeID.TabIndex = 6;
            this.txtChangePasswordEmployeeID.Text = "EmployeeID";
            this.txtChangePasswordEmployeeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 336);
            this.Controls.Add(this.txtChangePasswordEmployeeID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.loginFormPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.loginFormPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnChangePasswordClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse loginElipse;
        private System.Windows.Forms.Panel loginFormPanel;
        private Bunifu.Framework.UI.BunifuImageButton btnChangePasswordClose;
        private Bunifu.Framework.UI.BunifuThinButton2 btnChangePassword;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtNewPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtOldPassword;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtChangePasswordEmployeeID;
    }
}