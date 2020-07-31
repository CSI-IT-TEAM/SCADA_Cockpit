using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_FORM2 : Form
    {
        public SMT_SCADA_COCKPIT_FORM2()
        {
            InitializeComponent();
            lblHeader.Text = _strHeader;
        }

        private readonly string _strHeader = "       Preventative Maintenance";

        private void SetData(string arg_type)
        {
            try
            {
                chartControl1.DataSource = null;
                DataSet ds = Data_Select(arg_type);
                if (ds == null || ds.Tables.Count == 0) return;
                DataTable dtData = ds.Tables[0];
                DataTable dtDate = ds.Tables[1];

                switch (arg_type)
                {
                    case "D":
                        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + ")";
                        break;
                    case "W":
                        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + " ~ " + dtDate.Rows[0]["EDATE"].ToString() + ")";
                        break;
                    case "M":
                        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + " ~ " + dtDate.Rows[0]["EDATE"].ToString() + ")";
                        break;
                }


                chartControl1.DataSource = dtData;
                chartControl1.Series[0].ArgumentDataMember = "MACHINE_CD";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "OCR_TIME" });
                gridControl1.DataSource = dtData;


                for (int i = 0; i < gridView1.Columns.Count; i++)
                {

                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    if (i <= 4)
                    {
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    }
                    //  gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    // gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    //if (i <= 2)
                    //    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                    //else
                    //    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;

                    if (i == 4)
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

                    if (i == gridView1.Columns.Count - 1)
                        gridView1.Columns[i].AppearanceCell.Font = new Font("Calibri", 16, FontStyle.Bold);
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


        private void SetButtonClick(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    cmdDay.Enabled = false;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = true;                  
                    break;
                case "W":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = false;
                    cmdMonth.Enabled = true;
                    break;
                case "M":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = false;
                    break;
            }
        }

        #region DB
        private DataSet Data_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
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

        #endregion DB



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void cmdPm1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                timer1.Start();
                SetHeader("D");
                SetButtonClick("D");
                SetData("D");
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

        private void cmDay_Click(object sender, EventArgs e)
        {
            SetHeader("D");
            SetButtonClick("D");
            SetData("D");
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            SetHeader("W");
            SetButtonClick("W");
            SetData("W");
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            SetHeader("M");
            SetButtonClick("M");
            SetData("M");
        }
    }
}
