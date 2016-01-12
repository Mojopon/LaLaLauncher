using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MetroTrilithon.Serialization;

namespace LaLaLauncher.Settings
{
    public class Provider
    {
        public static string LocalFilePath { get; } = Directory.GetCurrentDirectory() + "\\Settings\\" + "Setting.xaml";

        public static ISerializationProvider Local { get; } = new FileSettingsProvider(LocalFilePath);
    }
}
