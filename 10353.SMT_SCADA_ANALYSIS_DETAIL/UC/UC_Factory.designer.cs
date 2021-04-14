namespace FORM.UC
{
    partial class UC_Factory
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
            DevExpress.XtraCharts.SimpleDiagram simpleDiagram1 = new DevExpress.XtraCharts.SimpleDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.PieBurstAnimation pieBurstAnimation1 = new DevExpress.XtraCharts.PieBurstAnimation();
            this.chartControl4 = new DevExpress.XtraCharts.ChartControl();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl4
            // 
            this.chartControl4.AnimationStartMode = DevExpress.XtraCharts.ChartAnimationMode.OnDataChanged;
            this.chartControl4.AppearanceNameSerializable = "Nature Colors";
            this.chartControl4.BackColor = System.Drawing.Color.Transparent;
            this.chartControl4.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl4.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.Default;
            this.chartControl4.DataBindings = null;
            simpleDiagram1.LabelsResolveOverlappingMinIndent = 2;
            this.chartControl4.Diagram = simpleDiagram1;
            this.chartControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl4.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            this.chartControl4.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.TopOutside;
            this.chartControl4.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight;
            this.chartControl4.Legend.Name = "Default Legend";
            this.chartControl4.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            this.chartControl4.Location = new System.Drawing.Point(0, 0);
            this.chartControl4.Name = "chartControl4";
            this.chartControl4.PaletteName = "Palette 3";
            this.chartControl4.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(28)))), ((int)(((byte)(28))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(142)))), ((int)(((byte)(40))))), System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(142)))), ((int)(((byte)(40))))))}));
            this.chartControl4.PaletteRepository.Add("Palette 2", new DevExpress.XtraCharts.Palette("Palette 2", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
            this.chartControl4.PaletteRepository.Add("Palette 3", new DevExpress.XtraCharts.Palette("Palette 3", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Yellow, System.Drawing.Color.Yellow),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Red, System.Drawing.Color.Red),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))))}));
            pieSeriesLabel1.Border.Color = System.Drawing.Color.Black;
            pieSeriesLabel1.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            pieSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Gradient;
            pieSeriesLabel1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pieSeriesLabel1.LineColor = System.Drawing.Color.Blue;
            pieSeriesLabel1.LineStyle.Thickness = 2;
            pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.TwoColumns;
            pieSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            pieSeriesLabel1.TextColor = System.Drawing.Color.Black;
            pieSeriesLabel1.TextPattern = "{V:#,0} Person(s)\n{VP:0.0%}\n";
            series1.Label = pieSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Series 1";
            series1.ToolTipEnabled = DevExpress.Utils.DefaultBoolean.False;
            series1.TopNOptions.Count = 3;
            series1.TopNOptions.Enabled = true;
            pieSeriesView1.Animation = pieBurstAnimation1;
            pieSeriesView1.Rotation = 90;
            series1.View = pieSeriesView1;
            this.chartControl4.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl4.Size = new System.Drawing.Size(134, 130);
            this.chartControl4.TabIndex = 16;
            // 
            // UC_Factory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.chartControl4);
            this.Name = "UC_Factory";
            this.Size = new System.Drawing.Size(134, 130);
            this.Load += new System.EventHandler(this.UC_Machine_Load);
            ((System.ComponentModel.ISupportInitialize)(simpleDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl4;

        


    }
}
