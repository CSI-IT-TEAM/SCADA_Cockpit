namespace FORM
{
    partial class SMT_SCADA_COCKPIT_POPUP
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMT_SCADA_COCKPIT_POPUP));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.RN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.OCCUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SV_MIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SV_MAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FINAL_PV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnTop = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lblHeader = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnTop, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1428, 619);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Calibri", 12.75F);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(3, 81);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1422, 535);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Calibri", 15.75F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 50;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.RN,
            this.DATE,
            this.OCCUR,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.SV_MIN,
            this.SV_MAX,
            this.FINAL_PV});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.RowHeight = 50;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            // 
            // RN
            // 
            this.RN.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.RN.AppearanceHeader.Options.UseFont = true;
            this.RN.AppearanceHeader.Options.UseTextOptions = true;
            this.RN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.RN.Caption = "No";
            this.RN.FieldName = "RN";
            this.RN.FieldNameSortGroup = "RN";
            this.RN.Name = "RN";
            this.RN.Visible = true;
            this.RN.VisibleIndex = 0;
            this.RN.Width = 57;
            // 
            // DATE
            // 
            this.DATE.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.DATE.AppearanceHeader.Options.UseFont = true;
            this.DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.DATE.Caption = "Date";
            this.DATE.FieldName = "DATE";
            this.DATE.FieldNameSortGroup = "DATE";
            this.DATE.Name = "DATE";
            this.DATE.Visible = true;
            this.DATE.VisibleIndex = 1;
            this.DATE.Width = 126;
            // 
            // OCCUR
            // 
            this.OCCUR.AppearanceCell.Options.UseTextOptions = true;
            this.OCCUR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OCCUR.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.OCCUR.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.OCCUR.AppearanceHeader.Options.UseFont = true;
            this.OCCUR.AppearanceHeader.Options.UseTextOptions = true;
            this.OCCUR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.OCCUR.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.OCCUR.Caption = "Occur";
            this.OCCUR.FieldName = "OCCUR";
            this.OCCUR.FieldNameSortGroup = "OCCUR";
            this.OCCUR.Name = "OCCUR";
            this.OCCUR.Visible = true;
            this.OCCUR.VisibleIndex = 2;
            this.OCCUR.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn1.Caption = "Plant";
            this.gridColumn1.FieldName = "PLANT_NM";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 71;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.Caption = "Line";
            this.gridColumn2.FieldName = "LINE_NM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.Caption = "Area";
            this.gridColumn3.FieldName = "AREA";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 101;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn4.Caption = "Machine ID";
            this.gridColumn4.FieldName = "MACHINE_CD";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 298;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn5.Caption = "Machine Name";
            this.gridColumn5.FieldName = "MACHINE_NM";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 322;
            // 
            // SV_MIN
            // 
            this.SV_MIN.AppearanceCell.Options.UseTextOptions = true;
            this.SV_MIN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SV_MIN.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SV_MIN.AppearanceHeader.Options.UseFont = true;
            this.SV_MIN.AppearanceHeader.Options.UseTextOptions = true;
            this.SV_MIN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SV_MIN.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SV_MIN.Caption = "SV Min";
            this.SV_MIN.FieldName = "SV_MIN";
            this.SV_MIN.FieldNameSortGroup = "SV_MIN";
            this.SV_MIN.Name = "SV_MIN";
            this.SV_MIN.Visible = true;
            this.SV_MIN.VisibleIndex = 8;
            this.SV_MIN.Width = 97;
            // 
            // SV_MAX
            // 
            this.SV_MAX.AppearanceCell.Options.UseTextOptions = true;
            this.SV_MAX.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.SV_MAX.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.SV_MAX.AppearanceHeader.Options.UseFont = true;
            this.SV_MAX.AppearanceHeader.Options.UseTextOptions = true;
            this.SV_MAX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SV_MAX.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SV_MAX.Caption = "SV Max";
            this.SV_MAX.FieldName = "SV_MAX";
            this.SV_MAX.FieldNameSortGroup = "SV_MAX";
            this.SV_MAX.Name = "SV_MAX";
            this.SV_MAX.Visible = true;
            this.SV_MAX.VisibleIndex = 9;
            this.SV_MAX.Width = 106;
            // 
            // FINAL_PV
            // 
            this.FINAL_PV.AppearanceCell.Options.UseTextOptions = true;
            this.FINAL_PV.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.FINAL_PV.AppearanceHeader.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold);
            this.FINAL_PV.AppearanceHeader.Options.UseFont = true;
            this.FINAL_PV.AppearanceHeader.Options.UseTextOptions = true;
            this.FINAL_PV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.FINAL_PV.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.FINAL_PV.Caption = "Final PV";
            this.FINAL_PV.FieldName = "FINAL_PV";
            this.FINAL_PV.FieldNameSortGroup = "FINAL_PV";
            this.FINAL_PV.Name = "FINAL_PV";
            this.FINAL_PV.Visible = true;
            this.FINAL_PV.VisibleIndex = 10;
            this.FINAL_PV.Width = 94;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.button1);
            this.pnTop.Controls.Add(this.lblHeader);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTop.Location = new System.Drawing.Point(3, 3);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1422, 72);
            this.pnTop.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(1274, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Export Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblHeader
            // 
            this.lblHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(0)))), ((int)(((byte)(95)))));
            this.lblHeader.Appearance.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Appearance.Options.UseBackColor = true;
            this.lblHeader.Appearance.Options.UseFont = true;
            this.lblHeader.Appearance.Options.UseForeColor = true;
            this.lblHeader.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(1422, 72);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = " Preventative Maintenance Detail ";
            // 
            // SMT_SCADA_COCKPIT_POPUP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1428, 619);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMT_SCADA_COCKPIT_POPUP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.VisibleChanged += new System.EventHandler(this.SMT_SCADA_COCKPIT_FORM2_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.pnTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnTop;
        private DevExpress.XtraEditors.LabelControl lblHeader;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn DATE;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn RN;
        private DevExpress.XtraGrid.Columns.GridColumn OCCUR;
        private DevExpress.XtraGrid.Columns.GridColumn SV_MIN;
        private DevExpress.XtraGrid.Columns.GridColumn SV_MAX;
        private DevExpress.XtraGrid.Columns.GridColumn FINAL_PV;
        private System.Windows.Forms.Button button1;
    }
}