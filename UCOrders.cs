using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PharmacyMS
{
    public partial class UCOrders : UserControl
    {
        public UCOrders()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void UCOrders_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DispDGVAvlProds();
                    DispDGVOrders();
                    DispAvlCategoriesinCB();
                    TotalPrice();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ProdsLoad");
                }
            }
        }

        private void CmbBxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBxProd.Items.Clear();
            CmbBxProd.Text = string.Empty;
            LbProdId.Text = "----------";
            LbProdPrice.Text = "----------";
            string selcat = CmbBxCategory.Text;

            if (selcat != null)
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();
                        string seldata = $"Select * From Products Where Category = '{selcat}' AND DateDelete is NULL";
                        using (SqlCommand selcmd =  new SqlCommand(seldata, sqlcon))
                        {
                            SqlDataReader sdr = selcmd.ExecuteReader();
                            while (sdr.Read())
                            {
                                string pdname = (string)sdr["PdName"];
                                CmbBxProd.Items.Add(pdname);
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex.Message, "CmbBxCat");
                    }
                }
            }
        }

        private void CmbBxProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            LbProdId.Text = "----------";
            LbProdPrice.Text = "----------";
            string selprod = CmbBxProd.Text;

            if (selprod != null)
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();
                        string seldata = $"Select * From Products Where PdName = '{selprod}' AND DateDelete is NULL";
                        using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                        {
                            SqlDataReader sdr = selcmd.ExecuteReader();
                            if (sdr.Read())
                            {
                                string pdid = (string)sdr["PdId"];
                                string price = (Convert.ToSingle(sdr["Price"])).ToString();
                                LbProdId.Text = pdid;
                                LbProdPrice.Text = price;
                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex.Message, "CmbBxProd");
                    }
                }
            }
        }

        private void Gn2BtnInsert_Click(object sender, EventArgs e)
        {
            if (CmbBxCategory.SelectedIndex == -1 || CmbBxProd.SelectedIndex == -1 || string.IsNullOrEmpty(LbProdId.Text) || string.IsNullOrEmpty(LbProdPrice.Text) || Gn2NUDQty.Value == 0)
            {
                MessageBox.Show("Incomplete Data.. Pls Fill All Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();
                        GetPrice();


                        string insdata = "Insert Into Orders (CustId, ProdId, ProdName, Category, RegularPrice, Quantity, PdTotPrice, Status, DateOrder) Values (@cstid, @pdid, @pdname, @cat, @rgprice, @qty, @ptp, @st, @dtord)";
                        using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                        {
                            float pdtotprice = getprice * (int)Gn2NUDQty.Value;

                            inscmd.Parameters.AddWithValue("@cstid", IdGenerator());
                            inscmd.Parameters.AddWithValue("@pdid", LbProdId.Text);
                            inscmd.Parameters.AddWithValue("@pdname", CmbBxProd.Text);
                            inscmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text);
                            inscmd.Parameters.AddWithValue("@rgprice", getprice.ToString("0.##"));
                            inscmd.Parameters.AddWithValue("@qty", (int)Gn2NUDQty.Value);
                            inscmd.Parameters.AddWithValue("@ptp", pdtotprice.ToString("0.##"));
                            inscmd.Parameters.AddWithValue("@st", "Pending");
                            inscmd.Parameters.AddWithValue("@dtord", DateTime.Today);

                            inscmd.ExecuteNonQuery();
                            DispDGVOrders();
                            TotalPrice();
                            
                            MessageBox.Show("Order Added Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "OrdInsert");
                    }
                }
            }
        }

        private void Gn2BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void Gn2BtnPay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBAmount.Text) || DGVOrders.RowCount == 0 || !chkamnt)
            {
                MessageBox.Show("Invalid/Incomplete Info", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            else
            {
                DialogResult dr = MessageBox.Show("Are you Sure For Paying the Orders ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        try
                        {
                            sqlcon.Open();
                            string insdata = "Insert Into Transactions (CustId, TotalPrice, Amount, Change, Status, DateTransc) Values (@cstid, @tp, @amnt, @chng, @st, @dttrns)";
                            using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                            {
                                inscmd.Parameters.AddWithValue("@cstid", IdGenerator());
                                inscmd.Parameters.AddWithValue("@tp", Gn2TBTotalPrice.Text);
                                inscmd.Parameters.AddWithValue("@amnt", Gn2TBAmount.Text);
                                inscmd.Parameters.AddWithValue("@chng", Gn2TBChange.Text);
                                inscmd.Parameters.AddWithValue("@st", "Completed");
                                inscmd.Parameters.AddWithValue("@dttrns", DateTime.Today);

                                inscmd.ExecuteNonQuery();
                            }

                            string upddata1 = "Update Orders Set Status = @st Where CustId = @cstid";
                            using (SqlCommand updcmd1 = new SqlCommand(upddata1, sqlcon))
                            {
                                updcmd1.Parameters.AddWithValue("@cstid", IdGenerator() - 1);
                                updcmd1.Parameters.AddWithValue("@st", "Completed");

                                updcmd1.ExecuteNonQuery();
                            }

                            List<string> PdIds = new List<string>();
                            List<int> PdQtys = new List<int>();
                            string seldata = "Select ProdId, Quantity From Orders Where CustId = @cstid";
                            using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                            {
                                selcmd.Parameters.AddWithValue("@cstid", IdGenerator() - 1);
                                SqlDataReader sdr = selcmd.ExecuteReader();
                                while (sdr.Read())
                                {
                                    PdIds.Add(sdr["ProdId"].ToString());
                                    PdQtys.Add((int)sdr["Quantity"]);
                                }
                                sdr.Close();
                                for (int i = 0; i < PdIds.Count; i++)
                                {
                                    string getpdid = PdIds[i];
                                    int getpdqty = PdQtys[i];
                                    string upddata2 = "Update Products Set Stock = Stock - @qty Where PdId = @pid";
                                    using (SqlCommand updcmd2 = new SqlCommand(upddata2, sqlcon))
                                    {
                                        updcmd2.Parameters.AddWithValue("@pid", getpdid);
                                        updcmd2.Parameters.AddWithValue("@qty", getpdqty);

                                        updcmd2.ExecuteNonQuery();
                                    }
                                }
                                
                            }

                            MessageBox.Show("Payment Successfull", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message, "BtnPay");
                        }
                    }
                    
                }
            }

        }

        private void Gn2BtnReceipt_Click(object sender, EventArgs e)
        {
            if(!chkamnt)
            {
                MessageBox.Show("Invalid/Incomplete Info", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                PPD1.ShowDialog();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "BtnReceipt");
            }
        }

        private void Gn2BtnRemove_Click(object sender, EventArgs e)
        {
            if (DGVOrders.RowCount == 0 || getidfrmords == 0)
            {
                MessageBox.Show("Pls Select Item First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Are you Sure To Remove Item at Id: {getidfrmords} ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        try
                        {
                            
                            sqlcon.Open();
                            string remdata = "Delete From Orders Where Id = @id";
                            using (SqlCommand selcmd = new SqlCommand(remdata, sqlcon))
                            {
                                selcmd.Parameters.AddWithValue("@id", getidfrmords);
                                selcmd.ExecuteNonQuery();
                                DispDGVOrders();
                                TotalPrice();   
                                
                                MessageBox.Show("Order Removed Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            }
                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine(ex.Message, "OrdRemove");
                        }
                    }
                }
                
            }
        }

        private void DGVAvlProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = DGVAvlProds.Rows[e.RowIndex];

                    CmbBxCategory.Text = (string)row.Cells[3].Value;
                    CmbBxProd.Text = (string)row.Cells[2].Value;
                    LbProdId.Text = (string)row.Cells[1].Value;
                    LbProdPrice.Text = (Convert.ToSingle(row.Cells[5].Value)).ToString();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "DGVAvlProds");
            }
        }

        int getidfrmords;
        private void DGVOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = DGVOrders.Rows[e.RowIndex];
                getidfrmords = (int)row.Cells[0].Value;
            }
        }

        private void DispDGVAvlProds()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Id, PdId, PdName, Category, Stock, Price, Status, ImagePath, DateInsert From Products Where DateDelete is NULL AND Status = @st";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@st", "Available");
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        DGVAvlProds.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispProds");
                }
            }
        }

        private void DispAvlCategoriesinCB()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    CmbBxCategory.Items.Clear();
                    sqlcon.Open();

                    string seldata = "Select Distinct Category From Categories Where Status = @st";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@st", "Available");
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                string category = (string)sdr["Category"];
                                CmbBxCategory.Items.Add(category);
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispCats");
                }
            }
        }


        public int IdGenerator()
        {
            int custid = 1;
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();
                    string seldata = "Select Count(Id) From Transactions";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        object result = selcmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            custid = (int)result + 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "IdGen");
                }
            }
            return custid;
        }

        private void DispDGVOrders()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    int custid = 0;
                    sqlcon.Open();
                    string seldata1 = "Select Max(CustId) From Orders";
                    using (SqlCommand selcmd1 = new SqlCommand(seldata1, sqlcon))
                    {
                        object result = selcmd1.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            custid = (int)result;
                        }
                    }
                    string seldata2 = "Select * From Orders Where CustId = @cstid";
                    using (SqlCommand selcmd2 = new SqlCommand(seldata2, sqlcon))
                    {
                        selcmd2.Parameters.AddWithValue("@cstid", custid);
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd2);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        DGVOrders.DataSource = dt;
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispDGVOrds");
                }

            }
        }

        
        float getprice = 0;
        private void GetPrice()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();
                    string seldata = "Select * From Products Where PdId = @pid";
                    using (SqlCommand selcmd = new SqlCommand( seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@pid", LbProdId.Text);
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            object rawprice = sdr["Price"];
                            if (rawprice != DBNull.Value)
                            { getprice = Convert.ToSingle(sdr["Price"]); }
                        }
                        sdr.Close();

                    }
                    
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "GetPrice");
                }
            }
            
        }

        float totalprice = 0;
        private void TotalPrice()
        {

            using (SqlConnection sqlcon = new SqlConnection (constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select SUM(PdTotPrice) as TotPrice From Orders Where CustId = @cstid";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@cstid", IdGenerator());
                        SqlDataReader sdr = selcmd.ExecuteReader();
                        if (sdr.Read())
                        {
                            if (sdr["TotPrice"] != DBNull.Value)
                            { totalprice = Convert.ToSingle(sdr["TotPrice"]); }
                        }
                        Gn2TBTotalPrice.Text = $"{totalprice:0.##}";
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message, "TotPrice");

                }
            }
            
        }

        

        private void ClearFields()
        {
            CmbBxCategory.Text = string.Empty;
            CmbBxProd.Text = string.Empty;
            LbProdId.Text = "----------";
            LbProdPrice.Text = "----------";
        }

        public void RefreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DispDGVAvlProds();
            DispDGVOrders();
            DispAvlCategoriesinCB();
        }

        bool chkamnt = false;
        private void Gn2TBAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    TotalPrice();
                    float totalprice = float.Parse(Gn2TBTotalPrice.Text);
                    float amount = float.Parse(Gn2TBAmount.Text);

                    float change = amount - totalprice;
                    if (change < 0)
                    {
                        MessageBox.Show("Amount Cannot be Less than TotalPrice", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        Gn2TBAmount.Focus();
                        chkamnt = false;
                        return;
                    }
                    else
                    {
                        Gn2TBChange.Text = change.ToString("0.##");
                        chkamnt = true;
                    }

                    e.Handled = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "TxtBxKeyDown");
                    chkamnt = false;
                }
                
            }
        }

        int rowindex;
        private void PD1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            TotalPrice();

            int y = 50;
            int left = 50;
            int colwidth = 160;

            Font headerfont = new Font("Leelawadee", 18, FontStyle.Bold);
            Font font = new Font("Arial", 12, FontStyle.Bold);
            Font smallfont = new Font("Segoe UI", 10, FontStyle.Bold);

            int centrex1 = (int)(e.PageBounds.Width - e.Graphics.MeasureString("GUNA PHARMACEUTICALS", headerfont).Width)/2;
            int centrex2 = (int)(e.PageBounds.Width - e.Graphics.MeasureString("Have a Good Day!", font).Width)/2;
            
            // ✅ Store Header
            e.Graphics.DrawString("GUNA PHARMACEUTICALS", headerfont, Brushes.Firebrick, centrex1, y);
            y += 80;

            string date = $"Date: {DateTime.Now:dd/MM/yyyy hh:mm tt}";
            int datex = (int)((e.PageBounds.Width - left) - e.Graphics.MeasureString(date, font).Width);

            // ✅ Date + Bill No
            e.Graphics.DrawString($"Bill No: {IdGenerator() - 1}", font, Brushes.Black, left, y);
            e.Graphics.DrawString(date, font, Brushes.Black, datex, y);
            y += 30;

            e.Graphics.DrawLine(Pens.Black, left, y, e.PageBounds.Width - left, y);
            y += 20;

            // ✅ Table Headers
            string[] headers = { "ProdId", "ProdName", "Category", "Quantity", "Price" };
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawString(headers[i], font, Brushes.MidnightBlue, left + (i * colwidth), y);
            }
            y += 25;

            e.Graphics.DrawLine(Pens.Black, left, y, e.PageBounds.Width - left, y);
            y += 10;

            // ✅ Table Rows
            while (rowindex < DGVOrders.Rows.Count)
            {
                DataGridViewRow row = DGVOrders.Rows[rowindex];

                e.Graphics.DrawString(row.Cells[2].Value.ToString(), smallfont, Brushes.Black, left + 0, y);

                string pname = row.Cells[3].Value.ToString();

                // Limit text width so it wraps
                int textwidth = 160;
                SizeF textsize = e.Graphics.MeasureString(pname, smallfont, textwidth);

                // Draw wrapped product name
                e.Graphics.DrawString(pname, smallfont, Brushes.Black, new RectangleF(left + 160, y, textwidth, textsize.Height));

                e.Graphics.DrawString(row.Cells[4].Value.ToString(), smallfont, Brushes.Black, left + 320, y);
                e.Graphics.DrawString(row.Cells[6].Value.ToString(), smallfont, Brushes.Black, left + 480, y);
                e.Graphics.DrawString(row.Cells[7].Value.ToString(), smallfont, Brushes.Black, left + 640, y);

                y += (int)textsize.Height > 25 ? (int)textsize.Height : 25;
                rowindex++;

                if (y > e.MarginBounds.Height)
                {
                    e.HasMorePages = true;
                    return;
                }
            }
            y += 20;
            e.Graphics.DrawLine(Pens.Black, left, y, e.PageBounds.Width - left, y);
            y += 30;

            // ✅ Summary Price Section
            DrawRightAligned(e.Graphics, "TotalPrice(₹):", $"{Gn2TBTotalPrice.Text: 0.00}", font, left, ref y);
            DrawRightAligned(e.Graphics, "TenderedCash(₹):", $"{Gn2TBAmount.Text: 0.00}", font, left, ref y);
            DrawRightAligned(e.Graphics, "TenderedChange(₹):", $"{Gn2TBChange.Text: 0.00}", font, left, ref y);

            y += 30;
            e.Graphics.DrawLine(Pens.Black, left, y, e.PageBounds.Width - left, y);
            y += 30;

            // ✅ Footer
            e.Graphics.DrawString("Have a Good Day!", font, Brushes.Black, centrex2, y);
            y += 25;
           

            e.HasMorePages = false;
        }

        private void DrawRightAligned(Graphics g, string label, string value, Font font, int left, ref int y)
        {
            g.DrawString(label, font, Brushes.MidnightBlue, left + 300, y);
            g.DrawString(value, font, Brushes.Black, left + 520, y);
            y += 25;
        }

        
    }
}
