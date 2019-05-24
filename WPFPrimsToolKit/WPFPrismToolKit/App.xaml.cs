using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Log4;

namespace WPFPrimsToolKit
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the Config
        /// </summary>
        public static Config Config { get; set; }
        static App()
        {
            Log.Info("App Constructeur");
#if (DEBUG)
            
#endif
            App.Config = new Config();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Log.Info("App OnStartup");

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Log.Info("App OnExit");
        }
    }
}
