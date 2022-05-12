﻿namespace FORM
{
    partial class FRM_SCADA_TRENDING
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.groupBoxEx1 = new FORM.GroupBoxEx();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtp_To = new DevExpress.XtraEditors.DateEdit();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pnHeader.SuspendLayout();
            this.pnMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            this.groupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.btnBack);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 90);
            this.pnHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::FORM.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(0, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 84);
            this.btnBack.TabIndex = 59;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(91, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1653, 82);
            this.lblTitle.TabIndex = 58;
            this.lblTitle.Text = "TRENDING TEMPERATURE";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1671, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(233, 90);
            this.lblDate.TabIndex = 57;
            this.lblDate.Text = "2019-09-19\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnMain.Controls.Add(this.chartControl1);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 0);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1467, 886);
            this.pnMain.TabIndex = 2;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.CrosshairOptions.CrosshairLabelMode = DevExpress.XtraCharts.CrosshairLabelMode.ShowForNearestSeries;
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Angle = -45;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Tahoma", 9.5F);
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.AllowRotate = false;
            xyDiagram1.AxisX.Label.ResolveOverlappingOptions.AllowStagger = false;
            xyDiagram1.AxisX.MinorCount = 1;
            xyDiagram1.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisX.NumericScaleOptions.GridSpacing = 0.1D;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 10F);
            xyDiagram1.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram1.AxisY.NumericScaleOptions.AutoGrid = false;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Calibri", 10F);
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Title.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.Title.Text = "Controller ID";
            this.chartControl1.Legend.Title.Visible = true;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.Padding.Bottom = 10;
            this.chartControl1.Padding.Left = 10;
            this.chartControl1.Padding.Right = 10;
            this.chartControl1.Padding.Top = 20;
            series1.CrosshairLabelPattern = "{S}:{V}";
            pointSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            pointSeriesLabel1.LineStyle.Thickness = 2;
            pointSeriesLabel1.LineVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Label = pointSeriesLabel1;
            series1.LegendName = "Default Legend";
            series1.Name = "Controller";
            series1.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1;
            series1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.Color = System.Drawing.Color.Blue;
            splineSeriesView1.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            splineSeriesView1.LineMarkerOptions.BorderVisible = false;
            splineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(73)))), ((int)(((byte)(122)))));
            splineSeriesView1.LineMarkerOptions.Size = 5;
            splineSeriesView1.LineStyle.Thickness = 5;
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            splineSeriesView1.Shadow.Size = 1;
            series1.View = splineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1467, 886);
            this.chartControl1.TabIndex = 1;
            chartTitle1.Alignment = System.Drawing.StringAlignment.Far;
            chartTitle1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "Controller ID";
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BackgroundPanelImage = null;
            this.groupBoxEx1.Controls.Add(this.btnSearch);
            this.groupBoxEx1.Controls.Add(this.dtp_To);
            this.groupBoxEx1.Controls.Add(this.cboArea);
            this.groupBoxEx1.Controls.Add(this.label2);
            this.groupBoxEx1.Controls.Add(this.cboLine);
            this.groupBoxEx1.Controls.Add(this.label6);
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxEx1.DrawGroupBorder = true;
            this.groupBoxEx1.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx1.GroupPanelColor = System.Drawing.Color.White;
            this.groupBoxEx1.GroupPanelShape = FORM.GroupBoxEx.PanelType.Rounded;
            this.groupBoxEx1.GroupPanelWith = 1F;
            this.groupBoxEx1.Location = new System.Drawing.Point(0, 90);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(1904, 65);
            this.groupBoxEx1.TabIndex = 1;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.TextBackColor = System.Drawing.Color.White;
            this.groupBoxEx1.TextBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx1.TextBorderWith = 1F;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::FORM.Properties.Resources.btnSearch;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(747, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(183, 53);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // dtp_To
            // 
            this.dtp_To.EditValue = null;
            this.dtp_To.Location = new System.Drawing.Point(78, 13);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtp_To.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.Appearance.Options.UseBackColor = true;
            this.dtp_To.Properties.Appearance.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.Button.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.Button.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.ButtonHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.ButtonHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.ButtonPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.ButtonPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.CalendarHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.CalendarHeader.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCell.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCell.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellDisabled.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellHoliday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellHoliday.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellInactive.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellInactive.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSelected.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecial.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecial.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialSelected.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellToday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellToday.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.HeaderPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.HeaderPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.WeekDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.WeekDay.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtp_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_To.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_To.Properties.CellSize = new System.Drawing.Size(70, 50);
            this.dtp_To.Properties.TodayDate = new System.DateTime(2019, 9, 24, 9, 47, 32, 0);
            this.dtp_To.Size = new System.Drawing.Size(190, 36);
            this.dtp_To.TabIndex = 17;
            // 
            // cboArea
            // 
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(550, 13);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(180, 36);
            this.cboArea.TabIndex = 12;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.cboArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(479, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLine
            // 
            this.cboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLine.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(354, 13);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(110, 36);
            this.cboLine.TabIndex = 11;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 36);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(283, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Line";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 155);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.chkAll);
            this.splitContainer.Panel1.Controls.Add(this.treeList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnMain);
            this.splitContainer.Size = new System.Drawing.Size(1904, 886);
            this.splitContainer.SplitterDistance = 433;
            this.splitContainer.TabIndex = 3;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(2, 6);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkAll.Properties.Appearance.Options.UseBackColor = true;
            this.chkAll.Properties.AutoHeight = false;
            this.chkAll.Properties.Caption = "";
            this.chkAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkAll.Size = new System.Drawing.Size(25, 28);
            this.chkAll.TabIndex = 19;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // treeList
            // 
            this.treeList.Appearance.Row.Font = new System.Drawing.Font("Calibri", 13F);
            this.treeList.Appearance.Row.Options.UseFont = true;
            this.treeList.BandPanelRowHeight = 40;
            this.treeList.BestFitVisibleOnly = true;
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.ColumnPanelRowHeight = 40;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.ID_NAME});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.ReadOnly = true;
            this.treeList.OptionsBehavior.ResizeNodes = false;
            this.treeList.OptionsCustomization.AllowBandMoving = false;
            this.treeList.OptionsCustomization.AllowColumnMoving = false;
            this.treeList.OptionsCustomization.AllowFilter = false;
            this.treeList.OptionsCustomization.AllowSort = false;
            this.treeList.OptionsFilter.AllowColumnMRUFilterList = false;
            this.treeList.OptionsFilter.AllowFilterEditor = false;
            this.treeList.OptionsFilter.AllowMRUFilterList = false;
            this.treeList.OptionsSelection.MultiSelect = true;
            this.treeList.OptionsView.AnimationType = DevExpress.XtraTreeList.TreeListAnimationType.AnimateAllContent;
            this.treeList.OptionsView.AutoWidth = false;
            this.treeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList.OptionsView.ShowCheckBoxes = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.Size = new System.Drawing.Size(433, 886);
            this.treeList.TabIndex = 0;
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
            this.treeList.NodeChanged += new DevExpress.XtraTreeList.NodeChangedEventHandler(this.treeList_NodeChanged);
            this.treeList.SelectionChanged += new System.EventHandler(this.treeList_SelectionChanged);
            this.treeList.CustomDrawColumnHeader += new DevExpress.XtraTreeList.CustomDrawColumnHeaderEventHandler(this.treeList_CustomDrawColumnHeader);
            this.treeList.CustomDrawNodeCheckBox += new DevExpress.XtraTreeList.CustomDrawNodeCheckBoxEventHandler(this.treeList_CustomDrawNodeCheckBox);
            this.treeList.CustomDrawNodeButton += new DevExpress.XtraTreeList.CustomDrawNodeButtonEventHandler(this.treeList_CustomDrawNodeButton);
            this.treeList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseUp);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Machine  -  Controller";
            this.treeListColumn1.FieldName = "MENU_NM";
            this.treeListColumn1.MinWidth = 34;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 416;
            // 
            // ID_NAME
            // 
            this.ID_NAME.Caption = "ID_NAME";
            this.ID_NAME.FieldName = "ID_NAME";
            this.ID_NAME.Name = "ID_NAME";
            // 
            // FRM_SCADA_TRENDING
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SCADA_TRENDING";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_SCADA_TRENDING";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_SCADA_TRENDING_Load);
            this.pnHeader.ResumeLayout(false);
            this.pnMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.groupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Label lblDate;
        private GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraEditors.DateEdit dtp_To;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Timer tmrDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_NAME;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}