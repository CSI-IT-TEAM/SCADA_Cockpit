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
        private UC.UC_COMPARE_WEEK uc_compare_week = new UC.UC_COMPARE_WEEK();
        string _strType = "D";
        int _time = 0;

        private void SetData(string arg_type, bool arg_load = true)
        {
            try
            {
                if(arg_load)
                {
                    rdTop20.Checked = true;
                    pnBody2.Visible = false;
                    pnBody1.Visible = true;
                }
                
                

                chartControl1.DataSource = null;
                DataSet ds = Data_Select(arg_type);
                if (ds == null || ds.Tables.Count == 0) return;
                DataTable dtData = ds.Tables[0];
                DataTable dtDate = ds.Tables[1];

                //switch (arg_type)
                //{
                //    case "D":
                //        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + ")";
                //        break;
                //    case "W":
                //        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + " ~ " + dtDate.Rows[0]["EDATE"].ToString() + ")";
                //        break;
                //    case "M":
                //        lblHeader.Text = _strHeader + " (" + dtDate.Rows[0]["SDATE"].ToString() + " ~ " + dtDate.Rows[0]["EDATE"].ToString() + ")";
                //        break;
                //}


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
            rdTop20.Text = "Issue By Machine";
            switch (arg_type)
            {
                case "D":
                    
                    rdByDay.Text = "Issue Average By Day";
                    break;
                case "W":
                  
                    rdByDay.Text = "Issue By Week";
                    break;
                case "M":
                   
                    rdByDay.Text = "Issue By Month";
                    break;
            }

            if (rdTop20.Checked)
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
                    default:
                        lblHeader.Text = _strHeader;
                        break;
                }
            }
            else
            {
                lblHeader.Text = _strHeader;              
            }
            
        }

        private void LoadForm()
        {
            
            SetButtonClick(_strType);
            SetHeader(_strType);
            
            SetData(_strType);

            //if (rdTop20.Checked)
            //{
            //    SetData(_strType);
            //}
            //else
            //{
            //    uc_compare_week._strType = _strType;

            //    uc_compare_week.InitUc();
            //    uc_compare_week.SetData();

            //}

        }


        private void SetButtonClick(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    cmdDay.Enabled = false;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = true;
                    rdByDay.Visible = true;
                    rdTop20.Visible = true;
                    break;
                case "W":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = false;
                    cmdMonth.Enabled = true;
                    rdByDay.Visible = false;
                    rdTop20.Visible = false;
                    break;
                case "M":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = false;
                    rdByDay.Visible = false;
                    rdTop20.Visible = false;
                    break;
            }
        }

        private void InitCompare()
        {
            pnBody2.Visible = false;
            pnBody2.Dock = DockStyle.Fill;
            uc_compare_week.Dock = DockStyle.Fill;
            pnBody2.Controls.Add(uc_compare_week);
        }




        #region DB
        private DataSet Data_Select(string argType, string argDate = "")
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

        #endregion DB



        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if(_time >=30)
            {
                _time = 0;
                SetData(_strType, false);
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
                InitCompare();
                timer1.Start();
                _strType = "D";
                LoadForm();
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
            _strType = "D";
            LoadForm();
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            _strType = "W";
            LoadForm();
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            _strType = "M";
            LoadForm();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            // if (e.Column.Name != "MACHINE_CD") return;
            if (e.Clicks <= 1) return;
            string strMachine = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["MACHINE_CD"]).ToString();
            using (SMT_SCADA_COCKPIT_POPUP pop = new SMT_SCADA_COCKPIT_POPUP())
            {
                pop._dtData = Data_Select_Machine(_strType, strMachine);
                pop.ShowDialog();
            }
        }

        private void cmdExportDetail_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog SaveDlg = new SaveFileDialog())
                {

                    SaveDlg.RestoreDirectory = true;
                    SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (SaveDlg.ShowDialog() == DialogResult.OK)
                    {
                        grdExportDetail.DataSource = Data_Select_Machine(_strType, "");

                        for (int i = 0; i < grvExportDetail.Columns.Count; i++)
                        {

                            grvExportDetail.Columns[i].OptionsColumn.ReadOnly = true;
                            grvExportDetail.Columns[i].OptionsColumn.AllowEdit = false;
                            if (i <= 4)
                            {
                                grvExportDetail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                                grvExportDetail.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                            }
                            if (i == 4)
                                grvExportDetail.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        }

                        grvExportDetail.ExportToXlsx(SaveDlg.FileName);
                        MessageBox.Show("Export Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cmdExportIssue_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog SaveDlg = new SaveFileDialog())
                {
                    SaveDlg.RestoreDirectory = true;
                    SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                    if (SaveDlg.ShowDialog() == DialogResult.OK)
                    {
                        grdExportIssue.DataSource = Data_Select(_strType, "1").Tables[0];
                        grvExportIssue.ExportToXlsx(SaveDlg.FileName);
                        MessageBox.Show("Export Success!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void rdByDay_CheckedChanged(object sender, EventArgs e)
        {
            if (rdByDay.Checked)
            {
                uc_compare_week._strType = _strType;
                SetHeader("");
                pnBody2.Visible = true;
                pnBody1.Visible = false;
                cmdDay.Visible = false;
                cmdWeek.Visible = false;
                cmdMonth.Visible = false;

                //uc_compare_week.InitUc();
                // uc_compare_week.SetData();
            }
            else
            {
                cmdDay.Visible = true;
                cmdWeek.Visible = true;
                cmdMonth.Visible = true;
                LoadForm();
            }
            
        }
    }
}
