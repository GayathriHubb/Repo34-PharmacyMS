using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyMS
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Pnl2.Width += 5;

            if (Pnl2.Width >= Pnl1.Width)
            {
                Timer1.Stop();

                FormLogin frmlgn = new FormLogin();
                frmlgn.Show();
                Hide();
            }
        }
    }
}
 