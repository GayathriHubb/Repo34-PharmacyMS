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
    public partial class UCStaff : UserControl
    {
        public UCStaff()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void UCStaff_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DisplayDGVStaff();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "StaffLoad");
                }
            }
        }

        private void Gn2BtnInsert_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
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

                        string chkun = "Select Count(Id) From Users Where Username = @un";
                        using (SqlCommand chkcmd = new SqlCommand(chkun, sqlcon))
                        {
                            chkcmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());

                            int rc = 0;
                            object result = chkcmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rc = (int)result;
                            }

                            if (rc > 0)
                            {
                                string tempun = $"{Gn2TBUsNm.Text.Trim().Substring(0, 1).ToUpper()}{Gn2TBUsNm.Text.Trim().Substring(1)}";
                                MessageBox.Show($"Username: {tempun} is Existing Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }
                            if (Gn2TBPswrd.Text.Trim().Length < 8)
                            {
                                MessageBox.Show("Password Must be Atleast 8 characters or Up", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }

                        }
                        string insdata = "Insert Into Users (Username, Password, Role, Status, DateRegister) Values (@un, @pswrd, @role, @st, @dtreg)";

                        using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                        {
                            inscmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());
                            inscmd.Parameters.AddWithValue("@pswrd", Gn2TBPswrd.Text.Trim());
                            inscmd.Parameters.AddWithValue("@role", CmbBxRole.Text.Trim());
                            inscmd.Parameters.AddWithValue("@st", CmbBxStatus.Text.Trim());
                            inscmd.Parameters.AddWithValue("@dtreg", DateTime.Now);

                            inscmd.ExecuteNonQuery();
                            DisplayDGVStaff();
                            MessageBox.Show("User Record Inserted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            ClearFields();  
                        }
                    }
                    catch (SqlException ex)
                    {
                        Debug.WriteLine(ex.Message, "StaffInsert");
                    }
                }
            }
        }

        private void Gn2BtnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckEmptyFields())
            {
                MessageBox.Show("Pls Fill All Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult dr = MessageBox.Show($"Are you Sure to Update Id: {id} ?", "Update Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    using (SqlConnection sqlcon = new SqlConnection(constring))
                    {
                        try
                        {
                            sqlcon.Open();
                            string chkun = "Select Count(Id) From Users Where Username = @un";
                            using (SqlCommand chkcmd = new SqlCommand(chkun, sqlcon))
                            {
                                chkcmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());

                                int rc = 0;
                                object result = chkcmd.ExecuteScalar();
                                if (result != DBNull.Value)
                                {
                                    rc = (int)result;
                                }

                                if (rc >= 2)
                                {
                                    string tempun = $"{Gn2TBUsNm.Text.Trim().Substring(0, 1).ToUpper()}{Gn2TBUsNm.Text.Trim().Substring(1)}";
                                    MessageBox.Show($"Username: {tempun} is Existing Already", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    return;
                                }
                                if (Gn2TBPswrd.Text.Trim().Length < 8)
                                {
                                    MessageBox.Show("Password Must be Atleast 8 characters or Up", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    return;
                                }

                                string upddata = "Update Users Set Username = @un, Password = @pswrd, Role = @role, Status = @st Where Id = @id";
                                using (SqlCommand updcmd = new SqlCommand(upddata, sqlcon))
                                {
                                    updcmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@pswrd", Gn2TBPswrd.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@role", CmbBxRole.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@st", CmbBxStatus.Text.Trim());
                                    updcmd.Parameters.AddWithValue("@id", id);
                                    

                                    updcmd.ExecuteNonQuery();
                                    DisplayDGVStaff();
                                    MessageBox.Show("User Record Updated Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    ClearFields();
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message, "StaffUpdate");
                        }
                    }
                }
                
            }
        }

        private void Gn2BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBUsNm.Text) || id == 0)
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

                            string deldata = "Delete From Users Where Id = @id";
                            using (SqlCommand delcmd = new SqlCommand(deldata, sqlcon))
                            {
                                delcmd.Parameters.AddWithValue("@id", id);

                                delcmd.ExecuteNonQuery();
                                DisplayDGVStaff();  
                                MessageBox.Show("User Record Deleted Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                ClearFields() ; 
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message, "StaffDelete");
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
        private void DGVStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    DataGridViewRow row = DGVStaff.Rows[e.RowIndex];

                    id = (int)row.Cells[0].Value;
                    Gn2TBUsNm.Text = (string)row.Cells[1].Value;
                    Gn2TBPswrd.Text = (string)row.Cells[2].Value;
                    CmbBxRole.Text = (string)row.Cells[3].Value;
                    CmbBxStatus.Text = (string)row.Cells[4].Value;

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "DGVStaff");    
            }
            
        }

        private void DisplayDGVStaff()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Id, Username, Password, Role, Status, DateRegister From Users";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        DGVStaff.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "DispStaff");
                }
            }
        }

        private void ClearFields()
        {
            Gn2TBUsNm.Clear();
            Gn2TBPswrd.Clear();
            CmbBxRole.SelectedIndex = -1;
            CmbBxStatus.SelectedIndex = -1;
        }

        private bool CheckEmptyFields()
        {
            if (string.IsNullOrEmpty(Gn2TBUsNm.Text) || string.IsNullOrEmpty(Gn2TBPswrd.Text) || CmbBxRole.SelectedIndex == -1 || CmbBxStatus.SelectedIndex == -1)
            {
                return true;
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
            DisplayDGVStaff();
        }
    }
}
