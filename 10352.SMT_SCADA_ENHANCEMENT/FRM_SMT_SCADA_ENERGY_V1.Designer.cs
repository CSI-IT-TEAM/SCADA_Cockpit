namespace FORM
{
    partial class FRM_SMT_SCADA_ENERGY_V1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_SMT_SCADA_ENERGY_V1));
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation1 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation2 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction2 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation3 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation3 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction3 = new DevExpress.XtraCharts.SineEasingFunction();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new System.Windows.Forms.Button();
            this.pnInfoTotal = new System.Windows.Forms.Panel();
            this.advancedPanel3 = new FORM.AdvancedPanel();
            this.lblTotalProd = new System.Windows.Forms.Label();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.advancedPanel2 = new FORM.AdvancedPanel();
            this.lblAVG = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.advancedPanel1 = new FORM.AdvancedPanel();
            this.lblTotalKw = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnChart = new System.Windows.Forms.Panel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.grdView = new DevExpress.XtraGrid.GridControl();
            this.gvwView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.tblMain.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.pnInfoTotal.SuspendLayout();
            this.advancedPanel3.SuspendLayout();
            this.advancedPanel2.SuspendLayout();
            this.advancedPanel1.SuspendLayout();
            this.pnChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.pnHeader, 0, 0);
            this.tblMain.Controls.Add(this.pnInfoTotal, 0, 1);
            this.tblMain.Controls.Add(this.pnChart, 0, 2);
            this.tblMain.Controls.Add(this.pnGrid, 0, 3);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 4;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.99274F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.00726F));
            this.tblMain.Size = new System.Drawing.Size(1904, 1041);
            this.tblMain.TabIndex = 0;
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblHeader);
            this.pnHeader.Controls.Add(this.btnBack);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1898, 86);
            this.pnHeader.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1638, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(260, 86);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "2020-07-22\r\n10:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.LineVisible = true;
            this.lblHeader.Location = new System.Drawing.Point(89, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1543, 86);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Power Management Systems";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBack.BackgroundImage")));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 32.75F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Navy;
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(89, 86);
            this.btnBack.TabIndex = 90;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnInfoTotal
            // 
            this.pnInfoTotal.BackColor = System.Drawing.Color.White;
            this.pnInfoTotal.Controls.Add(this.advancedPanel3);
            this.pnInfoTotal.Controls.Add(this.advancedPanel2);
            this.pnInfoTotal.Controls.Add(this.advancedPanel1);
            this.pnInfoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInfoTotal.Location = new System.Drawing.Point(3, 95);
            this.pnInfoTotal.Name = "pnInfoTotal";
            this.pnInfoTotal.Size = new System.Drawing.Size(1898, 116);
            this.pnInfoTotal.TabIndex = 1;
            // 
            // advancedPanel3
            // 
            this.advancedPanel3.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel3.Controls.Add(this.lblTotalProd);
            this.advancedPanel3.Controls.Add(this.labelControl3);
            this.advancedPanel3.EdgeWidth = 2;
            this.advancedPanel3.EndColor = System.Drawing.Color.White;
            this.advancedPanel3.FlatBorderColor = System.Drawing.Color.Cyan;
            this.advancedPanel3.Location = new System.Drawing.Point(684, 6);
            this.advancedPanel3.Name = "advancedPanel3";
            this.advancedPanel3.RectRadius = 0;
            this.advancedPanel3.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel3.ShadowShift = 4;
            this.advancedPanel3.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel3.Size = new System.Drawing.Size(535, 110);
            this.advancedPanel3.StartColor = System.Drawing.Color.White;
            this.advancedPanel3.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel3.TabIndex = 6;
            // 
            // lblTotalProd
            // 
            this.lblTotalProd.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalProd.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTotalProd.Location = new System.Drawing.Point(3, 38);
            this.lblTotalProd.Name = "lblTotalProd";
            this.lblTotalProd.Size = new System.Drawing.Size(529, 55);
            this.lblTotalProd.TabIndex = 0;
            this.lblTotalProd.Text = "0 Prs";
            this.lblTotalProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelControl3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(529, 32);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Production Total";
            // 
            // advancedPanel2
            // 
            this.advancedPanel2.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel2.Controls.Add(this.lblAVG);
            this.advancedPanel2.Controls.Add(this.labelControl2);
            this.advancedPanel2.EdgeWidth = 2;
            this.advancedPanel2.EndColor = System.Drawing.Color.White;
            this.advancedPanel2.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.advancedPanel2.Location = new System.Drawing.Point(1249, 6);
            this.advancedPanel2.Name = "advancedPanel2";
            this.advancedPanel2.RectRadius = 0;
            this.advancedPanel2.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel2.ShadowShift = 4;
            this.advancedPanel2.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel2.Size = new System.Drawing.Size(535, 110);
            this.advancedPanel2.StartColor = System.Drawing.Color.White;
            this.advancedPanel2.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel2.TabIndex = 6;
            // 
            // lblAVG
            // 
            this.lblAVG.BackColor = System.Drawing.Color.Transparent;
            this.lblAVG.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAVG.Location = new System.Drawing.Point(3, 38);
            this.lblAVG.Name = "lblAVG";
            this.lblAVG.Size = new System.Drawing.Size(529, 55);
            this.lblAVG.TabIndex = 0;
            this.lblAVG.Text = "0 kWh/Prs";
            this.lblAVG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(529, 32);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Average Electric consumption/Prs";
            // 
            // advancedPanel1
            // 
            this.advancedPanel1.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel1.Controls.Add(this.lblTotalKw);
            this.advancedPanel1.Controls.Add(this.labelControl1);
            this.advancedPanel1.EdgeWidth = 2;
            this.advancedPanel1.EndColor = System.Drawing.Color.White;
            this.advancedPanel1.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.advancedPanel1.Location = new System.Drawing.Point(122, 6);
            this.advancedPanel1.Name = "advancedPanel1";
            this.advancedPanel1.RectRadius = 0;
            this.advancedPanel1.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel1.ShadowShift = 4;
            this.advancedPanel1.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel1.Size = new System.Drawing.Size(535, 110);
            this.advancedPanel1.StartColor = System.Drawing.Color.White;
            this.advancedPanel1.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel1.TabIndex = 0;
            // 
            // lblTotalKw
            // 
            this.lblTotalKw.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalKw.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTotalKw.Location = new System.Drawing.Point(3, 38);
            this.lblTotalKw.Name = "lblTotalKw";
            this.lblTotalKw.Size = new System.Drawing.Size(529, 55);
            this.lblTotalKw.TabIndex = 0;
            this.lblTotalKw.Text = "0 kWh";
            this.lblTotalKw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalKw.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(529, 32);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Electric consumption on yesterday";
            // 
            // pnChart
            // 
            this.pnChart.Controls.Add(this.chartControl1);
            this.pnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChart.Location = new System.Drawing.Point(3, 217);
            this.pnChart.Name = "pnChart";
            this.pnChart.Size = new System.Drawing.Size(1898, 638);
            this.pnChart.TabIndex = 2;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram1.AxisX.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram1.AxisX.Title.Text = "Plant";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridLines.Visible = false;
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Label.TextPattern = "{V:0.00}";
            xyDiagram1.AxisY.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "kWh/Prs";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.BorderVisible = false;
            xyDiagram1.DefaultPane.Shadow.Color = System.Drawing.Color.Silver;
            xyDiagram1.DefaultPane.Shadow.Size = 3;
            xyDiagram1.PaneDistance = 1;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.CrosshairLabelPattern = "{V:0.00}";
            pointSeriesLabel1.TextPattern = "{V:0.00}";
            series1.Label = pointSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Day";
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation1.BeginTime = System.TimeSpan.Parse("00:00:02");
            xySeriesUnwindAnimation1.Duration = System.TimeSpan.Parse("00:00:02.5000000");
            splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
            xyMarkerSlideAnimation1.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromRightBottomCorner;
            xyMarkerSlideAnimation1.EasingFunction = sineEasingFunction1;
            splineSeriesView1.SeriesPointAnimation = xyMarkerSlideAnimation1;
            splineSeriesView1.Shadow.Visible = true;
            series1.View = splineSeriesView1;
            series2.CrosshairLabelPattern = "{V:0.00}";
            pointSeriesLabel2.TextPattern = "{V:0.00}";
            series2.Label = pointSeriesLabel2;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Week";
            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation2.BeginTime = System.TimeSpan.Parse("00:00:03");
            xySeriesUnwindAnimation2.Duration = System.TimeSpan.Parse("00:00:02.5000000");
            splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation2;
            xyMarkerSlideAnimation2.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromTopCenter;
            xyMarkerSlideAnimation2.EasingFunction = sineEasingFunction2;
            splineSeriesView2.SeriesPointAnimation = xyMarkerSlideAnimation2;
            splineSeriesView2.Shadow.Visible = true;
            series2.View = splineSeriesView2;
            series3.CrosshairLabelPattern = "{V:0.00}";
            pointSeriesLabel3.TextPattern = "{V:0.00}";
            series3.Label = pointSeriesLabel3;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Month";
            splineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation3.BeginTime = System.TimeSpan.Parse("00:00:01");
            xySeriesUnwindAnimation3.Duration = System.TimeSpan.Parse("00:00:02.5000000");
            splineSeriesView3.SeriesAnimation = xySeriesUnwindAnimation3;
            xyMarkerSlideAnimation3.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromLeftBottomCorner;
            xyMarkerSlideAnimation3.EasingFunction = sineEasingFunction3;
            splineSeriesView3.SeriesPointAnimation = xyMarkerSlideAnimation3;
            splineSeriesView3.Shadow.Visible = true;
            series3.View = splineSeriesView3;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3};
            this.chartControl1.Size = new System.Drawing.Size(1898, 638);
            this.chartControl1.TabIndex = 0;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.grdView);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(3, 861);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1898, 177);
            this.pnGrid.TabIndex = 3;
            // 
            // grdView
            // 
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.Font = new System.Drawing.Font("Calibri", 12.75F);
            this.grdView.Location = new System.Drawing.Point(0, 0);
            this.grdView.MainView = this.gvwView;
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(1898, 177);
            this.grdView.TabIndex = 5;
            this.grdView.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwView});
            // 
            // gvwView
            // 
            this.gvwView.Appearance.BandPanel.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Bold);
            this.gvwView.Appearance.BandPanel.Options.UseFont = true;
            this.gvwView.Appearance.BandPanel.Options.UseTextOptions = true;
            this.gvwView.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.BandPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.Appearance.Row.Font = new System.Drawing.Font("Calibri", 13F);
            this.gvwView.Appearance.Row.Options.UseFont = true;
            this.gvwView.Appearance.Row.Options.UseTextOptions = true;
            this.gvwView.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwView.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gvwView.BandPanelRowHeight = 40;
            this.gvwView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvwView.ColumnPanelRowHeight = 40;
            this.gvwView.GridControl = this.grdView;
            this.gvwView.Name = "gvwView";
            this.gvwView.OptionsBehavior.Editable = false;
            this.gvwView.OptionsBehavior.ReadOnly = true;
            this.gvwView.OptionsCustomization.AllowColumnMoving = false;
            this.gvwView.OptionsCustomization.AllowFilter = false;
            this.gvwView.OptionsCustomization.AllowGroup = false;
            this.gvwView.OptionsView.ColumnAutoWidth = false;
            this.gvwView.OptionsView.ShowColumnHeaders = false;
            this.gvwView.OptionsView.ShowGroupPanel = false;
            this.gvwView.OptionsView.ShowIndicator = false;
            this.gvwView.RowHeight = 40;
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // FRM_SMT_SCADA_ENERGY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tblMain);
            this.Name = "FRM_SMT_SCADA_ENERGY";
            this.Load += new System.EventHandler(this.FRM_SMT_SCADA_ENERGY_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_SCADA_ENERGY_VisibleChanged);
            this.tblMain.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.pnInfoTotal.ResumeLayout(false);
            this.advancedPanel3.ResumeLayout(false);
            this.advancedPanel2.ResumeLayout(false);
            this.advancedPanel1.ResumeLayout(false);
            this.pnChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Panel pnHeader;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel pnInfoTotal;
        private AdvancedPanel advancedPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lblTotalKw;
        private AdvancedPanel advancedPanel2;
        private System.Windows.Forms.Label lblAVG;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Panel pnChart;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Panel pnGrid;
        private DevExpress.XtraGrid.GridControl grdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwView;
        public System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Timer tmr;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private AdvancedPanel advancedPanel3;
        private System.Windows.Forms.Label lblTotalProd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}