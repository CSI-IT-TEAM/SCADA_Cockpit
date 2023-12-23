using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class FORM_SCADA_DOWNTIME_DETAIL : Form
    {
        public FORM_SCADA_DOWNTIME_DETAIL()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        int cCount = 0;
        #region DB
        public DataSet sbGetData(string ARG_QTYPE, string ARG_YM, string ARG_DIV)
        {

            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT.SP_GET_ANALYSIS_ANDON_DETAIL";

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
        private void BindingAndonChart(DataTable dt)
        {
            try
            {
                //Quality Chart
                chart1.DataSource = dt;
                chart1.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                chart1.Series[0].ArgumentDataMember = "LINE_NM";
                chart1.Series[0].ValueDataMembers.AddRange(new string[] { "LA" });
                ((DevExpress.XtraCharts.XYDiagram)chart1.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

                //Matenance Chart
                chart2.DataSource = dt;
                chart2.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                chart2.Series[0].ArgumentDataMember = "LINE_NM";
                chart2.Series[0].ValueDataMembers.AddRange(new string[] { "LB" });
                ((DevExpress.XtraCharts.XYDiagram)chart2.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

                //Management Chart
                chart3.DataSource = dt;
                chart3.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                chart3.Series[0].ArgumentDataMember = "LINE_NM";
                chart3.Series[0].ValueDataMembers.AddRange(new string[] { "LC" });
                ((DevExpress.XtraCharts.XYDiagram)chart3.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

                //Total Chart
                chart4.DataSource = dt;
                chart4.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                chart4.Series[0].ArgumentDataMember = "LINE_NM";
                chart4.Series[0].ValueDataMembers.AddRange(new string[] { "ANDON_AVG_TIME_TOTAL" });
                chart4.Series[1].ArgumentScaleType = ScaleType.Qualitative;
                chart4.Series[1].ArgumentDataMember = "LINE_NM";
                chart4.Series[1].ValueDataMembers.AddRange(new string[] { "ALARM_TIME" });
                ((DevExpress.XtraCharts.XYDiagram)chart4.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void BindingChart2(DataTable dt)
        {
            try
            {
                chart2.DataSource = dt;
                chart2.Series[0].ArgumentDataMember = "LINE_NM";
                chart2.Series[0].ValueDataMembers.AddRange(new string[] { "ALARM_RATIO" });
                chart2.Series[1].ArgumentDataMember = "LINE_NM";
                chart2.Series[1].ValueDataMembers.AddRange(new string[] { "ABSENT_RATIO" });
                ((DevExpress.XtraCharts.XYDiagram)chart1.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void chartControl1_MouseClick(object sender, MouseEventArgs e)
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
                    DataSet ds = sbGetData("PLANT", sYM, null);
                    BindingChart2(ds.Tables[0]);
                    this.Cursor = Cursors.Default;
                }
                catch
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 60)
            {
                cCount = 0;
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    DataSet ds = sbGetData("Q", DateTime.Now.ToString("yyyyMM"), null);
                    BindingAndonChart(ds.Tables[0]);

                    // DataSet ds2 = sbGetData("PLANT", DateTime.Now.ToString("yyyyMMdd"), null);
                    //BindingChart2(ds2.Tables[0]);
                    splashScreenManager1.CloseWaitForm();
                }
                catch
                {
                    splashScreenManager1.CloseWaitForm();
                }
            }
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void FORM_SCADA_ABSENT_DETAIL_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
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
