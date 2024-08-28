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
    public partial class SMT_SCADA_B2_IP_UV_TEMPER : Form
    {
        public SMT_SCADA_B2_IP_UV_TEMPER()
        {
            InitializeComponent();
        }

        #region Variable
        const int ReloadTime = 60;
        int cCount = 0;
        DataTable _dt, _dtUVZone1, _dtUVZone2, _dtUVZone3, _dtUVZone4, _dtUVZone5, _dtUVZone6;

        private void SMT_SCADA_B2_IP_UV_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
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
                BindingDataChart(dt, chartMC1, "001");
                BindingDataChart(dt, chartMC2, "002");
                BindingDataChart(dt, chartMC3, "003");
                //BindingDataChart("Roll", chartRoll, "ROLL", dt);
                //BindingDataChart("Extruder", chartEXTR, "EXTR", dt);
                //BindingDataChart("Palletizing", chartPall, "PELL", dt);
                //  BindingData();
                //LoadData();

            }
        }

        private void BindingDataChart(DataTable dt, DevExpress.XtraCharts.ChartControl _chart, string vMC_ID)
        {
            try
            {
                _chart.DataSource = null;
                if (dt.Rows.Count < 2) return;
                if (dt.Select("MC_ID = '" + vMC_ID + "'").Count() > 0)
                {
                    ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.Clear();
                    DataTable dtChart = dt.Select("MC_ID = '" + vMC_ID + "'").CopyToDataTable();
                    _chart.DataSource = dtChart;

                    _chart.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[0].ArgumentDataMember = "HMS";
                    _chart.Series[0].ValueDataMembers.AddRange(new string[] { "Z001" });
                    _chart.Series[1].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[1].ArgumentDataMember = "HMS";
                    _chart.Series[1].ValueDataMembers.AddRange(new string[] { "Z002" });
                    _chart.Series[2].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[2].ArgumentDataMember = "HMS";
                    _chart.Series[2].ValueDataMembers.AddRange(new string[] { "Z003" });
                    _chart.Series[3].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[3].ArgumentDataMember = "HMS";
                    _chart.Series[3].ValueDataMembers.AddRange(new string[] { "Z004" });
                    _chart.Series[4].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[4].ArgumentDataMember = "HMS";
                    _chart.Series[4].ValueDataMembers.AddRange(new string[] { "Z005" });
                    _chart.Series[5].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    _chart.Series[5].ArgumentDataMember = "HMS";
                    _chart.Series[5].ValueDataMembers.AddRange(new string[] { "Z006" });


                    DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                    DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine(); ////Constant line
                    
                    constantLine1.AxisValueSerializable = dtChart.Rows[0]["MINVAL"].ToString();
                    constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    constantLine1.Name = "Min";
                    constantLine2.AxisValueSerializable = dtChart.Rows[0]["MAXVAL"].ToString();
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
                    ((XYDiagram)_chart.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });
                    ((XYDiagram)_chart.Diagram).AxisY.WholeRange.Auto = true;
                    ((XYDiagram)_chart.Diagram).AxisY.WholeRange.SetMinMaxValues(int.Parse( dtChart.Rows[0]["MINVAL"].ToString()) - 5, int.Parse(dtChart.Rows[0]["MAXVAL"].ToString()) + 5);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
           // ComVar.Var.callForm = "back";
            tmrDate.Stop();
            ComVar.Var.callForm = "back";
        }

        double dUVZone1MC1 = 0, dUVZone1MC1Min = 0, dUVZone1MC1Max = 0,
                dUVZone1MC2 = 0, dUVZone1MC2Min = 0, dUVZone1MC2Max = 0,
              dUVZone1MC3 = 0, dUVZone1MC3Min = 0, dUVZone1MC3Max = 0,
            dUVZone2MC1 = 0, dUVZone2MC1Min = 0, dUVZone2MC1Max = 0,
            dUVZone2MC2 = 0, dUVZone2MC2Min = 0, dUVZone2MC2Max = 0,
            dUVZone2MC3 = 0, dUVZone2MC3Min = 0, dUVZone2MC3Max = 0,
              dUVZone3MC1 = 0, dUVZone3MC1Min = 0, dUVZone3MC1Max = 0,
            dUVZone3MC2 = 0, dUVZone3MC2Min = 0, dUVZone3MC2Max = 0,
            dUVZone3MC3 = 0, dUVZone3MC3Min = 0, dUVZone3MC3Max = 0,
            dUVZone4MC1 = 0, dUVZone4MC1Min = 0, dUVZone4MC1Max = 0,
            dUVZone4MC2 = 0, dUVZone4MC2Min = 0, dUVZone4MC2Max = 0,
            dUVZone4MC3 = 0, dUVZone4MC3Min = 0, dUVZone4MC3Max = 0,
             dUVZone5MC1 = 0, dUVZone5MC1Min = 0, dUVZone5MC1Max = 0,
            dUVZone5MC2 = 0, dUVZone5MC2Min = 0, dUVZone5MC2Max = 0,
            dUVZone5MC3 = 0, dUVZone5MC3Min = 0, dUVZone5MC3Max = 0,
            dUVZone6MC1 = 0, dUVZone6MC1Min = 0, dUVZone6MC1Max = 0,
            dUVZone6MC2 = 0, dUVZone6MC2Min = 0, dUVZone6MC2Max = 0,
            dUVZone6MC3 = 0, dUVZone6MC3Min = 0, dUVZone6MC3Max = 0;
        #endregion

        #region DB
        private DataTable LOAD_HISTORY_DATA(string ARG_QTYPE, string ARG_DATE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_B2IP_UV_TEMP_HISTORY";
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
        private DataTable LOAD_TRACKING_DATA(string ARG_QTYPE)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_B2IP_UV_TEMP_TRACKING";
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
        #endregion


        #region BindingData
        private Color lblColor(double Val, double MinVal, double MaxVal)
        {
            if (Val == 0 || MinVal == 0 || MaxVal == 0) return Color.Silver;
            if (Val < MinVal || Val > MaxVal)
                return Color.Red;
            else
                return Color.LimeGreen;
        }
        private void BindingDataGauges()
        {
            DataTable dt;
            dUVZone1MC1 = 0; dUVZone1MC2 = 0; dUVZone1MC3 = 0; dUVZone2MC1 = 0; dUVZone2MC2 = 0; dUVZone2MC3 = 0;
            dUVZone3MC1 = 0; dUVZone3MC2 = 0; dUVZone3MC3 = 0; dUVZone4MC1 = 0; dUVZone4MC2 = 0; dUVZone4MC3 = 0;
            dUVZone5MC1 = 0; dUVZone5MC2 = 0; dUVZone5MC3 = 0; dUVZone6MC1 = 0; dUVZone6MC2 = 0; dUVZone6MC3 = 0;

            if (_dt == null || _dt.Rows.Count == 0)
                dt = LOAD_TRACKING_DATA("Q");
            else
                dt = _dt.Copy();
            try
            {

                if (dt != null && dt.Rows.Count > 0)
                {
                    label4.Text = "Min: "+ Convert.ToDouble(dt.Rows[0]["MINVAL"].ToString()) + "°C";
                    label5.Text = "Max: "+ Convert.ToDouble(dt.Rows[0]["MAXVAL"].ToString()) + "°C";

                    for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                    {

                        //Z1
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "001" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone1MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone1MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone1MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "001" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone1MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone1MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone1MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "001" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone1MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone1MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone1MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                        //Z2
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "002" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone2MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone2MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone2MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "002" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone2MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone2MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone2MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "002" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone2MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone2MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone2MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                        //Z3
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "003" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone3MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone3MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone3MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "003" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone3MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone3MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone3MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "003" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone3MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone3MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone3MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                        //Z4
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "004" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone4MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone4MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone4MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "004" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone4MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone4MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone4MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "004" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone4MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone4MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone4MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                        //Z5
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "005" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone5MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone5MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone5MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "005" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone5MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone5MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone5MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "005" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone5MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone5MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone5MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());

                        }

                        //Z6
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "006" && dt.Rows[iRow]["MC_ID"].ToString() == "001") //Kneader Machine 1
                        {
                            dUVZone6MC1 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone6MC1Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone6MC1Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());


                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "006" && dt.Rows[iRow]["MC_ID"].ToString() == "002") //Kneader Machine 1
                        {
                            dUVZone6MC2 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone6MC2Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone6MC2Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }
                        if (dt.Rows[iRow]["LINE_CD"].ToString() == "006" && dt.Rows[iRow]["MC_ID"].ToString() == "003") //Kneader Machine 1
                        {
                            dUVZone6MC3 = Convert.ToDouble(dt.Rows[iRow]["VALUE"].ToString());
                            dUVZone6MC3Min = Convert.ToDouble(dt.Rows[iRow]["MINVAL"].ToString());
                            dUVZone6MC3Max = Convert.ToDouble(dt.Rows[iRow]["MAXVAL"].ToString());
                        }

                    }
                }

                //Kneader================================

                BindingGauges(lnZone1MC1, dUVZone1MC1, dUVZone1MC1Min - 10, dUVZone1MC1Max + 10, dUVZone1MC1Min, dUVZone1MC1Max);
                lblZone1MC1.Text = dUVZone1MC1.ToString() + " °C";
                lblZone1MC1._BackColor = lblColor(dUVZone1MC1, dUVZone1MC1Min, dUVZone1MC1Max);

                BindingGauges(lnZone1MC2, dUVZone1MC2, dUVZone1MC2Min - 10, dUVZone1MC2Max + 10, dUVZone1MC2Min, dUVZone1MC2Max);
                lblZone1MC2.Text = dUVZone1MC2.ToString() + " °C";
                lblZone1MC2._BackColor = lblColor(dUVZone1MC2, dUVZone1MC2Min, dUVZone1MC2Max);

                BindingGauges(lnZone1MC3, dUVZone1MC3, dUVZone1MC3Min - 10, dUVZone1MC3Max + 10, dUVZone1MC3Min, dUVZone1MC3Max);
                lblZone1MC3.Text = dUVZone1MC3.ToString() + " °C";
                lblZone1MC3._BackColor = lblColor(dUVZone1MC3, dUVZone1MC3Min, dUVZone1MC3Max);
                //=================================================
                BindingGauges(lnZone2MC1, dUVZone2MC1, dUVZone2MC1Min - 10, dUVZone2MC1Max + 10, dUVZone2MC1Min, dUVZone2MC1Max);
                lblZone2MC1.Text = dUVZone2MC1.ToString() + " °C";
                lblZone2MC1._BackColor = lblColor(dUVZone2MC1, dUVZone2MC1Min, dUVZone2MC1Max);

                BindingGauges(lnZone2MC2, dUVZone2MC2, dUVZone2MC2Min - 10, dUVZone2MC2Max + 10, dUVZone2MC2Min, dUVZone2MC2Max);
                lblZone2MC2.Text = dUVZone2MC2.ToString() + " °C";
                lblZone2MC2._BackColor = lblColor(dUVZone2MC2, dUVZone2MC2Min, dUVZone2MC2Max);

                BindingGauges(lnZone2MC3, dUVZone2MC3, dUVZone2MC3Min - 10, dUVZone2MC3Max + 10, dUVZone2MC3Min, dUVZone2MC3Max);
                lblZone2MC3.Text = dUVZone2MC3.ToString() + " °C";
                lblZone2MC3._BackColor = lblColor(dUVZone2MC3, dUVZone2MC3Min, dUVZone2MC3Max);
                //=================================================
                BindingGauges(lnZone3MC1, dUVZone3MC1, dUVZone3MC1Min - 10, dUVZone3MC1Max + 10, dUVZone3MC1Min, dUVZone3MC1Max);
                lblZone3MC1.Text = dUVZone3MC1.ToString() + " °C";
                lblZone3MC1._BackColor = lblColor(dUVZone3MC1, dUVZone3MC1Min, dUVZone3MC1Max);
                BindingGauges(lnZone3MC2, dUVZone3MC2, dUVZone3MC2Min - 10, dUVZone3MC2Max + 10, dUVZone3MC2Min, dUVZone3MC2Max);
                lblZone3MC2.Text = dUVZone3MC2.ToString() + " °C";
                lblZone3MC2._BackColor = lblColor(dUVZone3MC2, dUVZone3MC2Min, dUVZone3MC2Max);
                BindingGauges(lnZone3MC3, dUVZone3MC3, dUVZone3MC3Min - 10, dUVZone3MC3Max + 10, dUVZone3MC3Min, dUVZone3MC3Max);
                lblZone3MC3.Text = dUVZone3MC3.ToString() + " °C";
                lblZone3MC3._BackColor = lblColor(dUVZone3MC3, dUVZone3MC3Min, dUVZone3MC3Max);
                //=================================================
                BindingGauges(lnZone4MC1, dUVZone4MC1, dUVZone4MC1Min - 10, dUVZone4MC1Max + 10, dUVZone4MC1Min, dUVZone4MC1Max);
                lblZone4MC1.Text = dUVZone4MC1.ToString() + " °C";
                lblZone4MC1._BackColor = lblColor(dUVZone4MC1, dUVZone4MC1Min, dUVZone4MC1Max);
                BindingGauges(lnZone4MC2, dUVZone4MC2, dUVZone4MC2Min - 10, dUVZone4MC2Max + 10, dUVZone4MC2Min, dUVZone4MC2Max);
                lblZone4MC2.Text = dUVZone4MC2.ToString() + " °C";
                lblZone4MC2._BackColor = lblColor(dUVZone4MC2, dUVZone4MC2Min, dUVZone4MC2Max);
                BindingGauges(lnZone4MC3, dUVZone4MC3, dUVZone4MC3Min - 10, dUVZone4MC3Max + 10, dUVZone4MC3Min, dUVZone4MC3Max);
                lblZone4MC3.Text = dUVZone4MC3.ToString() + " °C";
                lblZone4MC3._BackColor = lblColor(dUVZone4MC3, dUVZone4MC3Min, dUVZone4MC3Max);
                //=================================================
                BindingGauges(lnZone5MC1, dUVZone5MC1, dUVZone5MC1Min - 10, dUVZone5MC1Max + 10, dUVZone5MC1Min, dUVZone5MC1Max);
                lblZone5MC1.Text = dUVZone5MC1.ToString() + " °C";
                lblZone5MC1._BackColor = lblColor(dUVZone5MC1, dUVZone5MC1Min, dUVZone5MC1Max);
                BindingGauges(lnZone5MC2, dUVZone5MC2, dUVZone5MC2Min - 10, dUVZone5MC2Max + 10, dUVZone5MC2Min, dUVZone5MC2Max);
                lblZone5MC2.Text = dUVZone5MC2.ToString() + " °C";
                lblZone5MC2._BackColor = lblColor(dUVZone5MC2, dUVZone5MC2Min, dUVZone5MC2Max);
                BindingGauges(lnZone5MC3, dUVZone5MC3, dUVZone5MC3Min - 10, dUVZone5MC3Max + 10, dUVZone5MC3Min, dUVZone5MC3Max);
                lblZone5MC3.Text = dUVZone5MC3.ToString() + " °C";
                lblZone5MC3._BackColor = lblColor(dUVZone5MC3, dUVZone5MC3Min, dUVZone5MC3Max);
                //=================================================
                BindingGauges(lnZone6MC1, dUVZone6MC1, dUVZone6MC1Min - 10, dUVZone6MC1Max + 10, dUVZone6MC1Min, dUVZone6MC1Max);
                lblZone6MC1.Text = dUVZone6MC1.ToString() + " °C";
                lblZone6MC1._BackColor = lblColor(dUVZone6MC1, dUVZone6MC1Min, dUVZone6MC1Max);
                BindingGauges(lnZone6MC2, dUVZone6MC2, dUVZone6MC2Min - 10, dUVZone6MC2Max + 10, dUVZone6MC2Min, dUVZone6MC2Max);
                lblZone6MC2.Text = dUVZone6MC2.ToString() + " °C";
                lblZone6MC2._BackColor = lblColor(dUVZone6MC2, dUVZone6MC2Min, dUVZone6MC2Max);
                BindingGauges(lnZone6MC3, dUVZone6MC3, dUVZone6MC3Min - 10, dUVZone6MC3Max + 10, dUVZone6MC3Min, dUVZone6MC3Max);
                lblZone6MC3.Text = dUVZone6MC3.ToString() + " °C";
                lblZone6MC3._BackColor = lblColor(dUVZone6MC3, dUVZone6MC3Min, dUVZone6MC3Max);

                // btnTest_Click(null, null);
            }
            catch// (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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

        #endregion
    }
}
