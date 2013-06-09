using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounter
{
    class WordsCounterMain
    {
        const string PathToFileWords = "..\\..\\TextFile\\words.txt";
        const string PathToSourceFile = "..\\..\\WordsCounterMain.cs";

        static void Main()
        {
           
            CountWordsInFile(PathToFileWords);

            Console.WriteLine("Press key for next file");
            Console.ReadLine();
            
            CountWordsInFile(PathToSourceFile);
        }
  
        private static void CountWordsInFile(string pathToFile)
        {
            string input = ReadInput(pathToFile);
            var  occurances = CountOccurances(input);
            Console.WriteLine("Words in file {0}:", pathToFile);
            PrintOutDictionary(occurances);
        }

        private static void PrintOutDictionary(IDictionary<string, int> occurances)
        {
            StringBuilder sb = new StringBuilder();
            var orderedByCount = occurances.OrderBy(x => x.Value).ThenBy(x => x.Key);
            foreach (var entry in orderedByCount)
            {
                sb.AppendFormat("{0,-20} -> {1}\n",entry.Key, entry.Value);
            }

            Console.WriteLine(sb.ToString());
        }

        private static IDictionary<string, int> CountOccurances(string input)
        {           
            var occurances = new Dictionary<string, int>();
            var regExp = new Regex("\\b[\\w]+\\b");
            var words = regExp.Matches(input);
            foreach (var word in words)
            {
                var caseInsensitiveWord = word.ToString().ToLower();
                if (occurances.ContainsKey(caseInsensitiveWord))
                {
                    occurances[caseInsensitiveWord]++;
                }
                else
                {
                    occurances.Add(caseInsensitiveWord, 1);
                }
            }

            return occurances;
        }

        private static string ReadInput(string pathToFile)
        {
            StreamReader fileReader = new StreamReader(pathToFile);
            string fileContents = null;
            using (fileReader)
            {
                fileContents = fileReader.ReadToEnd();
            }

            return fileContents;
        }
    }
}
