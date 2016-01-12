using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace LaLaLauncher.Utility
{
    public static class FileUtility
    {
        public static void Save<T>(T obj, string localFilePath)
        {
            var directory = PathUtility.GetDirectoryFromPath(localFilePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            var serializer = new XmlSerializer(typeof(T));
            var sw = new StreamWriter(localFilePath, false, new System.Text.UTF8Encoding(false));
            using (sw)
            {
                serializer.Serialize(sw, obj);
            }
        }

        public static T Load<T>(string localFilePath) where T : new()
        {
            if (File.Exists(localFilePath))
            {
                return TryDeserialize<T>(localFilePath);
            }
            else
            {
                return new T();
            }
        }

        private static T TryDeserialize<T>(string localFilePath) where T : new()
        {
            try
            {
                using (var fs = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                {
                    XmlReader reader = new XmlTextReader(fs);
                    var serializer = new XmlSerializer(typeof(T));
                    if (serializer.CanDeserialize(reader))
                    {
                        T obj = (T)serializer.Deserialize(reader);
                        return obj;
                    }
                    else
                    {
                        return new T();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new T();
            }
        }
    }
}
