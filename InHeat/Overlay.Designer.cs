namespace InHeat
{
    partial class Overlay
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.trackingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackingBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackingChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trackingChart
            // 
            this.trackingChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.Maximum = 101D;
            chartArea1.AxisX.Minimum = -1D;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LabelStyle.Enabled = false;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 100F;
            chartArea1.InnerPlotPosition.Width = 100F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.trackingChart.ChartAreas.Add(chartArea1);
            this.trackingChart.Location = new System.Drawing.Point(270, 1020);
            this.trackingChart.Name = "trackingChart";
            this.trackingChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Blue;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.SmartLabelStyle.Enabled = false;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            series2.BorderWidth = 7;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Magenta;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            series2.SmartLabelStyle.Enabled = false;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Single;
            this.trackingChart.Series.Add(series1);
            this.trackingChart.Series.Add(series2);
            this.trackingChart.Size = new System.Drawing.Size(205, 60);
            this.trackingChart.TabIndex = 0;
            this.trackingChart.Text = "chart1";
            // 
            // trackingBox
            // 
            this.trackingBox.Location = new System.Drawing.Point(275, 965);
            this.trackingBox.Name = "trackingBox";
            this.trackingBox.Size = new System.Drawing.Size(220, 55);
            this.trackingBox.TabIndex = 1;
            this.trackingBox.TabStop = false;
            // 
            // Overlay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.trackingBox);
            this.Controls.Add(this.trackingChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Overlay";
            this.Load += new System.EventHandler(this.Overlay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackingChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart trackingChart;
        private System.Windows.Forms.PictureBox trackingBox;
    }
}