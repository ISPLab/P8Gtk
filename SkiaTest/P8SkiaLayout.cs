using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkiaTest
{
    public class P8SkiaLayout : ContentView
    {
        public  P8SkiaLayout()
        {
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        public void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 1
            };

            canvas.DrawCircle(info.Width / 2, info.Height / 2, 10, paint);
            paint.Style = SKPaintStyle.Fill;
            paint.Color = SKColors.Blue;
        //    canvas.DrawCircle(args.Info.Width / 2, args.Info.Height / 2, 100, paint);
        }
    }
}
