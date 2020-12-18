namespace FORM
{
    partial class SMT_SCADA_ANALYSIS_MACHINE
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView2 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView4 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView5 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_ANALYSIS_MACHINE));
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.pnControl = new System.Windows.Forms.Panel();
            this.rdTop20 = new System.Windows.Forms.RadioButton();
            this.rdByDay = new System.Windows.Forms.RadioButton();
            this.chkCompare = new System.Windows.Forms.CheckBox();
            this.cmdWeek = new System.Windows.Forms.Button();
            this.cmdMonth = new System.Windows.Forms.Button();
            this.cmdDay = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnExport = new System.Windows.Forms.Panel();
            this.tlsLoction = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.timer1 = new System.Windows.Forms.Timer();
            this.pnBody1 = new System.Windows.Forms.Panel();
            this.pnChart = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView5)).BeginInit();
            this.pnControl.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pnExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlsLoction)).BeginInit();
            this.pnBody1.SuspendLayout();
            this.pnChart.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.AppearanceNameSerializable = "Light";
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisX.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisX.Title.Text = "Location";
            xyDiagram1.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.MinorCount = 1;
            xyDiagram1.AxisY.Tickmarks.Visible = false;
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "Issue Times (Count)";
            xyDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.WholeRange.AutoSideMargins = false;
            xyDiagram1.AxisY.WholeRange.SideMarginsValue = 0.99D;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Tahoma", 18F);
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Mixed";
            this.chartControl1.PaletteRepository.Add("Palette 2", new DevExpress.XtraCharts.Palette("Palette 2", DevExpress.XtraCharts.PaletteScaleMode.Extrapolate, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(129)))), ((int)(((byte)(189))))), System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(90)))), ((int)(((byte)(136)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(80)))), ((int)(((byte)(77))))), System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(52)))), ((int)(((byte)(49)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(187)))), ((int)(((byte)(89))))), System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(137)))), ((int)(((byte)(56)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(100)))), ((int)(((byte)(162))))), System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(69)))), ((int)(((byte)(115)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70))))), System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(101)))), ((int)(((byte)(9))))))}));
            series1.CheckableInLegend = false;
            series1.CheckedInLegend = false;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Series 1";
            sideBySideBarSeriesView1.ColorEach = true;
            series1.View = sideBySideBarSeriesView1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Series 2";
            sideBySideBarSeriesView2.ColorEach = true;
            series2.View = sideBySideBarSeriesView2;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Series 3";
            sideBySideBarSeriesView3.ColorEach = true;
            series3.View = sideBySideBarSeriesView3;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Series 4";
            sideBySideBarSeriesView4.ColorEach = true;
            series4.View = sideBySideBarSeriesView4;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.Name = "Series 5";
            sideBySideBarSeriesView5.ColorEach = true;
            series5.View = sideBySideBarSeriesView5;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4,
        series5};
            this.chartControl1.Size = new System.Drawing.Size(1645, 916);
            this.chartControl1.TabIndex = 12;
            chartTitle1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "Top 20 Machine Have Many Issue";
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.chartControl1.CustomDrawCrosshair += new DevExpress.XtraCharts.CustomDrawCrosshairEventHandler(this.chartControl1_CustomDrawCrosshair);
            // 
            // pnControl
            // 
            this.pnControl.BackColor = System.Drawing.Color.Transparent;
            this.pnControl.Controls.Add(this.rdTop20);
            this.pnControl.Controls.Add(this.rdByDay);
            this.pnControl.Controls.Add(this.chkCompare);
            this.pnControl.Controls.Add(this.cmdWeek);
            this.pnControl.Controls.Add(this.cmdMonth);
            this.pnControl.Controls.Add(this.cmdDay);
            this.pnControl.Controls.Add(this.comboBox1);
            this.pnControl.Controls.Add(this.label1);
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnControl.Location = new System.Drawing.Point(0, 76);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(1888, 50);
            this.pnControl.TabIndex = 2;
            // 
            // rdTop20
            // 
            this.rdTop20.AutoSize = true;
            this.rdTop20.Checked = true;
            this.rdTop20.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.rdTop20.Location = new System.Drawing.Point(9, 7);
            this.rdTop20.Name = "rdTop20";
            this.rdTop20.Size = new System.Drawing.Size(203, 33);
            this.rdTop20.TabIndex = 18;
            this.rdTop20.TabStop = true;
            this.rdTop20.Text = "Issue By Machine";
            this.rdTop20.UseVisualStyleBackColor = true;
            this.rdTop20.Visible = false;
            // 
            // rdByDay
            // 
            this.rdByDay.AutoSize = true;
            this.rdByDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.rdByDay.Location = new System.Drawing.Point(241, 7);
            this.rdByDay.Name = "rdByDay";
            this.rdByDay.Size = new System.Drawing.Size(239, 33);
            this.rdByDay.TabIndex = 17;
            this.rdByDay.Text = "Issue Average By Day";
            this.rdByDay.UseVisualStyleBackColor = true;
            this.rdByDay.Visible = false;
            // 
            // chkCompare
            // 
            this.chkCompare.AutoSize = true;
            this.chkCompare.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.chkCompare.Location = new System.Drawing.Point(901, 9);
            this.chkCompare.Name = "chkCompare";
            this.chkCompare.Size = new System.Drawing.Size(124, 33);
            this.chkCompare.TabIndex = 16;
            this.chkCompare.Text = "Compare";
            this.chkCompare.UseVisualStyleBackColor = true;
            this.chkCompare.Visible = false;
            // 
            // cmdWeek
            // 
            this.cmdWeek.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdWeek.Location = new System.Drawing.Point(1600, 4);
            this.cmdWeek.Name = "cmdWeek";
            this.cmdWeek.Size = new System.Drawing.Size(137, 44);
            this.cmdWeek.TabIndex = 7;
            this.cmdWeek.Text = "Weekly";
            this.cmdWeek.UseVisualStyleBackColor = true;
            this.cmdWeek.Click += new System.EventHandler(this.cmdWeek_Click);
            // 
            // cmdMonth
            // 
            this.cmdMonth.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMonth.Location = new System.Drawing.Point(1736, 4);
            this.cmdMonth.Name = "cmdMonth";
            this.cmdMonth.Size = new System.Drawing.Size(137, 44);
            this.cmdMonth.TabIndex = 6;
            this.cmdMonth.Text = "Monthly";
            this.cmdMonth.UseVisualStyleBackColor = true;
            this.cmdMonth.Click += new System.EventHandler(this.cmdMonth_Click);
            // 
            // cmdDay
            // 
            this.cmdDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDay.Location = new System.Drawing.Point(1464, 4);
            this.cmdDay.Name = "cmdDay";
            this.cmdDay.Size = new System.Drawing.Size(137, 44);
            this.cmdDay.TabIndex = 5;
            this.cmdDay.Text = "Daily";
            this.cmdDay.UseVisualStyleBackColor = true;
            this.cmdDay.Click += new System.EventHandler(this.cmDay_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Weekly",
            "Monthly",
            "Quaterly"});
            this.comboBox1.Location = new System.Drawing.Point(1202, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(205, 41);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1061, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Period";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.cmdBack);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1888, 76);
            this.pnTop.TabIndex = 2;
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdBack.BackgroundImage")));
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Font = new System.Drawing.Font("Calibri", 32.75F, System.Drawing.FontStyle.Bold);
            this.cmdBack.ForeColor = System.Drawing.Color.Navy;
            this.cmdBack.Location = new System.Drawing.Point(3, 3);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(77, 70);
            this.cmdBack.TabIndex = 88;
            this.cmdBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1653, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(235, 76);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "2020-07-22\r\n10:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.LineVisible = true;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1622, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        Preventative Maintenance";
            // 
            // pnExport
            // 
            this.pnExport.Controls.Add(this.tlsLoction);
            this.pnExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnExport.Location = new System.Drawing.Point(0, 0);
            this.pnExport.Name = "pnExport";
            this.pnExport.Size = new System.Drawing.Size(243, 916);
            this.pnExport.TabIndex = 77;
            // 
            // tlsLoction
            // 
            this.tlsLoction.Appearance.Row.Font = new System.Drawing.Font("Calibri", 13F);
            this.tlsLoction.Appearance.Row.Options.UseFont = true;
            this.tlsLoction.BandPanelRowHeight = 40;
            this.tlsLoction.BestFitVisibleOnly = true;
            this.tlsLoction.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlsLoction.ColumnPanelRowHeight = 40;
            this.tlsLoction.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.ID_NAME});
            this.tlsLoction.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlsLoction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlsLoction.Location = new System.Drawing.Point(0, 0);
            this.tlsLoction.Name = "tlsLoction";
            this.tlsLoction.OptionsBehavior.AllowExpandOnDblClick = false;
            this.tlsLoction.OptionsBehavior.Editable = false;
            this.tlsLoction.OptionsBehavior.ReadOnly = true;
            this.tlsLoction.OptionsBehavior.ResizeNodes = false;
            this.tlsLoction.OptionsCustomization.AllowBandMoving = false;
            this.tlsLoction.OptionsCustomization.AllowColumnMoving = false;
            this.tlsLoction.OptionsFilter.AllowColumnMRUFilterList = false;
            this.tlsLoction.OptionsFilter.AllowFilterEditor = false;
            this.tlsLoction.OptionsFilter.AllowMRUFilterList = false;
            this.tlsLoction.OptionsSelection.MultiSelect = true;
            this.tlsLoction.OptionsView.AnimationType = DevExpress.XtraTreeList.TreeListAnimationType.AnimateAllContent;
            this.tlsLoction.OptionsView.AutoWidth = false;
            this.tlsLoction.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.tlsLoction.OptionsView.ShowCheckBoxes = true;
            this.tlsLoction.OptionsView.ShowIndicator = false;
            this.tlsLoction.Size = new System.Drawing.Size(243, 916);
            this.tlsLoction.TabIndex = 1;
            this.tlsLoction.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.tlsLoction_NodeCellStyle);
            this.tlsLoction.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.tlsLoction_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.Caption = "Location";
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
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnBody1
            // 
            this.pnBody1.Controls.Add(this.pnChart);
            this.pnBody1.Controls.Add(this.pnExport);
            this.pnBody1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBody1.Location = new System.Drawing.Point(0, 126);
            this.pnBody1.Name = "pnBody1";
            this.pnBody1.Size = new System.Drawing.Size(1888, 916);
            this.pnBody1.TabIndex = 3;
            // 
            // pnChart
            // 
            this.pnChart.Controls.Add(this.chartControl1);
            this.pnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChart.Location = new System.Drawing.Point(243, 0);
            this.pnChart.Name = "pnChart";
            this.pnChart.Size = new System.Drawing.Size(1645, 916);
            this.pnChart.TabIndex = 78;
            // 
            // SMT_SCADA_ANALYSIS_MACHINE
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1888, 1042);
            this.Controls.Add(this.pnBody1);
            this.Controls.Add(this.pnControl);
            this.Controls.Add(this.pnTop);
            this.Name = "SMT_SCADA_ANALYSIS_MACHINE";
            this.Text = "SMT_SCADA_COCKPIT_FORM2";
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.pnControl.ResumeLayout(false);
            this.pnControl.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlsLoction)).EndInit();
            this.pnBody1.ResumeLayout(false);
            this.pnChart.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnControl;
        private System.Windows.Forms.Button cmdWeek;
        private System.Windows.Forms.Button cmdMonth;
        private System.Windows.Forms.Button cmdDay;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Panel pnExport;
        private System.Windows.Forms.Panel pnBody1;
        private System.Windows.Forms.Panel pnChart;
        private System.Windows.Forms.CheckBox chkCompare;
        private System.Windows.Forms.RadioButton rdTop20;
        private System.Windows.Forms.RadioButton rdByDay;
        private DevExpress.XtraTreeList.TreeList tlsLoction;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_NAME;
    }
}