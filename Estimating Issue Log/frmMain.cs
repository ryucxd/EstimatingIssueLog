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
    public partial class frmMain : Form
    {
        public int EngineerManager { get; set; }
        public frmMain(int _EngineerManager)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
            EngineerManager = _EngineerManager; //use this to filter out the 
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Environment.Exit(1);
                else
                    e.Cancel = true;
            }
        }
    }
}
