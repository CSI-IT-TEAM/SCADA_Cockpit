using DevExpress.XtraCharts;
using DevExpress.XtraGauges.Core.Model;
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
    public partial class FORM_SCADA_ENHANCEMENT : Form
    {
        public FORM_SCADA_ENHANCEMENT()
        {
            InitializeComponent();
            tmrLoad.Stop();
            tmrAnimationText.Stop();
        }
        #region Var
        DataTable dtCell1 = new DataTable();
        DataTable dtCell2 = new DataTable();
        DataTable dtCell3 = new DataTable();
        DataTable dtCell4 = new DataTable();
        DataTable dtCell6 = new DataTable();
        List<ChartModel> models = new List<ChartModel>();
        string[] YearValues = new string[8];
        Random r = new Random();
        int cCount = 0;
        int cCountPnCell1 = 0;
        private string[] _arrMonthShortName = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
        #endregion

        #region Database
        private DataTable GET_VALUE_ANALYSIS(string ARG_QTYPE, string ARG_YM, string ARG_REMARK)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            MyOraDB.ShowErr = true;

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SP_GET_ANALYSIS";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_YM";
            MyOraDB.Parameter_Name[2] = "ARG_REMARK";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = ARG_QTYPE;
            MyOraDB.Parameter_Values[1] = ARG_YM;
            MyOraDB.Parameter_Values[2] = ARG_REMARK;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        private DataTable LoadDataTable()
        {
            try
            {
                // Create a DataTable and add two Columns to it
                DataTable dt = new DataTable();
                dt.Columns.Add("MONTH", typeof(string));
                dt.Columns.Add("PROD_QTY", typeof(int));

                for (int i = 0; i < 12; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["MONTH"] = _arrMonthShortName[i];
                    dr["PROD_QTY"] = r.Next(1000, 5000); // or dr[1]=24;
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }
        #endregion
        private void InitModels()
        {
            models.Add(new ChartModel { Title = "Rework && Equipment malfunction", Code = "RW", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "SEASON_LABEL", ValueColumnName = "QTY", formCall = "10353", AxisYTitle = "Prs", axisXTitle = "Season", valuePatten = "{V:#,#}" });
            models.Add(new ChartModel { Title = "Absent Rate", Code = "ABSENT", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "QTY", formCall = "10365", AxisYTitle = "%", axisXTitle = "Month", valuePatten = "{V}" });
            models.Add(new ChartModel { Title = "Andon DownTime", Code = "DOWNTIME", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "QTY", formCall = "10366", AxisYTitle = "Prs", axisXTitle = "Month", valuePatten = "{V:#,#}" }); //10366
            models.Add(new ChartModel { Title = "PM", Code = "PM", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "QTY", formCall = "10346", AxisYTitle = "Prs", axisXTitle = "Month", valuePatten = "{V:#,#}" });
            models.Add(new ChartModel { Title = "WOF", Code = "WOF", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "PROCESS", ValueColumnName = "QTY", formCall = "10339", AxisYTitle = "", axisXTitle = "", valuePatten = "" });
            models.Add(new ChartModel { Title = "Production Quantity", Code = "PROD", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "POD", formCall = "10369", AxisYTitle = "%", axisXTitle = "Month", valuePatten = "{V}" });
            models.Add(new ChartModel { Title = "PPSM", Code = "PPSM", ChartType = "PPSM", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "QTY", formCall = "10348", AxisYTitle = "", axisXTitle = "", valuePatten = "" });
            models.Add(new ChartModel { Title = "Electric by pair", Code = "ELEC", ChartType = "LINE", NumberOfSeries = 1, AxisLabelColumnName = "YM_LABEL", ValueColumnName = "QTY", formCall = "10354", AxisYTitle = "", axisXTitle = "", valuePatten = "" });
        }
        private void initUCHeader()
        {
            try
            {
                int iDx = 0;
                for (int iRow = 0; iRow < tblMain.RowCount; iRow++)
                {
                    for (int iCol = 0; iCol < tblMain.ColumnCount; iCol++)
                    {
                        var splControl = tblMain.GetControlFromPosition(iCol, iRow);
                        if (splControl != null)
                        {
                            UC.UCTitle uCTitle = new UC.UCTitle();

                            uCTitle.OnButtonDetailClick += OnButtonDetailClick;
                            uCTitle.OnButtonYearClick += OnButtonYearClick;
                            ((SplitContainer)splControl).BackColor = Color.FromName("Gainsboro");
                            ((SplitContainer)splControl).Panel1.Controls.Add(uCTitle);
                            YearValues[iDx] = uCTitle.yearValue();
                            uCTitle.SetModels(models[iDx]);
                            //Task t = new Task(() => BindingData(models[iDx], uCTitle.yearValue()));
                            //t.Start();
                            iDx++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void OnButtonYearClick(ChartModel model, string YearValue)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                //Cập nhật lại YearValue khi có thay đổi từ UC
                for (int i = 0; i < models.Count; i++)
                {
                    if (model.Code.Equals(models[i].Code))
                    {
                        YearValues[i] = YearValue;
                    }
                }
                Task t = new Task(() => BindingData(model, YearValue));
                t.Start();
                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void OnButtonDetailClick(ChartModel model, string YearValue)
        {
            try
            {
                //  MessageBox.Show(model.formCall);

                ComVar.Var._IsBack = true;
                ComVar.Var._strValue1 = YearValue;
                ComVar.Var.callForm = model.formCall;
            }
            catch
            {
            }
        }

        private void ResetControls()
        {
            //Cell1
            lblCell1_RW.Text = "0";
            lblCell1_Occur.Text = "0";
        }
        private void BindingData()
        {
            try
            {
                splashScreenManager1.ShowWaitForm();
                for (int i = 0; i < models.Count; i++)
                {
                    BindingData(models[i], YearValues[i]);
                }
                splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                splashScreenManager1.CloseWaitForm();
            }

        }
        private int BindingData(ChartModel model, string YearValue)
        {
            try
            {

                DataTable dt = LoadDataTable();
                DataTable dtReal = GET_VALUE_ANALYSIS(model.Code, YearValue, null);
                ResetControls();
                switch (model.Code)
                {
                    case "RW": //1
                        dtCell1 = dtReal.Copy();
                        tmrAnimationText.Start();
                        //chartRework.DataSource = dt;
                        //chartRework.Series[0].ArgumentDataMember = "MONTH";
                        //chartRework.Series[0].ValueDataMembers.AddRange(new string[] {"PROD_QTY" });
                        //((DevExpress.XtraCharts.XYDiagram)chartRework.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        //if (dt.Rows.Count >= 5)
                        //{
                        //    ((XYDiagram)chartRework.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        //}
                        break;
                    case "ABSENT": //2
                        arcScaleBestAbsent.Value = 0;
                        arcScaleBestAlarm.Value = 0;
                        arcScaleWorstAbsent.Value = 0;
                        arcScaleWorstAlarm.Value = 0;
                        dtCell2 = dtReal.Copy();
                        tmrAnimationText.Start();
                        break;
                    case "DOWNTIME": //3
                        //chartDownTime1.DataSource = dtReal;
                        //chartDownTime1.Series[0].ArgumentDataMember = "LINE_NM";
                        //chartDownTime1.Series[0].ValueDataMembers.AddRange(new string[] { "ALARM_TIME" });

                        //chartDownTime1.Series[1].ArgumentDataMember = "LINE_NM";
                        //chartDownTime1.Series[1].ValueDataMembers.AddRange(new string[] { "ANDON_AVG_TIME" });
                        //((DevExpress.XtraCharts.XYDiagram)chartDownTime1.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        dtCell3 = dtReal.Copy();
                        lblCell3_AlarmTop1.Text = "0";
                        lblCell3_AlarmTop2.Text = "0";
                        lblCell3_AlarmTop3.Text = "0";
                        lblCell3_MA.Text = "0";
                        lblCell3_TL.Text = "0";
                        lblCell3_Management.Text = "0";
                        tmrAnimationText.Start();
                        //chartDownTime1.Series[0].ArgumentDataMember = "MONTH";
                        //chartDownTime1.Series[0].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                        //((DevExpress.XtraCharts.XYDiagram)chartDownTime1.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        //if (dt.Rows.Count >= 5)
                        //{
                        //    ((XYDiagram)chartDownTime1.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        //}
                        break;
                    case "PM": //4
                        dtCell4 = dtReal.Copy();
                        lblCell4_AlarmTop1.Text = "0";
                        lblCell4_AlarmTop2.Text = "0";
                        lblCell4_AlarmTop3.Text = "0";
                        lblCell4_AlarmTop4.Text = "0";
                        lblCell4_AlarmTop5.Text = "0";

                        lblCell4_PMTop1.Text = "0";
                        lblCell4_PMTop2.Text = "0";
                        lblCell4_PMTop3.Text = "0";
                        lblCell4_PMTop4.Text = "0";
                        lblCell4_PMTop5.Text = "0";

                        tmrAnimationText.Start();
                        //chartPM.DataSource = dt;
                        //chartPM.Series[0].ArgumentDataMember = "MONTH";
                        //chartPM.Series[0].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                        //((DevExpress.XtraCharts.XYDiagram)chartPM.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        //if (dt.Rows.Count >= 5)
                        //{
                        //    ((XYDiagram)chartPM.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        //}
                        break;
                    case "WOF": //5
                        chartWOF.DataSource = dt;
                        chartWOF.Series[0].ArgumentDataMember = "MONTH";
                        chartWOF.Series[0].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                        ((DevExpress.XtraCharts.XYDiagram)chartWOF.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        if (dt.Rows.Count >= 5)
                        {
                            ((XYDiagram)chartWOF.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        }
                        break;
                    case "PROD": //6
                        dtCell6 = dtReal.Copy();
                        //chartProd.DataSource = dt;
                        //chartProd.Series[0].ArgumentDataMember = "MONTH";
                        //chartProd.Series[0].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                        //((DevExpress.XtraCharts.XYDiagram)chartProd.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        //if (dt.Rows.Count >= 5)
                        //{
                        //    ((XYDiagram)chartProd.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        //}
                        tmrAnimationText.Start();
                        break;
                    case "PPSM": //7
                        chartPPSM.DataSource = dt;
                        chartPPSM.Series[0].ArgumentDataMember = "MONTH";
                        chartPPSM.Series[0].ValueDataMembers.AddRange(new string[] { "PROD_QTY" });
                        ((DevExpress.XtraCharts.XYDiagram)chartPPSM.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        if (dt.Rows.Count >= 5)
                        {
                            ((XYDiagram)chartPPSM.Diagram).AxisX.VisualRange.SetMinMaxValues(dt.Rows[0]["MONTH"], dt.Rows[5]["MONTH"]);
                        }
                        break;
                    case "ELEC": //8
                        chartElec.DataSource = dtReal;
                        chartElec.Series[0].ArgumentDataMember = "YMD";
                        chartElec.Series[0].ValueDataMembers.AddRange(new string[] { "KWH" });
                        chartElec.Series[1].ArgumentDataMember = "YMD";
                        chartElec.Series[1].ValueDataMembers.AddRange(new string[] { "MC_OCR" });
                        ((DevExpress.XtraCharts.XYDiagram)chartElec.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        break;
                }
                return 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;

            }
        }

        private void BindingLabelRData(RoundLabel lbl, int min, int max)
        {
            lbl.Text = string.Format("{0:n0}", r.Next(min, max));
        }


        private void FORM_SCADA_ENHANCEMENT_Load(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
                InitModels();
                initUCHeader();

                //Best Absent
                arcScaleBestAbsent.EnableAnimation = true;
                arcScaleBestAbsent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleBestAbsent.EasingFunction = new BackEase();

                //Best Alarm
                arcScaleBestAlarm.EnableAnimation = true;
                arcScaleBestAlarm.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleBestAlarm.EasingFunction = new BackEase();

                arcScaleWorstAbsent.EnableAnimation = true;
                arcScaleWorstAbsent.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleWorstAbsent.EasingFunction = new BackEase();

                arcScaleWorstAlarm.EnableAnimation = true;
                arcScaleWorstAlarm.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                arcScaleWorstAlarm.EasingFunction = new BackEase();
                //  BindingData();
            }
            catch
            {


            }
        }

        private void splitContainer4_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void tmrLoad_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                BindingData();

            }
        }

        private void FORM_SCADA_ENHANCEMENT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 60;
                tmrLoad.Start();
            }
            else
                tmrLoad.Stop();
        }

        private void tmrAnimationText_Tick(object sender, EventArgs e)
        {
            cCountPnCell1++;
            BindingLabelRData(lblCell1_RW, 1, 101);
            BindingLabelRData(lblCell1_Occur, 1, 101);
            BindingLabelRData(lblCell2_AbsentBest, 1, 101);
            BindingLabelRData(lblCell2_AbsentWorst, 1, 101);

            BindingLabelRData(lblCell2_AlarmBest, 1, 101);
            BindingLabelRData(lblCell2_AlarmWorst, 1, 101);

            BindingLabelRData(lblCell3_AlarmTop1, 1, 1001);
            BindingLabelRData(lblCell3_AlarmTop2, 1, 1001);
            BindingLabelRData(lblCell3_AlarmTop3, 1, 1001);
            BindingLabelRData(lblCell3_MA, 1, 1001);
            BindingLabelRData(lblCell3_TL, 1, 1001);
            BindingLabelRData(lblCell3_Management, 1, 1001);

            BindingLabelRData(lblCell4_AlarmTop1, 1, 101);
            BindingLabelRData(lblCell4_AlarmTop2, 1, 101);
            BindingLabelRData(lblCell4_AlarmTop3, 1, 101);
            BindingLabelRData(lblCell4_AlarmTop4, 1, 101);
            BindingLabelRData(lblCell4_AlarmTop5, 1, 101);

            BindingLabelRData(lblCell4_PMTop1, 1, 101);
            BindingLabelRData(lblCell4_PMTop2, 1, 101);
            BindingLabelRData(lblCell4_PMTop3, 1, 101);
            BindingLabelRData(lblCell4_PMTop4, 1, 101);
            BindingLabelRData(lblCell4_PMTop5, 1, 101);

            BindingLabelRData(lblCell6_ProdBestTop1, 1, 101); BindingLabelRData(lblCell6_ProdBestTop2, 1, 101); BindingLabelRData(lblCell6_ProdBestTop3, 1, 101);
            BindingLabelRData(lblCell6_ProdWorstTop1, 1, 101); BindingLabelRData(lblCell6_ProdWorstTop2, 1, 101); BindingLabelRData(lblCell6_ProdWorstTop3, 1, 101);
            BindingLabelRData(lblCell6_AlarmBestTop1, 1, 101); BindingLabelRData(lblCell6_AlarmBestTop2, 1, 101); BindingLabelRData(lblCell6_AlarmBestTop3, 1, 101);
            BindingLabelRData(lblCell6_AlarmWorstTop1, 1, 101); BindingLabelRData(lblCell6_AlarmWorstTop2, 1, 101); BindingLabelRData(lblCell6_AlarmWorstTop3, 1, 101);

            if (cCountPnCell1 >= 15)
            {
                cCountPnCell1 = 0;
                arcScaleBestAbsent.Value = 0;
                arcScaleBestAlarm.Value = 0;
                arcScaleWorstAbsent.Value = 0;
                arcScaleWorstAlarm.Value = 0;

                lblCell3_AlarmTop1.Text = "0";
                lblCell3_AlarmTop2.Text = "0";
                lblCell3_AlarmTop3.Text = "0";
                lblCell3_MA.Text = "0";
                lblCell3_TL.Text = "0";
                lblCell3_Management.Text = "0";

                lblCell4_AlarmTop1.Text = "0";
                lblCell4_AlarmTop2.Text = "0";
                lblCell4_AlarmTop3.Text = "0";
                lblCell4_AlarmTop4.Text = "0";
                lblCell4_AlarmTop5.Text = "0";

                lblCell4_PMTop1.Text = "0";
                lblCell4_PMTop2.Text = "0";
                lblCell4_PMTop3.Text = "0";
                lblCell4_PMTop4.Text = "0";
                lblCell4_PMTop5.Text = "0";

                lblCell6_ProdBestTop1.Text = "0%"; lblCell6_ProdBestTop2.Text = "0%"; lblCell6_ProdBestTop3.Text = "0%";
                lblCell6_ProdWorstTop1.Text = "0%"; lblCell6_ProdWorstTop2.Text = "0%"; lblCell6_ProdWorstTop3.Text = "0%";
                lblCell6_AlarmBestTop1.Text = "0%"; lblCell6_AlarmBestTop2.Text = "0%"; lblCell6_AlarmBestTop3.Text = "0%";
                lblCell6_AlarmWorstTop1.Text = "0%"; lblCell6_AlarmWorstTop2.Text = "0%"; lblCell6_AlarmWorstTop3.Text = "0%";

                tmrAnimationText.Stop();
                try
                {
                    lblCell1_RW.Text = string.Format("{0:n1}", dtCell1.Rows[0]["REW_RATE"]);
                    lblCell1_Occur.Text = string.Format("{0:n2}", dtCell1.Rows[0]["OCR_RATE"]);
                    //Binding Data for Absent Here!!!

                    if (dtCell2.Select("ABSENT_FLAG='Best'").Count() > 0)
                    {
                        //Best Absent
                        arcScaleBestAbsent.MinValue = Convert.ToInt32(dtCell2.Select("ABSENT_FLAG='Best'").CopyToDataTable().Rows[0]["ABSENT_MIN"]);
                        arcScaleBestAbsent.MaxValue = Convert.ToInt32(dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["ABSENT_MAX"]);
                        arcScaleBestAbsent.Value = float.Parse(string.Format("{0:n1}", dtCell2.Select("ABSENT_FLAG='Best'").CopyToDataTable().Rows[0]["ABSENT_RATIO"].ToString()));
                        lblCell2_AbsentBest.Text = string.Concat(string.Format("{0:n1}", dtCell2.Select("ABSENT_FLAG='Best'").CopyToDataTable().Rows[0]["ABSENT_RATIO"].ToString()), "%");
                        lblCell2_AbsentBestPlant.Text = dtCell2.Select("ABSENT_FLAG='Best'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        lblBestAbsent.Text = string.Concat(string.Format("{0:n1}", dtCell2.Select("ABSENT_FLAG='Best'").CopyToDataTable().Rows[0]["ABSENT_RATIO"].ToString()), "%");

                        //Best Alarm
                        arcScaleBestAlarm.MinValue = Convert.ToInt32(dtCell2.Select("ALARM_FLAG='Best'").CopyToDataTable().Rows[0]["ALARM_MIN"]);
                        arcScaleBestAlarm.MaxValue = Convert.ToInt32(dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["ALARM_MAX"]);
                        arcScaleBestAlarm.Value = float.Parse(string.Format("{0:n1}", dtCell2.Select("ALARM_FLAG='Best'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString()));
                        lblCell2_AlarmBest.Text =  string.Concat(string.Format("{0:n1}", dtCell2.Select("ALARM_FLAG='Best'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString()), "%");
                        lblCell2_AlarmBestPlant.Text = dtCell2.Select("ALARM_FLAG='Best'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        lblBestAlarm.Text = string.Concat(string.Format("{0:n1}", dtCell2.Select("ALARM_FLAG='Best'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString()), "%");

                    }

                    if (dtCell2.Select("ABSENT_FLAG='Worst'").Count() > 0)
                    {
                        //Best Absent
                        arcScaleWorstAbsent.MinValue = Convert.ToInt32(dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["ABSENT_MIN"]);
                        arcScaleWorstAbsent.MaxValue = Convert.ToInt32(dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["ABSENT_MAX"]);

                        arcScaleWorstAbsent.Value = float.Parse(string.Format("{0:n1}", dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["ABSENT_RATIO"].ToString()));

                        lblCell2_AbsentWorst.Text = lblWorstAbsent.Text = string.Concat(string.Format("{0:n1}", dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["ABSENT_RATIO"].ToString()), "%");
                        lblCell2_AbsentWorstPlant.Text = dtCell2.Select("ABSENT_FLAG='Worst'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        //Worst Alarm
                        arcScaleWorstAlarm.MinValue = Convert.ToInt32(dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["ALARM_MIN"]);
                        arcScaleWorstAlarm.MaxValue = Convert.ToInt32(dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["ALARM_MAX"]);
                        arcScaleWorstAlarm.Value = float.Parse(string.Format("{0:n1}", dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString()));
                        lblCell2_AlarmWorst.Text = lblWorstAlarm.Text =  string.Concat(string.Format("{0:n1}", dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString()), "%");
                        lblCell2_AlarmWorstPlant.Text = dtCell2.Select("ALARM_FLAG='Worst'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                    }

                    if (dtCell3.Rows.Count > 0 && dtCell3 != null)
                    {
                        lblCell3_MA.Text = string.Format("{0:n0}", dtCell3.Select("PROCESS_CD = 'LB'").CopyToDataTable().Rows[0]["QTY"]);
                        lblCell3_Management.Text = string.Format("{0:n0}", dtCell3.Select("PROCESS_CD = 'LA'").CopyToDataTable().Rows[0]["QTY"]);
                        lblCell3_TL.Text = string.Format("{0:n0}", dtCell3.Select("PROCESS_CD = 'LC'").CopyToDataTable().Rows[0]["QTY"]);
                        if (dtCell3.Rows[3] != null)
                        {
                            lblPlant1.Text = dtCell3.Rows[3]["PROCESS_CD"].ToString();
                            lblCell3_AlarmTop1.Text = string.Format("{0:n0}", dtCell3.Rows[3]["QTY"]);
                        }
                        if (dtCell3.Rows[4] != null)
                        {
                            lblPlant2.Text = dtCell3.Rows[4]["PROCESS_CD"].ToString();
                            lblCell3_AlarmTop2.Text = string.Format("{0:n0}", dtCell3.Rows[4]["QTY"]);
                        }
                        if (dtCell3.Rows[5] != null)
                        {
                            lblPlant3.Text = dtCell3.Rows[5]["PROCESS_CD"].ToString();
                            lblCell3_AlarmTop3.Text = string.Format("{0:n0}", dtCell3.Rows[5]["QTY"]);
                        }
                    }

                    if (dtCell4.Rows.Count > 0 && dtCell4 != null)
                    {
                        if (dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '1'").Count() > 0)
                        {
                            lblCell4_AlarmTop1.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '1'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantAlarmTop1.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '1'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '2'").Count() > 0)
                        {
                            lblCell4_AlarmTop2.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '2'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantAlarmTop2.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '2'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '3'").Count() > 0)
                        {
                            lblCell4_AlarmTop3.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '3'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantAlarmTop3.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '3'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '4'").Count() > 0)
                        {
                            lblCell4_AlarmTop4.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '4'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantAlarmTop4.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '4'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '5'").Count() > 0)
                        {
                            lblCell4_AlarmTop5.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '5'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantAlarmTop5.Text = dtCell4.Select("ITEMS = 'ALARM' AND SEQ = '5'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }

                        if (dtCell4.Select("ITEMS = 'PM' AND SEQ = '1'").Count() > 0)
                        {
                            lblCell4_PMTop1.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '1'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantPMTop1.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '1'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'PM' AND SEQ = '2'").Count() > 0)
                        {
                            lblCell4_PMTop2.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '2'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantPMTop2.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '2'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'PM' AND SEQ = '3'").Count() > 0)
                        {
                            lblCell4_PMTop3.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '3'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantPMTop3.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '3'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'PM' AND SEQ = '4'").Count() > 0)
                        {
                            lblCell4_PMTop4.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '4'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantPMTop4.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '4'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                        if (dtCell4.Select("ITEMS = 'PM' AND SEQ = '5'").Count() > 0)
                        {
                            lblCell4_PMTop5.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '5'").CopyToDataTable().Rows[0]["RATE"].ToString();
                            lblCell4_PlantPMTop5.Text = dtCell4.Select("ITEMS = 'PM' AND SEQ = '5'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                        }
                    }

                    //Cell 6
                    if (dtCell6.Rows.Count > 0 && dtCell6 != null)
                    {

                        if (dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '1'").Count() > 0)
                        {
                            lblCell6_ProdBestPlant1.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '1'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdBestTop1.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '1'").CopyToDataTable().Rows[0]["RATIO"].ToString();
                            lblCell6_AlarmBestTop1.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '1'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }
                        if (dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '2'").Count() > 0)
                        {
                            lblCell6_ProdBestPlant2.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '2'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdBestTop2.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '2'").CopyToDataTable().Rows[0]["RATIO"].ToString();
                            lblCell6_AlarmBestTop2.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '2'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }
                        if (dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '3'").Count() > 0)
                        {
                            lblCell6_ProdBestPlant3.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '3'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdBestTop3.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '3'").CopyToDataTable().Rows[0]["RATIO"].ToString();
                            lblCell6_AlarmBestTop3.Text = dtCell6.Select("FLAG = 'Best' AND SEQ_1 = '3'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }

                        if (dtCell6.Select("FLAG = 'Worst' AND SEQ = '1'").Count() > 0)
                        {
                            lblCell6_ProdWorstPlant1.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '1'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdWorstTop1.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '1'").CopyToDataTable().Rows[0]["RATIO"].ToString();

                            lblCell6_AlarmWorstTop1.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '1'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }

                        if (dtCell6.Select("FLAG = 'Worst' AND SEQ = '2'").Count() > 0)
                        {
                            lblCell6_ProdWorstPlant2.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '2'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdWorstTop2.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '2'").CopyToDataTable().Rows[0]["RATIO"].ToString();
                            lblCell6_AlarmWorstTop2.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '2'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }
                        if (dtCell6.Select("FLAG = 'Worst' AND SEQ = '3'").Count() > 0)
                        {
                            lblCell6_ProdWorstPlant3.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '3'").CopyToDataTable().Rows[0]["LINE_NM"].ToString();
                            lblCell6_ProdWorstTop3.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '3'").CopyToDataTable().Rows[0]["RATIO"].ToString();
                            lblCell6_AlarmWorstTop3.Text = dtCell6.Select("FLAG = 'Worst' AND SEQ = '3'").CopyToDataTable().Rows[0]["ALARM_RATIO"].ToString();
                        }





                    }
                }
                catch (Exception ex)
                {
                    // MessageBox.Show(ex.Message);
                }

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblCell6_ProdBestPlant1_Click(object sender, EventArgs e)
        {

        }
    }
}
