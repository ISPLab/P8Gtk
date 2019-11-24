using System;
using System.Threading.Tasks;
using SkiaSharp;

namespace SkiaTest
{
    public class CircleImgSource : P8ImageSource
    {
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        float xRadius;
        float yRadius;
        bool firstPaint =true;
        public CircleImgSource()
        {
            Width = 500;
            Height = 500;
        }

        public override void PaintBitmap()
        {
            sKCanvas.Clear();
            //  float maxRadius = 0.75f * Math.Min(100, 100) / 2;
            // float minRadius = 0.25f * maxRadius;
            // float xRadius = minRadius * (float)Scale + maxRadius * (1 - (float)Scale);
            // float yRadius = maxRadius * (float)Scale + minRadius * (1 - (float)Scale);
            if (firstPaint)
            {
                xRadius = (float)Width / 2;
                yRadius = (float)Height / 2;
                firstPaint = false;
            }
            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 50;
                sKCanvas.DrawOval((float)Width / 2, (float)Height / 2, xRadius, yRadius, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.SkyBlue;
                sKCanvas.DrawOval((float)Width / 2, (float)Height / 2, xRadius, yRadius, paint);
            }
        }

        bool Shrank;
        public override async Task Animate()
        {
            stopwatch.Start();
            while (true)
            {
                if(xRadius<20|| yRadius<20)
                {
                    xRadius = xRadius +0.5f;
                    yRadius = yRadius + 0.5f;
                }
                else
                {
                    xRadius = xRadius - 0.5f;
                    yRadius = yRadius - 0.5f;
                }
                InvalidateCanvas();

                await Task.Delay(1);
               /* double cycleTime = 10;// slider.Value
                ;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                Scale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                InvalidateCanvas();
                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));*/
            }
        }
    }
}