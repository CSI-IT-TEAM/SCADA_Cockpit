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
    public partial class SMT_SCADA_BOTTOM_COCKPIT_V4_1 : Form
    {
        public SMT_SCADA_BOTTOM_COCKPIT_V4_1()
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
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.SEL_BOTTOM_COCKPIT_DATA";

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
                        if (dr["LABEL_CODE"].Equals(item.Tag.ToString()))
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
            catch (Exception)
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
                    cCount = 30;
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
            foreach (var item in lblList)
            {
                item.BackColor = !isClick ? ColorRange[r.Next(0, 3)] : Color.Silver;
            }
            isClick = !isClick;
        }
        #region Init layout
        //private void InitLayout()
        //{
        //    try
        //    {
        //        // OS Rubber
        //        lblList.Add(lbl_OS_Rub_Banbury);
        //        lblList.Add(lbl_OS_Rub_1Roll);
        //        lblList.Add(lbl_OS_Rub_2Roll);
        //        lblList.Add(lbl_OS_Rub_Calendar);

        //        //OS Eva
        //        lblList.Add(lbl_OS_EVA_Kneader);
        //        lblList.Add(lbl_OS_EVA_Roll);
        //        lblList.Add(lbl_OS_EVA_Extruder);
        //        lblList.Add(lbl_OS_EVA_Pall);
        //        lblList.Add(lbl_OS_EVA_Calendar);

        //        //Phylon CTM
        //        lblList.Add(lbl_PH_CTM_1);
        //        lblList.Add(lbl_PH_CTM_2);
        //        lblList.Add(lbl_PH_CTM_3);
        //        lblList.Add(lbl_PH_CTM_4);
        //        lblList.Add(lbl_PH_CTM_5);
        //        lblList.Add(lbl_PH_CTM_6);
        //        lblList.Add(lbl_PH_CTM_7);
        //        lblList.Add(lbl_PH_CTM_8);
        //        lblList.Add(lbl_PH_CTM_9);
        //        lblList.Add(lbl_PH_CTM_10);
        //        lblList.Add(lbl_PH_CTM_11);
        //        lblList.Add(lbl_PH_CTM_12);
        //        lblList.Add(lbl_PH_CTM_13);
        //        lblList.Add(lbl_PH_CTM_14);

        //        //Phylon UV
        //        lblList.Add(lbl_PH_UV_1);
        //        lblList.Add(lbl_PH_UV_2);
        //        lblList.Add(lbl_PH_UV_3);
        //        lblList.Add(lbl_PH_UV_4);
        //        lblList.Add(lbl_PH_UV_5);
        //        lblList.Add(lbl_PH_UV_6);
        //        lblList.Add(lbl_PH_UV_7);

        //        //IP-A Compound
        //        lblList.Add(lbl_IPA_1_Kneader);
        //        lblList.Add(lbl_IPA_2_Kneader);
        //        lblList.Add(lbl_IPA_3_Kneader);
        //        lblList.Add(lbl_IPA_4_Kneader);

        //        lblList.Add(lbl_IPA_1_Roll);
        //        lblList.Add(lbl_IPA_2_Roll);
        //        lblList.Add(lbl_IPA_3_Roll);
        //        lblList.Add(lbl_IPA_4_Roll);

        //        lblList.Add(lbl_IPA_1_Extruder);
        //        lblList.Add(lbl_IPA_2_Extruder);
        //        lblList.Add(lbl_IPA_3_Extruder);
        //        lblList.Add(lbl_IPA_4_Extruder);

        //        lblList.Add(lbl_IPA_1_Pall);
        //        lblList.Add(lbl_IPA_2_Pall);
        //        lblList.Add(lbl_IPA_3_Pall);
        //        lblList.Add(lbl_IPA_4_Pall);

        //        //IP-A Zone
        //        lblList.Add(lbl_IPA_Zone_1_Injection);
        //        lblList.Add(lbl_IPA_Zone_2_Injection);
        //        lblList.Add(lbl_IPA_Zone_3_Injection);
        //        lblList.Add(lbl_IPA_Zone_4_Injection);
        //        lblList.Add(lbl_IPA_Zone_5_Injection);
        //        lblList.Add(lbl_IPA_Zone_6_Injection);
        //        lblList.Add(lbl_IPA_Zone_7_Injection);

        //        lblList.Add(lbl_IPA_Zone_1_Stab);
        //        lblList.Add(lbl_IPA_Zone_2_Stab);
        //        lblList.Add(lbl_IPA_Zone_3_Stab);
        //        lblList.Add(lbl_IPA_Zone_4_Stab);
        //        lblList.Add(lbl_IPA_Zone_5_Stab);
        //        lblList.Add(lbl_IPA_Zone_6_Stab);
        //        lblList.Add(lbl_IPA_Zone_7_Stab);

        //        //IP-A UV
        //        lblList.Add(lbl_IPA_UV_1);
        //        lblList.Add(lbl_IPA_UV_2);
        //        lblList.Add(lbl_IPA_UV_3);
        //        lblList.Add(lbl_IPA_UV_4);
        //        lblList.Add(lbl_IPA_UV_5);
        //        lblList.Add(lbl_IPA_UV_6);
        //        lblList.Add(lbl_IPA_UV_7);

        //        //PU
        //        lblList.Add(lbl_PU_Poly);
        //        lblList.Add(lbl_PU_Iso);

        //        lblList.Add(lbl_PU_Auto_Mat_1);
        //        lblList.Add(lbl_PU_Auto_Mat_2);
        //        lblList.Add(lbl_PU_Auto_Mat_3);

        //        lblList.Add(lbl_PU_Auto_Oil_1);
        //        lblList.Add(lbl_PU_Auto_Oil_2);
        //        lblList.Add(lbl_PU_Auto_Oil_3);

        //        lblList.Add(lbl_PU_Auto_Hose_1);
        //        lblList.Add(lbl_PU_Auto_Hose_2);
        //        lblList.Add(lbl_PU_Auto_Hose_3);

        //        lblList.Add(lbl_PU_Manual_Mat_1);
        //        lblList.Add(lbl_PU_Manual_Mat_2);
        //        lblList.Add(lbl_PU_Manual_Mat_3);

        //        lblList.Add(lbl_PU_Manual_Oil_1);
        //        lblList.Add(lbl_PU_Manual_Oil_2);
        //        lblList.Add(lbl_PU_Manual_Oil_3);

        //        lblList.Add(lbl_PU_Manual_Hose_1);
        //        lblList.Add(lbl_PU_Manual_Hose_2);
        //        lblList.Add(lbl_PU_Manual_Hose_3);

        //        lblList.Add(lbl_PU_UV_1);
        //        lblList.Add(lbl_PU_UV_2);
        //        lblList.Add(lbl_PU_UV_3);
        //        lblList.Add(lbl_PU_UV_4);
        //        lblList.Add(lbl_PU_UV_5);
        //        lblList.Add(lbl_PU_UV_6);
        //        lblList.Add(lbl_PU_UV_7);

        //        lblList.Add(lbl_PU_SPRAY_1);
        //        lblList.Add(lbl_PU_SPRAY_2);
        //        lblList.Add(lbl_PU_SPRAY_3);
        //        lblList.Add(lbl_PU_SPRAY_4);
        //        lblList.Add(lbl_PU_SPRAY_5);
        //        lblList.Add(lbl_PU_SPRAY_6);
        //        lblList.Add(lbl_PU_SPRAY_7);
        //        lblList.Add(lbl_PU_SPRAY_8);
        //        lblList.Add(lbl_PU_SPRAY_9);
        //        lblList.Add(lbl_PU_SPRAY_10);

        //        //GROUP
        //        lblGrpList.Add(lbl_OS_GRP_RUBBER);
        //        lblGrpList.Add(lbl_OS_GRP_EVA);

        //        lblGrpList.Add(lbl_PH_GRP_CTM);

        //        lblGrpList.Add(lbl_IP_GRP_COMP);

        //        lblGrpList.Add(lbl_IP_GRP_ZONE);

        //        lblGrpList.Add(lbl_PU_GRP_MAT);

        //        lblGrpList.Add(lbl_IP_UV_GRP_ZONE);

        //        lblGrpList.Add(lbl_PU_GRP);

        //        foreach (var item in lblList)
        //        {
        //            item.Tag = item.Name;
        //            item.BackColor = Color.Silver;
        //            item.Click += Item_Click;
        //        }

        //        foreach (var item in lblGrpList)
        //        {
        //            item.Tag = item.Name;
        //            item.Click += Item_Click1;
        //            item.MouseEnter += lbl_GRP_MouseEnter;
        //            item.MouseLeave += lbl_GRP_MouseLeave;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
        #endregion

        private void SMT_SCADA_BOTTOM_COCKPIT_V4_Load(object sender, EventArgs e)
        {
            //InitLayout
            //InitLayout();
            int a = 0;
        }

        private void lbl_GRP_MouseEnter(object sender, EventArgs e)
        {
            RoundLabel lbl = ((RoundLabel)sender);
            lbl.ForeColor = Color.Blue;
            lbl.Font = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
        }

        private void lbl_GRP_MouseLeave(object sender, EventArgs e)
        {
            RoundLabel lbl = ((RoundLabel)sender);
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
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

        private void lbl_PU_Poly_Click(object sender, EventArgs e)
        {

        }

        private void lbl_OS_GRP_RUBBER_Click(object sender, EventArgs e)
        {

        }

        private void cmdScadaBottom_Click(object sender, EventArgs e)
        {
            call_from(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            call_from(1);
            //ComVar.Var._IsBack = true;
            ///*
            //    1 - lbl_OS_GRP_RUBBER
            //    2 - lbl_OS_GRP_EVA
            //    3 - lbl_PH_GRP_CTM
            //    4 - lbl_IP_GRP_COMP
            //    5 - lbl_IP_GRP_ZONE
            //    6 - lbl_IP_UV_GRP_ZONE
            //    7 - lbl_PU_GRP_MAT
            //    8 - lbl_PU_GRP

            //*/
            //DataTable dt = SEL_F_CALL("Q", "2", "lbl_OS_GRP_RUBBER");
            //if (dt == null) return;
            //ComVar.Var.callForm = dt.Rows[0]["FORM_CALL_SEQ"].ToString();
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

        private void label4_Click(object sender, EventArgs e)
        {
            call_from(2);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            call_from(3);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void label11_Click(object sender, EventArgs e)
        {
            call_from(5);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            call_from(6);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            call_from(7);
        }

        private void label17_Click(object sender, EventArgs e)
        {
            call_from(8);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            call_from(6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            call_from(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            call_from(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            call_from(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            call_from(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            call_from(7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            call_from(8);
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
               // Debug.WriteLine(ex.Message);
            }
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
          
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }


        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Hand;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 7;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.Default;
                Button btn = (Button)sender;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.BorderColor = Color.White;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            call_from(7);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            call_from(5);
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            call_from(6);
        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            call_from(8);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            call_from(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            call_from(2);
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            call_from(3);
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            call_from(4);
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
