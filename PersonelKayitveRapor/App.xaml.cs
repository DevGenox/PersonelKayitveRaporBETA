using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace PersonelKayitveRapor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            Splashwindow splash = new Splashwindow();
            splash.Show();

            Elemanlistesi main = new Elemanlistesi();


            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(i);
            }

            splash.Close();

            main.Show();
        }
    }
}
