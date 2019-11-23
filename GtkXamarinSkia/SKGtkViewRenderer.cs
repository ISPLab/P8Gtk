using System;
using System.ComponentModel;
using SkiaSharp.Views.Forms;
using SkiaSharp.Views.Gtk;
using SkiaTest;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

[assembly: ExportRenderer(typeof(PureSkia), typeof(GtkXamarinSkia.GTK.SKGtkViewRenderer))]
namespace GtkXamarinSkia.GTK
{
    public class SKGtkViewRenderer : ViewRenderer<PureSkia, SKWidget>
    {
        
        protected override void Dispose(bool disposing)
        {
            var control = Control;
            if (control != null)
            {
               // control.PaintSurface -= OnPaintSurface;
            }
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<PureSkia> e)
        {
            if (e.OldElement != null)
            {
                (e.NewElement as SkiaTest.ISKCanvasViewController).SurfaceInvalidated -= HandleSurfaceInvalidated;
            }
            if (e.NewElement != null)
            {
                // create the native view
                if (Control == null)
                {
                   
                    var view = CreateNativeControl();
                    view.HeightRequest = 200;
                    view.WidthRequest = 200;
                  
                    view.PaintSurface += OnPaintSurface;
                    SetNativeControl(view);
                    view.ButtonPressEvent += View_ButtonPressEvent;
                    view.FocusMoved += View_FocusMoved;
                    view.EnterNotifyEvent += View_EnterNotifyEvent;
                  
                }
                (e.NewElement as SkiaTest.ISKCanvasViewController).SurfaceInvalidated += HandleSurfaceInvalidated;
            }
            base.OnElementChanged(e);
        }

        private void View_EnterNotifyEvent(object o, Gtk.EnterNotifyEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void View_FocusMoved(object o, Gtk.FocusMovedArgs args)
        {
            throw new NotImplementedException();
        }

        private void View_ButtonPressEvent(object o, Gtk.ButtonPressEventArgs args)
        {
            //throw new NotImplementedException();
        }

        void OnPaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            // the control is being repainted, let the user know
            (Element as SkiaTest.ISKCanvasViewController)?.OnPaintSurface(new SKPaintSurfaceEventArgs(e.Surface, e.Info));
        }

        protected virtual SKWidget CreateNativeControl()
        {
            return new SKWidget();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // FIXME: uncomment when supported
            /*
            if (e.PropertyName == SKFormsView.IgnorePixelScalingProperty.PropertyName)
            {
                Control.IgnorePixelScaling = Element.IgnorePixelScaling;
            }
            */
        }

        void HandleSurfaceInvalidated(object sender, EventArgs e)
        {
            QueueDraw();
        }
    }
}