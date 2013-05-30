using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace RemoveNegativeFromList
{
    /// <summary>
    /// Removes from given sequence all negative numbers
    /// </summary>
    class RemoveNegativeNumbersFromList
    {
        const int Min = -2000;
        const int Max = 1000;

        static void Main()
        {
            try
            {
                var list = ListGenerator.GetListIntegers(Min, Max);
                Console.WriteLine("Original list: {0}\n", Utilities.Join(list.ToArray()));

                var cleared = ClearNegatives(list);
                Console.WriteLine("Cleared list: {0}", Utilities.Join(cleared.ToArray()));
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static List<int> ClearNegatives(List<int> list)
        {
            List<int> clearedList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] >= 0 )
                {
                    clearedList.Add(list[i]);
                }
            }

            return clearedList;
        }
    }
}
