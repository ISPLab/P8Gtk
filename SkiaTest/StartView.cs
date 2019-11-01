using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkiaTest
{
    public class SkAreaRenderer : ContentView
    {
        public SkAreaRenderer()
        {
            Label label = new Label
            {Text ="This is xamarin label on Xamarin Content View"};
            StackLayout stack = new StackLayout();
            stack.Children.Add(label);
            P8SkiaLayout gTKRenderer = new P8SkiaLayout();
            gTKRenderer.WidthRequest = 100;
            gTKRenderer.HeightRequest = 100;
         //   stack.Children.Add(gTKRenderer);
         //   Content = stack;
            Content = gTKRenderer;
        }
    }
}
