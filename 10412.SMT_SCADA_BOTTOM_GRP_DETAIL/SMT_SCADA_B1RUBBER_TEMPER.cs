using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_B1RUBBER_TEMPER : Form
    {
        public SMT_SCADA_B1RUBBER_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        #region Variable
        const int ReloadTime = 60; //Seconds
        int cCount = 0;
        DataTable _dt, _dtBanb1, _dtBanb2, _dtRoll11, _dtRoll12, _dtRoll21, _dtRoll22, _dtCald1, _dtCald2;
        double iBanburyMC1 = 0, iBanburyMC2 = 0, iBanburyMat1 = 0, iBanburyMat2 = 0;
        double dBanburyMC1Min = 0, dBanburyMC1Max = 0, dBanburyMC2Min = 0, dBanburyMC2Max = 0, dBanburyMat1Min = 0, dBanburyMat1Max = 0, dBanburyMat2Min = 0, dBanburyMat2Max = 0;

        private void button1_Click(object sender, EventArgs e)
        {

        }

        double iRoll1MC1 = 0, iRoll1MC2 = 0, iRoll2MC1 = 0, iRoll2MC2 = 0;
        double dRoll1MC1Min = 0, dRoll1MC1Max = 0, dRoll1MC2Min = 0, dRoll1MC2Max = 0, dRoll2MC1Min = 0, dRoll2MC1Max = 0, dRoll2MC2Min = 0, dRoll2MC2Max = 0;


        double iCalendarMC1 = 0, iCalendarMC2 = 0, iCalendarMat1 = 0, iCalendarMat2 = 0;
        double dCalendarMC1Min = 0, dCalendarMC1Max = 0, dCalendarMC2Min = 0, dCalendarMC2Max = 0, dCalendarMat1Min = 0, dCalendarMat1Max = 0, dCalendarMat2Min = 0, dCalendarMat2Max = 0;
        #endregion
        private void SMT_SCADA_BOTTOM_OS_TEMPER_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void SMT_SCADA_BOTTOM_OS_TEMPER_V2_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
           // ComVar.Var.callForm = "back";
            tmrDate.Stop();
            ComVar.Var.callForm = "back";

        }
        #region DB
        private DataTable LOAD_DATA()
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_RUB_TEMP_TRACKING";
                //ARGMODE
                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "CV_1";
                MyOraDB.Parameter_Type[0] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = "";
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
        private DataTable LOAD_DATA_HISTORY(string ARG_MLINE_CD, string ARG_MC_ID, string ARG_ROLL_OP_CD)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                // string process_name = "MES.PKG_OS_RUB_TEMP_TRACKING.SP_RUB_TEMP_HISTORY";
                string process_name = "MES.PKG_SMT_B1_DIGITAL.SP_RUB_TEMP_HISTORY";
                //ARGMODE
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_MLINE_CD";
                MyOraDB.Parameter_Name[1] = "ARG_MC_ID";
                MyOraDB.Parameter_Name[2] = "ARG_ROLL_OP_CD";
                MyOraDB.Parameter_Name[3] = "CV_1";
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = ARG_MLINE_CD;
                MyOraDB.Parameter_Values[1] = ARG_MC_ID;
                MyOraDB.Parameter_Values[2] = ARG_ROLL_OP_CD;
                MyOraDB.Parameter_Values[3] = "";
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
        private DataTable SELECT_TEMP_SUM(string arg_mline_cd, string arg_mc_id)
        {
            System.Data.DataSet retDS;
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ReDim_Parameter(3);
            MyOraDB.Process_Name = "MES.PKG_SMT_PROD_SHOW.SEL_EVA_TEMP_TRACKING";

            //02.ARGURMENT ¢¬i
            MyOraDB.Parameter_Name[0] = "ARG_MLINE_CD";
            MyOraDB.Parameter_Name[1] = "ARG_MC_ID";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

            //03.DATA TYPE A¢´AC

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = arg_mline_cd;
            MyOraDB.Parameter_Values[1] = arg_mc_id;
            MyOraDB.Parameter_Values[2] = "";




            MyOraDB.Add_Select_Parameter(true);

            retDS = MyOraDB.Exe_Select_Procedure();

            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        #endregion
        #region Binding Data
        private void BindingData()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                DataTable dt1 = LOAD_DATA_HISTORY("BB101", "001", "BANB");
                DataTable dt2 = LOAD_DATA_HISTORY("BB102", "001", "BANB");

                if (_dtBanb1 == null || _dtBanb1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "001", "BANB");
                else
                    dt1 = _dtBanb1.Copy();
                if (_dtBanb2 == null || _dtBanb2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "001", "BANB");
                else
                    dt2 = _dtBanb2.Copy();

                CreateChartLine(chartBanbury, dt1, "Banbury", " M/C 1", dt2, "M/C 2");

                //Chart Roll
                dt1 = null;
                dt2 = null;
                if (_dtRoll11 == null || _dtRoll11.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "003", "ROLL");
                else
                    dt1 = _dtRoll11.Copy();
                if (_dtRoll12 == null || _dtRoll12.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "003", "ROLL");
                else
                    dt2 = _dtRoll12.Copy();
                if ((dt1 != null && dt1.Rows.Count > 0) || (dt2 != null && dt2.Rows.Count > 0))
                {
                    CreateChartLine(chartRoll1, dt1, "1st Roll", "M/C 1", dt2, "M/C 2");

                }
                //Chart Roll 2
                dt1 = null;
                dt2 = null;
                if (_dtRoll21 == null || _dtRoll21.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "007", "ROLL");
                else
                    dt1 = _dtRoll21.Copy();
                if (_dtRoll22 == null || _dtRoll22.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "007", "ROLL");
                else
                    dt2 = _dtRoll22.Copy();
                //dt1 = checkDt(_dtRoll21,LOAD_DATA_HISTORY("BB101", "007", "ROLL"));
                //dt2 = checkDt(_dtRoll21,LOAD_DATA_HISTORY("BB102", "007", "ROLL"));

                CreateChartLine(chartRoll2, dt1, "2nd Roll", "M/C 1", dt2, "M/C 2");


                //Chart Calender
                dt1 = null;
                dt2 = null;
                if (_dtCald1 == null || _dtCald1.Rows.Count == 0)
                    dt1 = LOAD_DATA_HISTORY("BB101", "008", "CALD");
                else
                    dt1 = _dtCald1.Copy();
                if (_dtCald2 == null || _dtCald2.Rows.Count == 0)
                    dt2 = LOAD_DATA_HISTORY("BB102", "008", "CALD");
                else
                    dt2 = _dtCald2.Copy();
                // dt1 = checkDt(_dtCald1, LOAD_DATA_HISTORY("BB101", "008", "CALD"));
                // dt2 = checkDt(_dtCald2, LOAD_DATA_HISTORY("BB102", "008", "CALD"));

                CreateChartLine(chartCalendar, dt1, "Calender", "M/C 1", dt2, "M/C 2");
                splashScreenManager1.CloseWaitForm();
            }
            catch { splashScreenManager1.CloseWaitForm(); }
        }
        private void BindingDataGauges()
        {
            DataTable dt;
            if (_dt == null || _dt.Rows.Count == 0)
                dt = LOAD_DATA();
            else
                dt = _dt.Copy();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "BANB" && dt.Rows[iRow]["MC_ID"].ToString() == "001")
                    {
                        iBanburyMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dBanburyMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dBanburyMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }

                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "BANB" && dt.Rows[iRow]["MC_ID"].ToString() == "001")
                    {
                        iBanburyMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dBanburyMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dBanburyMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }

                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "BANB" && dt.Rows[iRow]["MC_ID"].ToString() == "002")
                    {
                        iBanburyMat1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dBanburyMat1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dBanburyMat1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }
                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "BANB" && dt.Rows[iRow]["MC_ID"].ToString() == "002")
                    {
                        iBanburyMat2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dBanburyMat2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dBanburyMat2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }


                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003")
                    {
                        iRoll1MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dRoll1MC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dRoll1MC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }
                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003")
                    {
                        iRoll1MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dRoll1MC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dRoll1MC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }

                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "007")
                    {
                        iRoll2MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dRoll2MC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dRoll2MC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }
                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "007")
                    {
                        iRoll2MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dRoll2MC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dRoll2MC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }



                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "CALD" && dt.Rows[iRow]["MC_ID"].ToString() == "008")
                    {
                        iCalendarMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dCalendarMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dCalendarMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }

                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "CALD" && dt.Rows[iRow]["MC_ID"].ToString() == "008")
                    {
                        iCalendarMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dCalendarMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dCalendarMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }

                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB101" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "CALD" && dt.Rows[iRow]["MC_ID"].ToString() == "009")
                    {
                        iCalendarMat1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dCalendarMat1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dCalendarMat1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }
                    if (dt.Rows[iRow]["MLINE_CD"].ToString() == "BB102" && dt.Rows[iRow]["ROLL_OP_CD"].ToString() == "CALD" && dt.Rows[iRow]["MC_ID"].ToString() == "009")
                    {
                        iCalendarMat2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                        dCalendarMat2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                        dCalendarMat2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                    }



                }

            }


            BindingGauges(lnBanburyMC1, iBanburyMC1, dBanburyMC1Min - 10, dBanburyMC1Max + 10, dBanburyMC1Min, dBanburyMC1Max);

            lblBanburyLine1MC.Text = "Temp: " + iBanburyMC1.ToString() + " °C";
            lblBanburyLine1MC._BackColor = lblColor(iBanburyMC1, dBanburyMC1Min, dBanburyMC1Max);
            lblBanburyLine1MCMin.Text = "Min: " + dBanburyMC1Min.ToString() + " °C";
            lblBanburyLine1MCMax.Text = "Max: " + dBanburyMC1Max.ToString() + " °C";

            BindingGauges(lnBanburyMC2, iBanburyMC2, dBanburyMC2Min - 10, dBanburyMC2Max + 10, dBanburyMC2Min, dBanburyMC2Max);
            lblBanburyLine2MC.Text = "Temp: " + iBanburyMC2.ToString() + " °C";
            lblBanburyLine2MC._BackColor = lblColor(iBanburyMC2, dBanburyMC2Min, dBanburyMC2Max);
            lblBanburyLine2MCMin.Text = "Min: " + dBanburyMC2Min.ToString() + " °C";
            lblBanburyLine2MCMax.Text = "Max: " + dBanburyMC2Max.ToString() + " °C";

            BindingGauges(cirBanburyMat1, iBanburyMat1, dBanburyMat1Min - 10, dBanburyMat1Max + 10, dBanburyMat1Min, dBanburyMat1Max);
            lblBanburyLine1Mat.Text = "Temp: " + iBanburyMat1.ToString() + " °C";
            lblBanburyLine1Mat._BackColor = lblColor(iBanburyMat1, dBanburyMat1Min, dBanburyMat1Max);
            lblBanburyLine1MatMin.Text = "Min: " + dBanburyMat1Min.ToString() + " °C";
            lblBanburyLine1MatMax.Text = "Max: " + dBanburyMat1Max.ToString() + " °C";

            BindingGauges(cirBanburyMat2, iBanburyMat2, dBanburyMat2Min - 10, dBanburyMat2Max + 10, dBanburyMat2Min, dBanburyMat2Max);
            lblBanburyLine2Mat.Text = "Temp: " + iBanburyMat2.ToString() + " °C";
            lblBanburyLine2Mat._BackColor = lblColor(iBanburyMat2, dBanburyMat2Min, dBanburyMat2Max);
            lblBanburyLine2MatMin.Text = "Min: " + dBanburyMat2Min.ToString() + " °C";
            lblBanburyLine2MatMax.Text = "Max: " + dBanburyMat2Max.ToString() + " °C";


            BindingGauges(lnRollMC11, iRoll1MC1, dRoll1MC1Min - 10, dRoll1MC1Max + 10, dRoll1MC1Min, dRoll1MC1Max);
            lblRoll1Line1MC.Text = "Temp: " + iRoll1MC1.ToString() + " °C";
            lblRoll1Line1MC._BackColor = lblColor(iRoll1MC1, dRoll1MC1Min, dRoll1MC1Max);
            lblRoll1Line1MCMin.Text = "Min: " + dRoll1MC1Min.ToString() + " °C";
            lblRoll1Line1MCMax.Text = "Max: " + dRoll1MC1Max.ToString() + " °C";

            BindingGauges(lnRollMC12, iRoll1MC2, dRoll1MC2Min - 10, dRoll1MC2Max + 10, dRoll1MC2Min, dRoll1MC2Max);
            lblRoll1Line2MC.Text = "Temp: " + iRoll1MC2.ToString() + " °C";
            lblRoll1Line2MC._BackColor = lblColor(iRoll1MC2, dRoll1MC2Min, dRoll1MC2Max);
            lblRoll1Line2MCMin.Text = "Min: " + dRoll1MC2Min.ToString() + " °C";
            lblRoll1Line2MCMax.Text = "Max: " + dRoll1MC2Max.ToString() + " °C";

            BindingGauges(lnRollMC21, iRoll2MC1, dRoll2MC1Min - 10, dRoll2MC1Max + 10, dRoll2MC1Min, dRoll2MC1Max);
            lblRoll2Line1MC.Text = "Temp: " + iRoll2MC1.ToString() + " °C";
            lblRoll2Line1MC._BackColor = lblColor(iRoll2MC1, dRoll2MC1Min, dRoll2MC1Max);
            lblRoll2Line1MCMin.Text = "Min: " + dRoll2MC1Min.ToString() + " °C";
            lblRoll2Line1MCMax.Text = "Max: " + dRoll2MC1Max.ToString() + " °C";

            BindingGauges(lnRollMC22, iRoll2MC2, dRoll2MC2Min - 10, dRoll2MC2Max + 10, dRoll2MC2Min, dRoll2MC2Max);
            lblRoll2Line2MC.Text = "Temp: " + iRoll2MC2.ToString() + " °C";
            lblRoll2Line2MC._BackColor = lblColor(iRoll2MC2, dRoll2MC2Min, dRoll2MC2Max);
            lblRoll2Line2MCMin.Text = "Min: " + dRoll2MC2Min.ToString() + " °C";
            lblRoll2Line2MCMax.Text = "Max: " + dRoll2MC2Max.ToString() + " °C";


            BindingGauges(lnCalendarMC1, iCalendarMC1, dCalendarMC1Min - 10, dCalendarMC1Max + 10, dCalendarMC1Min, dCalendarMC1Max);
            lblCalendarLine1MC.Text = "Temp: " + iCalendarMC1.ToString() + " °C";
            lblCalendarLine1MC._BackColor = lblColor(iCalendarMC1, dCalendarMC1Min, dCalendarMC1Max);
            lblCalendarLine1MCMin.Text = "Min: " + dCalendarMC1Min.ToString() + " °C";
            lblCalendarLine1MCMax.Text = "Max: " + dCalendarMC1Max.ToString() + " °C";

            BindingGauges(lnCalendarMC2, iCalendarMC2, dCalendarMC2Min - 10, dCalendarMC2Max + 10, dCalendarMC2Min, dCalendarMC2Max);
            lblCalendarLine2MC.Text = "Temp: " + iCalendarMC2.ToString() + " °C";
            lblCalendarLine2MC._BackColor = lblColor(iCalendarMC2, dCalendarMC2Min, dCalendarMC2Max);
            lblCalendarLine2MCMin.Text = "Min: " + dCalendarMC2Min.ToString() + " °C";
            lblCalendarLine2MCMax.Text = "Max: " + dCalendarMC2Max.ToString() + " °C";

            BindingGauges(cirCalendarMat1, iCalendarMat1, dCalendarMat1Min - 10, dCalendarMat1Max + 10, dCalendarMat1Min, dCalendarMat1Max);
            lblCalendarLine1Mat.Text = "Temp: " + iCalendarMat1.ToString() + " °C";
            lblCalendarLine1Mat._BackColor = lblColor(iCalendarMat1, dCalendarMat1Min, dCalendarMat1Max);
            lblCalendarLine1MatMin.Text = "Min: " + dCalendarMat1Min.ToString() + " °C";
            lblCalendarLine1MatMax.Text = "Max: " + dCalendarMat1Max.ToString() + " °C";


            BindingGauges(cirCalendarMat2, iCalendarMat2, dCalendarMat2Min - 10, dCalendarMat2Max + 10, dCalendarMat2Min, dCalendarMat2Max);
            lblCalendarLine2Mat.Text = "Temp: " + iCalendarMat2.ToString() + " °C";
            lblCalendarLine2Mat._BackColor = lblColor(iCalendarMat2, dCalendarMat2Min, dCalendarMat2Max);
            lblCalendarLine2MatMin.Text = "Min: " + dCalendarMat2Min.ToString() + " °C";
            lblCalendarLine2MatMax.Text = "Max: " + dCalendarMat2Max.ToString() + " °C";

            button1_Click(null,null);
        }


        #endregion

        #region Method Create
        private Color lblColor(double Val, double MinVal, double MaxVal)
        {
            if (Val == 0 && MinVal == 0 && MaxVal == 0) return Color.Silver;
            if (Val < MinVal || Val > MaxVal)
                return Color.Red;
            else
                return Color.LimeGreen;
        }
        private void CreateChartLine(ChartControl arg_chart, DataTable arg_dt1, string arg_name1, string arg_serial_name1, DataTable arg_dt2, string arg_serial_name2)
        {
            try
            {
                //  if (arg_dt1 == null || arg_dt1.Rows.Count == 0) return;
                //  if (arg_dt2 == null || arg_dt2.Rows.Count == 0) return;
                int iRow = 0;
                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                    iRow = arg_dt2.Rows.Count;
                else
                    iRow = arg_dt1.Rows.Count;

                //----------create--------------------
                arg_chart.Series.Clear();
                arg_chart.Titles.Clear();
                arg_chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;
                // ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();

                Series series1 = new Series(arg_serial_name1, ViewType.Spline);
                Series series2 = new Series(arg_serial_name2, ViewType.Spline);

                DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();

                DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();

                DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();

                //--------- Add data Point------------
                if (arg_dt1 != null && arg_dt1.Rows.Count > 0)
                {
                    try
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                            {
                                if (arg_dt1.Rows[i]["VALUE"] == null)
                                    series1.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), ""));
                                else
                                    series1.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), arg_dt1.Rows[i]["VALUE"]));
                            }
                            else
                            {
                                if (arg_dt1.Rows[i]["VALUE"] == null)
                                    series1.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), ""));
                                else
                                    series1.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), arg_dt1.Rows[i]["VALUE"]));
                            }

                        }
                    }
                    catch
                    { }


                }
                series1.ArgumentScaleType = ScaleType.Qualitative;

                if (arg_dt2 != null && arg_dt2.Rows.Count > 0)
                {

                    try
                    {
                        for (int i = 0; i < iRow; i++)
                        {
                            if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                            {
                                series2.Points.Add(new SeriesPoint(arg_dt2.Rows[i]["T_HMS"].ToString(), arg_dt2.Rows[i]["VALUE"]));

                            }
                            else
                            {
                                series2.Points.Add(new SeriesPoint(arg_dt1.Rows[i]["T_HMS"].ToString(), arg_dt2.Rows[i]["VALUE"]));
                            }

                        }
                    }
                    catch
                    { }
                }
                series2.ArgumentScaleType = ScaleType.Qualitative;

                arg_chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] { series1, series2 };


                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();

                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine();

                //title
                DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
                chartTitle2.Alignment = System.Drawing.StringAlignment.Near;
                chartTitle2.Font = new System.Drawing.Font("Times New Roman", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chartTitle2.Text = arg_name1;
                chartTitle2.TextColor = System.Drawing.Color.Yellow;
                arg_chart.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] { chartTitle2 });

                //Constant line
                //constantLine1.ShowInLegend = false;

                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                {
                    constantLine1.AxisValueSerializable = arg_dt2.Rows[0]["MINVAL"].ToString();
                    constantLine2.AxisValueSerializable = arg_dt2.Rows[0]["MAXVAL"].ToString();
                }
                else
                {
                    constantLine1.AxisValueSerializable = arg_dt1.Rows[0]["MINVAL"].ToString();
                    constantLine2.AxisValueSerializable = arg_dt1.Rows[0]["MAXVAL"].ToString();
                }


                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";

                constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine2.Name = "Max";
                // constantLine1.ShowBehind = false;
                constantLine1.Title.Visible = false;
                constantLine1.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine1.LineStyle.Thickness = 3;
                constantLine2.Title.Visible = false;
                constantLine2.Title.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine2.LineStyle.Thickness = 3;
                // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.Clear();
                ((XYDiagram)arg_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });


                // format Series 
                splineSeriesView1.LineStyle.Thickness = 3;
                splineSeriesView2.LineStyle.Thickness = 3;
                splineSeriesView2.Color = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

                series1.View = splineSeriesView1;
                series2.View = splineSeriesView2;

                xySeriesUnwindAnimation1.EasingFunction = sineEasingFunction1;
                splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
                splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation1;

                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.Auto = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.AutoSideMargins = false;
                ((XYDiagram)arg_chart.Diagram).AxisX.VisualRange.SideMarginsValue = 2;
                //((XYDiagram)arg_chart.Diagram).AxisX.Label.Angle = 0;
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
                ((XYDiagram)arg_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)arg_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.AutoGrid = false;
                ((XYDiagram)arg_chart.Diagram).AxisY.NumericScaleOptions.GridSpacing = 1;
                //--------Text AxisX/ AxisY
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Text = "Temperature";
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.TextColor = Color.Yellow;
                ((XYDiagram)arg_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;

                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.Auto = false;
                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.AutoSideMargins = false;
                //  ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.SideMarginsValue = 1;               
                // ((XYDiagram)arg_chart.Diagram).AxisY.Tickmarks.MinorVisible = false;

                ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.Auto = true;
                if (arg_dt1.Rows.Count <= arg_dt2.Rows.Count)
                    ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt2.Rows[0]["MINVAL"].ToString()) - 5, Convert.ToInt32(arg_dt2.Rows[0]["MAXVAL"].ToString()) + 5);
                else
                    ((XYDiagram)arg_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(Convert.ToInt32(arg_dt1.Rows[0]["MINVAL"].ToString()) - 5, Convert.ToInt32(arg_dt1.Rows[0]["MAXVAL"].ToString()) + 5);

                //Phuoc Continues Format
                ((XYDiagram)arg_chart.Diagram).AxisY.GridLines.Visible = false;

                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MinValue = Convert.ToInt32(arg_dt1.Rows[0]["MINVAL"].ToString()) - 2;
                // ((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MaxValue = Convert.ToInt32(arg_dt1.Rows[0]["MAXVAL"].ToString()) + 2;
                //((XYDiagram)arg_chart.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;

                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MinValue = 25;
                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.MaxValue = 55;


                //((XYDiagram)arg_chart.Diagram).AxisY.VisualRange.SetMinMaxValues(arg_dt1.Rows[0]["MINVAL"], arg_dt1.Rows[0]["MAXVAL"]);

                // ((XYDiagram)arg_chart.Diagram).AxisX.Title.Text = "HMS";
                //  ((XYDiagram)arg_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
                // ((XYDiagram)arg_chart.Diagram).AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            }
            catch (Exception ex)
            {

            }
        }
        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            double _iMin = 0, _iMax = 100;
            if (num > 0)
            {
                _iMin = iMin;
                _iMax = iMax;
            }
           // circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = (float)_iMin;
            circularGauge.Scales[0].MaxValue = (float)_iMax;

            //circularGauge.Scales[0].Value = 0;

            //circularGauge.Labels[0].Text = "0";
            if (circularGauge.Scales[0].Ranges.Count >= 3 && num > 0)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();



                circularGauge.Scales[0].Value = (float)num;


                //labelGauges.Text = num.ToString();
            }
            catch (Exception ex)
            { }
            // }
        }
        private void BindingGauges(DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge, double num, double iMin, double iMax, double iRangeMin, double iRangeMax)
        {
            // DataTable dt = SEL_POD("014", "001");
            if (circularGauge.Scales.Count <= 0)
            {
                return;
            }
            double _iMin = 0, _iMax = 100;
            if (num > 0)
            {
                _iMin = iMin;
                _iMax = iMax;
            }
           // circularGauge.Scales[0].EnableAnimation = false;
            //arcScaleGauges.EasingFunction = new BackEase();
            circularGauge.Scales[0].MinValue = (float)_iMin;
            circularGauge.Scales[0].MaxValue = (float)_iMax;
            //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(10);
            //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(15);
            //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(20);
           // circularGauge.Scales[0].Value = 0;

            if (circularGauge.Scales[0].Ranges.Count >= 3 && num > 0)
            {
                circularGauge.Scales[0].Ranges[0].StartValue = (float)iMin;
                circularGauge.Scales[0].Ranges[0].EndValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].StartValue = (float)iRangeMin;
                circularGauge.Scales[0].Ranges[1].EndValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].StartValue = (float)iRangeMax;
                circularGauge.Scales[0].Ranges[2].EndValue = (float)iMax;

            }
            //labelGauges.Text = "0";
            //if (dt != null && dt.Rows.Count > 0)
            //{
            try
            {

                //circularGauge.Scales[0].MinValue = (float)iMin;
                //circularGauge.Scales[0].MaxValue = (float)iMax;
                //arcScaleGauges.Ranges[0].EndValue = arcScaleGauges.Ranges[1].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) - 2);
                //arcScaleGauges.Ranges[1].EndValue = arcScaleGauges.Ranges[2].StartValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 2);
                //arcScaleGauges.Ranges[2].EndValue = Convert.ToSingle(Convert.ToSingle(dt.Rows[0][0]) + 5);

                circularGauge.Scales[0].EnableAnimation = true;
                circularGauge.Scales[0].EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                //arcScaleGauges.EasingFunction = new BackEase();


                circularGauge.Scales[0].Value = (float)num;

                //labelGauges.Text = num.ToString();
            }
            catch (Exception ex)
            { }
            // }
        }
        #endregion

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                BindingDataGauges();
                BindingData();
                //Doing Something?????
            }
        }
    }
}
