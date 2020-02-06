using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Estimating_Issue_Log
{
    public partial class frmMain : Form
    {
        public int EngineerManager { get; set; }
        public int ID { get; set; }
        public frmMain(int _EngineerManager, int _ID)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
            EngineerManager = _EngineerManager; //use this to filter out the 
            ID = _ID;
            string sql = "";
            if (EngineerManager == -1)
                sql = "SELECT * FROM dbo.estimating_issue_log;";
            else
                sql = "SELECT * FROM dbo.estimating_issue_log WHERE logged_by = " + ID;
            //fill DGV
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            format();
            locking(EngineerManager);
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
        private void format()
        {
            //dgv formatting
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].HeaderText = "Date Logged";
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].HeaderText = "Quote Number";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].HeaderText = "Issue";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].HeaderText = "Logged by";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].HeaderText = "Checked by";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].HeaderText = "Checked date";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].HeaderText = "Discussed with";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].HeaderText = "Discussed Date";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].HeaderText = "Action description";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[10].HeaderText = "Resolved";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void locking(int overRide)
        {
            if (overRide == -1) //if there even are things to lock lmao
            {
                //unlock ALL the things

            }
            else
            {
                //lock ALL the things

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewIssue frm = new frmNewIssue(ID);
            frm.ShowDialog();
        }
    }
}
