namespace Estimating_Issue_Log
{
    partial class frmNewIssue
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
            this.txtIssue = new System.Windows.Forms.RichTextBox();
            this.lblQuoteNumber = new System.Windows.Forms.Label();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstimating = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIssue
            // 
            this.txtIssue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIssue.Location = new System.Drawing.Point(8, 139);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.Size = new System.Drawing.Size(340, 142);
            this.txtIssue.TabIndex = 3;
            this.txtIssue.Text = "";
            // 
            // lblQuoteNumber
            // 
            this.lblQuoteNumber.AutoSize = true;
            this.lblQuoteNumber.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuoteNumber.Location = new System.Drawing.Point(43, 87);
            this.lblQuoteNumber.Name = "lblQuoteNumber";
            this.lblQuoteNumber.Size = new System.Drawing.Size(85, 15);
            this.lblQuoteNumber.TabIndex = 1;
            this.lblQuoteNumber.Text = "Quote number";
            // 
            // txtQuote
            // 
            this.txtQuote.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuote.Location = new System.Drawing.Point(134, 83);
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(100, 23);
            this.txtQuote.TabIndex = 2;
            this.txtQuote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuote_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Person responsible";
            // 
            // cmbEstimating
            // 
            this.cmbEstimating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstimating.FormattingEnabled = true;
            this.cmbEstimating.Location = new System.Drawing.Point(124, 16);
            this.cmbEstimating.Name = "cmbEstimating";
            this.cmbEstimating.Size = new System.Drawing.Size(121, 21);
            this.cmbEstimating.TabIndex = 1;
            this.cmbEstimating.SelectedIndexChanged += new System.EventHandler(this.cmbEstimating_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Description of Issue";
            // 
            // btnLog
            // 
            this.btnLog.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Location = new System.Drawing.Point(221, 287);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(75, 23);
            this.btnLog.TabIndex = 4;
            this.btnLog.Text = "Log Issue";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(63, 287);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(134, 54);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(100, 23);
            this.txtTitle.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Title";
            // 
            // frmNewIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 325);
            this.ControlBox = false;
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEstimating);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtQuote);
            this.Controls.Add(this.lblQuoteNumber);
            this.Controls.Add(this.txtIssue);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewIssue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Issue";
            this.Load += new System.EventHandler(this.frmNewIssue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtIssue;
        private System.Windows.Forms.Label lblQuoteNumber;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEstimating;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label3;
    }
}