using SkiaSharp;
using SkiaSharp.Views.Forms;
using SkiaTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

[assembly: ExportRenderer(typeof(P8SkiaLayout), typeof(SkiaTest.SkiaRenderer))]
namespace SkiaTest
{
    public class SkiaRenderer :  ViewRenderer<P8SkiaLayout, Gtk.Widget>
    {
        private Gdk.Pixbuf pix;
        P8SkiaLayout p8SkiaLayout;
        public SKSize CanvasSize => pix == null ? SKSize.Empty : new SKSize(pix.Width, pix.Height);
        [Category("Appearance")]
        public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface;
        private SKSurface surface;

        public SkiaRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<P8SkiaLayout> e)
        {
            base.OnElementChanged(e);
            if(e.OldElement == null)
            {
                p8SkiaLayout = e.NewElement;

                this.ExposeEvent += SkiaRender_ExposeEvent;
            }
        }

        private void SkiaRender_ExposeEvent(object o, Gtk.ExposeEventArgs evnt)
        {
            var window = evnt.Event.Window;
            var area = evnt.Event.Area;

            // get the pixbuf
            var imgInfo = CreateDrawingObjects();

            if (imgInfo.Width == 0 || imgInfo.Height == 0)
                return ;

            // start drawing
            using (new SKAutoCanvasRestore(surface.Canvas, true))
            {
                OnPaintSurface(new SKPaintSurfaceEventArgs(surface, imgInfo));
            }

            surface.Canvas.Flush();

            // swap R and B
            if (imgInfo.ColorType == SKColorType.Bgra8888)
            {
                using (var pixmap = surface.PeekPixels())
                {
                    SKSwizzle.SwapRedBlue(pixmap.GetPixels(), imgInfo.Width * imgInfo.Height);
                }
            }

            // write the pixbuf to the graphics
            window.Clear();
            window.DrawPixbuf(null, pix, 0, 0, 0, 0, -1, -1, Gdk.RgbDither.None, 0, 0);

            return ;
        }

        private SKImageInfo CreateDrawingObjects()
        {
            //  Allocation.Bottom = p8SkiaLayout.Bounds.Bottom;

            //get from view
            //  var alloc = Allocation;
         
            Gdk.Rectangle alloc = new Gdk.Rectangle((int)p8SkiaLayout.Bounds.X, (int)p8SkiaLayout.Bounds.Y, (int)p8SkiaLayout.WidthRequest, (int)p8SkiaLayout.HeightRequest);
            var imgInfo = new SKImageInfo(alloc.Width, alloc.Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            if (pix == null || pix.Width != imgInfo.Width || pix.Height != imgInfo.Height)
            {
                FreeDrawingObjects();

                if (imgInfo.Width != 0 && imgInfo.Height != 0)
                {
                    pix = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, true, 8, imgInfo.Width, imgInfo.Height);

                    // (re)create the SkiaSharp drawing objects
                    surface = SKSurface.Create(imgInfo, pix.Pixels, imgInfo.RowBytes);
                }
            }

            return imgInfo;
        }

        protected virtual void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            // invoke the event
            PaintSurface?.Invoke(this, e);

            p8SkiaLayout.OnCanvasViewPaintSurface(this, e);
        }
        private void FreeDrawingObjects()
        {
            pix?.Dispose();
            pix = null;

            // SkiaSharp objects should only exist if the Pixbuf is set as well
            surface?.Dispose();
            surface = null;
        }

        ~SkiaRenderer()
        {
            Dispose(false);
        }
        public override void Destroy()
        {
            GC.SuppressFinalize(this);
            Dispose(true);

            base.Destroy();
        }
        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);

            base.Dispose();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                FreeDrawingObjects();
            }
            this.Dispose(disposing);
        }

    }
}
