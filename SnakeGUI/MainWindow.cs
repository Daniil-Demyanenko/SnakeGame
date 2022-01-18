using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using Cairo;
using System.Timers;
using System.Threading.Tasks;
using SnakeLib;

namespace SnakeGUI
{
    class MainWindow : Window
    {
        [UI] private Label snake_info = null;
        [UI] private Image img = null;
        private Area area;

        //https://zetcode.com/gui/gtksharp/drawing/

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            area = new Area(500,500);

            Draw();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private async Task Draw()
        {
            // настройка Cairo
            var cs = new Cairo.ImageSurface(Format.Argb32, 500, 500);
            var cc = new Cairo.Context(cs);

            while (area.SnaleIsLive)
            {
                await Task.Run(() => System.Threading.Thread.Sleep(200));
                //обновляем фон
                cc.Rectangle(0, 0, 500, 500);
                cc.SetSourceRGB(40/(double)255, 40/(double)255, 40/(double)255);
                cc.Fill();

                // границы поля
                cc.Rectangle(0, 0, 500, 500);
                cc.SetSourceRGB(Random.Shared.NextDouble(), Random.Shared.NextDouble(), Random.Shared.NextDouble());
                cc.LineWidth = 50;
                cc.Stroke();

                // Яблоко
                cc.Rectangle(50, 50, 25, 25);
                cc.SetSourceRGB(1, 0, 0);
                cc.Fill();

                await Task.Run(() => System.Threading.Thread.Sleep(10));
                img.FromSurface = cs;
            }

            cc.GetTarget().Dispose();
            cc.Dispose();
            cs.Dispose();
        }
    }
}
