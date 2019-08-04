using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sfashfa_ui.customclass
{
    class Opencv_lib
    {
        public static Mat rotateDegree(Mat src, int angle)
        {
            Mat dst = new Mat();
            Point2f pt = new Point2f(src.Cols / 2, src.Rows / 2);
            Mat r = Cv2.GetRotationMatrix2D(pt, angle, 1.0);

            Cv2.WarpAffine(src, dst, r, src.Size());

            src.Dispose();

            return dst;
        }

        //화면회전 다른 버전 
        public static Mat rotateImage(Mat src, float angle)
        {
            Bitmap b = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(src);
           
            Bitmap returnBitmap = new Bitmap(b.Height, b.Width);

            Graphics g = Graphics.FromImage(returnBitmap);

            //g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.TranslateTransform((float)b.Height / 2, (float)b.Width / 2);

            g.RotateTransform(angle);

            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(b, new System.Drawing.Point(0, 0));

            g.Dispose();
            src.Dispose();

            return bgr42bgr3(OpenCvSharp.Extensions.BitmapConverter.ToMat(returnBitmap));
        }

        private static Mat bgr42bgr3(Mat src)
        {
            Mat result = new Mat();
            Cv2.CvtColor(src, result, ColorConversionCodes.BGRA2BGR);
            src.Dispose();
            return result;
        }

        public static Mat findupperbody(Mat srcMat, int colormode)
        {
            Mat result = new Mat();
            Cv2.GaussianBlur(srcMat, result, new OpenCvSharp.Size(5, 5), 0);
            Cv2.CvtColor(srcMat, result, ColorConversionCodes.BGR2GRAY);

            int gr_thr = 4;
            double scale_Factor = 1.1;

            Rect[] found;
            using (CascadeClassifier detectupbody = new CascadeClassifier(@"C:\opencv_data\haarcascade_upperbody.xml"))
            {
                found = detectupbody.DetectMultiScale(result, scale_Factor, gr_thr);

                if (found.Length > 0)
                {
                    for (int i = 0; i < found.Length; i++)
                    {
                        Rect rect = new Rect((int)(found[i].X + (found[i].Width / 7)), (int)(found[i].Y + (found[i].Height * 0.55)), (int)(found[i].Width * 0.75), found[i].Height);
                        srcMat = findContur(srcMat, rect, colormode);
                        //srcMat = ColorChange(srcMat, rect, 1, 0,0);
                    }
                }
                result.Dispose();
                found = null;
            }

            return srcMat;
        }

        private static Mat findContur(Mat srcMat, Rect rect, int colormode)
        {
            try
            {
                Point2f offset = new Point2f(rect.X, rect.Y);
                Mat result = new Mat(srcMat, rect);
                Cv2.CvtColor(result, result, ColorConversionCodes.BGR2GRAY);
                OpenCvSharp.Point[][] points;
                HierarchyIndex[] indexs;
                result = result.Canny(100, 250, 3, true);

                //result = OverWriteShape(result, srcMat, rect);
                //Cv2.CvtColor(result, result, ColorConversionCodes.BGR2GRAY);
                //result = 

                //Cv2.FindContours(InputOutputArray image, out Point[][] contours, out HierarchyIndex[] hierarchy, RetrievalModes mode, ContourApproximationModes method, Point ? offset = null);
                Cv2.FindContours(result, out points, out indexs, RetrievalModes.List, ContourApproximationModes.ApproxSimple, offset);
                if (points != null && points.Length > 0)
                {
                    for (int i = 0; i < points.Length; i++)
                    {
                        srcMat.DrawContours(points, i, Scalar.Red, -1, LineTypes.Link8, null, 2147483647);
                        if (colormode != 0)
                            ZoneColor(srcMat, points, colormode);

                    }
                }
                result.Dispose();
                return srcMat;
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return srcMat;
        }

        public static Mat ZoneColor(Mat srcMat, OpenCvSharp.Point[][] points, int colormode)
        {
            Point2d top = new Point2d(10000, 10000);
            Point2d bottom = new Point2d(0, 0);

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points[i].Length; j++)
                {
                    if (top.X > points[i][j].X)
                        top.X = points[i][j].X;
                    if (top.Y > points[i][j].Y)
                        top.Y = points[i][j].Y;

                    if (bottom.X < points[i][j].X)
                        bottom.X = points[i][j].X;
                    if (bottom.Y < points[i][j].Y)
                        bottom.Y = points[i][j].Y;
                }

            }
            Rect rect3 = new Rect((int)top.X, (int)top.Y, (int)(bottom.X - top.X), (int)(bottom.Y - top.Y));

            Mat res = new Mat(srcMat, rect3);
            for (int i = 0; i < res.Rows; i++)
            {
                for (int j = 0; j < res.Cols; j++)
                {
                    Double[] data = res.GetArray(i, j);

                    Vec3b colour = res.At<Vec3b>(i, j);

                    switch (colormode)
                    {
                        case 1://red
                            colour.Item2 = 200;
                            break;
                        case 2://blue
                            colour.Item0 = 200;
                            break;
                        case 3://gray
                            colour.Item0 = 166;
                            colour.Item1 = 166;
                            colour.Item2 = 166;
                            break;
                        case 4://orange
                            colour.Item2 = 230;
                            colour.Item1 = 187;
                            break;
                        case 5://yellow
                            colour.Item1 = 200;
                            colour.Item2 = 200;
                            break;
                        case 6://black
                            colour.Item0 = 0;
                            colour.Item1 = 0;
                            colour.Item2 = 0;
                            break;
                    }


                    res.SetArray(i, j, colour);

                }
            }
            return srcMat;
        }
    }
}
