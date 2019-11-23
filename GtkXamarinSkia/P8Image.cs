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
            Binding bindW = new Binding("Width", source: this,mode:BindingMode.TwoWay);
            source.SetBinding(WidthProperty, bindW);
            Binding bindH = new Binding("Height", source:this);
            source.SetBinding(HeightProperty, bindH);
            Binding bindS = new Binding("ImageSource", source:source);
            this.SetBinding(Image.SourceProperty, binding: bindS);
       
        }

        internal void SetP8Source(P8ImageSource source)
        {
            imageSource = source;
            Binding bindW = new Binding("Width", source: this, mode: BindingMode.TwoWay);
            source.SetBinding(WidthProperty, bindW);
            Binding bindH = new Binding("Height", source: this);
            source.SetBinding(HeightProperty, bindH);
            Binding bindS = new Binding("ImageSource", source: source);
            this.SetBinding(Image.SourceProperty, binding: bindS);
            //source.Width = 100;// this.Width;
            //source.Height = 100;// this.Height;
        }
    }
}