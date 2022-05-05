using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM.FRM
{
    public partial class FRM_SCADA_TREND_CRL : Form
    {
        public FRM_SCADA_TREND_CRL()
        {
            InitializeComponent();
            dispatcherTimer.Stop();
        }
        #region variable
        int cLabel = 0;
        DatabaseSCADA db = new DatabaseSCADA();
        DataTable dtRealChart = new DataTable();
        #endregion
        public void GetData(string sDateF, string sDateT, string Line, string Mline, string Area, string Machine, string Controller)
        {
            dtRealChart.Clear();
            dtRealChart = db.GET_DATA("Q", sDateF, sDateT, Line, Mline, Area, Machine, Controller);
            if (dtRealChart != null && dtRealChart.Rows.Count > 0)
            {
                chartTrend.Series.Clear();
                DevExpress.XtraCharts.ConstantLine LINE_MIN = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine LINE_MAX = new DevExpress.XtraCharts.ConstantLine();
                //DevExpress.XtraCharts.ConstantLine LINE_LSL = new DevExpress.XtraCharts.ConstantLine();
                //DevExpress.XtraCharts.ConstantLine LINE_USL = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                DevExpress.XtraCharts.LineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(146)))));
                splineSeriesView1.LineStyle.Thickness = 5;
                splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                series1.View = splineSeriesView1;
                this.chartTrend.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
                ((XYDiagram)chartTrend.Diagram).AxisY.WholeRange.SetMinMaxValues(dtRealChart.Rows[0]["axis_min"], dtRealChart.Rows[0]["axis_max"]);
                LINE_MIN.AxisValueSerializable = dtRealChart.Rows[0]["VL_MIN"].ToString();
                LINE_MIN.Color = System.Drawing.Color.Red;
                LINE_MIN.LineStyle.Thickness = 3;
                LINE_MIN.Name = "MIN";

                LINE_MAX.AxisValueSerializable = dtRealChart.Rows[0]["VL_MAX"].ToString();
                LINE_MAX.Color = System.Drawing.Color.Red;
                LINE_MAX.LineStyle.Thickness = 3;
                LINE_MAX.Name = "MAX";

                //LINE_LSL.AxisValueSerializable = dtRealChart.Rows[0]["VL_LSL"].ToString();
                //LINE_LSL.Color = System.Drawing.Color.Yellow;
                //LINE_LSL.LineStyle.Thickness = 3;
                //LINE_LSL.Name = "LSL";

                //LINE_USL.AxisValueSerializable = dtRealChart.Rows[0]["VL_USL"].ToString();
                //LINE_USL.Color = System.Drawing.Color.Yellow;
                //LINE_USL.LineStyle.Thickness = 3;
                //LINE_USL.Name = "USL";
                ((XYDiagram)chartTrend.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)chartTrend.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {LINE_MIN,LINE_MAX});
                dispatcherTimer.Start();
            }
            else
            {
                chartTrend.Series.Clear();
                dispatcherTimer.Stop();
            }
        }
        public void GetDataBarChart(string sDateF, string sDateT, string Line, string Mline, string Area, string Machine, string Controller)
        {
            try
            {
                DataTable dt = db.GET_DATA_COUNT_CHART("Q", sDateF, sDateT, Line, Mline, Area, Machine, Controller);
                DevExpress.XtraCharts.ConstantLine LINE_MIN = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine LINE_MAX = new DevExpress.XtraCharts.ConstantLine();
                //DevExpress.XtraCharts.ConstantLine LINE_LSL = new DevExpress.XtraCharts.ConstantLine();
                //DevExpress.XtraCharts.ConstantLine LINE_USL = new DevExpress.XtraCharts.ConstantLine();
                chartBarTrend.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    chartBarTrend.Series[0].ArgumentDataMember = "LB";
                    chartBarTrend.Series[0].ValueDataMembers.AddRange(new string[] { "VL" });
                    LINE_MIN.AxisValueSerializable = dtRealChart.Rows[0]["VL_MIN"].ToString();
                    LINE_MIN.Color = System.Drawing.Color.Red;
                    LINE_MIN.LineStyle.Thickness = 3;
                    LINE_MIN.Name = "MIN";

                    LINE_MAX.AxisValueSerializable = dtRealChart.Rows[0]["VL_MAX"].ToString();
                    LINE_MAX.Color = System.Drawing.Color.Red;
                    LINE_MAX.LineStyle.Thickness = 3;
                    LINE_MAX.Name = "MAX";

                    //LINE_LSL.AxisValueSerializable = dtRealChart.Rows[0]["VL_LSL"].ToString();
                    //LINE_LSL.Color = System.Drawing.Color.Yellow;
                    //LINE_LSL.LineStyle.Thickness = 3;
                    //LINE_LSL.Name = "LSL";

                    //LINE_USL.AxisValueSerializable = dtRealChart.Rows[0]["VL_USL"].ToString();
                    //LINE_USL.Color = System.Drawing.Color.Yellow;
                    //LINE_USL.LineStyle.Thickness = 3;
                    //LINE_USL.Name = "USL";
                    ((XYDiagram)chartBarTrend.Diagram).AxisX.ConstantLines.Clear();
                    ((XYDiagram)chartBarTrend.Diagram).AxisX.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            LINE_MIN,LINE_MAX});
                    ((XYDiagram)chartBarTrend.Diagram).AxisX.WholeRange.SetMinMaxValues(Convert.ToInt32(dtRealChart.Rows[0]["VL_MIN"]) - 1, Convert.ToInt32(dtRealChart.Rows[0]["VL_MAX"]) + 1);
                
                    //Fill dữ liệu cho Pie Chart
                    GetDataPieChart(dt);
                }
            }
            catch (Exception ex)
            { }
        }
        public void GetDataPieChart(DataTable _dt)
        {
            DataTable dt = _dt;
            chartPercent.DataSource = dt;
            chartPercent.Series[0].ArgumentDataMember = "LB";
            chartPercent.Series[0].ValueDataMembers.AddRange(new string[] { "VL" });
        }
        private void BindingChartTrend()
        {
            try
            {
                XYDiagram diagram = (XYDiagram)chartTrend.Diagram;
                chartTrend.Series[0].Points.Add(new SeriesPoint(dtRealChart.Rows[cLabel]["LB"].ToString(), dtRealChart.Rows[cLabel]["VL"]));
                chartTrend.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                //((XYDiagram)chartTrend.Diagram).AxisY.WholeRange.SetMinMaxValues(dtRealChart.Rows[cLabel]["axis_min"], dtRealChart.Rows[cLabel]["axis_max"]);
                if (chartTrend.Series[0].Points.Count > 200)
                {
                    chartTrend.Series[0].Points.RemoveAt(0);
                }
                cLabel++;
                if (cLabel > dtRealChart.Rows.Count - 1)
                {
                    chartTrend.Series.Clear();
                    DevExpress.XtraCharts.ConstantLine LINE_MIN = new DevExpress.XtraCharts.ConstantLine();
                    DevExpress.XtraCharts.ConstantLine LINE_MAX = new DevExpress.XtraCharts.ConstantLine();
                    //DevExpress.XtraCharts.ConstantLine LINE_LSL = new DevExpress.XtraCharts.ConstantLine();
                    //DevExpress.XtraCharts.ConstantLine LINE_USL = new DevExpress.XtraCharts.ConstantLine();
                    DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
                    DevExpress.XtraCharts.LineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
                    splineSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(146)))));
                    splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
                    splineSeriesView1.LineStyle.Thickness = 5;
                    series1.View = splineSeriesView1;
                    this.chartTrend.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1 };
                   
                    LINE_MIN.AxisValueSerializable = dtRealChart.Rows[0]["VL_MIN"].ToString();
                    LINE_MIN.Color = System.Drawing.Color.Red;
                    LINE_MIN.LineStyle.Thickness = 3;
                    LINE_MIN.Name = "MIN";

                    LINE_MAX.AxisValueSerializable = dtRealChart.Rows[0]["VL_MAX"].ToString();
                    LINE_MAX.Color = System.Drawing.Color.Red;
                    LINE_MAX.LineStyle.Thickness = 3;
                    LINE_MAX.Name = "MAX";

                    //LINE_LSL.AxisValueSerializable = dtRealChart.Rows[0]["VL_LSL"].ToString();
                    //LINE_LSL.Color = System.Drawing.Color.Yellow;
                    //LINE_LSL.LineStyle.Thickness = 3;
                    //LINE_LSL.Name = "LSL";

                    //LINE_USL.AxisValueSerializable = dtRealChart.Rows[0]["VL_USL"].ToString();
                    //LINE_USL.Color = System.Drawing.Color.Yellow;
                    //LINE_USL.LineStyle.Thickness = 3;
                    //LINE_USL.Name = "USL";
                    ((XYDiagram)chartTrend.Diagram).AxisY.ConstantLines.Clear();
                    ((XYDiagram)chartTrend.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {LINE_MIN,LINE_MAX});
                    
                    cLabel = 0;
                }
            }
            catch (Exception ex)
            { }
        }
        private void BindingChartBarTrend(DataTable _dt)
        {

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            BindingChartTrend();
        }
    }
}
