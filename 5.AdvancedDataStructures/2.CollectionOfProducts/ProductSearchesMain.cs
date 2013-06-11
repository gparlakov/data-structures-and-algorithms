using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CollectionOfProducts
{
    class ProductSearchesMain
    {
        const string ProductsFile = "..\\..\\products.txt";
        const int RandomProductsCount = 510000;
        const int MinPrice = 10;
        const int MaxPrice = 100000000;
        const int NumberSearches = 100000;

        static void Main(string[] args)
        {
            //read product names from a txt file
            var productNames = ReadProducts(ProductsFile);

            Console.WriteLine("Generating {0} products\n", RandomProductsCount);
            var products = ProductsGenerator.GenerateRandomPrducts(
                RandomProductsCount, productNames, MinPrice, MaxPrice);            
            Console.WriteLine("Generated {0} products!\n", products.Count);

            Console.WriteLine("Starting searches 10000 by given range!\n");
            var timeForSearches = TestSearches(products, NumberSearches);

            
            Console.WriteLine("Time for {0} searches by given random interval [a..b] in {1} records : {2} milliseconds\n",
                NumberSearches, products.Count, timeForSearches.Milliseconds);
        }

        private static TimeSpan TestSearches(
            Wintellect.PowerCollections.OrderedMultiDictionary<int, string> products, 
            int countSearches)
        {
            var ranges = GenerateSearchRange(countSearches);
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();            
            stopwatch.Start();
            for (int i = 0; i < countSearches; i++)
            {
                var firstTwenty = products.Range(ranges[i].Key, true, ranges[i].Value, true).Take(20);
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //generates saerch ranges separately so it doesn't affect the timing
        private static KeyValuePair<int, int>[] GenerateSearchRange(int countSearches)
        {
            Random rand = new Random();
            var ranges = new KeyValuePair<int, int>[countSearches];
            for (int i = 0; i < countSearches; i++)
            {
                var smaller = rand.Next(MinPrice, MaxPrice);
                var bigger = rand.Next(MinPrice, MaxPrice);
                if (bigger < smaller)
                {
                    var buff = bigger;
                    bigger = smaller;
                    smaller = buff;
                }
                ranges[i] = new KeyValuePair<int, int>(smaller, bigger);
            }

            return ranges;
        }

        private static string[] ReadProducts(string file)
        {
            StreamReader fileReader = new StreamReader(file);
            string content;
            using (fileReader)
            {
                content = fileReader.ReadToEnd();
            }

            var lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return lines;
        }
    }
}
