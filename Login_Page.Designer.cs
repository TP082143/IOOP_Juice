namespace Assignment
{
    partial class Login_Page
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
            this.txtBoxUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtBoxPassword = new System.Windows.Forms.TextBox();
            this.lblLoginInstruction = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLblForgotPassword = new System.Windows.Forms.LinkLabel();
            this.panelBig = new System.Windows.Forms.Panel();
            this.panelSmall = new System.Windows.Forms.Panel();
            this.btnPassSubmit = new System.Windows.Forms.Button();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtBoxForgotPass = new System.Windows.Forms.TextBox();
            this.lblForgotEmail = new System.Windows.Forms.Label();
            this.txtBoxForgotEmail = new System.Windows.Forms.TextBox();
            this.btnForgotFind = new System.Windows.Forms.Button();
            this.lblForgotUsername = new System.Windows.Forms.Label();
            this.txtBoxForgotUsername = new System.Windows.Forms.TextBox();
            this.timerBigPanel = new System.Windows.Forms.Timer(this.components);
            this.timerSmallPanel = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBig.SuspendLayout();
            this.panelSmall.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxUsername
            // 
            this.txtBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxUsername.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxUsername.Location = new System.Drawing.Point(202, 563);
            this.txtBoxUsername.Name = "txtBoxUsername";
            this.txtBoxUsername.Size = new System.Drawing.Size(431, 36);
            this.txtBoxUsername.TabIndex = 0;
            this.txtBoxUsername.TextChanged += new System.EventHandler(this.txtBoxUsername_TextChanged);
            this.txtBoxUsername.Enter += new System.EventHandler(this.txtBoxUsername_Enter);
            this.txtBoxUsername.Leave += new System.EventHandler(this.txtBoxUsername_Leave);
            // 
            // lblUsername
            // 
            this.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblUsername.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsername.Location = new System.Drawing.Point(196, 525);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(240, 33);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Username or Email";
            this.lblUsername.Click += new System.EventHandler(this.lblUsername_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(196, 624);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(128, 33);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password";
            this.lblPassword.Click += new System.EventHandler(this.lblPassword_Click);
            // 
            // txtBoxPassword
            // 
            this.txtBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxPassword.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPassword.Location = new System.Drawing.Point(202, 662);
            this.txtBoxPassword.Name = "txtBoxPassword";
            this.txtBoxPassword.PasswordChar = '*';
            this.txtBoxPassword.Size = new System.Drawing.Size(431, 36);
            this.txtBoxPassword.TabIndex = 2;
            this.txtBoxPassword.TextChanged += new System.EventHandler(this.txtBoxPassword_TextChanged);
            this.txtBoxPassword.Enter += new System.EventHandler(this.txtBoxPassword_Enter);
            this.txtBoxPassword.Leave += new System.EventHandler(this.txtBoxPassword_Leave);
            // 
            // lblLoginInstruction
            // 
            this.lblLoginInstruction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoginInstruction.AutoSize = true;
            this.lblLoginInstruction.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLoginInstruction.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginInstruction.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLoginInstruction.Location = new System.Drawing.Point(289, 458);
            this.lblLoginInstruction.Name = "lblLoginInstruction";
            this.lblLoginInstruction.Size = new System.Drawing.Size(257, 29);
            this.lblLoginInstruction.TabIndex = 5;
            this.lblLoginInstruction.Text = "Enter your login details";
            this.lblLoginInstruction.Click += new System.EventHandler(this.lblLoginInstruction_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLogin.BackColor = System.Drawing.Color.Tomato;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 2;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogin.Location = new System.Drawing.Point(322, 739);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(192, 45);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.BackgroundImage = global::Assignment.Properties.Resources.FoodiePoint_Login_Page_01_02;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(172, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(495, 408);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // linkLblForgotPassword
            // 
            this.linkLblForgotPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.linkLblForgotPassword.AutoSize = true;
            this.linkLblForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblForgotPassword.LinkColor = System.Drawing.Color.Gray;
            this.linkLblForgotPassword.Location = new System.Drawing.Point(518, 701);
            this.linkLblForgotPassword.Name = "linkLblForgotPassword";
            this.linkLblForgotPassword.Size = new System.Drawing.Size(115, 17);
            this.linkLblForgotPassword.TabIndex = 8;
            this.linkLblForgotPassword.TabStop = true;
            this.linkLblForgotPassword.Text = "Forgot Passoword";
            this.linkLblForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblForgotPassword_LinkClicked);
            // 
            // panelBig
            // 
            this.panelBig.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelBig.Controls.Add(this.panelSmall);
            this.panelBig.Controls.Add(this.lblForgotEmail);
            this.panelBig.Controls.Add(this.txtBoxForgotEmail);
            this.panelBig.Controls.Add(this.btnForgotFind);
            this.panelBig.Controls.Add(this.lblForgotUsername);
            this.panelBig.Controls.Add(this.txtBoxForgotUsername);
            this.panelBig.Location = new System.Drawing.Point(202, 449);
            this.panelBig.MaximumSize = new System.Drawing.Size(442, 378);
            this.panelBig.Name = "panelBig";
            this.panelBig.Size = new System.Drawing.Size(10, 10);
            this.panelBig.TabIndex = 9;
            // 
            // panelSmall
            // 
            this.panelSmall.Controls.Add(this.btnPassSubmit);
            this.panelSmall.Controls.Add(this.txtBoxForgotPass);
            this.panelSmall.Controls.Add(this.lblNewPassword);
            this.panelSmall.Location = new System.Drawing.Point(11, 217);
            this.panelSmall.MaximumSize = new System.Drawing.Size(420, 147);
            this.panelSmall.Name = "panelSmall";
            this.panelSmall.Size = new System.Drawing.Size(10, 10);
            this.panelSmall.TabIndex = 15;
            // 
            // btnPassSubmit
            // 
            this.btnPassSubmit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPassSubmit.BackColor = System.Drawing.Color.IndianRed;
            this.btnPassSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPassSubmit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPassSubmit.FlatAppearance.BorderSize = 2;
            this.btnPassSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPassSubmit.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPassSubmit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPassSubmit.Location = new System.Drawing.Point(-197, 99);
            this.btnPassSubmit.Name = "btnPassSubmit";
            this.btnPassSubmit.Size = new System.Drawing.Size(92, 34);
            this.btnPassSubmit.TabIndex = 16;
            this.btnPassSubmit.Text = "Submit";
            this.btnPassSubmit.UseVisualStyleBackColor = false;
            this.btnPassSubmit.Click += new System.EventHandler(this.btnPassSubmit_Click);
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNewPassword.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNewPassword.Location = new System.Drawing.Point(-202, 32);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(211, 25);
            this.lblNewPassword.TabIndex = 16;
            this.lblNewPassword.Text = "Type New Passoword";
            // 
            // txtBoxForgotPass
            // 
            this.txtBoxForgotPass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxForgotPass.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxForgotPass.Location = new System.Drawing.Point(-197, 59);
            this.txtBoxForgotPass.Name = "txtBoxForgotPass";
            this.txtBoxForgotPass.PasswordChar = '*';
            this.txtBoxForgotPass.Size = new System.Drawing.Size(381, 33);
            this.txtBoxForgotPass.TabIndex = 16;
            // 
            // lblForgotEmail
            // 
            this.lblForgotEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForgotEmail.AutoSize = true;
            this.lblForgotEmail.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblForgotEmail.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblForgotEmail.Location = new System.Drawing.Point(-203, 89);
            this.lblForgotEmail.Name = "lblForgotEmail";
            this.lblForgotEmail.Size = new System.Drawing.Size(63, 25);
            this.lblForgotEmail.TabIndex = 14;
            this.lblForgotEmail.Text = "Email";
            // 
            // txtBoxForgotEmail
            // 
            this.txtBoxForgotEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxForgotEmail.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxForgotEmail.Location = new System.Drawing.Point(-201, 117);
            this.txtBoxForgotEmail.Name = "txtBoxForgotEmail";
            this.txtBoxForgotEmail.Size = new System.Drawing.Size(408, 33);
            this.txtBoxForgotEmail.TabIndex = 13;
            // 
            // btnForgotFind
            // 
            this.btnForgotFind.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnForgotFind.BackColor = System.Drawing.Color.OliveDrab;
            this.btnForgotFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnForgotFind.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnForgotFind.FlatAppearance.BorderSize = 2;
            this.btnForgotFind.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForgotFind.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnForgotFind.Location = new System.Drawing.Point(94, 158);
            this.btnForgotFind.Name = "btnForgotFind";
            this.btnForgotFind.Size = new System.Drawing.Size(113, 42);
            this.btnForgotFind.TabIndex = 12;
            this.btnForgotFind.Text = "Find";
            this.btnForgotFind.UseVisualStyleBackColor = false;
            this.btnForgotFind.Click += new System.EventHandler(this.btnForgotFind_Click);
            // 
            // lblForgotUsername
            // 
            this.lblForgotUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblForgotUsername.AutoSize = true;
            this.lblForgotUsername.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblForgotUsername.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgotUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblForgotUsername.Location = new System.Drawing.Point(-203, 18);
            this.lblForgotUsername.Name = "lblForgotUsername";
            this.lblForgotUsername.Size = new System.Drawing.Size(106, 25);
            this.lblForgotUsername.TabIndex = 11;
            this.lblForgotUsername.Text = "Username";
            // 
            // txtBoxForgotUsername
            // 
            this.txtBoxForgotUsername.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBoxForgotUsername.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxForgotUsername.Location = new System.Drawing.Point(-201, 47);
            this.txtBoxForgotUsername.Name = "txtBoxForgotUsername";
            this.txtBoxForgotUsername.Size = new System.Drawing.Size(408, 33);
            this.txtBoxForgotUsername.TabIndex = 10;
            // 
            // timerBigPanel
            // 
            this.timerBigPanel.Interval = 15;
            this.timerBigPanel.Tick += new System.EventHandler(this.timerBigPanel_Tick);
            // 
            // timerSmallPanel
            // 
            this.timerSmallPanel.Interval = 20;
            this.timerSmallPanel.Tick += new System.EventHandler(this.timerSmallPanel_Tick);
            // 
            // Login_Page
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 866);
            this.Controls.Add(this.panelBig);
            this.Controls.Add(this.linkLblForgotPassword);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLoginInstruction);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtBoxPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtBoxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Login_Page";
            this.Text = "Login Page";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBig.ResumeLayout(false);
            this.panelBig.PerformLayout();
            this.panelSmall.ResumeLayout(false);
            this.panelSmall.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtBoxPassword;
        private System.Windows.Forms.Label lblLoginInstruction;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLblForgotPassword;
        private System.Windows.Forms.Panel panelBig;
        private System.Windows.Forms.Label lblForgotEmail;
        private System.Windows.Forms.TextBox txtBoxForgotEmail;
        private System.Windows.Forms.Button btnForgotFind;
        private System.Windows.Forms.Label lblForgotUsername;
        private System.Windows.Forms.TextBox txtBoxForgotUsername;
        private System.Windows.Forms.Panel panelSmall;
        private System.Windows.Forms.Button btnPassSubmit;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtBoxForgotPass;
        private System.Windows.Forms.Timer timerBigPanel;
        private System.Windows.Forms.Timer timerSmallPanel;
    }
}

