namespace FORM
{
    partial class FRM_SCADA_TRENDING_BK20201125
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
            this.pnHeader = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new System.Windows.Forms.Label();
            this.pnMain = new System.Windows.Forms.Panel();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.groupBoxEx1 = new FORM.GroupBoxEx();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtp_From = new DevExpress.XtraEditors.DateEdit();
            this.dtp_To = new DevExpress.XtraEditors.DateEdit();
            this.cboID = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMachine = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboArea = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLine = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.pnHeader.SuspendLayout();
            this.groupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_From.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_From.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnHeader
            // 
            this.pnHeader.Controls.Add(this.btnBack);
            this.pnHeader.Controls.Add(this.lblTitle);
            this.pnHeader.Controls.Add(this.lblDate);
            this.pnHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnHeader.Location = new System.Drawing.Point(0, 0);
            this.pnHeader.Name = "pnHeader";
            this.pnHeader.Size = new System.Drawing.Size(1904, 90);
            this.pnHeader.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BackgroundImage = global::FORM.Properties.Resources.back;
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(0, 5);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(85, 84);
            this.btnBack.TabIndex = 59;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Calibri", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblTitle.LineVisible = true;
            this.lblTitle.Location = new System.Drawing.Point(91, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1653, 82);
            this.lblTitle.TabIndex = 58;
            this.lblTitle.Text = "TRENDING TEMPERATURE";
            this.lblTitle.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.Location = new System.Drawing.Point(1671, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(233, 90);
            this.lblDate.TabIndex = 57;
            this.lblDate.Text = "2019-09-19\r\n00:00:00";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // pnMain
            // 
            this.pnMain.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 155);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(1904, 886);
            this.pnMain.TabIndex = 2;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.BackgroundPanelImage = null;
            this.groupBoxEx1.Controls.Add(this.btnSearch);
            this.groupBoxEx1.Controls.Add(this.dtp_From);
            this.groupBoxEx1.Controls.Add(this.dtp_To);
            this.groupBoxEx1.Controls.Add(this.cboID);
            this.groupBoxEx1.Controls.Add(this.label4);
            this.groupBoxEx1.Controls.Add(this.cboMachine);
            this.groupBoxEx1.Controls.Add(this.label3);
            this.groupBoxEx1.Controls.Add(this.cboArea);
            this.groupBoxEx1.Controls.Add(this.label2);
            this.groupBoxEx1.Controls.Add(this.cboLine);
            this.groupBoxEx1.Controls.Add(this.label6);
            this.groupBoxEx1.Controls.Add(this.label7);
            this.groupBoxEx1.Controls.Add(this.label1);
            this.groupBoxEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxEx1.DrawGroupBorder = true;
            this.groupBoxEx1.GroupBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx1.GroupPanelColor = System.Drawing.Color.White;
            this.groupBoxEx1.GroupPanelShape = FORM.GroupBoxEx.PanelType.Rounded;
            this.groupBoxEx1.GroupPanelWith = 1F;
            this.groupBoxEx1.Location = new System.Drawing.Point(0, 90);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(1904, 65);
            this.groupBoxEx1.TabIndex = 1;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.TextBackColor = System.Drawing.Color.White;
            this.groupBoxEx1.TextBorderColor = System.Drawing.Color.Black;
            this.groupBoxEx1.TextBorderWith = 1F;
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::FORM.Properties.Resources.btnSearch;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(1749, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(143, 53);
            this.btnSearch.TabIndex = 18;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.MouseLeave += new System.EventHandler(this.btnSearch_MouseLeave);
            this.btnSearch.MouseHover += new System.EventHandler(this.btnSearch_MouseHover);
            // 
            // dtp_From
            // 
            this.dtp_From.EditValue = null;
            this.dtp_From.Location = new System.Drawing.Point(69, 13);
            this.dtp_From.Name = "dtp_From";
            this.dtp_From.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtp_From.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.Appearance.Options.UseBackColor = true;
            this.dtp_From.Properties.Appearance.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.Button.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.Button.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.ButtonHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.ButtonHighlighted.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.ButtonPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.ButtonPressed.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.CalendarHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.CalendarHeader.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCell.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCell.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellDisabled.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellHoliday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellHoliday.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellInactive.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellInactive.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellPressed.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellSelected.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecial.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecial.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialPressed.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellSpecialSelected.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.DayCellToday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.DayCellToday.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.HeaderPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.HeaderPressed.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.WeekDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.WeekDay.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtp_From.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_From.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtp_From.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_From.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_From.Properties.CellSize = new System.Drawing.Size(70, 50);
            this.dtp_From.Properties.TodayDate = new System.DateTime(2019, 9, 24, 9, 47, 32, 0);
            this.dtp_From.Size = new System.Drawing.Size(149, 36);
            this.dtp_From.TabIndex = 17;
            // 
            // dtp_To
            // 
            this.dtp_To.EditValue = null;
            this.dtp_To.Location = new System.Drawing.Point(245, 13);
            this.dtp_To.Name = "dtp_To";
            this.dtp_To.Properties.Appearance.BackColor = System.Drawing.SystemColors.ControlLight;
            this.dtp_To.Properties.Appearance.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.Appearance.Options.UseBackColor = true;
            this.dtp_To.Properties.Appearance.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.Button.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.Button.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.ButtonHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.ButtonHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.ButtonPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.ButtonPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.CalendarHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.CalendarHeader.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCell.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCell.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellDisabled.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellHoliday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellHoliday.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellInactive.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellInactive.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSelected.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecial.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecial.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialSelected.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellSpecialSelected.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.DayCellToday.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.DayCellToday.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.Header.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.Header.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.HeaderHighlighted.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.HeaderHighlighted.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.HeaderPressed.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.HeaderPressed.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.WeekDay.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.WeekDay.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceCalendar.WeekNumber.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceCalendar.WeekNumber.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceDisabled.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceDisabled.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceFocused.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceFocused.Options.UseFont = true;
            this.dtp_To.Properties.AppearanceReadOnly.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.dtp_To.Properties.AppearanceReadOnly.Options.UseFont = true;
            this.dtp_To.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_To.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtp_To.Properties.CellSize = new System.Drawing.Size(70, 50);
            this.dtp_To.Properties.TodayDate = new System.DateTime(2019, 9, 24, 9, 47, 32, 0);
            this.dtp_To.Size = new System.Drawing.Size(149, 36);
            this.dtp_To.TabIndex = 17;
            // 
            // cboID
            // 
            this.cboID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboID.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboID.FormattingEnabled = true;
            this.cboID.Location = new System.Drawing.Point(1508, 13);
            this.cboID.Name = "cboID";
            this.cboID.Size = new System.Drawing.Size(232, 36);
            this.cboID.TabIndex = 14;
            this.cboID.SelectedIndexChanged += new System.EventHandler(this.cboID_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DimGray;
            this.label4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1358, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "Controller ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMachine
            // 
            this.cboMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMachine.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboMachine.FormattingEnabled = true;
            this.cboMachine.Location = new System.Drawing.Point(921, 13);
            this.cboMachine.Name = "cboMachine";
            this.cboMachine.Size = new System.Drawing.Size(427, 36);
            this.cboMachine.TabIndex = 13;
            this.cboMachine.SelectedIndexChanged += new System.EventHandler(this.cboMachine_SelectedIndexChanged);
            this.cboMachine.SelectedValueChanged += new System.EventHandler(this.cboMachine_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DimGray;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(813, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 36);
            this.label3.TabIndex = 10;
            this.label3.Text = "Machine";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboArea
            // 
            this.cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArea.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboArea.FormattingEnabled = true;
            this.cboArea.Location = new System.Drawing.Point(636, 13);
            this.cboArea.Name = "cboArea";
            this.cboArea.Size = new System.Drawing.Size(167, 36);
            this.cboArea.TabIndex = 12;
            this.cboArea.SelectedIndexChanged += new System.EventHandler(this.cboArea_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(568, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "Area";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboLine
            // 
            this.cboLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLine.Font = new System.Drawing.Font("Calibri", 17F, System.Drawing.FontStyle.Bold);
            this.cboLine.FormattingEnabled = true;
            this.cboLine.Location = new System.Drawing.Point(466, 13);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(92, 36);
            this.cboLine.TabIndex = 11;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DimGray;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 36);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(220, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 36);
            this.label7.TabIndex = 7;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 36);
            this.label1.TabIndex = 6;
            this.label1.Text = "Line";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // FRM_SCADA_TRENDING_BK20201125
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.pnHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FRM_SCADA_TRENDING_BK20201125";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRM_SCADA_TRENDING_BK20201125";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FRM_SCADA_TRENDING_BK20201125_Load);
            this.pnHeader.ResumeLayout(false);
            this.groupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_From.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_From.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_To.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHeader;
        private System.Windows.Forms.Button btnBack;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Label lblDate;
        private GroupBoxEx groupBoxEx1;
        private System.Windows.Forms.Button btnSearch;
        private DevExpress.XtraEditors.DateEdit dtp_From;
        private DevExpress.XtraEditors.DateEdit dtp_To;
        private System.Windows.Forms.ComboBox cboID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMachine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Timer tmrDate;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}