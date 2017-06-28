using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Essential.IO
{
    public class File
    {        
        public static IEnumerable<string> ReadContentLines(string path)
        {
            return System.IO.File.ReadLines(path).Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Trim());
        }

        public static void CopyFileToSubfolders(string fileName, string rootFolder, SearchOption searchOption = SearchOption.TopDirectoryOnly, Action<int, int> Progress = null)
        {
            var directories = new DirectoryInfo(rootFolder).EnumerateDirectories("*", searchOption);

            var total = directories.Count();
            var current = 0;
            foreach (var dir in directories)
            {
                System.IO.File.Copy(fileName, dir.FullName + "/" + Path.GetFileName(fileName));
                Progress?.Invoke(++current, total);
            }
        }
    }
}
