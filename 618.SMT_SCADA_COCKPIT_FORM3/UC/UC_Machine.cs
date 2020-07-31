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
    public partial class UC_Machine : UserControl
    {
        public UC_Machine()
        {
            InitializeComponent();
        }


        //private readonly Image imgNosew = Image.FromFile(Application.StartupPath + @"\img\Nosew.png");
        //private readonly Image imgFss = Image.FromFile(Application.StartupPath + @"\img\Stockfit.png");
        //private readonly Image imgAss = Image.FromFile(Application.StartupPath + @"\img\Ass.png");

        public string _Area, _Name, _Code;

        private void UC_Machine_Load(object sender, EventArgs e)
        {
            picMachine.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\" + _Area + ".png");
            //if (_Area == Var.Area.Nosew) 
            //    picMachine.BackgroundImage = imgNosew;
            //else if (_Area == Var.Area.Stockfit)
            //    picMachine.BackgroundImage = imgFss;
            //else
            //    picMachine.BackgroundImage = imgAss;

            cmdMachine.Text = _Name;
          //  Console.WriteLine(this.Width.ToString() + " " + this.Height.ToString());
        }



        public delegate void Button_Click(string Name, string Area);
        public Button_Click OnButton_Click = null;

        private void btn_Click(object sender, EventArgs e)
        {
            if (OnButton_Click != null)
                OnButton_Click(_Code, _Area);
        }

        
    }
}
