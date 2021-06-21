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
    public partial class SMT_SCADA_B2_PU_MAT_TEMPER : Form
    {
        public SMT_SCADA_B2_PU_MAT_TEMPER()
        {
            InitializeComponent();
            InitLayout();
        }
        List<Label> lstLabel = new List<Label>();
        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void InitLayout()
        {
            try
            {

                lstLabel.Add(lbl_001POLY1MAT);
                lstLabel.Add(lbl_001POLY1OIL);
                lstLabel.Add(lbl_001POLY1HOSE);

                lstLabel.Add(lbl_002POLY1MAT);
                lstLabel.Add(lbl_002POLY1OIL);
                lstLabel.Add(lbl_002POLY1HOSE);

                lstLabel.Add(lbl_003POLY1MAT);
                lstLabel.Add(lbl_003POLY1OIL);
                lstLabel.Add(lbl_003POLY1HOSE);


                lstLabel.Add(lbl_001POLY2MAT);
                lstLabel.Add(lbl_001POLY2OIL);
                lstLabel.Add(lbl_001POLY2HOSE);

                lstLabel.Add(lbl_002POLY2MAT);
                lstLabel.Add(lbl_002POLY2OIL);
                lstLabel.Add(lbl_002POLY2HOSE);

                lstLabel.Add(lbl_003POLY2MAT);
                lstLabel.Add(lbl_003POLY2OIL);
                lstLabel.Add(lbl_003POLY2HOSE);

                lstLabel.Add(lbl_001ISO1MAT);
                lstLabel.Add(lbl_001ISO1OIL);
                lstLabel.Add(lbl_001ISO1HOSE);

                lstLabel.Add(lbl_002ISO1MAT);
                lstLabel.Add(lbl_002ISO1OIL);
                lstLabel.Add(lbl_002ISO1HOSE);

                lstLabel.Add(lbl_003ISO1MAT);
                lstLabel.Add(lbl_003ISO1OIL);
                lstLabel.Add(lbl_003ISO1HOSE);

                //==============================
                lstLabel.Add(lbl_004POLY1_1MAT);
                lstLabel.Add(lbl_004POLY1_1OIL);
                lstLabel.Add(lbl_004POLY1_1HOSE);

                lstLabel.Add(lbl_005POLY1_1MAT);
                lstLabel.Add(lbl_005POLY1_1OIL);
                lstLabel.Add(lbl_005POLY1_1HOSE);

                lstLabel.Add(lbl_006POLY1_1MAT);
                lstLabel.Add(lbl_006POLY1_1OIL);
                lstLabel.Add(lbl_006POLY1_1HOSE);

                lstLabel.Add(lbl_004POLY1_2MAT);
                lstLabel.Add(lbl_004POLY1_2OIL);
                lstLabel.Add(lbl_004POLY1_2HOSE);

                lstLabel.Add(lbl_005POLY1_2MAT);
                lstLabel.Add(lbl_005POLY1_2OIL);
                lstLabel.Add(lbl_005POLY1_2HOSE);

                lstLabel.Add(lbl_006POLY1_2MAT);
                lstLabel.Add(lbl_006POLY1_2OIL);
                lstLabel.Add(lbl_006POLY1_2HOSE);

                lstLabel.Add(lbl_004POLY2_1MAT);
                lstLabel.Add(lbl_004POLY2_1OIL);
                lstLabel.Add(lbl_004POLY2_1HOSE);

                lstLabel.Add(lbl_005POLY2_1MAT);
                lstLabel.Add(lbl_005POLY2_1OIL);
                lstLabel.Add(lbl_005POLY2_1HOSE);

                lstLabel.Add(lbl_006POLY2_1MAT);
                lstLabel.Add(lbl_006POLY2_1OIL);
                lstLabel.Add(lbl_006POLY2_1HOSE);

                lstLabel.Add(lbl_004POLY2_2MAT);
                lstLabel.Add(lbl_004POLY2_2OIL);
                lstLabel.Add(lbl_004POLY2_2HOSE);

                lstLabel.Add(lbl_005POLY2_2MAT);
                lstLabel.Add(lbl_005POLY2_2OIL);
                lstLabel.Add(lbl_005POLY2_2HOSE);

                lstLabel.Add(lbl_006POLY2_2MAT);
                lstLabel.Add(lbl_006POLY2_2OIL);
                lstLabel.Add(lbl_006POLY2_2HOSE);

                lstLabel.Add(lbl_004ISO1_1MAT);
                lstLabel.Add(lbl_004ISO1_1OIL);
                lstLabel.Add(lbl_004ISO1_1HOSE);

                lstLabel.Add(lbl_005ISO1_1MAT);
                lstLabel.Add(lbl_005ISO1_1OIL);
                lstLabel.Add(lbl_005ISO1_1HOSE);

                lstLabel.Add(lbl_006ISO1_1MAT);
                lstLabel.Add(lbl_006ISO1_1OIL);
                lstLabel.Add(lbl_006ISO1_1HOSE);

                lstLabel.Add(lbl_004ISO1_2MAT);
                lstLabel.Add(lbl_004ISO1_2OIL);
                lstLabel.Add(lbl_004ISO1_2HOSE);

                lstLabel.Add(lbl_005ISO1_2MAT);
                lstLabel.Add(lbl_005ISO1_2OIL);
                lstLabel.Add(lbl_005ISO1_2HOSE);

                lstLabel.Add(lbl_006ISO1_2MAT);
                lstLabel.Add(lbl_006ISO1_2OIL);
                lstLabel.Add(lbl_006ISO1_2HOSE);

                foreach (var item in lstLabel)
                {
                    item.Tag = item.Name.ToString().Replace("lbl_", "");
                    item.Click += Item_Click;
                }

            }
            catch 
            {

                
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in lstLabel)
                {
                    item.BackColor = Color.FromArgb(45, 55, 117);
                    item.ForeColor = Color.White;
                }

                Label lbl = ((Label)sender);
                lbl.BackColor = Color.Yellow;
                lbl.ForeColor = Color.Black;
              //  MessageBox.Show(lbl.Tag.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void BindingData()
        {

        }
         

    }

   
}
