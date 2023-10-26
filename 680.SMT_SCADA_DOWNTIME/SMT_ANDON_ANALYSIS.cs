using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace FORM
{
    public partial class SMT_ANDON_ANALYSIS : Form
    {
        public SMT_ANDON_ANALYSIS()
        {
            InitializeComponent();
        }
        #region Ora

        public DataTable SEL_DATA_ANDON(string Qtype, string V_P_YMD_F, string V_P_YMD_T, string V_P_LINE, string V_P_MLINE, string V_P_STATION, string V_P_PROCESS, string V_P_DOWNTIME, string V_P_TOP5)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;

            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT.SP_SMT_ANDON_GATHERING"; //SP_SMT_ANDON_DAILY

                MyOraDB.ReDim_Parameter(10);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD_F";
                MyOraDB.Parameter_Name[2] = "V_P_YMD_T";
                MyOraDB.Parameter_Name[3] = "V_P_LINE";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE";
                MyOraDB.Parameter_Name[5] = "V_P_STATION";
                MyOraDB.Parameter_Name[6] = "V_P_PROCESS";
                MyOraDB.Parameter_Name[7] = "V_P_DOWNTIME";
                MyOraDB.Parameter_Name[8] = "V_P_TOP5";
                MyOraDB.Parameter_Name[9] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[6] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[7] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[8] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[9] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = Qtype;
                MyOraDB.Parameter_Values[1] = V_P_YMD_F;
                MyOraDB.Parameter_Values[2] = V_P_YMD_T;
                MyOraDB.Parameter_Values[3] = V_P_LINE;
                MyOraDB.Parameter_Values[4] = V_P_MLINE;
                MyOraDB.Parameter_Values[5] = V_P_STATION;
                MyOraDB.Parameter_Values[6] = V_P_PROCESS;
                MyOraDB.Parameter_Values[7] = V_P_DOWNTIME;
                MyOraDB.Parameter_Values[8] = V_P_TOP5;
                MyOraDB.Parameter_Values[9] = "";


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

        private void GoFullscreen()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Bounds = Screen.PrimaryScreen.Bounds;

        }

        int indexScreen;
        string sLine, sMline;
        DataTable dtsource = null, dtB = null, dtC = null;
        int cMachine = 0, cQual = 0, cProd = 0, cCount = 0;
        bool flag = false;
        public SMT_ANDON_ANALYSIS(string Title, int _indexScreen, string _Line, string _Mline)
        {
            InitializeComponent();
            indexScreen = _indexScreen;
            sMline = _Mline;
            sLine = _Line;                    
        }

        string[] _str_uc = { "UC1", "UC2", "UC3", "UC4", "UC5", "UC6",
                             "UC7", "UC8", "UC9", "UC10", "UC11", "UC12",
                             "UC13", "UC14", "UC15","UC16", "UC17", "UC18",
                             "UC19", "UC20", "UC21"
                               };

        private void FRM_ANDON_GATHERING_Load(object sender, EventArgs e)
        {
            GoFullscreen();
            //setConfigForm();
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            date_F.EditValue = DateTime.Now;
            date_T.EditValue = DateTime.Now;

            uC_Factory1.setColor("GREEN");
            uC_Factory2.setColor("RED");
            uC_Factory3.setColor("YELLOW");

            // UC.UC_Factory _uc = this.Controls.Find("UC_Factory", true) as UC.UC_Factory;

            for (int i = 0; i < _str_uc.Length; i++)
            {
                UC.UC_Factory _uc = this.Controls.Find(_str_uc[i], true).FirstOrDefault() as UC.UC_Factory;
                if (int.Parse(_uc.Name.Replace("UC", "")) % 3 == 1)
                {
                    _uc.setColor("GREEN");
                }
                else if (int.Parse(_uc.Name.Replace("UC", "")) % 3 == 2)
                {
                    _uc.setColor("YELLOW");
                }
                else
                {
                    _uc.setColor("RED");
                }
            }
        }

        private void BindingData()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                gridControl.Refresh();
                string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");
                dtsource = SEL_DATA_ANDON("Q", strdate_f, strdate_t, sLine, cboMline.EditValue.ToString(), cboStation.EditValue == null ? "" : cboStation.EditValue.ToString(),
                    cboProcess.EditValue == null ? "" : cboProcess.EditValue.ToString(), chkDowntime.Checked == false ? "0" : "1", chkTop5.Checked == false ? "0" : "1"
                       );
                creat_mc_qty();
                if (dtsource != null && dtsource.Rows.Count > 0)
                {
                    //axfpGrid.Enabled = false;
                    //axfpGrid.Visible = false;
                    //axfpGrid.MaxRows = 1;
                    //axfpGrid.MaxRows = dt.Rows.Count + 1;
                    //lblAct.Text = dt.Rows[0]["ACT"].ToString();
                    //lblMrh.Text = dt.Rows[0]["MRH"].ToString();
                    //lblCall.Text = dt.Rows.Count.ToString("#,#");
                    //for (int i_row = 0; i_row < dt.Rows.Count; i_row++)
                    //{
                    //    axfpGrid.SetText(1, i_row + 2, i_row + 1);
                    //    axfpGrid.set_RowHeight(i_row + 2, 25);
                    //    axfpGrid.Row = i_row + 2;
                    //    axfpGrid.Col = 1;                    
                    //    axfpGrid.CellType = FPUSpreadADO.CellTypeConstants.CellTypeStaticText;
                    //    axfpGrid.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    //    axfpGrid.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                    //    axfpGrid.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Regular);
                    //    for (int i_col = 0; i_col < dt.Columns.Count - 2; i_col++)
                    //    {
                    //        axfpGrid.SetText(i_col + 2, i_row + 2, dt.Rows[i_row][i_col].ToString());
                    //        axfpGrid.Row = i_row + 2;
                    //        axfpGrid.Col = i_col + 2;                        
                    //        axfpGrid.CellType = FPUSpreadADO.CellTypeConstants.CellTypeStaticText;
                    //        axfpGrid.TypeHAlign = FPUSpreadADO.TypeHAlignConstants.TypeHAlignCenter;
                    //        axfpGrid.TypeVAlign = FPUSpreadADO.TypeVAlignConstants.TypeVAlignCenter;
                    //        axfpGrid.Font = new System.Drawing.Font("Calibri", 14, FontStyle.Regular);
                    //    }
                    //}
                    //axfpGrid.Enabled = true;
                    //axfpGrid.Visible = true;

                    lblAct.Text = dtsource.Rows[0]["ACT"].ToString();
                    lblMrh.Text = dtsource.Rows[0]["MRH"].ToString();
                    lblCall.Text = dtsource.Rows.Count.ToString("#,#");
                    gridControl.DataSource = dtsource;
                    for (int i = 0; i < gridView.Columns.Count; i++)
                    {
                        gridView.Columns[i].OptionsColumn.ReadOnly = true;
                        gridView.Columns[i].OptionsColumn.AllowEdit = false;
                        gridView.Columns[i].OptionsFilter.AllowFilter = false;
                        gridView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    }
                }
                else
                {
                    lblAct.Text = "00:00:00";
                    lblMrh.Text = "00:00:00";
                    lblCall.Text = "0";
                    gridControl.DataSource = dtsource;
                    //for (int i = 0; i < gridView.Columns.Count; i++)
                    //{
                    //    gridView.Columns[i].OptionsColumn.ReadOnly = true;
                    //    gridView.Columns[i].OptionsColumn.AllowEdit = false;
                    //    gridView.Columns[i].OptionsFilter.AllowFilter = false;
                    //    gridView.Columns[i].OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                    //    gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    //    gridView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    //}
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                splashScreenManager1.CloseWaitForm();
            }
        }

        private void creat_plant()
        {
            string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");
            DataTable dt = SEL_DATA_ANDON("C1", "", "", "", "", "",
                   "", "", "1"
                   );
            cboPlant.Properties.Columns.Clear();
            cboPlant.Properties.DataSource = dt;
            cboPlant.Properties.ValueMember = dt.Columns[0].ColumnName;
            cboPlant.Properties.DisplayMember = dt.Columns[1].ColumnName;
            cboPlant.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dt.Columns[0].ColumnName));
            cboPlant.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(dt.Columns[1].ColumnName));
            cboPlant.Properties.Columns[dt.Columns[0].ColumnName].Visible = false;
            cboPlant.ItemIndex = 0;

            //cboPlant.Properties.DataSource = dt;
            //cboPlant.Properties.DisplayMember = "NAME";
            //cboPlant.Properties.ValueMember = "CODE";
            //cboPlant.ItemIndex = 0;
        }
        private void creat_line()
        {
            string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");
            DataTable dt = SEL_DATA_ANDON("C2", "", "", sLine, "", "",
                   "", "", "1"
                   );

            cboMline.Properties.DataSource = dt;
            cboMline.Properties.DisplayMember = "NAME";
            cboMline.Properties.ValueMember = "CODE";
            cboMline.ItemIndex = 0;            
        }

        private void creat_station()
        {
            string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");

            DataTable dt = SEL_DATA_ANDON("C3", "", "", sLine, "", "",
                "", "", chkStation.Checked == false ? "0" : "1"
                   );

            cboStation.Properties.DataSource = dt;
            cboStation.Properties.DisplayMember = "NAME";
            cboStation.Properties.ValueMember = "CODE";
            cboStation.ItemIndex = 0;
        }

        private void creat_mc_qty()
        {
            string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");

            DataTable dt = SEL_DATA_ANDON("C5", strdate_f, strdate_t, sLine, cboMline.EditValue== null ? "ALL" : cboMline.EditValue.ToString(), "",
                "", "", chkStation.Checked == false ? "0" : "1"
                   );

            if (dt != null & dt.Rows.Count > 0)
            {
                lblQty.Text = dt.Rows[0]["QTY"].ToString();
                lblTarget.Text = dt.Rows[0]["TAR"].ToString();
            }
            else
            {
                lblQty.Text = "0";
                lblTarget.Text = "0";
            }
        }

        private void creat_process()
        {
            string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");            
            DataTable dt = SEL_DATA_ANDON("C4", "", "", sLine, "", "",
                   "", "", "1"
                   );

            cboProcess.Properties.DataSource = dt;
            cboProcess.Properties.DisplayMember = "NAME";
            cboProcess.Properties.ValueMember = "CODE";
            cboProcess.ItemIndex = 0;


        }

        private void BindingChart(DevExpress.XtraCharts.ChartControl sChart, DataTable dt, string Arg_Member, string Arg_ValueData)
        {
            sChart.DataSource = dt;
            sChart.Series[0].ArgumentDataMember = Arg_Member;
            sChart.Series[0].ValueDataMembers.AddRange(new string[] { Arg_ValueData });
            sChart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
            //DevExpress.XtraCharts.ConstantLine TargetLine = new DevExpress.XtraCharts.ConstantLine();
            //TargetLine.AxisValueSerializable = "1";
            //TargetLine.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            //TargetLine.Name = "Target: " + dt.Rows[0]["TARGET"].ToString();
            //((DevExpress.XtraCharts.XYDiagram)sChart.Diagram).AxisY.ConstantLines.Clear();
            //TargetLine.AxisValue = dt.Rows[0]["TARGET"];

            //((DevExpress.XtraCharts.XYDiagram)sChart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            //TargetLine});
        }

        private void GetDataMiddle()
        {

        }


        private void tmrDate_Tick(object sender, EventArgs e)
        {           
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));            
        }

        
        private void FRM_ANDON_GATHERING_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //cmdBack.Tag = ComVar.Var._Frm_Back;
                initForm();
                cCount = 29;
                tmrDate.Start();
                creat_plant();
                creat_line();
                creat_station();
                creat_process();
                BindingData();
                flag = true;
            }
            else
                tmrDate.Stop();
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            cCount = 29;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            BindingData();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && e.ToString().Length > 0)
            {
                string strdate_f = date_F.DateTime.ToString("yyyyMMdd"), strdate_t = date_T.DateTime.ToString("yyyyMMdd");
                DataTable dt = SEL_DATA_ANDON("T", strdate_f, strdate_t, sLine, "", "", "", "", txtQty.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    lblTarget.Text = dt.Rows[0][0].ToString();
                }
            }
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
            {
                e.Handled = true;                
            }            
           
        }

        private void chkStation_CheckedChanged(object sender, EventArgs e)
        {
            creat_station();
        }

        private void cboMline_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) BindingData();

        }

        private void cboStation_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) BindingData();
        }

        private void cboProcess_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) BindingData();
        }

        private void gridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.FieldName.Contains("PROCESS_NAME"))
            {
                if (dtsource.Rows.Count > 0)
                {
                    //if (dtsource.Rows[e.RowHandle]["COLOR"].ToString().Contains("RED"))
                    //{
                    //    e.Appearance.BackColor = Color.FromArgb(247, 131, 131);
                    //}
                    //else if (dtsource.Rows[e.RowHandle]["COLOR"].ToString().Contains("YELLOW"))
                    //{
                    //    e.Appearance.BackColor = Color.FromArgb(252, 248, 128);
                    //}
                    if (dtsource.Rows[e.RowHandle]["COLOR"].ToString().Contains("RED"))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else if (dtsource.Rows[e.RowHandle]["COLOR"].ToString().Contains("YELLOW"))
                    {
                        e.Appearance.BackColor = Color.Yellow;
                    }
                    else if (dtsource.Rows[e.RowHandle]["COLOR"].ToString().Contains("GREEN"))
                    {
                        e.Appearance.BackColor = Color.DodgerBlue;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void chkDowntime_CheckedChanged(object sender, EventArgs e)
        {
            BindingData();
        }

        private void chkTop5_CheckedChanged(object sender, EventArgs e)
        {
            BindingData();
        }

        private void date_F_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) BindingData();
        }

        private void date_T_EditValueChanged(object sender, EventArgs e)
        {
            if (flag == true) BindingData();
        }

        private void cboPlant_EditValueChanged(object sender, EventArgs e)
        {
            sLine = cboPlant.EditValue.ToString();
            creat_line();
            creat_station();
            if (flag == true) BindingData(); 
        }

        private void cmdPm1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }

        private void FRM_ANDON_GATHERING_Shown(object sender, EventArgs e)
        {
            cboProcess.Focus();
        }

        private void initForm()
        {
            sLine = ComVar.Var._strValue1;
            sMline = ComVar.Var._strValue2;
            // Lang = ComVar.Var._strValue3;

            //switch (ComVar.Var._strValue3)
            //{
            //    case "Vn":
            //        //btnDay.Text = "Ngày";
            //        //btnMonth.Text = "Tháng";
            //        //btnWeek.Text = "Tuần";
            //        //btnYear.Text = "Năm";
            //        lblTitle.Text = "Phân tích dữ liệu andon";
            //        break;
            //    case "En":
            //        //btnDay.Text = "Day";
            //        //btnMonth.Text = "Month";
            //        //btnWeek.Text = "Week";
            //        //btnYear.Text = "Year";
            //        lblTitle.Text = "Andon Data Analysis";
            //        break;
            //}

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Control cnt = (Control)sender;
            ComVar.Var.callForm = cnt.Tag == null ? "" : cnt.Tag.ToString();
        }

        #region  Get Config Data From Database
        /// <summary>
        /// Declare _dtnInit
        /// Dictionary<string, string> _dtnInit = new Dictionary<string, string>();
        /// </summary>
        private void setConfigForm()
        {
            try
            {
                System.Collections.Generic.Dictionary<string, string> dtnInit = new System.Collections.Generic.Dictionary<string, string>();
                dtnInit = ComVar.Func.getInitForm(ComVar.Var._Area + this.GetType().Assembly.GetName().Name, this.GetType().Name);

                for (int i = 0; i < dtnInit.Count; i++)
                {
                    setComValue(dtnInit.ElementAt(i).Key, dtnInit.ElementAt(i).Value);
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setConfigForm-->Err:    " + ex.ToString());
            }
        }

        private void setComValue(string obj, string obj_value)
        {
            try
            {
                if (obj.Contains('.'))
                {
                    string[] strSplit = obj.Split('.');
                    Control[] cnt = this.Controls.Find(strSplit[0], true);

                    for (int i = 0; i < cnt.Length; i++)
                    {
                        System.Reflection.PropertyInfo propertyInfo = cnt[i].GetType().GetProperty(strSplit[1]);
                        propertyInfo.SetValue(cnt[i], Convert.ChangeType(obj_value, propertyInfo.PropertyType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog(this.GetType().Name + "-->setComValue (" + obj + ", " + obj_value + ") Err:    " + ex.ToString());
            }

        }
        #endregion 

        
    }
}
