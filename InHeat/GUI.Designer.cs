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
            this.TrackerPictureBox = new System.Windows.Forms.PictureBox();
            this.trackerTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.trackingUpdateFrequencyBar = new System.Windows.Forms.TrackBar();
            this.trackingUpdatesLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateDevicesCheckbox = new System.Windows.Forms.CheckBox();
            this.minIntensity = new System.Windows.Forms.NumericUpDown();
            this.maxIntensity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.overlayCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIntensity)).BeginInit();
            this.SuspendLayout();
            // 
            // TrackerPictureBox
            // 
            this.TrackerPictureBox.Location = new System.Drawing.Point(12, 43);
            this.TrackerPictureBox.Name = "TrackerPictureBox";
            this.TrackerPictureBox.Size = new System.Drawing.Size(300, 50);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "On-fire bar tracking: ";
            // 
            // trackingUpdateFrequencyBar
            // 
            this.trackingUpdateFrequencyBar.AutoSize = false;
            this.trackingUpdateFrequencyBar.Location = new System.Drawing.Point(237, 171);
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
            this.trackingUpdatesLabel.Location = new System.Drawing.Point(12, 171);
            this.trackingUpdatesLabel.Name = "trackingUpdatesLabel";
            this.trackingUpdatesLabel.Size = new System.Drawing.Size(185, 24);
            this.trackingUpdatesLabel.TabIndex = 3;
            this.trackingUpdatesLabel.Text = "Updates per second:\r\n";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(330, 43);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(133, 50);
            this.connectButton.TabIndex = 5;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // clientUpdateTimer
            // 
            this.clientUpdateTimer.Enabled = true;
            this.clientUpdateTimer.Interval = 150;
            this.clientUpdateTimer.Tick += new System.EventHandler(this.clientUpdateTimer_Tick);
            // 
            // UpdateDevicesCheckbox
            // 
            this.UpdateDevicesCheckbox.AutoSize = true;
            this.UpdateDevicesCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateDevicesCheckbox.Location = new System.Drawing.Point(234, 99);
            this.UpdateDevicesCheckbox.Name = "UpdateDevicesCheckbox";
            this.UpdateDevicesCheckbox.Size = new System.Drawing.Size(229, 35);
            this.UpdateDevicesCheckbox.TabIndex = 6;
            this.UpdateDevicesCheckbox.Text = "Control Devices";
            this.UpdateDevicesCheckbox.UseVisualStyleBackColor = true;
            // 
            // minIntensity
            // 
            this.minIntensity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.minIntensity.Location = new System.Drawing.Point(275, 140);
            this.minIntensity.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.minIntensity.Minimum = new decimal(new int[] {
            99,
            0,
            0,
            -2147483648});
            this.minIntensity.Name = "minIntensity";
            this.minIntensity.Size = new System.Drawing.Size(65, 22);
            this.minIntensity.TabIndex = 7;
            this.minIntensity.ValueChanged += new System.EventHandler(this.minIntensity_ValueChanged);
            // 
            // maxIntensity
            // 
            this.maxIntensity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.maxIntensity.Location = new System.Drawing.Point(382, 140);
            this.maxIntensity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.maxIntensity.Name = "maxIntensity";
            this.maxIntensity.Size = new System.Drawing.Size(65, 22);
            this.maxIntensity.TabIndex = 8;
            this.maxIntensity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxIntensity.ValueChanged += new System.EventHandler(this.maxIntensity_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "Device intensity(%) range:";
            // 
            // overlayCheckBox
            // 
            this.overlayCheckBox.AutoSize = true;
            this.overlayCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.overlayCheckBox.Location = new System.Drawing.Point(12, 99);
            this.overlayCheckBox.Name = "overlayCheckBox";
            this.overlayCheckBox.Size = new System.Drawing.Size(205, 35);
            this.overlayCheckBox.TabIndex = 11;
            this.overlayCheckBox.Text = "Show Overlay";
            this.overlayCheckBox.UseVisualStyleBackColor = true;
            this.overlayCheckBox.CheckedChanged += new System.EventHandler(this.overlayCheckBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(351, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 24);
            this.label3.TabIndex = 12;
            this.label3.Text = "to";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 209);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.overlayCheckBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxIntensity);
            this.Controls.Add(this.minIntensity);
            this.Controls.Add(this.UpdateDevicesCheckbox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.trackingUpdatesLabel);
            this.Controls.Add(this.trackingUpdateFrequencyBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrackerPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GUI";
            this.Text = "In Heat";
            ((System.ComponentModel.ISupportInitialize)(this.TrackerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackingUpdateFrequencyBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIntensity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TrackerPictureBox;
        private System.Windows.Forms.Timer trackerTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackingUpdateFrequencyBar;
        private System.Windows.Forms.Label trackingUpdatesLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Timer clientUpdateTimer;
        private System.Windows.Forms.CheckBox UpdateDevicesCheckbox;
        private System.Windows.Forms.NumericUpDown minIntensity;
        private System.Windows.Forms.NumericUpDown maxIntensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox overlayCheckBox;
        private System.Windows.Forms.Label label3;
    }
}

