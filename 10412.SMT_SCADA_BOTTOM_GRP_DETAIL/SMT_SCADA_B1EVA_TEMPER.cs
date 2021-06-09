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
    public partial class SMT_SCADA_B1EVA_TEMPER : Form
    {
        public SMT_SCADA_B1EVA_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        #region Variable
        DataTable _dt, _dtKned1, _dtKned2, _dtRoll1, _dtRoll2, _dtExtr, _dtPall, _dtCald;
        const int ReloadTime = 60;
        int cCount = 0;
        double dKneaderMC1 = 0, dKneaderMC1Min = 0, dKneaderMC1Max = 0, dKneaderMat1 = 0, dKneaderMat1Min = 0, dKneaderMat1Max = 0,
               dKneaderMC2 = 0, dKneaderMC2Min = 0, dKneaderMC2Max = 0, dKneaderMat2 = 0, dKneaderMat2Min = 0, dKneaderMat2Max = 0,
               dRollMC1 = 0, dRollMC1Min = 0, dRollMC1Max = 0,
               dRollMC2 = 0, dRollMC2Min = 0, dRollMC2Max = 0,
               dExtrMC = 0, dExtrMCMin = 0, dExtrMCMax = 0,
               dPallMC = 0, dPallMCMin = 0, dPallMCMax = 0,
               dCalMC = 0, dCalMCMin = 0, dCalMCMax = 0;

        private void SMT_SCADA_B1EVA_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        #endregion

        #region DB
        private DataTable select_temp_sum(string arg_mline_cd, string arg_mc_id)
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
        private DataTable LOAD_EVA_DATA()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_B1EVA_TEMP_TRACKING";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "CV_1";
                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";
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

        private DataTable LOAD_DATA_HISTORY(string ARG_MLINE_CD, string ARG_MC_ID, string ARG_ROLL_OP_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                // string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_RUB_TEMP_HISTORY";
                string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_B1EVA_TEMP_HISTORY";
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
        #endregion

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }

        #region Create & Binding Data
        //private void LoadData()
        //{


        //    DataTable dt;
        //    if (_dtKned1 == null || _dtKned1.Rows.Count == 0)
        //        dt = this.select_temp_sum("KNED", "001");
        //    else
        //        dt = _dtKned1.Copy();
        //    CreateChartLineOld(chartKneader, dt, "Kneader - M/C");

        //    dt = null;
        //    if (_dtRoll1 == null || _dtRoll1.Rows.Count == 0)
        //        dt = this.select_temp_sum("ROLL", "001");
        //    else
        //        dt = _dtRoll1.Copy();
        //    CreateChartLineOld(chartRoll, dt, "Roll");

        //    dt = null;
        //    if (_dtExtr == null || _dtExtr.Rows.Count == 0)
        //        dt = this.select_temp_sum("EXTR", "001");
        //    else
        //        dt = _dtExtr.Copy();
        //    CreateChartLineOld(chartEXTR, dt, "Extruder");

        //    dt = null;
        //    if (_dtPall == null || _dtPall.Rows.Count == 0)
        //        dt = this.select_temp_sum("PELL", "001");
        //    else
        //        dt = _dtPall.Copy();
        //    CreateChartLineOld(chartPELL, dt, "Pelletizing");

        //    dt = null;
        //    if (_dtCald == null || _dtCald.Rows.Count == 0)
        //        dt = this.select_temp_sum("CALD", "001");
        //    else
        //        dt = _dtCald.Copy();
        //    CreateChartLineOld(chartCal, dt, "Calender");

        //}

        private void BindingData()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                //DataTable dt1 = LOAD_DATA_HISTORY("KD101", "001", "KNED");
                //DataTable dt2 = LOAD_DATA_HISTORY("KD102", "001", "KNED");
                DataTable dt1 = new DataTable();
                DataTable dt2 = new DataTable();
                if (_dtKned1 == null || _dtKned1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("KD101", "001", "KNED");
                else
                    dt1 = _dtKned1.Copy();
                if (_dtKned2 == null || _dtKned2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("KD102", "001", "KNED");
                else
                    dt2 = _dtKned2.Copy();

                CreateChartLine(chartKneader, dt1, "Kneader", " M/C 1", dt2, "M/C 2");

                //Chart Roll
                dt1 = null;
                dt2 = null;
                if (_dtRoll1 == null || _dtRoll1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("KD101", "003", "ROLL");
                else
                    dt1 = _dtRoll1.Copy();
                if (_dtRoll2 == null || _dtRoll2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("KD102", "003", "ROLL");
                else
                    dt2 = _dtRoll2.Copy();
                if ((dt1 != null && dt1.Rows.Count > 0) || (dt2 != null && dt2.Rows.Count > 0))
                {
                    CreateChartLine(chartRoll, dt1, "Roll", "M/C 1", dt2, "M/C 2");

                }

                //Chart Extruder
                dt1 = null;
                dt2 = null;
                if (_dtExtr == null || _dtExtr.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("KD101", "004", "EXTR");
                else
                    dt1 = _dtExtr.Copy();
                CreateChartLine(chartEXTR, dt1, "Extruder");

                //Chart Pall
                dt1 = null;
                dt2 = null;
                if (_dtExtr == null || _dtExtr.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("KD101", "005", "PELL");
                else
                    dt1 = _dtExtr.Copy();
                CreateChartLine(chartPELL, dt1, "Palettizing");

                //Chart Cal
                dt1 = null;
                if (_dtCald == null || _dtCald.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("KD102", "004", "CALD");
                else
                    dt1 = _dtCald.Copy();
                CreateChartLine(chartCal, dt1, "Calender");

                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }



        private void BindingDataGauges()
        {
            DataTable dt;

            if (_dt == null || _dt.Rows.Count == 0)
                dt = LOAD_EVA_DATA();
            else
                dt = _dt.Copy();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                    {
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dKneaderMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1 Material
                        {
                            dKneaderMat1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMat1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMat1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "001")
                        {
                            dKneaderMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "002")
                        {
                            dKneaderMat2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMat2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMat2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003")
                        {
                            dRollMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dRollMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dRollMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003")
                        {
                            dRollMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dRollMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dRollMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "EXTR" && dt.Rows[iRow]["MC_ID"].ToString() == "004") //extruder
                        {
                            dExtrMC = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dExtrMCMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dExtrMCMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "PELL" && dt.Rows[iRow]["MC_ID"].ToString() == "005")
                        {
                            dPallMC = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dPallMCMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dPallMCMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "CALD" && dt.Rows[iRow]["MC_ID"].ToString() == "004")
                        {
                            dCalMC = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dCalMCMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dCalMCMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }


                    }

                }

                //Kneader================================
                BindingGauges(lnKneaderMC1, dKneaderMC1, dKneaderMC1Min - 10, dKneaderMC1Max + 10, dKneaderMC1Min, dKneaderMC1Max);
                lblKneaderMC1.Text = "Temp: " + dKneaderMC1.ToString() + " °C";
                lblKneaderMC1Min.Text = "Min: " + dKneaderMC1Min.ToString() + " °C";
                lblKneaderMC1Max.Text = "Max: " + dKneaderMC1Max.ToString() + " °C";

                BindingGauges(cirKneaderMat1, dKneaderMat1, dKneaderMat1Min - 10, dKneaderMat1Max + 10, dKneaderMat1Min, dKneaderMat1Max);
                lblKneaderMC1.Text = "Temp: " + dKneaderMC1.ToString() + " °C";
                lblKneaderMC1Min.Text = "Min: " + dKneaderMC1Min.ToString() + " °C";
                lblKneaderMC1Max.Text = "Max: " + dKneaderMC1Max.ToString() + " °C";

                BindingGauges(lnKneaderMC2, dKneaderMC2, dKneaderMC2Min - 10, dKneaderMC2Max + 10, dKneaderMC2Min, dKneaderMC2Max);
                lblKneaderMC2.Text = "Temp: " + dKneaderMC2.ToString() + " °C";
                lblKneaderMC2Min.Text = "Min: " + dKneaderMC2Min.ToString() + " °C";
                lblKneaderMC2Max.Text = "Max: " + dKneaderMC2Max.ToString() + " °C";

                BindingGauges(cirKneaderMat2, dKneaderMat2, dKneaderMat2Min - 10, dKneaderMat2Max + 10, dKneaderMat2Min, dKneaderMat2Max);
                lblKneaderMC2.Text = "Temp: " + dKneaderMC2.ToString() + " °C";
                lblKneaderMC2Min.Text = "Min: " + dKneaderMC2Min.ToString() + " °C";
                lblKneaderMC2Max.Text = "Max: " + dKneaderMC2Max.ToString() + " °C";
                //Roll1================================
                BindingGauges(lnRollMC1, dRollMC1, dRollMC1Min - 10, dRollMC1Max + 10, dRollMC1Min, dRollMC1Max);
                lblRollMC1.Text = "Temp: " + dRollMC1.ToString() + " °C";
                lblRollMC1Min.Text = "Min: " + dRollMC1Min.ToString() + " °C";
                lblRollMC1Max.Text = "Max: " + dRollMC1Max.ToString() + " °C";
                //Roll2================================
                BindingGauges(lnRollMC2, dRollMC2, dRollMC2Min - 10, dRollMC2Max + 10, dRollMC2Min, dRollMC2Max);
                lblRollMC2.Text = "Temp: " + dRollMC2.ToString() + " °C";
                lblRollMC2Min.Text = "Min: " + dRollMC2Min.ToString() + " °C";
                lblRollMC2Max.Text = "Max: " + dRollMC2Max.ToString() + " °C";
                //Extr================================
                BindingGauges(lnExtrMC, dExtrMC, dExtrMCMin - 10, dExtrMCMax + 10, dExtrMCMin, dExtrMCMax);
                lblExtrMC.Text = "Temp: " + dExtrMC.ToString() + " °C";
                lblExtrMCMin.Text = "Min: " + dExtrMCMin.ToString() + " °C";
                lblExtrMCMax.Text = "Max: " + dExtrMCMax.ToString() + " °C";
                //Pall================================
                BindingGauges(lnPallMC, dPallMC, dPallMCMin - 10, dPallMCMax + 10, dPallMCMin, dPallMCMax);
                lblPallMC.Text = "Temp: " + dPallMC.ToString() + " °C";
                lblPallMCMin.Text = "Min: " + dPallMCMin.ToString() + " °C";
                lblPallMCMax.Text = "Max: " + dPallMCMax.ToString() + " °C";
                //Calender================================
                BindingGauges(lnCalMC, dCalMC, dCalMCMin - 10, dCalMCMax + 10, dCalMCMin, dCalMCMax);
                lblCalMC.Text = "Temp: " + dCalMC.ToString() + " °C";
                lblCalMCMin.Text = "Min: " + dCalMCMin.ToString() + " °C";
                lblCalMCMax.Text = "Max: " + dCalMCMax.ToString() + " °C";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = arg_name1;
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
                ((XYDiagram)arg_chart.Diagram).AxisX.AutoScaleBreaks.MaxCount = 1;
                ((XYDiagram)arg_chart.Diagram).AxisX.GridLines.Visible = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
                ((XYDiagram)arg_chart.Diagram).AxisX.NumericScaleOptions.AutoGrid = true;

                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new Font("Tahoma", 10, FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new Font("Tahoma", 10, FontStyle.Bold);


            }
            catch (Exception ex)
            {

            }


        }

        private void CreateChartLineOld(ChartControl arg_chart, DataTable arg_dt, string arg_name)
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
                ((XYDiagram)arg_chart.Diagram).Margins.Bottom = 20;
                ((XYDiagram)arg_chart.Diagram).Margins.Left = 20;
                ((XYDiagram)arg_chart.Diagram).Margins.Right = 20;
                ((XYDiagram)arg_chart.Diagram).Margins.Top = 20;
                //---------------
                ((XYDiagram)arg_chart.Diagram).AxisY.GridLines.Visible = false;
            }
            catch
            { }
        }

        private void CreateChartLine(ChartControl arg_chart, DataTable arg_dt, string arg_name)
        {
            try
            {
                if (arg_dt == null || arg_dt.Rows.Count == 0) return;
                arg_chart.Series.Clear();
                arg_chart.Titles.Clear();

                //----------create--------------------
                Series series1 = new Series(arg_name, ViewType.Spline);

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
                        if (arg_dt.Rows[i]["VALUE"] == null || arg_dt.Rows[i]["VALUE"].ToString() == "")
                            series1.Points.Add(new SeriesPoint(arg_dt.Rows[i]["T_HMS"].ToString()));
                        else
                            series1.Points.Add(new SeriesPoint(arg_dt.Rows[i]["T_HMS"].ToString(), arg_dt.Rows[i]["VALUE"].ToString()));
                    }
                    catch
                    { }
                }

                arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
                series1.ArgumentScaleType = ScaleType.Qualitative;

                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();

                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                //Constant line
                //constantLine1.ShowInLegend = false;

                constantLine1.AxisValueSerializable = arg_dt.Rows[0]["MINVAL"].ToString();
                constantLine2.AxisValueSerializable = arg_dt.Rows[0]["MAXVAL"].ToString();


                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";

                constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine2.Name = "Max";
                // constantLine1.ShowBehind = false;
                constantLine1.Title.Visible = false;
                constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine1.LineStyle.Thickness = 3;
                constantLine2.Title.Visible = false;
                constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine2.LineStyle.Thickness = 3;
                // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

                // format Series 
                splineSeriesView1.LineStyle.Thickness = 3;

                xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;

                series1.View = splineSeriesView1;

                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.Auto = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.AutoSideMargins = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
                //((XYDiagram)arg_chart.Diagram).AxisX.Label.Angle = 0;
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.AutoGrid = false;
                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.GridSpacing = 1;
                //--------Text AxisX/ AxisY
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = arg_name;
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;

                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.Auto = true;
                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt.Rows[0]["MINVAL"].ToString()) - 5, Convert.ToInt32(arg_dt.Rows[0]["MAXVAL"].ToString()) + 5);


                //Phuoc Continues Format
                ((XYDiagram)arg_chart.Diagram).AxisY.GridLines.Visible = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.AutoScaleBreaks.MaxCount = 1;
               
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.MinIndent = 1;
                ((XYDiagram)arg_chart.Diagram).AxisX.NumericScaleOptions.AutoGrid = false;

                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                //((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                //((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new Font("Times New Roman", 10, FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);

            }
            catch
            { }
        }
        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            double _iMin = 0, _iMax = 100;
            if (num > 0)
            {
                _iMin = iMin;
                _iMax = iMax;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = (float)_iMin;
            circularGauge.Scales[0].MaxValue = (float)_iMax;

            circularGauge.Scales[0].Value = 0;

            //circularGauge.Labels[0].Text = "0";
            if (circularGauge.Scales[0].Ranges.Count >= 3 && num > 0)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();



                circularGauge.Scales[0].Value = (float)num;


                //labelGauges.Text = num.ToString();
            }
            catch (Exception ex)
            { }
            // }
        }
        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            double _iMin = 0, _iMax = 100;
            if (num > 0)
            {
                _iMin = iMin;
                _iMax = iMax;
            }
            circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = (float)_iMin;
            circularGauge.Scales[0].MaxValue = (float)_iMax;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
            circularGauge.Scales[0].Value = 0;

            if (circularGauge.Scales[0].Ranges.Count >= 3 && num > 0)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                //circularGauge.Scales[0].MinValue = (float)iMin;
                //circularGauge.Scales[0].MaxValue = (float)iMax;
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) - 2);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 2);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 5);

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();


                circularGauge.Scales[0].Value = (float)num;

                //labelGauges.Text = num.ToString();
            }
            catch (Exception ex)
            { }
            // }
        }
        #endregion


        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                BindingDataGauges();
                //LoadData();
                BindingData();
            }
        }

        private void SMT_SCADA_B1EVA_TEMPER_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
