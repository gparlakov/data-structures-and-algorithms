using System;
using Utils;

namespace LongestSubsequence
{
    /// <summary>
    /// Write a method that finds the longest subsequence of 
    /// equal numbers in given List<int> and returns the result 
    /// as new List<int>. Write a program to test whether the method
    /// works correctly.
    /// </summary>
    class LongestSubsequenceMain
    {
        const int Min = 1;
        const int Max = 3;

        private static void Main(string[] args)
        {
            var list = ListGenerator.GetListIntegers(Min, Max); 
            var longestSubsequence = Utilities.GetLongestSubsequenceOfRepeating(list);

            var listJoined = Utilities.Join(list.ToArray());
            Console.WriteLine("Original Sequence : {0}\nLongest subsequence of repeating:\n",listJoined);

            var longesJoined = Utilities.Join(longestSubsequence.ToArray());
            Console.WriteLine(longesJoined);
        }
    }
}