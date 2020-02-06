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
            refreshDGV();
            format();
            fillCombo();
            locking(EngineerManager);
        }

        private void fillCombo()
        {
            //fill the combo logged by based on who has added a entry (saves me having to add everyone
            string sql = "SELECT DISTINCT b.forename + ' ' + b.surname as [name] FROM dbo.estimating_issue_log a " + //logged by
                "LEFT JOIN [user_info].[dbo].[user] b ON a.logged_by = b.ID;";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                        cmbLoggedBy.Items.Add(dataReader["name"].ToString());
                    conn.Close();
                }
            }
            //person responsible
            sql = "SELECT forename + ' ' + surname as [name] FROM dbo.[user] WHERE grouping = 5;";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                        CmbPersonResponsible.Items.Add(dataReader["name"].ToString());
                    conn.Close();
                }
            }
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
            dataGridView1.Columns[11].HeaderText = "Person Responsible";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        private void locking(int overRide)
        {
            if (overRide == -1) //if there even are things to lock lmao
            {
                //unlock ALL the things
                chkResolved.Enabled = true;
                cmbLoggedBy.Enabled = true;
            }
            else
            {
                //lock ALL the things
                chkResolved.Enabled = false;
                cmbLoggedBy.Enabled = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmNewIssue frm = new frmNewIssue(ID);
            frm.ShowDialog();
            refreshDGV();
        }

        private void txtQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void refreshDGV()
        {
            //this needs to filter out what the user sees UNLESS they are a manager...  //same thats on the form load but this needs to be callable
            string sql;
            if (EngineerManager == -1)
                sql = "SELECT a.[ID],[date_logged],[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],[resolved],c.forename + ' ' + c.surname as person_responsible FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id ORDER BY ID DESC;";
            else
                sql = "SELECT a.[ID],[date_logged],[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],[resolved],c.forename + ' ' + c.surname as person_responsible FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id WHERE logged_by = " + ID + "ORDER BY ID DESC";

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //clear the DGV
                    dataGridView1.DataSource = null;
                    this.dataGridView1.Rows.Clear();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            //format the DGV 
            format();
        }

        private void applyFilter()
        {

        }
    }
}
