using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CombinationsWithDuplicates
{
    /// <summary>
    /// 2.Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example:	///n=3, k=2  (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
    /// 
    /// 3.Modify the previous program to skip duplicates:    ///n=4, k=2  (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
    /// </summary>
    public class CombinationsMain
    {
        static void Main()
        {
            var n = Utils.Read("n");
            var k = Utils.Read("k");       
            var elements = GetNElements(n);

            Console.WriteLine("With repetitions:");
            GetCombinationsOfKfromN(elements, 0, new int[k], 0);
            Console.WriteLine("Without repetitions:");
            GetCombinationsOfKfromNWithoutRepetitions(elements, 0, new int[k], 0);
        }        

        private static void GetCombinationsOfKfromN(int[] elements, int currentElementIndex, int[] combination, int currCombinationIndex)
        {
            if (currCombinationIndex == combination.Length)
            {
                for (int i = 0; i < combination.Length; i++)
                {
                    Console.Write(combination[i]);
                }
                Console.WriteLine();
                return;
            }

            for (int i = currentElementIndex; i < elements.Length; i++)
			{
                combination[currCombinationIndex] = elements[i];
                GetCombinationsOfKfromN(elements, i, combination, currCombinationIndex + 1);
			}            
        }

        private static void GetCombinationsOfKfromNWithoutRepetitions(int[] elements, int currentElementIndex, int[] combination, int currCombinationIndex)
        {
            if (currCombinationIndex == combination.Length)
            {
                Utils.WriteOnConsole(combination);
                return;
            }

            for (int i = currentElementIndex; i < elements.Length; i++)
            {
                combination[currCombinationIndex] = elements[i];
                GetCombinationsOfKfromNWithoutRepetitions(elements, i + 1, combination, currCombinationIndex + 1);
            }
        }  
       
        private static int[] GetNElements(int n)
        {
            var elements = new int[n];
            for (int i = 0; i < n; i++)
            {
                elements[i] = i + 1;
            }

            return elements;
        }
    }
}
