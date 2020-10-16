using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_DOWNTIME : Form
    {
        public SMT_SCADA_DOWNTIME()
        {
            InitializeComponent();
            //lblHeader.Text = _strHeader;
        }
        private readonly string _strHeader = "       Preventative Maintenance";

        string _strType = "D";
        int _time = 0;
        DataTable dt_chart = null;

        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];


            }

            return result;
        }

        private void SetData(string arg_type)
        {
            try
            {
                chartControl1.DataSource = null;
                DataSet ds = Data_Select(arg_type);
                if (ds == null || ds.Tables.Count == 0) return;
                DataTable dtData = ds.Tables[0];
                DataTable dtData2 = ds.Tables[1];

                dt_chart = dtData;

                chartControl1.DataSource = dtData;
                chartControl1.Series[0].ArgumentDataMember = "PLANT";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "TIME_SUM" });
                //chartControl1.Series[0].ValueScaleType = DevExpress.XtraCharts.ScaleType.DateTime;
                // chartControl1.Series[0].Label.
                chartControl1.Series[1].ArgumentDataMember = "PLANT";
                chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "CALLING_TIMES" });
               

                //DataTable dt = null;
                grdView.DataSource = null;
                if (dtData2.Rows.Count > 0)
                {
                    gvwView.Bands.Clear();
                    gvwView.Columns.Clear();
                    GridBand gridBand1 = new GridBand();
                    BandedGridColumn column_Band1 = new BandedGridColumn();
                    BandedGridColumn column_Band2 = new BandedGridColumn();
                    gridBand1.Caption = "DIV";
                    gridBand1.Name = "DIV";
                    gridBand1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridBand1.VisibleIndex = 0;

                    //column_Band1.Caption = "FACTORY";
                    //column_Band1.FieldName = "FACTORY";
                    //column_Band1.Name = "FACTORY";
                    //column_Band1.Visible = false;
                    //column_Band1.Width = 90;
                    //gridBand1.Columns.Add(column_Band1);

                    column_Band1.Caption = "DIV";
                    column_Band1.FieldName = "DIV";
                    column_Band1.Name = "DIV";
                    column_Band1.Visible = true;
                    column_Band1.Width = 120;
                    column_Band1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    gridBand1.Columns.Add(column_Band1);

                    gvwView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { column_Band1 });
                    gvwView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });

                    DataTable dt = dtData2;
                    DataTable dtPivot = Pivot(dt, dt.Columns["PLANT"], dt.Columns["VALUE"]);
                    //Create Header
                    DataView view = new DataView(dt);
                    DataTable distinctValues = view.ToTable(true, "PLANT");
                    for (int i = 0; i < distinctValues.Rows.Count; i++)
                    {
                        GridBand gridBand = new GridBand();
                        BandedGridColumn column_Band = new BandedGridColumn();

                        gridBand.Caption = distinctValues.Rows[i]["PLANT"].ToString();
                        gridBand.Name = string.Concat("PLANT_", i);
                        gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                        gridBand.VisibleIndex = i;

                        column_Band.Caption = distinctValues.Rows[i]["PLANT"].ToString();
                        column_Band.FieldName = distinctValues.Rows[i]["PLANT"].ToString();
                        column_Band.Name = distinctValues.Rows[i]["PLANT"].ToString();
                        column_Band.Visible = true;
                        column_Band.Width = 80;

                        gridBand.Columns.Add(column_Band);
                        gvwView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { column_Band });
                        gvwView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand });
                        gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                    }
                    //==========End creater header

                    grdView.DataSource = dtPivot;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }

        }


        private void SetHeader(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    lblHeader.Text = _strHeader + " (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
                case "W":
                    lblHeader.Text = _strHeader + " (" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + " ~ " + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
                case "M":
                    lblHeader.Text = _strHeader + " (" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd") + " ~ " + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
            }
        }

        #region DB
        private DataSet Data_Select(string argType, string argDate = "")
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SELECT_SCADA_DOWNTIME";

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

        private DataTable Data_Select_Machine(string argType, string argMachine)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT_MACHINE";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_MACHINE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argMachine;
            MyOraDB.Parameter_Values[2] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[0];
        }

        #endregion DB



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if(_time >=30)
            {
                _time = 0;
                SetData(_strType);
            }
            
        }

        private void cmdPm1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _time = 29;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }




        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdDetail_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "681";
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            // if (e.Column.Name != "MACHINE_CD") return;
            //if (e.Clicks <= 1) return;
            //string strMachine = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["MACHINE_CD"]).ToString();
            //using (SMT_SCADA_COCKPIT_POPUP pop = new SMT_SCADA_COCKPIT_POPUP())
            //{
            //    pop._dtData = Data_Select_Machine(_strType, strMachine);
            //    pop.ShowDialog();
            //}
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs e)
        {
            BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            if (drawOptions == null)
                return;

            // Get the fill options for the series point.
            drawOptions.FillStyle.FillMode = FillMode.Gradient;
            RectangleGradientFillOptions options =
            drawOptions.FillStyle.Options as RectangleGradientFillOptions;
            if (options == null)
                return;

            // Get the value at the current series point.
            double val = e.SeriesPoint[0];

            if (val > 3600)
            {
                options.Color2 = Color.Red;
                drawOptions.Color = Color.Red;
                //drawOptions.Border.Color = Color.FromArgb(100, 39, 91, 1);
            }
            else if (val > 1740)
            {
                options.Color2 = Color.Orange;
                drawOptions.Color = Color.Orange;
                //drawOptions.Border.Color = Color.FromArgb(60, 165, 73, 5);
            }
            else if (val > 540)
            {
                options.Color2 = Color.Yellow;
                drawOptions.Color = Color.Yellow;
                //drawOptions.Border.Color = Color.FromArgb(60, 165, 73, 5);
            }
            else
            {
                options.Color2 = Color.Green;
                drawOptions.Color = Color.Green;
                //drawOptions.Border.Color = Color.FromArgb(100, 155, 26, 0);
            }
        }

        private void chartControl1_CustomDrawSeries(object sender, DevExpress.XtraCharts.CustomDrawSeriesEventArgs e)
        {
            //double val = e.Series.Points[0].Values[0];
            //// Originial values - 12, 93, 167  
            //Color colorInTarget = Color.FromArgb(12, 93, 240);
            //Color colorOutTarget = Color.FromArgb(40, 93, 167);

            //BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            //if (drawOptions == null)
            //    return;

            //if (val > 3600)
            //{
            //    // Volume value is inside target range.  
            //    drawOptions.Color = Color.Red;
            //    //drawOptions.FillStyle.FillMode = FillMode.Gradient;
            //}
            //else if (val > 1740)
            //{
            //    // Volume value is inside target range.  
            //    drawOptions.Color = Color.Orange;
            //    //drawOptions.FillStyle.FillMode = FillMode.Gradient;
            //}
            //else if (val > 540)
            //{
            //    // Volume value is inside target range.  
            //    drawOptions.Color = Color.Yellow;
            //    //drawOptions.FillStyle.FillMode = FillMode.Gradient;
            //}
            //else
            //{
            //    // Volume value is outside target range.  
            //    drawOptions.Color = Color.Green;
            //    //drawOptions.FillStyle.FillMode = FillMode.Gradient;
            //}
        }

        private void gvwView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if(e.CellValue.ToString().Contains("GREEN"))
            {
                e.Appearance.BackColor = Color.Green;
                e.Appearance.ForeColor = Color.White;
            }
            else if (e.CellValue.ToString().Contains("YELLOW"))
            {
                e.Appearance.BackColor = Color.Yellow;
                e.Appearance.ForeColor = Color.Black;
            }
            else if (e.CellValue.ToString().Contains("ORANGE"))
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.ForeColor = Color.White;
            }
            else if (e.CellValue.ToString().Contains("RED"))
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.White;
            }
        }
    }
}
