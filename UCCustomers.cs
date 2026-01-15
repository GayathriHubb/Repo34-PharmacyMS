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

namespace PharmacyMS
{
    public partial class UCCustomers : UserControl
    {
        public UCCustomers()
        {
            InitializeComponent();
        }
        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void UCCustomers_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    DispDGVCustms();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "CustmsLoad");
                }
            }
        }

        private void DispDGVCustms()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();
                    string seldata = "Select Id, CustId, TotalPrice, Amount, Change, Status, DateTransc From Transactions";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

                        DGVCustms.DataSource = dt;  
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message, "DGVCustms");
                }
            }
        }

        public void RefreshData()
        {
            if(InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            DispDGVCustms();
        }
    }
}
