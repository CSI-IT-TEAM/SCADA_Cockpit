namespace FORM
{
    partial class SMT_SCADA_B_PU_HISTORY
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_B_PU_HISTORY));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tmrTime = new System.Windows.Forms.Timer();
            this.pn_Top = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtp_Ym = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cht_Chart = new DevExpress.XtraCharts.ChartControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID_NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.STATUS = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.pn_Top.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Ym.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Ym.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            this.pn_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
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
            this.cmdBack.Location = new System.Drawing.Point(3, 0);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(77, 70);
            this.cmdBack.TabIndex = 89;
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
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
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
            this.lblHeader.Size = new System.Drawing.Size(905, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        Temperature History";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 68);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 68);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dtp_Ym);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1904, 68);
            this.panel4.TabIndex = 0;
            // 
            // dtp_Ym
            // 
            this.dtp_Ym.Cursor = System.Windows.Forms.Cursors.Default;
            this.dtp_Ym.EditValue = new System.DateTime(2017, 12, 15, 16, 0, 56, 917);
            this.dtp_Ym.Location = new System.Drawing.Point(155, 14);
            this.dtp_Ym.Name = "dtp_Ym";
            this.dtp_Ym.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtp_Ym.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Ym.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.dtp_Ym.Properties.Appearance.Options.UseFont = true;
            this.dtp_Ym.Properties.Appearance.Options.UseForeColor = true;
            this.dtp_Ym.Properties.AppearanceCalendar.ButtonPressed.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.ButtonPressed.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.CalendarHeader.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.CalendarHeader.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCell.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCell.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellHoliday.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellHoliday.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellPressed.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellPressed.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellSelected.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellSelected.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellToday.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.DayCellToday.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceCalendar.HeaderPressed.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceCalendar.HeaderPressed.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtp_Ym.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            this.dtp_Ym.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtp_Ym.Properties.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            serializableAppearanceObject1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject4.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            serializableAppearanceObject4.Options.UseFont = true;
            this.dtp_Ym.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 50, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null)});
            this.dtp_Ym.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            editorButtonImageOptions2.Location = DevExpress.XtraEditors.ImageLocation.Default;
            serializableAppearanceObject5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject5.Options.UseFont = true;
            serializableAppearanceObject6.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject6.Options.UseFont = true;
            serializableAppearanceObject7.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject7.Options.UseFont = true;
            serializableAppearanceObject8.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold);
            serializableAppearanceObject8.Options.UseFont = true;
            this.dtp_Ym.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Close, "", 50, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null)});
            this.dtp_Ym.Properties.CalendarTimeProperties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.dtp_Ym.Properties.CalendarTimeProperties.ReadOnly = true;
            this.dtp_Ym.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.dtp_Ym.Properties.ContextImageOptions.SvgImageSize = new System.Drawing.Size(1, 10);
            this.dtp_Ym.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dtp_Ym.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.dtp_Ym.Properties.EditFormat.FormatString = "yyyy/MM/dd";
            this.dtp_Ym.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtp_Ym.Properties.Mask.EditMask = "yyyy/MM/dd";
            this.dtp_Ym.Properties.ShowNullValuePromptWhenFocused = true;
            this.dtp_Ym.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.MonthView;
            this.dtp_Ym.Size = new System.Drawing.Size(202, 35);
            this.dtp_Ym.TabIndex = 710;
            this.dtp_Ym.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.dtp_Ym.ToolTipTitle = "Click vào để chọn ngày";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 35);
            this.label6.TabIndex = 709;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.cht_Chart, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 146);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 895);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // cht_Chart
            // 
            this.cht_Chart.AppearanceNameSerializable = "Dark Flat";
            this.cht_Chart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.cht_Chart.DataBindings = null;
            this.cht_Chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cht_Chart.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.cht_Chart.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.cht_Chart.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.cht_Chart.Legend.Font = new System.Drawing.Font("Tahoma", 12F);
            this.cht_Chart.Legend.Name = "Default Legend";
            this.cht_Chart.Location = new System.Drawing.Point(363, 3);
            this.cht_Chart.Name = "cht_Chart";
            this.cht_Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.cht_Chart.Size = new System.Drawing.Size(1538, 889);
            this.cht_Chart.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Controls.Add(this.treeList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 889);
            this.panel2.TabIndex = 0;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(9, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.chkAll.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkAll.Properties.Appearance.Options.UseBackColor = true;
            this.chkAll.Properties.Appearance.Options.UseForeColor = true;
            this.chkAll.Properties.AutoHeight = false;
            this.chkAll.Properties.Caption = "";
            this.chkAll.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkAll.Size = new System.Drawing.Size(25, 28);
            this.chkAll.TabIndex = 22;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // treeList
            // 
            this.treeList.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treeList.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList.Appearance.Row.Font = new System.Drawing.Font("Calibri", 13F);
            this.treeList.Appearance.Row.ForeColor = System.Drawing.Color.White;
            this.treeList.Appearance.Row.Options.UseFont = true;
            this.treeList.Appearance.Row.Options.UseForeColor = true;
            this.treeList.Appearance.TreeLine.BackColor = System.Drawing.Color.White;
            this.treeList.Appearance.TreeLine.BorderColor = System.Drawing.Color.White;
            this.treeList.Appearance.TreeLine.Options.UseBackColor = true;
            this.treeList.Appearance.TreeLine.Options.UseBorderColor = true;
            this.treeList.BandPanelRowHeight = 40;
            this.treeList.BestFitVisibleOnly = true;
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.ColumnPanelRowHeight = 40;
            this.treeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.ID_NAME,
            this.STATUS});
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList.Location = new System.Drawing.Point(0, 0);
            this.treeList.LookAndFeel.SkinName = "Office 2016 Black";
            this.treeList.LookAndFeel.UseDefaultLookAndFeel = false;
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsBehavior.ReadOnly = true;
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
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RowHeight = 45;
            this.treeList.Size = new System.Drawing.Size(354, 889);
            this.treeList.TabIndex = 21;
            this.treeList.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Large;
            this.treeList.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeList_NodeCellStyle);
            this.treeList.BeforeCheckNode += new DevExpress.XtraTreeList.CheckNodeEventHandler(this.treeList_BeforeCheckNode);
            this.treeList.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList_AfterCheckNode);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeListColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "Model";
            this.treeListColumn1.FieldName = "MENU_NM";
            this.treeListColumn1.MinWidth = 34;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 356;
            // 
            // ID_NAME
            // 
            this.ID_NAME.Caption = "ID_NAME";
            this.ID_NAME.FieldName = "ID_NAME";
            this.ID_NAME.Name = "ID_NAME";
            // 
            // pn_Main
            // 
            this.pn_Main.Controls.Add(this.tableLayoutPanel1);
            this.pn_Main.Controls.Add(this.panel1);
            this.pn_Main.Controls.Add(this.pn_Top);
            this.pn_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_Main.Location = new System.Drawing.Point(0, 0);
            this.pn_Main.Name = "pn_Main";
            this.pn_Main.Size = new System.Drawing.Size(1904, 1041);
            this.pn_Main.TabIndex = 0;
            // 
            // STATUS
            // 
            this.STATUS.Caption = "STATUS";
            this.STATUS.FieldName = "STATUS";
            this.STATUS.Name = "STATUS";
            // 
            // SMT_SCADA_B_PU_HISTORY
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pn_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SMT_SCADA_B_PU_HISTORY";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Tag = "10411";
            this.Text = "Scada Bottom History";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged);
            this.pn_Top.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Ym.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_Ym.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            this.pn_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Panel pn_Top;
        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.DateEdit dtp_Ym;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID_NAME;
        private System.Windows.Forms.Panel pn_Main;
        private DevExpress.XtraCharts.ChartControl cht_Chart;
        private DevExpress.XtraTreeList.Columns.TreeListColumn STATUS;
    }
}