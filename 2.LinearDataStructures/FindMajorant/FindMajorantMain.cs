using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace FindMajorant
{
    /// <summary>
    /// The majorant of an array of size N is a value that occurs in it at least N/2
    /// + 1 times. Write a program to find the majorant of given array (if exists).
    ///<example>{2, 2, 3, 3, 2, 3, 4, 3, 3}  3</example>
    /// </summary>
    public class FindMajorantMain
    {
        const int MinNumber = 0;
        const int MaxNumber = 3;
        const int CountToGenerate = 100;


        public static void Main(string[] args)
        {
            var listWithMajorant = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            //var list = ListGenerator.GetListIntegers(MinNumber, MaxNumber, CountToGenerate);

            var occuranceOfNumbers = Utilities.PopulateOccurenceDictionary(listWithMajorant);

            var majorants = GetMajorants(occuranceOfNumbers, listWithMajorant.Count);

            if (majorants == null || majorants.Count == 0)
            {
                Console.WriteLine("No majorants in this list");
            }
            else
            {
                var majorantsString = Utilities.Join(majorants.ToArray());
                Console.WriteLine("Majorants: {0}", majorantsString);
            }
        }

        private static List<int> GetMajorants(
            Dictionary<int, int> occuranceOfNumbers, int lengthOfList)
        {
            List<int> majorants = new List<int>();
            var majorantLimitCount = ((double)lengthOfList / 2) + 1;
            foreach (var item in occuranceOfNumbers)
            {
                if (item.Value >= majorantLimitCount)
                {
                    majorants.Add(item.Key);
                }
            }

            return majorants;
        }

    }
}