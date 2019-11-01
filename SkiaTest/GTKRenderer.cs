using Gtk;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace SkiaTest
{
    public class GTKRenderer : DrawingArea
    {
        private Gdk.Pixbuf pix;
        private SKSurface surface;

        [Category("Appearance")]
        public event EventHandler<SKPaintSurfaceEventArgs> PaintSurface;

        public GTKRenderer()
        {
            SetSizeRequest(200, 200);
           
        }
        protected override bool OnExposeEvent(Gdk.EventExpose evnt)
        {
            var window = evnt.Window;
            var area = evnt.Area;
            window.DrawRectangle(Style.BlackGC, false, 10, 10, 100, 200);
         
            /*            var imgInfo = CreateDrawingObjects();
            using (new SKAutoCanvasRestore(surface.Canvas, true))
            {
                OnPaintSurface(new SKPaintSurfaceEventArgs(surface, imgInfo));
            }*/

            return true; 
        }

        protected virtual void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            // invoke the event
            PaintSurface?.Invoke(this, e);
        }

        private SKImageInfo CreateDrawingObjects()
        {
            var alloc = Allocation;
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

        private void FreeDrawingObjects()
        {
            pix?.Dispose();
            pix = null;

            // SkiaSharp objects should only exist if the Pixbuf is set as well
            surface?.Dispose();
            surface = null;
        }
    }
}
