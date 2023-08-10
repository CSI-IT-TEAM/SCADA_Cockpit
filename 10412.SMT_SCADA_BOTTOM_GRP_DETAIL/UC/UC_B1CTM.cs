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
    public partial class UC_B1CTM : UserControl
    {
        public UC_B1CTM()
        {
            InitializeComponent();
        }
        public delegate void UCClickHandle(UC.UC_B1CTM uc);
        public UCClickHandle OnUcClick = null;

        public void BindingHeaderData(string MachineNo)
        {
            lblMC.Text = MachineNo;
        } 

        public void SetBackColor(Color color)
        {
            a1Panel1.BackColor = color;
        }

        public void SetBorder(int BorderWidth,Color color)
        {
            a1Panel1.BorderWidth = BorderWidth;
            a1Panel1.BorderColor = color;
        }

        public void BindingData(DataRow dr)
        {
           
            lblHeat.Text = string.Concat(dr["HEAT_VL"].ToString(), "°C");
            if (dr["HEAT_VL"].ToString() == "0")
            {
                lblHeat.BackColor = Color.Silver;
            }
            else
            {
                lblHeat.BackColor = Color.FromName(dr["HEAT_COLOR"].ToString());
            }
            



            lblCool.Text = string.Concat(dr["COOL_VL"].ToString(), "°C");
            lblCool.BackColor = Color.FromName(dr["COOL_COLOR"].ToString());

            if (dr["COOL_VL"].ToString() == "0")
            {
                lblCool.BackColor = Color.Silver;
            }
            else
            {
                lblCool.BackColor = Color.FromName(dr["COOL_COLOR"].ToString());
            }
        }
        private void a1Panel1_Click(object sender, EventArgs e)
        {
            if (OnUcClick != null)
            {
                OnUcClick(this);
            }
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (OnUcClick != null)
            {
                OnUcClick(this);
            }
        }
    }
}
