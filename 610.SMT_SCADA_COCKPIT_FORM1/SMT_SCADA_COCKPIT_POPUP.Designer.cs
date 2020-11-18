namespace FORM
{
    partial class SMT_SCADA_COCKPIT_POPUP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_COCKPIT_POPUP));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdMachine = new System.Windows.Forms.RadioButton();
            this.rdPmHis = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTxt2 = new System.Windows.Forms.Label();
            this.lblTxt1 = new System.Windows.Forms.Label();
            this.lblTxt3 = new System.Windows.Forms.Label();
            this.cmdWeek = new System.Windows.Forms.Button();
            this.cmdMonth = new System.Windows.Forms.Button();
            this.cmdDay = new System.Windows.Forms.Button();
            this.lblPage = new System.Windows.Forms.Label();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdPrev = new System.Windows.Forms.Button();
            this.pn_body = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SEQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WO_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WO_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DEFE_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLU_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_PIC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PM_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pn_body.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.99116F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.00884F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1428, 757);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.button1);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1422, 72);
            this.pnTop.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1274, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.lblHeader.Size = new System.Drawing.Size(1422, 72);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Equipment Malfunction Status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdMachine);
            this.panel1.Controls.Add(this.rdPmHis);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cmdWeek);
            this.panel1.Controls.Add(this.cmdMonth);
            this.panel1.Controls.Add(this.cmdDay);
            this.panel1.Controls.Add(this.lblPage);
            this.panel1.Controls.Add(this.cmdNext);
            this.panel1.Controls.Add(this.cmdPrev);
            this.panel1.Location = new System.Drawing.Point(3, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1422, 87);
            this.panel1.TabIndex = 4;
            // 
            // rdMachine
            // 
            this.rdMachine.AutoSize = true;
            this.rdMachine.Checked = true;
            this.rdMachine.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.rdMachine.Location = new System.Drawing.Point(1013, 46);
            this.rdMachine.Name = "rdMachine";
            this.rdMachine.Size = new System.Drawing.Size(185, 33);
            this.rdMachine.TabIndex = 20;
            this.rdMachine.TabStop = true;
            this.rdMachine.Text = "Machine Status";
            this.rdMachine.UseVisualStyleBackColor = true;
            this.rdMachine.CheckedChanged += new System.EventHandler(this.chkMachine_CheckedChanged);
            // 
            // rdPmHis
            // 
            this.rdPmHis.AutoSize = true;
            this.rdPmHis.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.rdPmHis.Location = new System.Drawing.Point(1245, 46);
            this.rdPmHis.Name = "rdPmHis";
            this.rdPmHis.Size = new System.Drawing.Size(65, 33);
            this.rdPmHis.TabIndex = 19;
            this.rdPmHis.Text = "PM";
            this.rdPmHis.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTxt2);
            this.panel2.Controls.Add(this.lblTxt1);
            this.panel2.Controls.Add(this.lblTxt3);
            this.panel2.Location = new System.Drawing.Point(208, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 78);
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
            this.lblTxt2.Size = new System.Drawing.Size(53, 22);
            this.lblTxt2.TabIndex = 12;
            this.lblTxt2.Text = "Text2";
            // 
            // lblTxt1
            // 
            this.lblTxt1.AutoSize = true;
            this.lblTxt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt1.ForeColor = System.Drawing.Color.White;
            this.lblTxt1.Location = new System.Drawing.Point(3, 6);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.Size = new System.Drawing.Size(53, 22);
            this.lblTxt1.TabIndex = 11;
            this.lblTxt1.Text = "Text1";
            // 
            // lblTxt3
            // 
            this.lblTxt3.AutoSize = true;
            this.lblTxt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt3.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt3.ForeColor = System.Drawing.Color.White;
            this.lblTxt3.Location = new System.Drawing.Point(3, 51);
            this.lblTxt3.Name = "lblTxt3";
            this.lblTxt3.Size = new System.Drawing.Size(53, 22);
            this.lblTxt3.TabIndex = 13;
            this.lblTxt3.Text = "Text3";
            // 
            // cmdWeek
            // 
            this.cmdWeek.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWeek.Location = new System.Drawing.Point(1146, 0);
            this.cmdWeek.Name = "cmdWeek";
            this.cmdWeek.Size = new System.Drawing.Size(137, 44);
            this.cmdWeek.TabIndex = 10;
            this.cmdWeek.Text = "Weekly";
            this.cmdWeek.UseVisualStyleBackColor = true;
            this.cmdWeek.Click += new System.EventHandler(this.cmdWeek_Click);
            // 
            // cmdMonth
            // 
            this.cmdMonth.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonth.Location = new System.Drawing.Point(1282, 0);
            this.cmdMonth.Name = "cmdMonth";
            this.cmdMonth.Size = new System.Drawing.Size(137, 44);
            this.cmdMonth.TabIndex = 9;
            this.cmdMonth.Text = "Monthly";
            this.cmdMonth.UseVisualStyleBackColor = true;
            this.cmdMonth.Click += new System.EventHandler(this.cmdMonth_Click);
            // 
            // cmdDay
            // 
            this.cmdDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDay.Location = new System.Drawing.Point(1010, 0);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new System.Drawing.Size(137, 44);
            this.cmdDay.TabIndex = 8;
            this.cmdDay.Text = "Daily";
            this.cmdDay.UseVisualStyleBackColor = true;
            this.cmdDay.Click += new System.EventHandler(this.cmDay_Click);
            // 
            // lblPage
            // 
            this.lblPage.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(68, 27);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(59, 31);
            this.lblPage.TabIndex = 7;
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNext
            // 
            this.cmdNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdNext.BackgroundImage")));
            this.cmdNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdNext.FlatAppearance.BorderSize = 0;
            this.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdNext.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.cmdNext.Location = new System.Drawing.Point(135, 12);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(60, 60);
            this.cmdNext.TabIndex = 6;
            this.cmdNext.UseVisualStyleBackColor = true;
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdPrev
            // 
            this.cmdPrev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdPrev.BackgroundImage")));
            this.cmdPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdPrev.FlatAppearance.BorderSize = 0;
            this.cmdPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPrev.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.cmdPrev.Location = new System.Drawing.Point(3, 12);
            this.cmdPrev.Name = "cmdPrev";
            this.cmdPrev.Size = new System.Drawing.Size(60, 60);
            this.cmdPrev.TabIndex = 5;
            this.cmdPrev.UseVisualStyleBackColor = true;
            this.cmdPrev.Click += new System.EventHandler(this.cmdPrev_Click);
            // 
            // pn_body
            // 
            this.pn_body.Controls.Add(this.gridControl1);
            this.pn_body.Controls.Add(this.chartControl1);
            this.pn_body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_body.Location = new System.Drawing.Point(3, 175);
            this.pn_body.Name = "pn_body";
            this.pn_body.Size = new System.Drawing.Size(1422, 579);
            this.pn_body.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1422, 579);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Visible = false;
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
            this.PM_DATE,
            this.DEFE_DATE,
            this.SOLU_DATE,
            this.PM_PIC,
            this.PM_STATUS});
            this.gridView1.GridControl = this.gridControl1;
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
            this.SEQ.Width = 55;
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
            this.WO_ID.Width = 249;
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
            this.WO_DATE.Visible = true;
            this.WO_DATE.VisibleIndex = 2;
            this.WO_DATE.Width = 150;
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
            // DEFE_DATE
            // 
            this.DEFE_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.DEFE_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEFE_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.DEFE_DATE.AppearanceHeader.Options.UseFont = true;
            this.DEFE_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.DEFE_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DEFE_DATE.Caption = "Start PM";
            this.DEFE_DATE.FieldName = "DEFE_DATE";
            this.DEFE_DATE.Name = "DEFE_DATE";
            this.DEFE_DATE.Visible = true;
            this.DEFE_DATE.VisibleIndex = 3;
            this.DEFE_DATE.Width = 155;
            // 
            // SOLU_DATE
            // 
            this.SOLU_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.SOLU_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SOLU_DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SOLU_DATE.AppearanceHeader.Options.UseFont = true;
            this.SOLU_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.SOLU_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SOLU_DATE.Caption = "End PM";
            this.SOLU_DATE.FieldName = "SOLU_DATE";
            this.SOLU_DATE.Name = "SOLU_DATE";
            this.SOLU_DATE.Visible = true;
            this.SOLU_DATE.VisibleIndex = 4;
            this.SOLU_DATE.Width = 150;
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
            // chartControl1
            // 
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "9";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "0";
            xyDiagram1.AxisY.GridLines.Visible = false;
            xyDiagram1.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.BackColor = System.Drawing.Color.White;
            xyDiagram1.EnableAxisXScrolling = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.CrosshairLabelPattern = "{V:#,#}";
            pointSeriesLabel1.TextPattern = "{V:#.0}";
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            lineSeriesView1.LineStyle.Thickness = 3;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1422, 579);
            this.chartControl1.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SMT_SCADA_COCKPIT_POPUP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1428, 757);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMT_SCADA_COCKPIT_POPUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pn_body.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cmdNext;
        private System.Windows.Forms.Button cmdPrev;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button cmdWeek;
        private System.Windows.Forms.Button cmdMonth;
        private System.Windows.Forms.Button cmdDay;
        private System.Windows.Forms.Label lblTxt1;
        private System.Windows.Forms.Label lblTxt3;
        private System.Windows.Forms.Label lblTxt2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pn_body;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SEQ;
        private DevExpress.XtraGrid.Columns.GridColumn WO_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn WO_ID;
        private DevExpress.XtraGrid.Columns.GridColumn PM_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn PM_PIC;
        private System.Windows.Forms.RadioButton rdMachine;
        private System.Windows.Forms.RadioButton rdPmHis;
        private DevExpress.XtraGrid.Columns.GridColumn DEFE_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn SOLU_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn PM_STATUS;
    }
}