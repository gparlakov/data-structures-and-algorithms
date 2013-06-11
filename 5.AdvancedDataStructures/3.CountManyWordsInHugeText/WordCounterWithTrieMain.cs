using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CountManyWordsInHugeText
{
    public class WordCounterWithTrieMain
    {
        //I didn't include a very large file so put your file location here
        const string LargeFile = "..\\..\\LargeTextFile.txt";
        const string WordsFile = "..\\..\\Words.txt";

        static void Main()
        {
            //to make the file really big ~ 70 000kb now is ~700kb
            //MultiplyFileHundredTimes(LargeFile);
            //build trie from the LargeFile
            var trie = BuildTrie();           

            //gets the words from the WordsFile
            var words = GetWords();

            //counts how many times each word is found in the original text (LargeFile)
            SortedDictionary<string, int> wordsAndOccurances = new SortedDictionary<string, int>();
            foreach (var word in words)
            {
                int occurances = 0;
                trie.ContainsWord(word, out occurances);
                if (!wordsAndOccurances.ContainsKey(word))
                {
                    wordsAndOccurances.Add(word, occurances);
                }                
            }

            Console.WriteLine(wordsAndOccurances.Count);

            PrintWordOccurances(wordsAndOccurances);
        }
  
        /// <summary>
        /// Currently prints in Ascending order by count of occurances
        /// </summary>
        /// <param name="wordsAndOccurances"></param>
        private static void PrintWordOccurances(SortedDictionary<string, int> wordsAndOccurances)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in wordsAndOccurances.OrderBy(x => x.Value))
            {
                sb.AppendFormat("{0} -> {1}\n", item.Key, item.Value);
            }

            Console.WriteLine(sb.ToString());
        }
  
        private static string[] GetWords()
        {
            var wordsText = ReadFile(WordsFile);
            var words = wordsText.Split(TrieNode.Separators, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
  
        private static Trie BuildTrie()
        {
            var trie = new Trie();
            //var text = "alpha alpine!,!!!...alp red bull Racing Alpha alpha alpine!,!!!...alp";
            var text = ReadFile(LargeFile);
            trie.BuildTrie(text);

            return trie;
        }

        private static string ReadFile(string fileLocation)
        {
            var reader = new StreamReader(fileLocation);
            string content;
            using (reader)
            {
                content = reader.ReadToEnd();
            }

            return content;
        }

        private static void MultiplyFileHundredTimes(string fileloc)
        {
            var reader = new StreamReader(fileloc);
            string content = null;
            using (reader)
            {
                content = reader.ReadToEnd();
            }

            var writer = new StreamWriter(fileloc);
            using (writer)
            {
                for (int i = 0; i < 100; i++)
                {
                    writer.Write(content);
                }
            }
        }
    }
}
