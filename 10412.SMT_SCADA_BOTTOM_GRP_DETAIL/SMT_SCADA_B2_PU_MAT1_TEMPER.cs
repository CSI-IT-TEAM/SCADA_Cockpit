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
    public partial class SMT_SCADA_B2_PU_MAT1_TEMPER : Form
    {
        public SMT_SCADA_B2_PU_MAT1_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
            tmrAnimation.Stop();
            tmrBlinking.Stop();
        }
        const int ReloadTime = 60;
        int cCount = 0;
        private DataTable SEL_TEMPERATURE(string arg_mc_id)
        {
            COM.OraDB MyOraDB = new COM.OraDB();
            DataSet ds_ret;
            try
            {
                string process_name = "PKG_SMT_MAT.SEL_TEMPERATURE";

                MyOraDB.ReDim_Parameter(1);
                MyOraDB.Process_Name = process_name;

                MyOraDB.Parameter_Name[0] = "OUT_CURSOR";

                MyOraDB.Parameter_Type[0] = (int)OracleType.Cursor;

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

        private void loadData()
        {
            DataTable dt = SEL_TEMPERATURE("001");
            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["TEMP5"].ToString() != "0°C")
                {
                    lbl_poly_hea.Text = dt.Rows[0]["TEMP5"].ToString().Replace("R", "");

                    lbl_poly_hea1.Text = string.Concat(dt.Rows[0]["MIN_TEMP5"], "°C - ", dt.Rows[0]["MAX_TEMP5"], "°C");

                    if (dt.Rows[0]["TEMP5"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_poly_hea.Tag = "1";
                    }
                    else
                        lbl_poly_hea.Tag = "0";
                }

                if (dt.Rows[0]["TEMP6"].ToString() != "0°C")
                {
                    lbl_poly_war.Text = dt.Rows[0]["TEMP6"].ToString().Replace("R", "");
                    lbl_poly_war1.Text = string.Concat(dt.Rows[0]["MIN_TEMP6"], "°C - ", dt.Rows[0]["MAX_TEMP6"], "°C");

                    if (dt.Rows[0]["TEMP6"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_poly_war.Tag = "2";
                    }
                    else
                        lbl_poly_war.Tag = "0";

                }

                if (dt.Rows[0]["TEMP2"].ToString() != "0°C")
                {
                    lbl_iso1_hea.Text = dt.Rows[0]["TEMP2"].ToString().Replace("R", "");
                    lbl_iso1_hea1.Text = string.Concat(dt.Rows[0]["MIN_TEMP2"], "°C - ", dt.Rows[0]["MAX_TEMP2"], "°C");
                    if (dt.Rows[0]["TEMP2"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_iso1_hea.Tag = "1";
                    }
                    else
                        lbl_iso1_hea.Tag = "0";
                }

                if (dt.Rows[0]["TEMP4"].ToString() != "0°C")
                {
                    lbl_iso1_war.Text = dt.Rows[0]["TEMP4"].ToString().Replace("R", "");
                    lbl_iso1_war1.Text = string.Concat(dt.Rows[0]["MIN_TEMP4"], "°C - ", dt.Rows[0]["MAX_TEMP4"], "°C");
                    if (dt.Rows[0]["TEMP4"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_iso1_war.Tag = "2";
                    }
                    else
                        lbl_iso1_war.Tag = "0";
                }

                if (dt.Rows[0]["TEMP1"].ToString() != "0°C")
                {
                    lbl_iso2_hea.Text = dt.Rows[0]["TEMP1"].ToString().Replace("R", "");
                    lbl_iso2_hea1.Text = string.Concat(dt.Rows[0]["MIN_TEMP1"], "°C - ", dt.Rows[0]["MAX_TEMP1"], "°C");
                    if (dt.Rows[0]["TEMP1"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_iso2_hea.Tag = "1";
                    }
                    else
                        lbl_iso2_hea.Tag = "0";
                }

                if (dt.Rows[0]["TEMP3"].ToString() != "0°C")
                {
                    lbl_iso2_war.Text = dt.Rows[0]["TEMP3"].ToString().Replace("R", "");
                    lbl_iso2_war1.Text = string.Concat(dt.Rows[0]["MIN_TEMP3"], "°C - ", dt.Rows[0]["MAX_TEMP3"], "°C");
                    if (dt.Rows[0]["TEMP3"].ToString().Substring(0, 1) == "R")
                    {
                        lbl_iso2_war.Tag = "2";
                    }
                    else
                        lbl_iso2_war.Tag = "0";
                }

            }

        }

        private void getControl()
        {
            try
            {
                foreach (Control cnt in this.Controls)
                {
                    if (cnt.Tag == "1")
                    {
                        if (cnt.BackColor != Color.Red)
                            cnt.BackColor = Color.Red;
                        else
                            cnt.BackColor = Color.FromArgb(45, 55, 118);
                    }
                    else if (cnt.Tag == "2")
                    {
                        if (cnt.BackColor != Color.Red)
                            cnt.BackColor = Color.Red;
                        else
                            cnt.BackColor = Color.FromArgb(45, 55, 118);
                    }
                    cnt.ForeColor = Color.White;

                }
            }
            catch (Exception ex)
            {

            }
        }

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
        }

        private void SMT_SCADA_B2_PU_MAT1_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
                tmrDate.Stop();
        }
        Random r = new Random();
        int cAni = 0;
        const int TimeAniStop = 30;
        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            cAni++;

            lbl_poly_hea.Text = r.Next(1, 101).ToString();
            lbl_poly_war.Text = r.Next(1, 101).ToString();
            lbl_iso1_war.Text = r.Next(1, 101).ToString();
            lbl_iso1_hea.Text = r.Next(1, 101).ToString();
            lbl_iso2_war.Text = r.Next(1, 101).ToString();
            lbl_iso2_hea.Text = r.Next(1, 101).ToString();
            if (cAni >= TimeAniStop)
            {
                cAni = 0;
                tmrAnimation.Stop();
                loadData();
                tmrBlinking.Start();
            }
        }

        private void tmrBlinking_Tick(object sender, EventArgs e)
        {
            getControl();
        }
    }
}
