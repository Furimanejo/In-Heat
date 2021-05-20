using System;
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
    public partial class Overlay : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        public Rectangle trackingRect { get; set; }
        int trackingchartMaxPoints = 80;

        public Overlay()
        {
            InitializeComponent();        

            trackingRect = ControlRectangle(trackingBox);
            Rectangle rect = ControlRectangle(trackingChart);

            this.Size = Screen.PrimaryScreen.Bounds.Size;
            
            ScaleControl(trackingChart, rect);
        }

        Rectangle ControlRectangle(Control control)
        {
            return new Rectangle(control.Location, control.Size);
        }

        void ScaleControl(Control control, Rectangle rect)
        {
            var ratioX = Size.Width / 1920f;
            var ratioY = Size.Height / 1080f;

            var newLocationX = ratioX * rect.Location.X;
            var newLocationY = ratioY * rect.Location.Y;
            var newWidth = ratioX * rect.Width;
            var newHeight = ratioY * rect.Height;

            var newLocation = new Point((int)newLocationX, (int)newLocationY);
            var newSize = new Size((int)newWidth, (int)newHeight);

            control.Location = newLocation;
            control.Size = newSize;
        }

        private void Overlay_Load(object sender, EventArgs e)
        {
            //make overlay background transparent
            BackColor = Color.Wheat;
            TransparencyKey = Color.Wheat;
            trackingChart.BackColor = Color.Wheat;
            trackingChart.ChartAreas[0].BackColor = Color.Wheat;
            trackingChart.Series[0].Color = Color.Transparent;

            // make overlay click-through
            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);

            this.TopMost = true;
        }

        public void AddPointsToChart(float raw, float filtered)
        {
            var rawSeries = trackingChart.Series[0].Points;
            var filteredSeries = trackingChart.Series[1].Points;

            //// this avoid some weird behavior in the chart, trust me
            raw += .01f;
            filtered += .01f;

            foreach (var point in rawSeries)
                point.YValues[0]--;
            rawSeries.AddXY(raw, rawSeries.Count);
            while (rawSeries.Count > trackingchartMaxPoints)
                rawSeries.RemoveAt(0);

            foreach (var point in filteredSeries)
                point.YValues[0]--;
            filteredSeries.AddXY(filtered, filteredSeries.Count);
            while (filteredSeries.Count > trackingchartMaxPoints)
                filteredSeries.RemoveAt(0);
        }
    }
}
