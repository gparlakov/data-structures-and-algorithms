using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FileSystemTree
{
    public class FileSystemTreeMain
    {
        const string StartDirectory = @"c:\windows";

        static void Main()
        {
            var startFolder = new Folder(StartDirectory);
            var listener = new EventListenter(startFolder);
            BuildFolderTree(startFolder);
            var sizeInMB = CaculateFullSizeInMB(startFolder);
            Console.WriteLine("\nDone");
            Thread.Sleep(500);
            Console.WriteLine("All files in directory {0} have a total size of {1:f2} MB",StartDirectory, sizeInMB);
        }
                
        private static double CaculateFullSizeInMB(Folder startFolder)
        {
            var foldersQueue = new Queue<Folder>();
            double sizeInMB = 0;
            foldersQueue.Enqueue(startFolder);
            while (foldersQueue.Count > 0)
            {
                var nextFolder = foldersQueue.Dequeue();

                var files = nextFolder.GetFiles();
                foreach (var file in files)
                {
                    sizeInMB += (double)file.Size / 1024;
                }

                var subFolders = nextFolder.GetFolders();
                foreach (var folder in subFolders)
                {
                    foldersQueue.Enqueue(folder);
                }
            }

            return sizeInMB;
        }

        private static void BuildFolderTree(Folder startFolder)
        {
            AddFiles(startFolder);
            AddFolders(startFolder);
        }
  
        private static void AddFolders(Folder startFolder)
        {
            var directories = Directory.EnumerateDirectories(startFolder.FullPath);
            foreach (var dir in directories)
            {
                try
                {                   
                    var newFolder = new Folder(dir);
                    startFolder.AddFolder(newFolder);
                    BuildFolderTree(newFolder);
                }
                catch
                {
                }
            }
        }
  
        private static void AddFiles(Folder startFolder)
        {
            var files = Directory.EnumerateFiles(startFolder.FullPath);
            foreach (var file in files)
            {
                try
                {
                    var info = new FileInfo(file);
                    var newFile = new File(info.Name, (int)info.Length);
                    startFolder.AddFile(newFile);
                }
                catch
                {
                }
            }
        }
    }
}
