using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_BOTTOM_COCKPIT_V2 : Form
    {
        public SMT_SCADA_BOTTOM_COCKPIT_V2()
        {
            InitializeComponent();
        }
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrTime.Stop();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                tmrTime.Start();
            }
        }
    }
}
