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
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();
        }

        readonly string constring = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CSharp\WinFormsNetFmwk1\PharmacyMS\Pharmacy.mdf;Integrated Security = True";

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                try
                {
                    TotalCashiersCount();
                    TotalOrdersCount();
                    TodayRevenue();
                    TotalRevenue();
                    DispDGVCustms();
        
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "CustmsLoad");
                }
            }
        }

        public void TotalCashiersCount()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Count(Id) From Users Where Role = @role";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@role", "Staff");
                        object res = selcmd.ExecuteScalar();
                        if (res != DBNull.Value)
                        {
                            LbTotCashiers.Text = Convert.ToInt32(res).ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message, "TotCashiers");
                }
            }
        }

        public void TotalOrdersCount()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Count(Id) From Transactions";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        object res = selcmd.ExecuteScalar();
                        if (res != DBNull.Value)
                        {
                            LbTotOrds.Text = Convert.ToInt32(res).ToString();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message, "TotTransc");
                }
            }
        }

        public void TodayRevenue()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select SUM(TotalPrice) From Transactions Where DateTransc = @dttrns";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        selcmd.Parameters.AddWithValue("@dttrns", DateTime.Today);
                        object res = selcmd.ExecuteScalar();
                        if (res != DBNull.Value)
                        {
                            LbTodRev.Text = (Convert.ToSingle(res)).ToString("C2");
                        }
                    }
                       
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "TodRev");
                }
            }
        }

        public void TotalRevenue()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select SUM(TotalPrice) From Transactions";
                    using (SqlCommand selcmd = new SqlCommand(seldata, sqlcon))
                    {
                        object res = selcmd.ExecuteScalar();
                        if (res != DBNull.Value)
                        {
                            LbTotRev.Text = (Convert.ToSingle(res)).ToString("C2");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message, "TotRev");
                }
            }
        }

        public void DispDGVCustms()
        {
            using (SqlConnection sqlcon = new SqlConnection(constring))
            {
                try
                {
                    sqlcon.Open();

                    string seldata = "Select Id, CustId, TotalPrice, Amount, Change, DateTransc From Transactions";
                    using (SqlCommand selcmd = new SqlCommand (seldata, sqlcon))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(selcmd);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        DGVDashboard.DataSource = dt;
                    }
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex.Message, "DispCutms");
                }
            }
        }

        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }
            TotalCashiersCount();
            TotalOrdersCount();
            TodayRevenue();
            TotalRevenue();
            DispDGVCustms();
        }


    }
}
