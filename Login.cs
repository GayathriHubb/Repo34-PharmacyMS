using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace PharmacyMS
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void Gn2BtnSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBUsNm.Text) || string.IsNullOrEmpty(Gn2TBPswrd.Text) || CmbBxRole.SelectedIndex == -1)
            {
                MessageBox.Show("Pls Select Role and Fill All the Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return; 
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        string seldata = "Select Count(*) From Users Where Username = @un AND Password = @pswrd AND Role = @role";

                        using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                        {
                            selcmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());
                            selcmd.Parameters.AddWithValue("@pswrd", Gn2TBPswrd.Text.Trim());
                            selcmd.Parameters.AddWithValue("@role", CmbBxRole.Text.Trim());
                            int rc = 0;
                            object result = selcmd.ExecuteScalar();
                            if (result != DBNull.Value)
                            {
                                rc = (int)result;
                            }

                            if (rc > 0)
                            {
                                MessageBox.Show("Login Successfull", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                                PharmacyData.Username = Gn2TBUsNm.Text.Trim();
                                
                                if (CmbBxRole.Text == "Admin")
                                {
                                    FormAdminMain admmn = new FormAdminMain();
                                    admmn.Show();
                                    Hide();
                                }
                                if (CmbBxRole.Text == "Staff")
                                {
                                    FormStaffMain stfmn = new FormStaffMain();
                                    stfmn.Show();
                                    Hide();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Incorrect Credentials/Role", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "Login");
                    }

                }
            }
        }

        private void Gn2BtnClear_Click(object sender, EventArgs e)
        {
            Gn2TBUsNm.Clear();
            Gn2TBPswrd.Clear();
            CmbBxRole.SelectedIndex = -1;
        }

        private void Gn2BtnReg_Click(object sender, EventArgs e)
        {
            FormRegister frmreg = new FormRegister();
            frmreg.Show();
            Hide();
        }

        private void ChkBxPswrd_CheckedChanged(object sender, EventArgs e)
        {
            Gn2TBPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
        }

        private void Gn2BtnFP_Click(object sender, EventArgs e)
        {
            FormForgotPswrd frgtpswrd = new FormForgotPswrd();
            Hide();
            frgtpswrd.ShowDialog();
            Show();
        }
    }
}
