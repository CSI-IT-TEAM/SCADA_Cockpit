namespace FORM.UC
{
    partial class UC_WS_INFO
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_WS_INFO));
            this.lblPlantName = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPlantQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWip_Qty = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRateInv_Plan = new System.Windows.Forms.Label();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblLT = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlantName
            // 
            this.lblPlantName.BackColor = System.Drawing.Color.SteelBlue;
            this.lblPlantName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPlantName.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantName.ForeColor = System.Drawing.Color.White;
            this.lblPlantName.Location = new System.Drawing.Point(0, 0);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(193, 44);
            this.lblPlantName.TabIndex = 0;
            this.lblPlantName.Text = "Plant Name";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPlantName.Click += new System.EventHandler(this.lblPlantName_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.lblPlantQty);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.lblWip_Qty);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.lblRateInv_Plan);
            this.flowLayoutPanel1.ForeColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(-4, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(205, 103);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plan";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlantQty
            // 
            this.lblPlantQty.BackColor = System.Drawing.Color.Gray;
            this.lblPlantQty.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblPlantQty.ForeColor = System.Drawing.Color.White;
            this.lblPlantQty.Location = new System.Drawing.Point(78, 0);
            this.lblPlantQty.Name = "lblPlantQty";
            this.lblPlantQty.Size = new System.Drawing.Size(120, 33);
            this.lblPlantQty.TabIndex = 1;
            this.lblPlantQty.Text = "0 Prs";
            this.lblPlantQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Lavender;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "Inv";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblWip_Qty
            // 
            this.lblWip_Qty.BackColor = System.Drawing.Color.Gray;
            this.lblWip_Qty.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblWip_Qty.ForeColor = System.Drawing.Color.Lavender;
            this.lblWip_Qty.Location = new System.Drawing.Point(78, 33);
            this.lblWip_Qty.Name = "lblWip_Qty";
            this.lblWip_Qty.Size = new System.Drawing.Size(120, 33);
            this.lblWip_Qty.TabIndex = 3;
            this.lblWip_Qty.Text = "0 Prs";
            this.lblWip_Qty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DarkOrange;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 33);
            this.label5.TabIndex = 4;
            this.label5.Text = "Rate";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRateInv_Plan
            // 
            this.lblRateInv_Plan.BackColor = System.Drawing.Color.DarkOrange;
            this.lblRateInv_Plan.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.lblRateInv_Plan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRateInv_Plan.Location = new System.Drawing.Point(78, 66);
            this.lblRateInv_Plan.Name = "lblRateInv_Plan";
            this.lblRateInv_Plan.Size = new System.Drawing.Size(120, 33);
            this.lblRateInv_Plan.TabIndex = 5;
            this.lblRateInv_Plan.Text = "0%";
            this.lblRateInv_Plan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(3, 150);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Properties.EndColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBarControl1.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.progressBarControl1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.progressBarControl1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.progressBarControl1.Properties.Maximum = 5;
            this.progressBarControl1.Properties.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBarControl1.Properties.Step = 1;
            this.progressBarControl1.Size = new System.Drawing.Size(184, 10);
            this.progressBarControl1.TabIndex = 3;
            this.progressBarControl1.Visible = false;
            // 
            // lblLT
            // 
            this.lblLT.Font = new System.Drawing.Font("Calibri", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLT.ForeColor = System.Drawing.Color.Black;
            this.lblLT.Location = new System.Drawing.Point(27, 155);
            this.lblLT.Name = "lblLT";
            this.lblLT.Size = new System.Drawing.Size(150, 21);
            this.lblLT.TabIndex = 5;
            this.lblLT.Text = "Leadtime: 2.5 Days";
            this.lblLT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Calibri", 18.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(0, 204);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(193, 42);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Balance Detail";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold);
            this.lblProgress.Location = new System.Drawing.Point(10, 169);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(177, 37);
            this.lblProgress.TabIndex = 6;
            this.lblProgress.Text = "██████████";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_WS_INFO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLT);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblPlantName);
            this.Name = "UC_WS_INFO";
            this.Size = new System.Drawing.Size(193, 249);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPlantQty;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Label lblWip_Qty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRateInv_Plan;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private System.Windows.Forms.Label lblLT;
        private System.Windows.Forms.Label lblProgress;
    }
}
