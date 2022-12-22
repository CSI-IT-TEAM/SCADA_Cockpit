namespace FORM.FRM
{
    partial class FRM_SCADA_TREND_CRL
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
            DevExpress.XtraCharts.XYDiagram xyDiagram5 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.ConstantLine constantLine3 = new DevExpress.XtraCharts.ConstantLine();
            DevExpress.XtraCharts.Series series7 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView3 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle7 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram6 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series8 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel3 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView3 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle8 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.Series series9 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel3 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView3 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle9 = new DevExpress.XtraCharts.ChartTitle();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.chartTrend = new DevExpress.XtraCharts.ChartControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.splBottom = new System.Windows.Forms.SplitContainer();
            this.chartBarTrend = new DevExpress.XtraCharts.ChartControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chartPercent = new DevExpress.XtraCharts.ChartControl();
            this.dispatcherTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splBottom)).BeginInit();
            this.splBottom.Panel1.SuspendLayout();
            this.splBottom.Panel2.SuspendLayout();
            this.splBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarTrend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).BeginInit();
            this.SuspendLayout();
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 0);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.chartTrend);
            this.splMain.Panel1.Controls.Add(this.labelControl5);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.splBottom);
            this.splMain.Size = new System.Drawing.Size(1904, 1041);
            this.splMain.SplitterDistance = 550;
            this.splMain.TabIndex = 0;
            // 
            // chartTrend
            // 
            this.chartTrend.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartTrend.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.False;
            this.chartTrend.DataBindings = null;
            xyDiagram5.AxisX.VisibleInPanesSerializable = "-1";
            constantLine3.AxisValueSerializable = "3";
            constantLine3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            constantLine3.LineStyle.Thickness = 3;
            constantLine3.Name = "Constant Line 1";
            xyDiagram5.AxisY.ConstantLines.AddRange(new DevExpress.XtraCharts.ConstantLine[] {
            constantLine3});
            xyDiagram5.AxisY.VisibleInPanesSerializable = "-1";
            this.chartTrend.Diagram = xyDiagram5;
            this.chartTrend.Legend.Name = "Default Legend";
            this.chartTrend.Location = new System.Drawing.Point(0, 57);
            this.chartTrend.Name = "chartTrend";
            series7.Name = "Series 1";
            lineSeriesView3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(96)))), ((int)(((byte)(146)))));
            lineSeriesView3.LineStyle.Thickness = 5;
            lineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series7.View = lineSeriesView3;
            this.chartTrend.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series7};
            this.chartTrend.Size = new System.Drawing.Size(1904, 422);
            this.chartTrend.TabIndex = 54;
            chartTitle7.Text = "Real time Inclination";
            chartTitle7.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartTrend.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle7});
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.LineVisible = true;
            this.labelControl5.Location = new System.Drawing.Point(9, 12);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(1883, 39);
            this.labelControl5.TabIndex = 53;
            this.labelControl5.Text = "REAL TIME INCLINATION";
            this.labelControl5.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // splBottom
            // 
            this.splBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBottom.Location = new System.Drawing.Point(0, 0);
            this.splBottom.Name = "splBottom";
            // 
            // splBottom.Panel1
            // 
            this.splBottom.Panel1.Controls.Add(this.chartBarTrend);
            this.splBottom.Panel1.Controls.Add(this.labelControl1);
            // 
            // splBottom.Panel2
            // 
            this.splBottom.Panel2.Controls.Add(this.labelControl2);
            this.splBottom.Panel2.Controls.Add(this.chartPercent);
            this.splBottom.Size = new System.Drawing.Size(1904, 487);
            this.splBottom.SplitterDistance = 1180;
            this.splBottom.TabIndex = 0;
            // 
            // chartBarTrend
            // 
            this.chartBarTrend.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartBarTrend.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartBarTrend.DataBindings = null;
            xyDiagram6.AxisX.NumericScaleOptions.AutoGrid = false;
            xyDiagram6.AxisX.Title.Text = "Temperature";
            xyDiagram6.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            xyDiagram6.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram6.AxisY.Title.Text = "Count";
            xyDiagram6.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram6.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram6.DefaultPane.BorderVisible = false;
            this.chartBarTrend.Diagram = xyDiagram6;
            this.chartBarTrend.Legend.Name = "Default Legend";
            this.chartBarTrend.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartBarTrend.Location = new System.Drawing.Point(15, 44);
            this.chartBarTrend.Name = "chartBarTrend";
            sideBySideBarSeriesLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            sideBySideBarSeriesLabel3.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            series8.Label = sideBySideBarSeriesLabel3;
            series8.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series8.Name = "Series 1";
            sideBySideBarSeriesView3.ColorEach = true;
            series8.View = sideBySideBarSeriesView3;
            this.chartBarTrend.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series8};
            this.chartBarTrend.Size = new System.Drawing.Size(1158, 370);
            this.chartBarTrend.TabIndex = 52;
            chartTitle8.Text = "Current Situation of Occupation";
            chartTitle8.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartBarTrend.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle8});
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(1161, 39);
            this.labelControl1.TabIndex = 53;
            this.labelControl1.Text = "CURRENT SITUATION OF OCCUPATION";
            this.labelControl1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(727, 39);
            this.labelControl2.TabIndex = 54;
            this.labelControl2.Text = "CURRENT SITUATION OF OCCUPATION OF PIECHART";
            this.labelControl2.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // chartPercent
            // 
            this.chartPercent.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartPercent.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartPercent.DataBindings = null;
            this.chartPercent.Legend.Name = "Default Legend";
            this.chartPercent.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartPercent.Location = new System.Drawing.Point(3, 44);
            this.chartPercent.Name = "chartPercent";
            pieSeriesLabel3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pieSeriesLabel3.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            pieSeriesLabel3.TextPattern = "{A}°C \n{VP:0.0%}";
            series9.Label = pieSeriesLabel3;
            series9.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series9.Name = "Series 1";
            series9.View = pieSeriesView3;
            this.chartPercent.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series9};
            this.chartPercent.Size = new System.Drawing.Size(724, 367);
            this.chartPercent.TabIndex = 53;
            chartTitle9.Text = "Current Situation of Occupation by Piechart";
            chartTitle9.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartPercent.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle9});
            // 
            // dispatcherTimer
            // 
            this.dispatcherTimer.Enabled = true;
            this.dispatcherTimer.Interval = 50;
            this.dispatcherTimer.Tick += new System.EventHandler(this.dispatcherTimer_Tick);
            // 
            // FRM_SCADA_TREND_CRL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splMain);
            this.Name = "FRM_SCADA_TREND_CRL";
            this.Text = "FRM_SCADA_TREND_ALL";
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrend)).EndInit();
            this.splBottom.Panel1.ResumeLayout(false);
            this.splBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBottom)).EndInit();
            this.splBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBarTrend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPercent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.SplitContainer splBottom;
        private DevExpress.XtraCharts.ChartControl chartTrend;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraCharts.ChartControl chartBarTrend;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraCharts.ChartControl chartPercent;
        private System.Windows.Forms.Timer dispatcherTimer;

    }
}