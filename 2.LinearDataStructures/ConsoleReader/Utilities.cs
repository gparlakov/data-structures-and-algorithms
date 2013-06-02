using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Utilities
    {
        public static int Sum(List<int> list)
        {
            ThrowExceptionIfEmptyOrNull(list);

            var sum = 0;
            foreach (var num in list)
            {
                sum += num;
            }

            return sum;
        }

        public static string Join(int[] list)
        {
            ThrowExceptionIfEmptyOrNull(list);
           
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < list.Length - 1; i++)
            {
                result.AppendFormat("{0}, ", list[i]);
            }

            result.Append(list[list.Length - 1]);

            return result.ToString();
        }

        public static Stack<int> PutInStack(List<int> list)
        {
            ThrowExceptionIfEmptyOrNull(list);

            Stack<int> integers = new Stack<int>();

            for (int i = 0; i < list.Count; i++)
            {
                integers.Push(list[i]);
            }

            return integers;
        }

        public static List<int> GetLongestSubsequenceOfRepeating(List<int> list)
        {
            ThrowExceptionIfEmptyOrNull(list);

            var tempList = new List<int>();
            var maxList = new List<int>();
            var baseElem = list[0];
            tempList.Add(baseElem);

            for (int i = 1; i < list.Count; i++)
            {
                var nextElem = list[i];
                if (nextElem == baseElem)
                {
                    tempList.Add(nextElem);
                }

                if (nextElem != baseElem || i == list.Count - 1)
                {
                    if (tempList.Count > maxList.Count)
                    {
                        maxList = GetCopyOfList(tempList);
                    }

                    baseElem = nextElem;

                    tempList.Clear();
                    tempList.Add(baseElem);
                }
            }

            return maxList;
        }

        public static int ReadIntegerInput(string nameOfArgument)
        {
            int n;
            bool parsed = false;
            do
            {
                Console.WriteLine("Give me number {0}: (integer) : ", nameOfArgument);
                string line = Console.ReadLine();
                parsed = int.TryParse(line, out n);
            }
            while (!parsed);

            return n;
        }

        /// <summary>
        /// Populates a dictionary with key the number and value the number of its occurences
        /// </summary>
        /// <param name="list">The list from whence to get the numbers</param>
        /// <returns>Dictionary number -> occurances</returns>
        /// <example>In list 1,2,3,2,1,5,6,5 -> 1 - 2 times; 2 - 2 times; 3 - 1; 5 - 2; 6 - 1;</example>
        public static Dictionary<int, int> PopulateOccurenceDictionary(List<int> list)
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
               
        #region Printing Methods

        public static void PrintSorted(List<int> list)
        {
            ThrowExceptionIfEmptyOrNull(list);

            int[] sorted = new int[list.Count];
            list.CopyTo(sorted);
            Array.Sort(sorted);

            Console.WriteLine("Sorted:");
            Console.WriteLine(Join(sorted));
        }

        public static void PrintFromStack(Stack<int> stack)
        {
            StringBuilder result = new StringBuilder();
            do
            {
                var next = stack.Pop();
                result.AppendFormat("{0}, ", next);
            }
            while (stack.Count > 0);

            Console.WriteLine("Printed from stack (reversed order):\n{0}", result);
        }

        public static void PrintDictionary(IOrderedEnumerable<KeyValuePair<int, int>> orderedOccurance)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in orderedOccurance)
            {
                result.AppendFormat("{0} -> {1}\n", item.Key, item.Value);
            }

            Console.WriteLine(result);
        }

        #endregion

        #region Private Methods

        private static void ThrowExceptionIfEmptyOrNull(ICollection<int> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("The passed {0} is null!", list.GetType().ToString());
            }

            if (list.Count < 1)
            {
                throw new ArgumentException("The passed {0} is Empty!", list.GetType().ToString());
            }
        }

        private static List<int> GetCopyOfList(List<int> list)
        {
            var copy = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                copy.Add(list[i]);
            }

            return copy;
        }
        
        #endregion
    }
}