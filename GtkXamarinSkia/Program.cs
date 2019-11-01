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
             Gtk.Application.Init();
             Forms.Init();
             var app = new App();
             var window = new FormsWindow();
             window.LoadApplication(app);
             window.SetApplicationTitle("This is app from GTK");
             window.Show();
             Gtk.Application.Run();
        }
    }
}
