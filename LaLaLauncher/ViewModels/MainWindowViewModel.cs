using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Livet;

namespace LaLaLauncher.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private object _Content;
        public object Content
        {
            get { return _Content; }
            set
            {
                if (_Content == value)
                    return;
                _Content = value;
                RaisePropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _Content = new LaunchableListViewModel();
        }

        public void Initialize() { }
    }
}
