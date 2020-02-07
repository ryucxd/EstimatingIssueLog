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
    public partial class frmAdmin : Form
    {
        public int Selected_ID { get; set; }
        public frmAdmin(int _ID)
        {
            InitializeComponent();
            Selected_ID = _ID;
            this.Icon = Properties.Resources.ELI_icon;
            getData();

        }

        private void getData()
        {
            string sql = "SELECT a.[ID],[date_logged],[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],[resolved],c.forename + ' ' + c.surname as person_responsible FROM[order_database].[dbo].[estimating_issue_log] a " +
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
                        txtActionTaken.Text = sdr["date_logged"].ToString();
                        txtQuote.Text = sdr["quote_number"].ToString();
                        txtDescription.Text = sdr["description"].ToString();
                        txtLoggedBy.Text = sdr["logged_by"].ToString();
                        cmbCheckedBy.Items.Add(sdr["checked_by"].ToString());
                        txtCheckedDate.Text = sdr["checked_date"].ToString();
                        cmbDiscussedWith.Items.Add(sdr["discussed_with"].ToString());
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtActionTaken.Text = sdr["action_taken"].ToString();
                        cmbPersonResponsible.Items.Add(sdr["person_responsible"].ToString());
                        this.Text = "Issue ID: " + Selected_ID;
                    }
                    conn.Close();
                }
            }

        }
    }
}
