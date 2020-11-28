using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_POPUP_INFOR : Form
    {
        public SMT_SCADA_POPUP_INFOR()
        {
            InitializeComponent();
        }

        string _machine = "", _type = "";
        int iCount = 0;
        
        #region Function
        private void SetData()
        {
            try
            {
                DataSet ds = Data_Select();               
                Grid.DataSource = ds.Tables[0];
                SetText(ds.Tables[1]);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void SetText(DataTable argTable)
        {
            try
            {
                lblTxt1.Text = argTable.Rows[0]["TXT1"].ToString();
                lblTxt2.Text = argTable.Rows[0]["TXT2"].ToString();
                lblTxt3.Text = argTable.Rows[0]["TXT3"].ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private DevExpress.XtraGrid.GridControl Grid
        {
            get
            {
                switch (_type)
                {
                    case "REPAIR":
                        return gridRepair;
                    case "PM":
                        return gridPM;
                    case "MOVE":
                        return gridMove;
                    default:
                        return null;
                }
            }
        }

        private void GetMachine()
        {
            try
            {
               // StreamReader sr = new StreamReader(ComVar.Var._strValue5);
                _machine = System.IO.File.ReadAllText(ComVar.Var._strValue5); 
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            
        }



        #endregion

        #region DB
        private DataSet Data_Select()
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ShowErr = true;

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.P_SCADA_MACHINE_INFOR";

            MyOraDB.Parameter_Name[0] = "ARG_TYPE";
            MyOraDB.Parameter_Name[1] = "ARG_MACHINE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = _type;
            MyOraDB.Parameter_Values[1] = _machine;
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
        }


        #endregion DB

        #region Event

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible)
                {
                    iCount = 58;
                    tabControl.SelectedTabPageIndex = 0;
                    _machine = System.IO.File.ReadAllText(ComVar.Var._strValue5);
                    timer1.Start();
                }
                else
                {
                    timer1.Stop();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                iCount++;
                if (iCount == 60)
                {
                    iCount = 0;
                    SetData();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }



        #endregion

        private void SMT_SCADA_POPUP_INFOR_Load(object sender, EventArgs e)
        {

        }

        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            _type = tabControl.SelectedTabPage.Name;
            SetData();
            iCount = 0;
        }
    }

 




}
