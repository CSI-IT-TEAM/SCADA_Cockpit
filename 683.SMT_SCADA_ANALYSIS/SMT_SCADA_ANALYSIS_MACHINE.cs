using DevExpress.Skins;
using DevExpress.XtraCharts;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Data;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FORM
{
    public partial class SMT_SCADA_ANALYSIS_MACHINE : Form
    {
        public SMT_SCADA_ANALYSIS_MACHINE()
        {
            InitializeComponent();
            lblHeader.Text = _strHeader;
        }
        private readonly string _strHeader = "       Data Analysis Machine";
       // private UC.UC_COMPARE_WEEK uc_compare_week = new UC.UC_COMPARE_WEEK();
        string _strType = "D";
        int _time = 0;
        
        DataTable _dtChart = null;

        #region Procedure( Name is begin with Po_)
        private void LoadForm()
        {
            Po_SetButtonClick(_strType);
            Po_SetHeader(_strType);
            _dtChart = Data_Select(_strType, "2").Tables[0];
            Po_SetChartWhenClickTree();
            
            // Po_SetDefaultCheck();
            // Po_SetDataChart();
            //Po_SetData(_strType);
        }
        private void Po_SetDataChart(DataTable argDt)
        {
            try
            {
                
                chartControl1.DataSource = argDt;
                for(int i =0; i<5; i++)
                {
                    
                    //chartControl1.Series[i].Points[1].Color = Color.Green;
                    chartControl1.Series[i].ArgumentDataMember = "LABEL";
                    chartControl1.Series[i].ValueDataMembers.AddRange(new string[] { "DAY" + (i+1).ToString() });
                    
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

        }

        private void Po_SetHeader(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    lblHeader.Text = _strHeader + " By Day (" + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
                case "W":
                    lblHeader.Text = _strHeader + " By Week (" + DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd") + " ~ " + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
                case "M":
                    lblHeader.Text = _strHeader + " By Month (" + DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd") + " ~ " + DateTime.Now.ToString("yyyy-MM-dd") + ")";
                    break;
                default:
                    lblHeader.Text = _strHeader;
                    break;
            }
        }

        private void Po_SetButtonClick(string arg_type)
        {
            switch (arg_type)
            {
                case "D":
                    cmdDay.Enabled = false;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = true;
                    break;
                case "W":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = false;
                    cmdMonth.Enabled = true;

                    break;
                case "M":
                    cmdDay.Enabled = true;
                    cmdWeek.Enabled = true;
                    cmdMonth.Enabled = false;
                    break;
            }
        }

        private void Po_SetSeries()
        {
           
            foreach (TreeListNode node in tlsLoction.Nodes)
            {
                foreach (TreeListNode node1 in node.RootNode.Nodes)
                {
                    if (!node1.Checked)
                    {
                        foreach (Series series in chartControl1.Series)
                        {
                            if (series.Name == node1.GetValue("ID_NAME").ToString())
                            {
                                series.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        foreach (Series series in chartControl1.Series)
                        {
                            if (series.Name == node1.GetValue("ID_NAME").ToString())
                            {
                                series.Visible = true;
                            }
                        }
                    }
                }
            }

        }

        private void Po_SetTreelist()
        {
            try
            {
                DataTable dt = GetDataTemp();
                tlsLoction.DataSource = dt;
                tlsLoction.KeyFieldName = "ID";
                tlsLoction.ParentFieldName = "PARENTID";

                Skin skin = GridSkins.GetSkin(tlsLoction.LookAndFeel);
                skin.Properties[GridSkins.OptShowTreeLine] = true;

                foreach (TreeListNode node in tlsLoction.Nodes)
                {
                    var dataRow = tlsLoction.GetDataRecordByNode(node);
                    node.Tag = dataRow;
                    string nodeId = node.GetValue("ID").ToString();
                    if (nodeId == "F4")
                        node.Checked = true;
                    else
                        node.Checked = false;
                    node.Expanded = true;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        
                        if (nodeId == "F4" )
                            node1.Checked = true;
                        else
                            node1.Checked = false;
                    }
                }
            }
            catch { }
        }

        private void Po_SetCheckedChildNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
                node.Checked = node.ParentNode.Checked;
        }

        private bool Po_IsAllChecked(TreeListNodes nodes)
        {
            bool value = true;
            foreach (TreeListNode node in nodes)
            {
                if (!node.Checked)
                {
                    value = false;
                    break;
                }
            }
            return value;
        }

        private void Po_SetChartWhenClickTree()
        {
            string lineCd = "";
            foreach (TreeListNode node in tlsLoction.Nodes)
            {
                foreach (TreeListNode node1 in node.RootNode.Nodes)
                {
                    if (!node1.Checked)
                    {
                        lineCd.Replace(node1.GetValue("ID").ToString() + ",", "");
                    }
                    else
                    {
                        lineCd += node1.GetValue("ID").ToString() + ",";
                    }
                }
            }
            lineCd = lineCd.TrimEnd(',');
            Po_SetDataChart(GetDataChart(lineCd));
        }

        private void Po_SetDefaultCheck()
        {
            foreach (TreeListNode node in tlsLoction.Nodes)
            {
                foreach (TreeListNode node1 in node.RootNode.Nodes)
                {
                    string lineCd = node1.GetValue("ID").ToString();
                    if (lineCd == "013" || lineCd == "014" || lineCd == "015" || lineCd == "016" || lineCd == "017")
                    {
                        node1.Checked = true;
                    }
                    else
                    {
                        node1.Checked = false;
                    }
                    //if (!node1.Checked)
                    //{
                    //    lineCd.Replace(node1.GetValue("ID").ToString() + ",", "");
                    //}
                    //else
                    //{
                    //    lineCd += node1.GetValue("ID").ToString() + ",";
                    //}
                }
            }
        }

        #endregion

        #region Function( Name is begin with Fn_)

        #endregion Function

        #region Get Data From Database
        private DataSet Data_Select(string argType, string argDate = "")
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
            MyOraDB.Parameter_Values[1] = argDate;
            MyOraDB.Parameter_Values[2] = "";
            MyOraDB.Parameter_Values[3] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS;
        }

        private DataTable GetDataTemp()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string[] parentId = { "000", "000", "000", "000", "000",
                                 "F1", "F1", 
                                 "F2", "F2", "F2",
                                 "F3", "F3", "F3",
                                 "F4", "F4", "F4", "F4", "F4",
                                 "F5", "F5", "F5", "F5"
                               };

            string[] id = { "F1", "F2", "F3", "F4", "F5",
                                 "FGA", "UPS",
                                 "007", "008", "010",
                                 "011", "012", "099",
                                 "013", "014", "015", "016", "009",
                                 "018_1", "018_2"
                               };
            string[] menuNm = { "Factory 1", "Factory 2", "Factory 3", "Factory 4", "Factory 5",
                                 "Assembly", "Stockfit",
                                 "Lean B", "Lean C", "Lean D",
                                 "Lean E", "Lean F", "Lean N",
                                 "Lean G", "Lean H", "Lean I", "Lean J", "Lean K",
                                 "Lean L2", "Lean L1"
                               };

            

            dt.Columns.Add("PARENTID");
            dt.Columns.Add("ID");
            dt.Columns.Add("MENU_NM");
            for (int i = 0; i < id.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["PARENTID"] = parentId[i];
                row["ID"] = id[i];
                row["MENU_NM"] = menuNm[i];
                dt.Rows.Add(row);
            }

            return dt;
        }


        private DataTable GetDataChart(string argLineCd)
        {
            try
            {

                string[] lineCd = argLineCd.Split(',');
                

                DataTable dtData = new DataTable();
                dtData.Columns.Add("LABEL");
                dtData.Columns.Add("DAY1", typeof(int));
                dtData.Columns.Add("DAY2", typeof(int));
                dtData.Columns.Add("DAY3", typeof(int));
                dtData.Columns.Add("DAY4", typeof(int));
                dtData.Columns.Add("DAY5", typeof(int));

                if (argLineCd =="ALL")
                {
                    string[] selectedColumns = new[] { "LINE_CD" };

                    DataTable dtLine = new DataView(_dtChart).ToTable(true, selectedColumns).Select("1=1").Distinct().CopyToDataTable();

                    foreach (DataRow dr in dtLine.Rows)
                    {
                        DataRow[] drRow = _dtChart.Select($"line_cd = '{dr["LINE_CD"]}'");
                        if (drRow.Length > 0)
                        {
                            DataRow row = dtData.NewRow();
                            foreach (DataRow dtRow in drRow)
                            {
                                row["LABEL"] = dtRow["PLANT_NM"].ToString();
                                row["DAY" + dtRow["RN"].ToString()] = dtRow["OCR_TIME"];
                            }
                            dtData.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    foreach (string line in lineCd)
                    {
                        DataRow[] drRow = _dtChart.Select($"line_cd = '{line}'");
                        if (drRow.Length > 0)
                        {
                            DataRow row = dtData.NewRow();
                            foreach (DataRow dtRow in drRow)
                            {
                                row["LABEL"] = dtRow["PLANT_NM"].ToString();
                                row["DAY" + dtRow["RN"].ToString()] = dtRow["OCR_TIME"];
                            }
                            dtData.Rows.Add(row);
                        }
                    }
                }

                

                return dtData;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
           
        }

        private DataTable GetDataTemp2()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string[] Label = { "Lean G", "Lean H", "Lean I", "Lean J", "Lean K" };

            //string[] day1 = { 10, "F2", "F3", "F4", "F5",};
            //string[] day2 = { "F1", "F2", "F3", "F4", "F5"};
            //string[] day3 = { "F1", "F2", "F3", "F4", "F5"};
            //string[] day4 = { "F1", "F2", "F3", "F4", "F5"};
            //string[] day5 = { "F1", "F2", "F3", "F4", "F5"};



            dt.Columns.Add("LABEL");
            dt.Columns.Add("DAY1", typeof(int));
            dt.Columns.Add("DAY2", typeof(int));
            dt.Columns.Add("DAY3", typeof(int));
            dt.Columns.Add("DAY4", typeof(int));
            dt.Columns.Add("DAY5", typeof(int));

            Random rn = new Random();
            for (int i = 0; i < Label.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["LABEL"] = Label[i];
                row["DAY1"] = rn.Next(20, 30);
                row["DAY2"] = rn.Next(30, 40);
                row["DAY3"] = rn.Next(20, 50);
                row["DAY4"] = rn.Next(40, 60);
                row["DAY5"] = rn.Next(35, 55);
                dt.Rows.Add(row);
            }

            return dt;
        }
        #endregion DB

        #region Event
        private void SMT_SCADA_COCKPIT_FORM2_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _time = 29;
                _strType = "D";
                Po_SetTreelist();
                timer1.Start();
                
                

            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _time++;
            if (_time >= 30)
            {
                _time = 0;
                
                LoadForm();
            }

        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmDay_Click(object sender, EventArgs e)
        {
            _strType = "D";
            LoadForm();
        }

        private void cmdWeek_Click(object sender, EventArgs e)
        {
            _strType = "W";
            LoadForm();
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            _strType = "M";
            LoadForm();
        }

        #endregion

        private void tlsLoction_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
                e.Node.ParentNode.Checked = Po_IsAllChecked(e.Node.ParentNode.Nodes);
            else
                Po_SetCheckedChildNodes(e.Node.Nodes);

            Po_SetChartWhenClickTree();
        }

        private void tlsLoction_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.GetValue("PARENTID").ToString() == "000")
            {
                e.Appearance.BackColor = Color.Black;
                e.Appearance.ForeColor = Color.Yellow;
                e.Appearance.Font = new Font("Calibri", 13, FontStyle.Bold ^ FontStyle.Italic);
            }
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            
            //chartControl1.Series[1].Points[1].Color = Color.Green;
            //chartControl1.Series[1].Points[2].Color = Color.Green;
            //chartControl1.Series[1].Points[3].Color = Color.Green;
            //chartControl1.Series[1].Points[4].Color = Color.Green;
            //Color colorInTarget = Color.Green;
            //BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            //drawOptions.Color = colorInTarget;
            //drawOptions.FillStyle.FillMode = FillMode.Solid;
            /*
            double val = e.Series.Points[1].Values[0];
            // Originial values - 12, 93, 167  
            Color colorInTarget = Color.Green;
            Color colorOutTarget = Color.Red;
            
            BarDrawOptions drawOptions = e.SeriesDrawOptions as BarDrawOptions;
            if (drawOptions == null)
                return;

            if (val > 40)
            {
                // Volume value is inside target range.  
                drawOptions.Color = colorInTarget;
                drawOptions.FillStyle.FillMode = FillMode.Solid;
            }
            else
            {
                // Volume value is outside target range.  
                drawOptions.Color = colorOutTarget;
                drawOptions.FillStyle.FillMode = FillMode.Solid;
            }
            */
        }
    }
}
