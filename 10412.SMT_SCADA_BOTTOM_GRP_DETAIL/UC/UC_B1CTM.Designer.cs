namespace FORM.UC
{
    partial class UC_B1CTM
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
            this.a1Panel1 = new OS_DSF.A1Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCool = new System.Windows.Forms.Label();
            this.lblHeat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMC = new System.Windows.Forms.Label();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel1
            // 
            this.a1Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.a1Panel1.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.a1Panel1.Controls.Add(this.label3);
            this.a1Panel1.Controls.Add(this.lblCool);
            this.a1Panel1.Controls.Add(this.lblHeat);
            this.a1Panel1.Controls.Add(this.label2);
            this.a1Panel1.Controls.Add(this.lblMC);
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(3, 4);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 20;
            this.a1Panel1.ShadowOffSet = 6;
            this.a1Panel1.Size = new System.Drawing.Size(194, 83);
            this.a1Panel1.TabIndex = 0;
            this.a1Panel1.Click += new System.EventHandler(this.a1Panel1_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DodgerBlue;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(110, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cool";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label_Click);
            // 
            // lblCool
            // 
            this.lblCool.BackColor = System.Drawing.Color.Silver;
            this.lblCool.Font = new System.Drawing.Font("DS-Digital", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCool.ForeColor = System.Drawing.Color.White;
            this.lblCool.Location = new System.Drawing.Point(110, 32);
            this.lblCool.Name = "lblCool";
            this.lblCool.Size = new System.Drawing.Size(67, 38);
            this.lblCool.TabIndex = 0;
            this.lblCool.Text = "0°C";
            this.lblCool.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCool.Click += new System.EventHandler(this.label_Click);
            // 
            // lblHeat
            // 
            this.lblHeat.BackColor = System.Drawing.Color.Silver;
            this.lblHeat.Font = new System.Drawing.Font("DS-Digital", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeat.ForeColor = System.Drawing.Color.White;
            this.lblHeat.Location = new System.Drawing.Point(37, 32);
            this.lblHeat.Name = "lblHeat";
            this.lblHeat.Size = new System.Drawing.Size(67, 38);
            this.lblHeat.TabIndex = 0;
            this.lblHeat.Text = "0°C";
            this.lblHeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHeat.Click += new System.EventHandler(this.label_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Heat";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label_Click);
            // 
            // lblMC
            // 
            this.lblMC.BackColor = System.Drawing.Color.Silver;
            this.lblMC.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMC.Location = new System.Drawing.Point(3, 5);
            this.lblMC.Name = "lblMC";
            this.lblMC.Size = new System.Drawing.Size(28, 65);
            this.lblMC.TabIndex = 0;
            this.lblMC.Text = "-";
            this.lblMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMC.Click += new System.EventHandler(this.label_Click);
            // 
            // UC_B1CTM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(54)))));
            this.Controls.Add(this.a1Panel1);
            this.Name = "UC_B1CTM";
            this.Size = new System.Drawing.Size(200, 90);
            this.a1Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OS_DSF.A1Panel a1Panel1;
        private System.Windows.Forms.Label lblMC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCool;
        private System.Windows.Forms.Label lblHeat;
    }
}
