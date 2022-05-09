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
using System.Data.OracleClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FORM.UC
{
    public partial class UC_COMPARE_WEEK : UserControl
    {
        public UC_COMPARE_WEEK()
        {
            InitializeComponent();
            SetData();
        }
        int _iReload = 0;
        public string _strType = "D";

        public async void SetData()
        {
            try
            {
                Debug.WriteLine("load");
                Cursor.Current = Cursors.WaitCursor;
                InitUc();
                
                DataSet ds = await Task.Run(() => Data_Select_Compare(_strType));
                if (ds == null) return;
                DataTable dt = ds.Tables[0];
                if (dt == null ) return;

                //  OCR_TIME.Caption = "Issues Machine\n(Count)";
                chartControl1.DataSource = dt;
                chartControl1.Series[0].ArgumentDataMember = "TEXT";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "CNT" });

                //Grid
                gridControl1.DataSource = dt.Select("1=1", "TEXT DESC").CopyToDataTable(); 
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public void InitUc()
        {
            if (_strType=="W")
            {
                pnGrid.Visible = true;
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                diagram.AxisX.Title.Text = "Week";
                setChartTitle("Issue Machine By Week");
            }
            else if (_strType == "D")
            {
                pnGrid.Visible = false;
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                diagram.AxisX.Title.Text = "Days";
                setChartTitle("Issue Machine Average By Day");

            }
            else
            {
                pnGrid.Visible = false;
                XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                diagram.AxisX.Title.Text = "Days";
                setChartTitle("Issue Machine By Month");
            }
        }


        private DataSet Data_Select_Compare(string argType, string argDate = "")
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT_COMPARE";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
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
            chartTitle1.Font = new Font("Calibri", 18, FontStyle.Bold);
           // chartTitle1.TextColor = Color.Red;
            chartTitle1.Indent = 10;

            // Add the titles to the chart.
            chartControl1.Titles.AddRange(new ChartTitle[] {chartTitle1});
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            _iReload++;
            if (_iReload >= 60)
            {
                _iReload = 0;
                SetData();
            }
        }

        private void UC_COMPARE_WEEK_VisibleChanged(object sender, EventArgs e)
        {
            if(Visible)
            {
                _iReload = 60;
                tmrLoad.Start();
                InitUc();                
            }
            else
            {
                tmrLoad.Stop();             
            }
        }
    }
}
