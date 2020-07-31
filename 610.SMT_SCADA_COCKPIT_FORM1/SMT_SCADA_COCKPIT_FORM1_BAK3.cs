using System;
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
    public partial class SMT_SCADA_COCKPIT_FORM1_BAK3 : Form
    {
        public SMT_SCADA_COCKPIT_FORM1_BAK3()
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
                                 "B", "C", "D",
                                 "E", "F", "N",
                                 "G", "H", "I", "J", "K",
                                 "L", "L"
                               };
            string[] line_cd = { "001", "003", "002", "004", "005", "006",
                                 "007", "008", "010",
                                 "011", "012", "099", 
                                 "013", "014", "015", "016", "017", 
                                 "018", "019"
                               };

            string[] num_mline_upn = { "0", "0", "0", "0", "0", "0",
                                 "4", "4", "4", 
                                 "4", "4", "4", 
                                 "4", "4", "4", "4", "4",
                                 "4", "4"
                               };

            string[] num_mline_fss = { "1", "1", "1", "1", "1", "1",
                                 "4", "4", "4", 
                                 "4", "4", "4", 
                                 "4", "4", "4", "4", "4",
                                 "4", "4"
                               };

            string[] num_mline_fga = { "1", "1", "1", "1", "1", "1",
                                 "4", "4", "4", 
                                 "4", "4", "8", 
                                 "4", "4", "4", "4", "4",
                                 "4", "4"
                               };

            dt.Columns.Add("FACTORY");
            dt.Columns.Add("LINE_NM");
            dt.Columns.Add("LINE_CD");
            dt.Columns.Add("NUM_UPN");
            dt.Columns.Add("NUM_FSS");
            dt.Columns.Add("NUM_FGA");
            for (int i = 0; i < line_nm.Length; i++)
            {
                DataRow row = dt.NewRow();
                row["FACTORY"] = factory[i];
                row["LINE_NM"] = line_nm[i];
                row["LINE_CD"] = line_cd[i];
                row["NUM_UPN"] = num_mline_upn[i];
                row["NUM_FSS"] = num_mline_fss[i];
                row["NUM_FGA"] = num_mline_fga[i];

                dt.Rows.Add(row);
            }

            return dt;
        }


        #region Init Form

        private void initForm()
        {
            try
            {

               
               // aPn3.Visible = false;

               // picSCADA.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\Start_up.png");

                DataTable dt = createDatatableTest();

                DataTable dtFactory = dt.Select("FACTORY = 'F1'").CopyToDataTable();

                //create_Line_F1(dtFactory);

                int x = 74, y = 31;
                create_Line_F1(pnF1, dtFactory, x, ref y, "FGA");
                y += 10;
                create_Line_F1(pnF1, dtFactory, x, ref y, "FSS");

                x = 74;
                y = 31;
                dtFactory = dt.Select("FACTORY = 'F2'").CopyToDataTable();
                create_Line(pnF2, dtFactory, x, y);

                x = 74;
                y = 31;
                dtFactory = dt.Select("FACTORY = 'F3'").CopyToDataTable();
                create_Line(pnF3, dtFactory, x, y);

                x = 74;
                y = 31;
                dtFactory = dt.Select("FACTORY = 'F4'").CopyToDataTable();
                create_Line(pnF4, dtFactory, x, y);

                x = 74;
                y = 31;
                dtFactory = dt.Select("FACTORY = 'F5'").CopyToDataTable();
                create_Line(pnF5, dtFactory, x, y);


              //  uC_Chart_Donut1.setColor("Lime");
             //   uC_Chart_Pie1.setColor("RED");



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

        private void create_Line_F1(Panel pnControl, DataTable argDt, int locStartX,ref int locStartY, string area)
        {
            int locX = locStartX, locY = locStartY;
            Font buttonMlineFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            Font buttonLineFont = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold);
            Point buttonLoc;
            Size buttonSize;
            Size lineButtonSize = new System.Drawing.Size(60, 25);
            Size buttonStatusSize = new System.Drawing.Size(230, 25);
            Dictionary<string, string> dicValue = new Dictionary<string, string>();

            dicValue.Add("NAME", "");
            dicValue.Add("TEXT", "");
            dicValue.Add("BACK_COLOR", "");
            dicValue.Add("FORE_COLOR", "");

            Button cmdLine;
            //Assemblem
            foreach (DataRow row in argDt.Rows)
            {

                buttonLoc = new Point(locX, locY);
                dicValue["NAME"] = "cmd_" + row["LINE_CD"].ToString() + "_000" + "_" + area + "_" + "LNM";
                dicValue["TEXT"] = row["LINE_NM"].ToString();
                dicValue["BACK_COLOR"] = "NAVY";
                dicValue["FORE_COLOR"] = "WHITE";
                cmdLine = createButton(dicValue, buttonLoc, lineButtonSize, buttonMlineFont);
                pnControl.Controls.Add(cmdLine);

                locX += lineButtonSize.Width + 5;

                buttonLoc = new Point(locX, locY);
                dicValue["NAME"] = "cmd_" + row["LINE_CD"].ToString() + "_000" + "_" + area + "_" + "STA";
                dicValue["TEXT"] = "";
                dicValue["BACK_COLOR"] = "GREEN";
                dicValue["FORE_COLOR"] = "WHITE";
                cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                pnControl.Controls.Add(cmdLine);

                locX = locStartX;
                locY += buttonStatusSize.Height + 5;
            }

            buttonLoc = new Point(3, locStartY);
            buttonSize = new System.Drawing.Size(65, locY - locStartY - 5);
            dicValue["NAME"] = "cmd_F1_FGA";
            dicValue["TEXT"] = area == "FGA" ? "AS" : area == "FSS" ? "FS" : area;
            dicValue["BACK_COLOR"] = "NAVY";
            dicValue["FORE_COLOR"] = "WHITE";
            cmdLine = createButton(dicValue, buttonLoc, buttonSize, buttonLineFont);
            pnControl.Controls.Add(cmdLine);

            locStartY = locY += 10;
        }

        private void create_Line(Panel pnControl, DataTable argDt, int locStartX, int locStartY)
        {
            int locX = locStartX, locY = locStartY;
            Font buttonMlineFont = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            Font buttonLineFont = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold);
            Point buttonLoc;
            Size buttonSize;
            Size lineButtonSize = new System.Drawing.Size(60, 25);
            Size buttonStatusSize = new System.Drawing.Size(70, 25);
            Dictionary<string, string> dicValue = new Dictionary<string, string>();
            string lineCd;
            int iNumLine;

            dicValue.Add("NAME", "");
            dicValue.Add("TEXT", "");
            dicValue.Add("BACK_COLOR", "");
            dicValue.Add("FORE_COLOR", "");

            Button cmdLine;

            foreach (DataRow row in argDt.Rows)
            {
                int.TryParse(row["NUM_UPN"].ToString(), out iNumLine);
                lineCd = row["LINE_CD"].ToString();
                for (int iLine = 1; iLine <= iNumLine; iLine++)
                {
                    buttonLoc = new Point(locX, locY);
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "MNM";
                    dicValue["TEXT"] = iLine.ToString();
                    dicValue["BACK_COLOR"] = "NAVY";
                    dicValue["FORE_COLOR"] = "WHITE";
                    cmdLine = createButton(dicValue, buttonLoc, lineButtonSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    locX += lineButtonSize.Width + 5;

                    //UPN
                    buttonLoc = new Point(locX, locY);
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "UPN" + "_" + "STA";
                    dicValue["TEXT"] = "";
                    dicValue["BACK_COLOR"] = "GREEN";
                    dicValue["FORE_COLOR"] = "WHITE";
                    cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    //FSS
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "FSS" + "_" + "STA";
                    buttonLoc = new Point(locX += buttonStatusSize.Width + 5, locY);
                    cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    //FGA
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "FGA" + "_" + "STA";
                    buttonLoc = new Point(locX += buttonStatusSize.Width + 5, locY);
                    cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);


                    locX = locStartX;
                    locY += buttonStatusSize.Height + 5;
                }

                buttonLoc = new Point(3, locStartY);
                buttonSize = new System.Drawing.Size(65, locY - locStartY - 5);
                dicValue["NAME"] = "cmd_" + lineCd + "_" + "LNM"; ;
                dicValue["TEXT"] = row["LINE_NM"].ToString();
                dicValue["BACK_COLOR"] = "NAVY";
                dicValue["FORE_COLOR"] = "WHITE";
                cmdLine = createButton(dicValue, buttonLoc, buttonSize, buttonLineFont);
                pnControl.Controls.Add(cmdLine);

                locStartY = locY += 10;
            }
        }

        private Button createButton(Dictionary<string, string> value, Point location, Size size, Font font)
        {
            Button cmd = new Button();

            cmd.FlatAppearance.BorderSize = 0;
            cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmd.Font = font;
            cmd.Location = location;
            cmd.BackColor = Color.FromName(value["BACK_COLOR"]);
            cmd.ForeColor = Color.FromName(value["FORE_COLOR"]);
            cmd.Name = value["NAME"];
            //cmd.Tag = value["NAME"].Remove(0, 4);
            cmd.Size = size;
            cmd.Text = value["TEXT"];
            cmd.UseVisualStyleBackColor = true;
            cmd.Click += new EventHandler(Button_Line_Click);

            return cmd;
        }

