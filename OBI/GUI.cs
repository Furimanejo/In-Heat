using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBI
{
    public partial class GUI : Form
    {
        ClientController clientController;
        OnFireTracker onFireTracker;

        public GUI()
        {
            InitializeComponent();
            clientController = new ClientController();
            onFireTracker = new OnFireTracker(TrackerPictureBox);
            UpdateTrackingFrequency();
        }

        private void trackerTimer_Tick(object sender, EventArgs e)
        {
            onFireTracker.Update();
            //trackingChart.Series[0].Points.Add(100 * onFireTracker.lastReadValue);
            //trackingChart.Series[1].Points.Add(100 * onFireTracker.movingAverage);
            //if (trackingChart.Series[0].Points.Count > 300)
            //    trackingChart.Series[0].Points.RemoveAt(0);
            //if (trackingChart.Series[1].Points.Count > 300)
            //    trackingChart.Series[1].Points.RemoveAt(0);
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
    }
}
