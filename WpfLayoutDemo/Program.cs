using System;
using System.Windows;
using LayoutControlDemo.Modules;

namespace DevExpress.Xpf.LayoutControlDemo
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DevExpress.Xpf.Core.ThemeManager.EnableDefaultThemeLoading = false;
            DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName =
                                DevExpress.Xpf.Core.Theme.MetropolisLight.Name;

            Startup.RunTest();
        }
    }

    public class App : Application
    {
    }

    public class Startup
    {
        public static void InitDemo() { }

        public static void RunTest()
        {
            var main = new Window1();
            var app = new App();

            app.MainWindow = main;

            main.Show();
            app.Run();
        }

        protected bool GetDebug()
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}
