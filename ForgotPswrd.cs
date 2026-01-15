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
    public partial class FormForgotPswrd : Form
    {
        public FormForgotPswrd()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void Gn2BtnConfirm_Click(object sender, EventArgs e)
        {
            PharmacyData.Username = Gn2TBUsNm.Text.Trim();

            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Count(Id) From Users Where Username = @un AND SecQsn = @sq AND SecAns = @sa";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@un", Gn2TBUsNm.Text.Trim());
                        selcmd.Parameters.AddWithValue("@sq", CmbBxSecQsn.Text.Trim());
                        selcmd.Parameters.AddWithValue("@sa", Gn2TBSecAns.Text.Trim());

                        int rc = 0;
                        object result = selcmd.ExecuteScalar(); 
                        if (result != DBNull.Value)
                        {
                            rc = (int)result;   
                        }

                        if (rc > 0)
                        {
                            FormChangePswrd chngpswrd = new FormChangePswrd();
                            chngpswrd.ShowDialog();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Info", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "ForgotPassord");
                }
            }


        }

        private void Gn2BtnBack_Click(object sender, EventArgs e)
        {
            FormLogin frmlgn = new FormLogin();
            frmlgn.Show();
        }
    }
}
