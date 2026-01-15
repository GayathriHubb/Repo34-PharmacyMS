using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;

namespace PharmacyMS
{
    public partial class UCCategories : UserControl
    {
        public UCCategories()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void UCCategories_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DispDGVCategories();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "CatsLoad");
                }
            }
        }

        private void Gn2BtnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBCatId.Text) || string.IsNullOrEmpty(Gn2TBCat.Text) || CmbBxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Pls Fill All Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        string chkcatid = "Select Count(Id) From Categories Where CategoryId = @catid";
                        using (SqlCommand chkcmd = new SqlCommand(chkcatid, sqlcon))
                        {
                            chkcmd.Parameters.AddWithValue("@catid", Gn2TBCatId.Text.Trim());
                            int rc = 0;
                            object result = chkcmd.ExecuteScalar(); 
                            if (result != DBNull.Value)
                            {
                                rc = (int)result;   
                            }

                            if (rc != 0)
                            {
                                MessageBox.Show($"CategoryId: {Gn2TBCatId.Text.Trim()} is Existing Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }

                            else
                            {
                                string insdata = "Insert Into Categories (CategoryId, Category, Status, DateInsert) Values (@catid, @cat, @st, @dtins)";

                                using (SqlCommand inscmd =  new SqlCommand(insdata, sqlcon))
                                {
                                    inscmd.Parameters.AddWithValue("@catid", Gn2TBCatId.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@cat", Gn2TBCat.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@st", CmbBxStatus.Text);
                                    inscmd.Parameters.AddWithValue("@dtins", DateTime.Today);

                                    inscmd.ExecuteNonQuery();
                                    DispDGVCategories();
                                    MessageBox.Show("Category Record Inserted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    ClearFields();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "CatsInsert");
                    }
                    
                }
            }
        }

        private void Gn2BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBCatId.Text) || string.IsNullOrEmpty(Gn2TBCat.Text) || CmbBxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Pls Fill All Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show($"Are you Sure to Update Id: {id} ?", "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        string chkcatid = "Select Count(Id) From Categories Where CategoryId = @catid";
                        using (SqlCommand chkcmd = new SqlCommand(chkcatid, sqlcon))
                        {
                            chkcmd.Parameters.AddWithValue("@catid", Gn2TBCatId.Text.Trim());
                            int rc = 0;
                            object result = chkcmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rc = (int)result;
                            }

                            if (rc >= 2)
                            {
                                MessageBox.Show($"CategoryId: {Gn2TBCatId.Text.Trim()} is Existing Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }

                            else
                            {
                                string upddata = "Update Categories Set CategoryId = @catid, Category = @cat, Status = @st, DateUpdate = @dtupd Where Id = @id";

                                using (SqlCommand updcmd = new SqlCommand(upddata, sqlcon))
                                {
                                    updcmd.Parameters.AddWithValue("@catid", Gn2TBCatId.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@cat", Gn2TBCat.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@st", CmbBxStatus.Text);
                                    updcmd.Parameters.AddWithValue("@dtupd", DateTime.Today);
                                    updcmd.Parameters.AddWithValue("@id", id);

                                    updcmd.ExecuteNonQuery();
                                    DispDGVCategories();
                                    MessageBox.Show("Category Record Updated Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    ClearFields();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "CatsUpdate");
                    }

                }

            }
        }

        private void Gn2BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBCatId.Text) || id == 0)
            {
                MessageBox.Show("Pls Select Record First", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Are you Sure to Delete Id: {id} ?", "Delete Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        try
                        {
                            sqlcon.Open();

                            string deldata = "Delete From Categories Where Id = @id";
                            using (SqlCommand delcmd = new SqlCommand(deldata, sqlcon))
                            {
                                delcmd.Parameters.AddWithValue("@id", id);   

                                delcmd.ExecuteNonQuery();
                                MessageBox.Show("Category Record Deleted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                ClearFields();
                            }
                        }
                        catch (SqlException ex)
                        {
                            Debug.WriteLine(ex.Message, "CatsDelete");
                        }
                    }
                }
            }
        }

        private void Gn2BtnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        int id;
        private void DGVCats_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = DGVCats.Rows[e.RowIndex];

                    id = (int) row.Cells[0].Value;  
                    Gn2TBCatId.Text = (string)row.Cells[1].Value;
                    Gn2TBCat.Text = (string)row.Cells[2].Value;
                    CmbBxStatus.Text = (string)row.Cells[3].Value;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "DGVCats");
            }
            
        }

        private void DispDGVCategories()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select * From Categories";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        DGVCats.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispCats");
                }
            }
        }

        private void ClearFields()
        {
            Gn2TBCatId.Clear(); 
            Gn2TBCat.Clear();
            CmbBxStatus.SelectedIndex = -1;
        }

        public void RefreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            DispDGVCategories();
        }
    }
}
