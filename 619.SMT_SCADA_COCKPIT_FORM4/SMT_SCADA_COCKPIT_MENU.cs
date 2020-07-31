using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using System.Data.OleDb;
//using JPlatform.Client.Controls;


namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_MENU : Form
    {
        public SMT_SCADA_COCKPIT_MENU()
        {            
            InitializeComponent();
            initForm();
        }

        Dictionary<string, UC.UC_Machine> _dicLocation = new Dictionary<string, UC.UC_Machine>();

        private void SMT_SCADA_COCKPIT_MENU_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                tmrTime.Start();

            }
            else
            {
                tmrTime.Stop();
            }
        }


        #region Init Form

        private void initForm()
        {
            try
            {
                //this.circularGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();

                //pic1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\VC.jpg");
                //pic2.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\LT.png");
                //pic3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\TP.jpg");


                //cmdVJ1.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\Button_VC.png");
                //cmdVJ2.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\Button_LT.png");
                //cmdVJ3.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\Button_TP.png");

                /*
                string[] F1 = { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5", "Line 6" };
                string[] F2 = { "Plant A", "Plant B", "Plant C", "Plant D" };
                string[] F3 = { "Plant E", "Plant F", "Plant N" };
                string[] F4 = { "Plant G", "Plant H", "Plant I", "Plant J", "Plant K" };
                string[] F5 = { "Plant L1", "Plant L2", "Plant M1", "Plant M2" };

                addMachine(tblF1Nosew, Var.Area.Nosew, F1);
                addMachine(tblF2Nosew, Var.Area.Nosew, F2);
                addMachine(tblF3Nosew, Var.Area.Nosew, F3);
                addMachine(tblF4Nosew, Var.Area.Nosew, F4);
                addMachine(tblF5Nosew, Var.Area.Nosew, F5);

                addMachine(tblF1Fss, Var.Area.Stockfit, F1);
                addMachine(tblF2Fss, Var.Area.Stockfit, F2);
                addMachine(tblF3Fss, Var.Area.Stockfit, F3);
                addMachine(tblF4Fss, Var.Area.Stockfit, F4);
                addMachine(tblF5Fss, Var.Area.Stockfit, F5);

                addMachine(tblF1Ass, Var.Area.Assembly, F1);
                addMachine(tblF2Ass, Var.Area.Assembly, F2);
                addMachine(tblF3Ass, Var.Area.Assembly, F3);
                addMachine(tblF4Ass, Var.Area.Assembly, F4);
                addMachine(tblF5Ass, Var.Area.Assembly, F5);
                */
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
            }

            
        }
        private void addLine()
        {
            try
            {
                //DataTable dtLayout = Master_Select("Q1");

                //Dictionary<string, TableLayoutPanel> dicTableLayout = new Dictionary<string, TableLayoutPanel>()
                //{
                //    {"F1UPN",tblF1Nosew},{"F2UPN",tblF2Nosew},{"F3UPN",tblF3Nosew},{"F4UPN",tblF4Nosew},{"F5UPN",tblF5Nosew},
                //    {"F1FSS",tblF1Fss},{"F2FSS",tblF2Fss},{"F3FSS",tblF3Fss},{"F4FSS",tblF4Fss},{"F5FSS",tblF5Fss},  
                //    {"F1FGA",tblF1Ass},{"F2FGA",tblF2Ass},{"F3FGA",tblF3Ass},{"F4FGA",tblF4Ass},{"F5FGA",tblF5Ass}
                //};

                //int iRow = 0, iColumn = 0, iMaxRow = 4, iMaxColumn = 1, iLineTotal = dtLayout.Rows.Count;
                //string strArea = "",  strTable = "";
                //tblMenu.Visible = false;
                //for (int iLine = 0; iLine < iLineTotal; iLine++)
                //{
                //    if (iRow <= iMaxRow)
                //    {
                //        strArea = dtLayout.Rows[iLine]["OP_CD"].ToString();
                //        strTable = dtLayout.Rows[iLine]["FACTORY"].ToString() + dtLayout.Rows[iLine]["OP_CD"].ToString();

                //        UC.UC_Machine machine = new UC.UC_Machine();
                //        machine.OnButton_Click += Button_Line_Click;
                //        machine._Area = strArea;
                //        machine._Name = dtLayout.Rows[iLine]["LINE_NAME"].ToString();
                //        machine._Code = dtLayout.Rows[iLine]["LINE_CD"].ToString();

                //        dicTableLayout[strTable].Controls.Add(machine, iColumn, iRow);
                //    }

                //    if (iColumn++ > iMaxColumn)
                //    {
                //        iColumn = 0;
                //        iRow++;
                //    }

                //    if (iLine + 1 < iLineTotal && strArea != dtLayout.Rows[iLine + 1]["OP_CD"].ToString())
                //    {
                //        iColumn = 0;
                //        iRow = 0;
                //    }
                //}
                //tblMenu.Visible = true;
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());;
            }
            
        }

        #region Button Line Click

        #endregion Button Line Click
        private void Button_Line_Click(string argName, string argArea)
        {
            MessageBox.Show(argArea + "|" + argName);
        }

        #endregion Init Form

        #region DB

        private DataTable Master_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.MASTER_PLANT_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }


        #endregion DB

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text= string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void cmdVJ1_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "610";
        }

        


    }
}
