using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

using System.Windows.Input;

using Emgu;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace InHeat
{
    class OnFireTracker
    {
        PictureBox pictureBox;
        Image<Bgr, Byte> frame;
        Rectangle barRect1080p = new Rectangle(275, 970, 210, 50);
        
        float readValueMultiplier = 1 / .8f;

        List<float> valuesRead;
        public int readsPerSecond = 30;

        public float lastReadValue 
        {
            get
            {
                return valuesRead.Count == 0 ? 0 : valuesRead[valuesRead.Count - 1];
            }
        }

        public float movingAverage
        {
            get
            {
                float sum = 0;
                int nonZeros = 0;
                for(int i = valuesRead.Count -1; i >= 0; i--)
                {
                    var value = valuesRead[i];
                    if (value == 0)
                        continue;
                    sum += value;
                    nonZeros++;
                    if (valuesRead.Count - i > readsPerSecond*1.5f)
                        break;
                }
                return nonZeros == 0 ? 0 : sum / nonZeros;
            }
        }

        public OnFireTracker(PictureBox pictureBox1)
        {
            pictureBox = pictureBox1;
            valuesRead = new List<float>();
            //load sample image
            //string path = "..//..//Screenshot_1.png";
            //frame = new Image<Bgr, Byte>(path);

            //crop
            //frame.ROI = barRect1080p;
            //frame = frame.Copy();
            //ProcessFrame();
        }

        public void Update()
        {
            CaptureFrame();
            ProcessFrame();
        }

        void ProcessFrame()
        {
            var bars = new List<Image<Bgr, Byte>>();
            bars.Add(DetectBarByContours());
            bars.Add(DetectBarByHorizontalLines());

            int maxArea = 0;
            int chosenBarIndex = -1;
            for(int i = 0; i < bars.Count; i++)
            {
                var barArea = CountNonBlack(bars[i]);
                if(barArea > 1500 && barArea < 2000 && barArea > maxArea)
                {
                    maxArea = barArea;
                    chosenBarIndex = i;
                }
            }
            // one of the bars found is valid
            float value = 0;
            if(chosenBarIndex > -1)
            {
                var cyanPixels = CountCyanPixels(bars[chosenBarIndex]);
                value = (float) cyanPixels / maxArea;
                value *= readValueMultiplier;
                value = value > 1 ? 1 : value;
                UpdatePictureBox(bars[chosenBarIndex].ToBitmap());
            }
            else
            {
                UpdatePictureBox(frame.CopyBlank().ToBitmap());
            }
            valuesRead.Add(value);
            while (valuesRead.Count > readsPerSecond * 5f)
                valuesRead.RemoveAt(0);
        }

        UMat FindEdgesInFrame()
        {
            //convert frame to gray
            var tempGray = new UMat();
            CvInvoke.CvtColor(frame, tempGray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
            //CvInvoke.GaussianBlur(tempGray, tempGray, new Size(3, 3), 15, 15);

            //canny edge detection
            var mean = CvInvoke.Mean(tempGray).V0;
            var mixThreshold = .8f * mean;
            var maxThreshold = 1.3 * mean;
            CvInvoke.Canny(tempGray, tempGray, mixThreshold, maxThreshold);
            return tempGray;
        }

        Image<Bgr, Byte> DetectBarByContours()
        {
            var edges = FindEdgesInFrame();

            //find contours from edges
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(edges, contours, null,
                Emgu.CV.CvEnum.RetrType.List,
                Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            //find contour of biggest width
            var index = -1;
            var maxWidth = 0;
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);
                if (rect.Width > maxWidth && rect.Width > .7f * barRect1080p.Width)
                {
                    maxWidth = rect.Width;
                    index = i;
                }
            }

            var barMask = frame.CopyBlank();
            if (index > -1)
            {
                // fill the contour found with white pixels
                VectorOfPoint hull = new VectorOfPoint();
                CvInvoke.ConvexHull(contours[index], hull);
                CvInvoke.FillConvexPoly(barMask, hull, 
                    new MCvScalar(255, 255, 255), 
                    Emgu.CV.CvEnum.LineType.FourConnected);
            }

            CvInvoke.BitwiseAnd(frame, barMask, barMask);
            return barMask;
        }

        Image<Bgr, Byte> DetectBarByHorizontalLines()
        {
            var tempGray = FindEdgesInFrame();
            
            LineSegment2D[] houghLines = CvInvoke.HoughLinesP(tempGray, .5, Math.PI/180, 10, .6* barRect1080p.Width, 10);
            List<LineSegment2D> possibleBarLines = new List<LineSegment2D>();
            int x1 = 0;
            int x2 = 0;
            foreach (LineSegment2D line in houghLines)
            {
                LineSegment2D horizontalLine = new LineSegment2D(new Point(0, 0), new Point(10, 0));
                var angle = line.GetExteriorAngleDegree(horizontalLine);
                if (angle > 0)
                {
                    possibleBarLines.Add(line);
                    if (line.P1.X > x1)
                        x1 = line.P1.X;
                    if (line.P2.X > x2)
                        x2 = line.P2.X;
                    CvInvoke.Line(tempGray, line.P1, line.P2, new MCvScalar(0,255,0), 1);
                }
            }

            var barMask = frame.CopyBlank();
            // not enough lines detected to make a bar
            if(possibleBarLines.Count < 2)
                return barMask;

            // get bottom 2 lines, ordering by P1.Y value
            possibleBarLines = possibleBarLines.OrderBy(o => o.P1.Y).ToList();
            LineSegment2D line1 = possibleBarLines[possibleBarLines.Count - 2];
            LineSegment2D line2 = possibleBarLines[possibleBarLines.Count - 1];
            Point[] points = new Point[] { 
                new Point(x1, line1.P1.Y),
                new Point(x2, line1.P2.Y),
                new Point(x2, line2.P2.Y),
                new Point(x1, line2.P1.Y) };
            VectorOfPoint barPoints = new VectorOfPoint(points);
            CvInvoke.FillConvexPoly(barMask, barPoints, new MCvScalar(255, 255, 255), Emgu.CV.CvEnum.LineType.FourConnected);

            //return bar to colors from original frame
            CvInvoke.BitwiseAnd(frame, barMask, barMask);

            return barMask;
        }

        int CountCyanPixels(Image<Bgr, Byte> barImage)
        {
            var cyanPixels = barImage.InRange(new Bgr(240, 200, 0), new Bgr(255, 255, 255)).CountNonzero()[0];
            return cyanPixels;
        }

        int CountNonBlack(Image<Bgr, Byte> barImage)
        {
            var totalpixels = barImage.InRange(new Bgr(1, 1, 1), new Bgr(255, 255, 255)).CountNonzero()[0];
            return totalpixels;
        }

        void CaptureFrame()
        {
            Bitmap captureBitmap = new Bitmap(barRect1080p.Width, barRect1080p.Height);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(barRect1080p.Left, barRect1080p.Top, 0, 0, barRect1080p.Size);
            frame = captureBitmap.ToImage<Bgr, Byte>();
        }

        void UpdatePictureBox(Bitmap bmp)
        {
            pictureBox.Image = bmp;
        }
    }
}
