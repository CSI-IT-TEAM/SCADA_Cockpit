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
    public partial class SMT_SCADA_BOTTOM_OS_TEMPER_V2 : Form
    {
        public SMT_SCADA_BOTTOM_OS_TEMPER_V2()
        {
            InitializeComponent();
        }
        #region Variable
        int cCount = 0;

        #endregion
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";

        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount == 180)
            {
                cCount = 0;
                //Doing Something?????
            }
        }
    }
}
