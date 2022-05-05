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
    public partial class UC_BOTTOM_SCADA_OTH : UserControl
    {
        public UC_BOTTOM_SCADA_OTH()
        {
            InitializeComponent();
        }
        public delegate void ButtonClickHandler(string btnCode);
        public ButtonClickHandler OnButtonclick = null;
        Color[] ColorRange = new Color[3] { Color.Red, Color.Green, Color.Yellow };
        Color[] ForeColorRange = new Color[3] { Color.White, Color.White, Color.Black };
        Random r = new Random();
        List<Button> btnList = new List<Button>();
        int GapY = 35, LocY = 3, buttonHeight = 30;
        bool isMalClick = false;
        public void Init_Table()
        {
            try
            {

                string[] RubbMachineList = new string[4] { "Banbury", "1st Roll", "2nd Roll", "Calendar" };
                string[] EvaMachineList = new string[5] { "Kneader", "Roll", "Extruder", "Palletizing", "Calendar" };
                //Button Area Rubb (Tạo 1 lần)
                Button btn1 = new Button();
                btn1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn1.FlatAppearance.BorderSize = 0;
                btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn1.BackColor = Color.Black;
                btn1.ForeColor = Color.White;
                btn1.Location = new System.Drawing.Point(5, 3);
                btn1.Name = string.Concat("btnRUBAREA_", this.Name);
                //Resize Button Rubber
                btn1.TabIndex = 0;
                btn1.Text = "Rubber";
                btn1.UseVisualStyleBackColor = true;
                xtraScrollableControl1.Controls.Add(btn1);
                for (int i = 0; i < RubbMachineList.Length; i++)
                {
                    //Button Machine Rubb
                    Button btn2 = new Button();
                    btn2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn2.FlatAppearance.BorderSize = 0;
                    btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn2.BackColor = Color.DodgerBlue;
                    btn2.Location = new System.Drawing.Point(80, LocY);
                    btn2.Name = string.Concat("btnRUBBMC_", this.Name, "_btn_", i);
                    btn2.Size = new System.Drawing.Size(144, buttonHeight);
                    btn2.TabIndex = 0;
                    btn2.Text = RubbMachineList[i].ToString();
                    btn2.UseVisualStyleBackColor = true;
                    xtraScrollableControl1.Controls.Add(btn2);

                    //Button Temper
                    Button btn3 = new Button();
                    btn3.FlatAppearance.BorderSize = 0;
                    btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn3.BackColor = Color.Silver;
                    btn3.Location = new System.Drawing.Point(230, LocY);
                    btn3.Name = string.Concat("btnRUBB_TEMP_", this.Name, "_btn_", i);
                    btn3.Size = new System.Drawing.Size(215, buttonHeight);
                    btn3.TabIndex = 0;
                    btn3.Text = string.Empty;
                    btn3.UseVisualStyleBackColor = true;
                    btn3.Click += Btn2_Click;
                    xtraScrollableControl1.Controls.Add(btn3);
                    btnList.Add(btn3);
                    btn1.Size = new System.Drawing.Size(70, LocY + buttonHeight - 3); //(37 + GapY) * RubbMachineList.Length
                    LocY += GapY;

                }

                //Button Area eva (Tạo 1 lần)
                Button btn4 = new Button();
                btn4.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn4.FlatAppearance.BorderSize = 0;
                btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                btn4.BackColor = Color.Black;
                btn4.ForeColor = Color.White;
                btn4.Location = new System.Drawing.Point(5, LocY);
                btn4.Name = string.Concat("btnEVAAREA_", this.Name);
                //Resize Button Rubber
                btn4.TabIndex = 0;
                btn4.Text = "EVA";
                btn4.UseVisualStyleBackColor = true;
                xtraScrollableControl1.Controls.Add(btn4);
               
                for (int i = 0; i < EvaMachineList.Length; i++)
                {
                    //Button Machine Rubb
                    Button btn2 = new Button();
                    btn2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    btn2.FlatAppearance.BorderSize = 0;
                    btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn2.BackColor = Color.Coral;
                    btn2.Location = new System.Drawing.Point(80, LocY);
                    btn2.Name = string.Concat("btnEVAMC_", this.Name, "_btn_", i);
                    btn2.Size = new System.Drawing.Size(144, buttonHeight);
                    btn2.TabIndex = 0;
                    btn2.Text = EvaMachineList[i].ToString();
                    btn2.UseVisualStyleBackColor = true;
                    xtraScrollableControl1.Controls.Add(btn2);

                    //Button Temper
                    Button btn3 = new Button();
                    btn3.FlatAppearance.BorderSize = 0;
                    btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btn3.BackColor = Color.Silver;
                    btn3.Location = new System.Drawing.Point(230, LocY);
                    btn3.Name = string.Concat("btnEVA_TEMP_", this.Name, "_btn_", i);
                    btn3.Size = new System.Drawing.Size(215, buttonHeight);
                    btn3.TabIndex = 0;
                    btn3.Text = string.Empty;
                    btn3.UseVisualStyleBackColor = true;
                    btn3.Click += Btn2_Click;
                    btnList.Add(btn3);
                    xtraScrollableControl1.Controls.Add(btn3);
                
                    btn4.Size = new System.Drawing.Size(70, LocY + buttonHeight - 3 - btn1.Height - 5); //(37 + GapY) * RubbMachineList.Length
                    LocY += GapY;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //private void InitTable()
        //{
        //    for (int i = 0; i < r.Next(10, 100); i++)
        //    {

        //        //Button Machine/Zone
        //        Button btn1 = new Button();
        //        btn1.BackColor = Color.Silver;
        //        btn1.FlatAppearance.BorderSize = 0;
        //        btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //        btn1.Location = new System.Drawing.Point(24, LocY);
        //        btn1.Name = string.Concat("btn1_", this.Name, "_btn_", i);
        //        btn1.Size = new System.Drawing.Size(206, 40);
        //        btn1.TabIndex = 0;
        //        btn1.Text = string.Concat("Machine_", this.Name, "_", i);
        //        btn1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //        btn1.UseVisualStyleBackColor = true;
        //        xtraScrollableControl1.Controls.Add(btn1);

        //        //Button Temperature Status
        //        Button btn2 = new Button();
        //        btn2.BackColor = Color.Silver;
        //        btn2.FlatAppearance.BorderSize = 0;
        //        btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //        btn2.Location = new System.Drawing.Point(234, LocY);
        //        btn2.Name = string.Concat("btn2_", this.Name, "_btn_", i);
        //        btn2.Size = new System.Drawing.Size(203, 40);
        //        btn2.TabIndex = 0;
        //        btn2.Text = string.Empty;// string.Concat("btn2_", this.Name, (i + 1));
        //        btn2.UseVisualStyleBackColor = true;
        //        btn2.Click += Btn2_Click;
        //        xtraScrollableControl1.Controls.Add(btn2);
        //        btnList.Add(btn2);
        //        LocY += GapY;

        //    }
        //}

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
        public void SetColorTitle()
        {
            int rand = r.Next(0, 3);
            lblTitle.BackColor = ColorRange[rand];
            lblTitle.ForeColor = ForeColorRange[rand];
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
