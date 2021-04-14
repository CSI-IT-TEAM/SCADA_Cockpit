namespace FORM
{
    partial class FRM_SMT_SCADA_ENERGY
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
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY2 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY3 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.HatchFillOptions hatchFillOptions1 = new DevExpress.XtraCharts.HatchFillOptions();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.BarGrowUpAnimation barGrowUpAnimation1 = new DevExpress.XtraCharts.BarGrowUpAnimation();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel1 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineAreaSeriesView splineAreaSeriesView1 = new DevExpress.XtraCharts.SplineAreaSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation1 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation1 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.SineEasingFunction sineEasingFunction1 = new DevExpress.XtraCharts.SineEasingFunction();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel2 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView1 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation2 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation2 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.QuadraticEasingFunction quadraticEasingFunction1 = new DevExpress.XtraCharts.QuadraticEasingFunction();
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PointSeriesLabel pointSeriesLabel3 = new DevExpress.XtraCharts.PointSeriesLabel();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView2 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.XYSeriesUnwindAnimation xySeriesUnwindAnimation3 = new DevExpress.XtraCharts.XYSeriesUnwindAnimation();
            DevExpress.XtraCharts.XYMarkerSlideAnimation xyMarkerSlideAnimation3 = new DevExpress.XtraCharts.XYMarkerSlideAnimation();
            DevExpress.XtraCharts.ExponentialEasingFunction exponentialEasingFunction1 = new DevExpress.XtraCharts.ExponentialEasingFunction();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnInfoTotal = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dptDate = new DevExpress.XtraEditors.DateEdit();
            this.advancedPanel3 = new FORM.AdvancedPanel();
            this.lblAVGProd = new System.Windows.Forms.Label();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.advancedPanel4 = new FORM.AdvancedPanel();
            this.lblAVGCost = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.advancedPanel2 = new FORM.AdvancedPanel();
            this.lblAVG = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.advancedPanel1 = new FORM.AdvancedPanel();
            this.lblAVGkWh = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnChart = new System.Windows.Forms.Panel();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.pnGrid = new System.Windows.Forms.Panel();
            this.grdView = new DevExpress.XtraGrid.GridControl();
            this.gvwView = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.tblMain.SuspendLayout();
            this.pnHeader.SuspendLayout();
            this.pnInfoTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dptDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptDate.Properties)).BeginInit();
            this.advancedPanel3.SuspendLayout();
            this.advancedPanel4.SuspendLayout();
            this.advancedPanel2.SuspendLayout();
            this.advancedPanel1.SuspendLayout();
            this.pnChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).BeginInit();
            this.pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
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
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.54161F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.45839F));
            this.tblMain.Size = new System.Drawing.Size(1904, 1041);
            this.tblMain.TabIndex = 0;
            // 
            // pnHeader
            // 
            this.pnHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(176)))), ((int)(((byte)(80)))));
            this.pnHeader.Controls.Add(this.btnBack);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Controls.Add(this.lblHeader);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnHeader.Location = new System.Drawing.Point(3, 3);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1898, 104);
            this.pnHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::FORM.Properties.Resources.Back_Icon;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 32.75F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Navy;
            this.btnBack.Location = new System.Drawing.Point(1532, 6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 95);
            this.btnBack.TabIndex = 90;
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1638, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(260, 104);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "2020-07-22\r\n10:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.Appearance.Options.UseForeColor = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1543, 104);
            this.lblHeader.TabIndex = 4;
            this.lblHeader.Text = "Power Management Systems";
            // 
            // pnInfoTotal
            // 
            this.pnInfoTotal.BackColor = System.Drawing.Color.White;
            this.pnInfoTotal.Controls.Add(this.label1);
            this.pnInfoTotal.Controls.Add(this.dptDate);
            this.pnInfoTotal.Controls.Add(this.advancedPanel3);
            this.pnInfoTotal.Controls.Add(this.advancedPanel4);
            this.pnInfoTotal.Controls.Add(this.advancedPanel2);
            this.pnInfoTotal.Controls.Add(this.advancedPanel1);
            this.pnInfoTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnInfoTotal.Location = new System.Drawing.Point(3, 113);
            this.pnInfoTotal.Name = "pnInfoTotal";
            this.pnInfoTotal.Size = new System.Drawing.Size(1898, 168);
            this.pnInfoTotal.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 40);
            this.label1.TabIndex = 8;
            this.label1.Text = "Month";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dptDate
            // 
            this.dptDate.EditValue = new System.DateTime(2020, 10, 29, 0, 0, 0, 0);
            this.dptDate.Location = new System.Drawing.Point(116, 7);
            this.dptDate.Name = "dptDate";
            this.dptDate.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18F);
            this.dptDate.Properties.Appearance.Options.UseFont = true;
            this.dptDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptDate.Properties.DisplayFormat.FormatString = "yyyy/MM";
            this.dptDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dptDate.Properties.EditFormat.FormatString = "yyyy/MM";
            this.dptDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptDate.Properties.Mask.EditMask = "yyyy/MM";
            this.dptDate.Properties.TodayDate = new System.DateTime(2020, 10, 29, 10, 46, 38, 0);
            this.dptDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.dptDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.dptDate.Size = new System.Drawing.Size(136, 36);
            this.dptDate.TabIndex = 7;
            // 
            // advancedPanel3
            // 
            this.advancedPanel3.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel3.Controls.Add(this.lblAVGProd);
            this.advancedPanel3.Controls.Add(this.labelControl3);
            this.advancedPanel3.EdgeWidth = 2;
            this.advancedPanel3.EndColor = System.Drawing.Color.White;
            this.advancedPanel3.FlatBorderColor = System.Drawing.Color.CornflowerBlue;
            this.advancedPanel3.Location = new System.Drawing.Point(486, 49);
            this.advancedPanel3.Name = "advancedPanel3";
            this.advancedPanel3.RectRadius = 0;
            this.advancedPanel3.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel3.ShadowShift = 4;
            this.advancedPanel3.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel3.Size = new System.Drawing.Size(467, 110);
            this.advancedPanel3.StartColor = System.Drawing.Color.White;
            this.advancedPanel3.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel3.TabIndex = 6;
            // 
            // lblAVGProd
            // 
            this.lblAVGProd.BackColor = System.Drawing.Color.Transparent;
            this.lblAVGProd.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAVGProd.Location = new System.Drawing.Point(3, 38);
            this.lblAVGProd.Name = "lblAVGProd";
            this.lblAVGProd.Size = new System.Drawing.Size(461, 55);
            this.lblAVGProd.TabIndex = 0;
            this.lblAVGProd.Text = "0 Prs";
            this.lblAVGProd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAVGProd.DoubleClick += new System.EventHandler(this.lblTotalProd_DoubleClick);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.labelControl3.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(461, 32);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Production by Month";
            // 
            // advancedPanel4
            // 
            this.advancedPanel4.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel4.Controls.Add(this.lblAVGCost);
            this.advancedPanel4.Controls.Add(this.labelControl4);
            this.advancedPanel4.EdgeWidth = 2;
            this.advancedPanel4.EndColor = System.Drawing.Color.White;
            this.advancedPanel4.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.advancedPanel4.Location = new System.Drawing.Point(1439, 49);
            this.advancedPanel4.Name = "advancedPanel4";
            this.advancedPanel4.RectRadius = 0;
            this.advancedPanel4.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel4.ShadowShift = 4;
            this.advancedPanel4.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel4.Size = new System.Drawing.Size(467, 110);
            this.advancedPanel4.StartColor = System.Drawing.Color.White;
            this.advancedPanel4.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel4.TabIndex = 6;
            // 
            // lblAVGCost
            // 
            this.lblAVGCost.BackColor = System.Drawing.Color.Transparent;
            this.lblAVGCost.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAVGCost.Location = new System.Drawing.Point(3, 38);
            this.lblAVGCost.Name = "lblAVGCost";
            this.lblAVGCost.Size = new System.Drawing.Size(461, 55);
            this.lblAVGCost.TabIndex = 0;
            this.lblAVGCost.Text = "0 USD";
            this.lblAVGCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelControl4.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.LineVisible = true;
            this.labelControl4.Location = new System.Drawing.Point(3, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(461, 32);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "Cost by Month (Cost/Kwh: 0.07 USD)";
            // 
            // advancedPanel2
            // 
            this.advancedPanel2.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel2.Controls.Add(this.lblAVG);
            this.advancedPanel2.Controls.Add(this.labelControl2);
            this.advancedPanel2.EdgeWidth = 2;
            this.advancedPanel2.EndColor = System.Drawing.Color.White;
            this.advancedPanel2.FlatBorderColor = System.Drawing.Color.DeepSkyBlue;
            this.advancedPanel2.Location = new System.Drawing.Point(963, 49);
            this.advancedPanel2.Name = "advancedPanel2";
            this.advancedPanel2.RectRadius = 0;
            this.advancedPanel2.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel2.ShadowShift = 4;
            this.advancedPanel2.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel2.Size = new System.Drawing.Size(467, 110);
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
            this.lblAVG.Size = new System.Drawing.Size(461, 55);
            this.lblAVG.TabIndex = 0;
            this.lblAVG.Text = "0 kWh/Prs";
            this.lblAVG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(461, 32);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Electric consumption/Prs";
            // 
            // advancedPanel1
            // 
            this.advancedPanel1.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.advancedPanel1.Controls.Add(this.lblAVGkWh);
            this.advancedPanel1.Controls.Add(this.labelControl1);
            this.advancedPanel1.EdgeWidth = 2;
            this.advancedPanel1.EndColor = System.Drawing.Color.White;
            this.advancedPanel1.FlatBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.advancedPanel1.Location = new System.Drawing.Point(10, 49);
            this.advancedPanel1.Name = "advancedPanel1";
            this.advancedPanel1.RectRadius = 0;
            this.advancedPanel1.ShadowColor = System.Drawing.Color.Silver;
            this.advancedPanel1.ShadowShift = 4;
            this.advancedPanel1.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.advancedPanel1.Size = new System.Drawing.Size(467, 110);
            this.advancedPanel1.StartColor = System.Drawing.Color.White;
            this.advancedPanel1.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.advancedPanel1.TabIndex = 0;
            // 
            // lblAVGkWh
            // 
            this.lblAVGkWh.BackColor = System.Drawing.Color.Transparent;
            this.lblAVGkWh.Font = new System.Drawing.Font("Times New Roman", 40F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAVGkWh.Location = new System.Drawing.Point(3, 38);
            this.lblAVGkWh.Name = "lblAVGkWh";
            this.lblAVGkWh.Size = new System.Drawing.Size(461, 55);
            this.lblAVGkWh.TabIndex = 0;
            this.lblAVGkWh.Text = "0 kWh";
            this.lblAVGkWh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAVGkWh.DoubleClick += new System.EventHandler(this.label1_DoubleClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.LineVisible = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(461, 32);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Electric consumption by month";
            // 
            // pnChart
            // 
            this.pnChart.Controls.Add(this.chartControl1);
            this.pnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChart.Location = new System.Drawing.Point(3, 287);
            this.pnChart.Name = "pnChart";
            this.pnChart.Size = new System.Drawing.Size(1898, 527);
            this.pnChart.TabIndex = 2;
            // 
            // chartControl1
            // 
            this.chartControl1.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl1.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl1.DataBindings = null;
            xyDiagram1.AxisX.Label.Font = new System.Drawing.Font("Calibri", 12F);
            xyDiagram1.AxisX.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            xyDiagram1.AxisX.Title.Text = "Date";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.GridLines.Visible = false;
            xyDiagram1.AxisY.Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Label.TextPattern = "{V:#,#}";
            xyDiagram1.AxisY.Title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Title.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            xyDiagram1.AxisY.Title.Text = "Production (Prs)";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.BorderVisible = false;
            xyDiagram1.DefaultPane.Shadow.Color = System.Drawing.Color.Silver;
            xyDiagram1.DefaultPane.Shadow.Size = 3;
            xyDiagram1.PaneDistance = 1;
            secondaryAxisY1.Alignment = DevExpress.XtraCharts.AxisAlignment.Near;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.Label.Font = new System.Drawing.Font("Calibri", 12F);
            secondaryAxisY1.Label.TextPattern = "{V:0.00}";
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            secondaryAxisY1.Title.Text = "kWh/Prs";
            secondaryAxisY1.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            secondaryAxisY2.AxisID = 1;
            secondaryAxisY2.Label.Font = new System.Drawing.Font("Calibri", 12F);
            secondaryAxisY2.Label.TextPattern = "{V:#,#}";
            secondaryAxisY2.Name = "Secondary AxisY 2";
            secondaryAxisY2.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            secondaryAxisY2.Title.Text = "Electric Comsumsion (kWh)";
            secondaryAxisY2.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY2.VisibleInPanesSerializable = "-1";
            secondaryAxisY3.AxisID = 2;
            secondaryAxisY3.Label.Font = new System.Drawing.Font("Calibri", 12F);
            secondaryAxisY3.Label.TextPattern = "{V:#,#}";
            secondaryAxisY3.Name = "Secondary AxisY 3";
            secondaryAxisY3.Title.Font = new System.Drawing.Font("Calibri", 14.25F);
            secondaryAxisY3.Title.Text = "Cost (USD)";
            secondaryAxisY3.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY3.Visibility = DevExpress.Utils.DefaultBoolean.True;
            secondaryAxisY3.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1,
            secondaryAxisY2,
            secondaryAxisY3});
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl1.Legend.Border.Color = System.Drawing.Color.Gray;
            this.chartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl1.Legend.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
            hatchFillOptions1.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            hatchFillOptions1.HatchStyle = System.Drawing.Drawing2D.HatchStyle.WideDownwardDiagonal;
            this.chartControl1.Legend.FillStyle.Options = hatchFillOptions1;
            this.chartControl1.Legend.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartControl1.Legend.MarkerMode = DevExpress.XtraCharts.LegendMarkerMode.CheckBoxAndMarker;
            this.chartControl1.Legend.MarkerSize = new System.Drawing.Size(30, 25);
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Numerical;
            series1.CrosshairLabelPattern = "{V:#,#}";
            sideBySideBarSeriesLabel1.TextPattern = "{V:#,#}";
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Production";
            barGrowUpAnimation1.BeginTime = System.TimeSpan.Parse("00:00:01");
            barGrowUpAnimation1.Duration = System.TimeSpan.Parse("00:00:02.2000000");
            barGrowUpAnimation1.PointDelay = System.TimeSpan.Parse("00:00:00.1000000");
            barGrowUpAnimation1.PointOrder = DevExpress.XtraCharts.PointAnimationOrder.Random;
            sideBySideBarSeriesView1.Animation = barGrowUpAnimation1;
            sideBySideBarSeriesView1.AxisYName = "Secondary AxisY 2";
            sideBySideBarSeriesView1.Transparency = ((byte)(90));
            series1.View = sideBySideBarSeriesView1;
            series2.CrosshairLabelPattern = "{V:#,#}";
            pointSeriesLabel1.TextPattern = "{V:#,#}";
            series2.Label = pointSeriesLabel1;
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series2.Name = "Electric Comsumsion";
            splineAreaSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.False;
            xySeriesUnwindAnimation1.BeginTime = System.TimeSpan.Parse("00:00:02");
            xySeriesUnwindAnimation1.Duration = System.TimeSpan.Parse("00:00:02.5000000");
            splineAreaSeriesView1.SeriesAnimation = xySeriesUnwindAnimation1;
            xyMarkerSlideAnimation1.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromTopCenter;
            xyMarkerSlideAnimation1.EasingFunction = sineEasingFunction1;
            splineAreaSeriesView1.SeriesPointAnimation = xyMarkerSlideAnimation1;
            series2.View = splineAreaSeriesView1;
            series3.CrosshairLabelPattern = "{V:0.00}";
            pointSeriesLabel2.Font = new System.Drawing.Font("Calibri", 12F);
            pointSeriesLabel2.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel2.TextPattern = "{V:0.00}";
            series3.Label = pointSeriesLabel2;
            series3.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series3.Name = "kWh/Prs";
            splineSeriesView1.AxisYName = "Secondary AxisY 1";
            splineSeriesView1.Color = System.Drawing.Color.Black;
            splineSeriesView1.LineStyle.DashStyle = DevExpress.XtraCharts.DashStyle.Dash;
            splineSeriesView1.LineStyle.Thickness = 3;
            splineSeriesView1.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation2.BeginTime = System.TimeSpan.Parse("00:00:01");
            xySeriesUnwindAnimation2.Duration = System.TimeSpan.Parse("00:00:02.5000000");
            splineSeriesView1.SeriesAnimation = xySeriesUnwindAnimation2;
            xyMarkerSlideAnimation2.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromLeftBottomCorner;
            xyMarkerSlideAnimation2.EasingFunction = quadraticEasingFunction1;
            xyMarkerSlideAnimation2.PointDelay = System.TimeSpan.Parse("00:00:00.1000000");
            splineSeriesView1.SeriesPointAnimation = xyMarkerSlideAnimation2;
            splineSeriesView1.Shadow.Visible = true;
            series3.View = splineSeriesView1;
            series4.CrosshairLabelPattern = "{V:#,#}";
            pointSeriesLabel3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pointSeriesLabel3.LineVisibility = DevExpress.Utils.DefaultBoolean.True;
            pointSeriesLabel3.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.JustifyAroundPoint;
            pointSeriesLabel3.TextPattern = "{V:#,#}";
            series4.Label = pointSeriesLabel3;
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Cost";
            splineSeriesView2.AxisYName = "Secondary AxisY 3";
            splineSeriesView2.Color = System.Drawing.Color.Red;
            splineSeriesView2.LineStyle.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            splineSeriesView2.LineStyle.Thickness = 3;
            splineSeriesView2.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            xySeriesUnwindAnimation3.BeginTime = System.TimeSpan.Parse("00:00:03");
            xySeriesUnwindAnimation3.Duration = System.TimeSpan.Parse("00:00:02.2000000");
            splineSeriesView2.SeriesAnimation = xySeriesUnwindAnimation3;
            xyMarkerSlideAnimation3.Direction = DevExpress.XtraCharts.XYMarkerSlideAnimationDirection.FromBottomCenter;
            xyMarkerSlideAnimation3.Duration = System.TimeSpan.Parse("00:00:02.2000000");
            xyMarkerSlideAnimation3.EasingFunction = exponentialEasingFunction1;
            xyMarkerSlideAnimation3.PointDelay = System.TimeSpan.Parse("00:00:00.1000000");
            splineSeriesView2.SeriesPointAnimation = xyMarkerSlideAnimation3;
            series4.View = splineSeriesView2;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2,
        series3,
        series4};
            this.chartControl1.Size = new System.Drawing.Size(1898, 527);
            this.chartControl1.TabIndex = 0;
            // 
            // pnGrid
            // 
            this.pnGrid.Controls.Add(this.grdView);
            this.pnGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnGrid.Location = new System.Drawing.Point(3, 820);
            this.pnGrid.Name = "pnGrid";
            this.pnGrid.Size = new System.Drawing.Size(1898, 218);
            this.pnGrid.TabIndex = 3;
            // 
            // grdView
            // 
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.Font = new System.Drawing.Font("Calibri", 12.75F);
            this.grdView.Location = new System.Drawing.Point(0, 0);
            this.grdView.MainView = this.gvwView;
            this.grdView.Name = "grdView";
            this.grdView.Size = new System.Drawing.Size(1898, 218);
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
            this.gvwView.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
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
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 1000;
            this.tmr.Tick += new System.EventHandler(this.tmr_Tick);
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationId = "554b17f3-211c-45fe-80d5-666d6d606652";
            this.toastNotificationsManager1.ApplicationName = "SMT_SCADA_ENERGY";
            this.toastNotificationsManager1.Notifications.AddRange(new DevExpress.XtraBars.ToastNotifications.IToastNotificationProperties[] {
            new DevExpress.XtraBars.ToastNotifications.ToastNotification("10ea65a0-a82a-4979-8453-84425c8ab41a", global::FORM.Properties.Resources.Back_Icon, "Pellentesque lacinia tellus eget volutpat", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i" +
                    "ncididunt ut labore et dolore magna aliqua.", "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor i" +
                    "ncididunt ut labore et dolore magna aliqua.", DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.Text01)});
            // 
            // FRM_SMT_SCADA_ENERGY
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.tblMain);
            this.Name = "FRM_SMT_SCADA_ENERGY";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_SMT_SCADA_ENERGY_Load);
            this.VisibleChanged += new System.EventHandler(this.FRM_SMT_SCADA_ENERGY_VisibleChanged);
            this.tblMain.ResumeLayout(false);
            this.pnHeader.ResumeLayout(false);
            this.pnInfoTotal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dptDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptDate.Properties)).EndInit();
            this.advancedPanel3.ResumeLayout(false);
            this.advancedPanel4.ResumeLayout(false);
            this.advancedPanel2.ResumeLayout(false);
            this.advancedPanel1.ResumeLayout(false);
            this.pnChart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineAreaSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pointSeriesLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
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
        private System.Windows.Forms.Label lblAVGkWh;
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
        private System.Windows.Forms.Label lblAVGProd;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private AdvancedPanel advancedPanel4;
        private System.Windows.Forms.Label lblAVGCost;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dptDate;
    }
}