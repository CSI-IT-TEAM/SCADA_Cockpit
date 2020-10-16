﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using System.Data.OleDb;
//using JPlatform.Client.Controls;


namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_FORM1_BAK2 : Form
    {
        public SMT_SCADA_COCKPIT_FORM1_BAK2()
        {            
            InitializeComponent();
            initForm();
        }

        int _iReload = 0;
        Dictionary<string, UC.UC_Chart_Donut> _dicLocation = new Dictionary<string, UC.UC_Chart_Donut>();

        private void SMT_SCADA_COCKPIT_MENU_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmdBack.Visible = ComVar.Var._IsBack;
                tmrTime.Start();

            }
            else
            {
                tmrTime.Stop();
            }
        }


        //Create Datatable Test
        private DataTable createDatatableTest()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            string[] factory = { "F1", "F1", "F1", "F1", "F1", "F1",
                                 "F2", "F2", "F2", 
                                 "F3", "F3", "F3", 
                                 "F4", "F4", "F4", "F4", "F4",
                                 "F5", "F5", "F5", "F5"
                               };
            string[] line_nm = { "Line 1", "Line 2", "Line 3", "Line 4", "Line 5", "Line 6",
                                 "Plant B", "Plant C", "Plant D",
                                 "Plant E", "Plant F", "Plant N",
                                 "Plant G", "Plant H", "Plant I", "Plant J", "Plant K",
                                 "Plant L1", "Plant L2", "Plant M1", "Plant M2"
                               };
            string[] line_cd = { "001", "003", "002", "004", "005", "006",
                                 "007", "008", "010",
                                 "011", "012", "099", 
                                 "013", "014", "015", "016", "017", 
                                 "018", "019", "020", "021"
                               };

            dt.Columns.Add("FACTORY");
            dt.Columns.Add("LINE_NM");
            dt.Columns.Add("LINE_CD");

            for (int i = 0; i < factory.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["FACTORY"] = factory[i];
                row["LINE_NM"] = line_nm[i];
                row["LINE_CD"] = line_cd[i];

                dt.Rows.Add(row);
            }
            return dt;
        }


        #region Init Form

        private void initForm()
        {
            try
            {

                aPn1.Visible = false;
                aPn2.Visible = false;
                aPn3.Visible = false;

               // picSCADA.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\Start_up.png");

                DataTable dt = createDatatableTest();

              //  uC_Chart_Donut1.setColor("Lime");
                uC_Chart_Pie1.setColor("RED");

                //initAPanel(gpF1, "F1", dt);
                //initAPanel(gpF2, "F2", dt);
                //initAPanel(gpF3, "F3", dt);
                //initAPanel(gpF4, "F4", dt);
                //initAPanel(gpF5, "F5", dt);



                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
            }
        }

        private void initAPanel(GroupBoxEx grpEx, string factory, DataTable argDt)
        {
            AdvancedPanel aPnUpn = createPanel("aPn_" + factory + "_UPN", 8, 140, 300, 190);
            AdvancedPanel aPnFss = createPanel("aPn_" + factory + "_FSS", 327, 140, 300, 190);
            AdvancedPanel aPnFga = createPanel("aPn_" + factory + "_FGA", 8, 337, 619, 134);
            aPnUpn.Controls.Add(createLabelName("lbl_" + factory + "_UPN", "No-Sew"));
            aPnFss.Controls.Add(createLabelName("lbl_" + factory + "_FSS", "Stockfit"));
            aPnFga.Controls.Add(createLabelName("lbl_" + factory + "_FGA", "Assembly"));

            DataTable dtFactory = argDt.Select("FACTORY = '" + factory + "'").CopyToDataTable();
            panelUpnAdd(aPnUpn, dtFactory);
            panelFssAdd(aPnFss, dtFactory);
            panelFgaAdd(aPnFga, dtFactory);

            grpEx.Controls.Add(aPnUpn);
            grpEx.Controls.Add(aPnFss);
            grpEx.Controls.Add(aPnFga);
        }

        private void panelUpnAdd(AdvancedPanel aPn,  DataTable dtFactory)
        {
            int locStartX = 10, locStartY = 40;
            int locX = locStartX, locY = locStartY;
            int widthButton = 65, heightButton = 60;
            int maxLineInRow = 4, iLine = 0;
            string buttonName, buttonText;

            foreach (DataRow row in dtFactory.Rows)
            {
                iLine++;
                if (iLine > maxLineInRow)
                {
                    locY += heightButton + 5;
                    locX = locStartX;
                    iLine = 1;
                }
                buttonName = "cmd_" + row["LINE_CD"].ToString() + "_UPN";
                buttonText = row["LINE_NM"].ToString();
                Button btn = createLine(buttonName, buttonText, locX, locY, widthButton, heightButton);
                aPn.Controls.Add(btn);

                locX += widthButton + 5;
            }
        }

        private void panelFssAdd(AdvancedPanel aPn, DataTable dtFactory)
        {
            int locStartX = 10, locStartY = 40;
            int locX = locStartX, locY = locStartY;
            int widthButton = 65, heightButton = 60;
            int maxLineInRow = 4, iLine = 0;
            string buttonName, buttonText;

            foreach (DataRow row in dtFactory.Rows)
            {
                iLine++;
                if (iLine > maxLineInRow)
                {
                    locY += heightButton + 5;
                    locX = locStartX;
                    iLine = 1;
                }
                buttonName = "cmd_" + row["LINE_CD"].ToString() + "_FSS";
                buttonText = row["LINE_NM"].ToString();
                Button btn = createLine(buttonName, buttonText, locX, locY, widthButton, heightButton);
                aPn.Controls.Add(btn);

                locX += widthButton + 5;
            }
        }

        private void panelFgaAdd(AdvancedPanel aPn, DataTable dtFactory)
        {
            int locStartX = 10, locStartY = 40;
            int locX = locStartX, locY = locStartY;
            int widthButton = 65, heightButton = 60;
            int maxLineInRow = 8, iLine = 0;
            string buttonName, buttonText;

            foreach (DataRow row in dtFactory.Rows)
            {
                iLine++;
                if (iLine > maxLineInRow)
                {
                    locY += heightButton + 5;
                    locX = locStartX;
                    iLine = 1;
                }
                buttonName = "cmd_" + row["LINE_CD"].ToString() + "_FGA";
                buttonText = row["LINE_NM"].ToString();
                Button btn = createLine(buttonName, buttonText, locX, locY, widthButton, heightButton);
                aPn.Controls.Add(btn);

                locX += widthButton + 5;
            }
        }


        private AdvancedPanel createPanel(string namePanel, int LocationXPanel, int LocationYPanel, int widthPanel, int heightPanel)
        {
            AdvancedPanel aPanel = new FORM.AdvancedPanel();

            aPanel.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            aPanel.EdgeWidth = 1;
            aPanel.EndColor = System.Drawing.Color.White;
            aPanel.FlatBorderColor = System.Drawing.Color.DarkTurquoise;
            aPanel.ForeColor = System.Drawing.Color.Black;
            aPanel.Location = new System.Drawing.Point(LocationXPanel, LocationYPanel);
            aPanel.Name = namePanel;
            aPanel.Padding = new System.Windows.Forms.Padding(2);
            aPanel.RectRadius = 0;
            aPanel.ShadowColor = System.Drawing.Color.DimGray;
            aPanel.ShadowShift = 5;
            aPanel.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            aPanel.Size = new System.Drawing.Size(widthPanel, heightPanel);
            aPanel.StartColor = System.Drawing.Color.White;
            aPanel.Style = FORM.AdvancedPanel.BevelStyle.Flat;

            return aPanel;
        }

        private Label createLabelName(string nameLabel, string textLabel)
        {
            Label lbl = new Label();

            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(5, 2);
            lbl.Name = nameLabel;          
            lbl.Size = new System.Drawing.Size(84, 33);
            lbl.TabIndex = 0;
            lbl.Text = textLabel;

            return lbl;
        }

        private Button createLine(string nameButton, string textButton, int LocationXButton, int LocationYButton, int widthButton, int heightButton)
        {
            Button cmd = new Button();

            cmd.FlatAppearance.BorderSize = 0;
            cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmd.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
            cmd.Location = new System.Drawing.Point(LocationXButton, LocationYButton);
            cmd.BackColor = Color.LimeGreen;
            cmd.ForeColor = Color.White;
            cmd.Name = nameButton;
            cmd.Tag = nameButton.Remove(0, 4);
            cmd.Size = new System.Drawing.Size(widthButton, heightButton);
            cmd.TabIndex = 0;
            cmd.Text = textButton;
            cmd.UseVisualStyleBackColor = true;
            cmd.Click += new EventHandler(Button_Line_Click);

            return cmd;
        }

        private void addLine()
        {
            try
            {
                /*
                DataTable dtLayout = Master_Select("Q1");

                Dictionary<string, TableLayoutPanel> dicTableLayout = new Dictionary<string, TableLayoutPanel>()
                {
                    {"F1UPN",tblF1Nosew},{"F2UPN",tblF2Nosew},{"F3UPN",tblF3Nosew},{"F4UPN",tblF4Nosew},{"F5UPN",tblF5Nosew},
                    {"F1FSS",tblF1Fss},{"F2FSS",tblF2Fss},{"F3FSS",tblF3Fss},{"F4FSS",tblF4Fss},{"F5FSS",tblF5Fss},  
                    {"F1FGA",tblF1Ass},{"F2FGA",tblF2Ass},{"F3FGA",tblF3Ass},{"F4FGA",tblF4Ass},{"F5FGA",tblF5Ass}
                };

                int iRow = 0, iColumn = 0, iMaxRow = 4, iMaxColumn = 1, iLineTotal = dtLayout.Rows.Count;
                string strArea = "",  strTable = "";
                tblMenu.Visible = false;
                for (int iLine = 0; iLine < iLineTotal; iLine++)
                {
                    if (iRow <= iMaxRow)
                    {
                        strArea = dtLayout.Rows[iLine]["OP_CD"].ToString();
                        strTable = dtLayout.Rows[iLine]["FACTORY"].ToString() + dtLayout.Rows[iLine]["OP_CD"].ToString();

                        UC.UC_Machine machine = new UC.UC_Machine();
                        machine.OnButton_Click += Button_Line_Click;
                        machine._Area = strArea;
                        machine._Name = dtLayout.Rows[iLine]["LINE_NAME"].ToString();
                        machine._Code = dtLayout.Rows[iLine]["LINE_CD"].ToString();

                        dicTableLayout[strTable].Controls.Add(machine, iColumn, iRow);
                    }

                    if (iColumn++ > iMaxColumn)
                    {
                        iColumn = 0;
                        iRow++;
                    }

                    if (iLine + 1 < iLineTotal && strArea != dtLayout.Rows[iLine + 1]["OP_CD"].ToString())
                    {
                        iColumn = 0;
                        iRow = 0;
                    }
                }
                tblMenu.Visible = true;
                */
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());;
            }
            
        }

        #region Button Line Click

        private void Button_Line_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MessageBox.Show(ctr.Tag.ToString());
        }
        #endregion Button Line Click

       

        #endregion Init Form

        #region DB

        private DataTable Master_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.MASTER_PLANT_SELECT";

            MyOraDB.Parameter_Name[0] = "ARG_QTYPE";
            MyOraDB.Parameter_Name[1] = "OUT_CURSOR";

            MyOraDB.Parameter_Type[0] = (int)OracleType.VarChar;
            MyOraDB.Parameter_Type[1] = (int)OracleType.Cursor;

            MyOraDB.Parameter_Values[0] = argType;
            MyOraDB.Parameter_Values[1] = "";

            MyOraDB.Add_Select_Parameter(true);
            DataSet retDS = MyOraDB.Exe_Select_Procedure();
            if (retDS == null) return null;

            return retDS.Tables[MyOraDB.Process_Name];
        }


        #endregion DB

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            lblDate.Text= string.Format(DateTime.Now.ToString("yyyy-MM-dd\nHH:mm:ss"));
            _iReload ++;
            if (_iReload == 10)
            {
                //uC_Chart_Donut1.setColor("Red");
                uC_Chart_Pie1.setColor("Green");
            }
        }

        private void cmdF4_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var._strValue1 = "F4";
            ComVar.Var.callForm = "617";

        }

        private void lblDate_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        


    }
}