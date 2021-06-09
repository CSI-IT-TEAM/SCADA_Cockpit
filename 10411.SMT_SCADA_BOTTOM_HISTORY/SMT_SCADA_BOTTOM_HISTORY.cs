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
                LoadingDataChart();
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
        private int GetMinValue(List<int> lst)
        {
            try
            {
                return lst.Min();
            }
            catch
            {
                return 0;
            }
        }
        private int GetMaxValue(List<int> lst)
        {
            try
            {
                return lst.Max();
            }
            catch
            {
                return 0;
            }

        }

        #region Loading Data
        private void LoadingDataChart()
        {
            try
            {
                
                dtData = GetData("Q", "ALL", "ALL");        /*Get All Data*/
                int iRow = 0;
                DataTable dt1 = null;
                DataTable dt2 = null;
                dt1 = dtData.Select("MLINE_CD = 'BB101'", "HMS").CopyToDataTable(); //GetData Mline: BB101
                dt2 = dtData.Select("MLINE_CD = 'BB102'", "HMS").CopyToDataTable(); //GetData Mline: BB102

                    

                if (dt1.Rows.Count <= dt2.Rows.Count)
                        iRow = dt1.Rows.Count;
                    else
                        iRow = dt2.Rows.Count;

                /*---------------------------Create----------------------------------*/
                //Clear Chart
                cht_Chart.Series.Clear();
                cht_Chart.Titles.Clear();
                cht_Chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;

                Series series1 = new Series("", ViewType.Spline);
                Series series2 = new Series("", ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                /*---------------------------Add DataPoint----------------------------------*/
                if (dt1 != null || dt1.Rows.Count > 0)
                {
                    for (int i = 0; i < iRow; i++)
                    {
                        if (dt1.Rows.Count <= dt2.Rows.Count)
                        {
                            series1.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                        }
                        else
                        {
                            series1.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                        }
                    }
                    
                }
                series1.ArgumentScaleType = ScaleType.Qualitative;

                if (dt2 != null || dt2.Rows.Count > 0)
                {
                    for (int i = 0; i < iRow; i++)
                    {
                        if (dt1.Rows.Count <= dt2.Rows.Count)
                        {
                            series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                        }
                        else
                        {
                            series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                        }
                    }
                }
                series2.ArgumentScaleType = ScaleType.Qualitative;

                //Add Series
                cht_Chart.SeriesSerializable = new Series[] { series1, series2 };
                //title
                DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                chartTitle.Alignment = System.Drawing.StringAlignment.Near;
                chartTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
                chartTitle.Text = "SCADA Machine Temporature";
                chartTitle.TextColor = System.Drawing.Color.Blue;
                cht_Chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });

                //Constant line
                //constantLine1.ShowInLegend = false;
                constantLine1.AxisValueSerializable = dtData.Rows[4]["MIN_VL"].ToString();
                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";
                constantLine2.AxisValueSerializable = dtData.Rows[5]["MAX_VL"].ToString();
                constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine2.Name = "Max";
                // constantLine1.ShowBehind = false;
                constantLine1.Title.Visible = false;
                constantLine1.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine1.LineStyle.Thickness = 3;
                constantLine2.Title.Visible = false;
                constantLine2.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine2.LineStyle.Thickness = 3;
                // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region DataBase
        public DataTable GetData(string argType, string argMC, string argMILINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            MyOraDB.ShowErr = true;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT_01.SMT_SCADA_BOTTOM_HISTORY";

                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_MC_ID";
                MyOraDB.Parameter_Name[2] = "V_P_MLINE_CD";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argType;
                MyOraDB.Parameter_Values[1] = argMC;
                MyOraDB.Parameter_Values[2] = argMILINE_CD;
                MyOraDB.Parameter_Values[3] = "";

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

        private void ckb_MC001_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ckb_MC002_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
