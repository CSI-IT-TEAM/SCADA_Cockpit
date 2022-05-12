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
        string MachineName = string.Empty;
        bool isHasChild = false, isCheckState = true;
        int _time = 0;
        bool isFirstTime = true;
        DataTable dtData = null;
        const int ReLoad = 60;
        string _opcd = "";
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
        private void SMT_SCADA_BOTTOM_COCKPIT_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            dtp_Ym.EditValue = DateTime.Now.ToString("yyyy-MM-dd");
            dtp_Ym.EditValueChanged += new System.EventHandler(dtp_Ym_EditValueChanged);
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= ReLoad)
            {
                _time = 0;
                //GetDataTable();
                GetDataTableTest();
            }
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                BindingData();
                if (isFirstTime)
                {
                    isFirstTime = false;
                    chkAll.Checked = true;
                    _time = ReLoad;
                }
                else
                {
                    _time = ReLoad;
                }
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
        private void BindingData()
        {
            _opcd = ComVar.Var._strValue1;
            DataTable dt = SP_MENU_SELECT("Q", ComVar.Var._strValue2, DateTime.Now.ToString("yyyyMMdd"), "SCADA_B_COCKPIT", _opcd);
            if (dt == null) return;
            else
            {
                dtData = GetData(ComVar.Var._strValue2, _opcd, "ALL", ""); //Get All data temperature once time.
                BindingTree(dt);
            }
        }
        #region TreeList
        public void BindingTree(DataTable dt)
        {
            isHasChild = false;
            treeListColumn1.Caption = "_";
            treeList.DataSource = null;
            if (dt == null) return;
            MachineName = dt.Rows.Count > 0 ? dt.Rows[0]["BUTTON_MAPPING_NAME"].ToString() : "Machine";
            treeListColumn1.Caption = MachineName;
            treeList.DataSource = dt;
            treeList.KeyFieldName = "ID";
            treeList.ParentFieldName = "PARENTID";
            Skin skin = GridSkins.GetSkin(treeList.LookAndFeel);
            skin.Properties[GridSkins.OptShowTreeLine] = true;
            chkAll.Checked = true;
            foreach (TreeListNode node in treeList.Nodes)
            {
                var dataRow = treeList.GetDataRecordByNode(node);
                node.Tag = dataRow;
                node.Expanded = true;
                node.Checked = true;

                foreach (TreeListNode node1 in node.RootNode.Nodes)
                {
                    if (node.Checked)
                        node1.Checked = true;


                }
            }
            //chkAll.Checked = false;
            //chkAll.Checked = true;
        }

        #endregion

        #region Loading Data
        private void GetDataTable()
        {
            List<DataTable> lstData = new List<DataTable>();
            List<string> lstSeriesName = new List<string>();
            DataTable dt = dtData.Copy();//Giu lai datatable goc, de su dung lai.
            isCheckState = false;
            if (dt.Rows.Count < 2) return;
            foreach (TreeListNode node in treeList.Nodes)
            {
                foreach (TreeListNode Childnode in node.RootNode.Nodes)
                {
                    if (Childnode.Checked)
                    {
                        isHasChild = true;
                        string NodeID = Childnode.GetValue("ID").ToString().Substring(4);
                        string NodeName = Childnode.GetValue("MENU_NM").ToString();
                        if (dt.Select("ID = '" + NodeID + "'").Count() > 0)
                        {
                            DataTable dtTmp = dt.Select("ID = '" + NodeID + "'").CopyToDataTable();
                            lstData.Add(dtTmp);
                            lstSeriesName.Add(NodeName);
                        }
                    }
                }
                if (!isHasChild)
                {
                    if (node.Checked)
                    {
                        string ParNodeID = node.GetValue("ID").ToString().Substring(4);
                        string ParNodeName = node.GetValue("MENU_NM").ToString();
                        if (dt.Select("MLINE_CD = '" + ParNodeID + "'").Count() > 0)
                        {
                            DataTable dtTmp = dt.Select("MLINE_CD = '" + ParNodeID + "'").CopyToDataTable();
                            lstData.Add(dtTmp);
                            lstSeriesName.Add(ParNodeName);
                        }
                    }
                }
            }

            chkAll.CheckedChanged -= chkAll_CheckedChanged;
            chkAll.Checked = treeList.GetAllCheckedNodes().Count == treeList.AllNodesCount;
            chkAll.CheckedChanged += chkAll_CheckedChanged;
            //Doing something with list datatable
            //  MessageBox.Show("Done!");
            DrawChart(lstData, lstSeriesName, cht_Chart, lstData.Count == 1 ? true : false);
        }

        private void GetDataTableTest()
        {
            try
            {
                List<DataTable> lstData = new List<DataTable>();
                List<string> lstSeriesName = new List<string>();
                DataTable dt = new DataTable();
                isCheckState = false;
                dt = dtData.Copy();

                var AllCheckNodes = treeList.GetAllCheckedNodes();
                var TreeMaxLevel = GetDeepestNodeLevel(treeList);

                foreach (var item in AllCheckNodes)
                {
                    if (item.Level == TreeMaxLevel) //Lay Node trong cung
                    {
                        string NodeID = item.GetValue("ID").ToString().Substring(4);
                        string NodeName = item.GetValue("MENU_NM").ToString();
                        if (dt.Select("ID = '" + NodeID + "'").Count() > 0)
                        {
                            DataTable dtTemp = dt.Select("ID = '" + NodeID + "'").CopyToDataTable();
                            lstData.Add(dtTemp);
                            lstSeriesName.Add(NodeName);
                        }
                    }
                }
                chkAll.CheckedChanged -= chkAll_CheckedChanged;
                chkAll.Checked = treeList.GetAllCheckedNodes().Count == treeList.AllNodesCount;
                chkAll.CheckedChanged += chkAll_CheckedChanged;
                DrawChart(lstData, lstSeriesName, cht_Chart, lstData.Count == 1 ? true : false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //returns Level of the deepest node in that TreeList
        public int GetDeepestNodeLevel(TreeList treeList)
        {
            int level = -1;
            foreach (TreeListNode node in treeList.Nodes)
            {
                int deep = DigInNodes(node);
                if (deep > level)
                    level = deep;
            }
            return level;
        }
        private int DigInNodes(TreeListNode node)
        {
            int level = node.Level;
            foreach (TreeListNode subnode in node.Nodes)
            {
                int deep = DigInNodes(subnode);
                if (deep > level)
                    level = deep;
            }
            return level;
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

        private void DrawChart(List<DataTable> lstData, List<string> listSeriesName, ChartControl _chart, bool isDrawSpec)
        {
            try
            {

                int minRow = 0, minRange = 0, maxRange = 0;
                const int iThickness = 3;
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
                if (lstData.Count == 0) return;
                for (int i = 0; i < lstData.Count; i++) //Khoi tao so luong series & add vao list Series
                {
                    Series series = new Series(listSeriesName[i], ViewType.Spline);
                    DevExpress.XtraCharts.SplineSeriesView splineSeriesView = new DevExpress.XtraCharts.SplineSeriesView();
                    splineSeriesView.LineStyle.Thickness = iThickness;
                    //splineSeriesView.AxisX.Title.Text = "Temperature (°C)";
                    //splineSeriesView.AxisY.Title.Text = "Time";


                    //if (i == 0 && lstData.Count == 1)
                    //{
                    //    //    DevExpress.XtraCharts.XYMarkerSlideAnimation slideAnimation = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
                    //    //    slideAnimation.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromRight;
                    //    //    //slideAnimation.PointDelay = System.TimeSpan.Parse("00:00:00.01000000");
                    //    //    splineSeriesView.LineMarkerOptions.BorderColor = Color.Yellow;
                    //    //    splineSeriesView.LineMarkerOptions.Color = Color.Yellow;
                    //    //    splineSeriesView.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
                    //    //    splineSeriesView.SeriesPointAnimation = slideAnimation;
                    //}
                    series.View = splineSeriesView;
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
                //if (lstData.Count != 1)
                //    if (((XYDiagram)_chart.Diagram).AxisY.ConstantLines.Count > 0)
                //        ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.Clear();

                if (isDrawSpec)
                {
                    ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.Clear();
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
                    constantLine1.LineStyle.Thickness = iThickness;
                    constantLine2.Title.Visible = false;
                    constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //constantLine1.Title.Text = "Target";
                    constantLine2.LineStyle.Thickness = iThickness;
                    // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                    ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });
                }
                _chart.Legend.BackColor = Color.Black;
                //Whole Range Truc Y
                //if (!ComVar.Var._strValue2.Equals("IP_UV_ZONE"))
                //{
                    ((XYDiagram)_chart.Diagram).AxisY.WholeRange.Auto = true;
                    ((XYDiagram)_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(minRange - 5, maxRange + 5);
                //}
                ((XYDiagram)_chart.Diagram).AxisY.GridLines.Visible = false;
                ((XYDiagram)_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Text = "Time";
                ((XYDiagram)_chart.Diagram).AxisX.Title.TextColor = Color.Orange;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)_chart.Diagram).AxisY.Label.Visible = true;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Text = "Temperature  (°C)";
                ((XYDiagram)_chart.Diagram).AxisY.Title.TextColor = Color.Yellow;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            catch (Exception ex)
            {

            }
        }

        //private void DrawChart(DataTable dtChart, ChartControl _chart)
        //{
        //    try
        //    {
        //        DataTable dt1 = null;
        //        DataTable dt2 = null;
        //        int iRow = 0;

        //        dt1 = dtChart.Select("MLINE_CD = 'BB101'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB101'", "HMS").CopyToDataTable() : null; //GetData Mline: BB101
        //        dt2 = dtChart.Select("MLINE_CD = 'BB102'", "HMS").Count() > 0 ? dtChart.Select("MLINE_CD = 'BB102'", "HMS").CopyToDataTable() : null; //GetData Mline: BB102
        //        if (dt1 == null && dt2 != null)
        //        {
        //            iRow = dt2.Rows.Count;
        //        }
        //        else if (dt2 == null && dt1 != null)
        //        {
        //            iRow = dt1.Rows.Count;
        //        }
        //        else if (dt1 != null && dt2 != null)
        //        {
        //            if (dt1.Rows.Count <= dt2.Rows.Count)
        //                iRow = dt1.Rows.Count;
        //            else
        //                iRow = dt2.Rows.Count;
        //        }
        //        /*---------------------------Create----------------------------------*/
        //        //Clear Chart
        //        _chart.Series.Clear();
        //        if (dt1 == null && dt2 == null)
        //        {
        //            return;
        //        }
        //        _chart.Titles.Clear();
        //        _chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;

        //        Series series1 = new Series("MC 1", ViewType.Spline);
        //        Series series2 = new Series("MC 2", ViewType.Spline);

        //        DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
        //        DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

        //        DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

        //        DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
        //        DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
        //        DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

        //        /*---------------------------Add DataPoint----------------------------------*/
        //        if (dt1 != null)
        //        {
        //            if (dt1.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < iRow; i++)
        //                {
        //                    if (dt2 == null)
        //                    {
        //                        series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
        //                    }
        //                    else
        //                    {
        //                        if (dt1.Rows.Count <= dt2.Rows.Count)
        //                        {
        //                            series1.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
        //                        }
        //                        else
        //                        {
        //                            series1.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt1.Rows[i]["VALUE"]));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        series1.ArgumentScaleType = ScaleType.Qualitative;

        //        if (dt2 != null)
        //        {
        //            if (dt2.Rows.Count > 0)
        //            {
        //                for (int i = 0; i < iRow; i++)
        //                {
        //                    if (dt1 == null)
        //                    {
        //                        series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
        //                    }
        //                    else
        //                    {
        //                        if (dt1.Rows.Count <= dt2.Rows.Count)
        //                        {
        //                            series2.Points.Add(new SeriesPoint(dt1.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
        //                        }
        //                        else
        //                        {
        //                            series2.Points.Add(new SeriesPoint(dt2.Rows[i]["HMS"].ToString(), dt2.Rows[i]["VALUE"]));
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        series2.ArgumentScaleType = ScaleType.Qualitative;

        //        //Add Series
        //        _chart.SeriesSerializable = new Series[] { series1, series2 };
        //        //title
        //        //DevExpress.XtraCharts.ChartTitle chartTitle = new DevExpress.XtraCharts.ChartTitle();
        //        //chartTitle.Alignment = System.Drawing.StringAlignment.Near;
        //        //chartTitle.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
        //        //chartTitle.TextColor = System.Drawing.Color.Blue;
        //        //_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle });

        //        //Constant line
        //        //constantLine1.ShowInLegend = false;
        //        constantLine1.AxisValueSerializable = dtChart.Rows[4]["MIN_VL"].ToString();
        //        constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //        constantLine1.Name = "Min";
        //        constantLine2.AxisValueSerializable = dtChart.Rows[5]["MAX_VL"].ToString();
        //        constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //        constantLine2.Name = "Max";
        //        // constantLine1.ShowBehind = false;
        //        constantLine1.Title.Visible = false;
        //        constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        //constantLine1.Title.Text = "Target";
        //        constantLine1.LineStyle.Thickness = 3;
        //        constantLine2.Title.Visible = false;
        //        constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        //constantLine1.Title.Text = "Target";
        //        constantLine2.LineStyle.Thickness = 3;
        //        // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
        //        ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.Clear();
        //        ((XYDiagram)cht_Chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

        //        // format Series 


        //        splineSeriesView1.LineStyle.Thickness = 3;

        //        series2.View = splineSeriesView1;

        //        xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
        //        splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;

        //        ((XYDiagram)_chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = true;

        //        ((XYDiagram)_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
        //        ((XYDiagram)_chart.Diagram).AxisX.Label.Visible = true;
        //        ((XYDiagram)_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        //        ((XYDiagram)_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);

        //        ((XYDiagram)_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion

        #region DataBase
        public DataTable GetData(string argType, string argOPCD, string argMC, string argMILINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            MyOraDB.ShowErr = true;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT_01.SMT_SCADA_BOTTOM_HISTORY";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_ROLL_OP_CD";
                MyOraDB.Parameter_Name[3] = "V_P_MC_ID";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argType;
                MyOraDB.Parameter_Values[1] = dtp_Ym.DateTime.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = argOPCD;
                MyOraDB.Parameter_Values[3] = argMC;
                MyOraDB.Parameter_Values[4] = argMILINE_CD;
                MyOraDB.Parameter_Values[5] = "";

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
        private DataTable SP_MENU_SELECT(string argQtype, string argItems, string argDate, string argUserID, string argbutton)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.SELECT_MENU";
                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_ITEMS";
                MyOraDB.Parameter_Name[2] = "ARG_DATE";
                MyOraDB.Parameter_Name[3] = "ARG_USER_ID"; //ARG_BUTTON_CODE
                MyOraDB.Parameter_Name[4] = "ARG_BUTTON_CODE";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argQtype;
                MyOraDB.Parameter_Values[1] = argItems;
                MyOraDB.Parameter_Values[2] = argDate;
                MyOraDB.Parameter_Values[3] = argUserID;
                MyOraDB.Parameter_Values[4] = argbutton;
                MyOraDB.Parameter_Values[5] = "";
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
        private void treeList_AfterCheckNode(object sender, NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
                e.Node.ParentNode.Checked = IsAllChecked(e.Node.ParentNode.Nodes);
            else
                SetCheckedChildNodes(e.Node.Nodes);
            //GetDataTable();
            GetDataTableTest();
        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (chkAll.Checked)
                {
                    treeList.CheckAll();
                    //foreach (TreeListNode node in treeList.Nodes)
                    //{
                    //    node.Checked = true;
                    //    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    //    {
                    //        node1.Checked = true;
                    //    }
                    //}
                }
                if (!chkAll.Checked)
                {
                    treeList.UncheckAll();
                    //foreach (TreeListNode node in treeList.Nodes)
                    //{
                    //    node.Checked = false;
                    //    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    //    {
                    //        node1.Checked = false;
                    //    }
                    //}
                }
                //GetDataTable();
                GetDataTableTest();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
            }

        }
        private void SetCheckedChildNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
            {
                node.Checked = node.ParentNode.Checked;
            }
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

        private void treeList_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                var sColor = treeList.GetRowCellValue(e.Node, treeList.Columns["STATUS"]).ToString();
                if (sColor.Equals("1"))
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dtp_Ym_EditValueChanged(object sender, EventArgs e)
        {
            BindingData();
            //GetDataTable();
            GetDataTableTest();
        }
    }
}
