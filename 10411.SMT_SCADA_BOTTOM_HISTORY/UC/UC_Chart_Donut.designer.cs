namespace FORM.UC
{
    partial class UC_Chart_Donut
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
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGauge1 = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleRangeBarComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent();
            this.ascInv = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleRangeBarComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ascInv)).BeginInit();
            this.SuspendLayout();
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.ColorScheme.TargetElements = ((DevExpress.XtraGauges.Core.Base.TargetElement)((DevExpress.XtraGauges.Core.Base.TargetElement.RangeBar | DevExpress.XtraGauges.Core.Base.TargetElement.Label)));
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(125, 122);
            this.gaugeControl1.TabIndex = 1;
            // 
            // circularGauge1
            // 
            this.circularGauge1.Bounds = new System.Drawing.Rectangle(5, 3, 116, 114);
            this.circularGauge1.Name = "circularGauge1";
            this.circularGauge1.RangeBars.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent[] {
            this.arcScaleRangeBarComponent1});
            this.circularGauge1.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.ascInv});
            // 
            // arcScaleRangeBarComponent1
            // 
            this.arcScaleRangeBarComponent1.ArcScale = this.ascInv;
            this.arcScaleRangeBarComponent1.EndOffset = 4F;
            this.arcScaleRangeBarComponent1.Name = "circularGauge1_RangeBar2";
            this.arcScaleRangeBarComponent1.RoundedCaps = true;
            this.arcScaleRangeBarComponent1.Shader = new DevExpress.XtraGauges.Core.Drawing.StyleShader("Colors[Style1:#318433;Style2:]");
            this.arcScaleRangeBarComponent1.ShowBackground = true;
            this.arcScaleRangeBarComponent1.StartOffset = 60F;
            this.arcScaleRangeBarComponent1.ZOrder = -10;
            // 
            // ascInv
            // 
            this.ascInv.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.ascInv.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.ascInv.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.ascInv.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.ascInv.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.ascInv.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.ascInv.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.ascInv.EndAngle = 90F;
            this.ascInv.MajorTickCount = 0;
            this.ascInv.MajorTickmark.FormatString = "{0:F0}";
            this.ascInv.MajorTickmark.ShapeOffset = -14F;
            this.ascInv.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_1;
            this.ascInv.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.ascInv.MaxValue = 2.5F;
            this.ascInv.MinorTickCount = 0;
            this.ascInv.MinorTickmark.ShapeOffset = -7F;
            this.ascInv.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style16_2;
            this.ascInv.Name = "scale1";
            this.ascInv.StartAngle = -270F;
            // 
            // UC_Chart_Donut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gaugeControl1);
            this.Name = "UC_Chart_Donut";
            this.Size = new System.Drawing.Size(124, 121);
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleRangeBarComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ascInv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleRangeBarComponent arcScaleRangeBarComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent ascInv;

    }
}
