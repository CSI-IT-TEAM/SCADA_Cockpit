using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
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
    public partial class SMT_SCADA_BOTTOM_OS_TEMPER : Form
    {
        public SMT_SCADA_BOTTOM_OS_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        #region var

        int cCount = 0, iPage = 1;
        DataTable _dt, _dtBanb1, _dtBanb2, _dtRoll11, _dtRoll12, _dtRoll21, _dtRoll22, _dtCald1, _dtCald2;
        DataTable _dtData, _dtKned1, _dtKned2, _dtRoll, _dtExtr, _dtPell, _dtCald;

        private void SMT_SCADA_BOTTOM_OS_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 180;
                tmrDate.Start();
            }else
            {
                tmrDate.Stop();
            }
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            if (cCount >= 180)
            {
                cCount = 0;
                switch (iPage)
                {
                    case 1:
                        BindingPage1Data();
                        break;
                    case 2:
                        BindingPage2Data();
                        break;
                }
            }
        }
        #endregion

        #region DB
        private DataTable LOAD_DATA_HISTORY(string ARG_MLINE_CD, string ARG_MC_ID, string ARG_ROLL_OP_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                // string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_RUB_TEMP_HISTORY";
                string process_name = "MES.PKG_SMT_B1_DIGITAL.SP_RUB_TEMP_HISTORY";
                //ARGMODE
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MC_ID";
                MyOraDB.Parameter_Name[2] = "ARG_ROLL_OP_CD";
                MyOraDB.Parameter_Name[3] = "CV_1";
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MC_ID;
                MyOraDB.Parameter_Values[2] = ARG_ROLL_OP_CD;
                MyOraDB.Parameter_Values[3] = "";
                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();
                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch
            {
                return null;
            }
        }
        private DataTable SELECT_TEMP_SUM(string arg_mline_cd, string arg_mc_id)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = "MES.PKG_SMT_PROD_SHOW.SEL_EVA_TEMP_TRACKING";

            //02.ARGURMENT ¢¬i
            MyOraDB.Parameter_Name[0] = "ARG_MLINE_CD";
            MyOraDB.Parameter_Name[1] = "ARG_MC_ID";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            //03.DATA TYPE A¢´AC

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = arg_mline_cd;
            MyOraDB.Parameter_Values[1] = arg_mc_id;
            MyOraDB.Parameter_Values[2] = "";




            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        #endregion
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }

        private void sbtnNav_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton sbtn = ((SimpleButton)sender);
                sbtnRub.Enabled = true;
                sBtnEVA.Enabled = true;
                sbtn.Enabled = false;
                switch (sbtn.Tag.ToString())
                {
                    case "Rubber":
                        iPage = 1;
                        navigationFrame1.SelectedPage = navigationPage1;
                        BindingPage1Data();
                        break;
                    case "EVA":
                        iPage = 2;
                        navigationFrame1.SelectedPage = navigationPage2;
                        BindingPage2Data();
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region PAGE 1
        private void BindingPage1Data()
        {
            try
            {
                DataTable dt1 = LOAD_DATA_HISTORY("BB101", "001", "BANB");
                DataTable dt2 = LOAD_DATA_HISTORY("BB102", "001", "BANB");

                if (_dtBanb1 == null || _dtBanb1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "001", "BANB");
                else
                    dt1 = _dtBanb1.Copy();
                if (_dtBanb2 == null || _dtBanb2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "001", "BANB");
                else
                    dt2 = _dtBanb2.Copy();

                CreateChartLine(chartBanbury, dt1, "Banbury", " M/C 1", dt2, "M/C 2");

                //Chart Roll
                dt1 = null;
                dt2 = null;
                if (_dtRoll11 == null || _dtRoll11.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "003", "ROLL");
                else
                    dt1 = _dtRoll11.Copy();
                if (_dtRoll12 == null || _dtRoll12.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "003", "ROLL");
                else
                    dt2 = _dtRoll12.Copy();
                if ((dt1 != null && dt1.Rows.Count > 0) || (dt2 != null && dt2.Rows.Count > 0))
                {
                    CreateChartLine(chartRoll1, dt1, "1st Roll", "M/C 1", dt2, "M/C 2");

                }
                //Chart Roll 2
                dt1 = null;
                dt2 = null;
                if (_dtRoll21 == null || _dtRoll21.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "007", "ROLL");
                else
                    dt1 = _dtRoll21.Copy();
                if (_dtRoll22 == null || _dtRoll22.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "007", "ROLL");
                else
                    dt2 = _dtRoll22.Copy();
                //dt1 = checkDt(_dtRoll21,LOAD_DATA_HISTORY("BB101", "007", "ROLL"));
                //dt2 = checkDt(_dtRoll21,LOAD_DATA_HISTORY("BB102", "007", "ROLL"));

                CreateChartLine(chartRoll2, dt1, "2nd Roll", "M/C 1", dt2, "M/C 2");


                //Chart Calender
                dt1 = null;
                dt2 = null;
                if (_dtCald1 == null || _dtCald1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "008", "CALD");
                else
                    dt1 = _dtCald1.Copy();
                if (_dtCald2 == null || _dtCald2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "008", "CALD");
                else
                    dt2 = _dtCald2.Copy();
                // dt1 = checkDt(_dtCald1, LOAD_DATA_HISTORY("BB101", "008", "CALD"));
                // dt2 = checkDt(_dtCald2, LOAD_DATA_HISTORY("BB102", "008", "CALD"));

                CreateChartLine(chartCalendar, dt1, "Calendar", "M/C 1", dt2, "M/C 2");
            }
            catch { }
        }
        #endregion
        #region PAGE 2
        private void BindingPage2Data()
        {
            try
            {
                DataTable dt = new DataTable();
                if (_dtKned1 == null || _dtKned1.Rows.Count == 0)
                    dt = SELECT_TEMP_SUM("KNED", "001");
                else
                    dt = _dtKned1.Copy();
                CreateChartLine(ChartKneader1, dt, "Kneader - Machine");
                dt = null;
                if (_dtKned2 == null || _dtKned2.Rows.Count == 0)
                    dt = SELECT_TEMP_SUM("KNED", "002");
                else
                    dt = _dtKned2.Copy();
                CreateChartLine(ChartKneader2, dt, "Kneader - Material");

                dt = null;
                if (_dtRoll == null || _dtRoll.Rows.Count == 0)
                    dt = this.SELECT_TEMP_SUM("ROLL", "001");
                else
                    dt = _dtRoll.Copy();
                CreateChartLine(chartRoll, dt, "Roll");

                dt = null;
                if (_dtExtr == null || _dtExtr.Rows.Count == 0)
                    dt = this.SELECT_TEMP_SUM("EXTR", "001");
                else
                    dt = _dtExtr.Copy();
                CreateChartLine(chartEXTR, dt, "Extruder");

                dt = null;
                if (_dtPell == null || _dtPell.Rows.Count == 0)
                    dt = this.SELECT_TEMP_SUM("PELL", "001");
                else
                    dt = _dtPell.Copy();
                CreateChartLine(chartPall, dt, "Pelletizing");

                dt = null;
                if (_dtCald == null || _dtCald.Rows.Count == 0)
                    dt = this.SELECT_TEMP_SUM("CALD", "001");
                else
                    dt = _dtCald.Copy();
                CreateChartLine(chartCal, dt, "Calender");
            }
            catch { }
        }
        #endregion

        private void CreateChartLine(ChartControl arg_chart, DataTable arg_dt1, string arg_name1, string arg_serial_name1, DataTable arg_dt2, string arg_serial_name2)
        {
            try
            {
                //  if (arg_dt1 == null || arg_dt1.Rows.Count == 0) return;
                //  if (arg_dt2 == null || arg_dt2.Rows.Count == 0) return;
                int iRow = 0;
                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                    iRow = arg_dt2.Rows.Count;
                else
                    iRow = arg_dt1.Rows.Count;

                //----------create--------------------
                arg_chart.Series.Clear();
                arg_chart.Titles.Clear();
                arg_chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;
                // ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();

                Series series1 = new Series(arg_serial_name1, ViewType.Spline);
                Series series2 = new Series(arg_serial_name2, ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();



                //--------- Add data Point------------
                if (arg_dt1 != null && arg_dt1.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                            {
                                if (arg_dt1.Rows[i]["VALUE"] == null)
                                    series1.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), ""));
                                else
                                    series1.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), arg_dt1.Rows[i]["VALUE"]));
                            }
                            else
                            {
                                if (arg_dt1.Rows[i]["VALUE"] == null)
                                    series1.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), ""));
                                else
                                    series1.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), arg_dt1.Rows[i]["VALUE"]));


                            }

                        }
                    }
                    catch
                    { }


                }
                series1.ArgumentScaleType = ScaleType.Qualitative;

                if (arg_dt2 != null && arg_dt2.Rows.Count > 0)
                {

                    try
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                            {
                                series2.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), arg_dt2.Rows[i]["VALUE"]));

                            }
                            else
                            {
                                series2.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), arg_dt2.Rows[i]["VALUE"]));
                            }

                        }
                    }
                    catch
                    { }


                }
                series2.ArgumentScaleType = ScaleType.Qualitative;

                arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };


                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();

                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                //title
                DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
                chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
                chartTitle2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
                chartTitle2.Text = arg_name1;
                chartTitle2.TextColor = System.Drawing.Color.Yellow;
                arg_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle2 });

                //Constant line
                //constantLine1.ShowInLegend = false;

                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                {
                    constantLine1.AxisValueSerializable = arg_dt2.Rows[0]["MINVAL"].ToString();
                    constantLine2.AxisValueSerializable = arg_dt2.Rows[0]["MAXVAL"].ToString();
                }
                else
                {
                    constantLine1.AxisValueSerializable = arg_dt1.Rows[0]["MINVAL"].ToString();
                    constantLine2.AxisValueSerializable = arg_dt1.Rows[0]["MAXVAL"].ToString();
                }


                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";

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
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });


                // format Series 


                splineSeriesView1.LineStyle.Thickness = 3;
                splineSeriesView2.LineStyle.Thickness = 3;
                splineSeriesView2.Color = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

                series1.View = splineSeriesView1;
                series2.View = splineSeriesView2;

                xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
                splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation1;

                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.Auto = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.AutoSideMargins = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
                //((XYDiagram)arg_chart.Diagram).AxisX.Label.Angle = 0;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)arg_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.AutoGrid = false;
                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.GridSpacing = 1;
                //--------Text AxisX/ AxisY
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = "TEMPERATURE";
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;

                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.Auto = false;
                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.AutoSideMargins = false;
                //  ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.SideMarginsValue = 1;               
                // ((XYDiagram)arg_chart.Diagram).AxisY.Tickmarks.MinorVisible = false;

                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.Auto = true;
                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                    ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt2.Rows[0]["MINVAL"].ToString()) - 5, Convert.ToInt32(arg_dt2.Rows[0]["MAXVAL"].ToString()) + 5);
                else
                    ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt1.Rows[0]["MINVAL"].ToString()) - 5, Convert.ToInt32(arg_dt1.Rows[0]["MAXVAL"].ToString()) + 5);


                //Phuoc Continues Format
                ((XYDiagram)arg_chart.Diagram).AxisY.GridLines.Visible = false;

                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MinValue = Convert.ToInt32(arg_dt1.Rows[0]["MINVAL"].ToString()) - 2;
                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MaxValue = Convert.ToInt32(arg_dt1.Rows[0]["MAXVAL"].ToString()) + 2;
                //((XYDiagram)arg_chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MinValue = 25;
                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MaxValue = 55;


                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.SetMinMaxValues(arg_dt1.Rows[0]["MINVAL"], arg_dt1.Rows[0]["MAXVAL"]);

                // ((XYDiagram)arg_chart.Diagram).AxisX.Title.Text = "HMS";
                //  ((XYDiagram)arg_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
                // ((XYDiagram)arg_chart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));



            }
            catch (Exception ex)
            {

            }


        }

        private void CreateChartLine(ChartControl arg_chart, DataTable arg_dt, string arg_name)
        {
            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                arg_chart.Series.Clear();
                arg_chart.Titles.Clear();

                //----------create--------------------
                Series series1 = new Series("Line 1", ViewType.Spline);
                Series series2 = new Series("Line 2", ViewType.Spline);
                //Series series2 = new Series("Chart Line 5", ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
                //DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
                //DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
                //DevExpress.XtraCharts.BarWidenAnimation barWidenAnimation1 = new DevExpress.XtraCharts.BarWidenAnimation();
                //DevExpress.XtraCharts.ElasticEasingFunction elasticEasingFunction1 = new DevExpress.XtraCharts.ElasticEasingFunction();
                //DevExpress.XtraCharts.XYSeriesBlowUpAnimation xySeriesBlowUpAnimation1 = new DevExpress.XtraCharts.XYSeriesBlowUpAnimation();
                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
                //DevExpress.XtraCharts.XYSeriesUnwrapAnimation xySeriesUnwrapAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwrapAnimation();

                //DevExpress.XtraCharts.PowerEasingFunction powerEasingFunction1 = new DevExpress.XtraCharts.PowerEasingFunction();
                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
                DevExpress.XtraCharts.ConstantLine MinLine = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine MaxLine = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine NearMinLine = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine NearMaxLine = new DevExpress.XtraCharts.ConstantLine();

                //--------- Add data Point------------

                for (int i = 0; i < arg_dt.Rows.Count; i++)
                {
                    try
                    {
                        if (arg_dt.Rows[i]["VALUE1"] == null || arg_dt.Rows[i]["VALUE1"].ToString() == "")
                            series1.Points.Add(new SeriesPoint(arg_dt.Rows[i]["HMS"].ToString()));
                        else
                            series1.Points.Add(new SeriesPoint(arg_dt.Rows[i]["HMS"].ToString(), arg_dt.Rows[i]["VALUE1"].ToString()));
                    }
                    catch
                    { }

                    try
                    {
                        if (arg_dt.Rows[i]["VALUE2"] == null || arg_dt.Rows[i]["VALUE2"].ToString() == "")
                            series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["HMS"].ToString()));
                        else
                            series2.Points.Add(new SeriesPoint(arg_dt.Rows[i]["HMS"].ToString(), arg_dt.Rows[i]["VALUE2"].ToString()));
                    }
                    catch
                    { }

                }

                arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series2.ArgumentScaleType = ScaleType.Qualitative;


                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
                //Min line
                MinLine.AxisValueSerializable = arg_dt.Rows[0]["MIN_VALUE"].ToString();
                MinLine.Color = System.Drawing.Color.Red;
                MinLine.LineStyle.Thickness = 2;
                MinLine.ShowBehind = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { MinLine });
                //Near Min line
                NearMinLine.AxisValueSerializable = (Convert.ToInt32(arg_dt.Rows[0]["MIN_VALUE"].ToString()) + Convert.ToInt32(arg_dt.Rows[0]["NEAR"].ToString())).ToString();
                NearMinLine.Color = System.Drawing.Color.Yellow;
                NearMinLine.LineStyle.Thickness = 2;
                NearMinLine.ShowBehind = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { NearMinLine });
                //Max line
                MaxLine.AxisValueSerializable = arg_dt.Rows[0]["MAX_VALUE"].ToString();
                MaxLine.Color = System.Drawing.Color.Red;
                MaxLine.LineStyle.Thickness = 2;
                MaxLine.ShowBehind = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { MaxLine });
                //Near Max line
                NearMaxLine.AxisValueSerializable = (Convert.ToInt32(arg_dt.Rows[0]["MAX_VALUE"].ToString()) - Convert.ToInt32(arg_dt.Rows[0]["NEAR"].ToString())).ToString();
                NearMaxLine.Color = System.Drawing.Color.Yellow;
                NearMaxLine.LineStyle.Thickness = 2;
                NearMaxLine.ShowBehind = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { NearMaxLine });


                //title
                arg_chart.Titles.Add(new ChartTitle());
                arg_chart.Titles[0].Text = arg_name;//arg_name;
                arg_chart.Titles[0].Visibility = DevExpress.Utils.DefaultBoolean.True;
                arg_chart.Titles[0].Font = new Font("Tahoma", 12, FontStyle.Bold);
                arg_chart.Titles[0].Alignment = StringAlignment.Center;
                arg_chart.Titles[0].Dock = ChartTitleDockStyle.Left;
                // format Series 
                //splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //splineSeriesView1.Color = System.Drawing.Color.Green;
                //splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
                //splineSeriesView1.LineMarkerOptions.BorderVisible = false;
                //splineSeriesView1.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Circle;
                //splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Green;
                //splineSeriesView1.LineMarkerOptions.Size = 1;
                //splineSeriesView1.LineStyle.Thickness = 2;

                //splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //splineSeriesView2.Color = System.Drawing.Color.Black;
                //splineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.DodgerBlue;
                //splineSeriesView2.LineMarkerOptions.BorderVisible = false;
                //splineSeriesView2.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Circle;
                //splineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.Green;
                //splineSeriesView2.LineMarkerOptions.Size = 1;
                //splineSeriesView2.LineStyle.Thickness = 2;
                //series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                //series1.Label.TextPattern = "{V:#,#}";
                //series1.View = splineSeriesView1;
                //series2.View = splineSeriesView2;



                ((SplineSeriesView)series2.View).Color = Color.Black;
                ((SplineSeriesView)series1.View).Color = Color.Green;

                //series1.ShowInLegend = true;

                xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
                splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation1;



                arg_chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                arg_chart.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
                arg_chart.Legend.AlignmentVertical = LegendAlignmentVertical.TopOutside;
                arg_chart.Legend.Direction = LegendDirection.LeftToRight;
                // arg_chart.Legend.Direction = LegendDirection.TopToBottom;
                arg_chart.Legend.Margins.All = 0;
                arg_chart.Legend.Padding.All = 0;
                arg_chart.Legend.Font = new Font("Tahoma", 10, FontStyle.Bold);
                MaxLine.ShowInLegend = false;
                NearMaxLine.ShowInLegend = false;
                MinLine.ShowInLegend = false;
                NearMinLine.ShowInLegend = false;

                if (arg_dt.Rows[0]["VALUE1"] == null || arg_dt.Rows[0]["VALUE1"].ToString() == ""
                    || arg_dt.Rows[0]["VALUE2"] == null || arg_dt.Rows[0]["VALUE2"].ToString() == "")
                {
                    series1.ShowInLegend = false;
                    series2.ShowInLegend = false;
                }
                else
                {
                    series1.ShowInLegend = true;
                    series2.ShowInLegend = true;
                }

                //format Chart
                // ChartLine5.Size = new System.Drawing.Size(858, 157);
                ((XYDiagram)arg_chart.Diagram).AxisX.AutoScaleBreaks.MaxCount = 1;
                ((XYDiagram)arg_chart.Diagram).AxisX.GridLines.Visible = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
                ((XYDiagram)arg_chart.Diagram).AxisX.NumericScaleOptions.AutoGrid = true;


                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new Font("Tahoma", 10, FontStyle.Bold);

                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Visible = true;
                //((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.AutoGrid = false;


                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.Auto = true;



                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt.Rows[0]["MIN_VALUE"].ToString()) - 1, Convert.ToInt32(arg_dt.Rows[0]["MAX_VALUE"].ToString()) + 1);
                //((XYDiagram)arg_chart.Diagram).Margins.Bottom = 20;
                //((XYDiagram)arg_chart.Diagram).Margins.Left = 20;
                //((XYDiagram)arg_chart.Diagram).Margins.Right = 20;
                //((XYDiagram)arg_chart.Diagram).Margins.Top = 20;
                ((XYDiagram)arg_chart.Diagram).AxisY.GridLines.Visible = false;
            }
            catch
            { }


        }
    }
}
