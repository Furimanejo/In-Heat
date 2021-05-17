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
        ClientController clientController;
        OnFireTracker onFireTracker;
        int trackingchartMaxPoints = 200;
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


            //chart
            trackingChart.Series[0].Points.Add(100f * onFireTracker.lastReadValue);
            while (trackingChart.Series[0].Points.Count > trackingchartMaxPoints)
                trackingChart.Series[0].Points.RemoveAt(0);
            trackingChart.Series[1].Points.Add(100f * onFireTracker.movingAverage);
            while (trackingChart.Series[1].Points.Count > trackingchartMaxPoints)
                trackingChart.Series[1].Points.RemoveAt(0);
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
            catch
            {
                Console.WriteLine("ErrorConnecting");
            }
        }

        private async void clientUpdateTimer_Tick(object sender, EventArgs e)
        {
            await clientController.UpdateValue(onFireTracker.movingAverage);
        }
    }
}
