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
    public partial class SMT_SCADA_BOTTOM_COCKPIT_V4 : Form
    {
        public SMT_SCADA_BOTTOM_COCKPIT_V4()
        {
            InitializeComponent();
            tmrBlinking.Stop();
        }

        bool isFirstTime = true;
        int cCount = 0;
        Random r = new Random();
        Color[] ColorRange = new Color[3] { Color.Red, Color.Green, Color.Yellow };
        bool isClick = false;
        List<Label> lblList = new List<Label>();
        List<Label> lblGrpList = new List<Label>();

        #region DB
        private DataTable SEL_F_CALL(string argType,string argHeadCode, string arglabelCode)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SEL_BOTTOM_COCKPIT_F_SEQ";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_HEAD_CODE";
            MyOraDB.Parameter_Name[2] = "ARG_LABEL_CODE";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argHeadCode;
            MyOraDB.Parameter_Values[2] = arglabelCode;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }

        private DataTable SEL_BOTTOM_COCKPIT_DATA(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SEL_BOTTOM_COCKPIT_DATA_V1";

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
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrTime.Stop();
            tmrBlinking.Stop();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                try
                {
                    splashScreenManager1.ShowWaitForm();
                    DataTable dt = SEL_BOTTOM_COCKPIT_DATA("Q");
                    BindingData(dt);
                    tmrBlinking.Start();
                    splashScreenManager1.CloseWaitForm();
                }
                catch { splashScreenManager1.CloseWaitForm(); }
            }
        }

        private void BindingData(DataTable dt)
        {
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (var item in lblList)
                    {
                        if (dr["ITEMS_MAPPING"].Equals(item.Tag.ToString()))
                        {

                            switch (dr["STATUS"].ToString())
                            {
                                case "G":
                                    item.BackColor = Color.Green;
                                    break;
                                case "R":
                                    item.BackColor = Color.Red;
                                    break;
                                case "Y":
                                    item.BackColor = Color.Yellow;
                                    break;
                            }
                        }
                    }
                }
                tmrBlinking.Start();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_V2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                if (isFirstTime)
                {
                    isFirstTime = !isFirstTime;
                    cCount = 60;
                }else
                {
                    cCount = 50;
                }
                tmrTime.Start();
                tmrBlinking.Start();

            }
            else
            {
                tmrTime.Stop();
                tmrBlinking.Stop();
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }


        private void SMT_SCADA_BOTTOM_COCKPIT_V4_Load(object sender, EventArgs e)
        {
            InitLayout();
        }

     
        private void tmrBlinking_Tick(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in lblList)
                {
                    if (item.BackColor == Color.Red)
                        item.BackColor = Color.FromArgb(191,191,191);
                    else if (item.BackColor == Color.FromArgb(191, 191, 191))
                        item.BackColor = Color.Red;
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }


            

        private void Item_Click1(object sender, EventArgs e)
        {
            //group click

            ComVar.Var._IsBack = true;
            Label lbl = ((Label)sender);
            //Using Flag
            //  ComVar.Var._strValue4 = lbl.Name.ToString(); //Lưu giá trị để kiểm tra selected page
            DataTable dt = SEL_F_CALL("Q", "2", lbl.Name.ToString());
            if (dt == null) return;
            //ComVar.Var._iValue1 = int.Parse(dt.Rows[0]["PAGE_IDX"].ToString());
            ComVar.Var.callForm = dt.Rows[0]["FORM_CALL_SEQ"].ToString();
        }

        private void InitLayout()
        {
            try
            {
                // B1 Rubber
                lblList.Add(B1_RUBBERBANB);
                lblList.Add(B1_RUBBERROLL003);
                lblList.Add(B1_RUBBERROLL007);
                lblList.Add(B1_RUBBERCALD);

                // B1 Eva
                lblList.Add(B1_EVAB1_EVA_CALD);
                lblList.Add(B1_EVAB1_EVA_KNED);
                lblList.Add(B1_EVAB1_EVA_ROLL003);
                lblList.Add(B1_EVAB1_EVA_EXTR);
                lblList.Add(B1_EVAB1_EVA_PELL);

                // B1 CTM

                lblList.Add(B1_CTM1_6);
                lblList.Add(B1_CTM7_12);
                lblList.Add(B1_CTM13_18);
                lblList.Add(B1_CTM19_24);
                lblList.Add(B1_CTM25_30);
                lblList.Add(B1_CTM31_36);
                lblList.Add(B1_CTM37_42);
                lblList.Add(B1_CTM43_48);
                lblList.Add(B1_CTM49_54);
                lblList.Add(B1_CTM55_60);

                // B1 COM

                lblList.Add(B2_COMPKNED_KD202);
                lblList.Add(B2_COMPROLL_KD202);
                lblList.Add(B2_COMPEXTR_KD202);
                lblList.Add(B2_COMPPELL_KD202);

                lblList.Add(B2_COMPKNED_KD203);
                lblList.Add(B2_COMPROLL_KD203);
                lblList.Add(B2_COMPEXTR_KD203);
                lblList.Add(B2_COMPPELL_KD203);

                lblList.Add(B2_COMPKNED_KD204);
                lblList.Add(B2_COMPROLL_KD204);
                lblList.Add(B2_COMPEXTR_KD204);
                lblList.Add(B2_COMPPELL_KD204);


                lblList.Add(IP_ZONE_001);
                lblList.Add(IP_ZONE_002);
                lblList.Add(IP_ZONE_003);
                lblList.Add(IP_ZONE_004);
                lblList.Add(IP_ZONE_005);
                lblList.Add(IP_ZONE_006);
                lblList.Add(IP_ZONE_007);

                lblList.Add(IP_UV_ZONE001);
                lblList.Add(IP_UV_ZONE002);
                lblList.Add(IP_UV_ZONE003);
                lblList.Add(IP_UV_ZONE004);
                lblList.Add(IP_UV_ZONE005);
                lblList.Add(IP_UV_ZONE006);
                lblList.Add(IP_UV_ZONE007);


                // PU 
                lblList.Add(B2_POLY_MAT);
                lblList.Add(B2_ISO1_MAT);
                lblList.Add(B2_ISO2_MAT);

                lblList.Add(PU_EQUIPMENT001);
                lblList.Add(PU_EQUIPMENT002);
                lblList.Add(PU_EQUIPMENT003);
                lblList.Add(PU_EQUIPMENT004);
                lblList.Add(PU_EQUIPMENT005);
                lblList.Add(PU_EQUIPMENT006);
                lblList.Add(PU_EQUIPMENT007);





                foreach (var item in lblList)
                {
                    item.Tag = item.Name;
                    item.BackColor = Color.Silver;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        private void call_from(int from)
        {
           
            /*
                1 - lbl_OS_GRP_RUBBER
                2 - lbl_OS_GRP_EVA
                3 - lbl_PH_GRP_CTM
                4 - lbl_IP_GRP_COMP
                5 - lbl_IP_GRP_ZONE
                6 - lbl_IP_UV_GRP_ZONE
                7 - lbl_PU_GRP_MAT
                8 - lbl_PU_GRP
                
            */
            string[] Name = new string[9];

            Name[1] = "lbl_OS_GRP_RUBBER";
            Name[2] = "lbl_OS_GRP_EVA";
            Name[3] = "lbl_PH_GRP_CTM";
            Name[4] = "lbl_IP_GRP_COMP";
            Name[5] = "lbl_IP_GRP_ZONE";
            Name[6] = "lbl_IP_UV_GRP_ZONE";
            Name[7] = "lbl_PU_GRP_MAT";
            Name[8] = "lbl_PU_GRP";

            DataTable dt = SEL_F_CALL("Q", "2", Name[from]);
            if (dt == null) return;
            if (dt.Rows[0]["FORM_CALL_SEQ"].ToString().Length >= 1)
            {
                ComVar.Var._IsBack = true;
                ComVar.Var.callForm = dt.Rows[0]["FORM_CALL_SEQ"].ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            call_from(1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            call_from(2);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            call_from(3);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void label115_Click(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void label116_Click(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            call_from(5);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            call_from(6);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            call_from(7);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            call_from(8);
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Label btn = (Label)sender;
                btn.BackColor = Color.Transparent;
            }
            catch
            {

            }
        }
        private void lbl_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Label btn = (Label)sender;
                btn.BackColor = Color.HotPink;

            }
            catch 
            {
               
            }
        }

        private void lblHeader_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
