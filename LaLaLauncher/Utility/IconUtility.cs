using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace LaLaLauncher.Utility
{
    public static class IconUtility
    {
        public static BitmapSource ExtractIcon(string filePath)
        {
            var sysicon = System.Drawing.Icon.ExtractAssociatedIcon(filePath);
            var bmpSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                         sysicon.Handle,
                         System.Windows.Int32Rect.Empty,
                         BitmapSizeOptions.FromEmptyOptions());
            sysicon.Dispose();

            return bmpSrc;
        }
    }
}
