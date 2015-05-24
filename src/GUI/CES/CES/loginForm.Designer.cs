namespace CES
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.loginName = new System.Windows.Forms.TextBox();
            this.loginPassword = new System.Windows.Forms.TextBox();
            this.loginNameLabel = new System.Windows.Forms.Label();
            this.loginPasswordLabel = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.addrComboBox = new System.Windows.Forms.ComboBox();
            this.addrLabel = new System.Windows.Forms.Label();
            this.aboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loginName
            // 
            this.loginName.Location = new System.Drawing.Point(109, 64);
            this.loginName.Name = "loginName";
            this.loginName.Size = new System.Drawing.Size(131, 21);
            this.loginName.TabIndex = 0;
            // 
            // loginPassword
            // 
            this.loginPassword.Location = new System.Drawing.Point(109, 112);
            this.loginPassword.Name = "loginPassword";
            this.loginPassword.PasswordChar = '*';
            this.loginPassword.Size = new System.Drawing.Size(131, 21);
            this.loginPassword.TabIndex = 1;
            // 
            // loginNameLabel
            // 
            this.loginNameLabel.AutoSize = true;
            this.loginNameLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.loginNameLabel.Location = new System.Drawing.Point(36, 64);
            this.loginNameLabel.Name = "loginNameLabel";
            this.loginNameLabel.Size = new System.Drawing.Size(56, 16);
            this.loginNameLabel.TabIndex = 2;
            this.loginNameLabel.Text = "用户名";
            // 
            // loginPasswordLabel
            // 
            this.loginPasswordLabel.AutoSize = true;
            this.loginPasswordLabel.Font = new System.Drawing.Font("宋体", 12F);
            this.loginPasswordLabel.Location = new System.Drawing.Point(42, 114);
            this.loginPasswordLabel.Name = "loginPasswordLabel";
            this.loginPasswordLabel.Size = new System.Drawing.Size(40, 16);
            this.loginPasswordLabel.TabIndex = 3;
            this.loginPasswordLabel.Text = "密码";
            // 
            // title
            // 
            this.title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 14F, System.Drawing.FontStyle.Bold);
            this.title.Location = new System.Drawing.Point(81, 21);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(129, 19);
            this.title.TabIndex = 4;
            this.title.Text = "学生选课系统";
            this.title.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("宋体", 10F);
            this.loginButton.Location = new System.Drawing.Point(76, 145);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(85, 37);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // addrComboBox
            // 
            this.addrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.addrComboBox.FormattingEnabled = true;
            this.addrComboBox.Items.AddRange(new object[] {
            "10.141.249.176"});
            this.addrComboBox.Location = new System.Drawing.Point(109, 196);
            this.addrComboBox.Name = "addrComboBox";
            this.addrComboBox.Size = new System.Drawing.Size(121, 20);
            this.addrComboBox.TabIndex = 6;
            // 
            // addrLabel
            // 
            this.addrLabel.AutoSize = true;
            this.addrLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.addrLabel.Location = new System.Drawing.Point(26, 199);
            this.addrLabel.Name = "addrLabel";
            this.addrLabel.Size = new System.Drawing.Size(77, 14);
            this.addrLabel.TabIndex = 7;
            this.addrLabel.Text = "登录服务器";
            // 
            // aboutButton
            // 
            this.aboutButton.Font = new System.Drawing.Font("宋体", 9F);
            this.aboutButton.Location = new System.Drawing.Point(167, 150);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(60, 27);
            this.aboutButton.TabIndex = 8;
            this.aboutButton.Text = "关于..";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 231);
            this.Controls.Add(this.aboutButton);
            this.Controls.Add(this.addrLabel);
            this.Controls.Add(this.addrComboBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.loginPasswordLabel);
            this.Controls.Add(this.loginNameLabel);
            this.Controls.Add(this.loginPassword);
            this.Controls.Add(this.loginName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginName;
        private System.Windows.Forms.TextBox loginPassword;
        private System.Windows.Forms.Label loginNameLabel;
        private System.Windows.Forms.Label loginPasswordLabel;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.ComboBox addrComboBox;
        private System.Windows.Forms.Label addrLabel;
        private System.Windows.Forms.Button aboutButton;
    }
}

