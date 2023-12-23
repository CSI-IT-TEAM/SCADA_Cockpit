namespace FORM
{
    partial class FORM_SCADA_PPSM_DETAIL
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
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY4 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel7 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView7 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel8 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView8 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle4 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FORM_SCADA_PPSM_DETAIL));
            this.pnTop = new System.Windows.Forms.Panel();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new System.Windows.Forms.Label();
            this.tmrDate = new System.Windows.Forms.Timer();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.cmdBack = new System.Windows.Forms.Button();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView8)).BeginInit();
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
            this.lblHeader.Size = new System.Drawing.Size(1449, 110);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "PPSM && Equipment Malfunction By Factory";
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
            xyDiagram4.AxisX.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram4.AxisX.Title.Text = "Plant";
            xyDiagram4.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram4.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram4.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisY.GridLines.Visible = false;
            xyDiagram4.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram4.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram4.AxisY.Title.Text = "Alert Time  Sumarry / Working Time (%)";
            xyDiagram4.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram4.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram4.DefaultPane.BorderVisible = false;
            secondaryAxisY4.AxisID = 0;
            secondaryAxisY4.Name = "Secondary AxisY 1";
            secondaryAxisY4.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            secondaryAxisY4.Title.Text = "PPSM";
            secondaryAxisY4.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY4.VisibleInPanesSerializable = "-1";
            xyDiagram4.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY4});
            this.chartControl1.Diagram = xyDiagram4;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 110);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.RuntimeHitTesting = true;
            sideBySideBarSeriesLabel7.TextPattern = "{V}%";
            series7.Label = sideBySideBarSeriesLabel7;
            series7.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.Name = "Equipment Malfunction Ratio";
            sideBySideBarSeriesView7.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(32)))), ((int)(((byte)(96)))));
            sideBySideBarSeriesView7.Border.Thickness = 3;
            sideBySideBarSeriesView7.Border.Visibility = DevExpress.Utils.DefaultBoolean.False;
            sideBySideBarSeriesView7.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            sideBySideBarSeriesView7.Shadow.Visible = true;
            series7.View = sideBySideBarSeriesView7;
            sideBySideBarSeriesLabel8.TextPattern = "{V}%";
            series8.Label = sideBySideBarSeriesLabel8;
            series8.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series8.Name = "PPSM";
            sideBySideBarSeriesView8.AxisYName = "Secondary AxisY 1";
            sideBySideBarSeriesView8.Color = System.Drawing.Color.SteelBlue;
            sideBySideBarSeriesView8.Shadow.Visible = true;
            series8.View = sideBySideBarSeriesView8;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7,
        series8};
            this.chartControl1.Size = new System.Drawing.Size(1904, 931);
            this.chartControl1.TabIndex = 7;
            chartTitle4.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle4.Text = "Equipment malfunction Ratio & PPSM Ratio by Factory";
            chartTitle4.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle4});
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
            this.cmdBack.TabIndex = 101;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // FORM_SCADA_PPSM_DETAIL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.pnTop);
            this.Name = "FORM_SCADA_PPSM_DETAIL";
            this.Text = "FORM_SCADA_ABSENT_DETAIL";
            this.VisibleChanged += new System.EventHandler(this.FORM_SCADA_ABSENT_DETAIL_VisibleChanged);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
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