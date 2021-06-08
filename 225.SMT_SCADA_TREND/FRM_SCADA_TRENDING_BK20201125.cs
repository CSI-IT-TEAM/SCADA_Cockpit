using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM
{
    public partial class FRM_SCADA_TRENDING_BK20201125 : Form
    {
        public FRM_SCADA_TRENDING_BK20201125()
        {
            InitializeComponent();
        }

        #region FormChild
        FRM.FRM_SCADA_TREND_ALL FRM_TREND_ALL = new FRM.FRM_SCADA_TREND_ALL();
        FRM.FRM_SCADA_TREND_CRL FRM_TREND_CRL = new FRM.FRM_SCADA_TREND_CRL();
        #endregion
        #region Variable       
        string _LINE;
        string _MACHINE;
        bool flag = false;
        int _cnt = 0;
        DatabaseSCADA db = new DatabaseSCADA();
        DataTable dtRealChart = new DataTable();
        #endregion
        private void InitForm(List<Form> lF)
        {
            for (int i = 0; i < lF.Count; i++)
            {
                lF[i].FormBorderStyle = FormBorderStyle.None;
                lF[i].TopLevel = false;
                
                lF[i].Dock = DockStyle.Fill;
                pnMain.Controls.Add(lF[i]);
            }
        }
        private void FRM_SCADA_TRENDING_BK20201125_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            CXMLConfig conFig = new CXMLConfig("Config.xml");
            _LINE = conFig.XmlReadValue("LINECD");

            InitForm(new List<Form> { FRM_TREND_ALL, FRM_TREND_CRL });    //Gán 2 form vào panel Main
           // load_combo(); //Binding Combobox
            tmrDate.Interval = 1000;
            tmrDate.Enabled = true;
        }
        private void load_combo()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDATE = db.SEL_SCADA_SET_COMBO("DATE", _LINE);
                dtp_To.EditValue = dtDATE.Rows[0]["TODAY"];
                dtp_From.EditValue = dtDATE.Rows[0]["PREV_DAY"];

                DataTable dt = db.SEL_SCADA_SET_COMBO("LINE", _LINE);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cboLine.DataSource = dt;
                    cboLine.DisplayMember = "NAME";
                    cboLine.ValueMember = "CODE";
                }
                        
                DataTable dt1 = db.SEL_SCADA_SET_COMBO2("MACHINE", _LINE, "001", "FGA", "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    cboMachine.DataSource = dt1;
                    cboMachine.DisplayMember = "NAME";
                    cboMachine.ValueMember = "CODE";
                }
                    //_MACHINE = "Aging Conveyor";
                    //cboMachine.SelectedIndex = 0;
                    //cboMachine.SelectedValue = _MACHINE;
                
            }
            catch
            {
                cboMachine.SelectedIndex = 0;
            }
            finally { this.Cursor = Cursors.Default; }
        }
        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboArea.DataSource == null || cboArea.SelectedValue.ToString() == "System.Data.DataRowView") return;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = db.SEL_SCADA_SET_COMBO2("MACHINE", _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), "");
                //if (dt != null && dt.Rows.Count > 0)
                //{
                cboMachine.DataSource = dt;
                cboMachine.DisplayMember = "NAME";
                cboMachine.ValueMember = "CODE";
                //}
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = db.SEL_SCADA_SET_COMBO("AREA", _LINE);
                //if (dt != null && dt.Rows.Count > 0)
                //{
                cboArea.DataSource = dt;
                cboArea.DisplayMember = "NAME";
                cboArea.ValueMember = "CODE";
                //}
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMachine.DataSource == null || cboMachine.SelectedValue.ToString() == "System.Data.DataRowView") return;
                this.Cursor = Cursors.WaitCursor;
                DataTable dt = db.SEL_SCADA_SET_COMBO2("ID", _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString());
                
                cboID.DisplayMember = "NAME";
                cboID.ValueMember = "CODE";
                cboID.DataSource = dt;
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void cboID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboID.SelectedValue.ToString().Equals("0"))
            {
                pnMain.Controls[0].Show(); //trend all
                pnMain.Controls[1].Hide(); //trend controller
            }
            else
            {
                pnMain.Controls[1].Show(); //trend all
                pnMain.Controls[0].Hide(); //trend controller
            }
            btnSearch_Click(null, null);
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                if (cboID.SelectedValue.ToString().Equals("0"))
                {
                    FRM_TREND_ALL.GetData2BindingChart(dtp_From.DateTime.ToString("yyyyMMdd"), dtp_To.DateTime.ToString("yyyyMMdd"), _LINE,
                                             cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString(),
                                             cboID.SelectedValue.ToString());
                }
                else
                {
                    FRM_TREND_CRL.GetData(dtp_From.DateTime.ToString("yyyyMMdd"), dtp_To.DateTime.ToString("yyyyMMdd"), _LINE,
                                          cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString(),
                                          cboID.SelectedValue.ToString());
                    FRM_TREND_CRL.GetDataBarChart(dtp_From.DateTime.ToString("yyyyMMdd"), dtp_To.DateTime.ToString("yyyyMMdd"), _LINE,
                                          cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString(),
                                          cboID.SelectedValue.ToString());
                }
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();
            }
            catch
            {
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();
            }
        }
        private void cboMachine_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    //if (!cboMachine.SelectedValue.ToString().Equals("System.Data.DataRowView"))
            //    //{
            //    DataTable dt = db.SEL_SCADA_SET_COMBO2("ID", _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString());
            //    //if (dt != null && dt.Rows.Count > 0)
            //    //{
            //    cboID.DataSource = dt;
            //    cboID.DisplayMember = "NAME";
            //    cboID.ValueMember = "CODE";
            //    //}
            //    //}
            //}
            //catch { }
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            ComVar.Var.callForm = "minimized";
        } 
        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            if (_cnt < 2)
                _cnt++;
            if (_cnt == 2)
            {
                _cnt++;
                if (!flag)
                    load_combo();
            }
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Properties.Resources.btnSearch1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Properties.Resources.btnSearch;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
