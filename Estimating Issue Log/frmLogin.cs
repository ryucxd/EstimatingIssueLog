using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estimating_Issue_Log
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            session sessionLogin = new session();
            sessionLogin.login(txtUsername.Text, txtPassword.Text);
            if(sessionLogin.passwordWrong == true)
            {
                MessageBox.Show("Wrong username/password!");
                wipeTxt(2);
                return;
            }
            if (sessionLogin.isEngineer == false)
            {
                MessageBox.Show("You are not allowed to log into this program!");
                wipeTxt(1);
                return;
            }
            if (sessionLogin.isEngineer == true)
            {
                frmMain frm = new frmMain(Convert.ToInt32(sessionLogin.engineerManager),Convert.ToInt32(sessionLogin.ID));
                frm.Show();
                this.Hide();
            }
        }

        private void wipeTxt(int num)
        {
            if (num == 1) //wipe both
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
            else if (num == 2) //only wipe pass
                txtPassword.Text = "";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
