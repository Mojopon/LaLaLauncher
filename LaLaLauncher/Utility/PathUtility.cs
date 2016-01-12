using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaLauncher.Utility
{
    public static class PathUtility
    {
        public static List<string> ExecutableExtensions = new List<string>()
        {
            "exe",
        };

        public static string GetFileNameFromPath(string path)
        {
            string fileName = "";
            for (int i = 0; i < path.Length - 1; i++)
            {
                var character = path[path.Length - (i + 1)];
                if (character == '\\')
                {
                    fileName = path.Substring(path.Length - i, i);
                    return fileName;
                }
            }

            return fileName;
        }

        public static bool IsExecutable(string path)
        {
            var fileName = GetFileNameFromPath(path);
            for(int i = 0; i < path.Length - 1; i++)
            {
                var character = path[path.Length - (i + 1)];
                if(character == '.')
                {
                    var extension = fileName.Substring(fileName.Length - i, i).ToLower();
                    foreach(string executableExtension in ExecutableExtensions)
                    {
                        if (extension == executableExtension) return true;
                    }
                }
            }

            return false;
        }

        public static string GetDirectoryFromPath(string path)
        {
            string fileName = "";
            for (int i = 0; i < path.Length - 1; i++)
            {
                var character = path[path.Length - (i + 1)];
                if (character == '\\')
                {
                    fileName = path.Substring(0, path.Length - i);
                    return fileName;
                }
            }

            return fileName;
        }

        public static string CreatePathFromFileName(string fileName, params string[] folders)
        {
            string path = "";

            path = Directory.GetCurrentDirectory();

            foreach(string folderName in folders)
            {
                path += "\\" + folderName;
            }

            path += "\\" + fileName;

            return path;
        }
    }
}
