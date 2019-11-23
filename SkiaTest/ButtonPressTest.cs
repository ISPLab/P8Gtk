using System;
using Xamarin.Forms;
namespace SkiaTest
{
    public class ButtonPressTest: Xamarin.Forms.ContentView
    {
        public ButtonPressTest()
        {
            Button button = new Button
            {
                Text = "Click me",
                HeightRequest = 100,
                WidthRequest = 100
            };
            button.Clicked += (s,e)=>
            {
                button.Text = "Clicked!";
            };
            StackLayout layout = new StackLayout();
            layout.Children.Add(button);
            this.Content = layout;

        }
    }
}
