using System;
using Xamarin.Forms;

namespace SkiaTest
{
    public class P8ImageTest : ContentView
    {
        public P8ImageTest()
        {
            CircleImgSource cis = new CircleImgSource();
            P8Image image = new P8Image(cis);
            image.WidthRequest = 100;
            image.HeightRequest = 100;
            image.BackgroundColor = Color.LightBlue;
            StackLayout stack = new StackLayout();
            stack.Children.Add(image);
            this.Content = stack;
        }
    }
}
