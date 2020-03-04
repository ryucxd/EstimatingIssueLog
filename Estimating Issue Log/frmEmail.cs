using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Estimating_Issue_Log
{
    public partial class frmEmail : Form
    {
        public frmEmail()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ELI_icon;


            fillCheckBox();
        }

        public void fillCheckBox()
        {
            string sql = "SELECT forename + ' ' + surname as [name] FROM dbo.[user] WHERE grouping = 5 OR engineerManager = -1 ORDER BY id ASC";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        //traditional
                        checkedListBox1.Items.Add(sdr["name"].ToString(), false); 
                    }
                    conn.Close();
                    }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            string emails = "";
            string sql = "";
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                foreach (object item in checkedListBox1.CheckedItems) //this displays the text of each CHECKED item //
                { //its really nice ^-^
                    //collect the email for each person ticked and build it into a string "test@yes.com;test@no.co.uk;"
                    sql = "SELECT email FROM dbo.[user] WHERE forename + ' ' + surname = '" + item.ToString() + "'";
                    using (SqlCommand cmd = new SqlCommand(sql,conn))
                    {
                        conn.Open();
                        string temp = Convert.ToString(cmd.ExecuteScalar());
                        conn.Close();
                        emails = emails + temp + ";"; //this works like a charm! for both singles AND two people¬
                    }
                }    
            }
            //how we have the string for emails, we can fire the procedure
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_estimating_issue_log_temp_email", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = emails;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            MessageBox.Show("The email has been sent!");
            this.Close();
        }
    }
}
