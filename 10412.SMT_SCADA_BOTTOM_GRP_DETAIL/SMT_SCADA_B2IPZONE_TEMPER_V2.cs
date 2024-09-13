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
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_B2IPZONE_TEMPER_V2 : Form
    {
        public SMT_SCADA_B2IPZONE_TEMPER_V2()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            tmrDate.Stop();
        }
        #region Variable
        int cCount = 0;
        const int ReloadTime = 60;
        List<Label> lstLabel = new List<Label>();
        List<Label> ChamberStandMINlstLabel = new List<Label>();
        List<Label> ChamberStandMAXlstLabel = new List<Label>();
        List<Label> lstInjectLabel = new List<Label>();
        string argZone = "Z001", argStabMC = "001", argStabLine = "001";
        int PageIdx = 1;
        int MaxPageSeq = 0;
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
            //ComVar.Var.callForm = "back";
            tmrDate.Stop();
            ComVar.Var.callForm = "back";
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                tmrAnimation.Start();
            }


            //foreach (var item in lstInjectLabel)
            //{
            //    if(item.BackColor == Color.Red)
            //    {
            //        item.BackColor = Color.Gray;
            //    }
            //    else if (item.BackColor == Color.Gray)
            //    {
            //        item.BackColor = Color.Red;
            //    }

            //}
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

                foreach (var item in ChamberStandMINlstLabel)
                {

                    item.Text = "0";
                }
                foreach (var item in ChamberStandMAXlstLabel)
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

                    foreach (var item in ChamberStandMINlstLabel)
                    {
                        if (item.Name.ToString().Replace("_MIN", "").Equals(dr["MAPPING_NAME"]))
                        {
                            item.Text = dr["MIN_VAL"].ToString();
                        }
                    }
                    foreach (var item in ChamberStandMAXlstLabel)
                    {
                        if (item.Name.ToString().Replace("_MAX", "").Equals(dr["MAPPING_NAME"]))
                        {
                            item.Text = dr["MAX_VAL"].ToString();
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


        private void BindingInjectionData(string _argZone, int PageIdx)
        {
            try
            {

                foreach (var item in lstInjectLabel)
                {
                    item.Text = "0";
                    item.BackColor = Color.FromArgb(45, 55, 117);
                }
                lblMC1.Text = string.Empty;
                lblMC2.Text = string.Empty;
                lblMC3.Text = string.Empty;
                DataTable dt = SEL_INJECTION_DATA("Q", DateTime.Now.ToString("yyyyMMdd"), _argZone);
                if (dt.Rows.Count < 2) return;
                MaxPageSeq = Convert.ToInt32(dt.Compute("max([PAGE_IDX])", string.Empty));
                if (MaxPageSeq % 3 != 0)
                    MaxPageSeq = (int)Math.Ceiling((double)MaxPageSeq / 3);
                else
                    MaxPageSeq = MaxPageSeq / 3;
                DataTable dtP = new DataTable();

                if (dt.Select("PAGE_IDX >='" + ((PageIdx * 3) - 2).ToString() + "' AND PAGE_IDX <= '" + (PageIdx * 3) + "'").Count() > 0)
                {
                    DataTable dtTemp = dt.Select("PAGE_IDX >='" + ((PageIdx * 3) - 2).ToString() + "' AND PAGE_IDX <= '" + (PageIdx * 3) + "'").CopyToDataTable();
                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        if (dr["SEQ"].ToString().Equals("1"))
                        {
                            lblMC1.Text = dr["MACHINE_NM"].ToString();
                            foreach (var item in lstInjectLabel)
                            {
                                //lblMC1_INJECT1_01 Nhom 1
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC1_INJECT1") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT1"]);
                                    if (dr["STATUS1"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;

                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);
                                    }
                                }
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC1_INJECT2") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT2"]);
                                    if (dr["STATUS2"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;

                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);
                                    }
                                }
                            }
                        }

                        if (dr["SEQ"].ToString().Equals("2"))
                        {
                            lblMC2.Text = dr["MACHINE_NM"].ToString();
                            foreach (var item in lstInjectLabel)
                            {
                                //Nhom 2
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC2_INJECT1") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT1"]);
                                    if (dr["STATUS1"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);
                                    }
                                }
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC2_INJECT2") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT2"]);
                                    if (dr["STATUS2"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);
                                    }
                                }
                            }
                        }

                        if (dr["SEQ"].ToString().Equals("3"))
                        {
                            lblMC3.Text = dr["MACHINE_NM"].ToString();
                            foreach (var item in lstInjectLabel)
                            {
                                //Nhom 3
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC3_INJECT1") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT1"]);
                                    if (dr["STATUS1"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);

                                    }
                                }
                                if (item.Name.ToString().Substring(0, 14).Equals("lblMC3_INJECT2") && item.Name.ToString().Substring(item.Name.ToString().Length - 2).Equals(dr["STATION_CD"]))
                                {
                                    item.Text = string.Format("{0:n1}", dr["INJECT2"]);
                                    if (dr["STATUS2"].ToString().Equals("1"))
                                    {
                                        item.BackColor = Color.Red;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.FromArgb(45, 55, 117);
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        #region Oracle
        private DataTable SEL_BOTTOM_COCKPIT_DATA(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SEL_IP_ZONE_STATUS_LIST";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        #endregion

        private void sbtnZone_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cCount = 0;
            DataTable dt = SEL_BOTTOM_COCKPIT_DATA("Q");
            BindingData(dt);
            //sbtnZone1.Appearance.BackColor = sbtnZone1.Appearance.BackColor2 = Color.Silver;
            //sbtnZone2.Appearance.BackColor = sbtnZone2.Appearance.BackColor2 = Color.Silver;
            //sbtnZone3.Appearance.BackColor = sbtnZone3.Appearance.BackColor2 = Color.Silver;
            //sbtnZone4.Appearance.BackColor = sbtnZone4.Appearance.BackColor2 = Color.Silver;
            //sbtnZone5.Appearance.BackColor = sbtnZone5.Appearance.BackColor2 = Color.Silver;
            //sbtnZone6.Appearance.BackColor = sbtnZone6.Appearance.BackColor2 = Color.Silver;
            //sbtnZone7.Appearance.BackColor = sbtnZone7.Appearance.BackColor2 = Color.Silver;

            SimpleButton sbtn = ((SimpleButton)sender);
            sbtn.Appearance.BackColor = sbtn.Appearance.BackColor2 = Color.Yellow;
            sbtn.Appearance.ForeColor = Color.Black;
            argZone = sbtn.Tag.ToString();

            if (dt != null)
            {
                if (dt.Select("MACHINE_CODE_MAPPING='" + argZone + "'") != null)
                {
                    DataTable dtTemp = dt.Select("MACHINE_CODE_MAPPING='" + argZone + "'").CopyToDataTable();
                    lbl_Inject_Min.Text = string.Format("Min: {0} °C", dtTemp.Rows[0]["MIN_VAL"]);
                    lbl_Inject_Max.Text = string.Format("Max: {0} °C", dtTemp.Rows[0]["MAX_VAL"]);
                }
            }


            BindingInjectionData(argZone, PageIdx);
            BindingStabilizationData(argZone);
            this.Cursor = Cursors.Default;
        }

        private void SMT_SCADA_B2IPZONE_TEMPER_Load(object sender, EventArgs e)
        {
            InitLabelControls();
            sBtnList = new SimpleButton[] { sbtnZone1, sbtnZone2, sbtnZone3, sbtnZone4, sbtnZone5, sbtnZone6, sbtnZone7 };
            //Select data with default value
            //lblMC1_INJECT1_01.BackColor = Color.Red;
            DataTable dt = SEL_BOTTOM_COCKPIT_DATA("Q");


            

            BindingData(dt);
            if (dt != null)
            {
                if (dt.Select("MACHINE_CODE_MAPPING='Z001'") != null)
                {
                    DataTable dtTemp = dt.Select("MACHINE_CODE_MAPPING='Z001'").CopyToDataTable();
                    lbl_Inject_Min.Text = string.Format("Min: {0} °C", dtTemp.Rows[0]["MIN_VAL"]);
                    lbl_Inject_Max.Text = string.Format("Max: {0} °C", dtTemp.Rows[0]["MAX_VAL"]);
                }
            }

            sbtnZone1.Appearance.BackColor = sbtnZone1.Appearance.BackColor2 = Color.Yellow;
            sbtnZone1.Appearance.ForeColor = Color.Black;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 500; // Timer interval in milliseconds (1000 ms = 1 second)
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        SimpleButton[] sBtnList = null;
        private void BindingData(DataTable dt)
        {
            try
            {

                foreach (DataRow dr in dt.Rows)
                {
                    foreach (var item in sBtnList)
                    {
                        if (dr["MACHINE_CODE_MAPPING"].Equals(item.Tag.ToString()))
                        {

                            switch (dr["STATUS"].ToString())
                            {
                                case "G":
                                    item.Appearance.BackColor = Color.Green;
                                    item.Appearance.BackColor2 = Color.Green;
                                    break;
                                case "R":
                                    item.Appearance.BackColor = Color.Red;
                                    item.Appearance.BackColor2 = Color.Red;
                                    break;
                                case "Y":
                                    item.Appearance.BackColor = Color.Yellow;
                                    item.Appearance.BackColor2 = Color.Yellow;
                                    break;
                            }
                        }
                    }
                }


                tmrBlinking.Enabled = true;
                tmrBlinking.Start();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void tmrBlinking_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in sBtnList)
                {
                    if (item.Appearance.BackColor == Color.Red)
                    {
                        item.Appearance.BackColor = Color.Black;
                        item.Appearance.BackColor2 = Color.Black;
                        item.Appearance.ForeColor = Color.White;
                    }
                    else if (item.Appearance.BackColor == Color.Black)
                    {
                        item.Appearance.BackColor = Color.Red;
                        item.Appearance.BackColor2 = Color.Red;
                        item.Appearance.ForeColor = Color.White;
                    }


                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Label item in lstInjectLabel)
            {
                if (item.BackColor == Color.Red)
                {
                    item.BackColor = Color.FromArgb(45, 55, 118);
                }
                else if (item.BackColor == Color.FromArgb(45, 55, 118))
                {
                    item.BackColor = Color.Red;
                }
            }

            foreach (Label item in lstLabel)
            {
                if (item.BackColor == Color.Red)
                {
                    item.BackColor = Color.FromArgb(45, 55, 118);
                }
                else if (item.BackColor == Color.FromArgb(45, 55, 118))
                {
                    item.BackColor = Color.Red;
                }
            }
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

        }
        Random r = new Random();
        int cAni = 0;
        const int TimeAniStop = 30;

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            cAni++;
            foreach (var item in lstInjectLabel)
            {
                item.Text = r.Next(1, 101).ToString();
            }
            foreach (var item in lstLabel)
            {
                item.Text = r.Next(1, 101).ToString();
            }
            if (cAni >= TimeAniStop)
            {
                cAni = 0;
                tmrAnimation.Stop();
                string _argZone = argZone;

                BindingInjectionData(_argZone, PageIdx);
                BindingStabilizationData(_argZone);
            }

        }

        private void sbtnNavPage_Click(object sender, EventArgs e)
        {
            try
            {
                SimpleButton sbtn = ((SimpleButton)sender);
                sbtnPrev.Enabled = true;
                sbtnNext.Enabled = true;
                switch (sbtn.Tag.ToString())
                {
                    case "PREV":
                        PageIdx--;
                        if (PageIdx < 1)
                            PageIdx = MaxPageSeq;
                        else if (PageIdx == 1)
                        {
                            sbtn.Enabled = false;
                        }
                        break;
                    case "NEXT":
                        PageIdx++;
                        if (PageIdx > MaxPageSeq)
                            PageIdx = 1;
                        else if (PageIdx == MaxPageSeq)
                            sbtn.Enabled = false;
                        break;
                }

                BindingInjectionData(argZone, PageIdx);
            }
            catch
            {


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

            ChamberStandMINlstLabel.Add(lblLine_001_001_MIN);
            ChamberStandMINlstLabel.Add(lblLine_001_002_MIN);
            ChamberStandMINlstLabel.Add(lblLine_001_003_MIN);
            ChamberStandMINlstLabel.Add(lblLine_001_004_MIN);
            ChamberStandMINlstLabel.Add(lblLine_001_005_MIN);
            ChamberStandMINlstLabel.Add(lblLine_001_006_MIN);
            ChamberStandMAXlstLabel.Add(lblLine_001_001_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_001_002_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_001_003_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_001_004_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_001_005_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_001_006_MAX);


            lstLabel.Add(lblLine_002_013);
            lstLabel.Add(lblLine_002_014);
            lstLabel.Add(lblLine_002_015);
            lstLabel.Add(lblLine_002_016);
            lstLabel.Add(lblLine_002_017);
            lstLabel.Add(lblLine_002_018);
            lstLabel.Add(lblLine_002_019);
            lstLabel.Add(lblLine_002_020);
            lstLabel.Add(lblLine_002_021);
            lstLabel.Add(lblLine_002_022);
            lstLabel.Add(lblLine_002_023);
            lstLabel.Add(lblLine_002_024);

            ChamberStandMINlstLabel.Add(lblLine_002_013_MIN);
            ChamberStandMINlstLabel.Add(lblLine_002_014_MIN);
            ChamberStandMINlstLabel.Add(lblLine_002_015_MIN);
            ChamberStandMINlstLabel.Add(lblLine_002_016_MIN);
            ChamberStandMINlstLabel.Add(lblLine_002_017_MIN);
            ChamberStandMINlstLabel.Add(lblLine_002_018_MIN);
            ChamberStandMAXlstLabel.Add(lblLine_002_013_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_002_014_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_002_015_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_002_016_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_002_017_MAX);
            ChamberStandMAXlstLabel.Add(lblLine_002_018_MAX);


            //foreach (var item in lstLabel)
            //{
            //    item.Click += Item_Click;
            //}




            //inject label
            lstInjectLabel.Add(lblMC1_INJECT1_01);
            lstInjectLabel.Add(lblMC1_INJECT1_02);
            lstInjectLabel.Add(lblMC1_INJECT1_03);
            lstInjectLabel.Add(lblMC1_INJECT1_04);
            lstInjectLabel.Add(lblMC1_INJECT1_05);
            lstInjectLabel.Add(lblMC1_INJECT1_06);
            lstInjectLabel.Add(lblMC1_INJECT1_07);
            lstInjectLabel.Add(lblMC1_INJECT1_08);

            lstInjectLabel.Add(lblMC1_INJECT2_01);
            lstInjectLabel.Add(lblMC1_INJECT2_02);
            lstInjectLabel.Add(lblMC1_INJECT2_03);
            lstInjectLabel.Add(lblMC1_INJECT2_04);
            lstInjectLabel.Add(lblMC1_INJECT2_05);
            lstInjectLabel.Add(lblMC1_INJECT2_06);
            lstInjectLabel.Add(lblMC1_INJECT2_07);
            lstInjectLabel.Add(lblMC1_INJECT2_08);

            lstInjectLabel.Add(lblMC2_INJECT1_01);
            lstInjectLabel.Add(lblMC2_INJECT1_02);
            lstInjectLabel.Add(lblMC2_INJECT1_03);
            lstInjectLabel.Add(lblMC2_INJECT1_04);
            lstInjectLabel.Add(lblMC2_INJECT1_05);
            lstInjectLabel.Add(lblMC2_INJECT1_06);
            lstInjectLabel.Add(lblMC2_INJECT1_07);
            lstInjectLabel.Add(lblMC2_INJECT1_08);

            lstInjectLabel.Add(lblMC2_INJECT2_01);
            lstInjectLabel.Add(lblMC2_INJECT2_02);
            lstInjectLabel.Add(lblMC2_INJECT2_03);
            lstInjectLabel.Add(lblMC2_INJECT2_04);
            lstInjectLabel.Add(lblMC2_INJECT2_05);
            lstInjectLabel.Add(lblMC2_INJECT2_06);
            lstInjectLabel.Add(lblMC2_INJECT2_07);
            lstInjectLabel.Add(lblMC2_INJECT2_08);

            lstInjectLabel.Add(lblMC3_INJECT1_01);
            lstInjectLabel.Add(lblMC3_INJECT1_02);
            lstInjectLabel.Add(lblMC3_INJECT1_03);
            lstInjectLabel.Add(lblMC3_INJECT1_04);
            lstInjectLabel.Add(lblMC3_INJECT1_05);
            lstInjectLabel.Add(lblMC3_INJECT1_06);
            lstInjectLabel.Add(lblMC3_INJECT1_07);
            lstInjectLabel.Add(lblMC3_INJECT1_08);

            lstInjectLabel.Add(lblMC3_INJECT2_01);
            lstInjectLabel.Add(lblMC3_INJECT2_02);
            lstInjectLabel.Add(lblMC3_INJECT2_03);
            lstInjectLabel.Add(lblMC3_INJECT2_04);
            lstInjectLabel.Add(lblMC3_INJECT2_05);
            lstInjectLabel.Add(lblMC3_INJECT2_06);
            lstInjectLabel.Add(lblMC3_INJECT2_07);
            lstInjectLabel.Add(lblMC3_INJECT2_08);

            //foreach (var item in lstInjectLabel)
            //{
            //    item.Click += Item_Click;
            //}

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
