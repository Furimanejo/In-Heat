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
        Rectangle barRect1080p = new Rectangle(275, 965, 220, 55);

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
                float pointsToRead = (readsPerSecond * 1f);
                if (pointsToRead > valuesRead.Count)
                    pointsToRead = valuesRead.Count;
                int zeros = 0;
                List<float> points = new List<float>();
                for (int i = valuesRead.Count - 1; i > 0; i--)
                {
                    var value = valuesRead[i];
                    if (value == 0)
                        zeros++;
                    //continue;
                    points.Add(value);
                    if (points.Count > pointsToRead + zeros)
                        break;
                }
                if (points.Count == 0)
                    return 0;
                points = points.OrderBy(o => o).ToList();
                var index = (int)Math.Floor(.90f*(points.Count - 1));
                return points[index];
            }
        }

        public OnFireTracker(PictureBox pictureBox1)
        {
            pictureBox = pictureBox1;
            valuesRead = new List<float>();
        }

        public void Update()
        {
            CaptureFrame();
            var value = CyanDetection();
            value = (value - 0.05f);
            value /= 0.85f;
            value = value < 0 ? 0 : value;
            value = value > 1 ? 1 : value;
            valuesRead.Add(value);
            while (valuesRead.Count > readsPerSecond * 5f)
                valuesRead.RemoveAt(0);
        }

        private float CyanDetection()
        {
            float value = 0;
            var frameCopy = frame.Copy();
            CvInvoke.GaussianBlur(frameCopy, frameCopy, new Size(3, 3), 15, 15);

            var mean = CvInvoke.Mean(frameCopy); // B G R 
            var meanB = (mean.V0 / 255);
            var meanG = (mean.V1 / 255);
            var meanR = (mean.V2 / 255);
            var minBlue = 230 + 25 * meanB;
            var minGreen = 220 + 35 * meanG;
            var maxRed = 130 + 85 * meanR;

            var mask = frameCopy.InRange(new Bgr(minBlue, minGreen, 0), new Bgr(255, 255, maxRed));

            Mat element = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, 
                new Size(3, 3), new Point(-1, -1));

            CvInvoke.Dilate(mask, mask, element, new Point(-1,- 1), 2, 
                Emgu.CV.CvEnum.BorderType.Constant, new MCvScalar(0, 0, 0));  

            VectorOfVectorOfPoint cyanContours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(mask, cyanContours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            if (cyanContours.Size > 0)
            {
                var index = FindContourClosestToBottomRight(cyanContours);
                CvInvoke.DrawContours(frameCopy, cyanContours, index, new MCvScalar(0, 0, 255), 2);
                value = CvInvoke.BoundingRectangle(cyanContours[index]).Right;
                value /= barRect1080p.Width;
            }
            else
            {
                //var WhiteMask = frame.InRange(new Bgr(255, 255, 255), new Bgr(255, 255, 255));
                //VectorOfVectorOfPoint WhiteContours = new VectorOfVectorOfPoint();
                //CvInvoke.FindContours(WhiteMask, WhiteContours, null, Emgu.CV.CvEnum.RetrType.List, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);
                //var index = FindContourClosestToBottomRight(WhiteContours);
                //if(index > -1)
                //{
                //    CvInvoke.DrawContours(frameCopy, WhiteContours, index, new MCvScalar(0, 0, 255), 2);
                //    value = CvInvoke.BoundingRectangle(WhiteContours[index]).Right;
                //    value /= barRect1080p.Width;
                //    if (value < .7f)
                //        value = 0;
                //}
            }
            pictureBox.Image = frameCopy.ToBitmap();
            return value;
        }

        int FindContourClosestToBottomRight(VectorOfVectorOfPoint contours)
        {
            int chosenContourIndex = -1;            
            var minDistFromLowerLeft = 9999;
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);
                var distFromLowerLeft = rect.X - (rect.Y + rect.Height);
                if (distFromLowerLeft < minDistFromLowerLeft)
                {
                    minDistFromLowerLeft = distFromLowerLeft;
                    chosenContourIndex = i;
                }
            }
            return chosenContourIndex;
        }

        void CaptureFrame()
        {
            Bitmap captureBitmap = new Bitmap(barRect1080p.Width, barRect1080p.Height);
            Graphics captureGraphics = Graphics.FromImage(captureBitmap);
            captureGraphics.CopyFromScreen(barRect1080p.Left, barRect1080p.Top, 0, 0, barRect1080p.Size);
            frame = captureBitmap.ToImage<Bgr, Byte>();
        }
    }
}
