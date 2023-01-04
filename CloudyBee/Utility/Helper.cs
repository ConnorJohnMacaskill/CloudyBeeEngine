using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CloudyBeeEngine.Utility
{
    public static class Helper
    {
        private static Random random = new Random();

        public static int GetRandomInt(int max)
        {
            return GetRandomInt(0, max);
        }

        public static int GetRandomInt(int min, int max)
        {
            return random.Next(min, max);
        }

        public static void GetAllFiles(string rootDirectory, ref List<string> files)
        {
            GetAllFilesInDirectory(rootDirectory, ref files);

            foreach (string directory in Directory.GetDirectories(rootDirectory))
            {
                GetAllFiles(directory, ref files);
            }
        }

        private static void GetAllFilesInDirectory(string directory, ref List<string> files)
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                files.Add(file);
            }
        }

        public static string GetPathFromDirectory(string filePath, string directoryName)
        {
            string file = filePath.Replace("\\", "/");
            string[] parts = file.Split('/');
            file = string.Empty;

            int index = parts.ToList().IndexOf(directoryName) + 1;

            for (int i = index; i < parts.Length; i++)
            {
                file += parts[i] + "/";
            }

            return file.Remove(file.Length - 5, 5);
        }
    }
}