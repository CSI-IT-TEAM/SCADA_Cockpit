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
using System.Diagnostics;
//using JPlatform.Client.Controls;


namespace FORM
{
    public partial class SMT_SCADA_COCKPIT_FORM1 : Form
    {
        public SMT_SCADA_COCKPIT_FORM1()
        {            
            InitializeComponent();
            initForm();
        }


        int _iReload = 0;
        DataTable _dtMasterLine;
       // Dictionary<string, UC.UC_Chart_Donut> _dicLocation = new Dictionary<string, UC.UC_Chart_Donut>();
        Dictionary<string, Button_Status> _dicLine = new Dictionary<string, Button_Status>();
        Dictionary<string, UC.UC_Factory> _dicFac = new Dictionary<string, UC.UC_Factory>();
        private void SMT_SCADA_COCKPIT_MENU_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                cmdBack.Visible = ComVar.Var._IsBack;
                _iReload = 59;
                tmrTime.Start();
                tmrBlink.Start();
            }
            else
            {
                tmrTime.Stop();
                tmrBlink.Stop();
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

            string[] line_nm = { "1", "2", "3", "4", "5", "6",
                                 "B", "C", "D",
                                 "E", "F", "N",
                                 "G", "H", "I", "J", "K",
                                 "L1", "L2"
                               };
            string[] line_cd = { "001", "003", "002", "004", "005", "006",
                                 "007", "008", "010",
                                 "011", "012", "099", 
                                 "013", "014", "015", "016", "017", 
                                 "018", "018_1"
                               };

            string[] num_mline_upn = { "0", "0", "0", "0", "0", "0",
                                 "4", "4", "4", 
                                 "4", "4", "4", 
                                 "4", "4", "4", "4", "4",
                                 "4", "4"
                               };

            string[] num_mline_fss = { "1", "1", "1", "1", "1", "1",
                                 "4", "4", "4", 
                                 "4", "4", "8", 
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



                _dtMasterLine = Master_Select("");// createDatatableTest();// Master_Select("");

                DataTable dtFactory = _dtMasterLine.Select("FACTORY = 'F1'").CopyToDataTable();

                //create_Line_F1(dtFactory);

                int x = 74, y = 35;
                create_Line_F1(pnF1, dtFactory, x, ref y, "FGA");
                y += 10;
                create_Line_F1(pnF1, dtFactory, x, ref y, "FSS");

                x = 74;
                y = 35;
                dtFactory = _dtMasterLine.Select("FACTORY = 'F2'").CopyToDataTable();
                create_Line(pnF2, dtFactory, x, y);

                x = 74;
                y = 35;
                dtFactory = _dtMasterLine.Select("FACTORY = 'F3'").CopyToDataTable();
                create_Line(pnF3, dtFactory, x, y);

                x = 74;
                y = 35;
                dtFactory = _dtMasterLine.Select("FACTORY = 'F4'").CopyToDataTable();
                create_Line(pnF4, dtFactory, x, y);

                x = 74;
                y = 35;
                dtFactory = _dtMasterLine.Select("FACTORY = 'F5'").CopyToDataTable();
                create_Line(pnF5, dtFactory, x, y);

                create_Factory(gpExF1, "F1");
                create_Factory(gpExF2, "F2");
                create_Factory(gpExF3, "F3");
                create_Factory(gpExF4, "F4");
                create_Factory(gpExF5, "F5");             

                //setData();

                //initAPanel(gpF1, "F1", dt);
                //initAPanel(gpF2, "F2", dt);
                //initAPanel(gpF3, "F3", dt);
                //initAPanel(gpF4, "F4", dt);
                //initAPanel(gpF5, "F5", dt);

                tmrBlink.Start();
                


                
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
            Font lineTextButtonFont = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            Font buttonMlineFont = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            Font buttonLineFont = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold);
            Point buttonLoc;
            Size buttonSize;

            Size lineTextButtonSize = new System.Drawing.Size(60, 35);
            Size lineButtonSize = new System.Drawing.Size(60, 25);
            Size buttonStatusSize = new System.Drawing.Size(230, 25);
            Dictionary<string, string> dicValue = new Dictionary<string, string>();

            dicValue.Add("NAME", "");
            dicValue.Add("TEXT", "");
            dicValue.Add("BACK_COLOR", "");
            dicValue.Add("FORE_COLOR", "");
            dicValue.Add("TAG", "");

            Button cmdLine;

            //head line name
            buttonLoc = new Point(locStartX, 0);
            dicValue["NAME"] = "cmd_LineNm_TXT";
            dicValue["TEXT"] = "Line";
            dicValue["BACK_COLOR"] = "WHITE";
            dicValue["FORE_COLOR"] = "BLACK";
            dicValue["TAG"] = "";
            cmdLine = createButton(dicValue, buttonLoc, lineTextButtonSize, lineTextButtonFont);
            pnControl.Controls.Add(cmdLine);
            
            //Assemblem
            foreach (DataRow row in argDt.Rows)
            {

                buttonLoc = new Point(locX, locY);
                dicValue["NAME"] = "cmd_" + row["LINE_CD"].ToString() + "_000" + "_" + area + "_" + "LNM";
                dicValue["TEXT"] = row["LINE_NM"].ToString();
                dicValue["BACK_COLOR"] = "NAVY";
                dicValue["FORE_COLOR"] = "WHITE";
                dicValue["TAG"] = "";
                cmdLine = createButton(dicValue, buttonLoc, lineButtonSize, buttonMlineFont);
                pnControl.Controls.Add(cmdLine);

                locX += lineButtonSize.Width + 5;

                buttonLoc = new Point(locX, locY);
                dicValue["NAME"] = "cmd_" + row["LINE_CD"].ToString() + "_000" + "_" + area + "_" + "STA";
                dicValue["TEXT"] = "";
                dicValue["BACK_COLOR"] = "GREEN";
                dicValue["FORE_COLOR"] = "WHITE";
                dicValue["TAG"] = row["LINE_CD"].ToString() + "_000" + "_" + area;
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
            dicValue["TAG"] = "";
            cmdLine = createButton(dicValue, buttonLoc, buttonSize, buttonLineFont);
            pnControl.Controls.Add(cmdLine);

            locStartY = locY += 10;
        }

        private void create_Line(Panel pnControl, DataTable argDt, int locStartX, int locStartY)
        {
            int locX = locStartX, locY = locStartY;
            Font lineTextButtonFont = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            Font buttonMlineFont = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            Font buttonLineFont = new System.Drawing.Font("Calibri", 40F, System.Drawing.FontStyle.Bold);
            Font buttonLineFont2 = new System.Drawing.Font("Calibri", 32F, System.Drawing.FontStyle.Bold);
            Point buttonLoc;
            Size buttonSize;
            Size lineTextButtonSize ;
            Size lineButtonSize = new System.Drawing.Size(60, 25);
            Size buttonStatusSize = new System.Drawing.Size(70, 25);
            Dictionary<string, string> dicValue = new Dictionary<string, string>();
            string lineCd, factory = argDt.Rows[0]["FACTORY"].ToString();
            int iNumLine;

            dicValue.Add("NAME", "");
            dicValue.Add("TEXT", "");
            dicValue.Add("BACK_COLOR", "");
            dicValue.Add("FORE_COLOR", "");
            dicValue.Add("TAG", "");
            Button cmdLine;

            //head line name
            buttonLoc = new Point(locStartX, 0);
            lineTextButtonSize = new System.Drawing.Size(lineButtonSize.Width, 35);
            dicValue["NAME"] = "cmd_LineNm" + factory + "_TXT";
            dicValue["TEXT"] = "Line";
            dicValue["BACK_COLOR"] = "WHITE";
            dicValue["FORE_COLOR"] = "BLACK";
            dicValue["TAG"] = "";

            cmdLine = createButton(dicValue, buttonLoc, lineTextButtonSize, lineTextButtonFont);
            pnControl.Controls.Add(cmdLine);

            //
            buttonLoc = new Point(buttonStatusSize.Width * 2 , 0);
            lineTextButtonSize = new System.Drawing.Size(buttonStatusSize.Width, 35);
            dicValue["NAME"] = "cmd_UPN" + factory + "_TXT";
            dicValue["TEXT"] = "Nosew";
            dicValue["TAG"] = "";
            cmdLine = createButton(dicValue, buttonLoc, lineTextButtonSize, lineTextButtonFont);
            pnControl.Controls.Add(cmdLine);

            buttonLoc = new Point(buttonStatusSize.Width * 3 + 5 , 0);
            lineTextButtonSize = new System.Drawing.Size(buttonStatusSize.Width, 35);
            dicValue["NAME"] = "cmd_FSS" + factory + "_TXT";
            dicValue["TEXT"] = "SF";
            dicValue["TAG"] = "";
            cmdLine = createButton(dicValue, buttonLoc, lineTextButtonSize, lineTextButtonFont);
            pnControl.Controls.Add(cmdLine);

            buttonLoc = new Point(buttonStatusSize.Width * 4 +10 , 0);
            lineTextButtonSize = new System.Drawing.Size(buttonStatusSize.Width, 35);
            dicValue["NAME"] = "cmd_FGA" + factory + "_TXT";
            dicValue["TEXT"] = "Assy";
            dicValue["TAG"] = "";
            cmdLine = createButton(dicValue, buttonLoc, lineTextButtonSize, lineTextButtonFont);
            pnControl.Controls.Add(cmdLine);

            

            foreach (DataRow row in argDt.Rows)
            {
                int.TryParse(row["NUM_FGA"].ToString(), out iNumLine);
                lineCd = row["LINE_CD"].ToString();

                int iStart = lineCd == "018_1" ? 4 : 0;
                //lineCd = lineCd.Replace("_1", "");
                for (int iLine = iStart + 1; iLine <= iStart + iNumLine; iLine++)
                {
                    buttonLoc = new Point(locX, locY);
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "MNM";
                    dicValue["TEXT"] = iLine.ToString();
                    dicValue["BACK_COLOR"] = "NAVY";
                    dicValue["FORE_COLOR"] = "WHITE";
                    dicValue["TAG"] = "";
                    cmdLine = createButton(dicValue, buttonLoc, lineButtonSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    locX += lineButtonSize.Width + 5;

                    //UPN
                    buttonLoc = new Point(locX, locY);
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "UPN" + "_" + "STA";
                    dicValue["TAG"] = lineCd + "_" + iLine.ToString("000") + "_" + "UPN";
                    dicValue["TEXT"] = "";
                    if (lineCd =="099")
                        dicValue["BACK_COLOR"] = "WHITE";
                    else
                        dicValue["BACK_COLOR"] = "GREEN";
                    
                    dicValue["FORE_COLOR"] = "WHITE";
                    cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    //FSS
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "FSS" + "_" + "STA";
                    dicValue["TAG"] = lineCd + "_" + iLine.ToString("000") + "_" + "FSS";
                    dicValue["BACK_COLOR"] = "GREEN";
                    buttonLoc = new Point(locX += buttonStatusSize.Width + 5, locY);
                    cmdLine = createButton(dicValue, buttonLoc, buttonStatusSize, buttonMlineFont);
                    pnControl.Controls.Add(cmdLine);

                    //FGA
                    dicValue["NAME"] = "cmd_" + lineCd + "_" + iLine.ToString("000") + "_" + "FGA" + "_" + "STA";
                    dicValue["TAG"] = lineCd + "_" + iLine.ToString("000") + "_" + "FGA";
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
                dicValue["TAG"] = "";

                if (dicValue["TEXT"].Count() > 1)
                {
                }

                cmdLine = createButton(dicValue, buttonLoc, buttonSize, dicValue["TEXT"].Count() > 1 ? buttonLineFont2 : buttonLineFont);
                pnControl.Controls.Add(cmdLine);

                locStartY = locY += 10;
            }
        }

        private Button createButton(Dictionary<string, string> value, Point location, Size size, Font font)
        {
            try 
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

                

                if (value["TAG"] != "")
                {
                    Button_Status con = new Button_Status();
                    con.button = cmd;
                    con.status = "GREEN";
                    _dicLine.Add(value["TAG"].ToString(), con);
                }
                return cmd;
	        }
	        catch (Exception)
	        {
		        return null;
		        
	        }
            
        }

        private void create_Factory(GroupBoxEx gpEx, string factory)
        {
            int iStartX = 32, iStartY = 49;
            int iLocX = iStartX, iLocY = iStartY;
            int iSizeW = 95, iSizeH = 93;
            string[] area = { "UPN", "FSS", "FGA" };
            for (int iPart = 1; iPart <= 3; iPart++)
            {
                createUcFactory(gpEx, factory + "_" + area[iPart-1], new Point(iLocX, iLocY), new Size(iSizeW, iSizeH));
                iLocX += iSizeW + 2;
            }
        }

        private void createUcFactory(GroupBoxEx gpEx, string tag , Point location, Size size)
        {
            UC.UC_Factory uC_Factory = new UC.UC_Factory();

            uC_Factory.BackColor = System.Drawing.Color.Transparent;
            uC_Factory.Location = location;
            uC_Factory.Size = size;
            uC_Factory.Tag = tag;
            
            gpEx.Controls.Add(uC_Factory);
            if (tag != "")
                _dicFac.Add(tag, uC_Factory);

            
        }



        #endregion Init Form

        #region set Data

        private void setData()
        {
            
            DataTable dt = Data_Select("");
            
            //reset color line
            foreach (var item in _dicLine)
            {
                if (item.Value.status != "GREEN")
                {
                    item.Value.status = "GREEN";
                    item.Value.button.BackColor = Color.Green;
                }
            }

            //reset color Factory
            foreach (var item in _dicFac)
            {
                if (item.Value._Color != "GREEN")
                {
                    item.Value._Color = "GREEN";
                    item.Value.setColor("GREEN");
                    item.Value.Visible = true;
                }
            }

            DataRow[] dr;
            Dictionary<string, string> dicStatus = new Dictionary<string,string>();
            string location;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                     dr = _dtMasterLine.Select("LINE_CD = '" + row["LINE_CD"].ToString()  + "'");
                    
                    location = dr[0][0] + "_" + row["OP_CD"];

                    

                    //Set color Line
                    if (_dicLine.ContainsKey(row["NAME_CONTROL"].ToString()))
                    {
                        _dicLine[row["NAME_CONTROL"].ToString()].status = row["STATUS"].ToString();
                        _dicLine[row["NAME_CONTROL"].ToString()].button.BackColor = Color.FromName(row["STATUS"].ToString());
                    }

                    //Set color Factory
                    if (_dicFac[location]._Color != "RED")
                    {
                        _dicFac[location].setColor(row["STATUS"].ToString()); 
                        _dicFac[location]._Color = row["STATUS"].ToString();                     
                    }


                    //if (dicStatus.ContainsKey(location))
                    //{
                    //    if (dicStatus[location] == "YELLOW" && row["STATUS"].ToString() == "RED")
                    //    {
                    //        dicStatus[location] = row["STATUS"].ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    dicStatus[location] = row["STATUS"].ToString();
                    //}
                }
                catch (Exception)
                {
                    throw;
                }
            }

            

            

            //_dicFac["F4_UPN"].setColor("YELLOW");
            //_dicFac["F4_FSS"].setColor("YELLOW");
            //_dicFac["F4_FGA"].setColor("YELLOW");

         //   _dicFac["F5_FSS"].setColor("YELLOW");
            
            

        }
        #endregion Set Data

