using System;
using Gtk;

namespace SnakeGUI
{
    class Program
    {
        public static Application app = new Application("org.SnakeGUI.SnakeGUI", GLib.ApplicationFlags.None);
        [STAThread]
        public static void Main(string[] args)
        {
            Application.Init();
            app.Register(GLib.Cancellable.Current);

            //var win = new MainWindow();
            var startWin = new SettingsWin();
            
            app.AddWindow(startWin);
            //app.AddWindow(win);
            
            startWin.Show();
            Application.Run();
        }
    }
}
