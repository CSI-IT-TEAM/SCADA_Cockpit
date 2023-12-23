using DevExpress.XtraCharts;
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
    public partial class FORM_SCADA_WOF_DETAIL : Form
    {
        public FORM_SCADA_WOF_DETAIL()
        {
            InitializeComponent();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }
        #region Variable
        int cCount = 0;
        #endregion
        #region DB
        private DataSet Data_Select(string argType, string argDate = "")
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
        }
        public DataSet sbGetData(string ARG_QTYPE, string ARG_YM, string ARG_DIV)
        {
           
                COM.OraDB MyOraDB = new COM.OraDB();
                DataSet ds_ret;
                try
                {
                    string process_name = "MES.PKG_SMT_SCADA_COCKPIT.SP_GET_ANALYSIS_WOF_DETAIL";

                    MyOraDB.ReDim_Parameter(4);
                    MyOraDB.Process_Name = process_name;

                    MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                    MyOraDB.Parameter_Name[1] = "ARG_YM";
                    MyOraDB.Parameter_Name[2] = "ARG_REMARK";
                    MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                    MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                    MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                    MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                    MyOraDB.Parameter_Values[1] = ARG_YM;
                    MyOraDB.Parameter_Values[2] = ARG_DIV;
                    MyOraDB.Parameter_Values[3] = "";

                    MyOraDB.Add_Select_Parameter(true);
                    ds_ret = MyOraDB.Exe_Select_Procedure();

                    if (ds_ret == null) return null;
                    return ds_ret;
                }
                catch
                {
                    return null;
                }
        }
        #endregion
        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }
        private void BindingChart1(DataTable dt)
        {
            try
            {
                chart1.DataSource = dt;
                chart1.Series[0].ArgumentDataMember = "YM";
                chart1.Series[0].ValueDataMembers.AddRange(new string[] { "WOF_COUNT" });

                chart1.Series[1].ArgumentDataMember = "YM";
                chart1.Series[1].ValueDataMembers.AddRange(new string[] { "ALARM_TIME" });
                ((DevExpress.XtraCharts.XYDiagram)chart1.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;


            

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindingChart2(DataTable dt)
        {
            try
            {
                chart2.DataSource = dt;
                chart2.Series[0].ArgumentDataMember = "WO_DATE";
                chart2.Series[0].ValueDataMembers.AddRange(new string[] { "PM" });
                chart2.Series[1].ArgumentDataMember = "WO_DATE";
                chart2.Series[1].ValueDataMembers.AddRange(new string[] { "RM" });
                chart2.Series[2].ArgumentDataMember = "WO_DATE";
                chart2.Series[2].ValueDataMembers.AddRange(new string[] { "AM" });
                ((DevExpress.XtraCharts.XYDiagram)chart2.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BindingChart3(DataTable dt)
        {
            try
            {
                //DataSet ds1 = Data_Select("D");
                //if (ds1 == null || ds1.Tables.Count == 0) return;
                //DataTable dtData = ds1.Tables[0].Select("", "OCR_TIME ASC").CopyToDataTable();

                chart3.DataSource = dt.Select("", "ALARM_TIME ASC").CopyToDataTable();
                chart3.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                chart3.Series[0].ArgumentDataMember = "MC_NAME";
                chart3.Series[0].ValueDataMembers.AddRange(new string[] { "ALARM_TIME" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FORM_SCADA_REWORK_DETAIL_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    //DataSet ds =  sbGetData("Q", DateTime.Now.ToString("yyyyMM"), null);
                    //BindingChart1(ds.Tables[0]);
                    //BindingChart2(ds.Tables[0]);
                    //BindingChart3(ds.Tables[0]);
                    cCount = 60;
                    tmrDate.Start();
                }
                else
                {
                    tmrDate.Stop();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 60)
            {
                cCount = 0;
                splashScreenManager1.ShowWaitForm();
                DataSet ds = sbGetData("Q", DateTime.Now.ToString("yyyyMM"), null);
                BindingChart1(ds.Tables[0]);
                DataSet ds2 = sbGetData("Q2", DateTime.Now.ToString("yyyyMM"), null);
                BindingChart2(ds2.Tables[0]);
                DataSet ds1 = sbGetData("TOP", DateTime.Now.ToString("yyyyMM"), null);
                BindingChart3(ds1.Tables[0]);
                splashScreenManager1.CloseWaitForm();
            }
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            ChartHitInfo hit = chart1.CalcHitInfo(e.X, e.Y);
            SeriesPoint point = hit.SeriesPoint;

            // Check whether the series point was clicked or not.
            if (point != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    string sYM = string.Concat(point.Argument);
                    DataSet ds = sbGetData("Q2", sYM, null);
                    chart2.Titles[0].Text = "Work Order Current Situation on " + sYM;
                    BindingChart2(ds.Tables[0]);
                    this.Cursor = Cursors.Default;
                }
                catch
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }
    }
}
