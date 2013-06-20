using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace OrderedKSubsetOfStrings
{
    /// <summary>
    /// Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).	/// Example: n=3, k=2, set = {hi, a, b} =>	/// (hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
    /// </summary>
    class OrderedKSubsetOfStringsMain
    {
        static void Main(string[] args)
        {
            var strings = new string[] { "hi", "a", "b","t", "bye", "var" };
            var k = Utils.Read(string.Format("k - subset lenghth < {0}", strings.Length));
            var orderedSubset = new string[k];
            if (k >= strings.Length)
            {
                Console.WriteLine("Too high value of k");
            }
            else
            {
                GenerateAllOrderedSubsets(strings, orderedSubset, new bool[strings.Length], 0);
            }
        }

        private static void GenerateAllOrderedSubsets(string[] strings, string[] orderedSubset, bool[] used, int nextCombinationIndex)
        {
            if (nextCombinationIndex == orderedSubset.Length)
            {
                Utils.WriteOnConsole<string>(orderedSubset);
                return;
            }

            for (int i = 0; i < strings.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    orderedSubset[nextCombinationIndex] = strings[i] + " ";
                    GenerateAllOrderedSubsets(strings, orderedSubset, used, nextCombinationIndex + 1);
                    used[i] = false;
                }
            }
        }
    }
}
