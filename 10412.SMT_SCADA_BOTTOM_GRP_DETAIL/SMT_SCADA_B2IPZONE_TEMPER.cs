using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_B2IPZONE_TEMPER : Form
    {
        public SMT_SCADA_B2IPZONE_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        #region Variable
        int cCount = 0;
        const int ReloadTime = 60;
        List<Label> lstLabel = new List<Label>();
        string argZone = "Z001",argStabMC = "001",argStabLine = "001";
        #endregion

        #region DB
        private DataTable SEL_INJECTION_DATA(string argType, string argDate, string argZone)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_SELECT_B2ZONE_INJECT_TEMP";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_ZONE";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = argZone;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        private DataTable SEL_STABILIZATION_DATA(string argType, string argDate, string argZone)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_SELECT_B2ZONE_STAB_TEMP";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_ZONE";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = argZone;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        public DataTable GetData(string argType, string argOPCD, string argMC, string argMILINE_CD)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            MyOraDB.ShowErr = true;
            try
            {
                string process_name = "MES.PKG_SMT_SCADA_COCKPIT_01.SMT_SCADA_BOTTOM_HISTORY";

                MyOraDB.ReDim_Parameter(6);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "V_P_TYPE";
                MyOraDB.Parameter_Name[1] = "V_P_YMD";
                MyOraDB.Parameter_Name[2] = "V_P_ROLL_OP_CD";
                MyOraDB.Parameter_Name[3] = "V_P_MC_ID";
                MyOraDB.Parameter_Name[4] = "V_P_MLINE_CD";
                MyOraDB.Parameter_Name[5] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[4] = (int)OracleType.VarChar;
                MyOraDB.Parameter_Type[5] = (int)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argType;
                MyOraDB.Parameter_Values[1] = DateTime.Now.ToString("yyyyMMdd");
                MyOraDB.Parameter_Values[2] = argOPCD;
                MyOraDB.Parameter_Values[3] = argMC;
                MyOraDB.Parameter_Values[4] = argMILINE_CD;
                MyOraDB.Parameter_Values[5] = "";

                MyOraDB.Add_Select_Parameter(true);
                ds_ret = MyOraDB.Exe_Select_Procedure();

                if (ds_ret == null) return null;
                return ds_ret.Tables[process_name];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        #endregion


        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                string _argZone = argZone;
                BindingInjectionData(_argZone);
                BindingStabilizationData(_argZone);
            }
        }

        int iL1_001 = 0;
        private void BindingStabilizationData(string _argZone)
        {
            try
            {
                DataTable dt = SEL_STABILIZATION_DATA("Q", DateTime.Now.ToString("yyyyMMdd"), _argZone);
                foreach (var item in lstLabel)
                {
                    item.Text = "0";
                }
                    if (dt.Rows.Count < 2) return;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (var item in lstLabel)
                    {
                        if (item.Name.ToString().Equals(dr["MAPPING_NAME"]))
                        {
                            item.Text = dr["VALUE"].ToString();
                            
                            //System.Timers.Timer t = new System.Timers.Timer(100);
                           // t.AutoReset = true;
                           // t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                            //t.Elapsed += (sender, e) => { HandleTimerElapsed(_actual); };
                           // t.Start();
                        }
                    }
                }
            }
            catch 
            {

              
            }
        }

        private async void HandleTimerElapsed(object _actual)
        {
            throw new NotImplementedException();
        }
       

        private void BindingInjectionData(string _argZone)
        {
            try
            {
                DataTable dt = SEL_INJECTION_DATA("Q", DateTime.Now.ToString("yyyyMMdd"), _argZone);
                gridControl1.DataSource = dt;
                for (int i = 0; i < gridView1.Columns.Count; i++)
                {
                    gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    if (i == 0)
                        gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

                }

                string argMachine = string.Concat(argZone, gridView1.GetRowCellValue(0, gridView1.Columns["MACHINE_CD"]));
                string argMachineName = string.Concat(gridView1.GetRowCellValue(0, gridView1.Columns["MACHINE_NM"]), ", Station: ", gridView1.GetRowCellValue(0, gridView1.Columns["STATION_CD"]));
                DrawInjectChart(argMachine, argMachineName);
            }
            catch { }
        }

        private void sbtnZone_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cCount = 0;
            sbtnZone1.Appearance.BackColor = sbtnZone1.Appearance.BackColor2= Color.Silver;
            sbtnZone2.Appearance.BackColor = sbtnZone2.Appearance.BackColor2=Color.Silver;
            sbtnZone3.Appearance.BackColor = sbtnZone3.Appearance.BackColor2=Color.Silver;
            sbtnZone4.Appearance.BackColor = sbtnZone4.Appearance.BackColor2=Color.Silver;
            sbtnZone5.Appearance.BackColor = sbtnZone5.Appearance.BackColor2=Color.Silver;
            sbtnZone6.Appearance.BackColor = sbtnZone6.Appearance.BackColor2=Color.Silver;
            sbtnZone7.Appearance.BackColor = sbtnZone7.Appearance.BackColor2 = Color.Silver;

            SimpleButton sbtn = ((SimpleButton)sender);
            sbtn.Appearance.BackColor = sbtn.Appearance.BackColor2 = Color.Yellow;
            argZone = sbtn.Tag.ToString();
            BindingInjectionData(argZone);
            BindingStabilizationData(argZone);
            this.Cursor = Cursors.Default;
        }

        private void SMT_SCADA_B2IPZONE_TEMPER_Load(object sender, EventArgs e)
        {
            InitLabelControls();

            //Select data with default value

        }

        private void SMT_SCADA_B2IPZONE_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
            {
                tmrDate.Stop();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                string argMachine = string.Concat(argZone, gridView1.GetRowCellValue(e.RowHandle,gridView1.Columns["MACHINE_CD"]));
                string argMachineName = string.Concat( gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["MACHINE_NM"]),", Station: ", gridView1.GetRowCellValue(e.RowHandle,gridView1.Columns["STATION_CD"]));
                DrawInjectChart(argMachine, argMachineName);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void DrawInjectChart(string argMachine,string argMachineName)
        {
            DataTable dt = GetData("IP_ZONE_INJECTION", argZone + "_INJECTION", argMachine, "");
            chartInject.DataSource = dt;
            if (dt.Rows.Count < 2) return;
            int minRange = int.Parse(dt.Rows[0]["MIN_VL"].ToString());
            int maxRange = int.Parse(dt.Rows[0]["MAX_VL"].ToString());
            chartInject.AnimationStartMode = ChartAnimationMode.OnDataChanged;
            chartInject.Series[0].ArgumentScaleType = ScaleType.Qualitative;
            chartInject.Series[0].ArgumentDataMember = "HMS";
            chartInject.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE" });

            //((DevExpress.XtraCharts.XYDiagram)chartInject.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
            //spec
            DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine(); ////Constant line
                                                                                                         //constantLine1.ShowInLegend = false;
            constantLine1.AxisValueSerializable = dt.Rows[0]["MIN_VL"].ToString();
            constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            constantLine1.Name = "Min";
            constantLine2.AxisValueSerializable = dt.Rows[0]["MAX_VL"].ToString();
            constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            constantLine2.Name = "Max";
            // constantLine1.ShowBehind = false;
            constantLine1.Title.Visible = false;
            constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //constantLine1.Title.Text = "Target";
            constantLine1.LineStyle.Thickness = 3;
            constantLine2.Title.Visible = false;
            constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //constantLine1.Title.Text = "Target";
            constantLine2.LineStyle.Thickness = 3;
            // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
            ((XYDiagram)chartInject.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

            chartInject.Titles[0].Text = argMachineName;

            ((XYDiagram)chartInject.Diagram).AxisY.WholeRange.Auto = true;
            ((XYDiagram)chartInject.Diagram).AxisY.WholeRange.SetMinMaxValues(minRange - 5, maxRange + 5);
        }
        private int GetMinValue(List<int> lst)
        {
            try
            {
                return lst.Min();
            }
            catch
            {
                return 0;
            }

        }
        private int GetMaxValue(List<int> lst)
        {
            try
            {
                return lst.Max();
            }
            catch
            {
                return 0;
            }

        }
       
        private void InitLabelControls()
        {
            lstLabel.Add(lblLine_001_001);
            lstLabel.Add(lblLine_001_002);
            lstLabel.Add(lblLine_001_003);
            lstLabel.Add(lblLine_001_004);
            lstLabel.Add(lblLine_001_005);
            lstLabel.Add(lblLine_001_006);
            lstLabel.Add(lblLine_001_007);
            lstLabel.Add(lblLine_001_008);
            lstLabel.Add(lblLine_001_009);
            lstLabel.Add(lblLine_001_010);
            lstLabel.Add(lblLine_001_011);
            lstLabel.Add(lblLine_001_012);

            lstLabel.Add(lblLine_002_001);
            lstLabel.Add(lblLine_002_002);
            lstLabel.Add(lblLine_002_003);
            lstLabel.Add(lblLine_002_004);
            lstLabel.Add(lblLine_002_005);
            lstLabel.Add(lblLine_002_006);
            lstLabel.Add(lblLine_002_007);
            lstLabel.Add(lblLine_002_008);
            lstLabel.Add(lblLine_002_009);
            lstLabel.Add(lblLine_002_010);
            lstLabel.Add(lblLine_002_011);
            lstLabel.Add(lblLine_002_012);

            foreach (var item in lstLabel)
            {
                item.Click += Item_Click;
            }

        }

        private void Item_Click(object sender, EventArgs e)
        {
            try
            {
                Label lbl = ((Label)sender);
                foreach (var item in lstLabel)
                {
                    item.BackColor = Color.FromArgb(45, 55, 117);
                    item.ForeColor = Color.White;
                }

                lbl.BackColor = Color.Yellow;
                lbl.ForeColor = Color.Black;
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
