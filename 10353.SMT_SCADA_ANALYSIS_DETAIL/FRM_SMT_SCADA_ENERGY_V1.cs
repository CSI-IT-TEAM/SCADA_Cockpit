using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraGrid.Views.BandedGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_SMT_SCADA_ENERGY_V1 : Form
    {
        public FRM_SMT_SCADA_ENERGY_V1()
        {
            InitializeComponent();
            tmr.Stop();
        }
        int cCount = 0;
        Random r = new Random();

        private DataSet Data_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.ENEGY_DATA_SELECT_V2";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR2";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR3";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void FRM_SMT_SCADA_ENERGY_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void BindingData()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();

                DataTable table = new DataTable();
                table.Columns.Add("Plant", typeof(string));
                table.Columns.Add("D_VALUE", typeof(int));
                table.Columns.Add("M_VALUE", typeof(int));
                table.Columns.Add("Y_VALUE", typeof(int));
                for (int i = 0; i < 20; i++)
                {
                    table.Rows.Add(string.Concat("Plant ", (i + 1)), r.Next(500, 2000), r.Next(500, 2000), r.Next(500, 2000));
                }

                DataSet ds = Data_Select("Q");

                chartControl1.DataSource = ds.Tables[0];
                chartControl1.Series[0].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "BY_DAYS" });
                chartControl1.Series[1].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "BY_WEEKS" });
                chartControl1.Series[2].ArgumentDataMember = "LINE_NM";
                chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "BY_MONTHS" });

                BindingGrid(ds.Tables[1]);
                BindingTotalInfo(ds.Tables[2]);
                splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                splashScreenManager1.CloseWaitForm();
            }
        }
        private void BindingTotalInfo(DataTable dt)
        {
            lblTotalKw.Text = "0 kWh";
            lblTotalProd.Text = "0 Prs";
            lblAVG.Text = "0 Kwh/Prs";

            lblTotalKw.Text =string.Concat(string.Format("{0:n0}", dt.Rows[0]["ELEC_VAILD"])," kWh");
            lblTotalProd.Text =string.Concat( string.Format("{0:n0}", dt.Rows[0]["PROD_QTY"])," Prs");
            lblAVG.Text =string.Concat( string.Format("{0:n2}", dt.Rows[0]["ELEC_PER_PRS"])," kWh/Prs");
        }
        private void BindingGrid(DataTable dt)
        {
            try
            {
                grdView.DataSource = null;
                if (dt.Rows.Count > 0)
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
                    gridBand1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;

                    column_Band1.Caption = "DIV";
                    column_Band1.FieldName = "DIV";
                    column_Band1.Name = "DIV";
                    column_Band1.Visible = true;
                    column_Band1.Width = 120;
                    column_Band1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    gridBand1.Columns.Add(column_Band1);

                    gvwView.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] { column_Band1 });
                    gvwView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] { gridBand1 });

                    DataTable dtPivot = Pivot(dt, dt.Columns["LINE_NM"], dt.Columns["ELEC_PER_PRS"]);
                    //Create Header
                    DataView view = new DataView(dt);
                    DataTable distinctValues = view.ToTable(true, "LINE_NM");
                    for (int i = 0; i < distinctValues.Rows.Count; i++)
                    {
                        GridBand gridBand = new GridBand();
                        BandedGridColumn column_Band = new BandedGridColumn();

                        gridBand.Caption = distinctValues.Rows[i]["LINE_NM"].ToString();
                        gridBand.Name = string.Concat("LINE_NM_", i);
                        gridBand.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                        gridBand.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                        gridBand.VisibleIndex = i;

                        column_Band.Caption = distinctValues.Rows[i]["LINE_NM"].ToString();
                        column_Band.FieldName = distinctValues.Rows[i]["LINE_NM"].ToString();
                        column_Band.Name = distinctValues.Rows[i]["LINE_NM"].ToString();
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
            catch
            {

            }
        }
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
        private void FRM_SMT_SCADA_ENERGY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 60;
                tmr.Start();
            }
            else
                tmr.Stop();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                BindingData();
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            BindingData();
        }
    }
}
