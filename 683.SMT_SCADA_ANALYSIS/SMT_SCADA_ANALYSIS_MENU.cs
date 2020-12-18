using DevExpress.Skins;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_ANALYSIS_MENU : Form
    {
        public SMT_SCADA_ANALYSIS_MENU()
        {
            InitializeComponent();
            lblHeader.Text = _strHeader;
        }
        private readonly string _strHeader = "      Analysis Data      ";
        int _time = 0;
        
        DataTable _dtChart = null;

        #region Procedure( Name is begin with Po_)

        #endregion

        #region Function( Name is begin with Fn_)

        #endregion Function

        #region Get Data From Database
        
        #endregion DB

        #region Event
        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _time = 29;
                
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= 30)
            {
                _time = 0;

            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            
        }




        #endregion

        private void cmdMachine_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "683";
        }

        private void Cmd_MouseHover(object sender, EventArgs e)
        {
            Button cmd = ((Button)sender);
            cmd.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        private void cmdFems_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "682";
        }
    }
}
