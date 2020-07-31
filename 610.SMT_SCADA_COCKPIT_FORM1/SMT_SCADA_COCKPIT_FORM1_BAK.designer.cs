namespace FORM
{
    partial class SMT_SCADA_COCKPIT_FORM1_BAK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_COCKPIT_FORM1_BAK));
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdF4 = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gpF4 = new FORM.GroupBoxEx();
            this.gpF5 = new FORM.GroupBoxEx();
            this.gpF1 = new FORM.GroupBoxEx();
            this.aPn3 = new FORM.AdvancedPanel();
            this.aPn2 = new FORM.AdvancedPanel();
            this.aPn1 = new FORM.AdvancedPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gpF2 = new FORM.GroupBoxEx();
            this.gpF3 = new FORM.GroupBoxEx();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gpF1.SuspendLayout();
            this.aPn1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBand12
            // 
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.VisibleIndex = -1;
            // 
            // tmrTime
            // 
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.cmdF4);
            this.panel1.Controls.Add(this.cmdBack);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 110);
            this.panel1.TabIndex = 21;
            // 
            // cmdF4
            // 
            this.cmdF4.BackColor = System.Drawing.Color.Transparent;
            this.cmdF4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdF4.BackgroundImage")));
            this.cmdF4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdF4.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdF4.FlatAppearance.BorderSize = 0;
            this.cmdF4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdF4.Location = new System.Drawing.Point(1210, 3);
            this.cmdF4.Name = "cmdF4";
            this.cmdF4.Size = new System.Drawing.Size(108, 101);
            this.cmdF4.TabIndex = 68;
            this.cmdF4.UseVisualStyleBackColor = false;
            this.cmdF4.Click += new System.EventHandler(this.cmdF4_Click);
            // 
            // cmdBack
            // 
            this.cmdBack.BackColor = System.Drawing.Color.Transparent;
            this.cmdBack.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdBack.BackgroundImage")));
            this.cmdBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.cmdBack.FlatAppearance.BorderSize = 0;
            this.cmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdBack.Location = new System.Drawing.Point(1388, 5);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(108, 101);
            this.cmdBack.TabIndex = 67;
            this.cmdBack.UseVisualStyleBackColor = false;
            this.cmdBack.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1614, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(306, 110);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.DoubleClick += new System.EventHandler(this.lblDate_DoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Calibri", 62F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1065, 110);
            this.label1.TabIndex = 0;
            this.label1.Text = "SCADA Cockpit";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.gpF4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gpF5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.gpF1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpF2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gpF3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 110);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1920, 970);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // gpF4
            // 
            this.gpF4.BackgroundPanelImage = null;
            this.gpF4.DrawGroupBorder = true;
            this.gpF4.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpF4.ForeColor = System.Drawing.Color.DarkOrange;
            this.gpF4.GroupBorderColor = System.Drawing.Color.Blue;
            this.gpF4.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.gpF4.GroupPanelShape = FORM.GroupBoxEx.PanelType.Squared;
            this.gpF4.GroupPanelWith = 2F;
            this.gpF4.Location = new System.Drawing.Point(3, 488);
            this.gpF4.Name = "gpF4";
            this.gpF4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpF4.Size = new System.Drawing.Size(633, 479);
            this.gpF4.TabIndex = 8;
            this.gpF4.TabStop = false;
            this.gpF4.Text = "Factory 4";
            this.gpF4.TextBackColor = System.Drawing.Color.White;
            this.gpF4.TextBorderColor = System.Drawing.Color.Blue;
            this.gpF4.TextBorderWith = 2F;
            // 
            // gpF5
            // 
            this.gpF5.BackgroundPanelImage = null;
            this.gpF5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpF5.DrawGroupBorder = true;
            this.gpF5.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpF5.ForeColor = System.Drawing.Color.DarkOrange;
            this.gpF5.GroupBorderColor = System.Drawing.Color.Blue;
            this.gpF5.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.gpF5.GroupPanelShape = FORM.GroupBoxEx.PanelType.Squared;
            this.gpF5.GroupPanelWith = 2F;
            this.gpF5.Location = new System.Drawing.Point(642, 488);
            this.gpF5.Name = "gpF5";
            this.gpF5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpF5.Size = new System.Drawing.Size(634, 479);
            this.gpF5.TabIndex = 7;
            this.gpF5.TabStop = false;
            this.gpF5.Text = "Factory 5";
            this.gpF5.TextBackColor = System.Drawing.Color.White;
            this.gpF5.TextBorderColor = System.Drawing.Color.Blue;
            this.gpF5.TextBorderWith = 2F;
            // 
            // gpF1
            // 
            this.gpF1.BackgroundPanelImage = null;
            this.gpF1.Controls.Add(this.aPn3);
            this.gpF1.Controls.Add(this.aPn2);
            this.gpF1.Controls.Add(this.aPn1);
            this.gpF1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpF1.DrawGroupBorder = true;
            this.gpF1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpF1.ForeColor = System.Drawing.Color.DarkOrange;
            this.gpF1.GroupBorderColor = System.Drawing.Color.Blue;
            this.gpF1.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.gpF1.GroupPanelShape = FORM.GroupBoxEx.PanelType.Squared;
            this.gpF1.GroupPanelWith = 2F;
            this.gpF1.Location = new System.Drawing.Point(3, 3);
            this.gpF1.Name = "gpF1";
            this.gpF1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpF1.Size = new System.Drawing.Size(633, 479);
            this.gpF1.TabIndex = 3;
            this.gpF1.TabStop = false;
            this.gpF1.Text = "Factory 1";
            this.gpF1.TextBackColor = System.Drawing.Color.White;
            this.gpF1.TextBorderColor = System.Drawing.Color.Blue;
            this.gpF1.TextBorderWith = 2F;
            // 
            // aPn3
            // 
            this.aPn3.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.aPn3.EdgeWidth = 1;
            this.aPn3.EndColor = System.Drawing.Color.White;
            this.aPn3.FlatBorderColor = System.Drawing.Color.Turquoise;
            this.aPn3.Location = new System.Drawing.Point(8, 255);
            this.aPn3.Name = "aPn3";
            this.aPn3.Padding = new System.Windows.Forms.Padding(2);
            this.aPn3.RectRadius = 0;
            this.aPn3.ShadowColor = System.Drawing.Color.DimGray;
            this.aPn3.ShadowShift = 5;
            this.aPn3.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.aPn3.Size = new System.Drawing.Size(619, 228);
            this.aPn3.StartColor = System.Drawing.Color.White;
            this.aPn3.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.aPn3.TabIndex = 3;
            // 
            // aPn2
            // 
            this.aPn2.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.aPn2.EdgeWidth = 1;
            this.aPn2.EndColor = System.Drawing.Color.White;
            this.aPn2.FlatBorderColor = System.Drawing.Color.DarkTurquoise;
            this.aPn2.Location = new System.Drawing.Point(327, 46);
            this.aPn2.Name = "aPn2";
            this.aPn2.Padding = new System.Windows.Forms.Padding(2);
            this.aPn2.RectRadius = 0;
            this.aPn2.ShadowColor = System.Drawing.Color.DimGray;
            this.aPn2.ShadowShift = 5;
            this.aPn2.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.aPn2.Size = new System.Drawing.Size(300, 190);
            this.aPn2.StartColor = System.Drawing.Color.White;
            this.aPn2.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.aPn2.TabIndex = 2;
            // 
            // aPn1
            // 
            this.aPn1.BackgroundGradientMode = FORM.AdvancedPanel.PanelGradientMode.Vertical;
            this.aPn1.Controls.Add(this.button4);
            this.aPn1.Controls.Add(this.button3);
            this.aPn1.Controls.Add(this.button2);
            this.aPn1.Controls.Add(this.button1);
            this.aPn1.Controls.Add(this.label2);
            this.aPn1.EdgeWidth = 1;
            this.aPn1.EndColor = System.Drawing.Color.White;
            this.aPn1.FlatBorderColor = System.Drawing.Color.DarkTurquoise;
            this.aPn1.ForeColor = System.Drawing.Color.Black;
            this.aPn1.Location = new System.Drawing.Point(8, 46);
            this.aPn1.Name = "aPn1";
            this.aPn1.Padding = new System.Windows.Forms.Padding(2);
            this.aPn1.RectRadius = 0;
            this.aPn1.ShadowColor = System.Drawing.Color.DimGray;
            this.aPn1.ShadowShift = 5;
            this.aPn1.ShadowStyle = FORM.AdvancedPanel.ShadowMode.Dropped;
            this.aPn1.Size = new System.Drawing.Size(300, 190);
            this.aPn1.StartColor = System.Drawing.Color.White;
            this.aPn1.Style = FORM.AdvancedPanel.BevelStyle.Flat;
            this.aPn1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(203, 68);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 39);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(139, 68);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(75, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(10, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 33);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // gpF2
            // 
            this.gpF2.BackgroundPanelImage = null;
            this.gpF2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpF2.DrawGroupBorder = true;
            this.gpF2.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpF2.ForeColor = System.Drawing.Color.DarkOrange;
            this.gpF2.GroupBorderColor = System.Drawing.Color.Blue;
            this.gpF2.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.gpF2.GroupPanelShape = FORM.GroupBoxEx.PanelType.Squared;
            this.gpF2.GroupPanelWith = 2F;
            this.gpF2.Location = new System.Drawing.Point(642, 3);
            this.gpF2.Name = "gpF2";
            this.gpF2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpF2.Size = new System.Drawing.Size(634, 479);
            this.gpF2.TabIndex = 9;
            this.gpF2.TabStop = false;
            this.gpF2.Text = "Factory 2";
            this.gpF2.TextBackColor = System.Drawing.Color.White;
            this.gpF2.TextBorderColor = System.Drawing.Color.Blue;
            this.gpF2.TextBorderWith = 2F;
            // 
            // gpF3
            // 
            this.gpF3.BackgroundPanelImage = null;
            this.gpF3.DrawGroupBorder = true;
            this.gpF3.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpF3.ForeColor = System.Drawing.Color.DarkOrange;
            this.gpF3.GroupBorderColor = System.Drawing.Color.Blue;
            this.gpF3.GroupPanelColor = System.Drawing.SystemColors.Control;
            this.gpF3.GroupPanelShape = FORM.GroupBoxEx.PanelType.Squared;
            this.gpF3.GroupPanelWith = 2F;
            this.gpF3.Location = new System.Drawing.Point(1282, 3);
            this.gpF3.Name = "gpF3";
            this.gpF3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gpF3.Size = new System.Drawing.Size(633, 479);
            this.gpF3.TabIndex = 6;
            this.gpF3.TabStop = false;
            this.gpF3.Text = "Factory 3";
            this.gpF3.TextBackColor = System.Drawing.Color.White;
            this.gpF3.TextBorderColor = System.Drawing.Color.Blue;
            this.gpF3.TextBorderWith = 2F;
            // 
            // SMT_SCADA_COCKPIT_FORM1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SMT_SCADA_COCKPIT_FORM1";
            this.Text = "Form1";
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_MENU_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gpF1.ResumeLayout(false);
            this.aPn1.ResumeLayout(false);
            this.aPn1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private GroupBoxEx gpF1;
        private AdvancedPanel aPn1;
        private AdvancedPanel aPn3;
        private AdvancedPanel aPn2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private GroupBoxEx gpF4;
        private GroupBoxEx gpF5;
        private GroupBoxEx gpF2;
        private GroupBoxEx gpF3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button cmdF4;
    }
}