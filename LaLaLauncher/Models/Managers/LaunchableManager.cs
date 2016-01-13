using LaLaLauncher.Settings;
using LaLaLauncher.Utility;
using MetroTrilithon.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using System.Xml;
using System.Xml.Serialization;

namespace LaLaLauncher.Models.Managers
{
    public class LaunchableManager 
    {
        private static string localFilePath { get
            {
                return PathUtility.CreatePathFromFileName("Launchables.xml", "StoredModels");
            }
        }
        private ObservableCollection<LaunchableGroup> compositeLaunchables;

        public static LaunchableManager Instance { get; } = new LaunchableManager();
        public LaunchableManager()
        {
            compositeLaunchables = FileUtility.Load<ObservableCollection<LaunchableGroup>>(localFilePath);
            foreach(LaunchableGroup compositeLaunchable in compositeLaunchables)
            {
                compositeLaunchable.UpdateLaunchableInfos();
            }
        }

        public ObservableCollection<LaunchableGroup> GetLaunchables()
        {
            return compositeLaunchables;
        }

        public void Save()
        {
            FileUtility.Save(compositeLaunchables, localFilePath);
        }
    }
}
