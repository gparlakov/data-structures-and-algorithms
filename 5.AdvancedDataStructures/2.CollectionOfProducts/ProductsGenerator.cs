using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace CollectionOfProducts
{
    public static class ProductsGenerator
    {
        private static Random rand;

        static ProductsGenerator()
        {
            rand = new Random();
        }

        public static OrderedMultiDictionary<int, string> GenerateRandomPrducts(
            int count, string[] productNames, int minPrice, int maxPrice)
        {
            var products = new OrderedMultiDictionary<int, string>(true);
            var maxProductNum = productNames.Length;

            for (int i = 0; i < count; i++)
            {
                var price = rand.Next(minPrice, maxPrice);
                var product = productNames[rand.Next(maxProductNum)];

                products.Add(price, product);
            }

            return products;
        }
    }
}
