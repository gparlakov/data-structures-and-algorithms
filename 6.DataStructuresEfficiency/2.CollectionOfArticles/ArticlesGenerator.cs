using System;
using Wintellect.PowerCollections;

namespace CollectionOfProducts
{
    public static class ArticlesGenerator
    {
        private static Random rand;

        static ArticlesGenerator()
        {
            rand = new Random();
        }

        public static OrderedMultiDictionary<int, Article> GenerateRandomArticles(
            int count, string[] articleNames, int minPrice, int maxPrice)
        {
            var products = new OrderedMultiDictionary<int, Article>(true, (x,y) => x - y, (x,y)=> x.Title.CompareTo(y.Title));
            var maxProductNum = articleNames.Length;

            for (int i = 0; i < count; i++)
            {
                var price = rand.Next(minPrice, maxPrice);
                var article = articleNames[rand.Next(maxProductNum)];

                products.Add(price, new Article("123456789", "ACME", article, price));
            }

            return products;
        }
    }
}
