using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace FORM.FRM.UC
{
    public partial class UC_CHART : UserControl
    {
        public UC_CHART()
        {
            InitializeComponent();
        }
        public delegate void ChartClickHandler(string ChartName, bool isClickNew);
        public ChartClickHandler OnChartClick = null;
        private string Chart, ChartTemp, _No;
        public void BindingChart(int No, DataTable dt)
        {
            try
            {
                if (dt.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dt.Rows[0][string.Concat(No.ToString(), "_", "VL")].ToString()))
                    {
                        chartControl1.DataSource = null;
                        ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.Clear();
                        chartControl1.Titles[0].Text = "Controller";
                        chartControl1.Series[0].Name = "Controller";
                        btnZoom.Visible = false;
                    }
                    else
                    {
                        btnZoom.Visible = true;
                        chartControl1.DataSource = dt;
                        //CHART COMPANY
                        //Khoi tao 4 duong MIN,MAX,LSL,USL
                        DevExpress.XtraCharts.ConstantLine LINE_MIN = new DevExpress.XtraCharts.ConstantLine();
                        DevExpress.XtraCharts.ConstantLine LINE_MAX = new DevExpress.XtraCharts.ConstantLine();
                        //DevExpress.XtraCharts.ConstantLine LINE_LSL = new DevExpress.XtraCharts.ConstantLine();
                        //DevExpress.XtraCharts.ConstantLine LINE_USL = new DevExpress.XtraCharts.ConstantLine();

                        DevExpress.XtraCharts.ConstantLine LINE_SV = new DevExpress.XtraCharts.ConstantLine();

                        chartControl1.Series[0].Name = string.Concat("PV (Process Value)");
                        chartControl1.Series[0].ArgumentDataMember = "LB";
                        chartControl1.Titles[0].Text = string.Concat("Controller", " ", No.ToString() + ": " + dt.Rows[0][string.Concat(No.ToString(), "_", "CRT")].ToString());
                        //chartControl1.Titles[0].Text = string.Concat("Present Value (PV)"); 
                        chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { string.Concat(No.ToString(), "_", "VL") });
                        chartControl1.Series[0].Label.LineStyle.Thickness = 10;
                        ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.SetMinMaxValues(dt.Rows[0][string.Concat(No.ToString(), "_", "axis_min")], dt.Rows[0][string.Concat(No.ToString(), "_", "axis_max")]);


                        //ADD 4 DUONG VAO CHART
                        LINE_SV.AxisValueSerializable = dt.Rows[0][string.Concat(No.ToString(), "_", "SV")].ToString();
                        LINE_SV.Color = System.Drawing.Color.ForestGreen;
                        LINE_SV.LineStyle.Thickness = 2;
                        LINE_SV.Name = "";// "MIN";
                        LINE_SV.Name = "SV (Set Value)";
                        LINE_SV.Title.Visible = false;

                        LINE_MIN.AxisValueSerializable = dt.Rows[0][string.Concat(No.ToString(), "_", "VL_MIN")].ToString();
                        LINE_MIN.Color = System.Drawing.Color.Red;
                        LINE_MIN.LineStyle.Thickness = 2;
                        LINE_MIN.Name = "";// "MIN";
                        LINE_MIN.Name = "MIN";
                        LINE_MIN.Title.Visible = false;

                        LINE_MAX.AxisValueSerializable = dt.Rows[0][string.Concat(No.ToString(), "_", "VL_MAX")].ToString();
                        LINE_MAX.Color = System.Drawing.Color.Red;
                        LINE_MAX.LineStyle.Thickness = 2;
                        LINE_MAX.Name = "";//"MAX";
                        LINE_MAX.Name = "MAX";
                        LINE_MAX.Title.Visible = false;

                        /*
                        LINE_LSL.AxisValueSerializable = dt.Rows[0][string.Concat(No.ToString(), "_", "VL_LSL")].ToString();
                        LINE_LSL.Color = System.Drawing.Color.Yellow;
                        LINE_LSL.LineStyle.Thickness = 1;
                        LINE_LSL.Name = "";//"LSL";

                        LINE_USL.AxisValueSerializable = dt.Rows[0][string.Concat(No.ToString(), "_", "VL_USL")].ToString();
                        LINE_USL.Color = System.Drawing.Color.Yellow;
                        LINE_USL.LineStyle.Thickness = 1;
                        LINE_USL.Name = "";//"USL";
                        */
                        ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.Clear();
                        ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { LINE_SV, LINE_MIN, LINE_MAX });//,LINE_LSL,LINE_USL});                   
                    }
                }
                else
                {
                    chartControl1.DataSource = null;
                    ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.Clear();
                    chartControl1.Titles[0].Text = "Controller";
                    chartControl1.Series[0].Name = "Controller";
                    btnZoom.Visible = false;
                }
                Chart = _No = No.ToString();
            }
            catch (Exception ex)
            {
                chartControl1.DataSource = null;
                throw ex;
            }
        }
        private void FormatChart(bool isClickNew)
        {
            if (chartControl1.Titles.Count > 0)
            {
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                splineSeriesView1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.False;
                splineSeriesView1.LineMarkerOptions.BorderVisible = false;
                splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Blue;//FromArgb(((int)(((byte)(128)))), ((int)(((byte)(100)))), ((int)(((byte)(162)))));
                splineSeriesView1.LineMarkerOptions.Size = 5;
                splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

                switch (isClickNew)
                {
                    case true: //Chart Normal
                        chartControl1.Titles[0].Font = new Font("Tahoma", 10F);
                        splineSeriesView1.LineStyle.Thickness = 2;
                        splineSeriesView1.LineMarkerOptions.Size = 5;

                        break;
                    case false: //Chart zoom out
                        chartControl1.Titles[0].Font = new Font("Tahoma", 20F);
                        splineSeriesView1.LineStyle.Thickness = 3;
                        splineSeriesView1.LineMarkerOptions.Size = 7;
                        break;
                    default:
                        break;
                }
                chartControl1.Series[0].View = splineSeriesView1;
            }
        }
        bool isClickNew = false;
        private void chartControl1_Click(object sender, EventArgs e)
        {
           //nothing
        }
        private void btnZoom_Click(object sender, EventArgs e)
        {
            try
            {
                FormatChart(isClickNew);
                if (isClickNew && Chart.Equals(ChartTemp))
                {
                    isClickNew = false;
                    btnZoom.BackgroundImage = Properties.Resources.zoomin;
                }
                else
                {
                    isClickNew = true;
                    Chart = _No;
                    btnZoom.BackgroundImage = Properties.Resources.zoom_out;
                }
                ChartTemp = Chart;
                if (OnChartClick != null)
                    OnChartClick(Chart, isClickNew);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
