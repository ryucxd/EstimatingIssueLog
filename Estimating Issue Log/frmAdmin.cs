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
        public string USER { get; set; }

        public string identifier { get; set; }
        public string dateLogged { get; set; }
        public string quoteNumber { get; set; }
        public string issue { get; set; }
        public string PersonResponsible { get; set; }
        public frmAdmin(int _ID, string _USER)
        {
            InitializeComponent();
            Selected_ID = _ID;
            USER = _USER;
            this.Icon = Properties.Resources.ELI_icon;
            getData();

        }

        private void getData()
        {
            string sql = "SELECT a.[ID],[date_logged],[quote_number],[description],b.forename + ' ' + b.surname as [logged_by],e.forename + ' ' + e.surname as[checked_by],[checked_date],d.forename + ' ' + d.surname as [discussed_with]," +
                    "[discussed_date],[action_taken],[resolved],c.forename + ' ' + c.surname as person_responsible, a.[title] as [title] FROM[order_database].[dbo].[estimating_issue_log] a " +
                    "LEFT JOIN[user_info].[dbo].[user] b ON a.logged_by = b.id " +
                    "LEFT JOIN[user_info].[dbo].[user] c ON a.person_responsible = c.id " +
                    "LEFT JOIN[user_info].[dbo].[user] d ON a.discussed_with = d.id " +
                    "LEFT JOIN[user_info].[dbo].[user] e ON a.checked_by = e.id  WHERE a.ID = " + Selected_ID;

            //variables for combo boxes
            string checkedBy = "", discussedWith = "", personResponsible = "";
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
                        checkedBy = (sdr["checked_by"].ToString());
                        txtCheckedDate.Text = sdr["checked_date"].ToString();
                        discussedWith = (sdr["discussed_with"].ToString());
                        txtDiscussedDate.Text = sdr["discussed_date"].ToString();
                        txtActionTaken.Text = sdr["action_taken"].ToString();
                        personResponsible = (sdr["person_responsible"].ToString());
                        txtTitle.Text = (sdr["title"].ToString());
                        this.Text = "Issue ID: " + Selected_ID;
                    }
                    conn.Close();

                    //make the properties fill here incase it needs to be emailed
                    identifier = Convert.ToString(Selected_ID);
                    dateLogged = txtLoggedDate.Text;
                    quoteNumber = txtQuote.Text;
                    issue = txtDescription.Text;
                    PersonResponsible = personResponsible;

                }

                //checked by
                sql = "SELECT forename + ' ' + surname as [name] FROM [user_info].[dbo].[user] WHERE engineerManager = -1";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // because two combo boxes are going to have the same people maybe i can do this in one box
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                        cmbCheckedBy.Items.Add(dataReader["name"].ToString());
                    conn.Close();
                }

                //person responsible + discussed with
                sql = "SELECT forename + ' ' + surname as [name] FROM [user_info].[dbo].[user] WHERE grouping = 5";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) // because two combo boxes are going to have the same people maybe i can do this in one box
                {
                    conn.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        cmbPersonResponsible.Items.Add(dataReader["name"].ToString());
                        cmbDiscussedWith.Items.Add(dataReader["name"].ToString());
                    }
                    conn.Close();
                }

                //now set the cmb indexs to what is currently ***IF*** there is any
                int checkedIndex = 0;
                if (checkedBy != null)
                {
                    checkedIndex = cmbCheckedBy.Items.IndexOf(checkedBy);
                    cmbCheckedBy.SelectedIndex = checkedIndex;
                }
                int discussedIndex = 0;
                if (discussedWith != null)
                {
                    discussedIndex = cmbDiscussedWith.Items.IndexOf(discussedWith);
                    cmbDiscussedWith.SelectedIndex = discussedIndex;
                }
                int personIndex;
                if (personResponsible != null)
                {
                    personIndex = cmbPersonResponsible.Items.IndexOf(personResponsible);
                    cmbPersonResponsible.SelectedIndex = personIndex;
                }

            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //before the major update get all of the new params into variables to save calling   cmbPointless.index.taking.forever.to.get.to.the.end.text.tostring()
            //also needa  few connection strings to get the ID of the selected names
            int personResponsible = 0, checkedBy = 0, discussedWith = 0;
            int quoteNumber = Convert.ToInt32(txtQuote.Text);
            string description = txtDescription.Text;
            string ACTION = txtActionTaken.Text;

            //DTE is a bit tricky for displaying so we'll do that later

            //getting ID for the comboboxes that currently only display strings
            //if they bring back NULL coalesce it to 0 so it doesnt error and we can leave the combo blank etc
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionStringUser))
            {
                string sql = "SELECT COALESCE(ID,0) from dbo.[user] WHERE forename + ' ' + surname = '" + cmbPersonResponsible.Text + "' AND ID <> 195 AND ID <> 238 "; //person responsible first 
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();                                                                                                                                                                                                    //195/238 ARE NULL NAMES SO REMOVE THEM REEEEE TOM WHY DO YOU DO THISSSSS
                    personResponsible = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
                sql = "SELECT COALESCE(ID, 0) from dbo.[user] WHERE forename + ' ' + surname = '" + cmbCheckedBy.Text + "'  AND ID <> 195 AND ID <> 238 "; //checked by second
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    checkedBy = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
                sql = "SELECT COALESCE(ID, 0) from dbo.[user] WHERE forename + ' ' + surname = '" + cmbDiscussedWith.Text + "' AND ID <> 195 AND ID <> 238 "; //discussed with last
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    discussedWith = Convert.ToInt32(cmd.ExecuteScalar());
                    conn.Close();
                }
            }
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                //sql string but its like its a mech and its combining
                int needsComma = 0;
                string sql = "UPDATE dbo.estimating_issue_log SET ";
                if (personResponsible != 0)
                {
                    sql = sql + "person_responsible = " + personResponsible.ToString() + " ";
                    //variable for adding a comma
                    needsComma = 1;
                }
                if (checkedBy != 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + " checked_by = " + checkedBy.ToString() + " ";
                    needsComma = 1;
                }
                if (discussedWith != 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + " discussed_with = " + discussedWith.ToString() + " ";
                    needsComma = 1;
                }
                if (quoteNumber > 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + "quote_number = " + quoteNumber.ToString() + " ";
                    needsComma = 1;
                }
                if (description.Length > 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + " description = '" + description + "'";
                    needsComma = 1;
                }
                if (ACTION.Length > 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + "action_taken = '" + ACTION + "' ";
                    needsComma = 1;
                }
                //thats everything EXCEPT for the dates
                //date time baby
                if (txtCheckedDate.Text.Length > 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + "checked_date = '" + txtCheckedDate.Text + "' ";
                    needsComma = 1;
                }
                if (txtDiscussedDate.Text.Length > 0)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + "discussed_date = '" + txtDiscussedDate.Text + "' ";
                    needsComma = 1;
                }
                if (chk_resolved.Checked == true)
                {
                    if (needsComma != 0)
                        sql = sql + ",";
                    sql = sql + "resolved = -1";
                }

                sql = sql + "WHERE id = " + Selected_ID;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Information updated!");
                    this.Close();
                }
            }
        }

        private void dteCheck_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dteCheck.Value;
            txtCheckedDate.Text = date.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void dteDiscussed_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = this.dteDiscussed.Value;
            txtDiscussedDate.Text = date.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void txtQuote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
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

        private void btnReport_Click(object sender, EventArgs e)
        {//tjhios
            btnReport.Enabled = false;
            CrystalReport3 rpt = new CrystalReport3();
            rpt.SetParameterValue("ID", "ID: " + Selected_ID);
            rpt.SetParameterValue("USER", "Logged by:" + USER + " - Person Responsible: " + cmbPersonResponsible.Text);
            rpt.SetParameterValue("TITLE", "" + txtTitle.Text);
            rpt.SetParameterValue("DATE",   "DATE LOGGED: " + txtLoggedDate.Text);
            rpt.SetParameterValue("ISSUE", "ISSUE: " + txtDescription.Text + Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine +" ACTION TAKEN: " + txtActionTaken.Text); ;
            rpt.SetParameterValue("MEETINGTIME", "Time of meeting: .........................................");
            rpt.SetParameterValue("RESOLVED", "[ ] Resolved?");
            rpt.SetParameterValue("DISCUSSEDWITH", "Discussed With: " + cmbDiscussedWith.Text);
            rpt.SetParameterValue("DISCUSSEDWITHDATE", "Discussed Date: " + txtDiscussedDate.Text);
            rpt.SetParameterValue("CHECKEDBY", "Checked By: " + cmbCheckedBy.Text);
            rpt.SetParameterValue("CHECKEDBYDATE", "Checked Date: " + txtCheckedDate.Text);
            rpt.SetParameterValue("QUOTE", "Quote: " + txtQuote.Text);
            rpt.PrintToPrinter(1, false, 0, 0);
            MessageBox.Show("Report has been sent to your default printer!", "REPORT SENT",MessageBoxButtons.OK);

            //working code for paint shop
            //    label_test rpt = new label_test();
            //    string RAL = hiddenDGV.Rows[i].Cells[0].Value.ToString();
            //    string DOOR = hiddenDGV.Rows[i].Cells[1].Value.ToString();
            //    string FINISH = hiddenDGV.Rows[i].Cells[3].Value.ToString();
            //    string SUPPLIER = hiddenDGV.Rows[i].Cells[2].Value.ToString();
            //    rpt.SetParameterValue("RALCOLOUR", RAL);
            //    rpt.SetParameterValue("SUPPLIER", "Supplier: " + SUPPLIER);
            //    rpt.SetParameterValue("FINISH", "Finish: " + FINISH);
            //    rpt.SetParameterValue("DOORNUMBER", "Door Number: " + DOOR);
            //    rpt.PrintToPrinter(1, false, 0, 0); //this works well for auto printing
            //    insertINTO(DOOR);
            //}
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(CONNECT.ConnectionString))
            {
                //clear up temp table first
                string sql = "DELETE FROM dbo.estimating_issue_log_temp";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                    //before opening the form, update the table to include only that entry
                    sql = "INSERT INTO dbo.estimating_issue_log_temp (ID,date_logged,quote_number,issue,person_responsible) VALUES(" +
                        "'" + identifier + "','" + dateLogged + "','" + quoteNumber + "','" + issue + "','" + PersonResponsible + "')";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
                frmEmail frm = new frmEmail();
            frm.ShowDialog();
        }
    }
}
