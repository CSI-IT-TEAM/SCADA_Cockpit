using DevExpress.XtraEditors;
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
    public partial class SMT_SCADA_B2IPZONE_TEMPER : Form
    {
        public SMT_SCADA_B2IPZONE_TEMPER()
        {
            InitializeComponent();
            tmrDate.Stop();
        }
        #region Variable
        int cCount = 0;
        const int ReloadTime = 60;
        List<Label> lstLabel = new List<Label>();
        string argZone = "Z001",argStabMC = "001",argStabLine = "001";
        #endregion

        #region DB
        private DataTable SEL_INJECTION_DATA(string argType, string argDate, string argZone)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_B_COCKPIT.SP_SELECT_B2ZONE_INJECT_TEMP";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "ARG_ZONE";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = argZone;
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }
        #endregion


        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrDate.Stop();
        }

        private void tmrDate_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= ReloadTime)
            {
                cCount = 0;
                string _argZone = argZone;
                BindingInjectionData(_argZone);
            }
        }

        private void BindingInjectionData(string _argZone)
        {
            DataTable dt = SEL_INJECTION_DATA("Q", DateTime.Now.ToString("yyyyMMdd"), _argZone);
            gridControl1.DataSource = dt;
            for (int i = 0; i < gridView1.Columns.Count; i++)
            {
                gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                if (i==0)
                    gridView1.Columns[i].OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;

            }
        }

        private void sbtnZone_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            cCount = 0;
            sbtnZone1.Appearance.BackColor = sbtnZone1.Appearance.BackColor2= Color.Silver;
            sbtnZone2.Appearance.BackColor = sbtnZone2.Appearance.BackColor2=Color.Silver;
            sbtnZone3.Appearance.BackColor = sbtnZone3.Appearance.BackColor2=Color.Silver;
            sbtnZone4.Appearance.BackColor = sbtnZone4.Appearance.BackColor2=Color.Silver;
            sbtnZone5.Appearance.BackColor = sbtnZone5.Appearance.BackColor2=Color.Silver;
            sbtnZone6.Appearance.BackColor = sbtnZone6.Appearance.BackColor2=Color.Silver;
            sbtnZone7.Appearance.BackColor = sbtnZone7.Appearance.BackColor2 = Color.Silver;

            SimpleButton sbtn = ((SimpleButton)sender);
            sbtn.Appearance.BackColor = sbtn.Appearance.BackColor2 = Color.Yellow;
            argZone = sbtn.Tag.ToString();
            BindingInjectionData(argZone);
            this.Cursor = Cursors.Default;
        }

        private void SMT_SCADA_B2IPZONE_TEMPER_Load(object sender, EventArgs e)
        {
            InitLabelControls();

            //Select data with default value

        }

        private void SMT_SCADA_B2IPZONE_TEMPER_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = ReloadTime;
                tmrDate.Start();
            }
            else
            {
                tmrDate.Stop();
            }
        }

        private void InitLabelControls()
        {
            lstLabel.Add(lblLine_001_001);
            lstLabel.Add(lblLine_001_002);
            lstLabel.Add(lblLine_001_003);
            lstLabel.Add(lblLine_001_004);
            lstLabel.Add(lblLine_001_005);
            lstLabel.Add(lblLine_001_006);
            lstLabel.Add(lblLine_001_007);
            lstLabel.Add(lblLine_001_008);
            lstLabel.Add(lblLine_001_009);
            lstLabel.Add(lblLine_001_010);
            lstLabel.Add(lblLine_001_011);
            lstLabel.Add(lblLine_001_012);

            lstLabel.Add(lblLine_002_001);
            lstLabel.Add(lblLine_002_002);
            lstLabel.Add(lblLine_002_003);
            lstLabel.Add(lblLine_002_004);
            lstLabel.Add(lblLine_002_005);
            lstLabel.Add(lblLine_002_006);
            lstLabel.Add(lblLine_002_007);
            lstLabel.Add(lblLine_002_008);
            lstLabel.Add(lblLine_002_009);
            lstLabel.Add(lblLine_002_010);
            lstLabel.Add(lblLine_002_011);
            lstLabel.Add(lblLine_002_012);

            foreach (var item in lstLabel)
            {
                item.Click += Item_Click;
            }

        }

        private void Item_Click(object sender, EventArgs e)
        {
            try
            {
                Label lbl = ((Label)sender);
                foreach (var item in lstLabel)
                {
                    item.BackColor = Color.FromArgb(45, 55, 117);
                    item.ForeColor = Color.White;
                }

                lbl.BackColor = Color.Yellow;
                lbl.ForeColor = Color.Black;
              
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
