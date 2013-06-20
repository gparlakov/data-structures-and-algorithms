using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities;

namespace AllSubsetsK
{
    ///Write a program for generating and printing all subsets of k strings from given set of strings.	///Example: s = {test, rock, fun}, k=2	///(test rock),  (test fun),  (rock fun)
    public class AllSubsetsKMain
    {
        static void Main()
        {
            var strings = new string[]{ "test", "rock", "fun", "gum", "bubble", "ninja" };
            var k = Utils.Read(string.Format("K less than {0}", strings.Length));
            if (k > strings.Length)
            {
                Console.WriteLine("Too hight k - cant be more than {0}", strings.Length);
            }
            else
            {
                GenerateSubsets(strings, new string[k], 0, 0);

            }
        }

        private static void GenerateSubsets(string[] strings, string[] subset, int nextElementIndex , int nextSubsetIndex)
        {
            if (nextSubsetIndex == subset.Length)
            {
                Utilities.Utils.WriteOnConsole<string>(subset);
                return;
            }

            for (int i = nextElementIndex; i < strings.Length; i++)
            {
                subset[nextSubsetIndex] = strings[i] + " ";
                GenerateSubsets(strings, subset, i + 1, nextSubsetIndex + 1);
            }
        }
    }
}
