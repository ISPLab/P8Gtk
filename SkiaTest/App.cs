using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkiaTest
{
    public partial class App : Application
    {
        public App()
        {
            /*MainPage = new ContentPage
            {
                Content = new SkAreaRenderer()
            };*/

            MainPage = new ContentPage
            {
                Content = new ButtonPressTest()
            };
        }
    }
}

