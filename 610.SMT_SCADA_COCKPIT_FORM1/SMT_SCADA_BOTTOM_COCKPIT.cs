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

        List<UC.UC_BOTTOM_SCADA> ucList = new List<UC.UC_BOTTOM_SCADA>();
        List<UC.UC_BOTTOM_SCADA_4COL> uc4ColumnsList = new List<UC.UC_BOTTOM_SCADA_4COL>();
        List<UC.UC_BOTTOM_SCADA_3COL> uc3ColumnsList = new List<UC.UC_BOTTOM_SCADA_3COL>();
        List<UC.UC_BOTTOM_SCADA_2COL> uc2ColumnsList = new List<UC.UC_BOTTOM_SCADA_2COL>();
        List<UC.UC_BOTTOM_SCADA_OTH> ucOTHList = new List<UC.UC_BOTTOM_SCADA_OTH>();
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
                string[] B1_Code = new string[4] { "RUB", "PH", "OS", "IN" };
                for (int i = 0; i < tblB1.ColumnCount; i++)
                {
                    UC.UC_BOTTOM_SCADA_OTH ucBottomOTH = new UC.UC_BOTTOM_SCADA_OTH();
                    UC.UC_BOTTOM_SCADA_2COL ucBottom2Cols = new UC.UC_BOTTOM_SCADA_2COL();
                    UC.UC_BOTTOM_SCADA ucBottom = new UC.UC_BOTTOM_SCADA();
                    switch (B1_Code[i])
                    {
                        case "RUB":
                            tblB1.Controls.Add(ucBottomOTH, i, 0);
                            ucBottomOTH.Dock = DockStyle.Fill;
                            ucBottomOTH.Name = string.Concat("UC_B1_", i);
                            ucOTHList.Add(ucBottomOTH);
                            //Doing Stb
                            ucBottomOTH.Init_Table();
                            ucBottomOTH.SetTitle(B1_Title[i]);
                            ucBottomOTH.OnButtonclick += onClick;
                            break;
                        case "PH":
                            tblB1.Controls.Add(ucBottom2Cols, i, 0);
                            ucBottom2Cols.Dock = DockStyle.Fill;
                            ucBottom2Cols.Name = string.Concat("UC_B1_", i);
                            uc2ColumnsList.Add(ucBottom2Cols);
                            //Doing Stb
                            ucBottom2Cols.Init_Table(B1_Code[i]);
                            ucBottom2Cols.setColumHeader("Machine", "Heat", "Cool");
                            ucBottom2Cols.SetTitle(B1_Title[i]);
                            ucBottom2Cols.OnButtonclick += onClick;
                            break;
                        case "OS":
                            tblB1.Controls.Add(ucBottom, i, 0);
                            ucBottom.Dock = DockStyle.Fill;
                            ucBottom.Name = string.Concat("UC_B1_", i);
                            ucList.Add(ucBottom);
                            ucBottom.SetTitle(B1_Title[i]);
                            ucBottom.OnButtonclick += onClick;
                            break;
                        case "IN":
                            tblB1.Controls.Add(ucBottom, i, 0);
                            ucBottom.Dock = DockStyle.Fill;
                            ucBottom.Name = string.Concat("UC_B1_", i);
                            ucList.Add(ucBottom);
                            ucBottom.SetTitle(B1_Title[i]);
                            ucBottom.OnButtonclick += onClick;
                            break;
                    }

                }
                string[] B2_Title = new string[4] { "IP Compound", "IP-A", "IP-B", "PU" };
                string[] B2_Code = new string[4] { "COMPOUND", "IP-A", "IP-B", "PU" };
                for (int i = 0; i < tblB2.ColumnCount; i++)
                {
                    UC.UC_BOTTOM_SCADA_4COL ucBottom4Cols = new UC.UC_BOTTOM_SCADA_4COL();
                    UC.UC_BOTTOM_SCADA_3COL ucBottom3Cols = new UC.UC_BOTTOM_SCADA_3COL();
                    UC.UC_BOTTOM_SCADA_2COL ucBottom2Cols = new UC.UC_BOTTOM_SCADA_2COL();
                    UC.UC_BOTTOM_SCADA ucBottom = new UC.UC_BOTTOM_SCADA();
                    //Đăng ký sự kiện trao quyền
                    //Doing Stb
                    switch (B2_Code[i])
                    {
                        case "COMPOUND":
                            ucBottom4Cols.Init_Table();
                            tblB2.Controls.Add(ucBottom4Cols, i, 0);
                            ucBottom4Cols.Dock = DockStyle.Fill;
                            ucBottom4Cols.Name = string.Concat("UC_B2_", i);
                            uc4ColumnsList.Add(ucBottom4Cols);
                            ucBottom4Cols.SetTitle(B2_Title[i]);
                            ucBottom4Cols.OnButtonclick += onClick;
                            break;
                        case "IP-A":
                            ucBottom2Cols.Init_Table(B2_Code[i]);
                            tblB2.Controls.Add(ucBottom2Cols, i, 0);
                            ucBottom2Cols.Dock = DockStyle.Fill;
                            ucBottom2Cols.Name = string.Concat("UC_B2_", i);
                            uc2ColumnsList.Add(ucBottom2Cols);
                            ucBottom2Cols.SetTitle(B2_Title[i]);
                            ucBottom2Cols.setColumHeader("Zone", "Injection", "Stabilization");
                            ucBottom2Cols.OnButtonclick += onClick;
                            break;
                        case "IP-B":
                            tblB2.Controls.Add(ucBottom, i, 0);
                            ucBottom.Dock = DockStyle.Fill;
                            ucBottom.Name = string.Concat("UC_B2_", i);
                            ucList.Add(ucBottom);
                            ucBottom.SetTitle(B2_Title[i]);
                            ucBottom.OnButtonclick += onClick;
                            break;
                        case "PU":
                            ucBottom3Cols.Init_Table();
                            tblB2.Controls.Add(ucBottom3Cols, i, 0);
                            ucBottom3Cols.Dock = DockStyle.Fill;
                            ucBottom3Cols.Name = string.Concat("UC_B2_", i);
                            uc3ColumnsList.Add(ucBottom3Cols);
                            ucBottom3Cols.SetTitle(B2_Title[i]);
                            ucBottom3Cols.OnButtonclick += onClick;
                            break;
                    }

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
                    //=========================================
                    foreach (var item in uc2ColumnsList)
                    {
                        item.SetColorStatus();
                    }
                    foreach (var item in uc3ColumnsList)
                    {
                        item.SetColorStatus();
                    }
                    foreach (var item in uc4ColumnsList)
                    {
                        item.SetColorStatus();
                    }
                    foreach (var item in ucOTHList)
                    {
                        item.SetColorStatus();
                    }
                    //=========================================
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
