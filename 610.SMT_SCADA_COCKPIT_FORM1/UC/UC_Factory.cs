using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace FORM.UC
{
    public partial class UC_Factory : UserControl
    {
        public UC_Factory()
        {
            InitializeComponent();
            setColor("GREEN");
        }


        //private readonly Image imgNosew = Image.FromFile(Application.StartupPath + @"\img\Nosew.png");
        //private readonly Image imgFss = Image.FromFile(Application.StartupPath + @"\img\Stockfit.png");
        //private readonly Image imgAss = Image.FromFile(Application.StartupPath + @"\img\Ass.png");

        public string _Area, _Name, _Code, _Color;

        private void UC_Machine_Load(object sender, EventArgs e)
        {
            
        }


        public void setColor(string strColor)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CAPTION");
                dt.Columns.Add("VALUE_DATA");

                dt.Columns["VALUE_DATA"].DataType = typeof(int);


                string[] color = { "YELLOW", "RED", "GREEN" };
                for (int i = 0; i < color.Length; i++)
                {
                    DataRow row = dt.NewRow();
                    row["CAPTION"] = " ";

                    if (color[i].ToUpper() == strColor.ToUpper())
                        row["VALUE_DATA"] = 1;
                    else
                        row["VALUE_DATA"] = 0;

                    dt.Rows.Add(row);
                }

                chartControl4.DataSource = dt;
                chartControl4.Series[0].ArgumentDataMember = "CAPTION";
                chartControl4.Series[0].ValueDataMembers.AddRange(new string[] { "VALUE_DATA" });

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
               
            }
            
            // arcScaleRange.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:" + strColor + ";Style2:]");
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
