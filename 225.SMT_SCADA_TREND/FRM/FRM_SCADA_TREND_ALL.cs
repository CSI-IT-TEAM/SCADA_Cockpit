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
    public partial class FRM_SCADA_TREND_ALL : Form
    {
        public FRM_SCADA_TREND_ALL()
        {
            InitializeComponent();
        }
        DatabaseSCADA db = new DatabaseSCADA();
        private DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("Value1", typeof(int));
            table.Columns.Add("Value2", typeof(int));
            table.Columns.Add("Value3", typeof(int));
            table.Columns.Add("Value4", typeof(int));
            table.Columns.Add("Name", typeof(string));
            Random r = new Random();

            // Here we add DataRows.
            for (int i = 0; i < 10; i++)
            {
                table.Rows.Add(r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), r.Next(10, 100), "PLANT " + (i + 1).ToString());
            }
            return table;
        }
        public void GetData2BindingChart(string sDateF, string sDateT, string Line, string Mline, string Area, string Machine, string Controller)
        {
            DataTable dt = db.GET_DATA_4_ALL("Q", sDateF, sDateT, Line, Mline, Area, Machine, Controller);
            BindingChart(dt);
        }
        private void InitLayout()
        {
            int No = 1;
            for (int i = 0; i < tblMain.RowCount; i++)
            {
                for (int j = 0; j < tblMain.ColumnCount; j++)
                {
                    UC.UC_CHART UC_CHART = new UC.UC_CHART();
                    tblMain.Controls.Add(UC_CHART, j, i);
                    UC_CHART.Dock = DockStyle.Fill;
                    UC_CHART.OnChartClick += ChartClick;
                   // UC_CHART.BindingChart(No, GetTable());
                    No++;
                }
            }
        }
        private void FRM_SCADA_TREND_ALL_Load(object sender, EventArgs e)
        {
            InitLayout();
        }
        private void BindingChart(DataTable dt)
        {
            try
            {
                int iTable = 1;
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        if (iTable <= 12)                //12 cell được load layout
                        {
                            UC.UC_CHART UC_CHART = (UC.UC_CHART)tblMain.GetControlFromPosition(j, i);
                            UC_CHART.BindingChart(iTable, dt);
                            
                        }
                        iTable++;
                    }
                }
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        void ChartClick(string ChartNm, bool isClickNew)
        {
            // MessageBox.Show("Chart Clicking! " + ChartNm);
            //tblMain.ColumnStyles.Clear();
            tblMain.ColumnStyles.Clear();
            tblMain.RowStyles.Clear();

            if (isClickNew)
            {
                this.tblMain.ColumnCount = 1; this.tblMain.RowCount = Convert.ToInt32(ChartNm);
                this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                if (Convert.ToInt32(ChartNm) > 1)
                    for (int i = 1; i < Convert.ToInt32(ChartNm); i++)
                    {
                        this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0));
                    }
                this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
            else
            {
                tblMain.ColumnStyles.Clear();
                tblMain.RowStyles.Clear();
                this.tblMain.ColumnCount = 2; this.tblMain.RowCount = 6;
                this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
                for (int i = 0; i < 6; i++)
                    this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            }
        }
        private void tblMain_Click(object sender, EventArgs e)
        {

        }
    }
}
