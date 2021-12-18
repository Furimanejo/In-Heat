using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
            UpdateMinBPM(null, null);
            UpdateMaxBPM(null, null);
            overlay = new Overlay();

            var trackRect = ScaleRectangleToResolution(overlay.trackingRect);
            onFireTracker = new OnFireTracker(trackRect, TrackerPictureBox);
            UpdateTrackingFrequency();
        }

        Rectangle ScaleRectangleToResolution(Rectangle rect)
        {
            var ScreenRect = Screen.PrimaryScreen.Bounds;
            var scaleFactor = GetWindowsScreenScalingFactor(false);

            var ratioX = scaleFactor * ScreenRect.Width / 1920f;
            var ratioY = scaleFactor * ScreenRect.Height / 1080f;

            var newLocationX = ratioX * rect.Location.X;
            var newLocationY = ratioY * rect.Location.Y;
            var newWidth = ratioX * rect.Width;
            var newHeight = ratioY * rect.Height;

            var newLocation = new Point((int)newLocationX, (int)newLocationY);
            var newSize = new Size((int)newWidth, (int)newHeight);

            return new Rectangle(newLocation, newSize);
        }

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        public static double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            //Create Graphics object from the current windows handle
            Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
            //Get Handle to the device context associated with this Graphics object
            IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
            //Call GetDeviceCaps with the Handle to retrieve the Screen Height
            int LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
            //Divide the Screen Heights to get the scaling factor and round it to two decimals
            double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / (double)LogicalScreenHeight, 2);
            //If requested as percentage - convert it
            if (percentage)
            {
                ScreenScalingFactor *= 100.0;
            }
            //Release the Handle and Dispose of the GraphicsObject object
            GraphicsObject.ReleaseHdc(DeviceContextHandle);
            GraphicsObject.Dispose();
            //Return the Scaling Factor
            return ScreenScalingFactor;
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
            if (UpdateDevicesCheckbox.Checked)
            {
                float value = onFireTracker.movingAverage;
                // interpolation
                value = value * (float)(maxIntensity.Value - minIntensity.Value) / 100;
                value += (float)minIntensity.Value / 100;
                var deltaTime = Convert.ToUInt32(clientUpdateTimer.Interval);
                await clientController.UpdateValue(value, deltaTime);
            }
        }

        private void overlayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (overlayCheckBox.Checked)
                overlay.Show();
            else
                overlay.Hide();
        }

        private async void maxIntensity_ValueChanged(object sender, EventArgs e)
        {
            await ForceDeviceValue((float)maxIntensity.Value / 100f, 700);
        }
        private async void minIntensity_ValueChanged(object sender, EventArgs e)
        {
            await ForceDeviceValue((float)minIntensity.Value / 100f, 700);
        }

        private void UpdateMinBPM(object sender, EventArgs e)
        {
            clientController.minBPM = (float)minBPM.Value;
        }
        private void UpdateMaxBPM(object sender, EventArgs e)
        {
            clientController.maxBPM = (float)maxBPM.Value;
        }

        async Task ForceDeviceValue(float value, int miliseconds)
        {
            clientUpdateTimer.Enabled = false;
            try
            {
                await clientController.UpdateValue(value, 0);
                await Task.Delay(miliseconds);
                await clientController.UpdateValue(0, 0);
            }
            catch { }
            clientUpdateTimer.Enabled = true;
        }

        private async void UpdateDevicesCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdateDevicesCheckbox.Checked == false)
                await ForceDeviceValue(0, 100);
        }
    }
}