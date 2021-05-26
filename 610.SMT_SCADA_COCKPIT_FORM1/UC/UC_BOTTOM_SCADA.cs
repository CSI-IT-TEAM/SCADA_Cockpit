using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FORM.UC
{
    public partial class UC_BOTTOM_SCADA : UserControl
    {
        public UC_BOTTOM_SCADA()
        {
            InitializeComponent();
        }
        public delegate void ButtonClickHandler(string btnCode);
        public ButtonClickHandler OnButtonclick = null;
        Random r = new Random();
        List<Button> btnList = new List<Button>();
        int GapY = 46, LocY = 3;
        bool isMalClick = false;
        public void InitTable()
        {
            for (int i = 0; i < r.Next(10, 100); i++)
            {

                //Button Machine/Zone
                Button btn1 = new Button();
                btn1.BackColor = Color.Silver;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn1.Location = new System.Drawing.Point(24, LocY);
                btn1.Name = string.Concat("btn1_", this.Name,"_btn_", i );
                btn1.Size = new System.Drawing.Size(206, 40);
                btn1.TabIndex = 0;
                btn1.Text = string.Concat("Machine_", this.Name, "_",i );
                btn1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn1.UseVisualStyleBackColor = true;
                xtraScrollableControl1.Controls.Add(btn1);

                //Button Temperature Status
                Button btn2 = new Button();
                btn2.BackColor = Color.Silver;
                btn2.FlatAppearance.BorderSize = 0;
                btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn2.Location = new System.Drawing.Point(234, LocY);
                btn2.Name = string.Concat("btn2_", this.Name, "_btn_", i );
                btn2.Size = new System.Drawing.Size(203, 40);
                btn2.TabIndex = 0;
                btn2.Text = string.Empty;// string.Concat("btn2_", this.Name, (i + 1));
                btn2.UseVisualStyleBackColor = true;
                btn2.Click += Btn2_Click;
                xtraScrollableControl1.Controls.Add(btn2);
                btnList.Add(btn2);
                LocY += GapY;

            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (OnButtonclick != null)
            {
                Button btn = ((Button)sender);
                OnButtonclick(btn.Name.ToString());
            }
        }

        public void SetColorStatus()
        {
            foreach (var item in btnList)
            {
                item.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
            }
        }

        public void SetTitle(string Title)
        {
            lblTitle.Text = Title;
        }

        private void btnMal_Click(object sender, EventArgs e)
        {
            if (!isMalClick)
                btnMal.Text = "Show All";
            else
                btnMal.Text = "Malfunction";
            isMalClick = !isMalClick;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetColorStatus();
        }
    }
}
