using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_POPUP : Form
    {
        public SMT_SCADA_COCKPIT_POPUP()
        {
            InitializeComponent();
        }
        public DataTable _dtData = null;

        private void SetData()
        {
            try
            {
                gridControl1.DataSource = _dtData;

                for (int i = 0; i < gridView1.Columns.Count; i++)
                {

                    gridView1.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView1.Columns[i].OptionsColumn.AllowEdit = false;
                    if (i <= 4)
                    {
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        gridView1.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    }
                    if (i == 4)
                        gridView1.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }           
        }

        #region DB
        private DataSet Data_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(4);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.PM_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "ARG_DATE";
            MyOraDB.Parameter_Name[2] = "OUT_CURSOR";
            MyOraDB.Parameter_Name[3] = "OUT_CURSOR2";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[2] = (int)OracleType.Cursor;
            MyOraDB.Parameter_Type[3] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
        }

        #endregion DB


        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                SetData();
            }
            else
            {
               
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            }    
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SaveDlg = new SaveFileDialog())
            {
                SaveDlg.RestoreDirectory = true;
                SaveDlg.Filter = "Excel Files (*.xlsx)|*.xlsx";
                if (SaveDlg.ShowDialog() == DialogResult.OK)
                {
                    gridView1.ExportToXlsx(SaveDlg.FileName);
                }


            }
        }
    }
}
