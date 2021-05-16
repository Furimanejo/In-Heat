namespace OBI
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
            this.TrackerPictureBox = new System.Windows.Forms.PictureBox();
            this.trackerTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.trackingUpdateFrequencyBar = new System.Windows.Forms.TrackBar();
            this.trackingUpdatesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackerPictureBox
            // 
            this.TrackerPictureBox.Location = new System.Drawing.Point(12, 41);
            this.TrackerPictureBox.Name = "TrackerPictureBox";
            this.TrackerPictureBox.Size = new System.Drawing.Size(210, 25);
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
            this.trackingUpdateFrequencyBar.Location = new System.Drawing.Point(12, 97);
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
            this.trackingUpdatesLabel.Location = new System.Drawing.Point(13, 69);
            this.trackingUpdatesLabel.Name = "trackingUpdatesLabel";
            this.trackingUpdatesLabel.Size = new System.Drawing.Size(185, 24);
            this.trackingUpdatesLabel.TabIndex = 3;
            this.trackingUpdatesLabel.Text = "Updates per second:\r\n";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 412);
            this.Controls.Add(this.trackingUpdatesLabel);
            this.Controls.Add(this.trackingUpdateFrequencyBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackerPictureBox);
            this.Name = "GUI";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TrackerPictureBox;
        private System.Windows.Forms.Timer trackerTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackingUpdateFrequencyBar;
        private System.Windows.Forms.Label trackingUpdatesLabel;
    }
}

