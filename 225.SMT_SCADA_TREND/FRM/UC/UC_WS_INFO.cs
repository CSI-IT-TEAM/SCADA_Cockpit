using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UC_WS_INFO : UserControl
    {
        public UC_WS_INFO()
        {
            InitializeComponent();
        }
        #region Variable
        Random r = new Random();
        public delegate void OnbtnClickhandle(DevExpress.XtraEditors.SimpleButton button,string LINE_CD);
        public OnbtnClickhandle OnButtonClick;

        public delegate void OnLabelChangeColorhandle();
        public OnLabelChangeColorhandle OnLabelPlantClick;
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (OnButtonClick != null)
                OnButtonClick(((DevExpress.XtraEditors.SimpleButton)sender), lblPlantName.Text);
        }
        public void BindingData(string LINE_CD, string LINE_NM, string PLANT_QTY,string WIP_QTY,string Rate,string LT)
        {
            try
            {
                //int  LT = 0 ;
                lblProgress.Text = "";
                lblPlantQty.Text = "0 Prs";
                lblWip_Qty.Text = "0 Prs";
                lblRateInv_Plan.Text = "0%";
                lblPlantName.Text = LINE_NM;
                lblPlantQty.Text = String.Format("{0:n0}", Convert.ToInt32(PLANT_QTY)) + " Prs";
                lblWip_Qty.Text = String.Format("{0:n0}", Convert.ToInt32(WIP_QTY)) + " Prs";
                double r = Convert.ToDouble(Rate);
                if (r > 100)
                {
                    lblRateInv_Plan.Text = "100%⇗";
                    lblRateInv_Plan.BackColor = Color.Green;
                    lblRateInv_Plan.ForeColor = Color.White;
                }
                else if (r >= 80)
                {
                    lblRateInv_Plan.BackColor = Color.Yellow;
                    lblRateInv_Plan.ForeColor = Color.Black;
                    lblRateInv_Plan.Text = Rate + "%";
                }
                else
                {
                    lblRateInv_Plan.BackColor = Color.Red;
                    lblRateInv_Plan.ForeColor = Color.White;
                    lblRateInv_Plan.Text = Rate + "%";
                }
               // progressBarControl1.EditValue = Convert.ToInt32(LT.ToString());
                for (int i = 0; i < (Convert.ToInt32(LT.ToString()) > 5 ? 10 : Convert.ToInt32(LT.ToString())) * 2; i++)
                {
                    lblProgress.Text += "▓";
                }
                lblLT.Text = "LeadTime: " + LT.ToString();

                switch (Convert.ToInt32(LT.ToString()))
                {
                    case 1:
                        lblProgress.ForeColor = Color.Green;
                        break;
                    case 2:
                        lblProgress.ForeColor = Color.YellowGreen;
                        break;
                    case 3:
                        lblProgress.ForeColor = Color.Gold;
                        break;
                    case 4:
                        lblProgress.ForeColor = Color.OrangeRed;
                        break;
                    case 5:
                        lblProgress.ForeColor = Color.Red;
                        break;
                }
              //  progressBarControl1.Properties.StartColor = progressBarControl1.Properties.EndColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
            }
            catch(Exception ex) { }
        }
        public void ChangeColor(bool isDefault)
        {
            if (isDefault)
            { lblPlantName.BackColor = Color.SteelBlue; lblPlantName.ForeColor = Color.White; }
            else
            { lblPlantName.BackColor = Color.Yellow; lblPlantName.ForeColor = Color.Black; }
        }

        private void lblPlantName_Click(object sender, EventArgs e)
        {
            if (OnLabelPlantClick != null)
                OnLabelPlantClick();
                ((System.Windows.Forms.Label)sender).BackColor = Color.Yellow; ((System.Windows.Forms.Label)sender).ForeColor = Color.Black;
            
        }
    }
}
