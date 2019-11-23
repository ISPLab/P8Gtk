using System;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace SkiaTest
{
    public class P8ImageResource 
    {
        SKImage snapshot;
        SKBitmap bitmap;
        Color color;
        public EventHandler Painted;
        // SKCanvasView canvasView = new SKCanvasView();
        //   private Gdk.Pixbuf pix;
        //  private SKSurface surface;
        SKCanvas sKCanvas;
        public P8ImageResource(float width, float height)
        {
            this.Width = width;
            this.Height = height;
            CreateDrawingObjects();
           // PaintSurface += OnCanvasViewPaintSurface;
           //  canvasView.PaintSurface += OnCanvasViewPaintSurface;
           //  SKPaintSurfaceEventArgs sK = new SKPaintSurfaceEventArgs(canvasView.PaintSurface, )
           // Content = canvasView;
        }
        private void CreateDrawingObjects()
        {
            var imgInfo = new SKImageInfo((int)Width, (int)Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            color = Color.Green;
            bitmap = new SKBitmap(imgInfo);
            sKCanvas = new SKCanvas(bitmap);
            Paintbitmap(sKCanvas);
            //  snapshot = surface.Snapshot();
            // var alloc = new SKRect(0, 0, 100, 100);
            // this.pix;
            // byte[] buffer = new byte[500];
            // var pix = new Gdk.Pixbuf(  ( (buffer, 100, 100);
            //  surface = SKSurface.Create(imgInfo, pix.Pixels, imgInfo.RowBytes);
            // surface = SKSurface.Create(imgInfo,8);
            /*  var alloc = new  SKRect(100,100,100,1000);
              var imgInfo = new SKImageInfo((int)alloc.Width, (int)alloc.Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

              if (pix == null || pix.Width != imgInfo.Width || pix.Height != imgInfo.Height)
              {
                  FreeDrawingObjects();

                  if (imgInfo.Width != 0 && imgInfo.Height != 0)
                  {
                      pix = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, true, 8, imgInfo.Width, imgInfo.Height);

                      // (re)create the SkiaSharp drawing objects
                      surface = SKSurface.Create(imgInfo, pix.Pixels, imgInfo.RowBytes);
                      snapshot = surface.Snapshot();
                  }
              }
              return imgInfo;
               */
        }

        void Paintbitmap(SKCanvas canvas)
        {
            //SKCanvas canvas = _surface.Canvas;
            canvas.Clear();

            float maxRadius = 0.75f * Math.Min(100, 100) / 2;
            float minRadius = 0.25f * maxRadius;

            float xRadius = minRadius * scale + maxRadius * (1 - scale);
            float yRadius = maxRadius * scale + minRadius * (1 - scale);

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.Color = SKColors.Blue;
                paint.StrokeWidth = 50;
                canvas.DrawOval(Width / 2, Height / 2, xRadius, yRadius, paint);

                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.SkyBlue;
                canvas.DrawOval(Width / 2, Height / 2, xRadius, yRadius, paint);
            }
          // GetImageSource();
           // Painted?.Invoke(this, new EventArgs());


            /*   if (color == Color.Green)
                   color = Color.Red;
               else color = Color.Green;
               SKPaint paint = new SKPaint
               {
                   IsAntialias=true,
                   Style = SKPaintStyle.Stroke,
                   Color = color.ToSKColor(),
                   StrokeWidth = 2
               };
               sKCanvas.Scale((float)scale);
               // canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
               canvas.DrawCircle(50, 50, 25, paint);

              // snapshot = surface.Snapshot();
               OnPropertyChanged("Source");*/

        }
        private void FreeDrawingObjects()
        {
            //pix?.Dispose();
            //pix = null;

            // SkiaSharp objects should only exist if the Pixbuf is set as well
           // surface?.Dispose();
           // surface = null;
        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
           /* SKImageInfo info = args.Info;
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
            this.Source=  GetImageSource();
            OnPropertyChanged("imagesource");*/
        }

        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        float scale = 2;

        public float Width { get; }
        public float Height { get; }

        public async Task AnimationLoop()
        {
            stopwatch.Start();
            while (true)
            {
                double cycleTime = 1000;// slider.Value;
                double t = stopwatch.Elapsed.TotalSeconds % cycleTime / cycleTime;
                scale = (1 + (float)Math.Sin(2 * Math.PI * t)) / 2;
                Paintbitmap(sKCanvas);
                //canvasView.InvalidateSurface();
                await Task.Delay(TimeSpan.FromSeconds(100 / 30));
            }
        }
       
        public ImageSource GetImageSource()
        {
            SKImage image = SKImage.FromBitmap(bitmap);

            // encode the image (defaults to PNG)
            SKData encoded = image.Encode();
            System.IO.Stream stream = encoded.AsStream();
            var source = ImageSource.FromStream(() => stream);
            return source;

            // if (snapshot == null) return null;
            //var image = SkiaSharp.SKImage.FromBitmap(bitmap);
           /* var encoded = snapshot.Encode();
            var stream = encoded.AsStream();
            var source = ImageSource.FromStream(() => stream);
            return source;*/
        }
    }
}