#region No use
        /*
        

        

        private Button createLine(string nameButton, string textButton, Point location, Size size)
        {
            Button cmd = new Button();

            cmd.FlatAppearance.BorderSize = 0;
            cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmd.Font = new System.Drawing.Font("Calibri", 40, System.Drawing.FontStyle.Bold);
            cmd.Location = location;
            cmd.BackColor = Color.Green;
            cmd.ForeColor = Color.White;
            cmd.Name = nameButton;
            cmd.Tag = nameButton.Remove(0, 4);
            cmd.Size = size;
            cmd.Text = textButton;
            cmd.UseVisualStyleBackColor = true;
            cmd.Click += new EventHandler(Button_Line_Click);

            return cmd;
        }

        private Button createLine(string nameButton, string textButton, int LocationXButton, int LocationYButton, int widthButton, int heightButton)
        {
            Button cmd = new Button();

            cmd.FlatAppearance.BorderSize = 0;
            cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmd.Font = new System.Drawing.Font("Calibri", 40, System.Drawing.FontStyle.Bold);
            cmd.Location = new System.Drawing.Point(LocationXButton, LocationYButton);
            cmd.BackColor = Color.Green;
            cmd.ForeColor = Color.White;
            cmd.Name = nameButton;
            cmd.Tag = nameButton.Remove(0, 4);
            cmd.Size = new System.Drawing.Size(widthButton, heightButton);
            cmd.Text = textButton;
            cmd.UseVisualStyleBackColor = true;
            cmd.Click += new EventHandler(Button_Line_Click);

            return cmd;
        } 


        private Button createLine(DataRow rowLine)
        {
            int LocationXButton, LocationYButton, widthButton, heightButton;
            string nameButton = rowLine[""].ToString();
            string textButton = rowLine[""].ToString();

            int.TryParse(rowLine[""].ToString(), out LocationXButton);
            int.TryParse(rowLine[""].ToString(), out LocationYButton);
            int.TryParse(rowLine[""].ToString(), out widthButton);
            int.TryParse(rowLine[""].ToString(), out heightButton);



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


        //private Button createLine(string nameButton, string textButton, int LocationXButton, int LocationYButton, int widthButton, int heightButton)
        //{
        //    Button cmd = new Button();

        //    cmd.FlatAppearance.BorderSize = 0;
        //    cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    cmd.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold);
        //    cmd.Location = new System.Drawing.Point(LocationXButton, LocationYButton);
        //    cmd.BackColor = Color.LimeGreen;
        //    cmd.ForeColor = Color.White;
        //    cmd.Name = nameButton;
        //    cmd.Tag = nameButton.Remove(0, 4);
        //    cmd.Size = new System.Drawing.Size(widthButton, heightButton);
        //    cmd.TabIndex = 0;
        //    cmd.Text = textButton;
        //    cmd.UseVisualStyleBackColor = true;
        //    cmd.Click += new EventHandler(Button_Line_Click);

        //    return cmd;
        //}
      

        private void addLine()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.ToString());;
            }
            
        }

        */
#endregion 

        #region Button Line Click

        private void Button_Line_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MessageBox.Show(ctr.Name.ToString());
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
               // uC_Chart_Pie1.setColor("Green");
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        


    }
}
