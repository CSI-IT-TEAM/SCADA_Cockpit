namespace FORM
{
    partial class SMT_SCADA_B2_PU_MAT1_TEMPER
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_B2_PU_MAT1_TEMPER));
            this.pnTop = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.cmdBack = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_iso2_war = new System.Windows.Forms.Label();
            this.lbl_iso1_war = new System.Windows.Forms.Label();
            this.lbl_iso2_war1 = new System.Windows.Forms.Label();
            this.lbl_poly_war = new System.Windows.Forms.Label();
            this.lbl_iso1_war1 = new System.Windows.Forms.Label();
            this.lbl_iso2_hea = new System.Windows.Forms.Label();
            this.lbl_poly_war1 = new System.Windows.Forms.Label();
            this.lbl_iso2_hea1 = new System.Windows.Forms.Label();
            this.lbl_w3 = new System.Windows.Forms.Label();
            this.lbl_w2 = new System.Windows.Forms.Label();
            this.lbl_w1 = new System.Windows.Forms.Label();
            this.lbl_iso1_hea = new System.Windows.Forms.Label();
            this.lbl_h3 = new System.Windows.Forms.Label();
            this.lbl_iso1_hea1 = new System.Windows.Forms.Label();
            this.lbl_act = new System.Windows.Forms.Label();
            this.lbl_poly_hea = new System.Windows.Forms.Label();
            this.lbl_h2 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_stan = new System.Windows.Forms.Label();
            this.lbl_poly_hea1 = new System.Windows.Forms.Label();
            this.lblHeatingTitle = new System.Windows.Forms.Label();
            this.tmrDate = new System.Windows.Forms.Timer(this.components);
            this.tmrAnimation = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tmrBlinking = new System.Windows.Forms.Timer(this.components);
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pnTop.Size = new System.Drawing.Size(1920, 76);
            this.pnTop.TabIndex = 10;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1082, 33);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 89;
            this.btnTest.Text = "button1";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
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
            this.lblDate.Location = new System.Drawing.Point(1685, 0);
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
            this.lblHeader.Size = new System.Drawing.Size(1059, 76);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "        PU Material Temperature Tracking";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkCyan;
            this.label10.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(236, 800);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 251);
            this.label10.TabIndex = 34;
            this.label10.Text = "ISO 2";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkCyan;
            this.label9.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(236, 541);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(193, 251);
            this.label9.TabIndex = 33;
            this.label9.Text = "ISO 1";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label2.Font = new System.Drawing.Font("Calibri", 50F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(236, 282);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 251);
            this.label2.TabIndex = 32;
            this.label2.Text = "POLY";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso2_war
            // 
            this.lbl_iso2_war.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_iso2_war.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso2_war.ForeColor = System.Drawing.Color.Lime;
            this.lbl_iso2_war.Location = new System.Drawing.Point(1276, 929);
            this.lbl_iso2_war.Name = "lbl_iso2_war";
            this.lbl_iso2_war.Size = new System.Drawing.Size(384, 122);
            this.lbl_iso2_war.TabIndex = 30;
            this.lbl_iso2_war.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso1_war
            // 
            this.lbl_iso1_war.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_iso1_war.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso1_war.ForeColor = System.Drawing.Color.Lime;
            this.lbl_iso1_war.Location = new System.Drawing.Point(1276, 670);
            this.lbl_iso1_war.Name = "lbl_iso1_war";
            this.lbl_iso1_war.Size = new System.Drawing.Size(384, 122);
            this.lbl_iso1_war.TabIndex = 29;
            this.lbl_iso1_war.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso2_war1
            // 
            this.lbl_iso2_war1.BackColor = System.Drawing.Color.Blue;
            this.lbl_iso2_war1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso2_war1.ForeColor = System.Drawing.Color.White;
            this.lbl_iso2_war1.Location = new System.Drawing.Point(871, 929);
            this.lbl_iso2_war1.Name = "lbl_iso2_war1";
            this.lbl_iso2_war1.Size = new System.Drawing.Size(385, 122);
            this.lbl_iso2_war1.TabIndex = 28;
            this.lbl_iso2_war1.Text = "40°C - 50°C";
            this.lbl_iso2_war1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_poly_war
            // 
            this.lbl_poly_war.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_poly_war.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poly_war.ForeColor = System.Drawing.Color.Lime;
            this.lbl_poly_war.Location = new System.Drawing.Point(1276, 411);
            this.lbl_poly_war.Name = "lbl_poly_war";
            this.lbl_poly_war.Size = new System.Drawing.Size(384, 122);
            this.lbl_poly_war.TabIndex = 27;
            this.lbl_poly_war.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso1_war1
            // 
            this.lbl_iso1_war1.BackColor = System.Drawing.Color.Blue;
            this.lbl_iso1_war1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso1_war1.ForeColor = System.Drawing.Color.White;
            this.lbl_iso1_war1.Location = new System.Drawing.Point(871, 670);
            this.lbl_iso1_war1.Name = "lbl_iso1_war1";
            this.lbl_iso1_war1.Size = new System.Drawing.Size(390, 122);
            this.lbl_iso1_war1.TabIndex = 26;
            this.lbl_iso1_war1.Text = "40°C - 50°C";
            this.lbl_iso1_war1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso2_hea
            // 
            this.lbl_iso2_hea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_iso2_hea.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso2_hea.ForeColor = System.Drawing.Color.Lime;
            this.lbl_iso2_hea.Location = new System.Drawing.Point(1276, 800);
            this.lbl_iso2_hea.Name = "lbl_iso2_hea";
            this.lbl_iso2_hea.Size = new System.Drawing.Size(384, 122);
            this.lbl_iso2_hea.TabIndex = 25;
            this.lbl_iso2_hea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_poly_war1
            // 
            this.lbl_poly_war1.BackColor = System.Drawing.Color.Blue;
            this.lbl_poly_war1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poly_war1.ForeColor = System.Drawing.Color.White;
            this.lbl_poly_war1.Location = new System.Drawing.Point(871, 411);
            this.lbl_poly_war1.Name = "lbl_poly_war1";
            this.lbl_poly_war1.Size = new System.Drawing.Size(390, 122);
            this.lbl_poly_war1.TabIndex = 24;
            this.lbl_poly_war1.Text = "40°C - 50°C";
            this.lbl_poly_war1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso2_hea1
            // 
            this.lbl_iso2_hea1.BackColor = System.Drawing.Color.Blue;
            this.lbl_iso2_hea1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso2_hea1.ForeColor = System.Drawing.Color.White;
            this.lbl_iso2_hea1.Location = new System.Drawing.Point(871, 800);
            this.lbl_iso2_hea1.Name = "lbl_iso2_hea1";
            this.lbl_iso2_hea1.Size = new System.Drawing.Size(390, 122);
            this.lbl_iso2_hea1.TabIndex = 23;
            this.lbl_iso2_hea1.Text = "70°C - 80°C";
            this.lbl_iso2_hea1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_w3
            // 
            this.lbl_w3.BackColor = System.Drawing.Color.Gold;
            this.lbl_w3.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_w3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_w3.Location = new System.Drawing.Point(435, 929);
            this.lbl_w3.Name = "lbl_w3";
            this.lbl_w3.Size = new System.Drawing.Size(430, 122);
            this.lbl_w3.TabIndex = 11;
            this.lbl_w3.Text = "Warming";
            this.lbl_w3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_w2
            // 
            this.lbl_w2.BackColor = System.Drawing.Color.Gold;
            this.lbl_w2.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_w2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_w2.Location = new System.Drawing.Point(435, 670);
            this.lbl_w2.Name = "lbl_w2";
            this.lbl_w2.Size = new System.Drawing.Size(430, 122);
            this.lbl_w2.TabIndex = 21;
            this.lbl_w2.Text = "Warming";
            this.lbl_w2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_w1
            // 
            this.lbl_w1.BackColor = System.Drawing.Color.Gold;
            this.lbl_w1.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_w1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_w1.Location = new System.Drawing.Point(435, 411);
            this.lbl_w1.Name = "lbl_w1";
            this.lbl_w1.Size = new System.Drawing.Size(430, 122);
            this.lbl_w1.TabIndex = 20;
            this.lbl_w1.Text = "Warming";
            this.lbl_w1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso1_hea
            // 
            this.lbl_iso1_hea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_iso1_hea.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso1_hea.ForeColor = System.Drawing.Color.Lime;
            this.lbl_iso1_hea.Location = new System.Drawing.Point(1276, 541);
            this.lbl_iso1_hea.Name = "lbl_iso1_hea";
            this.lbl_iso1_hea.Size = new System.Drawing.Size(384, 122);
            this.lbl_iso1_hea.TabIndex = 19;
            this.lbl_iso1_hea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_h3
            // 
            this.lbl_h3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_h3.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_h3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_h3.Location = new System.Drawing.Point(435, 800);
            this.lbl_h3.Name = "lbl_h3";
            this.lbl_h3.Size = new System.Drawing.Size(430, 122);
            this.lbl_h3.TabIndex = 18;
            this.lbl_h3.Text = "Heating";
            this.lbl_h3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_iso1_hea1
            // 
            this.lbl_iso1_hea1.BackColor = System.Drawing.Color.Blue;
            this.lbl_iso1_hea1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_iso1_hea1.ForeColor = System.Drawing.Color.White;
            this.lbl_iso1_hea1.Location = new System.Drawing.Point(871, 541);
            this.lbl_iso1_hea1.Name = "lbl_iso1_hea1";
            this.lbl_iso1_hea1.Size = new System.Drawing.Size(390, 122);
            this.lbl_iso1_hea1.TabIndex = 17;
            this.lbl_iso1_hea1.Text = "70°C - 80°C";
            this.lbl_iso1_hea1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_act
            // 
            this.lbl_act.BackColor = System.Drawing.Color.Gray;
            this.lbl_act.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_act.ForeColor = System.Drawing.Color.Lime;
            this.lbl_act.Location = new System.Drawing.Point(1277, 168);
            this.lbl_act.Name = "lbl_act";
            this.lbl_act.Size = new System.Drawing.Size(384, 103);
            this.lbl_act.TabIndex = 16;
            this.lbl_act.Text = "ACTUAL";
            this.lbl_act.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_poly_hea
            // 
            this.lbl_poly_hea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(117)))));
            this.lbl_poly_hea.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poly_hea.ForeColor = System.Drawing.Color.Lime;
            this.lbl_poly_hea.Location = new System.Drawing.Point(1276, 282);
            this.lbl_poly_hea.Name = "lbl_poly_hea";
            this.lbl_poly_hea.Size = new System.Drawing.Size(384, 122);
            this.lbl_poly_hea.TabIndex = 15;
            this.lbl_poly_hea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_h2
            // 
            this.lbl_h2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lbl_h2.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_h2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_h2.Location = new System.Drawing.Point(435, 541);
            this.lbl_h2.Name = "lbl_h2";
            this.lbl_h2.Size = new System.Drawing.Size(430, 122);
            this.lbl_h2.TabIndex = 14;
            this.lbl_h2.Text = "Heating";
            this.lbl_h2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkOrange;
            this.label17.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(871, 96);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(790, 63);
            this.label17.TabIndex = 13;
            this.label17.Text = "TEMPERTURE °C";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_stan
            // 
            this.lbl_stan.BackColor = System.Drawing.Color.Blue;
            this.lbl_stan.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lbl_stan.ForeColor = System.Drawing.Color.White;
            this.lbl_stan.Location = new System.Drawing.Point(872, 168);
            this.lbl_stan.Name = "lbl_stan";
            this.lbl_stan.Size = new System.Drawing.Size(390, 103);
            this.lbl_stan.TabIndex = 12;
            this.lbl_stan.Text = "STANDARD";
            this.lbl_stan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_poly_hea1
            // 
            this.lbl_poly_hea1.BackColor = System.Drawing.Color.Blue;
            this.lbl_poly_hea1.Font = new System.Drawing.Font("DS-Digital", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_poly_hea1.ForeColor = System.Drawing.Color.White;
            this.lbl_poly_hea1.Location = new System.Drawing.Point(871, 282);
            this.lbl_poly_hea1.Name = "lbl_poly_hea1";
            this.lbl_poly_hea1.Size = new System.Drawing.Size(390, 122);
            this.lbl_poly_hea1.TabIndex = 31;
            this.lbl_poly_hea1.Text = "60°C - 70°C";
            this.lbl_poly_hea1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeatingTitle
            // 
            this.lblHeatingTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblHeatingTitle.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold);
            this.lblHeatingTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHeatingTitle.Location = new System.Drawing.Point(435, 282);
            this.lblHeatingTitle.Name = "lblHeatingTitle";
            this.lblHeatingTitle.Size = new System.Drawing.Size(430, 122);
            this.lblHeatingTitle.TabIndex = 22;
            this.lblHeatingTitle.Text = "Heating";
            this.lblHeatingTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrDate
            // 
            this.tmrDate.Enabled = true;
            this.tmrDate.Interval = 1000;
            this.tmrDate.Tick += new System.EventHandler(this.tmrDate_Tick);
            // 
            // tmrAnimation
            // 
            this.tmrAnimation.Enabled = true;
            this.tmrAnimation.Interval = 50;
            this.tmrAnimation.Tick += new System.EventHandler(this.tmrAnimation_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(436, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(429, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // tmrBlinking
            // 
            this.tmrBlinking.Enabled = true;
            this.tmrBlinking.Interval = 500;
            this.tmrBlinking.Tick += new System.EventHandler(this.tmrBlinking_Tick);
            // 
            // SMT_SCADA_B2_PU_MAT1_TEMPER
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_iso2_war);
            this.Controls.Add(this.lbl_iso1_war);
            this.Controls.Add(this.lbl_iso2_war1);
            this.Controls.Add(this.lbl_poly_war);
            this.Controls.Add(this.lbl_iso1_war1);
            this.Controls.Add(this.lbl_iso2_hea);
            this.Controls.Add(this.lbl_poly_war1);
            this.Controls.Add(this.lbl_iso2_hea1);
            this.Controls.Add(this.lbl_w3);
            this.Controls.Add(this.lbl_w2);
            this.Controls.Add(this.lbl_w1);
            this.Controls.Add(this.lbl_iso1_hea);
            this.Controls.Add(this.lbl_h3);
            this.Controls.Add(this.lbl_iso1_hea1);
            this.Controls.Add(this.lbl_act);
            this.Controls.Add(this.lbl_poly_hea);
            this.Controls.Add(this.lbl_h2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_stan);
            this.Controls.Add(this.lbl_poly_hea1);
            this.Controls.Add(this.lblHeatingTitle);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SMT_SCADA_B2_PU_MAT1_TEMPER";
            this.Text = "SMT_SCADA_B2_PU_MAT1_TEMPER";
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_B2_PU_MAT1_TEMPER_VisibleChanged);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Button btnTest;
        public System.Windows.Forms.Button cmdBack;
        private System.Windows.Forms.Label lblDate;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_iso2_war;
        private System.Windows.Forms.Label lbl_iso1_war;
        private System.Windows.Forms.Label lbl_iso2_war1;
        private System.Windows.Forms.Label lbl_poly_war;
        private System.Windows.Forms.Label lbl_iso1_war1;
        private System.Windows.Forms.Label lbl_iso2_hea;
        private System.Windows.Forms.Label lbl_poly_war1;
        private System.Windows.Forms.Label lbl_iso2_hea1;
        private System.Windows.Forms.Label lbl_w3;
        private System.Windows.Forms.Label lbl_w2;
        private System.Windows.Forms.Label lbl_w1;
        private System.Windows.Forms.Label lbl_iso1_hea;
        private System.Windows.Forms.Label lbl_h3;
        private System.Windows.Forms.Label lbl_iso1_hea1;
        private System.Windows.Forms.Label lbl_act;
        private System.Windows.Forms.Label lbl_poly_hea;
        private System.Windows.Forms.Label lbl_h2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_stan;
        private System.Windows.Forms.Label lbl_poly_hea1;
        private System.Windows.Forms.Label lblHeatingTitle;
        private System.Windows.Forms.Timer tmrDate;
        private System.Windows.Forms.Timer tmrAnimation;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer tmrBlinking;
    }
}