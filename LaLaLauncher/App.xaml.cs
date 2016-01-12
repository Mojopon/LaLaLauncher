using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LaLaLauncher.Views;
using LaLaLauncher.ViewModels;
using LaLaLauncher.Settings;
using Livet;
using System.Threading;
using MetroTrilithon.Serialization;
using LaLaLauncher.Models.Managers;

namespace LaLaLauncher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    sealed partial class App : Application
    {
        private LivetCompositeDisposable compositeDisposable = new LivetCompositeDisposable();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            /*
            var provider = Provider.Local;
            provider.Load();
            compositeDisposable.Add(provider.Save); 
            */


            var manager = LaunchableManager.Instance;
            compositeDisposable.Add(manager.Save);

            this.MainWindow = new MainWindow();
            MainWindow.DataContext = new MainWindowViewModel();
            this.MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            compositeDisposable.Dispose();

            Thread.Sleep(1000);
        }
    }
}
