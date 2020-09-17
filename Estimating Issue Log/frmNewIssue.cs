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
    public partial class frmNewIssue : Form
    {
        public int ID { get; set; }
        public int personResponsible { get; set; }
        public frmNewIssue(int _ID)
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;
            ID = _ID;
            //fill the combobox with staff names
            comboFill();
        }

        private void comboFill()
        {
            string sql = "SELECT forename + ' ' + surname as [name] FROM dbo.[user] WHERE ( grouping = 5 OR grouping = 15) AND [current] = 1;";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                        cmbEstimating.Items.Add(dataReader["name"].ToString());
                    conn.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            //collate everything and push to to database
            int log_ID = 0;
            string sql = "INSERT INTO dbo.[estimating_issue_log]  (date_logged,quote_number,description,logged_by,person_responsible,title) " +
                "VALUES (GETDATE()," + txtQuote.Text + ",'" + txtIssue.Text + "'," + ID + ",'" + personResponsible.ToString()+ "','" + txtTitle.Text + "')";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT MAX(ID) from dbo.[estimating_issue_log]", conn))
                {
                    conn.Open();
                    log_ID = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            MessageBox.Show("The issue has now been logged. Please attach any evidence to the folder that has just been opened.", "Logged!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.IO.Directory.CreateDirectory(@"\\designsvr1\Public\temp_test\PROJECT EIL\issues\" + log_ID);
            System.Diagnostics.Process.Start(@"\\designsvr1\Public\temp_test\PROJECT EIL\issues\" + log_ID); //open the root folder for /this/ project @ /current/ stage

            this.Close();
        }

        private void txtQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

        }

        private void cmbEstimating_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the ID of the new index
            string sql = "SELECT ID FROM dbo.[user] WHERE forename + ' ' + surname = '" + cmbEstimating.Text + "'";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql,conn))
                {
                    conn.Open();
                    personResponsible = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
        }

        private void frmNewIssue_Load(object sender, EventArgs e)
        {

        }
    }
}
