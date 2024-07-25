using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraCharts;
using System.Reflection;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes.Operations;

namespace FORM
{
    public partial class FRM_SCADA_TRENDING : Form
    {
        public FRM_SCADA_TRENDING()
        {
            InitializeComponent();
        }

        #region FormChild
        FRM.FRM_SCADA_TREND_ALL FRM_TREND_ALL = new FRM.FRM_SCADA_TREND_ALL();
        FRM.FRM_SCADA_TREND_CRL FRM_TREND_CRL = new FRM.FRM_SCADA_TREND_CRL();
        #endregion
        #region Variable       
        string _LINE;
        string _MACHINE;
        bool flag = false;
        int _cnt = 0;
        DatabaseSCADA db = new DatabaseSCADA();
        DataTable dtRealChart = new DataTable();

        public int iCount_Hide = 0;
        #endregion


        RepositoryItemCheckEdit checkEdit; 
        private void FRM_SCADA_TRENDING_Load(object sender, EventArgs e)
        {
            lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
            CXMLConfig conFig = new CXMLConfig("Config.xml");
            _LINE = conFig.XmlReadValue("LINECD");

            tmrDate.Interval = 1000;
            tmrDate.Enabled = true;            
            //treeList.OptionsSelection.MultiSelect = true;
            //checkEdit = (RepositoryItemCheckEdit)treeList.RepositoryItems.Add("CheckEdit");
            //SelectAll(treeList);
            //MouseEventArgs _e = new MouseEventArgs(System.Windows.Forms.MouseButtons.Left, 0, 9, 5, 0);
            //treeList_MouseUp(treeList, _e);
        }

        //protected void DrawCheckBox(Graphics g, RepositoryItemCheckEdit edit, Rectangle r, bool Checked)
        //{
        //    DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
        //    DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
        //    DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
        //    info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
        //    painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
        //    info.EditValue = Checked;
        //    info.Bounds = r;
        //    info.CalcViewInfo(g);
        //    args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, new DevExpress.Utils.Drawing.GraphicsCache(g), r);
        //    painter.Draw(args);
        //    args.Cache.Dispose();
        //} 

        private void load_combo()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtDATE = db.SEL_SCADA_SET_COMBO("DATE", _LINE);
                //dtp_To.EditValue = dtDATE.Rows[0]["TODAY"];
                dtp_To.EditValue = dtDATE.Rows[0]["PREV_DAY"];

                DataTable dt = db.SEL_SCADA_SET_COMBO("LINE", _LINE);
                if (dt != null && dt.Rows.Count > 0)
                {
                    cboLine.DataSource = dt;
                    cboLine.DisplayMember = "NAME";
                    cboLine.ValueMember = "CODE";
                }

