namespace FORM.UC
{
    partial class UC_Machine
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
            this.picMachine = new System.Windows.Forms.PictureBox();
            this.cmdMachine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).BeginInit();
            this.SuspendLayout();
            // 
            // picMachine
            // 
            this.picMachine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMachine.Location = new System.Drawing.Point(20, 1);
            this.picMachine.Name = "picMachine";
            this.picMachine.Size = new System.Drawing.Size(90, 51);
            this.picMachine.TabIndex = 0;
            this.picMachine.TabStop = false;
            // 
            // cmdMachine
            // 
            this.cmdMachine.BackColor = System.Drawing.Color.LimeGreen;
            this.cmdMachine.FlatAppearance.BorderSize = 0;
            this.cmdMachine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdMachine.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMachine.ForeColor = System.Drawing.Color.White;
            this.cmdMachine.Location = new System.Drawing.Point(20, 58);
            this.cmdMachine.Name = "cmdMachine";
            this.cmdMachine.Size = new System.Drawing.Size(90, 31);
            this.cmdMachine.TabIndex = 1;
            this.cmdMachine.UseVisualStyleBackColor = false;
            this.cmdMachine.Click += new System.EventHandler(this.btn_Click);
            // 
            // UC_Machine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cmdMachine);
            this.Controls.Add(this.picMachine);
            this.Name = "UC_Machine";
            this.Size = new System.Drawing.Size(133, 98);
            this.Load += new System.EventHandler(this.UC_Machine_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMachine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picMachine;
        private System.Windows.Forms.Button cmdMachine;

    }
}
