namespace FORM
{
    partial class SMT_SCADA_BOTTOM_COCKPIT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_BOTTOM_COCKPIT));
            this.pnTop = new System.Windows.Forms.Panel();
            this.a1Panel1 = new OS_DSF.A1Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rlblStopWork = new RoundLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.rlblMalfunction = new RoundLabel();
            this.rlblNormal = new RoundLabel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.button1 = new System.Windows.Forms.Button();
            this.splMain = new System.Windows.Forms.SplitContainer();
            this.button2 = new System.Windows.Forms.Button();
            this.tblB1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.tblB2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::FORM.WaitForm1), true, true);
            this.pnTop.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
            this.splMain.Panel1.SuspendLayout();
            this.splMain.Panel2.SuspendLayout();
            this.splMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.a1Panel1);
            this.pnTop.Controls.Add(this.cmdBack);
            this.pnTop.Controls.Add(this.lblDate);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1904, 76);
            this.pnTop.TabIndex = 3;
            // 
            // a1Panel1
            // 
            this.a1Panel1.BorderColor = System.Drawing.SystemColors.GrayText;
            this.a1Panel1.Controls.Add(this.label5);
            this.a1Panel1.Controls.Add(this.label4);
            this.a1Panel1.Controls.Add(this.rlblStopWork);
            this.a1Panel1.Controls.Add(this.label3);
            this.a1Panel1.Controls.Add(this.rlblMalfunction);
            this.a1Panel1.Controls.Add(this.rlblNormal);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(1275, 5);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 10;
            this.a1Panel1.Size = new System.Drawing.Size(388, 70);
            this.a1Panel1.TabIndex = 89;
            this.a1Panel1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(217, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Machine Stop Working";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Malfunction";
            // 
            // rlblStopWork
            // 
            this.rlblStopWork._BackColor = System.Drawing.Color.Black;
            this.rlblStopWork.BackColor = System.Drawing.Color.Transparent;
            this.rlblStopWork.Location = new System.Drawing.Point(191, 6);
            this.rlblStopWork.Name = "rlblStopWork";
            this.rlblStopWork.Size = new System.Drawing.Size(24, 23);
            this.rlblStopWork.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 1;
            this.label3.Text = "Normal Machine";
            // 
            // rlblMalfunction
            // 
            this.rlblMalfunction._BackColor = System.Drawing.Color.Red;
            this.rlblMalfunction.BackColor = System.Drawing.Color.Transparent;
            this.rlblMalfunction.Location = new System.Drawing.Point(12, 35);
            this.rlblMalfunction.Name = "rlblMalfunction";
            this.rlblMalfunction.Size = new System.Drawing.Size(24, 23);
            this.rlblMalfunction.TabIndex = 0;
            // 
            // rlblNormal
            // 
            this.rlblNormal._BackColor = System.Drawing.Color.Green;
            this.rlblNormal.BackColor = System.Drawing.Color.Transparent;
            this.rlblNormal.Location = new System.Drawing.Point(12, 6);
            this.rlblNormal.Name = "rlblNormal";
            this.rlblNormal.Size = new System.Drawing.Size(24, 23);
            this.rlblNormal.TabIndex = 0;
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
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(537, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        SCADA Bottom";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1676, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 89;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splMain
            // 
            this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMain.Location = new System.Drawing.Point(0, 76);
            this.splMain.Name = "splMain";
            this.splMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splMain.Panel1
            // 
            this.splMain.Panel1.Controls.Add(this.button2);
            this.splMain.Panel1.Controls.Add(this.tblB1);
            this.splMain.Panel1.Controls.Add(this.button1);
            this.splMain.Panel1.Controls.Add(this.label1);
            // 
            // splMain.Panel2
            // 
            this.splMain.Panel2.Controls.Add(this.separatorControl1);
            this.splMain.Panel2.Controls.Add(this.tblB2);
            this.splMain.Panel2.Controls.Add(this.label2);
            this.splMain.Size = new System.Drawing.Size(1904, 965);
            this.splMain.SplitterDistance = 482;
            this.splMain.SplitterWidth = 1;
            this.splMain.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1757, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 89;
            this.button2.Text = "Change Color";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tblB1
            // 
            this.tblB1.ColumnCount = 4;
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblB1.Location = new System.Drawing.Point(0, 45);
            this.tblB1.Name = "tblB1";
            this.tblB1.RowCount = 1;
            this.tblB1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblB1.Size = new System.Drawing.Size(1904, 437);
            this.tblB1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1904, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bottom 1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Location = new System.Drawing.Point(195, 11);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(1594, 23);
            this.separatorControl1.TabIndex = 8;
            // 
            // tblB2
            // 
            this.tblB2.ColumnCount = 4;
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblB2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblB2.Location = new System.Drawing.Point(0, 45);
            this.tblB2.Name = "tblB2";
            this.tblB2.RowCount = 1;
            this.tblB2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblB2.Size = new System.Drawing.Size(1904, 437);
            this.tblB2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1904, 45);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bottom 2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // SMT_SCADA_BOTTOM_COCKPIT
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.splMain);
            this.Controls.Add(this.pnTop);
            this.Name = "SMT_SCADA_BOTTOM_COCKPIT";
            this.Text = "ap";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_Load);
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_BOTTOM_COCKPIT_VisibleChanged);
            this.pnTop.ResumeLayout(false);
            this.a1Panel1.ResumeLayout(false);
            this.a1Panel1.PerformLayout();
            this.splMain.Panel1.ResumeLayout(false);
            this.splMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
            this.splMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splMain;
        private System.Windows.Forms.TableLayoutPanel tblB2;
        private System.Windows.Forms.TableLayoutPanel tblB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer tmrTime;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private OS_DSF.A1Panel a1Panel1;
        private RoundLabel rlblMalfunction;
        private RoundLabel rlblNormal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private RoundLabel rlblStopWork;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}