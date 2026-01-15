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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        
        private void Gn2BtnSignUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBUsNm.Text) || string.IsNullOrEmpty(Gn2TBPswrd.Text) || string.IsNullOrEmpty(Gn2TBCnfPswrd.Text) || 
                CmbBxRole.SelectedIndex == -1 || CmbbxSecQsn.SelectedIndex == -1 || string.IsNullOrEmpty(Gn2TBSecAns.Text))
            {
                MessageBox.Show("Pls Fill All the Fields Properly", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
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

                            if (rc != 0)
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
                            if(Gn2TBPswrd.Text.Trim() != Gn2TBCnfPswrd.Text.Trim())
                            {
                                MessageBox.Show("Passwords Does not Match", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                return;
                            }
                            else
                            {
                                string insdata = "Insert Into Users (Username, Password, SecQsn, SecAns, Role, Status, DateRegister) Values (@un, @pswrd, @sq, @sa, @role, @st, @dtreg)";
                                using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                                {
                                    inscmd.Parameters.AddWithValue("un", Gn2TBUsNm.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@pswrd", Gn2TBPswrd.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@sq", CmbbxSecQsn.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@sa", Gn2TBSecAns.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@role", CmbBxRole.Text.Trim());
                                    inscmd.Parameters.AddWithValue("@st", "Active");
                                    inscmd.Parameters.AddWithValue("@dtreg", DateTime.Now);

                                    inscmd.ExecuteNonQuery();

                                    MessageBox.Show("Registration Successfull", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                    FormLogin frmlgn = new FormLogin();
                                    frmlgn.Show();
                                    Hide();
                                    
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message, "SignUp");
                    }
                }
            }
        }

        private void Gn2BtnClear_Click(object sender, EventArgs e)
        {
            Gn2TBUsNm.Clear();
            Gn2TBPswrd.Clear();
            Gn2TBCnfPswrd.Clear();
            CmbBxRole.SelectedIndex = -1;
            CmbbxSecQsn.SelectedIndex = -1;
            Gn2TBSecAns.Clear();

        }

        private void Gn2BtnSignIn_Click(object sender, EventArgs e)
        {
            FormLogin frmlgn = new FormLogin();
            frmlgn.Show();
            Hide();
        }

        private void ChkBPswrd_CheckedChanged(object sender, EventArgs e)
        {
            Gn2TBPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
            Gn2TBCnfPswrd.UseSystemPasswordChar = !ChkBxPswrd.Checked;
        }
    }
}
