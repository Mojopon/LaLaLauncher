using LaLaLauncher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaLaLauncher.Views
{
    /// <summary>
    /// Interaction logic for ApplicationList.xaml
    /// </summary>
    public partial class LaunchableList : UserControl
    {
        public LaunchableList()
        {
            InitializeComponent();
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            LaunchableListViewModel viewModel = DataContext as LaunchableListViewModel;
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
                foreach (var path in files)
                    viewModel.AddNewLaunchable(path);
        }
    }
}
