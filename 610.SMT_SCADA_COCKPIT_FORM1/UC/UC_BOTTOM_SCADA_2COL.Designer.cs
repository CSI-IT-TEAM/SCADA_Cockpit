namespace FORM.UC
{
    partial class UC_BOTTOM_SCADA_2COL
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
            this.lblCol2 = new System.Windows.Forms.Label();
            this.lblCol1 = new System.Windows.Forms.Label();
            this.colArea = new System.Windows.Forms.Label();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.lblTitle = new System.Windows.Forms.Label();
            this.a1Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // a1Panel1
            // 
            this.a1Panel1.BackColor = System.Drawing.Color.White;
            this.a1Panel1.BorderColor = System.Drawing.SystemColors.Highlight;
            this.a1Panel1.Controls.Add(this.lblCol2);
            this.a1Panel1.Controls.Add(this.lblCol1);
            this.a1Panel1.Controls.Add(this.colArea);
            this.a1Panel1.Controls.Add(this.xtraScrollableControl1);
            this.a1Panel1.Controls.Add(this.lblTitle);
            this.a1Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.a1Panel1.GradientEndColor = System.Drawing.Color.White;
            this.a1Panel1.GradientStartColor = System.Drawing.Color.White;
            this.a1Panel1.Image = null;
            this.a1Panel1.ImageLocation = new System.Drawing.Point(4, 4);
            this.a1Panel1.Location = new System.Drawing.Point(0, 0);
            this.a1Panel1.Name = "a1Panel1";
            this.a1Panel1.RoundCornerRadius = 10;
            this.a1Panel1.ShadowOffSet = 8;
            this.a1Panel1.Size = new System.Drawing.Size(470, 445);
            this.a1Panel1.TabIndex = 0;
            // 
            // lblCol2
            // 
            this.lblCol2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCol2.ForeColor = System.Drawing.Color.Black;
            this.lblCol2.Location = new System.Drawing.Point(284, 57);
            this.lblCol2.Name = "lblCol2";
            this.lblCol2.Size = new System.Drawing.Size(140, 24);
            this.lblCol2.TabIndex = 2;
            this.lblCol2.Text = "Stabilization";
            this.lblCol2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCol1
            // 
            this.lblCol1.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCol1.ForeColor = System.Drawing.Color.Black;
            this.lblCol1.Location = new System.Drawing.Point(122, 57);
            this.lblCol1.Name = "lblCol1";
            this.lblCol1.Size = new System.Drawing.Size(156, 24);
            this.lblCol1.TabIndex = 2;
            this.lblCol1.Text = "Injection";
            this.lblCol1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colArea
            // 
            this.colArea.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.colArea.ForeColor = System.Drawing.Color.Black;
            this.colArea.Location = new System.Drawing.Point(4, 57);
            this.colArea.Name = "colArea";
            this.colArea.Size = new System.Drawing.Size(97, 24);
            this.colArea.TabIndex = 3;
            this.colArea.Text = "Zone";
            this.colArea.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Location = new System.Drawing.Point(3, 84);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(457, 349);
            this.xtraScrollableControl1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.White;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblTitle.Location = new System.Drawing.Point(1, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(461, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // UC_BOTTOM_SCADA_2COL
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.a1Panel1);
            this.Name = "UC_BOTTOM_SCADA_2COL";
            this.Size = new System.Drawing.Size(470, 445);
            this.a1Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OS_DSF.A1Panel a1Panel1;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private System.Windows.Forms.Label colArea;
        private System.Windows.Forms.Label lblCol2;
        private System.Windows.Forms.Label lblCol1;
    }
}
