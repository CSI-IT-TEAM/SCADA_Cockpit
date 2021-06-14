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
    public partial class SMT_SCADA_B2IPZONE_TEMPER : Form
    {
        public SMT_SCADA_B2IPZONE_TEMPER()
        {
            InitializeComponent();
        }
        #region Variable
        int cCount = 0;
        const int ReloadTime = 60;
        #endregion
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
              
            }
        }
    }
}
