using DevExpress.Utils;
using DevExpress.XtraCharts;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        DataTable _dtDataPage = null;
        DataTable _dtDataTrend = null;
        DataTable _dtMcId = null;

        int _iCurPage, _iMaxPage;
        double _iMinChart = 0, _iMaxChart = 0;

        ObservableCollection<DataRealPoint> dataPoints = new ObservableCollection<DataRealPoint>();

        #region Function
        private async void SetData()
        {
            try
            {
                DataSet ds = await Data_Select_Sync();
                Grid.DataSource = ds.Tables[0];
                SetText(ds.Tables[1]);
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("SetData()-->" + ex.ToString());
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
                ComVar.Var.writeToLog("SetText()-->" + ex.ToString());
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

        private async Task<DataSet>  Data_Select_Sync()
        {
            return await Task.Run(() =>{
                COM.OraDB MyOraDB = new COM.OraDB();

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
            });
            
        }

        private DataTable Data_Select_Machine(string argType, string argMachineCd, string argMachineId, string argHm)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            //  MyOraDB.ShowErr = true;
            MyOraDB.ReDim_Parameter(5);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.INFOR_SELECT_MACHINE";
            MyOraDB.ShowErr = true;
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

        #region Event

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (Visible)
                {
                    iCount = 59;
                    tabControl.SelectedTabPageIndex = 0;

                    //timer1.Start();
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
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }



        #endregion

        private void tabControl_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            try
            {
                _type = tabControl.SelectedTabPage.Name;
                iCount = 0;
                if (_type == "TREND")
                {
                    _iCurPage = 1;
                    _dtDataTrend = Data_Select_Machine("D", _machine, "", "");
                    _dtMcId = new DataView(_dtDataTrend).ToTable(true, "MC_ID").Select("", "MC_ID").Distinct().CopyToDataTable();
                    _iMaxPage = _dtMcId.Rows.Count;
                    SetClick("");
                    SetDataTrend();
                    BindingChartData2();
                    pnMcId.Visible = true;

                }
                else
                {
                    SetData();
                    pnMcId.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("tabControl_SelectedPageChanged()-->" + ex.ToString());
            }
            
            
            
        }


        #region Trend
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




                chartControl1.Series.Clear();
                chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series2, series3, series };

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
                if (iDataRow >= 20)
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
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                ComVar.Var.writeToLog("BindingChartData2()-->" + ex.ToString());
            }
        }

        private void SetClick(string argStatus)
        {
            try
            {
                if (argStatus == "NEXT")
                {
                    _iCurPage = _iCurPage + 1 > _iMaxPage ? _iMaxPage : _iCurPage + 1;
                }
                else if (argStatus == "PREV")
                {
                    _iCurPage = _iCurPage - 1 <= 0 ? 1 : _iCurPage - 1;
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
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("SetClick()-->" + ex.ToString());
            }
            
        }

        private void SetDataTrend()
        {
            try
            {
                _dtDataPage = _dtDataTrend.Select($"MC_ID = '{_dtMcId.Rows[_iCurPage - 1][0]}'").CopyToDataTable();
                //_strMachineCode = _dtDataPage.Rows[0]["MC_CODE"].ToString();
                // lblTxt1.Text = _dtDataPage.Rows[0]["TXT1"].ToString();
                // lblTxt2.Text = _dtDataPage.Rows[0]["TXT2"].ToString();
                // lblTxt3.Text = _dtDataPage.Rows[0]["TXT3"].ToString();

                GetMinMaxChart(_dtDataPage);
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("SetDataTrend()-->" + ex.ToString());
            }
            

            
        }

        private void SMT_SCADA_POPUP_INFOR_Load(object sender, EventArgs e)
        {
            _machine = System.IO.File.ReadAllText(ComVar.Var._strValue5);
            //SetData();
            
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


        private void cmdNext_Click(object sender, EventArgs e)
        {
            SetClick("NEXT");
            SetDataTrend();
            BindingChartData2();
        }

        private void cmdPrev_Click(object sender, EventArgs e)
        {
            SetClick("PREV");
            SetDataTrend();
            BindingChartData2();
        }

        #endregion

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
