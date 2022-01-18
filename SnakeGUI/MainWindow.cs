using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Cairo;
using System.Timers;

namespace SnakeGUI
{
    class MainWindow : Window
    {
        [UI] private Label snake_info = null;
        [UI] private Image img = null;
        private Timer timer;

        //https://zetcode.com/gui/gtksharp/drawing/

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            //img.KeyPressEvent += KeyPressed;

            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Draw;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            timer.Dispose();
            Application.Quit();
        }


        private void Draw(Object source, ElapsedEventArgs e)
        {
            var cs = new Cairo.ImageSurface(Format.Argb32, 500, 500);

            Cairo.Context cc = new Cairo.Context(cs);
            Cairo.PointD point1 = new Cairo.PointD(85, 0);
            Cairo.PointD point2 = new Cairo.PointD(95, 0);

            cc.Rectangle(0, 0, 500, 500);
            cc.SetSourceRGB(1, 0.5, 0);
            cc.LineWidth = 50;
            cc.Stroke();

            cc.Rectangle(25, 25, 25, 25);
            cc.SetSourceRGB(1, 0, 0);
            cc.Fill();

            img.FromSurface = cs;

            cc.GetTarget().Dispose();
            cc.Dispose();
            cs.Dispose();
        }

        // void Draw()
        // {
        //     using (Cairo.Context cc = Gdk.CairoHelper.Create(darea.GdkWindow))
        //     {

        //         cc.SetSourceRGB(0.2, 0.23, 0.9);
        //         cc.LineWidth = 1;

        //         cc.Rectangle(20, 20, 120, 80);
        //         cc.Rectangle(180, 20, 80, 80);
        //         cc.StrokePreserve();
        //         cc.SetSourceRGB(1, 1, 1);
        //         cc.Fill();

        //         cc.GetTarget().Dispose();
        //     }
        // }
    }
}
