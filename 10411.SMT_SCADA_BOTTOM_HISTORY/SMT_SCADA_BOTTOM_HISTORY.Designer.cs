namespace FORM
{
    partial class SMT_SCADA_BOTTOM_HISTORY
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView3 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView4 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView5 = new DevExpress.XtraCharts.SplineSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_BOTTOM_HISTORY));
            this.pn_Main = new System.Windows.Forms.Panel();
            this.pn_Chart = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cht_Chart = new DevExpress.XtraCharts.ChartControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pn_Top = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.pn_Main.SuspendLayout();
            this.pn_Chart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView5)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.pn_Top.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.pn_Chart);
            this.pn_Main.Controls.Add(this.pn_Top);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 0);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1904, 1041);
            this.pn_Main.TabIndex = 0;
            // 
            // pn_Chart
            // 
            this.pn_Chart.Controls.Add(this.tableLayoutPanel1);
            this.pn_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Chart.Location = new System.Drawing.Point(0, 78);
            this.pn_Chart.Name = "pn_Chart";
            this.pn_Chart.Size = new System.Drawing.Size(1904, 963);
            this.pn_Chart.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.01681F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.98319F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 963);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Tag = "10411";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cht_Chart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(327, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1574, 957);
            this.panel1.TabIndex = 0;
            // 
            // cht_Chart
            // 
            this.cht_Chart.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.cht_Chart.DataBindings = null;
            this.cht_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cht_Chart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.cht_Chart.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.cht_Chart.Legend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cht_Chart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.cht_Chart.Legend.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cht_Chart.Legend.MarkerSize = new System.Drawing.Size(18, 12);
            this.cht_Chart.Legend.Name = "Default Legend";
            this.cht_Chart.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.cht_Chart.Location = new System.Drawing.Point(0, 0);
            this.cht_Chart.Name = "cht_Chart";
            this.cht_Chart.PaletteName = "Marquee";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "Production";
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.View = splineSeriesView1;
            series1.Visible = false;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "Manpower";
            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.View = splineSeriesView2;
            series2.Visible = false;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "Budget";
            splineSeriesView3.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.View = splineSeriesView3;
            series3.Visible = false;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Series 1";
            splineSeriesView4.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.View = splineSeriesView4;
            series4.Visible = false;
            this.cht_Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
            this.cht_Chart.SeriesTemplate.View = splineSeriesView5;
            this.cht_Chart.Size = new System.Drawing.Size(1574, 957);
            this.cht_Chart.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.treeList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 957);
            this.panel2.TabIndex = 1;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(3, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chkAll.Properties.Appearance.Options.UseBackColor = true;
            this.chkAll.Properties.AutoHeight = false;
            this.chkAll.Properties.Caption = "";
            this.chkAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkAll.Size = new System.Drawing.Size(25, 28);
            this.chkAll.TabIndex = 20;
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
            this.treeList.Size = new System.Drawing.Size(318, 957);
            this.treeList.TabIndex = 1;
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Machine Banbury";
            this.treeListColumn1.FieldName = "MENU_NM";
            this.treeListColumn1.MinWidth = 34;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 330;
            // 
            // ID_NAME
            // 
            this.ID_NAME.Caption = "ID_NAME";
            this.ID_NAME.FieldName = "ID_NAME";
            this.ID_NAME.Name = "ID_NAME";
            // 
            // pn_Top
            // 
            this.pn_Top.Controls.Add(this.pnTop);
            this.pn_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Top.Location = new System.Drawing.Point(0, 0);
            this.pn_Top.Name = "pn_Top";
            this.pn_Top.Size = new System.Drawing.Size(1904, 78);
            this.pn_Top.TabIndex = 0;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.cmdBack);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1904, 76);
            this.pnTop.TabIndex = 4;
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
            this.lblDate.Location = new System.Drawing.Point(1669, 0);
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
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(905, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        SCADA Machine Temporature";
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // SMT_SCADA_BOTTOM_HISTORY
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pn_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SMT_SCADA_BOTTOM_HISTORY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "10411";
            this.Text = "Scada Bottom History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged);
            this.pn_Main.ResumeLayout(false);
            this.pn_Chart.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.pn_Top.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Main;
        private System.Windows.Forms.Panel pn_Chart;
        private System.Windows.Forms.Panel pn_Top;
        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraCharts.ChartControl cht_Chart;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_NAME;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}