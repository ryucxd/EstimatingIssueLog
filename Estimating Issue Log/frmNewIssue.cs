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
    public partial class frmNewIssue : Form
    {
        public frmNewIssue()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
