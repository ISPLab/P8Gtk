using System;
using Xamarin.Forms;
namespace SkiaTest
{
    public class ButtonPressTest: Xamarin.Forms.ContentView
    {
        public ButtonPressTest()
        {
            StackLayout layout = new StackLayout();
            //  PureSkia pureSkia = new PureSkia();
            //  pureSkia.WidthRequest = 50;
            //  pureSkia.HeightRequest = 50;
            P8SKImage p8SKImage = new P8SKImage();
            Button button = new Button
            {
                Text = "Click me",
                HeightRequest = 100,
                WidthRequest = 100
            };
            Image image = new Image { WidthRequest = 100, HeightRequest = 100, BackgroundColor = Color.LightBlue };
            p8SKImage.Painted += (s, e) =>
            {
                image.Source = p8SKImage.GetImageSource();
            };

            button.Clicked += async (s,e)=>
            {
                button.Text = "Clicked!";
                //  button.ContentLayout = image,
                // pureSkia.InvalidateSurface();
                button.ImageSource = p8SKImage.GetImageSource();
                await p8SKImage.AnimationLoop();
            };
            // button.ContentLayout=  new Button.ButtonContentLayout(new Button.ButtonContentLayout.ImagePosition(0))
            image.GestureRecognizers.Add(new TapGestureRecognizer((s,ev)=>
            {
                image.Source = p8SKImage.GetImageSource();
            }));
            button.BackgroundColor = Color.Aqua;
         
            layout.Children.Add(button);
            layout.Children.Add(image);
           // layout.Children.Add(pureSkia);
         
            this.Content = layout;
        }


  
    }
}
