using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class FormAdminMain : Form
    {
        public FormAdminMain()
        {
            InitializeComponent();
        }

        private void FormAdminMain_Load(object sender, EventArgs e)
        {
            string un = PharmacyData.Username;
            LbUser.Text = $"{un.Substring(0, 1).ToUpper()}{un.Substring(1)}";

            Gn2BtnDashboard.FillColor = Color.LightSalmon;

            UCDashboard1.Show();
            UCStaff1.Hide();
            UCCategories1.Hide();
            UCProducts1.Hide();
            UCCustomers1.Hide();

        }

        private void FormAdminMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you Sure to Quit ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.ExitThread();   
            }
            e.Cancel = true;
        }
       
        private void Gn2BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you Sure to Logout ?", "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                FormLogin frmlgn = new FormLogin();
                frmlgn.Show();
                Hide();
            }
        }

        private void MainBtns_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
           
            // Reset main buttons' fill colors
            foreach (Guna2Button b in Pnl1.Controls.OfType<Guna2Button>())
            {
                if ((string)b.Tag == "MainBtns")
                {
                    b.FillColor = Color.FromArgb(212, 195, 190);
                }
                // Highlight Clicked button
                btn.FillColor = Color.LightSalmon;
            }

            // Compute target Y for LbIndc relative to Pnl1 (works even if btn is inside nested containers)
            // Point btnScreen = btn.PointToScreen(Point.Empty);
            // Point btnRelative = Pnl1.PointToClient(btnScreen);

            int targety = btn.Location.Y + (btn.Height - LbIndc.Height) / 2;
            int step = 20;

            try
            {
                while (LbIndc.Location.Y != targety)
                {
                    int direction = (LbIndc.Location.Y < targety) ? step : -step;
                    int newy = LbIndc.Location.Y + direction;

                    if ((direction > 0 && newy > targety) || (direction < 0 && newy < targety))
                    {
                        newy = targety;
                    }

                    LbIndc.BringToFront();
                    LbIndc.Location = new Point(LbIndc.Location.X, newy);

                    Thread.Sleep(1);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, "LbIndc");
            }


            switch (btn.Name)
            {
                case "Gn2BtnDashboard":
                    UCDashboard1.Show();
                    UCStaff1.Hide();
                    UCCategories1.Hide();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCDashboard ucdsbrd = UCDashboard1 as UCDashboard;
                    ucdsbrd?.RefreshData();

                    break;
                case "Gn2BtnStaff":
                    UCDashboard1.Hide();
                    UCStaff1.Show();
                    UCCategories1.Hide();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCStaff ucstf = UCStaff1 as UCStaff;
                    ucstf?.RefreshData();

                    break;
                case "Gn2BtnCategories":
                    UCDashboard1.Hide();
                    UCStaff1.Hide();
                    UCCategories1.Show();
                    UCProducts1.Hide();
                    UCCustomers1.Hide();

                    UCCategories uccat = UCCategories1 as UCCategories;
                    uccat?.RefreshData();

                    break;
                case "Gn2BtnProds":
                    UCDashboard1.Hide();
                    UCStaff1.Hide();
                    UCCategories1.Hide();
                    UCProducts1.Show();
                    UCCustomers1.Hide();

                    UCProducts ucprds = UCProducts1 as UCProducts;
                    ucprds?.RefreshData();

                    break;
                case "Gn2BtnCustms":
                    UCDashboard1.Hide();
                    UCStaff1.Hide();
                    UCCategories1.Hide();
                    UCProducts1.Hide();
                    UCCustomers1.Show();

                    UCCustomers uccstms = UCCustomers1 as UCCustomers;
                    uccstms?.RefreshData();

                    break;
                default: break;
            }
        }

        private void CMSLightColors_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;
            
            Color c1 = Color.LightGray;
            Color c2 = Color.LightBlue;
            Color c3 = Color.Beige;

            switch (tsm.Text)
            {
                case "LightGray":
                    Pnl1.BackColor = c1;
                    UCDashboard1.Pnl1.BackColor = c1;
                    UCDashboard1.Pnl2.BackColor = c1;
                    UCStaff1.Pnl1.BackColor = c1;
                    UCStaff1.Pnl2.BackColor = c1;
                    UCCategories1.Pnl1.BackColor = c1;
                    UCCategories1.Pnl2.BackColor = c1;
                    UCProducts1.Pnl1.BackColor = c1;
                    UCProducts1.Pnl2.BackColor = c1;
                    UCCustomers1.Pnl1.BackColor = c1;
                    break;
                case "LightBlue":
                    Pnl1.BackColor = c2;
                    UCDashboard1.Pnl1.BackColor = c2;
                    UCDashboard1.Pnl2.BackColor = c2;
                    UCStaff1.Pnl1.BackColor = c2;
                    UCStaff1.Pnl2.BackColor = c2;
                    UCCategories1.Pnl1.BackColor = c2;
                    UCCategories1.Pnl2.BackColor = c2;
                    UCProducts1.Pnl1.BackColor = c2;
                    UCProducts1.Pnl2.BackColor = c2;
                    UCCustomers1.Pnl1.BackColor = c2;
                    break;

                case "Beige":
                    Pnl1.BackColor = c3;
                    UCDashboard1.Pnl1.BackColor = c3;
                    UCDashboard1.Pnl2.BackColor = c3;
                    UCStaff1.Pnl1.BackColor = c3;
                    UCStaff1.Pnl2.BackColor = c3;
                    UCCategories1.Pnl1.BackColor = c3;
                    UCCategories1.Pnl2.BackColor = c3;
                    UCProducts1.Pnl1.BackColor = c3;
                    UCProducts1.Pnl2.BackColor = c3;
                    UCCustomers1.Pnl1.BackColor = c3;
                    break;
            }
                    
            foreach (Label lb in Pnl1.Controls.OfType<Label>())
            {
                if ((string)lb.Tag == "Labels")
                {
                    lb.ForeColor = Color.DarkBlue;
                }
            }
        }

        private void CMSDarkColors_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsm = (ToolStripMenuItem)sender;

            Color c1 = Color.DarkGray;
            Color c2 = Color.DarkBlue;
            Color c3 = Color.DarkOrange;

            switch (tsm.Text)
            {
                case "DarkGray":
                    
                    Pnl1.BackColor = c1;
                    UCDashboard1.Pnl1.BackColor = c1;
                    UCDashboard1.Pnl2.BackColor = c1;
                    UCStaff1.Pnl1.BackColor = c1;
                    UCStaff1.Pnl2.BackColor = c1;
                    UCCategories1.Pnl1.BackColor = c1;  
                    UCCategories1.Pnl2.BackColor = c1;  
                    UCProducts1.Pnl1.BackColor = c1;
                    UCProducts1.Pnl2.BackColor = c1;
                    UCCustomers1.Pnl1.BackColor = c1;
                    break;
                case "DarkBlue":
                    Pnl1.BackColor = c2;
                    UCDashboard1.Pnl1.BackColor = c2;
                    UCDashboard1.Pnl2.BackColor = c2;
                    UCStaff1.Pnl1.BackColor = c2;
                    UCStaff1.Pnl2.BackColor = c2;
                    UCCategories1.Pnl1.BackColor = c2;
                    UCCategories1.Pnl2.BackColor = c2;
                    UCProducts1.Pnl1.BackColor = c2;
                    UCProducts1.Pnl2.BackColor = c2;
                    UCCustomers1.Pnl1.BackColor = c2;
                    break;
                case "DarkOrange":
                    Pnl1.BackColor = c3;
                    UCDashboard1.Pnl1.BackColor = c3;
                    UCDashboard1.Pnl2.BackColor = c3;
                    UCStaff1.Pnl1.BackColor = c3;
                    UCStaff1.Pnl2.BackColor = c3;
                    UCCategories1.Pnl1.BackColor = c3;
                    UCCategories1.Pnl2.BackColor = c3;
                    UCProducts1.Pnl1.BackColor = c3;
                    UCProducts1.Pnl2.BackColor = c3;
                    UCCustomers1.Pnl1.BackColor = c3;
                    break;
            }

            foreach (Label lb in Pnl1.Controls.OfType<Label>())
            {
                if ((string)lb.Tag == "Labels")
                {
                    lb.ForeColor = Color.LightCyan;
                }
            }
        }

        private void TSMReset_Click(object sender, EventArgs e)
        {
            Pnl1.BackColor = Color.FromArgb(105, 80, 65);
            Color c = Color.FromArgb(212, 195, 190);

            UCDashboard1.Pnl1.BackColor = c;
            UCDashboard1.Pnl2.BackColor = c;
            UCStaff1.Pnl1.BackColor = c;
            UCStaff1.Pnl2.BackColor = c;
            UCCategories1.Pnl1.BackColor = c;
            UCCategories1.Pnl2.BackColor = c;
            UCProducts1.Pnl1.BackColor = c;
            UCProducts1.Pnl2.BackColor = c;
            UCCustomers1.Pnl1.BackColor = c;

            foreach (Label lb in Pnl1.Controls.OfType<Label>())
            {
                if ((string)lb.Tag == "Labels")
                {
                    lb.ForeColor = Color.Honeydew;
                }
            }
        }

        // UNDONE: LbIndc Not working for BtnCustomers
    }
}
