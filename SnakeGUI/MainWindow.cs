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
        private SnakeLib.Direction direction = SnakeLib.Direction.Up;

        public MainWindow() : this(new Builder("MainWindow.glade")) { }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            area = new Area(AppSettings.AreaWidth, AppSettings.AreaHeight);
            this.KeyPressEvent += KeyPressed;


            Draw();
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private async Task Draw()
        {
            int counter = 0; // счтётчик для обращения к змейке
            int K = AppSettings.GetImgResizeK(); // коэфициент масштабирования
            // настройка Cairo
            var cs = new Cairo.ImageSurface(Format.Argb32, (area.W + 2) * K, (area.H + 2) * K);
            var cc = new Cairo.Context(cs);


            cc.Scale(K, K);
            cc.Translate(+1, +1);
            while (area.SnakeIsLive)
            {
                await Task.Run(() => System.Threading.Thread.Sleep(AppSettings.GamePeriod));

                Color CWall = SetEpilepsyColor(1, 1, 0);
                Color CBack = SetEpilepsyColor(0.1568, 0.1568, 0.1568);
                Color CApple = SetEpilepsyColor(1, 0, 0);
                Color CSnake = SetEpilepsyColor(0, 1, 0);



                // Границы поля
                cc.Rectangle(-1, -1, area.W + 2, area.H + 2);
                cc.SetSourceColor(CWall);
                cc.Fill();

                // границы поля
                cc.Rectangle(0, 0, area.W, area.H);
                cc.SetSourceColor(CBack);
                cc.Fill();


                // Яблоко
                cc.Rectangle(area.Apple.x, area.Apple.y, 1, 1);
                cc.SetSourceColor(CApple);
                cc.Fill();

                // Змей
                foreach (var i in area.Snake)
                    cc.Rectangle(i.x, i.y, 1, 1);
                cc.SetSourceColor(CSnake);
                cc.Fill();

                await Task.Run(() => System.Threading.Thread.Sleep(10));
                img.FromSurface = cs;

                counter++;
                if (counter >= AppSettings.SnakeSpeed)
                {
                    area.NextStep(direction);
                    counter = 0;
                }
            }

            cc.GetTarget().Dispose();
            cc.Dispose();
            cs.Dispose();
        }

        private Color SetEpilepsyColor(double r, double g, double b) =>
                            AppSettings.EpilepsyMode ?
                            new Color(Random.Shared.NextDouble(), Random.Shared.NextDouble(), Random.Shared.NextDouble()) :
                            new Color(r, g, b);

        [GLib.ConnectBefore]
        void KeyPressed(object sender, KeyPressEventArgs e)
        {
            direction = e.Event.Key switch
            {
                (Gdk.Key.Down or Gdk.Key.downarrow or Gdk.Key.KP_Down) => SnakeLib.Direction.Down,
                (Gdk.Key.Up or Gdk.Key.uparrow or Gdk.Key.KP_Up) => SnakeLib.Direction.Up,
                (Gdk.Key.Left or Gdk.Key.leftarrow or Gdk.Key.KP_Left) => SnakeLib.Direction.Left,
                (Gdk.Key.Right or Gdk.Key.rightarrow or Gdk.Key.KP_Right) => SnakeLib.Direction.Right,
                _ => direction
            };

            Console.WriteLine(direction.ToString());
        }
    }
}
