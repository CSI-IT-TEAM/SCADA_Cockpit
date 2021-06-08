using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;
using DevExpress.XtraCharts;

namespace FORM.UC
{
    public partial class UC_Chart_Bar : UserControl
    {
        public UC_Chart_Bar()
        {
            InitializeComponent();

        }

        public void SetData(DataTable argDtData)
        {
            
            chartControl1.DataSource = argDtData;
            chartControl1.Series[0].ArgumentDataMember = "MACHINE_CD";
            chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "OCR_TIME" });

        }
        
        private void setChartTitle(string argTitle)
        {
            chartControl1.Titles.Clear();
            // Create chart titles.
            ChartTitle chartTitle1 = new ChartTitle();

            // Define the text for the titles.
            // chartTitle1.Text = "<i>Basic</i> <b>HTML</b> <u>is</u> <color=blue>supported</color>.";
            chartTitle1.Text = argTitle;


            // Define the alignment of the titles.
            chartTitle1.Alignment = StringAlignment.Center;

            // Place the titles where it's required.
            chartTitle1.Dock = ChartTitleDockStyle.Top;

            // Customize a title's appearance.
            chartTitle1.Antialiasing = true;
            chartTitle1.Font = new Font("Tahoma", 14, FontStyle.Bold);
           // chartTitle1.TextColor = Color.Red;
            chartTitle1.Indent = 10;

            // Add the titles to the chart.
            chartControl1.Titles.AddRange(new ChartTitle[] {chartTitle1});
        }
    }
}
