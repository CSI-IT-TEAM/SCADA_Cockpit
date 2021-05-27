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
    public partial class UC_BOTTOM_SCADA_3COL : UserControl
    {
        public UC_BOTTOM_SCADA_3COL()
        {
            InitializeComponent();
        }
        public delegate void ButtonClickHandler(string btnCode);
        public ButtonClickHandler OnButtonclick = null;
        Color[] ColorRange = new Color[3] { Color.Red, Color.Green, Color.Yellow };
        Random r = new Random();
        List<Button> btnList = new List<Button>();
        int GapY = 43, LocY = 3;
        bool isMalClick = false;
        public void Init_Table()
        {
            try
            {
                string[] MachineList = new string[7] { "Auto 1", "Auto 2", "Auto 3", "Manual 1", "Manual 2", "Manual 3", "Manual 4" };
                for (int i = 0; i < 7; i++)
                {

                    //Button Zone
                    Button btn1 = new Button();
                    btn1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn1.FlatAppearance.BorderSize = 0;
                    btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    if (MachineList[i].Contains("Auto")) //Máy Auto thì màu khác cho dễ phân biệt
                        btn1.BackColor = Color.DodgerBlue; 
                    else
                        btn1.BackColor = Color.Coral;
                    btn1.Location = new System.Drawing.Point(5, LocY);
                    btn1.Name = string.Concat("btnMC_", this.Name, "_btn_", i);
                    btn1.Size = new System.Drawing.Size(108, 37);
                    btn1.TabIndex = 0;
                    btn1.Text = MachineList[i].ToString();
                    btn1.UseVisualStyleBackColor = true;
                    xtraScrollableControl1.Controls.Add(btn1);

                    //Button Material
                    Button btn2 = new Button();
                    btn2.FlatAppearance.BorderSize = 0;
                    btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn2.BackColor = Color.Silver;
                    btn2.Location = new System.Drawing.Point(119, LocY);
                    btn2.Name = string.Concat("btnMAT_", this.Name, "_btn_", i);
                    btn2.Size = new System.Drawing.Size(100, 37);
                    btn2.TabIndex = 0;
                    btn2.Text = string.Empty;
                    btn2.UseVisualStyleBackColor = true;
                    btn2.Click += Btn2_Click;
                    btnList.Add(btn2);
                    xtraScrollableControl1.Controls.Add(btn2);

                    //Button Oil
                    Button btn3 = new Button();
                    btn3.FlatAppearance.BorderSize = 0;
                    btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn3.BackColor = Color.Silver;
                    btn3.Location = new System.Drawing.Point(224, LocY);
                    btn3.Name = string.Concat("btnOIL_", this.Name, "_btn_", i);
                    btn3.Size = new System.Drawing.Size(100, 37);
                    btn3.TabIndex = 0;
                    btn3.Text = string.Empty;
                    btn3.UseVisualStyleBackColor = true;
                    btn3.Click += Btn2_Click;
                    btnList.Add(btn3);
                    xtraScrollableControl1.Controls.Add(btn3);

                    //Button Hose
                    Button btn4 = new Button();
                    btn4.FlatAppearance.BorderSize = 0;
                    btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn4.BackColor = Color.Silver;
                    btn4.Location = new System.Drawing.Point(330, LocY);
                    btn4.Name = string.Concat("btnHOSE_", this.Name, "_btn_", i);
                    btn4.Size = new System.Drawing.Size(100, 37);
                    btn4.TabIndex = 0;
                    btn4.Text = string.Empty;
                    btn4.UseVisualStyleBackColor = true;
                    btn4.Click += Btn2_Click;
                    btnList.Add(btn4);
                    xtraScrollableControl1.Controls.Add(btn4);

                    LocY += GapY;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InitTable()
        {
            for (int i = 0; i < r.Next(10, 100); i++)
            {

                //Button Machine/Zone
                Button btn1 = new Button();
                btn1.BackColor = Color.Silver;
                btn1.FlatAppearance.BorderSize = 0;
                btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn1.Location = new System.Drawing.Point(24, LocY);
                btn1.Name = string.Concat("btn1_", this.Name, "_btn_", i);
                btn1.Size = new System.Drawing.Size(206, 40);
                btn1.TabIndex = 0;
                btn1.Text = string.Concat("Machine_", this.Name, "_", i);
                btn1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn1.UseVisualStyleBackColor = true;
                xtraScrollableControl1.Controls.Add(btn1);

                //Button Temperature Status
                Button btn2 = new Button();
                btn2.BackColor = Color.Silver;
                btn2.FlatAppearance.BorderSize = 0;
                btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn2.Location = new System.Drawing.Point(234, LocY);
                btn2.Name = string.Concat("btn2_", this.Name, "_btn_", i);
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
                //item.BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), 0);
                item.BackColor = ColorRange[r.Next(0, 3)];
            }
        }

        public void SetTitle(string Title)
        {
            lblTitle.Text = Title;
        }

        private void btnMal_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            SetColorStatus();
        }
    }
}
