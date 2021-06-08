using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGauges.Core.Model;

namespace FORM.UC
{
    public partial class UC_Chart_Donut : UserControl
    {
        public UC_Chart_Donut()
        {
            InitializeComponent();
            setColor("LimeGreen");
        }

        public void setColor(string color)
        {
            try
            {
                ascInv.EnableAnimation = false;
                ascInv.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseIn;
                ascInv.EasingFunction = new BackEase();
                ascInv.MinValue = 0;
                ascInv.Value = 0;

                ascInv.EnableAnimation = true;
                ascInv.EasingMode = DevExpress.XtraGauges.Core.Model.EasingMode.EaseInOut;
                ascInv.EasingFunction = new BackEase();

                ascInv.Value = 2.5F;
                arcScaleRangeBarComponent1.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:" + color + ";Style2:]");


            }
            catch { }
        }
    }
}
