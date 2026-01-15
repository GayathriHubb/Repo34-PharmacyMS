namespace PharmacyMS
{
    partial class UCOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCOrders));
            this.Pnl1 = new System.Windows.Forms.Panel();
            this.LbIndc = new System.Windows.Forms.Label();
            this.LbAvlProds = new System.Windows.Forms.Label();
            this.DGVAvlProds = new System.Windows.Forms.DataGridView();
            this.Pnl2 = new System.Windows.Forms.Panel();
            this.Gn2NUDQty = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.LbLine = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.LbProdPrice = new System.Windows.Forms.Label();
            this.LbProdId = new System.Windows.Forms.Label();
            this.CmbBxProd = new System.Windows.Forms.ComboBox();
            this.CmbBxCategory = new System.Windows.Forms.ComboBox();
            this.Gn2BtnInsert = new Guna.UI2.WinForms.Guna2Button();
            this.Gn2BtnClear = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Pnl3 = new System.Windows.Forms.Panel();
            this.Gn2BtnReceipt = new Guna.UI2.WinForms.Guna2Button();
            this.Gn2TBChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.Gn2TBAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.Gn2TBTotalPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Gn2BtnPay = new Guna.UI2.WinForms.Guna2Button();
            this.Gn2BtnRemove = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LbOrders = new System.Windows.Forms.Label();
            this.DGVOrders = new System.Windows.Forms.DataGridView();
            this.PD1 = new System.Drawing.Printing.PrintDocument();
            this.PPD1 = new System.Windows.Forms.PrintPreviewDialog();
            this.Pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvlProds)).BeginInit();
            this.Pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gn2NUDQty)).BeginInit();
            this.Pnl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // Pnl1
            // 
            this.Pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Pnl1.Controls.Add(this.LbIndc);
            this.Pnl1.Controls.Add(this.LbAvlProds);
            this.Pnl1.Controls.Add(this.DGVAvlProds);
            this.Pnl1.Location = new System.Drawing.Point(5, 5);
            this.Pnl1.Name = "Pnl1";
            this.Pnl1.Size = new System.Drawing.Size(500, 280);
            this.Pnl1.TabIndex = 0;
            // 
            // LbIndc
            // 
            this.LbIndc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LbIndc.Location = new System.Drawing.Point(6, 3);
            this.LbIndc.Name = "LbIndc";
            this.LbIndc.Size = new System.Drawing.Size(8, 30);
            this.LbIndc.TabIndex = 3;
            this.LbIndc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbAvlProds
            // 
            this.LbAvlProds.AutoSize = true;
            this.LbAvlProds.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.LbAvlProds.Location = new System.Drawing.Point(25, 8);
            this.LbAvlProds.Name = "LbAvlProds";
            this.LbAvlProds.Size = new System.Drawing.Size(172, 21);
            this.LbAvlProds.TabIndex = 2;
            this.LbAvlProds.Text = "Available Products";
            this.LbAvlProds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVAvlProds
            // 
            this.DGVAvlProds.AllowUserToAddRows = false;
            this.DGVAvlProds.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVAvlProds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.DGVAvlProds.BackgroundColor = System.Drawing.Color.Gray;
            this.DGVAvlProds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVAvlProds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DGVAvlProds.ColumnHeadersHeight = 34;
            this.DGVAvlProds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVAvlProds.EnableHeadersVisualStyles = false;
            this.DGVAvlProds.Location = new System.Drawing.Point(5, 40);
            this.DGVAvlProds.Name = "DGVAvlProds";
            this.DGVAvlProds.ReadOnly = true;
            this.DGVAvlProds.RowHeadersWidth = 40;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVAvlProds.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DGVAvlProds.RowTemplate.Height = 28;
            this.DGVAvlProds.Size = new System.Drawing.Size(490, 235);
            this.DGVAvlProds.TabIndex = 1;
            this.DGVAvlProds.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVAvlProds_CellClick);
            // 
            // Pnl2
            // 
            this.Pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Pnl2.Controls.Add(this.Gn2NUDQty);
            this.Pnl2.Controls.Add(this.label11);
            this.Pnl2.Controls.Add(this.LbLine);
            this.Pnl2.Controls.Add(this.label6);
            this.Pnl2.Controls.Add(this.label7);
            this.Pnl2.Controls.Add(this.LbProdPrice);
            this.Pnl2.Controls.Add(this.LbProdId);
            this.Pnl2.Controls.Add(this.CmbBxProd);
            this.Pnl2.Controls.Add(this.CmbBxCategory);
            this.Pnl2.Controls.Add(this.Gn2BtnInsert);
            this.Pnl2.Controls.Add(this.Gn2BtnClear);
            this.Pnl2.Controls.Add(this.label5);
            this.Pnl2.Controls.Add(this.label4);
            this.Pnl2.Controls.Add(this.label3);
            this.Pnl2.Controls.Add(this.label2);
            this.Pnl2.Location = new System.Drawing.Point(5, 290);
            this.Pnl2.Name = "Pnl2";
            this.Pnl2.Size = new System.Drawing.Size(500, 346);
            this.Pnl2.TabIndex = 1;
            // 
            // Gn2NUDQty
            // 
            this.Gn2NUDQty.BackColor = System.Drawing.Color.Transparent;
            this.Gn2NUDQty.BorderRadius = 8;
            this.Gn2NUDQty.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Gn2NUDQty.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Gn2NUDQty.Location = new System.Drawing.Point(190, 241);
            this.Gn2NUDQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Gn2NUDQty.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.Gn2NUDQty.Name = "Gn2NUDQty";
            this.Gn2NUDQty.Size = new System.Drawing.Size(140, 35);
            this.Gn2NUDQty.TabIndex = 45;
            this.Gn2NUDQty.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2NUDQty.UpDownButtonForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(25, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 21);
            this.label11.TabIndex = 44;
            this.label11.Text = "Quantity";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbLine
            // 
            this.LbLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.LbLine.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold);
            this.LbLine.ForeColor = System.Drawing.Color.Honeydew;
            this.LbLine.Location = new System.Drawing.Point(0, 50);
            this.LbLine.Name = "LbLine";
            this.LbLine.Size = new System.Drawing.Size(500, 4);
            this.LbLine.TabIndex = 43;
            this.LbLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(6, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 30);
            this.label6.TabIndex = 22;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(25, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "Select Orders";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbProdPrice
            // 
            this.LbProdPrice.AutoSize = true;
            this.LbProdPrice.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.LbProdPrice.Location = new System.Drawing.Point(190, 206);
            this.LbProdPrice.Name = "LbProdPrice";
            this.LbProdPrice.Size = new System.Drawing.Size(80, 21);
            this.LbProdPrice.TabIndex = 20;
            this.LbProdPrice.Text = "----------";
            this.LbProdPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbProdId
            // 
            this.LbProdId.AutoSize = true;
            this.LbProdId.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.LbProdId.Location = new System.Drawing.Point(190, 161);
            this.LbProdId.Name = "LbProdId";
            this.LbProdId.Size = new System.Drawing.Size(80, 21);
            this.LbProdId.TabIndex = 19;
            this.LbProdId.Text = "----------";
            this.LbProdId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbBxProd
            // 
            this.CmbBxProd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxProd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbBxProd.FormattingEnabled = true;
            this.CmbBxProd.Location = new System.Drawing.Point(132, 111);
            this.CmbBxProd.Name = "CmbBxProd";
            this.CmbBxProd.Size = new System.Drawing.Size(258, 36);
            this.CmbBxProd.TabIndex = 18;
            this.CmbBxProd.SelectedIndexChanged += new System.EventHandler(this.CmbBxProd_SelectedIndexChanged);
            // 
            // CmbBxCategory
            // 
            this.CmbBxCategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBxCategory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbBxCategory.FormattingEnabled = true;
            this.CmbBxCategory.Location = new System.Drawing.Point(132, 66);
            this.CmbBxCategory.Name = "CmbBxCategory";
            this.CmbBxCategory.Size = new System.Drawing.Size(258, 36);
            this.CmbBxCategory.TabIndex = 17;
            this.CmbBxCategory.SelectedIndexChanged += new System.EventHandler(this.CmbBxCategory_SelectedIndexChanged);
            // 
            // Gn2BtnInsert
            // 
            this.Gn2BtnInsert.Animated = true;
            this.Gn2BtnInsert.BackColor = System.Drawing.Color.Transparent;
            this.Gn2BtnInsert.BorderRadius = 8;
            this.Gn2BtnInsert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gn2BtnInsert.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnInsert.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnInsert.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Gn2BtnInsert.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Gn2BtnInsert.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnInsert.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gn2BtnInsert.ForeColor = System.Drawing.Color.White;
            this.Gn2BtnInsert.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(30)))));
            this.Gn2BtnInsert.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Gn2BtnInsert.Location = new System.Drawing.Point(78, 300);
            this.Gn2BtnInsert.Name = "Gn2BtnInsert";
            this.Gn2BtnInsert.Size = new System.Drawing.Size(150, 35);
            this.Gn2BtnInsert.TabIndex = 16;
            this.Gn2BtnInsert.Text = "Insert";
            this.Gn2BtnInsert.Click += new System.EventHandler(this.Gn2BtnInsert_Click);
            // 
            // Gn2BtnClear
            // 
            this.Gn2BtnClear.Animated = true;
            this.Gn2BtnClear.BackColor = System.Drawing.Color.Transparent;
            this.Gn2BtnClear.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnClear.BorderRadius = 8;
            this.Gn2BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gn2BtnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Gn2BtnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Gn2BtnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnClear.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gn2BtnClear.ForeColor = System.Drawing.Color.White;
            this.Gn2BtnClear.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(30)))));
            this.Gn2BtnClear.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Gn2BtnClear.Location = new System.Drawing.Point(269, 300);
            this.Gn2BtnClear.Name = "Gn2BtnClear";
            this.Gn2BtnClear.Size = new System.Drawing.Size(150, 35);
            this.Gn2BtnClear.TabIndex = 15;
            this.Gn2BtnClear.Text = "Clear";
            this.Gn2BtnClear.Click += new System.EventHandler(this.Gn2BtnClear_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(25, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Regular Price";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(25, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Products";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(25, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Categories";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(25, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "ProductId";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Pnl3
            // 
            this.Pnl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Pnl3.Controls.Add(this.Gn2BtnReceipt);
            this.Pnl3.Controls.Add(this.Gn2TBChange);
            this.Pnl3.Controls.Add(this.Gn2TBAmount);
            this.Pnl3.Controls.Add(this.Gn2TBTotalPrice);
            this.Pnl3.Controls.Add(this.label8);
            this.Pnl3.Controls.Add(this.label9);
            this.Pnl3.Controls.Add(this.label10);
            this.Pnl3.Controls.Add(this.Gn2BtnPay);
            this.Pnl3.Controls.Add(this.Gn2BtnRemove);
            this.Pnl3.Controls.Add(this.label1);
            this.Pnl3.Controls.Add(this.LbOrders);
            this.Pnl3.Controls.Add(this.DGVOrders);
            this.Pnl3.Location = new System.Drawing.Point(511, 5);
            this.Pnl3.Name = "Pnl3";
            this.Pnl3.Size = new System.Drawing.Size(380, 630);
            this.Pnl3.TabIndex = 0;
            // 
            // Gn2BtnReceipt
            // 
            this.Gn2BtnReceipt.Animated = true;
            this.Gn2BtnReceipt.BackColor = System.Drawing.Color.Transparent;
            this.Gn2BtnReceipt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnReceipt.BorderRadius = 8;
            this.Gn2BtnReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gn2BtnReceipt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnReceipt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Gn2BtnReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Gn2BtnReceipt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnReceipt.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gn2BtnReceipt.ForeColor = System.Drawing.Color.White;
            this.Gn2BtnReceipt.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(30)))));
            this.Gn2BtnReceipt.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Gn2BtnReceipt.Location = new System.Drawing.Point(102, 588);
            this.Gn2BtnReceipt.Name = "Gn2BtnReceipt";
            this.Gn2BtnReceipt.Size = new System.Drawing.Size(180, 30);
            this.Gn2BtnReceipt.TabIndex = 24;
            this.Gn2BtnReceipt.Text = "Receipt";
            this.Gn2BtnReceipt.Click += new System.EventHandler(this.Gn2BtnReceipt_Click);
            // 
            // Gn2TBChange
            // 
            this.Gn2TBChange.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2TBChange.BorderRadius = 8;
            this.Gn2TBChange.BorderThickness = 2;
            this.Gn2TBChange.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Gn2TBChange.DefaultText = "";
            this.Gn2TBChange.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Gn2TBChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Gn2TBChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBChange.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBChange.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Gn2TBChange.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Gn2TBChange.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBChange.Location = new System.Drawing.Point(135, 451);
            this.Gn2TBChange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Gn2TBChange.Name = "Gn2TBChange";
            this.Gn2TBChange.PlaceholderText = "";
            this.Gn2TBChange.SelectedText = "";
            this.Gn2TBChange.Size = new System.Drawing.Size(231, 36);
            this.Gn2TBChange.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Gn2TBChange.TabIndex = 23;
            // 
            // Gn2TBAmount
            // 
            this.Gn2TBAmount.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2TBAmount.BorderRadius = 8;
            this.Gn2TBAmount.BorderThickness = 2;
            this.Gn2TBAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Gn2TBAmount.DefaultText = "";
            this.Gn2TBAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Gn2TBAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Gn2TBAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBAmount.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Gn2TBAmount.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Gn2TBAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBAmount.Location = new System.Drawing.Point(135, 404);
            this.Gn2TBAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Gn2TBAmount.Name = "Gn2TBAmount";
            this.Gn2TBAmount.PlaceholderText = "";
            this.Gn2TBAmount.SelectedText = "";
            this.Gn2TBAmount.Size = new System.Drawing.Size(231, 36);
            this.Gn2TBAmount.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Gn2TBAmount.TabIndex = 22;
            this.Gn2TBAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Gn2TBAmount_KeyDown);
            // 
            // Gn2TBTotalPrice
            // 
            this.Gn2TBTotalPrice.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2TBTotalPrice.BorderRadius = 8;
            this.Gn2TBTotalPrice.BorderThickness = 2;
            this.Gn2TBTotalPrice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Gn2TBTotalPrice.DefaultText = "";
            this.Gn2TBTotalPrice.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Gn2TBTotalPrice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Gn2TBTotalPrice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBTotalPrice.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Gn2TBTotalPrice.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBTotalPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Gn2TBTotalPrice.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Gn2TBTotalPrice.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Gn2TBTotalPrice.Location = new System.Drawing.Point(135, 354);
            this.Gn2TBTotalPrice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Gn2TBTotalPrice.Name = "Gn2TBTotalPrice";
            this.Gn2TBTotalPrice.PlaceholderText = "";
            this.Gn2TBTotalPrice.SelectedText = "";
            this.Gn2TBTotalPrice.Size = new System.Drawing.Size(231, 36);
            this.Gn2TBTotalPrice.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.Gn2TBTotalPrice.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Leelawadee", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(8, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 19);
            this.label8.TabIndex = 21;
            this.label8.Text = "Amount(₹)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Leelawadee", 8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(8, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 19);
            this.label9.TabIndex = 20;
            this.label9.Text = "TotalPrice(₹)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Leelawadee", 8F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(8, 458);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Change(₹)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Gn2BtnPay
            // 
            this.Gn2BtnPay.Animated = true;
            this.Gn2BtnPay.BackColor = System.Drawing.Color.Transparent;
            this.Gn2BtnPay.BorderRadius = 8;
            this.Gn2BtnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gn2BtnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Gn2BtnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Gn2BtnPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnPay.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gn2BtnPay.ForeColor = System.Drawing.Color.White;
            this.Gn2BtnPay.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(30)))));
            this.Gn2BtnPay.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Gn2BtnPay.Location = new System.Drawing.Point(102, 502);
            this.Gn2BtnPay.Name = "Gn2BtnPay";
            this.Gn2BtnPay.Size = new System.Drawing.Size(180, 30);
            this.Gn2BtnPay.TabIndex = 18;
            this.Gn2BtnPay.Text = "Pay Orders";
            this.Gn2BtnPay.Click += new System.EventHandler(this.Gn2BtnPay_Click);
            // 
            // Gn2BtnRemove
            // 
            this.Gn2BtnRemove.Animated = true;
            this.Gn2BtnRemove.BackColor = System.Drawing.Color.Transparent;
            this.Gn2BtnRemove.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnRemove.BorderRadius = 8;
            this.Gn2BtnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Gn2BtnRemove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnRemove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Gn2BtnRemove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Gn2BtnRemove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Gn2BtnRemove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            this.Gn2BtnRemove.Font = new System.Drawing.Font("Leelawadee", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gn2BtnRemove.ForeColor = System.Drawing.Color.White;
            this.Gn2BtnRemove.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(30)))));
            this.Gn2BtnRemove.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(195)))), ((int)(((byte)(190)))));
            this.Gn2BtnRemove.Location = new System.Drawing.Point(102, 545);
            this.Gn2BtnRemove.Name = "Gn2BtnRemove";
            this.Gn2BtnRemove.Size = new System.Drawing.Size(180, 30);
            this.Gn2BtnRemove.TabIndex = 17;
            this.Gn2BtnRemove.Text = "Remove";
            this.Gn2BtnRemove.Click += new System.EventHandler(this.Gn2BtnRemove_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(4, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 30);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LbOrders
            // 
            this.LbOrders.AutoSize = true;
            this.LbOrders.Font = new System.Drawing.Font("Leelawadee", 9F, System.Drawing.FontStyle.Bold);
            this.LbOrders.Location = new System.Drawing.Point(23, 8);
            this.LbOrders.Name = "LbOrders";
            this.LbOrders.Size = new System.Drawing.Size(97, 21);
            this.LbOrders.TabIndex = 5;
            this.LbOrders.Text = "All Orders";
            this.LbOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGVOrders
            // 
            this.DGVOrders.AllowUserToAddRows = false;
            this.DGVOrders.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGVOrders.BackgroundColor = System.Drawing.Color.Gray;
            this.DGVOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(80)))), ((int)(((byte)(65)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.DGVOrders.ColumnHeadersHeight = 34;
            this.DGVOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGVOrders.EnableHeadersVisualStyles = false;
            this.DGVOrders.Location = new System.Drawing.Point(2, 40);
            this.DGVOrders.Name = "DGVOrders";
            this.DGVOrders.ReadOnly = true;
            this.DGVOrders.RowHeadersWidth = 40;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.DGVOrders.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DGVOrders.RowTemplate.Height = 28;
            this.DGVOrders.Size = new System.Drawing.Size(376, 290);
            this.DGVOrders.TabIndex = 4;
            this.DGVOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVOrders_CellClick);
            // 
            // PD1
            // 
            this.PD1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PD1_PrintPage);
            // 
            // PPD1
            // 
            this.PPD1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PPD1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PPD1.ClientSize = new System.Drawing.Size(400, 300);
            this.PPD1.Document = this.PD1;
            this.PPD1.Enabled = true;
            this.PPD1.Icon = ((System.Drawing.Icon)(resources.GetObject("PPD1.Icon")));
            this.PPD1.Name = "PPD1";
            this.PPD1.Visible = false;
            // 
            // UCOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.Controls.Add(this.Pnl3);
            this.Controls.Add(this.Pnl2);
            this.Controls.Add(this.Pnl1);
            this.Name = "UCOrders";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(900, 644);
            this.Load += new System.EventHandler(this.UCOrders_Load);
            this.Pnl1.ResumeLayout(false);
            this.Pnl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAvlProds)).EndInit();
            this.Pnl2.ResumeLayout(false);
            this.Pnl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gn2NUDQty)).EndInit();
            this.Pnl3.ResumeLayout(false);
            this.Pnl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView DGVAvlProds;
        private System.Windows.Forms.Label LbIndc;
        private System.Windows.Forms.Label LbAvlProds;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LbOrders;
        private System.Windows.Forms.DataGridView DGVOrders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button Gn2BtnClear;
        private Guna.UI2.WinForms.Guna2Button Gn2BtnInsert;
        private System.Windows.Forms.ComboBox CmbBxProd;
        private System.Windows.Forms.ComboBox CmbBxCategory;
        private System.Windows.Forms.Label LbProdPrice;
        private System.Windows.Forms.Label LbProdId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2Button Gn2BtnPay;
        private Guna.UI2.WinForms.Guna2Button Gn2BtnRemove;
        private Guna.UI2.WinForms.Guna2Button Gn2BtnReceipt;
        private Guna.UI2.WinForms.Guna2TextBox Gn2TBChange;
        private Guna.UI2.WinForms.Guna2TextBox Gn2TBAmount;
        private Guna.UI2.WinForms.Guna2TextBox Gn2TBTotalPrice;
        private System.Windows.Forms.Label LbLine;
        private Guna.UI2.WinForms.Guna2NumericUpDown Gn2NUDQty;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Panel Pnl1;
        public System.Windows.Forms.Panel Pnl2;
        public System.Windows.Forms.Panel Pnl3;
        private System.Drawing.Printing.PrintDocument PD1;
        private System.Windows.Forms.PrintPreviewDialog PPD1;
    }
}
