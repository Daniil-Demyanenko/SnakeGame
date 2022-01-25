using System;
using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using System.Threading.Tasks;

namespace SnakeGUI
{
    class SettingsWin : Window
    {
        [UI] private CheckButton EpilepsyCheck = null;
        [UI] private Button StartBtn = null;
        [UI] private Scale SHeight = null;
        [UI] private Scale SWidth = null;
        [UI] private Scale SSize = null;


        public SettingsWin() : this(new Builder("MainWindow.glade")) { }

        private SettingsWin(Builder builder) : base(builder.GetRawOwnedObject("SettingsWin"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            StartBtn.Clicked += Start_Click;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            // Настройка приложения
            AppSettings.EpilepsyMode = EpilepsyCheck.Active;
            AppSettings.AreaWidth = (int)SWidth.Value;
            AppSettings.AreaHeight = (int)SHeight.Value;
            AppSettings.ImgSize = (int)SSize.Value;

            this.Hide();    //скрыли текущее окно
            var gameWin = new MainWindow();
            Program.app.AddWindow(gameWin); // Добавили новое окно в приложении
            Application.Windows[0].Show(); // Показываем окно с игрой
        }
    }
}