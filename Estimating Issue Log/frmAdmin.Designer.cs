namespace Estimating_Issue_Log
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtActionTaken = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckedDate = new System.Windows.Forms.TextBox();
            this.txtDiscussedDate = new System.Windows.Forms.TextBox();
            this.txtLoggedBy = new System.Windows.Forms.TextBox();
            this.txtLoggedDate = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.cmbCheckedBy = new System.Windows.Forms.ComboBox();
            this.cmbDiscussedWith = new System.Windows.Forms.ComboBox();
            this.cmbPersonResponsible = new System.Windows.Forms.ComboBox();
            this.dteCheck = new System.Windows.Forms.DateTimePicker();
            this.dteDiscussed = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chk_resolved = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnEvidence = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(372, 669);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(123, 33);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update ";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtActionTaken
            // 
            this.txtActionTaken.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActionTaken.Location = new System.Drawing.Point(12, 457);
            this.txtActionTaken.Name = "txtActionTaken";
            this.txtActionTaken.Size = new System.Drawing.Size(671, 175);
            this.txtActionTaken.TabIndex = 41;
            this.txtActionTaken.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(23, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Person Responsible";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(298, 436);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Action Taken ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(378, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Discussed With";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(548, 336);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 18);
            this.label7.TabIndex = 37;
            this.label7.Text = "Discussed Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Checked by";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "Checked Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(291, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Issue Recorded";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(564, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Quote Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Logged By";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(554, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Logged Date";
            // 
            // txtCheckedDate
            // 
            this.txtCheckedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheckedDate.Location = new System.Drawing.Point(174, 357);
            this.txtCheckedDate.Name = "txtCheckedDate";
            this.txtCheckedDate.Size = new System.Drawing.Size(157, 24);
            this.txtCheckedDate.TabIndex = 30;
            // 
            // txtDiscussedDate
            // 
            this.txtDiscussedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscussedDate.Location = new System.Drawing.Point(526, 357);
            this.txtDiscussedDate.Name = "txtDiscussedDate";
            this.txtDiscussedDate.Size = new System.Drawing.Size(157, 24);
            this.txtDiscussedDate.TabIndex = 29;
            // 
            // txtLoggedBy
            // 
            this.txtLoggedBy.Enabled = false;
            this.txtLoggedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoggedBy.Location = new System.Drawing.Point(12, 31);
            this.txtLoggedBy.Name = "txtLoggedBy";
            this.txtLoggedBy.Size = new System.Drawing.Size(165, 24);
            this.txtLoggedBy.TabIndex = 26;
            // 
            // txtLoggedDate
            // 
            this.txtLoggedDate.Enabled = false;
            this.txtLoggedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoggedDate.Location = new System.Drawing.Point(518, 31);
            this.txtLoggedDate.Name = "txtLoggedDate";
            this.txtLoggedDate.Size = new System.Drawing.Size(165, 24);
            this.txtLoggedDate.TabIndex = 24;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(12, 147);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(671, 175);
            this.txtDescription.TabIndex = 23;
            this.txtDescription.Text = "";
            // 
            // txtQuote
            // 
            this.txtQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.Location = new System.Drawing.Point(518, 85);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(165, 24);
            this.txtQuote.TabIndex = 22;
            this.txtQuote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuote_KeyPress);
            // 
            // cmbCheckedBy
            // 
            this.cmbCheckedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCheckedBy.FormattingEnabled = true;
            this.cmbCheckedBy.Location = new System.Drawing.Point(12, 355);
            this.cmbCheckedBy.Name = "cmbCheckedBy";
            this.cmbCheckedBy.Size = new System.Drawing.Size(146, 26);
            this.cmbCheckedBy.TabIndex = 43;
            // 
            // cmbDiscussedWith
            // 
            this.cmbDiscussedWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiscussedWith.FormattingEnabled = true;
            this.cmbDiscussedWith.Location = new System.Drawing.Point(361, 355);
            this.cmbDiscussedWith.Name = "cmbDiscussedWith";
            this.cmbDiscussedWith.Size = new System.Drawing.Size(146, 26);
            this.cmbDiscussedWith.TabIndex = 44;
            // 
            // cmbPersonResponsible
            // 
            this.cmbPersonResponsible.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPersonResponsible.FormattingEnabled = true;
            this.cmbPersonResponsible.Location = new System.Drawing.Point(12, 85);
            this.cmbPersonResponsible.Name = "cmbPersonResponsible";
            this.cmbPersonResponsible.Size = new System.Drawing.Size(165, 26);
            this.cmbPersonResponsible.TabIndex = 45;
            // 
            // dteCheck
            // 
            this.dteCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteCheck.Location = new System.Drawing.Point(174, 394);
            this.dteCheck.Name = "dteCheck";
            this.dteCheck.Size = new System.Drawing.Size(157, 24);
            this.dteCheck.TabIndex = 46;
            this.dteCheck.ValueChanged += new System.EventHandler(this.dteCheck_ValueChanged);
            // 
            // dteDiscussed
            // 
            this.dteDiscussed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteDiscussed.Location = new System.Drawing.Point(526, 394);
            this.dteDiscussed.Name = "dteDiscussed";
            this.dteDiscussed.Size = new System.Drawing.Size(157, 24);
            this.dteDiscussed.TabIndex = 47;
            this.dteDiscussed.ValueChanged += new System.EventHandler(this.dteDiscussed_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(358, 397);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(158, 18);
            this.label11.TabIndex = 48;
            this.label11.Text = "Select Discussed Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(18, 397);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(147, 18);
            this.label12.TabIndex = 49;
            this.label12.Text = "Select Checked Date";
            // 
            // chk_resolved
            // 
            this.chk_resolved.AutoSize = true;
            this.chk_resolved.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_resolved.Location = new System.Drawing.Point(244, 638);
            this.chk_resolved.Name = "chk_resolved";
            this.chk_resolved.Size = new System.Drawing.Size(180, 22);
            this.chk_resolved.TabIndex = 50;
            this.chk_resolved.Text = "Mark issue as resolved";
            this.chk_resolved.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(330, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 18);
            this.label13.TabIndex = 52;
            this.label13.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(257, 87);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(180, 24);
            this.txtTitle.TabIndex = 51;
            // 
            // btnEvidence
            // 
            this.btnEvidence.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvidence.Location = new System.Drawing.Point(192, 669);
            this.btnEvidence.Name = "btnEvidence";
            this.btnEvidence.Size = new System.Drawing.Size(123, 33);
            this.btnEvidence.TabIndex = 56;
            this.btnEvidence.Text = "Open Folder";
            this.btnEvidence.UseVisualStyleBackColor = true;
            this.btnEvidence.Click += new System.EventHandler(this.btnEvidence_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(12, 669);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(123, 33);
            this.btnReport.TabIndex = 57;
            this.btnReport.Text = "Print Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmail.Location = new System.Drawing.Point(552, 669);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(123, 33);
            this.btnEmail.TabIndex = 58;
            this.btnEmail.Text = "Email Issue";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 708);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnEvidence);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.chk_resolved);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dteDiscussed);
            this.Controls.Add(this.dteCheck);
            this.Controls.Add(this.cmbPersonResponsible);
            this.Controls.Add(this.cmbDiscussedWith);
            this.Controls.Add(this.cmbCheckedBy);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtActionTaken);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCheckedDate);
            this.Controls.Add(this.txtDiscussedDate);
            this.Controls.Add(this.txtLoggedBy);
            this.Controls.Add(this.txtLoggedDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtQuote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RichTextBox txtActionTaken;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCheckedDate;
        private System.Windows.Forms.TextBox txtDiscussedDate;
        private System.Windows.Forms.TextBox txtLoggedBy;
        private System.Windows.Forms.TextBox txtLoggedDate;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.ComboBox cmbCheckedBy;
        private System.Windows.Forms.ComboBox cmbDiscussedWith;
        private System.Windows.Forms.ComboBox cmbPersonResponsible;
        private System.Windows.Forms.DateTimePicker dteCheck;
        private System.Windows.Forms.DateTimePicker dteDiscussed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chk_resolved;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnEvidence;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnEmail;
    }
}