        private void readFile()
        {

        }

        #region Button Line Click

        private void Button_Line_Click(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            string[] strArr = ctr.Name.Split('_');
            string path = @"vnc\" + strArr[1] + ".vnc";
            
            if(!System.IO.File.Exists(Application.StartupPath + "\\" + path)) return;
            try
            {
                Process startVNC = new Process();
                startVNC.StartInfo.FileName = path;
                startVNC.Start();
                //if (startVNC.Start())
                //{
                //    startVNC.WaitForInputIdle();
                //    System.Threading.Thread.Sleep(100);
                //    SendKeys.Send(@"Pop*2@19");
                //    System.Threading.Thread.Sleep(100);
                //    SendKeys.Send("{ENTER}");

                //    //startVNC.WaitForInputIdle();
                //    //SendKeys.Send("172.30.105.108:5995");
                //    //SendKeys.Send("{ENTER}");
                //    //startVNC.WaitForInputIdle();
                //    //System.Threading.Thread.Sleep(1000);
                //    //SendKeys.Send("Pop*2@19");
                //   // SendKeys.Send("{ENTER}");
                //}
            }
            catch (Exception ex)
            {
                ComVar.Var.writeToLog("Open VNC Error: " + ex.ToString());
            }
            
        }
        #endregion Button Line Click

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

