using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PharmacyMS
{
    public partial class FormStaffMain : Form
    {
        public FormStaffMain()
        {
            InitializeComponent();
        }

        private void FormStaffMain_Load(object sender, EventArgs e)
        {
            string un = PharmacyData.Username;
            LbUser.Text = $"{un.Substring(0, 1).ToUpper()}{un.Substring(1)}";

            Gn2BtnDashboard.FillColor = Color.LightSalmon;

            UCDashboard1.Show();
            UCProducts1.Hide();
            UCOrders1.Hide();
            UCCustomers1.Hide();

        }

        private void FormStaffMain_FormClosing(object sender, FormClosingEventArgs e)
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

            foreach (Guna2Button b in Pnl1.Controls.OfType<Guna2Button>())
            {
                if ((string)b.Tag == "MainBtns")
                {
                    b.FillColor = Color.FromArgb(212, 195, 190);
                }
                btn.FillColor = Color.LightSalmon;
            }

            int targety = btn.Location.Y + (btn.Height - LbIndc.Height) / 2;
            int step = 15;

            while (LbIndc.Location.Y != targety)
            {
                int direction = (LbIndc.Location.Y < targety) ? step : -step;
                int newy = LbIndc.Location.Y + direction;

                if (direction > 0 && newy > targety || direction < 0 && newy < targety)
                {
                    newy = targety;
                }

                LbIndc.BringToFront();
                LbIndc.Location = new Point(LbIndc.Location.X, newy);

                Thread.Sleep(1);
            }

            switch (btn.Name)
            {
                case "Gn2BtnDashboard":
                    UCDashboard1.Show();
                    UCProducts1.Hide();
                    UCOrders1.Hide();
                    UCCustomers1.Hide();

                    UCDashboard ucdshbrd = UCDashboard1 as UCDashboard;
                    ucdshbrd?.RefreshData();

                    break;
                case "Gn2BtnProds":
                    UCDashboard1.Hide();
                    UCProducts1.Show();
                    UCOrders1.Hide();
                    UCCustomers1.Hide();

                    UCProducts1.Gn2BtnInsert.Enabled = UCProducts1.Gn2BtnUpdate.Enabled = UCProducts1.Gn2BtnDelete.Enabled = false;   

                    UCProducts ucprds = UCProducts1 as UCProducts;
                    ucprds?.RefreshData();
                    break;
                case "Gn2BtnOrders":
                    UCDashboard1.Hide();
                    UCProducts1.Hide();
                    UCOrders1.Show();
                    UCCustomers1.Hide();

                    UCOrders ucords = UCOrders1 as UCOrders;
                    ucords?.RefreshData();

                    break;
                case "Gn2BtnCustms":
                    UCDashboard1.Hide();
                    UCProducts1.Hide();
                    UCOrders1.Hide();
                    UCCustomers1.Show();

                    UCCustomers uccstms = UCCustomers1 as UCCustomers;
                    uccstms?.RefreshData();

                    break;
                default: break;
            }

        }

        private void CMSLighColors_Click(object sender, EventArgs e)
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
                    UCProducts1.Pnl1.BackColor = c1;
                    UCProducts1.Pnl2.BackColor = c1;
                    UCOrders1.Pnl1.BackColor = c1;
                    UCOrders1.Pnl2.BackColor = c1;
                    UCOrders1.Pnl3.BackColor = c1;
                    break;
                case "LightBlue":
                    Pnl1.BackColor = c2;
                    UCDashboard1.Pnl1.BackColor = c2;
                    UCDashboard1.Pnl2.BackColor = c2; 
                    UCProducts1.Pnl1.BackColor = c2;
                    UCProducts1.Pnl2.BackColor = c2;
                    UCOrders1.Pnl1.BackColor = c2;
                    UCOrders1.Pnl2.BackColor = c2;
                    UCOrders1.Pnl3.BackColor = c2;
                    break;
                case "Beige":
                    Pnl1.BackColor = c3;
                    UCDashboard1.Pnl1.BackColor = c3;
                    UCDashboard1.Pnl2.BackColor = c3;
                    UCProducts1.Pnl1.BackColor = c3;
                    UCProducts1.Pnl2.BackColor = c3;
                    UCOrders1.Pnl1.BackColor = c3;
                    UCOrders1.Pnl2.BackColor = c3;
                    UCOrders1.Pnl3.BackColor = c3;
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
                    UCProducts1.Pnl1.BackColor = c1;
                    UCProducts1.Pnl2.BackColor = c1;
                    UCOrders1.Pnl1.BackColor = c1;
                    UCOrders1.Pnl2.BackColor = c1;
                    UCOrders1.Pnl3.BackColor = c1;
                    break;
                case "DarkBlue":
                    Pnl1.BackColor = c2;
                    UCDashboard1.Pnl1.BackColor = c2;
                    UCDashboard1.Pnl2.BackColor = c2;
                    UCProducts1.Pnl1.BackColor = c2;
                    UCProducts1.Pnl2.BackColor = c2;
                    UCOrders1.Pnl1.BackColor = c2;
                    UCOrders1.Pnl2.BackColor = c2;
                    UCOrders1.Pnl3.BackColor = c2;
                    break;
                case "DarkOrange":
                    Pnl1.BackColor = c3;
                    UCDashboard1.Pnl1.BackColor = c3;
                    UCDashboard1.Pnl2.BackColor = c3;
                    UCProducts1.Pnl1.BackColor = c3;
                    UCProducts1.Pnl2.BackColor = c3;
                    UCOrders1.Pnl1.BackColor = c3;
                    UCOrders1.Pnl2.BackColor = c3;
                    UCOrders1.Pnl3.BackColor = c3;
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
            UCProducts1.Pnl1.BackColor = c;
            UCProducts1.Pnl2.BackColor = c;
            UCOrders1.Pnl1.BackColor = c;
            UCOrders1.Pnl2.BackColor = c;
            UCOrders1.Pnl3.BackColor = c;

            foreach (Label lb in Pnl1.Controls.OfType<Label>())
            {
                if ((string)lb.Tag == "Labels")
                {
                    lb.ForeColor = Color.Honeydew;
                }
            }
        }
    }
}
