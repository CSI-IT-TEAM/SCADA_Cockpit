using System.Threading.Tasks;

namespace FORM
{
    partial class SMT_SCADA_POPUP_INFOR
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode4 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTxt2 = new System.Windows.Forms.Label();
            this.lblTxt1 = new System.Windows.Forms.Label();
            this.lblTxt3 = new System.Windows.Forms.Label();
            this.pn_body = new System.Windows.Forms.Panel();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.PM = new DevExpress.XtraTab.XtraTabPage();
            this.gridPM = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_PIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REPAIR = new DevExpress.XtraTab.XtraTabPage();
            this.gridRepair = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SEQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WO_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.REQUEST_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEFE_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLU_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEFE_CD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.MOVE = new DevExpress.XtraTab.XtraTabPage();
            this.gridMove = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pn_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.PM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.REPAIR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRepair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.MOVE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pn_body, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.51865F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.48135F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1384, 641);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1378, 72);
            this.pnTop.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.LineVisible = true;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1378, 72);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Machine Information";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1378, 86);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTxt2);
            this.panel2.Controls.Add(this.lblTxt1);
            this.panel2.Controls.Add(this.lblTxt3);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 80);
            this.panel2.TabIndex = 14;
            // 
            // lblTxt2
            // 
            this.lblTxt2.AutoSize = true;
            this.lblTxt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt2.ForeColor = System.Drawing.Color.White;
            this.lblTxt2.Location = new System.Drawing.Point(3, 28);
            this.lblTxt2.Name = "lblTxt2";
            this.lblTxt2.Size = new System.Drawing.Size(90, 22);
            this.lblTxt2.TabIndex = 12;
            this.lblTxt2.Text = "                ";
            // 
            // lblTxt1
            // 
            this.lblTxt1.AutoSize = true;
            this.lblTxt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt1.ForeColor = System.Drawing.Color.White;
            this.lblTxt1.Location = new System.Drawing.Point(3, 6);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.Size = new System.Drawing.Size(60, 22);
            this.lblTxt1.TabIndex = 11;
            this.lblTxt1.Text = "          ";
            // 
            // lblTxt3
            // 
            this.lblTxt3.AutoSize = true;
            this.lblTxt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt3.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt3.ForeColor = System.Drawing.Color.White;
            this.lblTxt3.Location = new System.Drawing.Point(3, 51);
            this.lblTxt3.Name = "lblTxt3";
            this.lblTxt3.Size = new System.Drawing.Size(60, 22);
            this.lblTxt3.TabIndex = 13;
            this.lblTxt3.Text = "          ";
            // 
            // pn_body
            // 
            this.pn_body.Controls.Add(this.tabControl);
            this.pn_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_body.Location = new System.Drawing.Point(3, 173);
            this.pn_body.Name = "pn_body";
            this.pn_body.Size = new System.Drawing.Size(1378, 465);
            this.pn_body.TabIndex = 5;
            // 
            // tabControl
            // 
            this.tabControl.AppearancePage.Header.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabControl.AppearancePage.Header.Options.UseFont = true;
            this.tabControl.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Calibri", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tabControl.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.LookAndFeel.SkinName = "VS2010";
            this.tabControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tabControl.Name = "tabControl";
            this.tabControl.PaintStyleName = "PropertyView";
            this.tabControl.SelectedTabPage = this.PM;
            this.tabControl.Size = new System.Drawing.Size(1378, 465);
            this.tabControl.TabIndex = 51;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.REPAIR,
            this.PM,
            this.MOVE});
            this.tabControl.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.tabControl_SelectedPageChanged);
            // 
            // PM
            // 
            this.PM.Controls.Add(this.gridPM);
            this.PM.Name = "PM";
            this.PM.Size = new System.Drawing.Size(1376, 421);
            this.PM.Text = "   Smart Machine Check Schedule     ";
            // 
            // gridPM
            // 
            this.gridPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPM.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode3.RelationName = "Level1";
            this.gridPM.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode3});
            this.gridPM.Location = new System.Drawing.Point(0, 0);
            this.gridPM.MainView = this.gridView2;
            this.gridPM.Name = "gridPM";
            this.gridPM.Size = new System.Drawing.Size(1376, 421);
            this.gridPM.TabIndex = 5;
            this.gridPM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.ColumnPanelRowHeight = 50;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.PM_DATE,
            this.gridColumn4,
            this.gridColumn5,
            this.PM_PIC,
            this.PM_STATUS});
            this.gridView2.GridControl = this.gridPM;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsCustomization.AllowColumnMoving = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsCustomization.AllowGroup = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            this.gridView2.RowHeight = 50;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "No";
            this.gridColumn1.FieldName = "SEQ";
            this.gridColumn1.FieldNameSortGroup = "SEQ";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 55;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "W/O ID";
            this.gridColumn2.FieldName = "WO_ID";
            this.gridColumn2.FieldNameSortGroup = "WO_ID";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 249;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "W/O Date";
            this.gridColumn3.FieldName = "WO_DATE";
            this.gridColumn3.FieldNameSortGroup = "WO_DATE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 150;
            // 
            // PM_DATE
            // 
            this.PM_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.PM_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PM_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.PM_DATE.AppearanceHeader.Options.UseFont = true;
            this.PM_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.PM_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PM_DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PM_DATE.Caption = "PM Plan Date";
            this.PM_DATE.FieldName = "PM_DATE";
            this.PM_DATE.FieldNameSortGroup = "PM_DATE";
            this.PM_DATE.Name = "PM_DATE";
            this.PM_DATE.Visible = true;
            this.PM_DATE.VisibleIndex = 5;
            this.PM_DATE.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Start PM";
            this.gridColumn4.FieldName = "DEFE_DATE";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 155;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "End PM";
            this.gridColumn5.FieldName = "SOLU_DATE";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 150;
            // 
            // PM_PIC
            // 
            this.PM_PIC.AppearanceCell.Options.UseTextOptions = true;
            this.PM_PIC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PM_PIC.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.PM_PIC.AppearanceHeader.Options.UseFont = true;
            this.PM_PIC.AppearanceHeader.Options.UseTextOptions = true;
            this.PM_PIC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PM_PIC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PM_PIC.Caption = "PM Pic";
            this.PM_PIC.FieldName = "PM_PIC";
            this.PM_PIC.FieldNameSortGroup = "PM_PIC";
            this.PM_PIC.Name = "PM_PIC";
            this.PM_PIC.Visible = true;
            this.PM_PIC.VisibleIndex = 6;
            this.PM_PIC.Width = 330;
            // 
            // PM_STATUS
            // 
            this.PM_STATUS.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.PM_STATUS.AppearanceHeader.Options.UseFont = true;
            this.PM_STATUS.AppearanceHeader.Options.UseTextOptions = true;
            this.PM_STATUS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PM_STATUS.Caption = "PM Status";
            this.PM_STATUS.FieldName = "PM_STATUS";
            this.PM_STATUS.Name = "PM_STATUS";
            this.PM_STATUS.Visible = true;
            this.PM_STATUS.VisibleIndex = 7;
            this.PM_STATUS.Width = 181;
            // 
            // REPAIR
            // 
            this.REPAIR.Controls.Add(this.gridRepair);
            this.REPAIR.Name = "REPAIR";
            this.REPAIR.Size = new System.Drawing.Size(1376, 421);
            this.REPAIR.Text = "     Repair         ";
            // 
            // gridRepair
            // 
            this.gridRepair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRepair.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode4.RelationName = "Level1";
            this.gridRepair.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode4});
            this.gridRepair.Location = new System.Drawing.Point(0, 0);
            this.gridRepair.MainView = this.gridView1;
            this.gridRepair.Name = "gridRepair";
            this.gridRepair.Size = new System.Drawing.Size(1376, 421);
            this.gridRepair.TabIndex = 5;
            this.gridRepair.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SEQ,
            this.WO_ID,
            this.WO_DATE,
            this.REQUEST_DATE,
            this.DEFE_DATE,
            this.SOLU_DATE,
            this.DEFE_CD,
            this.PIC});
            this.gridView1.GridControl = this.gridRepair;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 50;
            // 
            // SEQ
            // 
            this.SEQ.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SEQ.AppearanceHeader.Options.UseFont = true;
            this.SEQ.AppearanceHeader.Options.UseTextOptions = true;
            this.SEQ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SEQ.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SEQ.Caption = "No";
            this.SEQ.FieldName = "SEQ";
            this.SEQ.FieldNameSortGroup = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.Visible = true;
            this.SEQ.VisibleIndex = 0;
            this.SEQ.Width = 41;
            // 
            // WO_ID
            // 
            this.WO_ID.AppearanceCell.Options.UseTextOptions = true;
            this.WO_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WO_ID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.WO_ID.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.WO_ID.AppearanceHeader.Options.UseFont = true;
            this.WO_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.WO_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WO_ID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.WO_ID.Caption = "W/O ID";
            this.WO_ID.FieldName = "WO_ID";
            this.WO_ID.FieldNameSortGroup = "WO_ID";
            this.WO_ID.Name = "WO_ID";
            this.WO_ID.Visible = true;
            this.WO_ID.VisibleIndex = 1;
            this.WO_ID.Width = 230;
            // 
            // WO_DATE
            // 
            this.WO_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.WO_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WO_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.WO_DATE.AppearanceHeader.Options.UseFont = true;
            this.WO_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.WO_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.WO_DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.WO_DATE.Caption = "W/O Date";
            this.WO_DATE.FieldName = "WO_DATE";
            this.WO_DATE.FieldNameSortGroup = "WO_DATE";
            this.WO_DATE.Name = "WO_DATE";
            this.WO_DATE.Width = 160;
            // 
            // REQUEST_DATE
            // 
            this.REQUEST_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.REQUEST_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.REQUEST_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.REQUEST_DATE.AppearanceHeader.Options.UseFont = true;
            this.REQUEST_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.REQUEST_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.REQUEST_DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.REQUEST_DATE.Caption = "Request Date";
            this.REQUEST_DATE.FieldName = "REQUEST_DATE";
            this.REQUEST_DATE.FieldNameSortGroup = "PM_DATE";
            this.REQUEST_DATE.Name = "REQUEST_DATE";
            this.REQUEST_DATE.Visible = true;
            this.REQUEST_DATE.VisibleIndex = 2;
            this.REQUEST_DATE.Width = 209;
            // 
            // DEFE_DATE
            // 
            this.DEFE_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.DEFE_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEFE_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.DEFE_DATE.AppearanceHeader.Options.UseFont = true;
            this.DEFE_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.DEFE_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEFE_DATE.Caption = "Start Repair";
            this.DEFE_DATE.FieldName = "DEFE_DATE";
            this.DEFE_DATE.Name = "DEFE_DATE";
            this.DEFE_DATE.Visible = true;
            this.DEFE_DATE.VisibleIndex = 3;
            this.DEFE_DATE.Width = 215;
            // 
            // SOLU_DATE
            // 
            this.SOLU_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.SOLU_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SOLU_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SOLU_DATE.AppearanceHeader.Options.UseFont = true;
            this.SOLU_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.SOLU_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SOLU_DATE.Caption = "End Repair";
            this.SOLU_DATE.FieldName = "SOLU_DATE";
            this.SOLU_DATE.Name = "SOLU_DATE";
            this.SOLU_DATE.Visible = true;
            this.SOLU_DATE.VisibleIndex = 4;
            this.SOLU_DATE.Width = 214;
            // 
            // DEFE_CD
            // 
            this.DEFE_CD.AppearanceCell.Options.UseTextOptions = true;
            this.DEFE_CD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.DEFE_CD.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.DEFE_CD.AppearanceHeader.Options.UseFont = true;
            this.DEFE_CD.AppearanceHeader.Options.UseTextOptions = true;
            this.DEFE_CD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEFE_CD.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DEFE_CD.Caption = "Broken";
            this.DEFE_CD.FieldName = "DEFE_CD";
            this.DEFE_CD.Name = "DEFE_CD";
            this.DEFE_CD.Visible = true;
            this.DEFE_CD.VisibleIndex = 5;
            this.DEFE_CD.Width = 206;
            // 
            // PIC
            // 
            this.PIC.AppearanceCell.Options.UseTextOptions = true;
            this.PIC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.PIC.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.PIC.AppearanceHeader.Options.UseFont = true;
            this.PIC.AppearanceHeader.Options.UseTextOptions = true;
            this.PIC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PIC.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.PIC.Caption = "PIC";
            this.PIC.FieldName = "PIC";
            this.PIC.FieldNameSortGroup = "PIC";
            this.PIC.Name = "PIC";
            this.PIC.Visible = true;
            this.PIC.VisibleIndex = 6;
            this.PIC.Width = 259;
            // 
            // MOVE
            // 
            this.MOVE.Controls.Add(this.gridMove);
            this.MOVE.Name = "MOVE";
            this.MOVE.Size = new System.Drawing.Size(1376, 421);
            this.MOVE.Text = "    Move History     ";
            // 
            // gridMove
            // 
            this.gridMove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridMove.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.gridMove.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridMove.Location = new System.Drawing.Point(0, 0);
            this.gridMove.MainView = this.gridView3;
            this.gridMove.Name = "gridMove";
            this.gridMove.Size = new System.Drawing.Size(1376, 421);
            this.gridMove.TabIndex = 6;
            this.gridMove.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gridView3.Appearance.Row.Options.UseFont = true;
            this.gridView3.ColumnPanelRowHeight = 50;
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView3.GridControl = this.gridMove;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsBehavior.Editable = false;
            this.gridView3.OptionsBehavior.ReadOnly = true;
            this.gridView3.OptionsCustomization.AllowColumnMoving = false;
            this.gridView3.OptionsCustomization.AllowFilter = false;
            this.gridView3.OptionsCustomization.AllowGroup = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.OptionsView.ShowIndicator = false;
            this.gridView3.RowHeight = 50;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn6.Caption = "No";
            this.gridColumn6.FieldName = "SEQ";
            this.gridColumn6.FieldNameSortGroup = "SEQ";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 41;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn7.Caption = "W/O ID";
            this.gridColumn7.FieldName = "WO_ID";
            this.gridColumn7.FieldNameSortGroup = "WO_ID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 230;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn8.Caption = "W/O Date";
            this.gridColumn8.FieldName = "WO_DATE";
            this.gridColumn8.FieldNameSortGroup = "WO_DATE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 160;
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn9.Caption = "Request Date";
            this.gridColumn9.FieldName = "REQUEST_DATE";
            this.gridColumn9.FieldNameSortGroup = "PM_DATE";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 209;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn10.AppearanceHeader.Options.UseFont = true;
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Start Repair";
            this.gridColumn10.FieldName = "DEFE_DATE";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 215;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "End Repair";
            this.gridColumn11.FieldName = "SOLU_DATE";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 4;
            this.gridColumn11.Width = 214;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.Caption = "Broken";
            this.gridColumn12.FieldName = "DEFE_CD";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 5;
            this.gridColumn12.Width = 206;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn13.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn13.AppearanceHeader.Options.UseFont = true;
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn13.Caption = "PIC";
            this.gridColumn13.FieldName = "PIC";
            this.gridColumn13.FieldNameSortGroup = "PIC";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 6;
            this.gridColumn13.Width = 259;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SMT_SCADA_POPUP_INFOR
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1384, 641);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMT_SCADA_POPUP_INFOR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pn_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.PM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.REPAIR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRepair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.MOVE.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTxt1;
        private System.Windows.Forms.Label lblTxt3;
        private System.Windows.Forms.Label lblTxt2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pn_body;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage REPAIR;
        private DevExpress.XtraTab.XtraTabPage PM;
        private DevExpress.XtraGrid.GridControl gridRepair;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SEQ;
        private DevExpress.XtraGrid.Columns.GridColumn WO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn WO_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn REQUEST_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn DEFE_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn SOLU_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn DEFE_CD;
        private DevExpress.XtraGrid.Columns.GridColumn PIC;
        private DevExpress.XtraTab.XtraTabPage MOVE;
        private DevExpress.XtraGrid.GridControl gridPM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn PM_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn PM_PIC;
        private DevExpress.XtraGrid.Columns.GridColumn PM_STATUS;
        private DevExpress.XtraGrid.GridControl gridMove;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
    }
}