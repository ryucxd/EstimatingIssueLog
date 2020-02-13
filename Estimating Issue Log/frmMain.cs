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
        public bool dteStartChanged { get; set; }
        public bool dteEndChanged { get; set; }
        public int loggedByID { get; set; }
        public int personResponsibleID { get; set; }
        public frmMain(int _EngineerManager, int _ID)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
            EngineerManager = _EngineerManager; //use this to filter out the 
            ID = _ID;
            refreshDGV();
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
            dataGridView1.Columns[2].HeaderText = "Title";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].HeaderText = "Quote Number";
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].HeaderText = "Issue";
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].HeaderText = "Logged by";
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[6].HeaderText = "Checked by";
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[7].HeaderText = "Checked date";
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[8].HeaderText = "Discussed with";
            dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[9].HeaderText = "Discussed Date";
            dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[10].HeaderText = "Action description";
            dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[11].HeaderText = "Resolved";
            dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[12].HeaderText = "Person Responsible";
            dataGridView1.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //time to shut up and colour up

            for (int i = 0; i < dataGridView1.Rows.Count;i++)
            {
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Resolved")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }
            }
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
            //this needs to filter out what the user sees UNLESS they are a manager...  
            string sql;
            if (EngineerManager == -1)
                sql = "SELECT a.[ID],[date_logged],a.title,[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],CASE WHEN [resolved] = -1 THEN 'Resolved' ELSE ' ' END as [resolved],c.forename + ' ' + c.surname as person_responsible FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id ORDER BY ID DESC;";
            else
                sql = "SELECT a.[ID],[date_logged],a.title,[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],b.forename + ' ' + b.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],CASE WHEN [resolved] = -1 THEN 'Resolved' ELSE ' ' END as [resolved],c.forename + ' ' + c.surname as person_responsible FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id WHERE logged_by = " + ID + " ORDER BY ID DESC";

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
            //adjust the sql string
            string sql = "";

            //add the ending
            if (EngineerManager == -1)
                sql = "SELECT a.[ID],[date_logged],a.title,[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],CASE WHEN [resolved] = -1 THEN 'Resolved' ELSE ' ' END as [resolved],c.forename + ' ' + c.surname as person_responsible,a.title FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id  WHERE ";
            else
                sql = "SELECT a.[ID],[date_logged],a.title,[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],CASE WHEN [resolved] = -1 THEN 'Resolved' ELSE ' ' END as [resolved],c.forename + ' ' + c.surname as person_responsible,a.title FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id  WHERE logged_by = " + ID + "  AND   ";

            //now start adding to the string
            //start with DTE
            if (dteStartChanged == true)
            {
                //if start has changed then
                sql = sql + " date_logged > '" + dteStart.Value.ToString("yyyy - MM - dd") + "'   AND   ";
            }

            if (dteStartChanged == true && dteStartChanged == true) //dont add < unless start is also true
            {
                sql = sql + " date_logged < '" + dteEnd.Value.ToString("yyyy - MM - dd") + "'   AND   ";
            }

            if (txtTitle.TextLength > 0)
            {
                sql = sql + " title LIKE '%" + txtTitle.Text + "%'   AND   ";
            }

            if (txtQuote.TextLength > 0)
            {
                sql = sql + " quote_number LIKE '%" + txtQuote.Text + "%'   AND   ";
            }

            if (txtIssue.TextLength > 0)
            {
                sql = sql + " [description] LIKE '%" + txtIssue.Text + "%'   AND   ";
            }

            if (loggedByID > 0)// need the ID of this person
            {
                sql = sql + " logged_by = " + loggedByID.ToString() + "   AND   ";
            }

            if (personResponsibleID > 0) // need the ID of this person
            {
                sql = sql + " person_responsible = " + personResponsibleID.ToString() + "   AND   ";
            }

            if (chkResolved.Checked == true)
            {
                sql = sql + " resolved = -1 " + "   AND   ";
            }



            sql = sql.Substring(0, sql.Length - 6);

            sql = sql + " ORDER BY ID DESC;";

            //revamp dgv now
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

        private void dteStart_ValueChanged(object sender, EventArgs e)
        {
            dteStartChanged = true;
            applyFilter();
        }

        private void txtQuote_TextChanged(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void cmbLoggedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the ID of what has been selected before apply filter
            string sql = "SELECT ID FROM dbo.[user] WHERE forename + ' ' + surname = '" + cmbLoggedBy.Text + "'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    loggedByID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            applyFilter();
        }

        private void CmbPersonResponsible_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the ID of who has been selected before apply filter
            string sql = "SELECT ID FROM dbo.[user] WHERE forename + ' ' + surname = '" + CmbPersonResponsible.Text + "'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    personResponsibleID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            applyFilter();
        }

        private void chkResolved_CheckedChanged(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void dteEnd_ValueChanged(object sender, EventArgs e)
        {
            dteEndChanged = true;
            applyFilter();
        }

        private void txtIssue_TextChanged(object sender, EventArgs e)
        {
            applyFilter();
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            applyFilter();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[10].Value.ToString() == "Resolved")
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSeaGreen;
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            if (EngineerManager == -1)
            {
                frmAdmin frm = new frmAdmin(selectedID);
                frm.ShowDialog(); 
            }
            else
            {
                frmUser frm = new frmUser(selectedID);
                frm.ShowDialog();
            }
            refreshDGV();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //make them blank
            txtIssue.Text = "";
            txtQuote.Text = "";
            cmbLoggedBy.Text = "";
            CmbPersonResponsible.Text = "";
            chkResolved.Checked = false;
            dteStart.Value = DateTime.Now;
            dteEnd.Value = DateTime.Now;
            //set the "is changed variables" back to null
            dteStartChanged = false;
            dteEndChanged = false;
            loggedByID = 0;
            personResponsibleID = 0;
            applyFilter();
        }


    }
}
