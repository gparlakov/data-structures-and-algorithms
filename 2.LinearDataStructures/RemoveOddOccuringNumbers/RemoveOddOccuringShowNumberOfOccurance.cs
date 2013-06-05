using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace RemoveOddOccuringNumbers
{
    /// <summary>
    /// 6.Write a program that removes from given sequence all numbers that occur odd number of times. Example:
    ///<example>{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}</example>
    /// 7.Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.    ///<example>     ///array = {3, 4, 4, 2, 3, 3, 4, 3, 2}    ///2  2 times    ///3  4 times    ///4  3 times
    ///</example>
    ////// </summary>
    public class RemoveOddOccuringShowNumberOfOccurance
    {
        public static void Main(string[] args)
        {
            var list = ListGenerator.GetListIntegers(0, 10, 50);
            Console.WriteLine(Utilities.Join(list.ToArray()));
            
            var clearedList = ClearList(list);
            Console.WriteLine("\nThe list cleared of all odd occuring numbers: \n{0}\n",
                Utilities.Join(clearedList.ToArray()));

            //7. Give number of occurances of each number
            var occurenceOfNumbers = Utilities.PopulateOccurenceDictionary(list);
            var orderedOccurance = occurenceOfNumbers.OrderBy(x => x.Key);
            Console.WriteLine("Each number and its occurences:");
            Utilities.PrintDictionary(orderedOccurance);
        }

        private static List<int> ClearList(List<int> list)
        {
            var occurenceOfNumbers = Utilities.PopulateOccurenceDictionary(list);

            List<int> clearedList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                var occurencesOfCurrentNum = occurenceOfNumbers[list[i]];
                if ((occurencesOfCurrentNum % 2) == 0)
                {
                    clearedList.Add(list[i]);
                }
            }

            return clearedList;
        }
  
    }
}