                DataTable dt1 = db.SEL_SCADA_SET_COMBO("AREA", _LINE);
                if (dt1 != null && dt1.Rows.Count > 0)
                {
                    cboArea.DisplayMember = "NAME";
                    cboArea.ValueMember = "CODE";
                    cboArea.DataSource = dt1;
                }
                
            }
            catch
            {
                
            }
            finally { this.Cursor = Cursors.Default; }
        }

        DataTable Pivot(DataTable dt, DataColumn pivotColumn, DataColumn pivotValue)
        {
            // find primary key columns 
            //(i.e. everything but pivot column and pivot value)
            DataTable temp = dt.Copy();
            temp.Columns.Remove(pivotColumn.ColumnName);
            temp.Columns.Remove(pivotValue.ColumnName);
            string[] pkColumnNames = temp.Columns.Cast<DataColumn>()
            .Select(c => c.ColumnName)
            .ToArray();

            // prep results table
            DataTable result = temp.DefaultView.ToTable(true, pkColumnNames).Copy();
            result.PrimaryKey = result.Columns.Cast<DataColumn>().ToArray();
            dt.AsEnumerable()
            .Select(r => r[pivotColumn.ColumnName].ToString())
            .Distinct().ToList()
            .ForEach(c => result.Columns.Add(c, pivotValue.DataType));
            //.ForEach(c => result.Columns.Add(c, pivotColumn.DataType));

            // load it
            foreach (DataRow row in dt.Rows)
            {
                // find row to update
                DataRow aggRow = result.Rows.Find(
                pkColumnNames
                .Select(c => row[c])
                .ToArray());
                // the aggregate used here is LATEST 
                // adjust the next line if you want (SUM, MAX, etc...)
                aggRow[row[pivotColumn.ColumnName].ToString()] = row[pivotValue.ColumnName];


            }

            return result;
        }

        private DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        DataTable dtMaster = null, dtchart = null;

        public void BindingChart()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                dtMaster = db.SP_SCADA_GET_CHART("Q", dtp_To.DateTime.ToString("yyyyMMdd"), _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString());
                if (dtMaster != null && dtMaster.Rows.Count > 0)
                {
                    dtchart = dtMaster.Copy();
                    dtchart.Columns.Remove("MIN_VAL");
                    dtchart.Columns.Remove("MAX_VAL");
                    //DataTable dtPivot = Pivot(dtchart, dtchart.Columns["ID_CODE"], dtchart.Columns["VAL"]);
                    //var distinctValues = dtchart.AsEnumerable()
                    //                  .Select(row => new
                    //                  {
                    //                      ID_CODE = row.Field<string>("ID_CODE")
                    //                  })
                    //                  .Distinct().OrderBy(r => r.ID_CODE);

                    //DataTable dtSeries = LINQResultToDataTable(distinctValues);

                    //if (dtPivot != null && dtPivot.Rows.Count > 0)
                    //{
                    //    chartControl1.Series.Clear();
                    //    Series[] series1 = new Series[dtPivot.Columns.Count - 1];
                    //    chartControl1.DataSource = dtPivot;
                    //    for (int i = 0; i < dtSeries.Rows.Count; i++)
                    //    {
                    //        series1[i] = new Series(dtSeries.Rows[i][0].ToString(), ViewType.Line);
                    //        series1[i].ArgumentDataMember = "LB";
                    //        series1[i].ValueDataMembers.AddRange(new string[] { dtSeries.Rows[i][0].ToString() });
                    //        series1[i].CrosshairLabelPattern = "{S} : {V}";
                    //        chartControl1.Series.Add(series1[i]);
                    //    }
                    //}
                }
                else
                {
                    dtchart = null;
            

                }
                BindingChart2();

                iCount_Hide = 0;
            }
            catch
            {
            }
        }

        public void BindingChart2()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                DataTable dt = null;
                DataTable dtmin_max = null;
                if (dtchart != null && dtchart.Rows.Count > 0)
                {
                    dt = dtchart.Copy();
                    int cnt1 = 0, cnt2 = 0;
                    string _strname = "";
                    foreach (TreeListNode node in treeList.Nodes)
                    {
                        foreach (TreeListNode node1 in node.RootNode.Nodes)
                        {
                            cnt1++;
                            if (!node1.Checked)
                            {
                                if (dt.Select("ID_CODE <> '" + node1.GetValue("ID_NAME").ToString() + "'", "LB, ID_CODE").Count() > 0)
                                {
                                    dt = dt.Select("ID_CODE <> '" + node1.GetValue("ID_NAME").ToString() + "'", "LB, ID_CODE").CopyToDataTable();
                                    cnt2++;
                                }
                            }
                            else
                            {
                                _strname = node1.GetValue("ID_NAME").ToString();
                            }
                        }
                    }

                    if (cnt1 - cnt2 == 1)
                    {
                        DataTable dtPivot = Pivot(dt, dt.Columns["ID_CODE"], dt.Columns["VAL"]);
                        DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
                        DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
                        

                        var distinctValues = dt.AsEnumerable()
                                          .Select(row => new
                                          {
                                              ID_CODE = row.Field<string>("ID_CODE")
                                          })
                                          .Distinct().OrderBy(r => r.ID_CODE);
                        DataTable dtSeries = LINQResultToDataTable(distinctValues);
                        
                        
                        dtmin_max = dtMaster.Select("ID_CODE = '" + _strname + "'", "LB, ID_CODE").CopyToDataTable();
                        dtmin_max.Columns.Remove("ID_CODE");
                        dtmin_max.Columns["VAL"].ColumnName = _strname;
                        dtmin_max.Columns["MIN_VAL"].ColumnName = "Min";
                        dtmin_max.Columns["MAX_VAL"].ColumnName = "Max";

                        dtSeries.Rows.Add("Min");
                        dtSeries.Rows.Add("Max");

                        splineSeriesView1.Color = System.Drawing.Color.Green;
                        splineSeriesView1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                        splineSeriesView1.LineStyle.Thickness = 5;
                        splineSeriesView1.Shadow.Size = 1;

                        splineSeriesView2.Color = System.Drawing.Color.Red;
                        splineSeriesView2.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                        splineSeriesView2.LineStyle.Thickness = 5;
                        splineSeriesView2.Shadow.Size = 1;
                        if (dtmin_max != null && dtmin_max.Rows.Count > 0)
                        {
                            chartControl1.Series.Clear();
                            Series[] series1 = new Series[dtmin_max.Columns.Count - 1];

                            chartControl1.DataSource = dtmin_max;
                            for (int i = 0; i < dtSeries.Rows.Count; i++)
                            {
                                series1[i] = new Series(dtSeries.Rows[i][0].ToString(), ViewType.Line);
                                series1[i].ArgumentDataMember = "LB";
                                series1[i].ValueDataMembers.AddRange(new string[] { dtSeries.Rows[i][0].ToString() });
                                series1[i].CrosshairLabelPattern = "{S} : {V}";
                                series1[i].View = splineSeriesView1;
                                if (i > 0)
                                {
                                    series1[i].View = splineSeriesView1;

                                }
                                else
                                {
                                    series1[i].View = splineSeriesView2;
                                }
                                chartControl1.Series.Add(series1[i]);
                            }
                            ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.Auto = false;
                            ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.MaxValue = int.Parse(dtmin_max.Rows[0]["Max"].ToString()) + 5;
                            ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.MinValue = int.Parse(dtmin_max.Rows[0]["Min"].ToString()) - 5;
                            ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.SideMarginsValue = 1;
                            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                            chartControl1.CrosshairOptions.CrosshairLabelMode = DevExpress.XtraCharts.CrosshairLabelMode.ShowCommonForAllSeries;
                            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
                            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                            diagram.EnableAxisXScrolling = true;

                            if (dtmin_max.Rows.Count > 22)
                            {
                                //diagram.AxisX.VisualRange.MinValue = dtmin_max.Rows[dtmin_max.Rows.Count - 21]["LB"];
                                diagram.AxisX.VisualRange.SetMinMaxValues(dtmin_max.Rows[dtPivot.Rows.Count - 23]["LB"], dtmin_max.Rows[dtPivot.Rows.Count - 1]["LB"]);
                            }
                            else
                            {
                                //diagram.AxisX.VisualRange.MinValue = dtmin_max.Rows[0]["LB"];
                                diagram.AxisX.VisualRange.SetMinMaxValues(dtmin_max.Rows[0]["LB"], dtmin_max.Rows[dtmin_max.Rows.Count - 1]["LB"]);
                            }
                            
                            //diagram.AxisX.VisualRange.MaxValue = dtmin_max.Rows[dtmin_max.Rows.Count - 1]["LB"];

                        }
                    }
                    else
                    {
                        DataTable dtPivot = Pivot(dt, dt.Columns["ID_CODE"], dt.Columns["VAL"]);
                        var distinctValues = dt.AsEnumerable()
                                          .Select(row => new
                                          {
                                              ID_CODE = row.Field<string>("ID_CODE")
                                          })
                                          .Distinct().OrderBy(r => r.ID_CODE);
                        DataTable dtSeries = LINQResultToDataTable(distinctValues);
                        if (dtPivot != null && dtPivot.Rows.Count > 0)
                        {                            
                            chartControl1.Series.Clear();
                            Series[] series1 = new Series[dtPivot.Columns.Count - 1];
                            chartControl1.DataSource = dtPivot;
                            for (int i = 0; i < dtSeries.Rows.Count; i++)
                            {
                                series1[i] = new Series(dtSeries.Rows[i][0].ToString(), ViewType.Line);
                                series1[i].ArgumentDataMember = "LB";
                                series1[i].ValueDataMembers.AddRange(new string[] { dtSeries.Rows[i][0].ToString() });
                                series1[i].CrosshairLabelPattern = "{S} : {V}";
                                chartControl1.Series.Add(series1[i]);
                            }
                            ((XYDiagram)chartControl1.Diagram).AxisY.WholeRange.Auto = true;
                            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
                            //chartControl1.CrosshairOptions.CrosshairLabelMode = DevExpress.XtraCharts.CrosshairLabelMode.ShowForNearestSeries;
                            chartControl1.CrosshairOptions.CrosshairLabelMode = DevExpress.XtraCharts.CrosshairLabelMode.ShowCommonForAllSeries;
                            diagram.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
                            diagram.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
                            diagram.EnableAxisXScrolling = true;
                            //diagram.AxisX.WholeRange.AlwaysShowZeroLevel = false;
                            diagram.AxisX.VisualRange.Auto = false;
                            if (dtPivot.Rows.Count > 22)
                            {
                                //diagram.AxisX.VisualRange.MinValue = dtmin_max.Rows[dtmin_max.Rows.Count - 21]["LB"];
                                diagram.AxisX.VisualRange.SetMinMaxValues(dtPivot.Rows[dtPivot.Rows.Count - 23]["LB"], dtPivot.Rows[dtPivot.Rows.Count - 1]["LB"]);
                            }
                            else
                            {
                                //diagram.AxisX.VisualRange.MinValue = dtmin_max.Rows[0]["LB"];
                                diagram.AxisX.VisualRange.SetMinMaxValues(dtPivot.Rows[0]["LB"], dtPivot.Rows[dtPivot.Rows.Count - 1]["LB"]);
                            }
                            //diagram.AxisX.VisualRange.MaxValue = dtmin_max.Rows[dtmin_max.Rows.Count - 1]["LB"];
                        }
                    }
                    
                    
                   // diagram.AxisX.WholeRange.SideMarginsValue = 0;
                    
                }
            }
            catch
            {
            }
        }

        private void set_Series()
        {
            foreach (TreeListNode node in treeList.Nodes)
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

        private void setTreelist()
        {
            try
            {
                if (cboArea.SelectedValue ==null) return;
                DataTable dt = db.SP_SCADA_SET_TREELIST("Q1", dtp_To.DateTime.ToString("yyyyMMdd"), _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString());
                treeList.DataSource = dt;
                treeList.KeyFieldName = "ID";
                treeList.ParentFieldName = "PARENTID";
                treeList.Columns["ID_NAME"].Visible = false;
                //treeList.Columns["SHIFT"].Visible = false;
                //treeList.Columns["SELECT_YN"].Visible = false;
                //treeList.Columns["MENU_NM"].OptionsColumn.AllowSort = false;
                //treeList.Columns["MENU_NM"].Width = 200;
                //treeList.Columns["MENU_NM"].Caption = "Process";
                //treeList.Columns["QTY"].OptionsColumn.AllowSort = false;
                //treeList.Columns["QTY"].Width = 90;
                //treeList.Columns["QTY"].Caption = "Total";
                //treeList.Columns["QTY"].Format.FormatType = DevExpress.Utils.FormatType.Numeric;
                //treeList.Columns["QTY"].Format.FormatString = "#,#";

                Skin skin = GridSkins.GetSkin(treeList.LookAndFeel);
                skin.Properties[GridSkins.OptShowTreeLine] = true;
                chkAll.Checked = true;
                foreach (TreeListNode node in treeList.Nodes)
                {
                    var dataRow = treeList.GetDataRecordByNode(node);
                    node.Tag = dataRow;
                    node.Checked = true;
                    node.Expanded = true;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        if (node.Checked)
                            node1.Checked = true;
                    }
                }
            }
            catch { }
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboArea.DataSource == null || cboArea.SelectedValue.ToString() == "System.Data.DataRowView") return;
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                setTreelist();
                BindingChart();
                
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();
            }
        }
        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                setTreelist();
                //DataTable dt = db.SEL_SCADA_SET_COMBO("AREA", _LINE);
                ////if (dt != null && dt.Rows.Count > 0)
                ////{
                //cboArea.DataSource = dt;
                //cboArea.DisplayMember = "NAME";
                //cboArea.ValueMember = "CODE";
                ////}
            }
            catch { }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                splashScreenManager1.ShowWaitForm();
                //setTreelist();
                BindingChart();
                set_Series();
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();

               
            }
            catch
            {
                this.Cursor = Cursors.Default;
                splashScreenManager1.CloseWaitForm();
            }
        }


        private void cboMachine_SelectedValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    //if (!cboMachine.SelectedValue.ToString().Equals("System.Data.DataRowView"))
            //    //{
            //    DataTable dt = db.SEL_SCADA_SET_COMBO2("ID", _LINE, cboLine.SelectedValue.ToString(), cboArea.SelectedValue.ToString(), cboMachine.SelectedValue.ToString());
            //    //if (dt != null && dt.Rows.Count > 0)
            //    //{
            //    cboID.DataSource = dt;
            //    cboID.DisplayMember = "NAME";
            //    cboID.ValueMember = "CODE";
            //    //}
            //    //}
            //}
            //catch { }
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            // Application.Exit();
            ComVar.Var.callForm = "minimized";
        } 
        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tmrDate_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss")); //Gán dữ liệu giờ cho label ngày giờ
                if (_cnt < 2)
                    _cnt++;
                if (_cnt == 2)
                {
                    _cnt++;
                    if (!flag)
                        load_combo();
                }


                iCount_Hide++;
                if (iCount_Hide >= 300)
                {
                    iCount_Hide = 0;
                    this.WindowState = FormWindowState.Minimized;
                    this.Hide();
                }
            }
            catch
            {
               
            }
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Properties.Resources.btnSearch1;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            btnSearch.BackgroundImage = Properties.Resources.btnSearch;
            btnSearch.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void treeList_NodeChanged(object sender, DevExpress.XtraTreeList.NodeChangedEventArgs e)
        {
            
        }

        private void SetCheckedChildNodes(TreeListNodes nodes)
        {
            foreach (TreeListNode node in nodes)
                node.Checked = node.ParentNode.Checked;
        } 

        private bool IsAllChecked(DevExpress.XtraTreeList.Nodes.TreeListNodes nodes)
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

        private void treeList_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.ParentNode != null)
                e.Node.ParentNode.Checked = IsAllChecked(e.Node.ParentNode.Nodes);
            else
                SetCheckedChildNodes(e.Node.Nodes);
            BindingChart2();
            set_Series();
        }

        //public void CheckAllNodes(TreeList tree)
        //{
        //    foreach (TreeListNode node in tree.Nodes)
        //    {
        //        node.Checked = true;
        //        CheckChildren(node, true);
        //    }
        //}

        //public void UncheckAllNodes(TreeList tree)
        //{
        //    foreach (TreeListNode node in tree.Nodes)
        //    {
        //        node.Checked = false;
        //        CheckChildren(node, false);
        //    }
        //}

        private void CheckChildren(TreeListNode rootNode, bool isChecked)
        {
            foreach (TreeListNode node in rootNode.Nodes)
            {
                CheckChildren(node, isChecked);
                node.Checked = isChecked;
            }
        }

        private void treeList_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            if (e.Node.GetValue("PARENTID").ToString() == "000")
            {
                e.Appearance.BackColor = Color.Black;
                e.Appearance.ForeColor = Color.Yellow;
                e.Appearance.Font = new Font("Times New Roman", 13, FontStyle.Bold ^ FontStyle.Italic);
            }
        }

        private void treeList_CustomDrawNodeButton(object sender, DevExpress.XtraTreeList.CustomDrawNodeButtonEventArgs e)
        {
            //Brush backBrush = e.Cache.GetSolidBrush(Color.White);
            //e.Graphics.FillRectangle(backBrush, e.Bounds);
            //ControlPaint.DrawBorder(e.Graphics, e.Bounds, Color.Gray, ButtonBorderStyle.Solid);
            //string displayCharacter = e.Expanded ? "-" : "+";
            //StringFormat outCharacterFormat = new StringFormat();
            //outCharacterFormat.Alignment = StringAlignment.Center;
            //outCharacterFormat.LineAlignment = StringAlignment.Center;
            //e.Graphics.DrawString(displayCharacter, new Font("Tahoma", 11),  new SolidBrush(Color.Black), e.Bounds, outCharacterFormat);
            //e.Handled = true;
        }

        private void treeList_CustomDrawNodeCheckBox(object sender, DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventArgs e)
        {
            
        }

        private bool IsAllSelected(TreeList tree)
        {
            return tree.Selection.Count > 0 && tree.Selection.Count == tree.AllNodesCount;
        } 

        private void treeList_CustomDrawColumnHeader(object sender, DevExpress.XtraTreeList.CustomDrawColumnHeaderEventArgs e)
        {
            //if (e.Column != null && e.Column.VisibleIndex == 0)
            //{
            //    Rectangle checkRect = new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 12, 12);
            //    ColumnInfo info = (ColumnInfo)e.ObjectArgs;
            //    if (info.CaptionRect.Left < 30)
            //        info.CaptionRect = new Rectangle(new Point(info.CaptionRect.Left + 15, info.CaptionRect.Top), info.CaptionRect.Size);
            //    e.Painter.DrawObject(info);

            //    DrawCheckBox(e.Graphics, checkEdit, checkRect, IsAllSelected(sender as TreeList));
            //    e.Handled = true;
            //}  
        }

        private void treeList_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                int cnt = 0;
                TreeList tree = sender as TreeList;
                Point pt = new Point(e.X, e.Y);
                TreeListHitInfo hit = tree.GetHitInfo(pt);






                if (hit.Column != null)
                {
                    switch (hit.HitInfoType.ToString().ToUpper())
                    {
                        case "COLUMN": //Neu click vao column header
                            foreach (TreeListNode node in treeList.Nodes)
                            {
                                foreach (TreeListNode node1 in node.RootNode.Nodes)
                                {
                                    if (node1.Checked)
                                    {
                                        cnt++;
                                    }
                                }
                            }

                            if (cnt == 0)
                            {

                                foreach (TreeListNode node in treeList.Nodes)
                                {
                                    node.Checked = true;
                                    chkAll.Checked = true;
                                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                                    {
                                        node1.Checked = true;
                                    }
                                }
                            }
                            else
                            {

                                foreach (TreeListNode node in treeList.Nodes)
                                {
                                    node.Checked = false;
                                    chkAll.Checked = false;
                                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                                    {
                                        node1.Checked = false;
                                    }
                                }
                            }

                            BindingChart2();
                            set_Series();
                            break;
                        case "CELL":
                            DevExpress.XtraTreeList.Nodes.TreeListNode clickedNode;
                            clickedNode = hit.Node;
                            clickedNode.Checked = !clickedNode.Checked;

                            // if a parent node is checked or unchecked, do the same for child nodes.  
                            if (clickedNode.HasChildren)
                            {
                                for (int i = 0; i < clickedNode.Nodes.Count; i++)
                                {
                                    clickedNode.Nodes[i].Checked = clickedNode.Checked;
                                }
                            }
                            else
                            {
                                // a child node was checked/unchecked so deselect the parent node if all of the nodes on  
                                // the same level aren't checked.  
                                bool bAllChecked = true;

                                for (int i = 0; i < clickedNode.ParentNode.Nodes.Count; i++)
                                {
                                    if (!clickedNode.ParentNode.Nodes[i].Checked)
                                    {
                                        bAllChecked = false;
                                        break;
                                    }
                                }


                                clickedNode.ParentNode.Checked = bAllChecked;

                            }

                            //bool bAllCheckTop = true;
                            ////Kiem tra tat ca node 0
                            //for (int i = 0; i < clickedNode.Nodes.Count; i++)
                            //{
                            //    if (!clickedNode.Nodes[i].Checked)
                            //    {
                            //        bAllCheckTop = false;
                            //        break;
                            //    }
                            //}
                            //chkAll.Checked = bAllCheckTop;
                            //else if (clickedNode.Level == 1) //Child node
                            //{
                            //    if (!clickedNode.Checked)
                            //    {
                            //        clickedNode.ParentNode.Checked = false;
                            //    }
                            //}

                            BindingChart();
                            set_Series();

                            break;
                    }

                   


                    //    ColumnInfo info = tree.ViewInfo.ColumnsInfo[hit.Column];
                    //    Rectangle checkRect = new Rectangle(info.Bounds.Left + 3, info.Bounds.Top + 5, 12, 12);
                    //    if (checkRect.Contains(pt))
                    //    {
                    //        if (IsAllSelected(tree))
                    //        {
                    //            tree.Selection.Clear();
                    //            foreach (TreeListNode node in treeList.Nodes)
                    //            {
                    //                node.Checked = false;
                    //                foreach (TreeListNode node1 in node.RootNode.Nodes)
                    //                {
                    //                    if (node1.Checked)
                    //                        node1.Checked = false;
                    //                }
                    //            }
                    //            BindingChart2();
                    //            set_Series();
                    //        }
                    //        else
                    //        {
                    //            SelectAll(tree);
                    //            foreach (TreeListNode node in treeList.Nodes)
                    //            {
                    //                node.Checked = true;
                    //                foreach (TreeListNode node1 in node.RootNode.Nodes)
                    //                {
                    //                    if (!node1.Checked)
                    //                        node1.Checked = true;
                    //                }
                    //            }
                    //            BindingChart2();
                    //            set_Series();
                    //        }
                    //        //throw new DevExpress.Utils.HideException();
                    //    }
                }
            }
            catch
            {

            }
        }

        class SelectNodeOperation : TreeListOperation
        {
            public override void Execute(TreeListNode node)
            {
                node.Selected = true;
            }
        }

        private void SelectAll(TreeList tree)
        {
            tree.BeginUpdate();
            tree.NodesIterator.DoOperation(new SelectNodeOperation());
            tree.EndUpdate();
        }

        private void treeList_SelectionChanged(object sender, EventArgs e)
        {
            //treeList.InvalidateColumnPanel();  
        }

        private void FRM_SCADA_TRENDING_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (iCount_Hide >= 200)
                {
                    iCount_Hide = 0;
                }
            }
            catch { }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            iCount_Hide = 0;

            if (chkAll.Checked)
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    node.Checked = true;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        node1.Checked = true;
                    }
                }
            }
            else
            {
                foreach (TreeListNode node in treeList.Nodes)
                {
                    node.Checked = false;
                    foreach (TreeListNode node1 in node.RootNode.Nodes)
                    {
                        node1.Checked = false;
                    }
                }
            }

            BindingChart2();
            set_Series();

        }  
    }
}
