using DevExpress.XtraCharts;
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
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_B1CTM_TEMPER : Form
    {
        public SMT_SCADA_B1CTM_TEMPER()
        {
            InitializeComponent();
            tmrTime.Stop();
        }

        #region Variable
        int NumberOfCTMMachine = 0, cCount = 0;
        DataTable dtHeat = new DataTable();
        DataTable dtCool = new DataTable();
        List<UC.UC_B1CTM> lstUC = new List<UC.UC_B1CTM>();
        #endregion

        #region DB
        private DataTable GET_MACHINE_MASTER(string argQtype)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.MASTER_CTM_MACHINE_SELECT";
                //ARGMODE
                MyOraDB.ReDim_Parameter(2);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "OUT_CURSOR";
                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.Cursor;
                MyOraDB.Parameter_Values[0] = argQtype;
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
        private DataTable GET_MACHINE_TEMPER(string argQtype,string LineNo,string argDate)
        {
            try
            {
                COM.OraDB MyOraDB = new COM.OraDB();
                System.Data.DataSet ds_ret;

                string process_name = "MES.PKG_SMT_SCADA_B_COCKPIT.CTM_MACHINE_TEMPER_SELECT";
                //ARGMODE
                MyOraDB.ReDim_Parameter(4);
                MyOraDB.Process_Name = process_name;
                MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
                MyOraDB.Parameter_Name[1] = "ARG_LINE_NO";
                MyOraDB.Parameter_Name[2] = "ARG_DATE";
                MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[1] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[2] = (char)OracleType.VarChar;
                MyOraDB.Parameter_Type[3] = (char)OracleType.Cursor;

                MyOraDB.Parameter_Values[0] = argQtype;
                MyOraDB.Parameter_Values[1] = LineNo;
                MyOraDB.Parameter_Values[2] = argDate;
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
        #endregion

        private void cmdBack_Click(object sender, EventArgs e)
        {
            //ComVar.Var.callForm = "back";
            //tmrTime.Stop();
            ComVar.Var.callForm = "back";
        }

        private void InitLayout()
        {
            dtHeat = GET_MACHINE_TEMPER("HEAT", "", "");
            dtCool = GET_MACHINE_TEMPER("COOL", "", "");
            //get number of CTM Machine
            DataTable dtMachineMaster = GET_MACHINE_MASTER("Q");
            if (dtMachineMaster != null && dtMachineMaster.Rows.Count > 0)
            {
                NumberOfCTMMachine = dtMachineMaster.Rows.Count;

                tblMain.Visible = false;
                int iDx = 0;
                for (int i = 0; i < tblMain.RowCount; i++)
                {
                    for (int j = 0; j < tblMain.ColumnCount; j++)
                    {
                        if (iDx < NumberOfCTMMachine)
                        {
                            UC.UC_B1CTM UcBtCtm = new UC.UC_B1CTM();
                            UcBtCtm.Tag = dtMachineMaster.Rows[iDx]["LINE_NO"].ToString();
                            UcBtCtm.BindingHeaderData(dtMachineMaster.Rows[iDx]["LINE_NO"].ToString().TrimStart('0'));
                            UcBtCtm.OnUcClick += UCOnClick;
                            tblMain.Controls.Add(UcBtCtm, j, i);
                            UcBtCtm.Dock = DockStyle.Fill;
                            lstUC.Add(UcBtCtm);

                            if (iDx == 0) {
                     
                                UCOnClick(UcBtCtm);
                                


                            }
                            iDx++;
                        }
                    }
                }
                tblMain.Visible = true;
            }
        }

        private void UCOnClick(UC.UC_B1CTM uc)
        {
          //  MessageBox.Show(uc.Tag.ToString());
            string LineNo = uc.Tag.ToString();
            chartHeat.DataSource = null;
            chartCool.DataSource = null;
            foreach (var item in lstUC)
            {
                item.SetBorder(1,Color.FromArgb(20, 25, 54));
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                uc.SetBorder(5,Color.OrangeRed);
                if (dtHeat.Select("MACHINE_CD = '" + LineNo + "'").Count() > 0)
                {
                    DataTable dt = dtHeat.Select("MACHINE_CD = '" + LineNo + "'").CopyToDataTable();
                    BindingChartData("H",dt);
                }

                if (dtCool.Select("MACHINE_CD = '" + LineNo + "'").Count() > 0)
                {
                    DataTable dt = dtCool.Select("MACHINE_CD = '" + LineNo + "'").CopyToDataTable();
                    BindingChartData("C", dt);
                }
                this.Cursor = Cursors.Default;
            }
            catch { this.Cursor = Cursors.Default; }
        }


        

        private void BindingChartData(string argQtype,DataTable dt)
        {
            try
            {
                int d_min = 0, d_max = 0;

                d_min = int.Parse(dt.Rows[0]["MIN_VL"].ToString());
                d_max = int.Parse(dt.Rows[0]["MAX_VL"].ToString());
                switch (argQtype)
                {
                    case "H":
                        //Binding Chart Data
                        chartHeat.DataSource = dt;
                        chartHeat.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                        chartHeat.Series[0].ArgumentDataMember = "HMS";
                        chartHeat.Series[0].ValueDataMembers.AddRange(new string[] { "VL" });
                        ((DevExpress.XtraCharts.XYDiagram)chartHeat.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        ((XYDiagram)chartHeat.Diagram).AxisY.WholeRange.Auto = true;
                        ((XYDiagram)chartHeat.Diagram).AxisY.WholeRange.SetMinMaxValues(d_min-5, d_max + 5);
                        break;
                    case "C":
                        //Binding Chart Data
                        chartCool.DataSource = dt;
                        chartCool.Series[0].ArgumentScaleType = ScaleType.Qualitative;
                        chartCool.Series[0].ArgumentDataMember = "HMS";
                        chartCool.Series[0].ValueDataMembers.AddRange(new string[] { "VL" });
                        ((DevExpress.XtraCharts.XYDiagram)chartCool.Diagram).AxisX.QualitativeScaleOptions.AutoGrid = false;
                        ((XYDiagram)chartCool.Diagram).AxisY.WholeRange.Auto = true;
                        ((XYDiagram)chartCool.Diagram).AxisY.WholeRange.SetMinMaxValues(d_min - 5, d_max + 5);
                        break;
                }
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
          
        }

        private void SMT_SCADA_B1CTM_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
               
                cCount = 299;
                tmrTime.Start();
            }
            else
                tmrTime.Stop();
        }

        private void SMT_SCADA_B1CTM_TEMPER_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            InitLayout();
            //UCOnClick();
        }
        int blink = -1;
        private void timer_blink_Tick(object sender, EventArgs e)
        {
            if (blink > 0)
            {
                blink--;
                try
                {
                    foreach (var item in lstUC)
                    {
                        item.AnmationData(r.Next(1, 101).ToString(), r.Next(1, 101).ToString());
                    }
                }
                catch
                {

                }
                
            }
            if(blink == 0)
            {
                dtHeat = GET_MACHINE_TEMPER("HEAT", "", "");
                dtCool = GET_MACHINE_TEMPER("COOL", "", "");
                DataTable dtCur = GET_MACHINE_TEMPER("CURR", "", "");
                if (dtCur != null && dtCur.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtCur.Rows)
                    {
                        foreach (var item in lstUC)
                        {

                            if (item.Tag.ToString().Equals(dr["MACHINE_CD"].ToString()))
                            {
                                item.BindingData(dr);
                            }
                        }
                    }


                }
                blink = -1;
            }
           

        }

        Random r = new Random();
        private void tmrTime_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 300)
            {
                blink = 15;
                //Thread t = new Thread(() =>
                //{
                //    for (int i = 0; i <= 10; i++)
                //    {
                //        foreach (var item in lstUC)
                //        {
                //            item.AnmationData(r.Next(1, 101).ToString(), r.Next(1, 101).ToString());
                //        }

                //    }
                //});
                //t.Start();

                //if(t.com)

                cCount = 0;
                
            }
        }
    }
}
