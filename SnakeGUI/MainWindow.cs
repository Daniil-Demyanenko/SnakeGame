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
        [UI] private Label _snakeInfo = null;
        [UI] private Image _img = null;
        private Area _area;
        private SnakeLib.Direction _direction = SnakeLib.Direction.Up;

        public MainWindow() : this(new Builder("MainWindow.glade"))
        {
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _area = new Area(AppSettings.AreaWidth, AppSettings.AreaHeight);
            this.KeyPressEvent += KeyPressed;

            Task.Run(Draw);
            Task.Run(MoveSnake);
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private async Task MoveSnake()
        {
            while (!_area.EndOfGame)
            {
                // Двигаем змейку
                _area.NextStep(_direction);
                // указываем длину змейки
                _snakeInfo.Text = (_area.Snake.Count > 2)
                    ? $"Длина змейки: {_area.Snake.Count}"
                    : "Управление стрелочками";

                await Task.Delay(AppSettings.SnakeSpeed);
            }

            _snakeInfo.Text = _area.SnakeIsLive ? "ПОБЕДА!" : "ПОРАЖЕНИЕ!";
        }

        private async Task Draw()
        {
            int counter = 0; // счтётчик для обращения к змейке
            int K = AppSettings.GetImgResizeK(); // коэфициент масштабирования
            // настройка Cairo
            using var cs = new Cairo.ImageSurface(Format.Argb32, (_area.W + 2) * K, (_area.H + 2) * K);
            using var cc = new Cairo.Context(cs);


            cc.Scale(K, K);
            cc.Translate(+1, +1);
            while (!_area.EndOfGame)
            {
                await Task.Delay(AppSettings.SnakeSpeed);

                //инициализируем цвета
                Color CWall = SetEpilepsyColor(1, 1, 0);
                Color CBack = SetEpilepsyColor(0.1568, 0.1568, 0.1568);
                Color CApple = SetEpilepsyColor(1, 0, 0);
                Color CSnake = SetEpilepsyColor(0, 1, 0);

                // Границы поля
                cc.Rectangle(-1, -1, _area.W + 2, _area.H + 2);
                cc.SetSourceColor(CWall);
                cc.Fill();

                // Фон
                cc.Rectangle(0, 0, _area.W, _area.H);
                cc.SetSourceColor(CBack);
                cc.Fill();

                // Яблоко
                cc.Rectangle(_area.Apple.X, _area.Apple.Y, 1, 1);
                cc.SetSourceColor(CApple);
                cc.Fill();

                // Змей
                foreach (var i in _area.Snake)
                    cc.Rectangle(i.X, i.Y, 1, 1);
                cc.SetSourceColor(CSnake);
                cc.Fill();

                await Task.Run(() => System.Threading.Thread.Sleep(10));
                _img.FromSurface = cs;
            }

            cc.GetTarget().Dispose();
        }

        // Если включен эпилептикМод, возвращает случайный чвет. Иначе -- указанный
        private Color SetEpilepsyColor(double r, double g, double b) =>
            AppSettings.EpilepsyMode
                ? new Color(Random.Shared.NextDouble(), Random.Shared.NextDouble(), Random.Shared.NextDouble())
                : new Color(r, g, b);

        [GLib.ConnectBefore]
        void KeyPressed(object sender, KeyPressEventArgs e)
        {
            _direction = e.Event.Key switch
            {
                (Gdk.Key.Down or Gdk.Key.downarrow or Gdk.Key.KP_Down) => SnakeLib.Direction.Down,
                (Gdk.Key.Up or Gdk.Key.uparrow or Gdk.Key.KP_Up) => SnakeLib.Direction.Up,
                (Gdk.Key.Left or Gdk.Key.leftarrow or Gdk.Key.KP_Left) => SnakeLib.Direction.Left,
                (Gdk.Key.Right or Gdk.Key.rightarrow or Gdk.Key.KP_Right) => SnakeLib.Direction.Right,
                _ => _direction
            };
        }
    }
}