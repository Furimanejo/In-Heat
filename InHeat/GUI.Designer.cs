namespace InHeat
{
    partial class GUI
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.TrackerPictureBox = new System.Windows.Forms.PictureBox();
            this.trackerTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.trackingUpdateFrequencyBar = new System.Windows.Forms.TrackBar();
            this.trackingUpdatesLabel = new System.Windows.Forms.Label();
            this.trackingChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientUpdateTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingChart)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackerPictureBox
            // 
            this.TrackerPictureBox.Location = new System.Drawing.Point(12, 41);
            this.TrackerPictureBox.Name = "TrackerPictureBox";
            this.TrackerPictureBox.Size = new System.Drawing.Size(420, 50);
            this.TrackerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TrackerPictureBox.TabIndex = 0;
            this.TrackerPictureBox.TabStop = false;
            // 
            // trackerTimer
            // 
            this.trackerTimer.Enabled = true;
            this.trackerTimer.Interval = 1000;
            this.trackerTimer.Tick += new System.EventHandler(this.trackerTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "On-fire bar tracking: ";
            // 
            // trackingUpdateFrequencyBar
            // 
            this.trackingUpdateFrequencyBar.AutoSize = false;
            this.trackingUpdateFrequencyBar.Location = new System.Drawing.Point(15, 139);
            this.trackingUpdateFrequencyBar.Maximum = 60;
            this.trackingUpdateFrequencyBar.Minimum = 10;
            this.trackingUpdateFrequencyBar.Name = "trackingUpdateFrequencyBar";
            this.trackingUpdateFrequencyBar.Size = new System.Drawing.Size(210, 36);
            this.trackingUpdateFrequencyBar.SmallChange = 5;
            this.trackingUpdateFrequencyBar.TabIndex = 2;
            this.trackingUpdateFrequencyBar.TabStop = false;
            this.trackingUpdateFrequencyBar.TickFrequency = 0;
            this.trackingUpdateFrequencyBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackingUpdateFrequencyBar.Value = 30;
            this.trackingUpdateFrequencyBar.Scroll += new System.EventHandler(this.trackingUpdateFrequencyBar_Scroll);
            // 
            // trackingUpdatesLabel
            // 
            this.trackingUpdatesLabel.AutoSize = true;
            this.trackingUpdatesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackingUpdatesLabel.Location = new System.Drawing.Point(16, 112);
            this.trackingUpdatesLabel.Name = "trackingUpdatesLabel";
            this.trackingUpdatesLabel.Size = new System.Drawing.Size(185, 24);
            this.trackingUpdatesLabel.TabIndex = 3;
            this.trackingUpdatesLabel.Text = "Updates per second:\r\n";
            // 
            // trackingChart
            // 
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisX.LabelStyle.Enabled = false;
            chartArea2.AxisX2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            chartArea2.AxisY2.Maximum = 100D;
            chartArea2.AxisY2.Minimum = 0D;
            chartArea2.Name = "ChartArea1";
            this.trackingChart.ChartAreas.Add(chartArea2);
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 5F;
            legend2.Position.Width = 100F;
            legend2.Position.Y = 95F;
            this.trackingChart.Legends.Add(legend2);
            this.trackingChart.Location = new System.Drawing.Point(24, 181);
            this.trackingChart.Name = "trackingChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.Name = "Raw Values";
            series3.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            series4.BorderWidth = 5;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Fuchsia;
            series4.Legend = "Legend1";
            series4.Name = "Filtered Values";
            series4.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
            this.trackingChart.Series.Add(series3);
            this.trackingChart.Series.Add(series4);
            this.trackingChart.Size = new System.Drawing.Size(408, 280);
            this.trackingChart.TabIndex = 4;
            this.trackingChart.Text = "chart1";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(340, 97);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(92, 78);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // clientUpdateTimer
            // 
            this.clientUpdateTimer.Enabled = true;
            this.clientUpdateTimer.Interval = 10;
            this.clientUpdateTimer.Tick += new System.EventHandler(this.clientUpdateTimer_Tick);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 480);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.trackingChart);
            this.Controls.Add(this.trackingUpdatesLabel);
            this.Controls.Add(this.trackingUpdateFrequencyBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackerPictureBox);
            this.Name = "GUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TrackerPictureBox;
        private System.Windows.Forms.Timer trackerTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackingUpdateFrequencyBar;
        private System.Windows.Forms.Label trackingUpdatesLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart trackingChart;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Timer clientUpdateTimer;
    }
}

