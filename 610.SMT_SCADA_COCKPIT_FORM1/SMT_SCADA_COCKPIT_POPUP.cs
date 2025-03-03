﻿using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_POPUP : Form
    {
        public SMT_SCADA_COCKPIT_POPUP()
        {
            InitializeComponent();
        }
        public DataTable _dtData = null;
        public DataTable _dtDataPage = null;
        bool isLoop = false;
        const int ViewportPointCount = 30;
        int _iCurPage, _iMaxPage;
        double _iMinChart=0, _iMaxChart=0;
        string _strMachineCode = "";
        string _strType = "D";
        ObservableCollection<DataRealPoint> dataPoints = new ObservableCollection<DataRealPoint>();


        private void BindingChartData()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // chartControl1.Titles.Add(new ChartTitle { Text = "Real-Time Charting" });
                dataPoints.Clear();
                // _dtDataPage = SEL_SMT_INST_SET_CHART("014", "001");
                isLoop = true;
                timer1.Stop();
                

                DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
               // DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
               // DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();

                Series series = new Series("SV MIN", ViewType.Line);
                series.ChangeView(ViewType.Line);
                series.DataSource = dataPoints;
                series.ArgumentDataMember = "sArgument";
                series.ValueDataMembers.AddRange("SV_MIN");
                series.CrosshairLabelPattern = "{V:#,#}";
                //format
                //lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView1.LineStyle.Thickness = 5;
                lineSeriesView1.Color = Color.Green;
                series.View = lineSeriesView1;
                Series series2 = new Series("SV MAX", ViewType.Line);
                series2.ChangeView(ViewType.Line);
                series2.DataSource = dataPoints;
                series2.ArgumentDataMember = "sArgument";
                series2.ValueDataMembers.AddRange("SV_MAX");
                series2.CrosshairLabelPattern = "{V:#,#}";
                //format
                //  lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView2.Color = Color.Green;
                lineSeriesView2.LineStyle.Thickness = 5;
                series2.View = lineSeriesView2;

                Series series3 = new Series("FINAL PV", ViewType.Line);
                series3.ChangeView(ViewType.Line);
                series3.DataSource = dataPoints;
                series3.ArgumentDataMember = "sArgument";
                series3.ValueDataMembers.AddRange("FINAL_PV");
                series3.CrosshairLabelPattern = "{V:#,#}";
                //format
                // lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView3.LineStyle.Thickness = 5;
                lineSeriesView3.Color = Color.Red;
                series3.View = lineSeriesView3;

                //Series series4 = new Series("Set Ratio", ViewType.Line);
                //series4.ChangeView(ViewType.Line);
                //series4.DataSource = dataPoints;
                //series4.ArgumentDataMember = "sArgument";
                //series4.ValueDataMembers.AddRange("RATIO");
                //series4.CrosshairLabelPattern = "{V:#.0}%";
                ////pointSeriesLabel4.TextPattern = "{V:#.0}%";
                //series4.LabelsVisibility = DefaultBoolean.True;
                ////format
                //lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //lineSeriesView4.LineStyle.Thickness = 4;
                //lineSeriesView4.Color = Color.Orange;
                //series4.View = lineSeriesView4;

                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
                diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                diagram.AxisX.WholeRange.SideMarginsValue = 0;
                diagram.AxisX.Title.Text = "Time";
                diagram.EnableAxisXScrolling = true;
                diagram.AxisX.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.DependentAxesYRange = DefaultBoolean.True;
                diagram.AxisY.WholeRange.AlwaysShowZeroLevel = true;
                diagram.AxisY.Title.Text = "Values";
                diagram.AxisY.WholeRange.MinValue = _iMinChart - 3;
                diagram.AxisY.WholeRange.MaxValue = _iMaxChart + 3;
                diagram.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.AxisY.Title.TextColor = Color.Blue;
                diagram.AxisY.Title.Visibility = DefaultBoolean.True;
                diagram.AxisY.Color = Color.DodgerBlue;
                diagram.AxisY.Label.TextPattern = "{V:#,#}";
                diagram.AxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                
                diagram.AxisY.Interlaced = false;
                chartControl1.Series.Clear();
                chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series3, series2, series };

                //ADD SECONDARY AXISY
               // SecondaryAxisY myAxisY = new SecondaryAxisY("my X-Axis");
               // ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();
                //((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);
                //((LineSeriesView)series4.View).AxisY = myAxisY;
                //myAxisY.WholeRange.SideMarginsValue = 0;
                //myAxisY.WholeRange.MinValue = 0;
                //myAxisY.WholeRange.MaxValue = 100;
                //myAxisY.Title.Text = "Set Ratio (%)";
                //myAxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //myAxisY.Title.TextColor = Color.Orange;
                //myAxisY.Title.Visibility = DefaultBoolean.True;
                //myAxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //myAxisY.Color = Color.Orange;
                
                //legend
                chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
                chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
                chartControl1.Legend.Name = "Default Legend";
                chartControl1.Legend.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartControl1.Legend.Visibility = DefaultBoolean.True;

                if (_dtDataPage != null && _dtDataPage.Rows.Count <= ViewportPointCount)
                {
                    for (int i = 0; i < _dtDataPage.Rows.Count; i++)
                    {
                        string setTime1 = _dtDataPage.Rows[i]["SET_TIME"].ToString();
                        double SV_MIN = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MIN"]);
                        double SV_MAX = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MAX"]);
                        double FINAL_PV = Convert.ToDouble(_dtDataPage.Rows[i]["FINAL_PV"]);
                        // double RATIO1 = Convert.ToDouble(_dtDataPage.Rows[i]["SET_RATIO"]);
                        dataPoints.Add(new DataRealPoint(setTime1, SV_MIN, SV_MAX, FINAL_PV));
                    }
                    isLoop = true;
                    // tmrDelay.Start();
                }
                else
                {
                    isLoop = false;
                    timer1.Start();
                }
                // timer1.Start();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { 
                this.Cursor = Cursors.Default; 
            }
        }


        private void BindingChartData2()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                // chartControl1.Titles.Add(new ChartTitle { Text = "Real-Time Charting" });
                dataPoints.Clear();
                // _dtDataPage = SEL_SMT_INST_SET_CHART("014", "001");

                
                DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView2 = new DevExpress.XtraCharts.LineSeriesView();
                DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
                // DevExpress.XtraCharts.LineSeriesView lineSeriesView4 = new DevExpress.XtraCharts.LineSeriesView();
                // DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel4 = new DevExpress.XtraCharts.PointSeriesLabel();

                Series series = new Series("SV MIN", ViewType.Line);
                series.ChangeView(ViewType.Line);
                series.DataSource = dataPoints;
                series.ArgumentDataMember = "sArgument";
                series.ValueDataMembers.AddRange("SV_MIN");
                series.CrosshairLabelPattern = "{V:#,#.#}";
              //  series.ArgumentScaleType = ScaleType.Numerical;
                //format
                //lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView1.LineStyle.Thickness = 5;
                lineSeriesView1.Color = Color.Green;
                series.View = lineSeriesView1;
                Series series2 = new Series("SV MAX", ViewType.Line);
                series2.ChangeView(ViewType.Line);
                series2.DataSource = dataPoints;
                series2.ArgumentDataMember = "sArgument";
                series2.ValueDataMembers.AddRange("SV_MAX");
                series2.CrosshairLabelPattern = "{V:#,#.#}";
               // series2.ArgumentScaleType = ScaleType.Numerical;
                //format
                //  lineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView2.Color = Color.Green;
                lineSeriesView2.LineStyle.Thickness = 5;
                series2.View = lineSeriesView2;

                Series series3 = new Series("FINAL PV", ViewType.Line);
                series3.ChangeView(ViewType.Line);
                series3.DataSource = dataPoints;
                series3.ArgumentDataMember = "sArgument";
                series3.ValueDataMembers.AddRange("FINAL_PV");
                series3.CrosshairLabelPattern = "{V:#,#.#}";
               // series3.ArgumentScaleType = ScaleType.Numerical;
                //format
                // lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                lineSeriesView3.LineStyle.Thickness = 5;
                lineSeriesView3.Color = Color.Red;
                series3.View = lineSeriesView3;

                chartControl1.Series.Clear();
                chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2, series3, series };

                //Series series4 = new Series("Set Ratio", ViewType.Line);
                //series4.ChangeView(ViewType.Line);
                //series4.DataSource = dataPoints;
                //series4.ArgumentDataMember = "sArgument";
                //series4.ValueDataMembers.AddRange("RATIO");
                //seri.es4.CrosshairLabelPattern = "{V:#.0}%";
                ////pointSeriesLabel4.TextPattern = "{V:#.0}%";
                //series4LabelsVisibility = DefaultBoolean.True;
                ////format
                //lineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                //lineSeriesView4.LineStyle.Thickness = 4;
                //lineSeriesView4.Color = Color.Orange;
                //series4.View = lineSeriesView4;

                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;

                diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
                diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                diagram.AxisX.Title.Text = "Time";
                diagram.AxisX.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.EnableAxisXScrolling = true;
                diagram.AxisX.WholeRange.AlwaysShowZeroLevel = false;
                diagram.AxisX.WholeRange.SideMarginsValue = 0;

                
                diagram.DependentAxesYRange = DefaultBoolean.True;             
                diagram.AxisY.Title.Text = "Values";
                diagram.AxisY.WholeRange.SideMarginsValue = 0;
                diagram.AxisY.WholeRange.MinValue = _iMinChart - 3;
                diagram.AxisY.WholeRange.MaxValue = _iMaxChart + 3;               
                diagram.AxisY.Title.TextColor = Color.Blue;
                diagram.AxisY.Title.Visibility = DefaultBoolean.True;
                diagram.AxisY.Color = Color.DodgerBlue;
                diagram.AxisY.Label.TextPattern = "{V:#,#}";

                diagram.AxisY.Title.Font = new System.Drawing.Font("Cal +ibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                diagram.AxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                diagram.AxisY.Interlaced = false;
               



                

                //ADD SECONDARY AXISY
                // SecondaryAxisY myAxisY = new SecondaryAxisY("my X-Axis");
                // ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Clear();
                //((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);
                //((LineSeriesView)series4.View).AxisY = myAxisY;
                //myAxisY.WholeRange.SideMarginsValue = 0;
                //myAxisY.WholeRange.MinValue = 0;
                //myAxisY.WholeRange.MaxValue = 100;
                //myAxisY.Title.Text = "Set Ratio (%)";
                //myAxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //myAxisY.Title.TextColor = Color.Orange;
                //myAxisY.Title.Visibility = DefaultBoolean.True;
                //myAxisY.Label.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //myAxisY.Color = Color.Orange;

                //legend
                //chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
                //chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
                //chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
                //chartControl1.Legend.Name = "Default Legend";
                //chartControl1.Legend.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //chartControl1.Legend.Visibility = DefaultBoolean.True;

                diagram.AxisX.VisualRange.Auto = false;
                
                int iDataRow = _dtDataPage.Rows.Count;
                if (iDataRow >=20)
                {
                    diagram.AxisX.VisualRange.SetMinMaxValues(_dtDataPage.Rows[iDataRow - 21]["SET_TIME"], _dtDataPage.Rows[iDataRow - 1]["SET_TIME"]);
                    
                    //diagram.AxisX.VisualRange.max
                }
                else
                {
                    diagram.AxisX.VisualRange.SetMinMaxValues(_dtDataPage.Rows[0]["SET_TIME"], _dtDataPage.Rows[iDataRow - 1]["SET_TIME"]);
                }

                for (int i = 0; i < _dtDataPage.Rows.Count; i++)
                {
                    string setTime1 = _dtDataPage.Rows[i]["SET_TIME"].ToString();
                    double SV_MIN = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MIN"]);
                    double SV_MAX = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MAX"]);
                    double FINAL_PV = Convert.ToDouble(_dtDataPage.Rows[i]["FINAL_PV"]);
                    // double RATIO1 = Convert.ToDouble(_dtDataPage.Rows[i]["SET_RATIO"]);
                    dataPoints.Add(new DataRealPoint(setTime1, SV_MIN, SV_MAX, FINAL_PV));
                }
                // timer1.Start();
               // chartControl1.AutoScrollOffset = new Point(12, 32);
               // this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region DB
        private DataTable Data_PM_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.MACHINE_WOF_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_MACHINE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";


            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = _strMachineCode;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[0];
        }

        public DataTable SEL_SMT_INST_SET_CHART(string ARG_LINE_CD, string ARG_MLINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_PHUOC.SP_SMT_INST_SET"; 

                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "ARG_LINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_LINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[2] = "";


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

        public static DataTable Data_Select_Machine(string argType, string argMachineCd, string argMachineId, string argHm)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            //  MyOraDB.ShowErr = true;
            MyOraDB.ReDim_Parameter(5);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT_MACHINE_ALERT_V2";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_MACHINE_CD";
            MyOraDB.Parameter_Name[2] = "ARG_MACHINE_ID";
            MyOraDB.Parameter_Name[3] = "ARG_HM";
            MyOraDB.Parameter_Name[4] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[4] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argMachineCd;
            MyOraDB.Parameter_Values[2] = argMachineId;
            MyOraDB.Parameter_Values[3] = argHm;
            MyOraDB.Parameter_Values[4] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[0];
        }

        #endregion DB


        private void setClick(string argStatus)
        {
            if (argStatus == "NEXT" )
            {
                _iCurPage = _iCurPage + 1>_iMaxPage ? _iMaxPage : _iCurPage + 1;
            }
            else if (argStatus == "PREV")
            {
                _iCurPage = _iCurPage - 1 <=0 ?  1: _iCurPage - 1;
            }


            if (_iCurPage == 1)
            {
                cmdPrev.Enabled = false;
            }
            else
            {
                cmdPrev.Enabled = true;
            }

            if (_iCurPage == _iMaxPage)
            {
                cmdNext.Enabled = false;
            }
            else
            {
                cmdNext.Enabled = true;
            }

            lblPage.Text = _iCurPage.ToString() + "/" + _iMaxPage.ToString();
        }

        private void GetMinMaxChart(DataTable argDt)
        {
            double iValue1, iValue2, iValue3;

            double.TryParse(argDt.Rows[0]["SV_MIN"].ToString(), out _iMinChart);
            double.TryParse(argDt.Rows[0]["SV_MAX"].ToString(), out _iMaxChart);

            foreach (DataRow dr in argDt.Rows)
            {
                double.TryParse(dr["SV_MIN"].ToString(), out iValue1);
                double.TryParse(dr["SV_MAX"].ToString(), out iValue2);
                double.TryParse(dr["FINAL_PV"].ToString(), out iValue3);

                if (_iMinChart > iValue1) _iMinChart = iValue1;
                if (_iMinChart > iValue2) _iMinChart = iValue2;
                if (_iMinChart > iValue3) _iMinChart = iValue3;

                if (_iMaxChart < iValue1) _iMaxChart = iValue1;
                if (_iMaxChart < iValue2) _iMaxChart = iValue2;
                if (_iMaxChart < iValue3) _iMaxChart = iValue3;

            }         
        }

        private void setDataGridPm()
        {
            DataTable dt = Data_PM_Select("Q");
            gvwView.BeginUpdate();

            grdPm.DataSource = dt;

            gvwView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Regular);
            gvwView.ColumnPanelRowHeight = 50;
            gvwView.RowHeight = 50;
            for (int i = 0; i < gvwView.Columns.Count; i++)
            {

                gvwView.Columns[i].AppearanceHeader.Font = new Font("Calibri", 16, FontStyle.Bold);


                gvwView.Columns[i].AppearanceCell.Options.UseTextOptions = true;

                gvwView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                gvwView.Columns[i].OptionsFilter.AllowFilter = false;
                gvwView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                gvwView.Columns[i].OptionsColumn.AllowEdit = false;
                gvwView.Columns[i].OptionsColumn.ReadOnly = true;
                
                gvwView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                //gvwView.Columns[i].AppearanceHeader.Fonts

                gvwView.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                //  

               // gvwView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
              //  gvwView.Columns[i].DisplayFormat.FormatString = "#,###.##";
            }

            
            gvwView.BestFitColumns();

            gvwView.EndUpdate();

        }

        private void PM_Detail_Check()
        {
            if (rdMachine.Checked)
            {
                cmdDay.Visible = true;
                cmdWeek.Visible = true;
                cmdMonth.Visible = true;
                chartControl1.Visible = true;

                grdPm.Visible = false;
                grdRepair.Visible = false;
            }          
            else if (rdPmHis.Checked)
            {
                cmdDay.Visible = false;
                cmdWeek.Visible = false;
                cmdMonth.Visible = false;
                grdPm.Visible = true;
                setDataGridPm();
                chartControl1.Visible = false;
            }
            else if (rdRepair.Checked)
            {
                cmdDay.Visible = false;
                cmdWeek.Visible = false;
                cmdMonth.Visible = false;
                chartControl1.Visible = false;
                grdPm.Visible = false;

                grdRepair.Visible = true;

            }    
        }

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Visible)
                
                    grdPm.Visible = false;
                    lblTxt1.Text = "";
                    lblTxt2.Text = "";
                    lblTxt3.Text = "";
                    SetButtonClick("D");
                    //SetData();
                    if (_dtData == null || _dtData.Rows.Count == 0) return;

                    _iCurPage = 1;
                    _iMaxPage = _dtData.Rows.Count;

                    setClick("");

                   
                    setData();
                    BindingChartData2();
                
            }
            catch (Exception ex)
            {}
            
            
        }

        private void setData()
        {
            string machineCd = _dtData.Rows[_iCurPage - 1]["MACHINE_CD"].ToString();
            string machineId = _dtData.Rows[_iCurPage - 1]["MC_ID"].ToString();
            string hm = _dtData.Rows[_iCurPage - 1]["HM"].ToString();
            _dtDataPage = Data_Select_Machine(_strType, machineCd, machineId, hm);
            _strMachineCode = _dtDataPage.Rows[0]["MC_CODE"].ToString();
            lblTxt1.Text = _dtDataPage.Rows[0]["TXT1"].ToString();
            lblTxt2.Text = _dtDataPage.Rows[0]["TXT2"].ToString();
            lblTxt3.Text = _dtDataPage.Rows[0]["TXT3"].ToString();
            
            GetMinMaxChart(_dtDataPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveDlg = new SaveFileDialog())
            {
                //SaveDlg.RestoreDirectory = true;
                //SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                //if (SaveDlg.ShowDialog() == DialogResult.OK)
                //{
                //    gridView1.ExportToXlsx(SaveDlg.FileName);
                //}


            }
        }

        private void cmDay_Click(object sender, EventArgs e)
        {
            _strType = "D";
           // SetHeader("D");
            SetButtonClick("D");
           // SetData("D");
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            _strType = "W";
           // SetHeader("W");
            SetButtonClick("W");
           //SetData("W");
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            _strType = "M";
          //  SetHeader("M");
            SetButtonClick("M");
           // SetData("M");
        }

        private void SetButtonClick(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    cmdDay.Enabled = false;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = true;
                    break;
                case "W":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = false;
                    cmdMonth.Enabled = true;
                    break;
                case "M":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = false;
                    break;
            }

            try
            {
                setData();
            }
            catch { }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            setClick("NEXT");
            setData();
            BindingChartData2();
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            setClick("PREV");
            setData();
            BindingChartData2();
        }

        private void chkMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMachine.Checked)
                PM_Detail_Check();
        }

        private void rdPmHis_CheckedChanged(object sender, EventArgs e)
        {
            if (rdPmHis.Checked)
                PM_Detail_Check();
        }

        private void rdRepair_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRepair.Checked)
                PM_Detail_Check();
        }

        int iCount = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_dtDataPage == null) return;

                if (iCount >= _dtDataPage.Rows.Count)
                {
                    iCount = 0;
                }
                if (dataPoints.Count < ViewportPointCount)
                {
                    for (int i = 0; i < ViewportPointCount; i++)
                    {
                        string setTime1 = _dtDataPage.Rows[i]["SET_TIME"].ToString();
                        double SV_MINF = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MIN"]);
                        double SV_MAXF = Convert.ToDouble(_dtDataPage.Rows[i]["SV_MAX"]);
                        double FINAL_PVF = Convert.ToDouble(_dtDataPage.Rows[i]["FINAL_PV"]);
                        //   double RATIO1 = Convert.ToDouble(_dtDataPage.Rows[i]["SET_RATIO"]);
                        dataPoints.Add(new DataRealPoint(setTime1, SV_MINF, SV_MAXF, FINAL_PVF));
                    }
                    iCount = ViewportPointCount;
                }


                string setTime = _dtDataPage.Rows[iCount]["SET_TIME"].ToString();
                double SV_MIN = Convert.ToDouble(_dtDataPage.Rows[iCount]["SV_MIN"]);
                double SV_MAX = Convert.ToDouble(_dtDataPage.Rows[iCount]["SV_MAX"]);
                double FINAL_PV = Convert.ToDouble(_dtDataPage.Rows[iCount]["FINAL_PV"]);
                //   double RATIO = Convert.ToDouble(_dtDataPage.Rows[iCount]["SET_RATIO"]);
                if (iCount > 10 && iCount < 30)
                {
                    dataPoints.Add(new DataRealPoint(setTime, null, null, null));
                }
                else
                {
                    dataPoints.Add(new DataRealPoint(setTime, SV_MIN, SV_MAX, FINAL_PV));
                }

                iCount++;
                if (dataPoints.Count > ViewportPointCount)
                {
                    dataPoints.RemoveAt(0);
                }
                if (iCount >= _dtDataPage.Rows.Count)
                {
                    isLoop = false;
                    iCount = 0;
                    timer1.Stop();
                     BindingChartData2();
                    // tmrDelay.Start();
                }
            }
            catch 
            {
            }
            
        }
    }

 



    public class DataRealPoint
    {
        //public DateTime Argument { get; set; }
        public string sArgument { get; set; }
        public double? SV_MIN { get; set; }
        public double? SV_MAX { get; set; }
        public double? FINAL_PV { get; set; }
       // public double rATIO { get; set; }
        //public DataPoint(DateTime argument, double value)
        //{
        //    Argument = argument;
        //    Value = value;
        //}
        public DataRealPoint(string Arg_argument, double? Arg_SV_MIN, double? Arg_SV_MAX, double? Arg_FINAL_PV)
        {
            sArgument = Arg_argument;
            SV_MIN = Arg_SV_MIN;
            SV_MAX = Arg_SV_MAX;
            FINAL_PV = Arg_FINAL_PV;
           // rATIO = RATIO; //Ratio 
        }
    }

}
