using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LocalWebPConverter.ConsoleApplication
{
    class Program
    {
        static FileSystemWatcher _fileSystemWatcher;
        static readonly int _imageQualityPercentage = 80;
        static readonly string _watchFolderPath = @"c:\temp\webp\input\";

        static void Main()
        {
            _fileSystemWatcher = new FileSystemWatcher(_watchFolderPath);
            _fileSystemWatcher.Created += FileSystemWatcher_Created;
            _fileSystemWatcher.EnableRaisingEvents = true;

            Console.ReadLine();
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            string fileExtension = new FileInfo(e.FullPath).Extension;

            if (!Regex.IsMatch(fileExtension, @"\.png|\.jpg|\.jpeg", RegexOptions.IgnoreCase))
                return;

            Console.WriteLine($"New file detected {e.FullPath}");

            WebPConverter.ConvertToWebP(
                e.FullPath,
                e.FullPath.Replace(fileExtension, ".webp"),
                _imageQualityPercentage);
        }        
    }
}
