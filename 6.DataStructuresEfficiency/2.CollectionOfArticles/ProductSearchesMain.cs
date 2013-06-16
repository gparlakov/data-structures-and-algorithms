using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Wintellect.PowerCollections;


namespace CollectionOfProducts
{
    /// <summary>
    /// A large trade company has millions of articles, each 
    /// described by barcode, vendor, title and price. Implement a
    /// data structure to store them that allows fast retrieval of all 
    /// articles in given price range [x…y]
    /// </summary>
    class ProductSearchesMain
    {
        const string ProductsFile = "..\\..\\articles.txt";
        const int RandomProductsCount = 1510000;
        const int MinPrice = 10;
        const int MaxPrice = 100000000;
        const int NumberSearches = 100000;

        static void Main(string[] args)
        {
            //read articles names from a txt file
            var productNames = ReadProducts(ProductsFile);

            Console.WriteLine("Generating {0} products\n", RandomProductsCount);
            var products = ArticlesGenerator.GenerateRandomArticles(
                RandomProductsCount, productNames, MinPrice, MaxPrice);            
            Console.WriteLine("Generated {0} products!\n", products.Count);

            Console.WriteLine("Starting searches {0} by given range!\n", NumberSearches);
            var timeForSearches = TestSearches(products, NumberSearches);

            
            Console.WriteLine("Time for {0} searches by given random interval [a..b] in {1} records : {2} milliseconds\n",
                NumberSearches, products.Count, timeForSearches.Milliseconds);

            Console.WriteLine("\nThis is only time statistics - if you want to be sure I search and find results - F5 breakpoint line 36 and see each result..");
        }

        /// <summary>
        /// I only return the time elapesed for the searches - for each result - F5...
        /// </summary>
        /// <param name="products"></param>
        /// <param name="countSearches"></param>
        /// <returns></returns>
        private static TimeSpan TestSearches(
            Wintellect.PowerCollections.OrderedMultiDictionary<int, Article> products,
            int countSearches)
        {
            var ranges = GenerateSearchRanges(countSearches);
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Reset();            
            stopwatch.Start();
            for (int i = 0; i < countSearches; i++)
            {
                var searchResult = products.Range(ranges[i].Key, true, ranges[i].Value, true);              
            }
            stopwatch.Stop();

            return stopwatch.Elapsed;
        }

        //generates search ranges separately so it doesn't affect the timing
        private static KeyValuePair<int, int>[] GenerateSearchRanges(int countSearches)
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
