using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _11.PermutationsWithRepetition
{
    // <summary>
    /// * Write a program to generate all permutations with 
    /// repetitions of given multi-set. For example the multi-set
    /// {1, 3, 5, 5}
    /// </summary>    
    public class AllPermutationsMain
    {
        static void Main(string[] args)
        {
            var elements = new int[] { 1, 5, 5, 5, 5, 5 };//, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            var n = elements.Length;
            var allPermutationsWithRepetition = new HashSet<string>();
            GenerateAllPermutationsWithRepetitions(elements, new int[n], 
                0, new bool[n], allPermutationsWithRepetition);

            foreach (var item in allPermutationsWithRepetition)
            {
                Console.WriteLine(item);
            }
        }

        private static void GenerateAllPermutationsWithRepetitions(int[] elements, int[] permutation,int currentIndex,
            bool[] used, HashSet<string> allPermutations)
        {
            if (currentIndex == permutation.Length)
            {
                PutInDictionary(permutation, allPermutations);
                //Utils.WriteOnConsole<int>(permutation);
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    permutation[currentIndex] = elements[i];
                    used[i] = true;
                    GenerateAllPermutationsWithRepetitions(elements, permutation,currentIndex + 1, 
                        used, allPermutations);
                    used[i] = false;
                }
            }
        }

        private static void PutInDictionary(int[] permutation, HashSet<string> allPermutations)
        {
            var result = new StringBuilder();

            for (int i = 0; i < permutation.Length; i++)
            {
                result.Append(permutation[i] + " ");
            }
            
            if (!allPermutations.Contains(result.ToString()))
            {
                allPermutations.Add(result.ToString());
            }
        }

    }
}
