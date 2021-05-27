using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_BOTTOM_COCKPIT : Form
    {
        public SMT_SCADA_BOTTOM_COCKPIT()
        {
            InitializeComponent();
        }

        List<UC.UC_BOTTOM_SCADA> ucList =new List<UC.UC_BOTTOM_SCADA>();
        int cCount = 0;
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
            tmrTime.Stop();
        }

        private void InitUC()
        {
            try
            {
                string[] B1_Title = new string[4] { "Rubber", "Phylon", "Outsole", "Insole" };
                for (int i = 0; i < tblB1.ColumnCount; i++)
                {
                    UC.UC_BOTTOM_SCADA ucBottom = new UC.UC_BOTTOM_SCADA();
                    tblB1.Controls.Add(ucBottom, i, 0);
                    ucBottom.Dock = DockStyle.Fill;
                    ucBottom.Name = string.Concat("UC_B1_", i);
                    ucList.Add(ucBottom);
                    //Doing Stb
                    ucBottom.InitTable();
                    ucBottom.SetTitle(B1_Title[i]);
                    ucBottom.OnButtonclick += onClick;

                }
                string[] B2_Title = new string[4] { "IP Compound", "IP-A", "IP-B", "PU" };
                for (int i = 0; i < tblB2.ColumnCount; i++)
                {
                    UC.UC_BOTTOM_SCADA ucBottom = new UC.UC_BOTTOM_SCADA();
                    tblB2.Controls.Add(ucBottom, i, 0);
                    ucBottom.Dock = DockStyle.Fill;
                    ucBottom.Name = string.Concat("UC_B2_", i);
                    ucList.Add(ucBottom);
                    //Đăng ký sự kiện trao quyền
                    //Doing Stb
                    ucBottom.InitTable();
                    ucBottom.SetTitle(B2_Title[i]);
                    ucBottom.OnButtonclick += onClick;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        void onClick(string btnCode)
        {
            MessageBox.Show(btnCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //foreach (var item in ucList)
            //{
            //    item.SetColorStatus();
            //}
           
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            InitUC();
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            cCount++;
            if (cCount >= 30)
            {
                try
                {
                    splashScreenManager1.ShowWaitForm();

                    cCount = 0;
                    foreach (var item in ucList)
                    {
                        item.SetColorStatus();
                    }
                    splashScreenManager1.CloseWaitForm();
                }
                catch (Exception ex) //Nếu có lỗi ...
                {
                    splashScreenManager1.CloseWaitForm();
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                cCount = 30;
                tmrTime.Start();
            }
            else
                tmrTime.Stop();
        }
    }
}
