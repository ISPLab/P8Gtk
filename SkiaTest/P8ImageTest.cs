using System;
using Xamarin.Forms;

namespace SkiaTest
{
    public class P8ImageTest : ContentView
    {
        public P8ImageTest()
        {
            FlexLayout layout = new FlexLayout();
            Frame image_frame = new Frame();
            image_frame.WidthRequest = 500;
            image_frame.HeightRequest = 500;

            CircleImgSource cis = new CircleImgSource();
            P8Image image = new P8Image(cis);
            FlexLayout.SetAlignSelf(image, FlexAlignSelf.Stretch);
           // FlexLayout.SetGrow(image, 2f);
            FlexLayout.SetBasis(image_frame, new FlexBasis(0.9f));
           // FlexLayout.SetBasis(image, new FlexBasis(600f));
            Binding bindI = new Binding { Source = layout, Path = "Width" };
            image.SetBinding(WidthRequestProperty, bindI);
            image_frame.Content = image;
            layout.Children.Add(image_frame);

            // image.HeightRequest = 100;
            image.BackgroundColor = Color.LightBlue;
            layout.Direction = FlexDirection.Column;
            layout.AlignItems = FlexAlignItems.Start;
            layout.JustifyContent = FlexJustify.Center;
            layout.Children.Add(image);

            FlexLayout layout1 = new FlexLayout();
            layout.HeightRequest = 100;
            Label width_label = new Label { Text="Width: " };
            Label label = new Label();
            label.SetBinding(Label.TextProperty, new Binding(source:image, path:"Width"));
            layout1.Children.Add(width_label);
            layout1.Children.Add(label);

            Label height_label = new Label { Text = " Height: " };
            layout1.Children.Add(height_label);
            Label height_labela_value = new Label();
            height_labela_value.SetBinding(Label.TextProperty, new Binding { Source = image, Path = "Height" });
            layout1.Children.Add(height_labela_value);

            FlexLayout.SetBasis(layout1, new FlexBasis(1));
            Frame bottom_frame = new Frame();
            bottom_frame.Content = layout1;
            layout.Children.Add(bottom_frame);
            this.Content = layout;
        }
    }
}
