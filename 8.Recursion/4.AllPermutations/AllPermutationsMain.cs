using System;
using System.Linq;
using Utilities;

namespace AllPermutations
{
    /// <summary>
    /// Write a recursive program for generating and printing all permutations of the numbers     /// 1, 2, ..., n for given integer number n. Example:	///n=3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3},					{2, 3, 1}, {3, 1, 2},{3, 2, 1}
    /// </summary>
    public class AllPermutationsMain
    {
        static void Main(string[] args)
        {
            var n = Utils.Read("n");
           
            // task 4
            GenerateAllPermutations(new int[n], 0, new bool[n]);
        }

        private static void GenerateAllPermutations(int[] elements, int currentIndex, bool[] used)
        {
            if (currentIndex == elements.Length)
            {
                Utils.WriteOnConsole(elements);

                return;
            }
                        
            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    elements[currentIndex] = i + 1;
                    used[i] = true;
                    GenerateAllPermutations(elements, currentIndex + 1, used);
                    used[i] = false;
                }                   
            }
        }        
    }
}
