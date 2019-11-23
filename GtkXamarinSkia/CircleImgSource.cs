using System;
using SkiaSharp;

namespace SkiaTest
{
    public class CircleImgSource : P8ImageSource
    {
    
        public override void PaintBitmap()
        {
            sKCanvas.Clear();
            float maxRadius = 0.75f * Math.Min(100, 100) / 2;
            float minRadius = 0.25f * maxRadius;

            float xRadius = minRadius * (float)Scale + maxRadius * (1 - (float)Scale);
            float yRadius = maxRadius * (float)Scale + minRadius * (1 - (float)Scale);

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 50;
                sKCanvas.DrawOval((float)Width / 2, (float)Height / 2, xRadius, yRadius, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.SkyBlue;
                sKCanvas.DrawOval((float)Width / 2, (float)Height / 2, xRadius, yRadius, paint);
            }
        }
    }
}