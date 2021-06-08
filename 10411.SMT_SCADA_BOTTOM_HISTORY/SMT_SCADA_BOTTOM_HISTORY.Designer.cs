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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_BOTTOM_HISTORY));
            DevExpress.XtraCharts.Series series4 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView5 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series5 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView6 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.Series series6 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView7 = new DevExpress.XtraCharts.SplineSeriesView();
            DevExpress.XtraCharts.SplineSeriesView splineSeriesView8 = new DevExpress.XtraCharts.SplineSeriesView();
            this.pn_Main = new System.Windows.Forms.Panel();
            this.pn_Top = new System.Windows.Forms.Panel();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.pnTop = new System.Windows.Forms.Panel();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.tmrTime = new System.Windows.Forms.Timer();
            this.pn_Chart = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.a1Panel1 = new OS_DSF.A1Panel();
            this.cht_Chart = new DevExpress.XtraCharts.ChartControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.pn_Main.SuspendLayout();
            this.pn_Top.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.pn_Chart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.a1Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView8)).BeginInit();
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
            // pn_Top
            // 
            this.pn_Top.Controls.Add(this.pnTop);
            this.pn_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_Top.Location = new System.Drawing.Point(0, 0);
            this.pn_Top.Name = "pn_Top";
            this.pn_Top.Size = new System.Drawing.Size(1904, 78);
            this.pn_Top.TabIndex = 0;
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
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
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
            this.tableLayoutPanel1.Controls.Add(this.cht_Chart, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.a1Panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1904, 963);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Tag = "10411";
            // 
            // a1Panel1
            // 
            this.a1Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.a1Panel1.BorderColor = System.Drawing.Color.White;
            this.a1Panel1.Controls.Add(this.checkBox6);
            this.a1Panel1.Controls.Add(this.checkBox5);
            this.a1Panel1.Controls.Add(this.checkBox4);
            this.a1Panel1.Controls.Add(this.checkBox3);
            this.a1Panel1.Controls.Add(this.checkBox2);
            this.a1Panel1.Controls.Add(this.checkBox1);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 3);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.Size = new System.Drawing.Size(318, 957);
            this.a1Panel1.TabIndex = 0;
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
            this.cht_Chart.Location = new System.Drawing.Point(327, 3);
            this.cht_Chart.Name = "cht_Chart";
            this.cht_Chart.PaletteName = "Marquee";
            series4.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.Name = "Production";
            splineSeriesView5.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series4.View = splineSeriesView5;
            series4.Visible = false;
            series5.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.Name = "Manpower";
            splineSeriesView6.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series5.View = splineSeriesView6;
            series5.Visible = false;
            series6.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.Name = "Budget";
            splineSeriesView7.MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            series6.View = splineSeriesView7;
            series6.Visible = false;
            this.cht_Chart.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series4,
        series5,
        series6};
            this.cht_Chart.SeriesTemplate.View = splineSeriesView8;
            this.cht_Chart.Size = new System.Drawing.Size(1574, 957);
            this.cht_Chart.TabIndex = 21;
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(9, 53);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(285, 41);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Machine Bambury 001";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.checkBox2.Location = new System.Drawing.Point(9, 211);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(285, 41);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Machine Bambury 002";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(101, 113);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(193, 28);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "001";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox4.Location = new System.Drawing.Point(101, 160);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(193, 28);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Text = "002";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox5.Location = new System.Drawing.Point(101, 270);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(193, 28);
            this.checkBox5.TabIndex = 1;
            this.checkBox5.Text = "001";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.checkBox6.Location = new System.Drawing.Point(101, 316);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(193, 28);
            this.checkBox6.TabIndex = 1;
            this.checkBox6.Text = "002";
            this.checkBox6.UseVisualStyleBackColor = true;
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
            this.pn_Top.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pn_Chart.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.a1Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(splineSeriesView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Chart)).EndInit();
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
        private DevExpress.XtraCharts.ChartControl cht_Chart;
        private OS_DSF.A1Panel a1Panel1;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}