namespace FORM
{
    partial class SMT_SCADA_B1CTM_TEMPER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_B1CTM_TEMPER));
            DevExpress.XtraCharts.XYDiagram xyDiagram3 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation3 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.XYDiagram xyDiagram4 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView4 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation4 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.a1Panel2 = new OS_DSF.A1Panel();
            this.chartCool = new DevExpress.XtraCharts.ChartControl();
            this.label2 = new System.Windows.Forms.Label();
            this.a1Panel1 = new OS_DSF.A1Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.chartHeat = new DevExpress.XtraCharts.ChartControl();
            this.pnTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.a1Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCool)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartHeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btnTest);
            this.pnTop.Controls.Add(this.cmdBack);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1904, 76);
            this.pnTop.TabIndex = 8;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(855, 19);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 89;
            this.btnTest.Text = "button1";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdBack.BackgroundImage")));
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.cmdBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Font = new System.Drawing.Font("Calibri", 32.75F, System.Drawing.FontStyle.Bold);
            this.cmdBack.ForeColor = System.Drawing.Color.Navy;
            this.cmdBack.Location = new System.Drawing.Point(3, 3);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(72, 70);
            this.cmdBack.TabIndex = 88;
            this.cmdBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1669, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(235, 76);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "2020-07-22\r\n10:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblHeader.Size = new System.Drawing.Size(1047, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        CTM Phylon Temperature Tracking";
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 6;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblMain.Location = new System.Drawing.Point(0, 76);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 10;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblMain.Size = new System.Drawing.Size(1236, 965);
            this.tblMain.TabIndex = 9;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.a1Panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.a1Panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1242, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(650, 965);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // a1Panel2
            // 
            this.a1Panel2.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel2.Controls.Add(this.chartCool);
            this.a1Panel2.Controls.Add(this.label2);
            this.a1Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel2.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(92)))));
            this.a1Panel2.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(92)))));
            this.a1Panel2.Image = null;
            this.a1Panel2.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel2.Location = new System.Drawing.Point(3, 485);
            this.a1Panel2.Name = "a1Panel2";
            this.a1Panel2.RoundCornerRadius = 20;
            this.a1Panel2.Size = new System.Drawing.Size(644, 477);
            this.a1Panel2.TabIndex = 1;
            // 
            // chartCool
            // 
            this.chartCool.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartCool.AppearanceNameSerializable = "Dark Flat";
            this.chartCool.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartCool.DataBindings = null;
            xyDiagram3.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram3.AxisY.GridLines.Visible = false;
            xyDiagram3.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram3.DefaultPane.BorderVisible = false;
            this.chartCool.Diagram = xyDiagram3;
            this.chartCool.Legend.Name = "Default Legend";
            this.chartCool.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartCool.Location = new System.Drawing.Point(5, 58);
            this.chartCool.Name = "chartCool";
            series3.Name = "Series 1";
            splineSeriesView3.Color = System.Drawing.Color.Cyan;
            splineSeriesView3.LineMarkerOptions.Size = 15;
            splineSeriesView3.LineStyle.Thickness = 3;
            splineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xyMarkerSlideAnimation3.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromBottomCenter;
            splineSeriesView3.SeriesPointAnimation = xyMarkerSlideAnimation3;
            splineSeriesView3.Shadow.Visible = true;
            series3.View = splineSeriesView3;
            this.chartCool.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartCool.Size = new System.Drawing.Size(627, 410);
            this.chartCool.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cool Temperature °C";
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.Color.Gray;
            this.a1Panel1.Controls.Add(this.label1);
            this.a1Panel1.Controls.Add(this.chartHeat);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel1.GradientEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(92)))));
            this.a1Panel1.GradientStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(51)))), ((int)(((byte)(92)))));
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 3);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 20;
            this.a1Panel1.Size = new System.Drawing.Size(644, 476);
            this.a1Panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Heat Temperature °C";
            // 
            // chartHeat
            // 
            this.chartHeat.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartHeat.AppearanceNameSerializable = "Dark Flat";
            this.chartHeat.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartHeat.DataBindings = null;
            xyDiagram4.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram4.AxisY.GridLines.Visible = false;
            xyDiagram4.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram4.DefaultPane.BorderVisible = false;
            this.chartHeat.Diagram = xyDiagram4;
            this.chartHeat.Legend.Name = "Default Legend";
            this.chartHeat.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartHeat.Location = new System.Drawing.Point(5, 51);
            this.chartHeat.Name = "chartHeat";
            series4.Name = "Series 1";
            splineSeriesView4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            splineSeriesView4.LineMarkerOptions.Size = 15;
            splineSeriesView4.LineStyle.Thickness = 3;
            splineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xyMarkerSlideAnimation4.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromTopCenter;
            splineSeriesView4.SeriesPointAnimation = xyMarkerSlideAnimation4;
            splineSeriesView4.Shadow.Visible = true;
            series4.View = splineSeriesView4;
            this.chartHeat.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4};
            this.chartHeat.Size = new System.Drawing.Size(627, 410);
            this.chartHeat.TabIndex = 0;
            // 
            // SMT_SCADA_B1CTM_TEMPER
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tblMain);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SMT_SCADA_B1CTM_TEMPER";
            this.Text = "SMT_SCADA_B1CTM_TEMPER";
            this.Load += new System.EventHandler(this.SMT_SCADA_B1CTM_TEMPER_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_B1CTM_TEMPER_VisibleChanged);
            this.pnTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.a1Panel2.ResumeLayout(false);
            this.a1Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCool)).EndInit();
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartHeat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private OS_DSF.A1Panel a1Panel1;
        private OS_DSF.A1Panel a1Panel2;
        private DevExpress.XtraCharts.ChartControl chartHeat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraCharts.ChartControl chartCool;
    }
}