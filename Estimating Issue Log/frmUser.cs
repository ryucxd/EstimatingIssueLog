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
    public partial class frmUser : Form
    {
        public int Selected_ID { get; set; }
        public frmUser(int _ID)
        {
            InitializeComponent();
            Selected_ID = _ID;
            this.Icon = Properties.Resources.ELI_icon;
            getData();
        }

        private void getData()
        {
            string sql = "SELECT a.[ID],[date_logged],[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],[resolved],c.forename + ' ' + c.surname as person_responsible,a.title FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id  WHERE a.ID = " + Selected_ID;

            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        txtLoggedDate.Text = sdr["date_logged"].ToString();
                        txtQuote.Text = sdr["quote_number"].ToString();
                        txtDescription.Text = sdr["description"].ToString();
                        txtLoggedBy.Text = sdr["logged_by"].ToString();
                        txtCheckedBy.Text = sdr["checked_by"].ToString();
                        txtCheckedDate.Text = sdr["checked_date"].ToString();
                        txtDiscussedWith.Text = sdr["discussed_with"].ToString();
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtActionTaken.Text = sdr["action_taken"].ToString();
                        txtPersonResponsible.Text = sdr["person_responsible"].ToString();
                        txtTitle.Text = sdr["title"].ToString();
                        this.Text = "Issue ID: "+ Selected_ID;
                    }
                    conn.Close();
                }
            }



        }
        private void button1_Click(object sender, EventArgs e)
        {   // update button
            string sql = "UPDATE dbo.estimating_issue_log SET [description] = '" + txtDescription.Text + "',title = '" + txtTitle.Text + "' WHERE ID = " + Selected_ID;
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Issue description has been updated!");
                this.Close();
            }
        }

        private void btnEvidence_Click(object sender, EventArgs e)
        {
            create_folder();
            System.Diagnostics.Process.Start(@"\\designsvr1\Public\temp_test\PROJECT EIL\issues\" + Selected_ID); //open the root folder for /this/ project @ /current/ stage

        }

        private void create_folder()
        {
            System.IO.Directory.CreateDirectory(@"\\designsvr1\Public\temp_test\PROJECT EIL\issues\" + Selected_ID);

        }
    }
}
