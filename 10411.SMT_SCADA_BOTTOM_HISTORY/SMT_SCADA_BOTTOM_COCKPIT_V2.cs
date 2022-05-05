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
    public partial class SMT_SCADA_BOTTOM_COCKPIT_V2 : Form
    {
        public SMT_SCADA_BOTTOM_COCKPIT_V2()
        {
            InitializeComponent();
        }
        int cCount = 0;
        Random r = new Random();
        Color[] ColorRange = new Color[3] { Color.Red, Color.Green, Color.Yellow };
        bool isClick = false;
        List<Label> lblList = new List<Label>();

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
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
                DataTable dt = SEL_BOTTOM_COCKPIT_DATA("Q");
                BindingData(dt);
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
                cCount = 60;
                tmrTime.Start();
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
        #region Initlayout
        private void InitLayout()
        {
            try
            {
                // OS Rubber
                lblList.Add(lbl_OS_Rub_Banbury);
                lblList.Add(lbl_OS_Rub_1Roll);
                lblList.Add(lbl_OS_Rub_2Roll);
                lblList.Add(lbl_OS_Rub_Calendar);

                //OS Eva
                lblList.Add(lbl_OS_EVA_Kneader);
                lblList.Add(lbl_OS_EVA_Roll);
                lblList.Add(lbl_OS_EVA_Extruder);
                lblList.Add(lbl_OS_EVA_Pall);
                lblList.Add(lbl_OS_EVA_Calendar);

                //Phylon CTM
                lblList.Add(lbl_PH_CTM_1);
                lblList.Add(lbl_PH_CTM_2);
                lblList.Add(lbl_PH_CTM_3);
                lblList.Add(lbl_PH_CTM_4);
                lblList.Add(lbl_PH_CTM_5);
                lblList.Add(lbl_PH_CTM_6);
                lblList.Add(lbl_PH_CTM_7);
                lblList.Add(lbl_PH_CTM_8);
                lblList.Add(lbl_PH_CTM_9);
                lblList.Add(lbl_PH_CTM_10);
                lblList.Add(lbl_PH_CTM_11);
                lblList.Add(lbl_PH_CTM_12);
                lblList.Add(lbl_PH_CTM_13);
                lblList.Add(lbl_PH_CTM_14);

                //Phylon UV
                lblList.Add(lbl_PH_UV_1);
                lblList.Add(lbl_PH_UV_2);
                lblList.Add(lbl_PH_UV_3);
                lblList.Add(lbl_PH_UV_4);
                lblList.Add(lbl_PH_UV_5);
                lblList.Add(lbl_PH_UV_6);
                lblList.Add(lbl_PH_UV_7);

                //IP-A Compound
                lblList.Add(lbl_IPA_1_Kneader);
                lblList.Add(lbl_IPA_2_Kneader);
                lblList.Add(lbl_IPA_3_Kneader);
                lblList.Add(lbl_IPA_4_Kneader);

                lblList.Add(lbl_IPA_1_Roll);
                lblList.Add(lbl_IPA_2_Roll);
                lblList.Add(lbl_IPA_3_Roll);
                lblList.Add(lbl_IPA_4_Roll);

                lblList.Add(lbl_IPA_1_Extruder);
                lblList.Add(lbl_IPA_2_Extruder);
                lblList.Add(lbl_IPA_3_Extruder);
                lblList.Add(lbl_IPA_4_Extruder);

                lblList.Add(lbl_IPA_1_Pall);
                lblList.Add(lbl_IPA_2_Pall);
                lblList.Add(lbl_IPA_3_Pall);
                lblList.Add(lbl_IPA_4_Pall);

                //IP-A Zone
                lblList.Add(lbl_IPA_Zone_1_Injection);
                lblList.Add(lbl_IPA_Zone_2_Injection);
                lblList.Add(lbl_IPA_Zone_3_Injection);
                lblList.Add(lbl_IPA_Zone_4_Injection);
                lblList.Add(lbl_IPA_Zone_5_Injection);
                lblList.Add(lbl_IPA_Zone_6_Injection);
                lblList.Add(lbl_IPA_Zone_7_Injection);

                lblList.Add(lbl_IPA_Zone_1_Stab);
                lblList.Add(lbl_IPA_Zone_2_Stab);
                lblList.Add(lbl_IPA_Zone_3_Stab);
                lblList.Add(lbl_IPA_Zone_4_Stab);
                lblList.Add(lbl_IPA_Zone_5_Stab);
                lblList.Add(lbl_IPA_Zone_6_Stab);
                lblList.Add(lbl_IPA_Zone_7_Stab);

                //IP-A UV
                lblList.Add(lbl_IPA_UV_1);
                lblList.Add(lbl_IPA_UV_2);
                lblList.Add(lbl_IPA_UV_3);
                lblList.Add(lbl_IPA_UV_4);
                lblList.Add(lbl_IPA_UV_5);
                lblList.Add(lbl_IPA_UV_6);
                lblList.Add(lbl_IPA_UV_7);

                //PU
                lblList.Add(lbl_PU_Poly);
                lblList.Add(lbl_PU_Iso);

                lblList.Add(lbl_PU_Auto_Mat_1);
                lblList.Add(lbl_PU_Auto_Mat_2);
                lblList.Add(lbl_PU_Auto_Mat_3);

                lblList.Add(lbl_PU_Auto_Oil_1);
                lblList.Add(lbl_PU_Auto_Oil_2);
                lblList.Add(lbl_PU_Auto_Oil_3);

                lblList.Add(lbl_PU_Auto_Hose_1);
                lblList.Add(lbl_PU_Auto_Hose_2);
                lblList.Add(lbl_PU_Auto_Hose_3);

                lblList.Add(lbl_PU_Manual_Mat_1);
                lblList.Add(lbl_PU_Manual_Mat_2);
                lblList.Add(lbl_PU_Manual_Mat_3);

                lblList.Add(lbl_PU_Manual_Oil_1);
                lblList.Add(lbl_PU_Manual_Oil_2);
                lblList.Add(lbl_PU_Manual_Oil_3);

                lblList.Add(lbl_PU_Manual_Hose_1);
                lblList.Add(lbl_PU_Manual_Hose_2);
                lblList.Add(lbl_PU_Manual_Hose_3);

                lblList.Add(lbl_PU_UV_1);
                lblList.Add(lbl_PU_UV_2);
                lblList.Add(lbl_PU_UV_3);
                lblList.Add(lbl_PU_UV_4);
                lblList.Add(lbl_PU_UV_5);
                lblList.Add(lbl_PU_UV_6);
                lblList.Add(lbl_PU_UV_7);

                lblList.Add(lbl_PU_SPRAY_1);
                lblList.Add(lbl_PU_SPRAY_2);
                lblList.Add(lbl_PU_SPRAY_3);
                lblList.Add(lbl_PU_SPRAY_4);
                lblList.Add(lbl_PU_SPRAY_5);
                lblList.Add(lbl_PU_SPRAY_6);
                lblList.Add(lbl_PU_SPRAY_7);
                lblList.Add(lbl_PU_SPRAY_8);
                lblList.Add(lbl_PU_SPRAY_9);
                lblList.Add(lbl_PU_SPRAY_10);

                foreach (var item in lblList)
                {
                    item.Tag = item.Name;
                    item.BackColor = Color.Silver;
                    item.Click += Item_Click;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            Label lbl = ((Label)sender);
            MessageBox.Show(lbl.Name.ToString());
            ComVar.Var.callForm = SEL_F_CALL("Q","1", lbl.Name.ToString()).Rows[0]["FORM_CALL_SEQ"].ToString();
        }
        #endregion

        private void SMT_SCADA_BOTTOM_COCKPIT_V2_Load(object sender, EventArgs e)
        {
            //InitLayout
            InitLayout();
        }
    }
}
