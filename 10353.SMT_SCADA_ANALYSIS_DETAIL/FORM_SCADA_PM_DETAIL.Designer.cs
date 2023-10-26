namespace FORM
{
    partial class FORM_SCADA_PM_DETAIL
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
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel4 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView4 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SCADA_PM_DETAIL));
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new System.Windows.Forms.Label();
            this.tmrDate = new System.Windows.Forms.Timer();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.cmdBack = new System.Windows.Forms.Button();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(95)))));
            this.pnTop.Controls.Add(this.cmdBack);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1904, 110);
            this.pnTop.TabIndex = 4;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.Appearance.Options.UseForeColor = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblHeader.Size = new System.Drawing.Size(1456, 110);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "PM Ratio && Equipment Malfunction By Plant";
            this.lblHeader.Click += new System.EventHandler(this.lblHeader_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1669, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(235, 110);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "2020-07-22\r\n10:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataBindings = null;
            xyDiagram2.AxisX.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram2.AxisX.Title.Text = "Plant";
            xyDiagram2.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.GridLines.Visible = false;
            xyDiagram2.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram2.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram2.AxisY.Title.Text = "Alert Time  Sumarry / Working Time (%)";
            xyDiagram2.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram2.DefaultPane.BorderVisible = false;
            secondaryAxisY2.AxisID = 0;
            secondaryAxisY2.Name = "Secondary AxisY 1";
            secondaryAxisY2.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            secondaryAxisY2.Title.Text = "PM Ratio (%)";
            secondaryAxisY2.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            xyDiagram2.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY2});
            this.chartControl1.Diagram = xyDiagram2;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 110);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.RuntimeHitTesting = true;
            sideBySideBarSeriesLabel3.TextPattern = "{V}%";
            series3.Label = sideBySideBarSeriesLabel3;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Equipment Malfunction Ratio";
            sideBySideBarSeriesView3.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(96)))));
            sideBySideBarSeriesView3.Border.Thickness = 3;
            sideBySideBarSeriesView3.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            sideBySideBarSeriesView3.Shadow.Visible = true;
            series3.View = sideBySideBarSeriesView3;
            sideBySideBarSeriesLabel4.TextPattern = "{V}%";
            series4.Label = sideBySideBarSeriesLabel4;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "PM Ratio";
            sideBySideBarSeriesView4.AxisYName = "Secondary AxisY 1";
            sideBySideBarSeriesView4.Color = System.Drawing.Color.SteelBlue;
            sideBySideBarSeriesView4.Shadow.Visible = true;
            series4.View = sideBySideBarSeriesView4;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3,
        series4};
            this.chartControl1.Size = new System.Drawing.Size(1904, 931);
            this.chartControl1.TabIndex = 7;
            chartTitle2.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle2.Text = "Equipment malfunction Ratio & PM Ratio by plant";
            chartTitle2.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdBack.BackgroundImage")));
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1542, 2);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(105, 105);
            this.cmdBack.TabIndex = 98;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FORM_SCADA_PM_DETAIL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.pnTop);
            this.Name = "FORM_SCADA_PM_DETAIL";
            this.Text = "FORM_SCADA_ABSENT_DETAIL";
            this.VisibleChanged += new System.EventHandler(this.FORM_SCADA_ABSENT_DETAIL_VisibleChanged);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Timer tmrDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        public System.Windows.Forms.Button cmdBack;
    }
}