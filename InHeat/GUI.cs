using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InHeat
{
    public partial class GUI : Form
    {
        Overlay overlay;
        ClientController clientController;
        OnFireTracker onFireTracker;

        public GUI()
        {
            InitializeComponent();
            clientController = new ClientController();
            onFireTracker = new OnFireTracker(TrackerPictureBox);
            overlay = new Overlay(onFireTracker.barRect1080p);
            UpdateTrackingFrequency();
        }

        private void trackerTimer_Tick(object sender, EventArgs e)
        {
            onFireTracker.Update();

            //chart
            var raw = 100f * onFireTracker.lastReadValue;
            var filtered = 100f * onFireTracker.movingAverage;
            overlay.AddPointsToChart(raw, filtered);
        }

        private void trackingUpdateFrequencyBar_Scroll(object sender, EventArgs e)
        {
            UpdateTrackingFrequency();
        }

        void UpdateTrackingFrequency()
        {
            onFireTracker.readsPerSecond = trackingUpdateFrequencyBar.Value;
            trackingUpdatesLabel.Text = $"Updates per second: {onFireTracker.readsPerSecond}";
            trackerTimer.Interval = 1000 / onFireTracker.readsPerSecond;
        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                await clientController.ConnectAsync();
            }
            catch { Console.WriteLine("Error Connecting"); }
        }

        private async void clientUpdateTimer_Tick(object sender, EventArgs e)
        {
            float value = 0;
            if (UpdateDevicesCheckbox.Checked)
            {
                value = onFireTracker.movingAverage;
                // interpolation
                value =  value * (float)(maxIntensity.Value - minIntensity.Value)/100;
                value += (float) minIntensity.Value / 100;
                // clamp
                value = value > 0 ? value : 0;
                value = value < 1 ? value : 1; 
            }
            try
            {
                await clientController.UpdateValue(value);
            }
            catch{ Console.WriteLine("Error Update Device Value"); }
        }

        private void overlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overlayCheckBox.Checked)
                overlay.Show();
            else
                overlay.Hide();
        }
    }
}
