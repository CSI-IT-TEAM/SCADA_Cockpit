using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_BOTTOM_HISTORY : Form
    {
        public SMT_SCADA_BOTTOM_HISTORY()
        {
            InitializeComponent();
        }

        int _time = 0;
        bool isFirstTime = true;
        DataTable dtData = null;
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrTime.Stop();
        }

        


        private void SMT_SCADA_BOTTOM_COCKPIT_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
           
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= 25)
            {
                _time = 0;
                LoadingData();
            }
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (isFirstTime)
                {
                    isFirstTime = false;
                    _time = 25;
                }
                else
                    _time = 0;
                tmrTime.Start();
            }
            else
                tmrTime.Stop();
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Loading Data
        private void LoadingData()
        {
            try
            {
                dtData = GetData("Q", "OS", "001", "BANB");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DataBase
        public DataTable GetData(string argType, string argOP_CD, string argMC, string argROLL_OP_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            MyOraDB.ShowErr = true;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT_01.SMT_SCADA_BOTTOM_HISTORY";

                MyOraDB.ReDim_Parameter(5);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_OP_CD";
                MyOraDB.Parameter_Name[2] = "V_P_MC_ID";
                MyOraDB.Parameter_Name[3] = "V_P_ROLL_OP_CD";
                MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argType;
                MyOraDB.Parameter_Values[1] = argOP_CD;
                MyOraDB.Parameter_Values[2] = argMC;
                MyOraDB.Parameter_Values[3] = argROLL_OP_CD;
                MyOraDB.Parameter_Values[4] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        #endregion
    }
}
