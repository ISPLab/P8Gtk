using System;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;

namespace SkiaTest
{
    public abstract class P8ImageSource : StreamImageSource /*, ISvgImageSource*/
    {
        SKBitmap bitmap;
        protected SKCanvas sKCanvas;

        public static BindableProperty WidthProperty =
        BindableProperty.Create(
           nameof(Width),
           typeof(double),
           typeof(P8ImageSource),
           (double)1.0,
          // defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: (s, v, n) => {
                   (s as P8ImageSource).InvalidateCanvas();
               }
       );

        public double Width
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public virtual async Task Animate()
        {

        }
     

        public static BindableProperty HeightProperty =
            BindableProperty.Create(
                nameof(Height),
                typeof(double),
                typeof(P8ImageSource),
                 (double)1.0,
                defaultBindingMode: BindingMode.OneWay,
                propertyChanged: (s,v,n) => {
                    (s as P8ImageSource).InvalidateCanvas();
                }
            );

        public double Height
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }


       public static BindableProperty ScaleProperty =
       BindableProperty.Create(
       nameof(Scale),
       typeof(double),
       typeof(P8ImageSource),
        (double)1.0,
       defaultBindingMode: BindingMode.OneWay,  propertyChanged: (s, v, n) => {
           (s as P8ImageSource).InvalidateCanvas();
       }
   );
        public double Scale
        {
            get { return (double)GetValue(ScaleProperty); }
            set { SetValue(ScaleProperty, value); }
        }
        public P8ImageSource()
        {
           // InvalidateCanvas();
        }

        public static BindableProperty ImageSourceProperty =
 BindableProperty.Create(
 nameof(ImageSource),
 typeof(ImageSource),
 typeof(P8ImageSource),
 default(ImageSource),
 defaultBindingMode: BindingMode.OneWay, propertyChanged: (s, v, n) => {
     //(s as P8ImageSource).InvalidateCanvas();
 }
);
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public void InvalidateCanvas()
        {
            if (Width <=1 || Height <= 1) return;

            var imgInfo = new SKImageInfo((int)Width, (int)Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
            bitmap = new SKBitmap(imgInfo);
            sKCanvas = new SKCanvas(bitmap);
            sKCanvas.Scale((float)Scale);
            PaintBitmap();
            this.ImageSource = GetImageResource();
        }

        public abstract void PaintBitmap();

        internal ImageSource GetImageResource()
        {
            SKImage image = SKImage.FromBitmap(bitmap);
            // encode the image (defaults to PNG)
            SKData encoded = image.Encode();
            System.IO.Stream stream = encoded.AsStream();
            var source = Xamarin.Forms.ImageSource.FromStream(() => stream);
           
            return source;
        }

    }
}