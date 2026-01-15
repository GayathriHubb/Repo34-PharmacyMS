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
    public partial class FormChangePswrd : Form
    {
        public FormChangePswrd()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void Gn2BtnChange_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Gn2TBPswrd.Text) || string.IsNullOrEmpty(Gn2TBCnfPswrd.Text))
            {
                MessageBox.Show("Pls Fill the Fields Properly", "Warning", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                return; 
            }
            if (Gn2TBPswrd.Text.Trim().Length < 8)
            {
                MessageBox.Show("Password Must be Atleast 8 characters or Up", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            if (Gn2TBPswrd.Text.Trim() != Gn2TBCnfPswrd.Text.Trim())
            {
                MessageBox.Show("Passwords Does not Match", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                using (SqlConnection sqlcon = new SqlConnection(constring))
                {
                    try
                    {
                        sqlcon.Open();

                        string insdata = "Insert Into Users (Username, Password, DateLastPswrdChange) Values (@un, @pswrd, @dtlst)";

                        using (SqlCommand inscmd = new SqlCommand(insdata, sqlcon))
                        {
                            inscmd.Parameters.AddWithValue("@un", PharmacyData.Username);
                            inscmd.Parameters.AddWithValue("@pswrd", Gn2TBPswrd.Text.Trim());
                            inscmd.Parameters.AddWithValue("@dtlst", DateTime.Today);

                            inscmd.ExecuteNonQuery();
                            MessageBox.Show("Password Changed Successfully", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            FormLogin frmlgn = new FormLogin();
                            frmlgn.Show();
                            Hide();
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message, "ChangePassword");
                    }

                }
            }
        }

        private void Gn2BtnBack_Click(object sender, EventArgs e)
        {
            FormForgotPswrd frgtpswrd = new FormForgotPswrd();
            frgtpswrd.ShowDialog(); 
        }
    }
}
