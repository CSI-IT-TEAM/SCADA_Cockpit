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
    public partial class SMT_SCADA_B2_PU_MAT_TEMPER : Form
    {
        public SMT_SCADA_B2_PU_MAT_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
            tmrAnimation.Stop();
            tmrBlinking.Stop();
            InitLayout();
        }
        bool isLoad = true;
        const int ReloadTime = 60;
        int cCount = 0;
        List<Label> lstLabel = new List<Label>();
        private void cmdBack_Click(object sender, EventArgs e)
        {
            //ComVar.Var.callForm = "back";
            tmrDate.Stop();
            ComVar.Var.callForm = "back";
        }


        #region DB
        private DataTable SEL_TRACKING_DATA(string argType, string argDate, string argMachine)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_B2PU_ISOPOLY_TRACKING_V3";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_MACHINE";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = argMachine;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        #endregion


        private void InitLayout()
        {
            try
            {

                lstLabel.Add(lbl_001POLY1MAT);
                lstLabel.Add(lbl_001POLY1OIL);
                lstLabel.Add(lbl_001POLY1HOSE);

                lstLabel.Add(lbl_002POLY1MAT);
                lstLabel.Add(lbl_002POLY1OIL);
                lstLabel.Add(lbl_002POLY1HOSE);

                lstLabel.Add(lbl_003POLY1MAT);
                lstLabel.Add(lbl_003POLY1OIL);
                lstLabel.Add(lbl_003POLY1HOSE);


                lstLabel.Add(lbl_001POLY2MAT);
                lstLabel.Add(lbl_001POLY2OIL);
                lstLabel.Add(lbl_001POLY2HOSE);

                lstLabel.Add(lbl_002POLY2MAT);
                lstLabel.Add(lbl_002POLY2OIL);
                lstLabel.Add(lbl_002POLY2HOSE);

                lstLabel.Add(lbl_003POLY2MAT);
                lstLabel.Add(lbl_003POLY2OIL);
                lstLabel.Add(lbl_003POLY2HOSE);

                lstLabel.Add(lbl_001ISO1MAT);
                lstLabel.Add(lbl_001ISO1OIL);
                lstLabel.Add(lbl_001ISO1HOSE);

                lstLabel.Add(lbl_002ISO1MAT);
                lstLabel.Add(lbl_002ISO1OIL);
                lstLabel.Add(lbl_002ISO1HOSE);

                lstLabel.Add(lbl_003ISO1MAT);
                lstLabel.Add(lbl_003ISO1OIL);
                lstLabel.Add(lbl_003ISO1HOSE);

                //==============================
                lstLabel.Add(lbl_004POLY1_1MAT);
                lstLabel.Add(lbl_004POLY1_1OIL);
                lstLabel.Add(lbl_004POLY1_1HOSE);

                lstLabel.Add(lbl_005POLY1_1MAT);
                lstLabel.Add(lbl_005POLY1_1OIL);
                lstLabel.Add(lbl_005POLY1_1HOSE);

                lstLabel.Add(lbl_006POLY1_1MAT);
                lstLabel.Add(lbl_006POLY1_1OIL);
                lstLabel.Add(lbl_006POLY1_1HOSE);

                lstLabel.Add(lbl_007POLY1_1MAT);
                lstLabel.Add(lbl_007POLY1_1OIL);
                lstLabel.Add(lbl_007POLY1_1HOSE);

                lstLabel.Add(lbl_004POLY1_2MAT);
                lstLabel.Add(lbl_004POLY1_2OIL);
                lstLabel.Add(lbl_004POLY1_2HOSE);

                lstLabel.Add(lbl_005POLY1_2MAT);
                lstLabel.Add(lbl_005POLY1_2OIL);
                lstLabel.Add(lbl_005POLY1_2HOSE);

                lstLabel.Add(lbl_006POLY1_2MAT);
                lstLabel.Add(lbl_006POLY1_2OIL);
                lstLabel.Add(lbl_006POLY1_2HOSE);

                lstLabel.Add(lbl_007POLY1_2MAT);
                lstLabel.Add(lbl_007POLY1_2OIL);
                lstLabel.Add(lbl_007POLY1_2HOSE);

                lstLabel.Add(lbl_004POLY2_1MAT);
                lstLabel.Add(lbl_004POLY2_1OIL);
                lstLabel.Add(lbl_004POLY2_1HOSE);

                lstLabel.Add(lbl_005POLY2_1MAT);
                lstLabel.Add(lbl_005POLY2_1OIL);
                lstLabel.Add(lbl_005POLY2_1HOSE);

                lstLabel.Add(lbl_006POLY2_1MAT);
                lstLabel.Add(lbl_006POLY2_1OIL);
                lstLabel.Add(lbl_006POLY2_1HOSE);

                lstLabel.Add(lbl_007POLY2_1MAT);
                lstLabel.Add(lbl_007POLY2_1OIL);
                lstLabel.Add(lbl_007POLY2_1HOSE);

                lstLabel.Add(lbl_004POLY2_2MAT);
                lstLabel.Add(lbl_004POLY2_2OIL);
                lstLabel.Add(lbl_004POLY2_2HOSE);

                lstLabel.Add(lbl_005POLY2_2MAT);
                lstLabel.Add(lbl_005POLY2_2OIL);
                lstLabel.Add(lbl_005POLY2_2HOSE);

                lstLabel.Add(lbl_006POLY2_2MAT);
                lstLabel.Add(lbl_006POLY2_2OIL);
                lstLabel.Add(lbl_006POLY2_2HOSE);

                lstLabel.Add(lbl_007POLY2_2MAT);
                lstLabel.Add(lbl_007POLY2_2OIL);
                lstLabel.Add(lbl_007POLY2_2HOSE);

                lstLabel.Add(lbl_004ISO1_1MAT);
                lstLabel.Add(lbl_004ISO1_1OIL);
                lstLabel.Add(lbl_004ISO1_1HOSE);

                lstLabel.Add(lbl_005ISO1_1MAT);
                lstLabel.Add(lbl_005ISO1_1OIL);
                lstLabel.Add(lbl_005ISO1_1HOSE);

                lstLabel.Add(lbl_006ISO1_1MAT);
                lstLabel.Add(lbl_006ISO1_1OIL);
                lstLabel.Add(lbl_006ISO1_1HOSE);

                lstLabel.Add(lbl_007ISO1_1MAT);
                lstLabel.Add(lbl_007ISO1_1OIL);
                lstLabel.Add(lbl_007ISO1_1HOSE);

                lstLabel.Add(lbl_004ISO1_2MAT);
                lstLabel.Add(lbl_004ISO1_2OIL);
                lstLabel.Add(lbl_004ISO1_2HOSE);

                lstLabel.Add(lbl_005ISO1_2MAT);
                lstLabel.Add(lbl_005ISO1_2OIL);
                lstLabel.Add(lbl_005ISO1_2HOSE);

                lstLabel.Add(lbl_006ISO1_2MAT);
                lstLabel.Add(lbl_006ISO1_2OIL);
                lstLabel.Add(lbl_006ISO1_2HOSE);

                lstLabel.Add(lbl_007ISO1_2MAT);
                lstLabel.Add(lbl_007ISO1_2OIL);
                lstLabel.Add(lbl_007ISO1_2HOSE);





                lstLabel.Add(lbl_004ISO1_3MAT);
                lstLabel.Add(lbl_005ISO1_3MAT);
                lstLabel.Add(lbl_006ISO1_3MAT);
                lstLabel.Add(lbl_007ISO1_3MAT);

                lstLabel.Add(lbl_004ISO1_3OIL);
                lstLabel.Add(lbl_005ISO1_3OIL);
                lstLabel.Add(lbl_006ISO1_3OIL);
                lstLabel.Add(lbl_007ISO1_3OIL);

                lstLabel.Add(lbl_004ISO1_3HOSE);
                lstLabel.Add(lbl_005ISO1_3HOSE);
                lstLabel.Add(lbl_006ISO1_3HOSE);
                lstLabel.Add(lbl_007ISO1_3HOSE);

                lstLabel.Add(lbl_004POLY1_3MAT);
                lstLabel.Add(lbl_005POLY1_3MAT);
                lstLabel.Add(lbl_006POLY1_3MAT);
                lstLabel.Add(lbl_007POLY1_3MAT);

                lstLabel.Add(lbl_004POLY1_3OIL);
                lstLabel.Add(lbl_005POLY1_3OIL);
                lstLabel.Add(lbl_006POLY1_3OIL);
                lstLabel.Add(lbl_007POLY1_3OIL);

                lstLabel.Add(lbl_004POLY1_3HOSE);
                lstLabel.Add(lbl_005POLY1_3HOSE);
                lstLabel.Add(lbl_006POLY1_3HOSE);
                lstLabel.Add(lbl_007POLY1_3HOSE);

                lstLabel.Add(lbl_004POLY2_3MAT);
                lstLabel.Add(lbl_005POLY2_3MAT);
                lstLabel.Add(lbl_006POLY2_3MAT);
                lstLabel.Add(lbl_007POLY2_3MAT);

                lstLabel.Add(lbl_004POLY2_3OIL);
                lstLabel.Add(lbl_005POLY2_3OIL);
                lstLabel.Add(lbl_006POLY2_3OIL);
                lstLabel.Add(lbl_007POLY2_3OIL);

                lstLabel.Add(lbl_004POLY2_3HOSE);
                lstLabel.Add(lbl_005POLY2_3HOSE);
                lstLabel.Add(lbl_006POLY2_3HOSE);
                lstLabel.Add(lbl_007POLY2_3HOSE);







                foreach (var item in lstLabel)
                {
                    item.Tag = item.Name.ToString().Replace("lbl_", "");
                    item.Click += Item_Click;
                }

            }
            catch
            {


            }
        }

        private void Item_Click(object sender, EventArgs e)
        {

            try
            {

                foreach (var item in lstLabel)
                {

                    item.ForeColor = Color.White;
                }

                Label lbl = ((Label)sender);
                if (lbl.Text == "") { return; }

                // lbl.BackColor = Color.Yellow;
                lbl.ForeColor = Color.Yellow;


                int minvl = 0, maxvl = 0;
                DataTable dt = SEL_TRACKING_DATA("C", DateTime.Now.ToString("yyyyMMdd"), lbl.Tag.ToString());
                if (dt.Rows.Count > 2)
                {
                    if (lbl.Tag.ToString().Contains("OIL"))
                    {
                        //minvl = int.Parse(dt.Rows[0]["MIN_VAL"].ToString());
                        //maxvl = int.Parse(dt.Rows[0]["MAX_VAL"].ToString());
                    }
                    else if (lbl.Tag.ToString().Contains("POLY"))
                    {
                        //minvl = int.Parse(dt.Rows[0]["POLY_MIN_VAL"].ToString());
                        //maxvl = int.Parse(dt.Rows[0]["POLY_MAX_VAL"].ToString());
                    }
                    else
                    {
                        // minvl = int.Parse(dt.Rows[0]["ISO_MIN_VAL"].ToString());
                        // maxvl = int.Parse(dt.Rows[0]["ISO_MAX_VAL"].ToString());
                    }

                    minvl = int.Parse(dt.Rows[0]["MIN_VAL"].ToString());
                    maxvl = int.Parse(dt.Rows[0]["MAX_VAL"].ToString());
                }
                BindingChart(dt, minvl, maxvl);
                //  MessageBox.Show(lbl.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindingChart(DataTable dt, int minvl, int maxvl)
        {
            try
            {
                chartControl1.DataSource = null;
                if (dt.Rows.Count > 1)
                {

                    int maxValue = int.MinValue;
                    int minValue = int.MaxValue;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (int.TryParse(row["VALUE"].ToString(), out int val))
                        {
                            if (val > maxValue) maxValue = val;
                            if (val < minValue) minValue = val;
                        }
                    }

      

                    chartControl1.DataSource = dt;
                    chartControl1.Series[0].ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative;
                    chartControl1.Series[0].ArgumentDataMember = "HMS";
                    chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE" });

                    DevExpress.XtraCharts.ConstantLine constantLine1 = new DevExpress.XtraCharts.ConstantLine();
                    DevExpress.XtraCharts.ConstantLine constantLine2 = new DevExpress.XtraCharts.ConstantLine(); ////Constant line
                                                                                                                 //constantLine1.ShowInLegend = false;
                    constantLine1.AxisValueSerializable = minvl.ToString();
                    constantLine1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    constantLine1.Name = "Min";
                    constantLine2.AxisValueSerializable = maxvl.ToString();
                    constantLine2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                    constantLine2.Name = "Max";
                    // constantLine1.ShowBehind = false;
                    constantLine1.Title.Visible = false;
                    constantLine1.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //constantLine1.Title.Text = "Target";
                    constantLine1.LineStyle.Thickness = 2;
                    constantLine2.Title.Visible = false;
                    constantLine2.Title.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //constantLine1.Title.Text = "Target";
                    constantLine2.LineStyle.Thickness = 2;
                    // constantLine1.Title.Alignment = DevExpress.XtraCharts.ConstantLineTitleAlignment.Far;
                    ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.Clear();
                    ((XYDiagram)chartControl1.Diagram).AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] { constantLine1, constantLine2 });

                    ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.Auto = true;
                    ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.SetMinMaxValues(minValue - 3, maxValue + 3);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BindingData()
        {
            try
            {
                DataTable dt = SEL_TRACKING_DATA("Q", DateTime.Now.ToString("yyyyMMdd"), "");
                foreach (var item in lstLabel)
                {
                    item.BackColor = Color.Gray;
                    item.ForeColor = Color.White;
                    item.Text = "";
                }
                if (dt.Rows.Count < 2) return;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (var item in lstLabel)
                    {
                        if (item.Tag.ToString().Equals(dr["ID"]))
                        {
                            item.Text = dr["VALUE"].ToString();

                            if (dr["VALUE"] != null)
                            {
                                if (int.Parse(dr["STATUS"].ToString()) == 1)
                                {
                                    item.BackColor = Color.Red;
                                    item.ForeColor = Color.White;
                                }
                                else
                                {
                                    item.BackColor = Color.Green;
                                    item.ForeColor = Color.White;
                                }
                            }
                            if (dr["USE_YN"].ToString() == "N")
                            {
                                item.BackColor = Color.Gray;
                                item.ForeColor = Color.White;
                                item.Text = "";
                                // item.ForeColor = Color.Gray;
                            }

                            /*
                            
                            if (dr["DIV2"].ToString().Equals("OIL"))
                            {
                                if (dr["VALUE"] != null)
                                {
                                    if (int.Parse(dr["VALUE"].ToString()) < int.Parse(dr["OIL_MIN_VAL"].ToString()) || int.Parse(dr["VALUE"].ToString()) > int.Parse(dr["OIL_MAX_VAL"].ToString()))
                                    {
                                        item.BackColor = Color.Red;
                                        item.ForeColor = Color.White;
                                    }
                                    else
                                    {
                                        item.BackColor = Color.Green;
                                        item.ForeColor = Color.White;
                                    }
                                }
                            }
                            else
                            {
                                if (dr["VALUE"] != null)
                                {
                                    if (dr["DIV"].ToString().Equals("POLY"))
                                    {
                                        if (int.Parse(dr["VALUE"].ToString()) < int.Parse(dr["POLY_MIN_VAL"].ToString()) || int.Parse(dr["VALUE"].ToString()) > int.Parse(dr["POLY_MAX_VAL"].ToString()))
                                        {
                                            item.BackColor = Color.Red;
                                            item.ForeColor = Color.White;
                                        }
                                        else
                                        {
                                            item.BackColor = Color.Green;
                                            item.ForeColor = Color.White;
                                        }
                                    }else
                                    {
                                        if (int.Parse(dr["VALUE"].ToString()) < int.Parse(dr["ISO_MIN_VAL"].ToString()) || int.Parse(dr["VALUE"].ToString()) > int.Parse(dr["ISO_MIN_VAL"].ToString()))
                                        {
                                            item.BackColor = Color.Red;
                                            item.ForeColor = Color.White;
                                        }
                                        else
                                        {
                                            item.BackColor = Color.Green;
                                            item.ForeColor = Color.White;
                                        }
                                    }
                                }

                            }
                            */
                        }
                    }
                }

                if (isLoad)
                {
                    isLoad = false;
                    Item_Click(lbl_001POLY1MAT, null);
                }


            }
            catch (Exception ex)
            {

            }
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
        }

        private void SMT_SCADA_B2_PU_MAT_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Visible)
                {
                    cCount = ReloadTime;
                    tmrDate.Start();


                }
                else
                {
                    tmrDate.Stop();
                    tmrAnimation.Stop();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        Random r = new Random();
        int cAni = 0;
        const int TimeAniStop = 30;
        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            cAni++;
            foreach (var item in lstLabel)
            {
                item.Text = r.Next(1, 101).ToString();
            }
            if (cAni >= TimeAniStop)
            {
                cAni = 0;
                tmrAnimation.Stop();
                BindingData();
                tmrBlinking.Start();
            }

        }

        private void tmrBlinking_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in lstLabel)
                {
                    if (item.BackColor == Color.Red)
                        item.BackColor = Color.FromArgb(45, 55, 118);
                    else if (item.BackColor == Color.FromArgb(45, 55, 118))
                        item.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SMT_SCADA_B2_PU_MAT_TEMPER_Load(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY2HOSE_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY2OIL_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY2MAT_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY1HOSE_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY1OIL_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003POLY1MAT_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003ISO1HOSE_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003ISO1OIL_Click(object sender, EventArgs e)
        {

        }

        private void lbl_003ISO1MAT_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {

        }
    }
}
