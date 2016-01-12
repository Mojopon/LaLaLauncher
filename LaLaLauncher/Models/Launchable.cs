using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Livet;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using LaLaLauncher.Utility;
using System.Windows.Interop;
using System.Windows;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;

namespace LaLaLauncher.Models
{
    public class Launchable : NotificationObject
    {
        public string Path { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        public bool? IsSelected { get; set; }

        #region Icon変更通知プロパティ
        [XmlIgnore]
        private BitmapSource _Icon;

        [XmlIgnore]
        public BitmapSource Icon
        {
            get
            { return _Icon; }
            set
            { 
                if (_Icon == value)
                    return;
                _Icon = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public Launchable() { }

        public Launchable(string path)
        {
            Path = path;

            GetApplicationInfoFromThePath();
        }

        public void GetApplicationInfoFromThePath()
        {
            if (!File.Exists(Path)) return;

            Name = PathUtility.GetFileNameFromPath(Path) == null ? Name : PathUtility.GetFileNameFromPath(Path);
            Icon = IconUtility.ExtractIcon(Path);
        }

        public void Launch()
        {
            var process = Process.Start(Path);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
