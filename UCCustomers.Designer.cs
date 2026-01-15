namespace PharmacyMS
{
    partial class UCCustomers
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl1 = new System.Windows.Forms.Panel();
            this.LbIndc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DGVCustms = new System.Windows.Forms.DataGridView();
            this.Pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustms)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl1
            // 
            this.Pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Pnl1.Controls.Add(this.LbIndc);
            this.Pnl1.Controls.Add(this.label1);
            this.Pnl1.Controls.Add(this.DGVCustms);
            this.Pnl1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pnl1.Location = new System.Drawing.Point(10, 5);
            this.Pnl1.Name = "Pnl1";
            this.Pnl1.Size = new System.Drawing.Size(880, 628);
            this.Pnl1.TabIndex = 3;
            // 
            // LbIndc
            // 
            this.LbIndc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LbIndc.Location = new System.Drawing.Point(6, 6);
            this.LbIndc.Name = "LbIndc";
            this.LbIndc.Size = new System.Drawing.Size(8, 30);
            this.LbIndc.TabIndex = 1;
            this.LbIndc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(25, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Customers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVCustms
            // 
            this.DGVCustms.AllowUserToAddRows = false;
            this.DGVCustms.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVCustms.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVCustms.BackgroundColor = System.Drawing.Color.Gray;
            this.DGVCustms.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVCustms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVCustms.ColumnHeadersHeight = 34;
            this.DGVCustms.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVCustms.EnableHeadersVisualStyles = false;
            this.DGVCustms.Location = new System.Drawing.Point(5, 45);
            this.DGVCustms.Name = "DGVCustms";
            this.DGVCustms.ReadOnly = true;
            this.DGVCustms.RowHeadersWidth = 40;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVCustms.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVCustms.RowTemplate.Height = 28;
            this.DGVCustms.Size = new System.Drawing.Size(870, 550);
            this.DGVCustms.TabIndex = 0;
            // 
            // UCCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.Pnl1);
            this.Name = "UCCustomers";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(900, 644);
            this.Load += new System.EventHandler(this.UCCustomers_Load);
            this.Pnl1.ResumeLayout(false);
            this.Pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCustms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label LbIndc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DGVCustms;
        public System.Windows.Forms.Panel Pnl1;
    }
}
