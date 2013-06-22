using System;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

namespace BinaryTreees
{
    class BinaryTreeesMain
    {
        static void Main(string[] args)
        {
            var symbols = ReadInput();
            //Count how many trees we can build from n nodes
            var treesCountWithNNodes = CountTreesWithNNodes(symbols.Length);

            //counts how many different ways of order theese nodes(balls) have
            var variations = VariationsCounter(symbols);

            Console.WriteLine(treesCountWithNNodes * variations);
        }

        private static long CountTreesWithNNodes(int nodesCount)
        {
            if (nodesCount < 2)
            {
                return 1;
            }

            long[] treesCount = new long[nodesCount + 1];
            treesCount[0] = 1;
            treesCount[1] = 1;

            for (int i = 2; i < nodesCount + 1; i++)
            {
                long sum = 0;
                for (int j = 0; j < i; j++)
                {
                    sum += (treesCount[j] * treesCount[i - j - 1]);
                }
                treesCount[i] = sum;
            }

            return treesCount[nodesCount];
        }

        private static char[] ReadInput()
        {
            var input = Console.ReadLine();
            //var input = "YYYBBBRBB";
            //var input = "Y";
            var symbols = input.ToCharArray();
            Array.Sort(symbols);
            return symbols;
        }

        public static BigInteger VariationsCounter(char[] elements)
        {
            //calculates factorials only 1 time and used as many as needed
            var factorials = CalculateFactorials(elements.Length);
            var nFactoriel = factorials[elements.Length];

            var charsCount = CountChars(elements);
            BigInteger symbolsCountFactorielsSum = 1;
            foreach (var item in charsCount)
            {
                symbolsCountFactorielsSum *= factorials[item.Value];
            }

            return nFactoriel / symbolsCountFactorielsSum;
        }

        private static BigInteger[] CalculateFactorials(int n)
        {
            var factorials = new BigInteger[n + 1];

            if (n < 2)
            {
                for (int i = 0; i <= n; i++)
                {
                    factorials[i] = 1;
                }
            }
            else
            {
                factorials[0] = 1;
                factorials[1] = 1;

                for (int i = 2; i <= n; i++)
                {
                    factorials[i] = i * factorials[i - 1];
                }
            }

            return factorials;
        }

        private static Dictionary<char, int> CountChars(char[] elements)
        {
            var charsCount = new Dictionary<char, int>();

            for (int i = 0; i < elements.Length; i++)
            {
                var element = elements[i];
                if (charsCount.ContainsKey(element))
                {
                    charsCount[element]++;
                }
                else
                {
                    charsCount.Add(element, 1);
                }
            }

            return charsCount;
        }
    }
}
