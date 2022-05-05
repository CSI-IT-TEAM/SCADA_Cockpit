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
    public partial class SMT_SCADA_B2COMPOUND_TEMPER : Form
    {
        //B2 Roll
        public SMT_SCADA_B2COMPOUND_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }

        #region Variable
        DataTable _dt, _dtKned1, _dtKned2, _dtKned3, _dtRoll1, _dtRoll2, _dtRoll3, _dtExtr1, _dtExtr2, _dtExtr3, _dtPall1, _dtPall2, _dtPall3;

        private void SMT_SCADA_B2COMPOUND_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }

        const int ReloadTime = 60;
        int cCount = 0;
        double dKneaderMC1 = 0, dKneaderMC1Min = 0, dKneaderMC1Max = 0, dKneaderMat1 = 0, dKneaderMat1Min = 0, dKneaderMat1Max = 0,
               dKneaderMC2 = 0, dKneaderMC2Min = 0, dKneaderMC2Max = 0, dKneaderMat2 = 0, dKneaderMat2Min = 0, dKneaderMat2Max = 0,
               dKneaderMC3 = 0, dKneaderMC3Min = 0, dKneaderMC3Max = 0, dKneaderMat3 = 0, dKneaderMat3Min = 0, dKneaderMat3Max = 0,

               dRollMC1 = 0, dRollMC1Min = 0, dRollMC1Max = 0,
               dRollMC2 = 0, dRollMC2Min = 0, dRollMC2Max = 0,
               dRollMC3 = 0, dRollMC3Min = 0, dRollMC3Max = 0,

               dExtrMat1 = 0, dExtrMat1Min = 0, dExtrMat1Max = 0,
            dExtrMat2 = 0, dExtrMat2Min = 0, dExtrMat2Max = 0,
            dExtrMat3 = 0, dExtrMat3Min = 0, dExtrMat3Max = 0,

               dPall1Seed = 0, dPall1SeedMin = 0, dPall1SeedMax = 0,
             dPall2Seed = 0, dPall2SeedMin = 0, dPall2SeedMax = 0,
             dPall3Seed = 0, dPall3SeedMin = 0, dPall3SeedMax = 0;


        #endregion

        #region DB
        private DataTable LOAD_TRACKING_DATA(string ARG_QTYPE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_B2ROLL_TEMP_TRACKING";
                //ARGMODE
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = "";
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

        private DataTable LOAD_HISTORY_DATA(string ARG_QTYPE, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_B2ROLL_TEMP_HISTORY";
                //ARGMODE
                MyOraDB.ReDim_Parameter(3);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_DATE";
                MyOraDB.Parameter_Name[2] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = ARG_QTYPE;
                MyOraDB.Parameter_Values[1] = ARG_DATE;
                MyOraDB.Parameter_Values[2] = "";
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


        #region Binding
        private Color lblColor(double Val, double MinVal, double MaxVal)
        {
            if (Val == 0 && MinVal == 0 && MaxVal == 0) return Color.Silver;
            if (Val < MinVal || Val > MaxVal)
                return Color.Red;
            else
                return Color.LimeGreen;
        }
        private void BindingDataGauges()
        {
            DataTable dt;
            dKneaderMC1 = 0; dKneaderMC1Min = 0; dKneaderMC1Max = 0; dKneaderMat1 = 0; dKneaderMat1Min = 0; dKneaderMat1Max = 0;
            dKneaderMC2 = 0; dKneaderMC2Min = 0; dKneaderMC2Max = 0; dKneaderMat2 = 0; dKneaderMat2Min = 0; dKneaderMat2Max = 0;
            dKneaderMC3 = 0; dKneaderMC3Min = 0; dKneaderMC3Max = 0; dKneaderMat3 = 0; dKneaderMat3Min = 0; dKneaderMat3Max = 0;

            dRollMC1 = 0; dRollMC1Min = 0; dRollMC1Max = 0;
            dRollMC2 = 0; dRollMC2Min = 0; dRollMC2Max = 0;
            dRollMC3 = 0; dRollMC3Min = 0; dRollMC3Max = 0;

            dExtrMat1 = 0; dExtrMat1Min = 0; dExtrMat1Max = 0;
            dExtrMat2 = 0; dExtrMat2Min = 0; dExtrMat2Max = 0;
            dExtrMat3 = 0; dExtrMat3Min = 0; dExtrMat3Max = 0;

            dPall1Seed = 0; dPall1SeedMin = 0; dPall1SeedMax = 0;
            dPall2Seed = 0; dPall2SeedMin = 0; dPall2SeedMax = 0;
            dPall3Seed = 0; dPall3SeedMin = 0; dPall3SeedMax = 0;

            if (_dt == null || _dt.Rows.Count == 0)
                dt = LOAD_TRACKING_DATA("Q");
            else
                dt = _dt.Copy();
            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                    {

                        //KNEADER
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD202" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dKneaderMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD202" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1 Material
                        {
                            dKneaderMat1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMat1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMat1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD203" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "001")  //Kneader Machine 2
                        {
                            dKneaderMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD203" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "002")  //Kneader Machine 2 Material
                        {
                            dKneaderMat2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMat2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMat2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD204" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "001")  //Kneader Machine 3
                        {
                            dKneaderMC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMC3Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMC3Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD204" && dt.Rows[iRow]["OP_CD"].ToString() == "KNED" && dt.Rows[iRow]["MC_ID"].ToString() == "002")  //Kneader Machine 3 Material
                        {
                            dKneaderMat3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dKneaderMat3Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dKneaderMat3Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }


                        //ROLL
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD202" && dt.Rows[iRow]["OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //ROLL 1
                        {
                            dRollMC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dRollMC1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dRollMC1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD203" && dt.Rows[iRow]["OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //ROLL 2
                        {
                            dRollMC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dRollMC2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dRollMC2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD204" && dt.Rows[iRow]["OP_CD"].ToString() == "ROLL" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //ROLL 3
                        {
                            dRollMC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dRollMC3Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dRollMC3Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }


                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD202" && dt.Rows[iRow]["OP_CD"].ToString() == "EXTR" && dt.Rows[iRow]["MC_ID"].ToString() == "009") //extruder 1
                        {
                            dExtrMat1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dExtrMat1Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dExtrMat1Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD203" && dt.Rows[iRow]["OP_CD"].ToString() == "EXTR" && dt.Rows[iRow]["MC_ID"].ToString() == "009") //extruder 1
                        {
                            dExtrMat2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dExtrMat2Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dExtrMat2Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD204" && dt.Rows[iRow]["OP_CD"].ToString() == "EXTR" && dt.Rows[iRow]["MC_ID"].ToString() == "009") //extruder 1
                        {
                            dExtrMat3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dExtrMat3Min = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dExtrMat3Max = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }


                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD202" && dt.Rows[iRow]["OP_CD"].ToString() == "PELL" && dt.Rows[iRow]["MC_ID"].ToString() == "008") //PALL Seed 1
                        {
                            dPall1Seed = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dPall1SeedMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dPall1SeedMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD203" && dt.Rows[iRow]["OP_CD"].ToString() == "PELL" && dt.Rows[iRow]["MC_ID"].ToString() == "008") //PALL Seed 2
                        {
                            dPall2Seed = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dPall2SeedMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dPall2SeedMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["MLINE_CD"].ToString() == "KD204" && dt.Rows[iRow]["OP_CD"].ToString() == "PELL" && dt.Rows[iRow]["MC_ID"].ToString() == "008") //PALL Seed 3
                        {
                            dPall3Seed = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dPall3SeedMin = Convert.ToInt32(dt.Rows[iRow]["MINVAL"].ToString());
                            dPall3SeedMax = Convert.ToInt32(dt.Rows[iRow]["MaxVAL"].ToString());
                        }
                    }

                }

                //Kneader================================
                BindingGauges(lnKneaderMC1, dKneaderMC1, dKneaderMC1Min - 10, dKneaderMC1Max + 10, dKneaderMC1Min, dKneaderMC1Max);
                lblKneaderMC1.Text = "Temp: " + dKneaderMC1.ToString() + " °C";
                lblKneaderMC1._BackColor = lblColor(dKneaderMC1, dKneaderMC1Min, dKneaderMC1Max);
                lblKneaderMC1Min.Text = "Min: " + dKneaderMC1Min.ToString() + " °C";
                lblKneaderMC1Max.Text = "Max: " + dKneaderMC1Max.ToString() + " °C";

                BindingGauges(cirKneaderMat1, dKneaderMat1, dKneaderMat1Min - 10, dKneaderMat1Max + 10, dKneaderMat1Min, dKneaderMat1Max);
                lblKneaderMat1.Text = "Temp: " + dKneaderMat1.ToString() + " °C";
                lblKneaderMat1._BackColor = lblColor(dKneaderMat1, dKneaderMat1Min, dKneaderMat1Max);
                lblKneaderMat1Min.Text = "Min: " + dKneaderMat1Min.ToString() + " °C";
                lblKneaderMat1Max.Text = "Max: " + dKneaderMat1Max.ToString() + " °C";

                BindingGauges(lnKneaderMC2, dKneaderMC2, dKneaderMC2Min - 10, dKneaderMC2Max + 10, dKneaderMC2Min, dKneaderMC2Max);
                lblKneaderMC2.Text = "Temp: " + dKneaderMC2.ToString() + " °C";
                lblKneaderMC2._BackColor = lblColor(dKneaderMC2, dKneaderMC2Min, dKneaderMC2Max);
                lblKneaderMC2Min.Text = "Min: " + dKneaderMC2Min.ToString() + " °C";
                lblKneaderMC2Max.Text = "Max: " + dKneaderMC2Max.ToString() + " °C";

                BindingGauges(cirKneaderMat2, dKneaderMat2, dKneaderMat2Min - 10, dKneaderMat2Max + 10, dKneaderMat2Min, dKneaderMat2Max);
                lblKneaderMat2.Text = "Temp: " + dKneaderMat2.ToString() + " °C";
                lblKneaderMat2._BackColor = lblColor(dKneaderMat2, dKneaderMat2Min, dKneaderMat2Max);
                lblKneaderMat2Min.Text = "Min: " + dKneaderMat2Min.ToString() + " °C";
                lblKneaderMat2Max.Text = "Max: " + dKneaderMat2Max.ToString() + " °C";

                BindingGauges(lnKneaderMC3, dKneaderMC3, dKneaderMC3Min - 10, dKneaderMC3Max + 10, dKneaderMC3Min, dKneaderMC3Max);
                lblKneaderMC3.Text = "Temp: " + dKneaderMC3.ToString() + " °C";
                lblKneaderMC3._BackColor = lblColor(dKneaderMC3, dKneaderMC3Min, dKneaderMC3Max);
                lblKneaderMC3Min.Text = "Min: " + dKneaderMC3Min.ToString() + " °C";
                lblKneaderMC3Max.Text = "Max: " + dKneaderMC3Max.ToString() + " °C";

                BindingGauges(cirKneaderMat3, dKneaderMat3, dKneaderMat3Min - 10, dKneaderMat3Max + 10, dKneaderMat3Min, dKneaderMat3Max);
                lblKneaderMat3.Text = "Temp: " + dKneaderMat3.ToString() + " °C";
                lblKneaderMat3._BackColor = lblColor(dKneaderMat3, dKneaderMat3Min, dKneaderMat3Max);
                lblKneaderMat3Min.Text = "Min: " + dKneaderMat3Min.ToString() + " °C";
                lblKneaderMat3Max.Text = "Max: " + dKneaderMat3Max.ToString() + " °C";
                //Roll1================================
                BindingGauges(lnRollMC1, dRollMC1, dRollMC1Min - 10, dRollMC1Max + 10, dRollMC1Min, dRollMC1Max);
                lblRollMC1.Text = "Temp: " + dRollMC1.ToString() + " °C";
                lblRollMC1._BackColor = lblColor(dRollMC1, dRollMC1Min, dRollMC1Max);
                lblRollMC1Min.Text = "Min: " + dRollMC1Min.ToString() + " °C";
                lblRollMC1Max.Text = "Max: " + dRollMC1Max.ToString() + " °C";
                //Roll2================================
                BindingGauges(lnRollMC2, dRollMC2, dRollMC2Min - 10, dRollMC2Max + 10, dRollMC2Min, dRollMC2Max);
                lblRollMC2.Text = "Temp: " + dRollMC2.ToString() + " °C";
                lblRollMC2._BackColor = lblColor(dRollMC2, dRollMC2Min, dRollMC2Max);
                lblRollMC2Min.Text = "Min: " + dRollMC2Min.ToString() + " °C";
                lblRollMC2Max.Text = "Max: " + dRollMC2Max.ToString() + " °C";
                //Roll3================================
                BindingGauges(lnRollMC3, dRollMC3, dRollMC3Min - 10, dRollMC3Max + 10, dRollMC3Min, dRollMC3Max);
                lblRollMC3.Text = "Temp: " + dRollMC3.ToString() + " °C";
                lblRollMC3._BackColor = lblColor(dRollMC3, dRollMC3Min, dRollMC3Max);
                lblRollMC3Min.Text = "Min: " + dRollMC3Min.ToString() + " °C";
                lblRollMC3Max.Text = "Max: " + dRollMC3Max.ToString() + " °C";
                //Extr1================================
                BindingGauges(cirEXTRMat1, dExtrMat1, dExtrMat1Min - 10, dExtrMat1Max + 10, dExtrMat1Min, dExtrMat1Max);
                lblEXTRMat1.Text = "Temp: " + dExtrMat1.ToString() + " °C";
                lblEXTRMat1._BackColor = lblColor(dExtrMat1, dExtrMat1Min, dExtrMat1Max);
                lblEXTRMat1Min.Text = "Min: " + dExtrMat1Min.ToString() + " °C";
                lblEXTRMat1Max.Text = "Max: " + dExtrMat1Max.ToString() + " °C";
                //Extr2================================
                BindingGauges(cirEXTRMat2, dExtrMat2, dExtrMat2Min - 10, dExtrMat2Max + 10, dExtrMat2Min, dExtrMat2Max);
                lblEXTRMat2.Text = "Temp: " + dExtrMat2.ToString() + " °C";
                lblEXTRMat2._BackColor = lblColor(dExtrMat2, dExtrMat2Min, dExtrMat2Max);
                lblEXTRMat2Min.Text = "Min: " + dExtrMat2Min.ToString() + " °C";
                lblEXTRMat2Max.Text = "Max: " + dExtrMat2Max.ToString() + " °C";
                //Extr3================================
                BindingGauges(cirEXTRMat3, dExtrMat3, dExtrMat3Min - 10, dExtrMat3Max + 10, dExtrMat3Min, dExtrMat3Max);
                lblEXTRMat3.Text = "Temp: " + dExtrMat3.ToString() + " °C";
                lblEXTRMat3._BackColor = lblColor(dExtrMat3, dExtrMat3Min, dExtrMat3Max);
                lblEXTRMat3Min.Text = "Min: " + dExtrMat3Min.ToString() + " °C";
                lblEXTRMat3Max.Text = "Max: " + dExtrMat3Max.ToString() + " °C";
                //Pall1================================
                BindingGauges(cirPELLSeed1, dPall1Seed, dPall1SeedMin - 10, dPall1SeedMax + 10, dPall1SeedMin, dPall1SeedMax);
                lblPELLSeed1.Text = "Temp: " + dPall1Seed.ToString() + " °C";
                lblPELLSeed1._BackColor = lblColor(dPall1Seed, dPall1SeedMin, dPall1SeedMax);
                lblPELLSeed1Min.Text = "Min: " + dPall1SeedMin.ToString() + " °C";
                lblPELLSeed1Max.Text = "Max: " + dPall1SeedMax.ToString() + " °C";
                //Pall1================================
                BindingGauges(cirPELLSeed2, dPall2Seed, dPall2SeedMin - 10, dPall2SeedMax + 10, dPall2SeedMin, dPall2SeedMax);
                lblPELLSeed2.Text = "Temp: " + dPall2Seed.ToString() + " °C";
                lblPELLSeed2._BackColor = lblColor(dPall2Seed, dPall2SeedMin, dPall2SeedMax);
                lblPELLSeed2Min.Text = "Min: " + dPall2SeedMin.ToString() + " °C";
                lblPELLSeed2Max.Text = "Max: " + dPall2SeedMax.ToString() + " °C";
                //Pall1================================
                BindingGauges(cirPELLSeed3, dPall3Seed, dPall3SeedMin - 10, dPall3SeedMax + 10, dPall3SeedMin, dPall3SeedMax);
                lblPELLSeed3.Text = "Temp: " + dPall3Seed.ToString() + " °C";
                lblPELLSeed3._BackColor = lblColor(dPall3Seed, dPall3SeedMin, dPall3SeedMax);
                lblPELLSeed3Min.Text = "Min: " + dPall3SeedMin.ToString() + " °C";
                lblPELLSeed3Max.Text = "Max: " + dPall3SeedMax.ToString() + " °C";

                btnTest_Click(null, null);
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void BindingDataChart(string Title,ChartControl chart, string op_cd, DataTable dt)
        {
            try
            {
                List<DataTable> lstData = new List<DataTable>();
                List<string> lstSeriesName = new List<string>();
                if (dt.Select("OP_CD = '" + op_cd + "'").Count() > 0)
                {

                    DataView view = new DataView(dt.Select("OP_CD = '" + op_cd + "'").CopyToDataTable());

                    DataTable dtTemp = view.ToTable(true, "OP_CD", "MLINE_CD");

                    foreach (DataRow dr in dtTemp.Rows)
                    {
                        if (dt.Select("OP_CD = '" + op_cd + "' and MLINE_CD = '" + dr["MLINE_CD"] + "'").Count() > 0)
                        {
                            DataTable _dt = dt.Select("OP_CD = '" + op_cd + "' and MLINE_CD = '" + dr["MLINE_CD"] + "'").CopyToDataTable();
                            lstData.Add(_dt);
                            lstSeriesName.Add(dr["MLINE_CD"].ToString());
                        }
                    }
                }
                CreateChart(Title,lstData, lstSeriesName, chart);
            }
            catch
            {

            }


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
        #endregion


        #region Create Controls After Binding
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

            // circularGauge.Scales[0].Value = 0;

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
            //circularGauge.Scales[0].EnableAnimation = false;
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

        private void CreateChart(string Title,List<DataTable> lstData, List<string> listSeriesName, ChartControl _chart)
        {
            try
            {
                int minRow = 0, minRange = 0, maxRange = 0;
                const int iThickness = 3;
                //List Range Min, Range Max;
                List<int> lstRgMin = new List<int>();
                List<int> lstRgMax = new List<int>();
                DataTable dtarg = new DataTable();
                List<int> lstRowCount = new List<int>();
                List<Series> lstSeries = new List<Series>();
                _chart.AnimationStartMode = ChartAnimationMode.OnDataChanged;
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (lstData[i].Rows[0]["MIN_VL"] != null)
                    {
                        int MinVl = int.Parse(lstData[i].Rows[0]["MIN_VL"].ToString());
                        lstRgMin.Add(MinVl);
                    }
                    if (lstData[i].Rows[0]["MAX_VL"] != null)
                    {
                        int MaxVl = int.Parse(lstData[i].Rows[0]["MAX_VL"].ToString());
                        lstRgMax.Add(MaxVl);
                    }

                    // lstRowCount.Add(lstData[i].Rows.Count);
                    if (lstData[i].AsEnumerable().Reverse().Take(10).Count() > 0)
                    {
                        lstRowCount.Add(lstData[i].AsEnumerable().Reverse().Take(10).CopyToDataTable().Rows.Count);
                    }
                    else
                    {
                        lstRowCount.Add(lstData[i].Rows.Count);
                    }

                }
                minRow = GetMinValue(lstRowCount);   //Tim datatable co so dong nho nhat.
                minRange = GetMinValue(lstRgMin);
                maxRange = GetMaxValue(lstRgMax);
                _chart.Series.Clear(); //Remove het series truoc khi add moi.

                for (int i = 0; i < lstData.Count; i++) //Khoi tao so luong series & add vao list Series
                {
                    Series series = new Series(listSeriesName[i], ViewType.Spline);
                    DevExpress.XtraCharts.SplineSeriesView splineSeriesView = new DevExpress.XtraCharts.SplineSeriesView();
                    splineSeriesView.LineStyle.Thickness = iThickness;
                    series.View = splineSeriesView;
                    series.ArgumentScaleType = ScaleType.Qualitative;
                    lstSeries.Add(series);
                    if (lstData[i].AsEnumerable().Reverse().Take(10).Count() > 0)
                    {
                        if (minRow == lstData[i].AsEnumerable().Reverse().Take(10).CopyToDataTable().Rows.Count)
                        {
                            dtarg = lstData[i].AsEnumerable().Reverse().Take(10).OrderBy(r => r.Field<string>("HMS")).CopyToDataTable();
                        }

                    }
                    else
                    {
                        if (minRow == lstData[i].Rows.Count)
                        {
                            dtarg = lstData[i];
                        }
                    }

                }
                for (int j = 0; j < minRow; j++)
                {
                    for (int k = 0; k < lstSeries.Count; k++)
                    {
                        lstSeries[k].Points.Add(new SeriesPoint(dtarg.Rows[j]["HMS"].ToString(), lstData[k].Rows[j]["VALUE"]));
                    }

                }

                for (int h = 0; h < lstSeries.Count; h++)
                {
                    _chart.Series.Add(lstSeries[h]);
                }
                ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.Clear();

                DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine(); ////Constant line
                                                                                                             //constantLine1.ShowInLegend = false;
                constantLine1.AxisValueSerializable = dtarg.Rows[0]["MIN_VL"].ToString();
                constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine1.Name = "Min";
                constantLine2.AxisValueSerializable = dtarg.Rows[0]["MAX_VL"].ToString();
                constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                constantLine2.Name = "Max";
                // constantLine1.ShowBehind = false;
                constantLine1.Title.Visible = false;
                constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine1.LineStyle.Thickness = iThickness;
                constantLine2.Title.Visible = false;
                constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //constantLine1.Title.Text = "Target";
                constantLine2.LineStyle.Thickness = iThickness;
                // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });
                _chart.Legend.BackColor = Color.Black;
                //Whole Range Truc Y
                ((XYDiagram)_chart.Diagram).AxisY.WholeRange.Auto = true;
                ((XYDiagram)_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(minRange - 5, maxRange + 5);
                ((XYDiagram)_chart.Diagram).AxisY.GridLines.Visible = false;
                ((XYDiagram)_chart.Diagram).AxisX.Label.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular);
                ((XYDiagram)_chart.Diagram).AxisX.Label.Visible = true;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.False;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Text = "Time";
                ((XYDiagram)_chart.Diagram).AxisX.Title.TextColor = Color.Orange;
                ((XYDiagram)_chart.Diagram).AxisX.Title.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                ((XYDiagram)_chart.Diagram).AxisY.Label.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular);
                ((XYDiagram)_chart.Diagram).AxisY.Label.Visible = true;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Text = Title+ " Temperature  (°C)";
                ((XYDiagram)_chart.Diagram).AxisY.Title.TextColor = Color.Yellow;
                ((XYDiagram)_chart.Diagram).AxisY.Title.Font = new System.Drawing.Font("Times New Roman", 11, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            }
            catch //(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                BindingDataGauges();

                DataTable dt = LOAD_HISTORY_DATA("Q", "");
                BindingDataChart("Kneader",chartKneader, "KNED", dt);
                BindingDataChart("Roll",chartRoll, "ROLL", dt);
                BindingDataChart("Extruder",chartEXTR, "EXTR", dt);
                BindingDataChart("Palletizing",chartPall, "PELL", dt);
                //  BindingData();
                //LoadData();

            }
        }
    }
}
