namespace PRESENTATION
{
    partial class MainUI
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
            this.Header = new System.Windows.Forms.Panel();
            this.NavigationBar = new System.Windows.Forms.Panel();
            this.NavigationBarMenu = new System.Windows.Forms.Panel();
            this.Btn_Login = new System.Windows.Forms.Button();
            this.Btn_Register = new System.Windows.Forms.Button();
            this.Btn_Comment = new System.Windows.Forms.Button();
            this.SideBarToggle = new System.Windows.Forms.Button();
            this.Logo = new System.Windows.Forms.Panel();
            this.MainSideBar = new System.Windows.Forms.Panel();
            this.BotBorder = new System.Windows.Forms.Panel();
            this.MultiContainerInNBM = new System.Windows.Forms.Panel();
            this.Header.SuspendLayout();
            this.NavigationBar.SuspendLayout();
            this.NavigationBarMenu.SuspendLayout();
            this.MultiContainerInNBM.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.Controls.Add(this.NavigationBar);
            this.Header.Controls.Add(this.Logo);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1583, 50);
            this.Header.TabIndex = 0;
            // 
            // NavigationBar
            // 
            this.NavigationBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(166)))), ((int)(((byte)(90)))));
            this.NavigationBar.Controls.Add(this.NavigationBarMenu);
            this.NavigationBar.Controls.Add(this.SideBarToggle);
            this.NavigationBar.Location = new System.Drawing.Point(230, 0);
            this.NavigationBar.Name = "NavigationBar";
            this.NavigationBar.Size = new System.Drawing.Size(1353, 50);
            this.NavigationBar.TabIndex = 1;
            // 
            // NavigationBarMenu
            // 
            this.NavigationBarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NavigationBarMenu.Controls.Add(this.MultiContainerInNBM);
            this.NavigationBarMenu.Controls.Add(this.Btn_Comment);
            this.NavigationBarMenu.Location = new System.Drawing.Point(1014, 0);
            this.NavigationBarMenu.Name = "NavigationBarMenu";
            this.NavigationBarMenu.Size = new System.Drawing.Size(339, 50);
            this.NavigationBarMenu.TabIndex = 0;
            // 
            // Btn_Login
            // 
            this.Btn_Login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Login.FlatAppearance.BorderSize = 0;
            this.Btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Login.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Login.Location = new System.Drawing.Point(113, 0);
            this.Btn_Login.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(113, 50);
            this.Btn_Login.TabIndex = 2;
            this.Btn_Login.Text = "Login";
            this.Btn_Login.UseVisualStyleBackColor = true;
            // 
            // Btn_Register
            // 
            this.Btn_Register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Register.FlatAppearance.BorderSize = 0;
            this.Btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Register.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Register.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Register.Location = new System.Drawing.Point(0, 0);
            this.Btn_Register.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Register.Name = "Btn_Register";
            this.Btn_Register.Size = new System.Drawing.Size(113, 50);
            this.Btn_Register.TabIndex = 1;
            this.Btn_Register.Text = "Register";
            this.Btn_Register.UseVisualStyleBackColor = true;
            // 
            // Btn_Comment
            // 
            this.Btn_Comment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Comment.FlatAppearance.BorderSize = 0;
            this.Btn_Comment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Comment.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Comment.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Comment.Location = new System.Drawing.Point(0, 0);
            this.Btn_Comment.Margin = new System.Windows.Forms.Padding(0);
            this.Btn_Comment.Name = "Btn_Comment";
            this.Btn_Comment.Size = new System.Drawing.Size(113, 50);
            this.Btn_Comment.TabIndex = 0;
            this.Btn_Comment.Text = "Comment";
            this.Btn_Comment.UseVisualStyleBackColor = true;
            // 
            // SideBarToggle
            // 
            this.SideBarToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(76)))));
            this.SideBarToggle.BackgroundImage = global::PRESENTATION.Properties.Resources.ic_menu_white_24dp;
            this.SideBarToggle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SideBarToggle.FlatAppearance.BorderSize = 0;
            this.SideBarToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SideBarToggle.ForeColor = System.Drawing.Color.Transparent;
            this.SideBarToggle.Location = new System.Drawing.Point(0, 0);
            this.SideBarToggle.Name = "SideBarToggle";
            this.SideBarToggle.Size = new System.Drawing.Size(42, 50);
            this.SideBarToggle.TabIndex = 1;
            this.SideBarToggle.UseVisualStyleBackColor = false;
            // 
            // Logo
            // 
            this.Logo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(141)))), ((int)(((byte)(76)))));
            this.Logo.Dock = System.Windows.Forms.DockStyle.Left;
            this.Logo.Location = new System.Drawing.Point(0, 0);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(230, 50);
            this.Logo.TabIndex = 0;
            // 
            // MainSideBar
            // 
            this.MainSideBar.AutoScroll = true;
            this.MainSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.MainSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainSideBar.Location = new System.Drawing.Point(0, 50);
            this.MainSideBar.Name = "MainSideBar";
            this.MainSideBar.Size = new System.Drawing.Size(230, 1048);
            this.MainSideBar.TabIndex = 1;
            // 
            // BotBorder
            // 
            this.BotBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(196)))), ((int)(((byte)(217)))));
            this.BotBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BotBorder.Location = new System.Drawing.Point(0, 1098);
            this.BotBorder.Name = "BotBorder";
            this.BotBorder.Size = new System.Drawing.Size(1583, 2);
            this.BotBorder.TabIndex = 2;
            // 
            // MultiContainerInNBM
            // 
            this.MultiContainerInNBM.Controls.Add(this.Btn_Login);
            this.MultiContainerInNBM.Controls.Add(this.Btn_Register);
            this.MultiContainerInNBM.Location = new System.Drawing.Point(113, 0);
            this.MultiContainerInNBM.Name = "MultiContainerInNBM";
            this.MultiContainerInNBM.Size = new System.Drawing.Size(226, 50);
            this.MultiContainerInNBM.TabIndex = 1;
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(1583, 1100);
            this.ControlBox = false;
            this.Controls.Add(this.MainSideBar);
            this.Controls.Add(this.Header);
            this.Controls.Add(this.BotBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainUI";
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Header.ResumeLayout(false);
            this.NavigationBar.ResumeLayout(false);
            this.NavigationBarMenu.ResumeLayout(false);
            this.MultiContainerInNBM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Panel NavigationBar;
        private System.Windows.Forms.Panel Logo;
        private System.Windows.Forms.Panel NavigationBarMenu;
        private System.Windows.Forms.Button Btn_Comment;
        private System.Windows.Forms.Button SideBarToggle;
        private System.Windows.Forms.Panel MainSideBar;
        private System.Windows.Forms.Button Btn_Login;
        private System.Windows.Forms.Button Btn_Register;
        private System.Windows.Forms.Panel BotBorder;
        private System.Windows.Forms.Panel MultiContainerInNBM;
    }
}