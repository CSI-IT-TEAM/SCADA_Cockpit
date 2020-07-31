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
    public partial class SMT_SCADA_COCKPIT_FORM3 : Form
    {
        public SMT_SCADA_COCKPIT_FORM3()
        {            
            InitializeComponent();
            initForm();
        }

        Dictionary<string, UC.UC_Machine> _dicLocation = new Dictionary<string, UC.UC_Machine>();

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

            string[] num_mline_upn = { "0", "0", "0", "0", "0", "0",
                                 "8", "8", "4", 
                                 "4", "4", "8", 
                                 "8", "8", "8", "8", "8",
                                 "4", "4", "4", "4"
                               };

            string[] num_mline_fss = { "0", "0", "0", "0", "0", "0",
                                 "4", "4", "4", 
                                 "4", "4", "8", 
                                 "8", "8", "8", "8", "8",
                                 "4", "4", "4", "4"
                               };

            string[] num_mline_fga = { "0", "0", "0", "0", "0", "0",
                                 "4", "4", "4", 
                                 "4", "4", "8", 
                                 "16", "16", "16", "16", "16",
                                 "4", "4", "4", "4"
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
                aPn1.Visible = false;
                panel2.Visible = false;
                

                //tblBody.Controls.Add(addImg("000", ImageLayout.Zoom), 1, 0);
                //tblBody.Controls.Add(addImg("000", ImageLayout.Zoom), 2, 0);
                //tblBody.Controls.Add(addImg("000", ImageLayout.Zoom), 3, 0);
                //tblBody.Controls.Add(addImg("000", ImageLayout.Zoom), 4, 0);
                //tblBody.Controls.Add(addImg("000", ImageLayout.Zoom), 5, 0);

                tblBody.Controls.Add(addImg("UPN", ImageLayout.Zoom), 0, 1);
                tblBody.Controls.Add(addImg("FSS", ImageLayout.Zoom), 0, 2);
                tblBody.Controls.Add(addImg("FGA", ImageLayout.Zoom), 0, 3);


                DataTable dt = createDatatableTest();

                DataTable dtFactory = dt.Select("FACTORY = 'F4'").CopyToDataTable();

                string lineName;
                for (int iRow = 0; iRow < 5; iRow++)
                {
                    lineName = dtFactory.Rows[iRow]["LINE_NM"].ToString();
                    tblBody.Controls.Add(createLineNameAndPicture(lineName), iRow + 1, 0);
                }

                initAPanel("F4", 1, dt);
                initAPanel("F4", 2, dt);
                initAPanel("F4", 3, dt);
               
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                
            }
        }

       




        private void initAPanel( string factory, int rowTableLayout, DataTable argDt)
        {
            DataTable dtFactory = argDt.Select("FACTORY = '" + factory + "'").CopyToDataTable();

            string line_cd;
            string area = rowTableLayout == 1 ? "UPN" : rowTableLayout == 2 ? "FSS" : "FGA";
            int maxColTableLayout = 5;
            int numberOfLine;
            for (int iLine = 0; iLine < dtFactory.Rows.Count; iLine++)
            {
                if (iLine >= maxColTableLayout) return;

                line_cd = dtFactory.Rows[iLine]["LINE_CD"].ToString();              
                int.TryParse( dtFactory.Rows[iLine]["NUM_" + area].ToString(), out numberOfLine);

                AdvancedPanel aPn = createPanel("aPn_" + line_cd + "_" + area);
                addLineInPanel(aPn, numberOfLine, area);
                tblBody.Controls.Add(aPn, iLine + 1, rowTableLayout);
            }
            
           // tblBody.Controls.Add(aPn1Upn, 1, 1);

            //AdvancedPanel aPnUpn = createPanel("aPn_" + factory + "_UPN", 8, 46, 300, 190);
            //AdvancedPanel aPnFss = createPanel("aPn_" + factory + "_FSS", 327, 46, 300, 190);
            //AdvancedPanel aPnFga = createPanel("aPn_" + factory + "_FGA", 8, 255, 619, 228);
            //aPnUpn.Controls.Add(createLabelName("lbl_" + factory + "_UPN", "No-Sew"));
            //aPnFss.Controls.Add(createLabelName("lbl_" + factory + "_FSS", "Stockfit"));
            //aPnFga.Controls.Add(createLabelName("lbl_" + factory + "_FGA", "Assembly"));

            //DataTable dtFactory = argDt.Select("FACTORY = '" + factory + "'").CopyToDataTable();
            //panelUpnAdd(aPnUpn, dtFactory);
            //panelFssAdd(aPnFss, dtFactory);
            //panelFgaAdd(aPnFga, dtFactory);

            //grpEx.Controls.Add(aPnUpn);
            //grpEx.Controls.Add(aPnFss);
            //grpEx.Controls.Add(aPnFga);
        }

        private AdvancedPanel createPanel(string namePanel)
        {
            AdvancedPanel aPanel = new FORM.AdvancedPanel();

            aPanel.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            aPanel.EdgeWidth = 1;
            aPanel.EndColor = System.Drawing.Color.White;
            aPanel.FlatBorderColor = System.Drawing.Color.DarkTurquoise;
            aPanel.ForeColor = System.Drawing.Color.Black;
            // aPanel.Location = new System.Drawing.Point(LocationXPanel, LocationYPanel);
            aPanel.Name = namePanel;
            aPanel.Dock = DockStyle.Fill;
            aPanel.Padding = new System.Windows.Forms.Padding(2);
            aPanel.RectRadius = 0;
            aPanel.ShadowColor = System.Drawing.Color.DimGray;
            aPanel.ShadowShift = 5;
            aPanel.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            // aPanel.Size = new System.Drawing.Size(widthPanel, heightPanel);
            aPanel.StartColor = System.Drawing.Color.White;
            aPanel.Style = FORM.AdvancedPanel.BevelStyle.Flat;

            return aPanel;
        }

        private void addLineInPanel(AdvancedPanel aPn, int numOfLine, string area)
        {
            int locStartX = 40;
            int locStartY =  40;
            int locX = locStartX, locY = locStartY;
            int widthButton = 65, heightButton = 60;
            int maxLineInRow = 4, iLine = 0;
            string buttonName, buttonText;

            for (int i = 0; i < numOfLine; i++)
            {
                iLine++;
                if (iLine > maxLineInRow)
                {
                    locY += heightButton + 5;
                    locX = locStartX;
                    iLine = 1;
                }
                buttonName = "cmd_" + (i + 1).ToString("000") + "_" + area;
                buttonText = (i + 1).ToString();
                Button btn = createLine(buttonName, buttonText, locX, locY, widthButton, heightButton);
                aPn.Controls.Add(btn);

                locX += widthButton + 5;
            }
        }

        private Button createLine(string nameButton, string textButton, int LocationXButton, int LocationYButton, int widthButton, int heightButton)
        {
            Button cmd = new Button();

            cmd.FlatAppearance.BorderSize = 0;
            cmd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmd.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            cmd.Location = new System.Drawing.Point(LocationXButton, LocationYButton);
            cmd.BackColor = Color.LimeGreen;
            cmd.ForeColor = Color.White;
            cmd.Name = nameButton;
            cmd.Size = new System.Drawing.Size(widthButton, heightButton);
            cmd.TabIndex = 0;
            cmd.Text = textButton;
            cmd.UseVisualStyleBackColor = true;

            return cmd;
        }

        private Panel createLineNameAndPicture(string text)
        {
            Panel pn = new Panel();
            pn.Dock = System.Windows.Forms.DockStyle.Fill;
            
            pn.Controls.Add(addImg("linePic", ImageLayout.Stretch));
            pn.Controls.Add(createLabelName("lbl" + text.Replace(" ", "_"), text));
            return pn;
        }

        private PictureBox addImg(string picName, ImageLayout type)
        {
            PictureBox pic = new PictureBox();
            pic.BackgroundImage = Image.FromFile(Application.StartupPath + @"\img\" + picName + ".png");
            pic.BackgroundImageLayout = type;
            pic.Dock = DockStyle.Left;
            pic.Size = new Size(170,91);

            return pic;
        }

        private Label createLabelName(string nameLabel, string textLabel)
        {
            Label lbl = new Label();

            lbl.Dock = System.Windows.Forms.DockStyle.Left;
            lbl.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new System.Drawing.Point(0, 0);
            lbl.ForeColor = Color.Navy;
            lbl.Name = nameLabel;
            lbl.Size = new System.Drawing.Size(110, 91);
            lbl.TabIndex = 0;
            lbl.Text = textLabel.Replace(" ","\n");
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            return lbl;
        }
       

        

/****************
 
 
 ***************/


        

        

        
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
        private void Button_Line_Click(string argName, string argArea)
        {
            MessageBox.Show(argArea + "|" + argName);
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
        }

        private void cmdBack_Click(object sender, EventArgs e)
        {
            ComVar.Var.callForm = "back";
        }

        


    }
}
