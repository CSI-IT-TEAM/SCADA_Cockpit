using DevExpress.XtraCharts;
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
    public partial class FRM_SMT_SCADA_ENERGY : Form
    {
        public FRM_SMT_SCADA_ENERGY()
        {
            InitializeComponent();
            tmr.Stop();
        }
        int cCount = 0;
        Random r = new Random();
        private void btnBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }
        
        private void FRM_SMT_SCADA_ENERGY_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            BindingData();
        }

        private void BindingData()
        {
            try
            {
                DataTable table = new DataTable();
                table.Columns.Add("Plant", typeof(string));
                table.Columns.Add("D_VALUE", typeof(int));
                table.Columns.Add("M_VALUE", typeof(int));
                table.Columns.Add("Y_VALUE", typeof(int));
                for (int i = 0; i < 20; i++)
                {
                    table.Rows.Add(string.Concat("Plant ", (i + 1)), r.Next(50, 200), r.Next(50, 200), r.Next(50, 200));
                }
                chartControl1.DataSource = table;
                chartControl1.Series[0].ArgumentDataMember = "Plant";
                chartControl1.Series[0].ValueDataMembers.AddRange(new string[] { "D_VALUE" });
                chartControl1.Series[1].ArgumentDataMember = "Plant";
                chartControl1.Series[1].ValueDataMembers.AddRange(new string[] { "M_VALUE" });
                chartControl1.Series[2].ArgumentDataMember = "Plant";
                chartControl1.Series[2].ValueDataMembers.AddRange(new string[] { "Y_VALUE" });
            }
            catch 
            {

            }
           



        }

        private void FRM_SMT_SCADA_ENERGY_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 60;
                tmr.Start();
            }
            else
                tmr.Stop();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            cCount++;
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            if (cCount >= 60)
            {
                cCount = 0;
            }
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            BindingData();
        }
    }
}
