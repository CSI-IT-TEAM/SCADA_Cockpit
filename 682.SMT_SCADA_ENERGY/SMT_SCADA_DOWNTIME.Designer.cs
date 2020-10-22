namespace FORM
{
    partial class SMT_SCADA_DOWNTIME
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
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_DOWNTIME));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnMid = new System.Windows.Forms.Panel();
            this.tblChart = new System.Windows.Forms.TableLayoutPanel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDetail = new System.Windows.Forms.Button();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmdPm1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grdView = new DevExpress.XtraGrid.GridControl();
            this.gvwView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTxt2 = new System.Windows.Forms.Label();
            this.lblTxt1 = new System.Windows.Forms.Label();
            this.lblTxt3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnMid.SuspendLayout();
            this.tblChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnMid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.20834F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.79167F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1888, 1042);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pnMid
            // 
            this.pnMid.Controls.Add(this.tblChart);
            this.pnMid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMid.Location = new System.Drawing.Point(3, 85);
            this.pnMid.Name = "pnMid";
            this.pnMid.Size = new System.Drawing.Size(1882, 811);
            this.pnMid.TabIndex = 0;
            // 
            // tblChart
            // 
            this.tblChart.ColumnCount = 1;
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblChart.Controls.Add(this.chartControl1, 0, 1);
            this.tblChart.Controls.Add(this.panel1, 0, 0);
            this.tblChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblChart.Location = new System.Drawing.Point(0, 0);
            this.tblChart.Name = "tblChart";
            this.tblChart.RowCount = 2;
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tblChart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblChart.Size = new System.Drawing.Size(1882, 811);
            this.tblChart.TabIndex = 0;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnLoad;
            this.chartControl1.AppearanceNameSerializable = "Chameleon";
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Angle = -45;
            xyDiagram1.AxisX.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisX.Title.Text = "Machine";
            xyDiagram1.AxisX.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Tahoma", 20F);
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "Downtime (Second)";
            xyDiagram1.AxisY.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.Title.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            secondaryAxisY1.Title.Text = "Calling Times (Count)";
            secondaryAxisY1.Title.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            secondaryAxisY1.Title.Visibility = DevExpress.Utils.DefaultBoolean.Default;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Left;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Tahoma", 18F);
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.Location = new System.Drawing.Point(3, 97);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Marquee";
            sideBySideBarSeriesLabel1.Position = DevExpress.XtraCharts.BarSeriesLabelPosition.Top;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Downtime";
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(240)))));
            sideBySideBarSeriesView1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid;
            series1.View = sideBySideBarSeriesView1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Calling Times";
            lineSeriesView1.AxisYName = "Secondary AxisY 1";
            lineSeriesView1.Color = System.Drawing.Color.LimeGreen;
            lineSeriesView1.LineMarkerOptions.Color = System.Drawing.Color.Yellow;
            lineSeriesView1.LineStyle.Thickness = 3;
            lineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = lineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.Size = new System.Drawing.Size(1876, 711);
            this.chartControl1.TabIndex = 12;
            chartTitle1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartTitle1.Text = "Average Downtime & Calling Times by Line";
            this.chartControl1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            this.chartControl1.CustomDrawSeries += new DevExpress.XtraCharts.CustomDrawSeriesEventHandler(this.chartControl1_CustomDrawSeries);
            this.chartControl1.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl1_CustomDrawSeriesPoint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1876, 88);
            this.panel1.TabIndex = 2;
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.Location = new System.Drawing.Point(1697, 0);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(176, 44);
            this.btnDetail.TabIndex = 6;
            this.btnDetail.Text = "DETAIL";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.cmdDetail_Click);
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.cmdPm1);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1882, 76);
            this.pnTop.TabIndex = 2;
            // 
            // cmdPm1
            // 
            this.cmdPm1.BackColor = System.Drawing.Color.Transparent;
            this.cmdPm1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdPm1.BackgroundImage")));
            this.cmdPm1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdPm1.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdPm1.FlatAppearance.BorderSize = 0;
            this.cmdPm1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPm1.Font = new System.Drawing.Font("Calibri", 32.75F, System.Drawing.FontStyle.Bold);
            this.cmdPm1.ForeColor = System.Drawing.Color.Navy;
            this.cmdPm1.Location = new System.Drawing.Point(3, 3);
            this.cmdPm1.Name = "cmdPm1";
            this.cmdPm1.Size = new System.Drawing.Size(77, 70);
            this.cmdPm1.TabIndex = 88;
            this.cmdPm1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdPm1.UseVisualStyleBackColor = false;
            this.cmdPm1.Click += new System.EventHandler(this.cmdPm1_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1622, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(260, 76);
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
            this.lblHeader.Size = new System.Drawing.Size(1895, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        Andon Information Downtime";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.grdView);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 902);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1882, 137);
            this.panel3.TabIndex = 7;
            // 
            // grdView
            // 
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.grdView.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdView.Location = new System.Drawing.Point(0, 0);
            this.grdView.MainView = this.gvwView;
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(1882, 137);
            this.grdView.TabIndex = 4;
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
            this.gvwView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvwView_RowCellStyle);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTxt2);
            this.panel2.Controls.Add(this.lblTxt1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTxt3);
            this.panel2.Location = new System.Drawing.Point(1364, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 87);
            this.panel2.TabIndex = 15;
            // 
            // lblTxt2
            // 
            this.lblTxt2.AutoSize = true;
            this.lblTxt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt2.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt2.ForeColor = System.Drawing.Color.White;
            this.lblTxt2.Location = new System.Drawing.Point(3, 21);
            this.lblTxt2.Name = "lblTxt2";
            this.lblTxt2.Size = new System.Drawing.Size(262, 22);
            this.lblTxt2.TabIndex = 12;
            this.lblTxt2.Text = "From 10 min to 29:59 is yellow";
            // 
            // lblTxt1
            // 
            this.lblTxt1.AutoSize = true;
            this.lblTxt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt1.ForeColor = System.Drawing.Color.White;
            this.lblTxt1.Location = new System.Drawing.Point(3, 0);
            this.lblTxt1.Name = "lblTxt1";
            this.lblTxt1.Size = new System.Drawing.Size(198, 22);
            this.lblTxt1.TabIndex = 11;
            this.lblTxt1.Text = "<= 10 minutes is green ";
            // 
            // lblTxt3
            // 
            this.lblTxt3.AutoSize = true;
            this.lblTxt3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.lblTxt3.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxt3.ForeColor = System.Drawing.Color.White;
            this.lblTxt3.Location = new System.Drawing.Point(3, 42);
            this.lblTxt3.Name = "lblTxt3";
            this.lblTxt3.Size = new System.Drawing.Size(304, 22);
            this.lblTxt3.TabIndex = 13;
            this.lblTxt3.Text = "From 30 min to 59:59 min is orange";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(135)))), ((int)(((byte)(156)))));
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 22);
            this.label1.TabIndex = 13;
            this.label1.Text = "Then more than 1 hour is red";
            // 
            // SMT_SCADA_DOWNTIME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 1042);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SMT_SCADA_DOWNTIME";
            this.Text = "SMT_SCADA_COCKPIT_FORM2";
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnMid.ResumeLayout(false);
            this.tblChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnMid;
        private System.Windows.Forms.TableLayoutPanel tblChart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdPm1;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGrid.GridControl grdView;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView gvwView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTxt2;
        private System.Windows.Forms.Label lblTxt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTxt3;
    }
}