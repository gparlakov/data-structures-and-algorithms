using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Text;

namespace _2.TraverseWindowsDirectory
{
    class Program
    {
        const string WindowsPath = "c:\\windows";
        const string SearchString = "*.exe";
        

        static void Main(string[] args)
        {
            var list = SearchDirectoryFor(WindowsPath, SearchString);
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("{0}\n",item);
            }
            Console.WriteLine(sb.ToString());
        }

        public static List<string> SearchDirectoryFor(string directory, string searchString)
        {
            Queue<string> directoriesToSearch = new Queue<string>();
            directoriesToSearch.Enqueue(directory);
            
            var allFilesMathingSearchedCriteria = new List<string>();
            
            while (directoriesToSearch.Count > 0)
            {
                var nextDirectory = directoriesToSearch.Dequeue();
                
                //lazy checking if directory is accessible - if not accessible throws exception and moves on...
                try
                {
                    var files = Directory.EnumerateFiles(nextDirectory, searchString);
                    allFilesMathingSearchedCriteria.AddRange(files);

                    var directories = Directory.EnumerateDirectories(nextDirectory);

                    foreach (var dir in directories)
                    {
                        directoriesToSearch.Enqueue(dir);
                    }
                }
                catch { }
            }


            return allFilesMathingSearchedCriteria;
        }
    }
}
