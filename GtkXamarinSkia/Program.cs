using SkiaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace GtkXamarinSkia
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // RunGtkWindow();
            RunXamarinWidow();
        }


        static void RunXamarinWidow()
        {
            Gtk.Application.Init();
            Forms.Init();
            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("This is app from GTK");
            window.Show();
            Gtk.Application.Run();
        }

        static void RunGtkWindow()
        {
            Gtk.Application.Init();
            Gtk.Window myWin = new Gtk.Window("My first GTK# Application! ");
            myWin.Resize(200, 200);
            myWin.ButtonPressEvent += (s,ev)=>
            {

            };
            //Create a label and put some text in it.

            Gtk.Label myLabel = new Gtk.Label();
            myLabel.Text = "Hello World!!!!";

            //Add the label to the form
            // myWin.Add(myLabel);

            Gtk.Button gtk_but = new Gtk.Button();
            gtk_but.HeightRequest = 100;
            gtk_but.WidthRequest = 100;
            gtk_but.Label = "button";
            myWin.Add(gtk_but);
            //Show Everything

            myWin.ShowAll();

            Gtk.Application.Run();
        }
    }
}
