using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace RemoveOddOccuringNumbers
{
    /// <summary>
    /// Write a program that removes from given sequence all numbers that occur odd number of times. Example:
    ///<example>{4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2}  {5, 3, 3, 5}</example>
    /// </summary>
    public class RemoveOddOccuring
    {
        static void Main(string[] args)
        {
            var list = ListGenerator.GetListIntegers(0, 10, 50);
            Console.WriteLine(Utilities.Join(list.ToArray()));

            var clearedList = ClearList(list);
            Console.WriteLine(Utilities.Join(clearedList.ToArray()));
        }

        private static List<int> ClearList(List<int> list)
        {
            var occurenceOfNumbers = PopulateOccurenceDictionary(list);

            List<int> clearedList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                var occurencesOfCurrentNum = occurenceOfNumbers[list[i]];
                if ((occurencesOfCurrentNum % 2) != 0)
                {
                    clearedList.Add(list[i]);
                }
            }

            return clearedList;
        }
  
        /// <summary>
        /// Populates a dictionary with key the number and value the number of its occurences
        /// </summary>
        /// <param name="list">The list from whence to get the numbers</param>
        /// <returns>Dictionary number -> occurances</returns>
        /// <example>In list 1,2,3,2,1,5,6,5 -> 1 - 2 times; 2 - 2 times; 3 - 1; 5 - 2; 6 - 1;</example>
        private static Dictionary<int, int> PopulateOccurenceDictionary(List<int> list)
        {
            Dictionary<int, int> occurenceOfNumbers = new Dictionary<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (occurenceOfNumbers.ContainsKey(list[i]))
                {
                    occurenceOfNumbers[list[i]]++;
                }
                else
                {
                    occurenceOfNumbers.Add(list[i], 1);
                }
            }

            return occurenceOfNumbers;
        }
    }
}