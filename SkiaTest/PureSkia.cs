using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaTest
{
    public class PureSkia : SKCanvasView
    {
        SKCanvasView canvasView = new SKCanvasView();
        SKImage snapshot;
        
        public PureSkia()
        {
            PaintSurface += OnCanvasViewPaintSurface;
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            Content = canvasView;
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 25
            };
            // canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
            canvas.DrawCircle(100, 100, 100, paint);
            snapshot = surface.Snapshot();
            OnPropertyChanged("imagesource");
        }

        public ImageSource GetImageSource()
        {
            if (snapshot == null) return null;
            //var image = SkiaSharp.SKImage.FromBitmap(bitmap);
            var encoded = snapshot.Encode();
            var stream = encoded.AsStream();
            var source = ImageSource.FromStream(() => stream);
            return source;
        }
    }
}