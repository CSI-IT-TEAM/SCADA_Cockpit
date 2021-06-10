using DevExpress.Skins;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
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
        const int ReLoad = 60;
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
        private void SMT_SCADA_BOTTOM_COCKPIT_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= ReLoad)
            {
                _time = 0;
                DataTable dt = SP_MENU_SELECT("Q", "SCADA_B_COCKPIT");
                BindingTree(dt);
                dtData = GetData("Q", "ALL", "ALL"); //Get All data temperature once time.
                if (isFirstTime)
                {
                    isFirstTime = !isFirstTime;
                    chkAll.Checked = true;
                }
                // LoadingDataChart();
            }
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                _time = 59;
                tmrTime.Start();
            }
            else
            {
                tmrTime.Stop();
            }
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
        #region TreeList
        public void BindingTree(DataTable dt)
        {
            treeList.DataSource = dt;
            treeList.KeyFieldName = "ID";
            treeList.ParentFieldName = "PARENTID";
            Skin skin = GridSkins.GetSkin(treeList.LookAndFeel);
            skin.Properties[GridSkins.OptShowTreeLine] = true;

            foreach (TreeListNode node in treeList.Nodes)
            {
                var dataRow = treeList.GetDataRecordByNode(node);
                node.Tag = dataRow;
                //node.Checked = true;
                node.Expanded = true;
                //foreach (TreeListNode node1 in node.RootNode.Nodes)
                //{
                //    if (node.Checked)
                //        node1.Checked = true;
                //}
            }

        }

        #endregion

        #region Loading Data
        private void GetDataTable()
        {
            List<DataTable> lstData = new List<DataTable>();
            DataTable dt = dtData.Copy();//Giu lai datatable goc, de su dung lai.
            if (dt == null) return;
            foreach (TreeListNode node in treeList.Nodes)
            {
                foreach (TreeListNode Childnode in node.RootNode.Nodes)
                {
                    if (Childnode.Checked)
                    {
                        string NodeID = Childnode.GetValue("ID").ToString();
                        if (dt.Select("ID = '" + NodeID + "'").Count() > 0)
                        {
                            DataTable dtTmp = dt.Select("ID = '" + NodeID + "'").CopyToDataTable();
                            lstData.Add(dtTmp);
                        }
                    }

                }
            }

            //Doing something with list datatable
            //  MessageBox.Show("Done!");
            DrawChartTest(lstData, cht_Chart, lstData.Count > 1 ? false : true);
        }


        private void LoadingDataChart()
        {
            try
            {
                dtData = GetData("Q", "ALL", "ALL");        /*Get All Data*/
                int cnt1 = 0, cnt2 = 0;
                DataTable dtTmp = null;
                dtTmp = dtData.Copy();
                if (dtTmp != null && dtTmp.Rows.Count > 0)
                {
                    foreach (TreeListNode node in treeList.Nodes)
                    {

                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            cnt1++;
                            if (!node1.Checked)
                            {
                                cnt2++;
                                if (dtTmp.Select("ID <> '" + node1.GetValue("ID").ToString() + "'", "").Count() > 0)
                                {
                                    dtTmp = dtTmp.Select("ID <> '" + node1.GetValue("ID").ToString() + "'", "").CopyToDataTable();
                                }
                            }
                        }
                    }
                    if (cnt1 == cnt2)
                        while (dtTmp.Rows.Count > 0)
                        {
                            dtTmp.Rows.RemoveAt(0);
                        }

                    DrawChart(dtTmp, cht_Chart);
                }
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

        private void DrawChartTest(List<DataTable> lstData, ChartControl _chart, bool isDrawSpec)
        {
            try
            {
                int minRow = 0, minRange = 0, maxRange = 0;
                //List Range Min, Range Max;
                List<int> lstRgMin = new List<int>();
                List<int> lstRgMax = new List<int>();

                DataTable dtarg = new DataTable();
                List<int> lstRowCount = new List<int>();
                List<Series> lstSeries = new List<Series>();
                _chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (lstData[i].Rows[0]["MIN_VL"] != null)
                    {
                        int MinVl = int.Parse(lstData[i].Rows[0]["MIN_VL"].ToString());
                        lstRgMin.Add(MinVl);
                    }
                    if (lstData[i].Rows[0]["MAX_VL"] != null)
                    {
                        int MaxVl = int.Parse(lstData[i].Rows[0]["MAX_VL"].ToString());
                        lstRgMax.Add(MaxVl);
                    }

                    lstRowCount.Add(lstData[i].Rows.Count);

                }
                minRow = GetMinValue(lstRowCount);   //Tim datatable co so dong nho nhat.
                minRange = GetMinValue(lstRgMin);
                maxRange = GetMaxValue(lstRgMax);
                _chart.Series.Clear(); //Remove het series truoc khi add moi.

                for (int i = 0; i < lstData.Count; i++) //Khoi tao so luong series & add vao list Series
                {
                    Series series = new Series("MC " + (i + 1), ViewType.Spline);
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    lstSeries.Add(series);
                    if (minRow == lstData[i].Rows.Count)
                    {
                        dtarg = lstData[i];
                    }

                }
                for (int j = 0; j < minRow; j++)
                {
                    for (int k = 0; k < lstSeries.Count; k++)
                    {
                        lstSeries[k].Points.Add(new SeriesPoint(dtarg.Rows[j]["HMS"].ToString(), lstData[k].Rows[j]["VALUE"]));
                    }

                }

                for (int h = 0; h < lstSeries.Count; h++)
                {
                    _chart.Series.Add(lstSeries[h]);
                }
                ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.Clear();
                if (isDrawSpec)
                {
                    DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                    DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine(); ////Constant line
                    //constantLine1.ShowInLegend = false;
                    constantLine1.AxisValueSerializable = dtarg.Rows[0]["MIN_VL"].ToString();
                    constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    constantLine1.Name = "Min";
                    constantLine2.AxisValueSerializable = dtarg.Rows[0]["MAX_VL"].ToString();
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
                    ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });
                }

                //Whole Range Truc Y
                     ((XYDiagram)_chart.Diagram).AxisY.WholeRange.Auto = true;
                ((XYDiagram)_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(minRange - 5, maxRange + 5);



                //DataTable dt1 = null;
                //DataTable dt2 = null;
                //int iRow = 0;

                //dt1 = dtChart.Select("MLINE_CD = 'BB101'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB101'", "HMS").CopyToDataTable() : null; //GetData Mline: BB101
                //dt2 = dtChart.Select("MLINE_CD = 'BB102'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB102'", "HMS").CopyToDataTable() : null; //GetData Mline: BB102
                //if (dt1 == null && dt2 != null)
                //{
                //    iRow = dt2.Rows.Count;
                //}
                //else if (dt2 == null && dt1 != null)
                //{
                //    iRow = dt1.Rows.Count;
                //}
                //else if (dt1 != null && dt2 != null)
                //{
                //    if (dt1.Rows.Count <= dt2.Rows.Count)
                //        iRow = dt1.Rows.Count;
                //    else
                //        iRow = dt2.Rows.Count;
                //}
                ///*---------------------------Create----------------------------------*/
                ////Clear Chart
                //_chart.Series.Clear();
                //if (dt1 == null && dt2 == null)
                //{
                //    return;
                //}
                //_chart.Titles.Clear();
                //_chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;

                //Series series1 = new Series("MC 1", ViewType.Spline);
                //Series series2 = new Series("MC 2", ViewType.Spline);

                //DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                //DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

                //DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

                //DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
                //DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                //DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                ///*---------------------------Add DataPoint----------------------------------*/
                //if (dt1 != null)
                //{
                //    if (dt1.Rows.Count > 0)
                //    {
                //        for (int i = 0; i < iRow; i++)
                //        {
                //            if (dt2 == null)
                //            {
                //                series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                //            }
                //            else
                //            {
                //                if (dt1.Rows.Count <= dt2.Rows.Count)
                //                {
                //                    series1.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                //                }
                //                else
                //                {
                //                    series1.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                //                }
                //            }
                //        }
                //    }
                //}
                //series1.ArgumentScaleType = ScaleType.Qualitative;

                //if (dt2 != null)
                //{
                //    if (dt2.Rows.Count > 0)
                //    {
                //        for (int i = 0; i < iRow; i++)
                //        {
                //            if (dt1 == null)
                //            {
                //                series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                //            }
                //            else
                //            {
                //                if (dt1.Rows.Count <= dt2.Rows.Count)
                //                {
                //                    series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                //                }
                //                else
                //                {
                //                    series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                //                }
                //            }
                //        }
                //    }
                //}
                //series2.ArgumentScaleType = ScaleType.Qualitative;

                ////Add Series
                //_chart.SeriesSerializable = new Series[] { series1, series2 };
                ////title
                ////DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                ////chartTitle.Alignment = System.Drawing.StringAlignment.Near;
                ////chartTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
                ////chartTitle.TextColor = System.Drawing.Color.Blue;
                ////_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });

                ////Constant line
                ////constantLine1.ShowInLegend = false;
                //constantLine1.AxisValueSerializable = dtChart.Rows[4]["MIN_VL"].ToString();
                //constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //constantLine1.Name = "Min";
                //constantLine2.AxisValueSerializable = dtChart.Rows[5]["MAX_VL"].ToString();
                //constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                //constantLine2.Name = "Max";
                //// constantLine1.ShowBehind = false;
                //constantLine1.Title.Visible = false;
                //constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ////constantLine1.Title.Text = "Target";
                //constantLine1.LineStyle.Thickness = 3;
                //constantLine2.Title.Visible = false;
                //constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ////constantLine1.Title.Text = "Target";
                //constantLine2.LineStyle.Thickness = 3;
                //// constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                //((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.Clear();
                //((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

                //// format Series 


                //splineSeriesView1.LineStyle.Thickness = 3;

                //series2.View = splineSeriesView1;

                //xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                //splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;

                //((XYDiagram)_chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = true;

                //((XYDiagram)_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
                //((XYDiagram)_chart.Diagram).AxisX.Label.Visible = true;
                //((XYDiagram)_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //((XYDiagram)_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);

                //((XYDiagram)_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            catch
            {

            }
        }

        private void DrawChart(DataTable dtChart, ChartControl _chart)
        {
            try
            {
                DataTable dt1 = null;
                DataTable dt2 = null;
                int iRow = 0;

                dt1 = dtChart.Select("MLINE_CD = 'BB101'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB101'", "HMS").CopyToDataTable() : null; //GetData Mline: BB101
                dt2 = dtChart.Select("MLINE_CD = 'BB102'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB102'", "HMS").CopyToDataTable() : null; //GetData Mline: BB102
                if (dt1 == null && dt2 != null)
                {
                    iRow = dt2.Rows.Count;
                }
                else if (dt2 == null && dt1 != null)
                {
                    iRow = dt1.Rows.Count;
                }
                else if (dt1 != null && dt2 != null)
                {
                    if (dt1.Rows.Count <= dt2.Rows.Count)
                        iRow = dt1.Rows.Count;
                    else
                        iRow = dt2.Rows.Count;
                }
                /*---------------------------Create----------------------------------*/
                //Clear Chart
                _chart.Series.Clear();
                if (dt1 == null && dt2 == null)
                {
                    return;
                }
                _chart.Titles.Clear();
                _chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;

                Series series1 = new Series("MC 1", ViewType.Spline);
                Series series2 = new Series("MC 2", ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                /*---------------------------Add DataPoint----------------------------------*/
                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (dt2 == null)
                            {
                                series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
                            }
                            else
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
                    }
                }
                series1.ArgumentScaleType = ScaleType.Qualitative;

                if (dt2 != null)
                {
                    if (dt2.Rows.Count > 0)
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (dt1 == null)
                            {
                                series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
                            }
                            else
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
                    }
                }
                series2.ArgumentScaleType = ScaleType.Qualitative;

                //Add Series
                _chart.SeriesSerializable = new Series[] { series1, series2 };
                //title
                //DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
                //chartTitle.Alignment = System.Drawing.StringAlignment.Near;
                //chartTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
                //chartTitle.TextColor = System.Drawing.Color.Blue;
                //_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });

                //Constant line
                //constantLine1.ShowInLegend = false;
                constantLine1.AxisValueSerializable = dtChart.Rows[4]["MIN_VL"].ToString();
                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";
                constantLine2.AxisValueSerializable = dtChart.Rows[5]["MAX_VL"].ToString();
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
                ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

                // format Series 


                splineSeriesView1.LineStyle.Thickness = 3;

                series2.View = splineSeriesView1;

                xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;

                ((XYDiagram)_chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = true;

                ((XYDiagram)_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ((XYDiagram)_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);

                ((XYDiagram)_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


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

        /*DataTable TreeList*/
        private DataTable SP_MENU_SELECT(string argQtype, string argUserID)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ConnectName = COM.OraDB.ConnectDB.LMES;
            DataSet ds_ret;
            try
            {
                string process_name = "PKG_PLM.SELECT_PLM_MENU";
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_USER_ID";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = argQtype;
                MyOraDB.Parameter_Values[1] = argUserID;
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

        #endregion

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAll.Checked)
                {
                    foreach (TreeListNode node in treeList.Nodes)
                    {
                        node.Checked = true;
                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            node1.Checked = true;
                        }
                    }
                }
                else
                {
                    foreach (TreeListNode node in treeList.Nodes)
                    {
                        node.Checked = false;
                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            node1.Checked = false;
                        }
                    }
                }
                GetDataTable();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void treeList_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
                e.Node.ParentNode.Checked = IsAllChecked(e.Node.ParentNode.Nodes);
            else
                SetCheckedChildNodes(e.Node.Nodes);

            GetDataTable(); //Test

            //LoadingDataChart();
        }

        private void SetCheckedChildNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
                node.Checked = node.ParentNode.Checked;
        }

        private bool IsAllChecked(TreeListNodes nodes)
        {
            bool value = true;
            foreach (TreeListNode node in nodes)
            {
                if (!node.Checked)
                {
                    value = false;
                    break;
                }
            }
            return value;
        }
    }
}
