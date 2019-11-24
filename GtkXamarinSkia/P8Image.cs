using System;
using Xamarin.Forms;

namespace SkiaTest
{
    public class P8Image : Xamarin.Forms.Image
    {
        P8ImageSource imageSource;
        public P8Image(P8ImageSource source):base()
        {
            imageSource = source;
            Binding bindW = new Binding { Source = this, Path = "Width", Mode = BindingMode.TwoWay };
            source.SetBinding(P8ImageSource.WidthProperty, bindW);
            Binding bindH = new Binding("Height", source:this);
            source.SetBinding(P8ImageSource.HeightProperty, bindH);
            Binding bindS = new Binding("ImageSource", source:source);
            this.SetBinding(Image.SourceProperty, binding: bindS);
        }
    }
}
