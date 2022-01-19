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
            area = new Area(35, 35);

            Draw();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private async Task Draw()
        {
            int K = (area.H > area.W) ? 800 / (area.H + 2) : 800 / (area.W + 2); // коэфициент масштабирования
            // настройка Cairo
            var cs = new Cairo.ImageSurface(Format.Argb32, (area.W + 2) * K, (area.H + 2) * K);
            var cc = new Cairo.Context(cs);


            cc.Scale(K, K);
            cc.Translate(+1, +1);
            while (area.SnakeIsLive)
            {
                await Task.Run(() => System.Threading.Thread.Sleep(200));

                // Границы поля
                cc.Rectangle(-1, -1, area.W + 2, area.H + 2);
                cc.SetSourceRGB(Random.Shared.NextDouble(), Random.Shared.NextDouble(), Random.Shared.NextDouble());
                cc.Fill();

                // границы поля
                cc.Rectangle(0, 0, area.W, area.H);
                cc.SetSourceRGB(0.1568, 0.1568, 0.1568);
                cc.Fill();


                // Яблоко
                cc.Rectangle(area.Apple.x, area.Apple.y, 1, 1);
                cc.SetSourceRGB(1, 0, 0);
                cc.Fill();

                // Змей
                foreach (var i in area.Snake)
                    cc.Rectangle(i.x, i.y, 1, 1);
                cc.SetSourceRGB(0, 1, 0);
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
