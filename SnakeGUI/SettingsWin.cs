using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Threading.Tasks;

namespace SnakeGUI
{
    class SettingsWin : Window
    {
        [UI] private CheckButton _epilepsyCheck = null;
        [UI] private Button _startBtn = null;
        [UI] private Scale _height = null;
        [UI] private Scale _width = null;
        [UI] private Scale _size = null;
        [UI] private Scale _speed = null;


        public SettingsWin() : this(new Builder("MainWindow.glade")) { }

        private SettingsWin(Builder builder) : base(builder.GetRawOwnedObject("SettingsWin"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            _startBtn.Clicked += Start_Click;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            // Настройка приложения
            AppSettings.EpilepsyMode = _epilepsyCheck.Active;
            AppSettings.AreaWidth = (int)_width.Value;
            AppSettings.AreaHeight = (int)_height.Value;
            AppSettings.ImgSize = (int)_size.Value;
            AppSettings.SnakeSpeed = (int)_speed.Value;

            this.Hide();    // Cкрыли текущее окно
            var gameWin = new MainWindow();
            Program.app.AddWindow(gameWin); // Добавили новое окно в приложении
            Application.Windows[0].Show(); // Показываем окно с игрой
        }
    }
}