        private DataTable Data_Select(string argType)
        {
            COM.OraDB MyOraDB = new COM.OraDB();

            MyOraDB.ReDim_Parameter(2);
            MyOraDB.Process_Name = "MES.PKG_SMT_SCADA_COCKPIT.MAIN_SELECT";

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
            if (_iReload == 60)
            {
                _iReload = 0;
                setData();
                
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

        private void cmdPm1_Click(object sender, EventArgs e)
        {
            ComVar.Var._IsBack = true;
            ComVar.Var.callForm = "617";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // ComVar.Var._IsBack = true;
           // ComVar.Var.callForm = "617";
            //string Path = @"vnc\013.vnc";
            ////string path2 = @"C:\Program Files\RealVNC\VNC Viewer\vncviewer.exe";

            //Process startVNC = new Process();

            //try 
            //{
            //    startVNC.StartInfo.FileName = Path;
            //    if (startVNC.Start())
            //    {
            //        startVNC.WaitForInputIdle();
            //        System.Threading.Thread.Sleep(100);
            //        SendKeys.Send(@"Pop*2@19");
            //        SendKeys.Send("{ENTER}");

            //        //startVNC.WaitForInputIdle();
            //        //SendKeys.Send("172.30.105.108:5995");
            //        //SendKeys.Send("{ENTER}");
            //        //startVNC.WaitForInputIdle();
            //        //System.Threading.Thread.Sleep(100);
            //        //SendKeys.Send("Pop*2@19");
            //        //SendKeys.Send("{ENTER}");
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}


        }

        private void tmrBlink_Tick(object sender, EventArgs e)
        {
            foreach (var item in _dicLine)
            {
                if (item.Value.status == "RED" && item.Value.button.BackColor == Color.Red)
                    item.Value.button.BackColor = Color.White;
                else if (item.Value.status == "RED" && item.Value.button.BackColor == Color.White)
                    item.Value.button.BackColor = Color.Red;
            }

            foreach (var item in _dicFac)
            {
                if (item.Value._Color == "RED" && item.Value.Visible)
                    item.Value.Visible = false;
                else if (item.Value._Color == "RED" && !item.Value.Visible)
                    item.Value.Visible = true;

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "minimized";
        }
    }



    public class Button_Status
    {
        public Button button;
        public string status;
    }
}
