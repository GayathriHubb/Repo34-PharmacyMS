using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PharmacyMS
{
    public partial class UCProducts : UserControl
    {
        public UCProducts()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        string targetpath;

        private void UCProducts_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DispDGVProds();
                    DisplayCategoriesinCB();
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.Message, "ProdsLoad");
                }
            }
        }

        private void Gn2BtnInsert_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Pls Fill All Fields and Select a Photo", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            if (!ValidPrice(Gn2TBPrice.Text, out float price))
            {
                MessageBox.Show("Pls Enter Valid Price", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                Gn2TBPrice.Focus();
                return;
            }
            else
            {
                string pid = Gn2TBProdId.Text.Trim().ToUpper();
                try
                {
                    string basedirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string relativepath = Path.Combine("ProdsDirectory", $"{pid}.jpg");
                    targetpath = Path.Combine(basedirectory, relativepath);

                    string directorypath = Path.GetDirectoryName(targetpath);
                    if (!Directory.Exists(directorypath))
                    {
                        Directory.CreateDirectory(directorypath);
                    }

                    if (!string.IsNullOrEmpty(PicBxProd.ImageLocation))
                    {
                        File.Copy(PicBxProd?.ImageLocation, targetpath, true);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "PicBxInsert");
                }
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();
                        string chkpid = "Select Count(Id) From Products Where PdId = @pid";
                        using (SqlCommand chkcmd = new SqlCommand(chkpid, sqlcon))
                        {
                            chkcmd.Parameters.AddWithValue("@pid", Gn2TBProdId.Text.Trim());

                            int rc = 0;
                            object result = chkcmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rc = (int)result;
                            }

                            if (rc != 0)
                            {
                                MessageBox.Show($"ProductId: {Gn2TBProdId.Text.Trim()} is Existing Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }

                            string insdata = "Insert Into Products (PdId, PdName, Category, Stock, Price, Status, ImagePath, DateInsert) Values (@pid, @pname, @cat, @stock, @price, @st, @imgpath, @dtins)";
                            using (SqlCommand inscmd =  new SqlCommand(insdata, sqlcon))
                            {
                                inscmd.Parameters.AddWithValue("@pid", pid);
                                inscmd.Parameters.AddWithValue("@pname", Gn2TBProd.Text.Trim());
                                inscmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text.Trim());
                                inscmd.Parameters.AddWithValue("@stock", (int)Gn2NUDStock.Value);
                                inscmd.Parameters.AddWithValue("@price", price.ToString("0.##"));
                                inscmd.Parameters.AddWithValue("@st", CmbBxStatus.Text.Trim());
                                inscmd.Parameters.AddWithValue("@imgpath", targetpath ?? string.Empty);
                                inscmd.Parameters.AddWithValue("@dtins", DateTime.Now);

                                inscmd.ExecuteNonQuery();
                                DispDGVProds();
                                MessageBox.Show("Product Record Inserted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                ClearFields();
                            }
                                
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ProdsInsert");
                    }
                }
            }
        }

        private void Gn2BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Pls Fill All Fields and Select a Photo", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidPrice(Gn2TBPrice.Text, out float price))
            {
                MessageBox.Show("Pls Enter Valid Price", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                Gn2TBPrice.Focus();
                return;
            }
            else
            {
                string pid = Gn2TBProdId.Text.Trim().ToUpper();
                DialogResult dr = MessageBox.Show($"Are you Sure to Update ProdId: {pid} ?", "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string basedirectory = AppDomain.CurrentDomain.BaseDirectory;
                        string relativepath = Path.Combine("ProdsDirectory", $"{pid}.jpg");
                        targetpath = Path.Combine(basedirectory, relativepath);

                        if (!string.IsNullOrEmpty(PicBxProd.ImageLocation))
                        {
                            File.Copy(PicBxProd?.ImageLocation, targetpath, true);
                        }
                        MessageBox.Show("Image Updated Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "PicBxUpdate");
                    }
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        try
                        {
                            sqlcon.Open();

                            string upddata = "Update Products Set PdName = @pname, Category = @cat, Stock = @stock, Price = @price, Status = @st, ImagePath = @imgpath, DateUpdate = @dtupd Where PdId = @pid";
                            using (SqlCommand updcmd = new SqlCommand(upddata, sqlcon))
                            {
                                updcmd.Parameters.AddWithValue("@pname", Gn2TBProd.Text.Trim());
                                updcmd.Parameters.AddWithValue("@cat", CmbBxCategory.Text.Trim());
                                updcmd.Parameters.AddWithValue("@stock", (int)Gn2NUDStock.Value);
                                updcmd.Parameters.AddWithValue("@price", price.ToString("0.##"));
                                updcmd.Parameters.AddWithValue("@st", CmbBxStatus.Text.Trim());
                                updcmd.Parameters.AddWithValue("@imgpath", targetpath ?? string.Empty);
                                updcmd.Parameters.AddWithValue("@dtupd", DateTime.Today);
                                updcmd.Parameters.AddWithValue("@pid", pid);

                                updcmd.ExecuteNonQuery();
                                DispDGVProds();
                                MessageBox.Show("Product Record Updated Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                ClearFields();
                            }
                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine(ex.Message, "ProdsUpdate");
                        }
                    }
                }
                
            }
        }

        private void Gn2BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBProdId.Text) || id == 0)
            {
                MessageBox.Show("Pls Select Record First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show($"Are you Sure to Delete Id: {id} ?", "Delete Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        string deldata = "Update Products Set DateDelete = @dtdel Where Id = @id";
                        using (SqlCommand delcmd = new SqlCommand(deldata, sqlcon))
                        {
                            delcmd.Parameters.AddWithValue("@id", id);
                            delcmd.Parameters.AddWithValue("@dtdel", DateTime.Today);

                            delcmd.ExecuteNonQuery();
                            DispDGVProds();
                            MessageBox.Show("Product Record Deleted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ProdsDelete");
                    }
                }
            }

        }

        private void Gn2BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        int id;
        private void DGVProds_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = DGVProds.Rows[e.RowIndex];

                    id = (int)row.Cells[0].Value;
                    Gn2TBProdId.Text = (string)row.Cells[1].Value;
                    Gn2TBProd.Text = (string) row.Cells[2].Value;
                    Gn2TBPrice.Text = Convert.ToSingle(row.Cells[5].Value).ToString();
                    CmbBxCategory.Text = (string)row.Cells[3].Value;
                    CmbBxStatus.Text = (string)row.Cells[6].Value;
                    Gn2NUDStock.Value = (int)row.Cells[4].Value;

                    string imgpath = (string)row.Cells[7].Value;

                    if (File.Exists(imgpath))
                    {
                        PicBxProd.ImageLocation = imgpath;
                    }
                    PicBxProd.Image = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "DGVProds");
            }
            
        }

        private void DispDGVProds()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Id, PdId, PdName, Category, Stock, Price, Status, ImagePath, DateInsert, DateUpdate From Products Where DateDelete is NULL";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        DGVProds.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispProds");
                }
            }
        }

        private void DisplayCategoriesinCB()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    CmbBxCategory.Items.Clear();
                    sqlcon.Open();

                    string seldata = "Select Distinct Category From Categories";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
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

        private bool CheckEmptyFields()
        {
            if (string.IsNullOrEmpty(Gn2TBProdId.Text) || string.IsNullOrEmpty(Gn2TBProd.Text) || string.IsNullOrEmpty(Gn2TBPrice.Text) ||
               CmbBxCategory.SelectedIndex == -1 || CmbBxStatus.SelectedIndex == -1 || Gn2NUDStock.Value == 0 || PicBxProd.Image == null)
            {
                return true; 
            }
            return false;
        }

        private void ClearFields()
        {
            Gn2TBProdId.Clear();
            Gn2TBProd.Clear();
            Gn2TBPrice.Clear();
            CmbBxCategory.SelectedIndex = -1;
            CmbBxStatus.SelectedIndex = -1;
            Gn2NUDStock.Value = 0;
            PicBxProd.Image = null; 
        }

        private bool ValidPrice(string pricetext, out float price)
        {
            if (float.TryParse(pricetext, out price))
            {
                if (price >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void RefreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DispDGVProds();
            DisplayCategoriesinCB();
        }

        private void Gn2BtnImage_Click(object sender, EventArgs e)
        {
            string imgpath = string.Empty;

            try
            {
                if (Ofd1.ShowDialog() == DialogResult.OK)
                {
                    imgpath = Ofd1.FileName;
                    PicBxProd.ImageLocation = imgpath;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "BtnImage");
            }
            
        }

        private void Gn2BtnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
