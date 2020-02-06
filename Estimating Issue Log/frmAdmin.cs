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
    public partial class frmAdmin : Form
    {
        public int Selected_ID { get; set; }
        public frmAdmin(int _ID)
        {
            InitializeComponent();
            Selected_ID = _ID;
        }
    }
}
