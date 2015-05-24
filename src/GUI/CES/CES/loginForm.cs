using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CES
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string loginState;
            // call login.exe
            if (string.IsNullOrEmpty(loginName.Text) || string.IsNullOrEmpty(loginPassword.Text))
            {
                MessageBox.Show("用户名或密码不能为空");
                return;
            }
            Process processLogin = new Process();
            processLogin.StartInfo.RedirectStandardOutput = true;
            processLogin.StartInfo.UseShellExecute = false;
            processLogin.StartInfo.CreateNoWindow = true;
            processLogin.StartInfo.FileName = "login.exe";
            processLogin.StartInfo.RedirectStandardInput = true;
            processLogin.Start();
            processLogin.StandardInput.WriteLine(loginName.Text);
            processLogin.StandardInput.WriteLine(loginPassword.Text);
            processLogin.WaitForExit();
            if (processLogin.HasExited)
            {
                loginState = processLogin.StandardOutput.ReadToEnd();
                if(!loginState.Contains("登录成功"))
                {
                    MessageBox.Show(loginState);
                    processLogin.Close();
                    return;
                }
            }
            processLogin.Close();
            // Show Main
            Main mainForm = new Main(loginName.Text);
            mainForm.Show();
            this.Hide();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.AcceptButton = loginButton;
            addrComboBox.SelectedIndex = 0;
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }

    }
}
