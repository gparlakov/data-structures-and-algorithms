using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemFrames
{
    public class FramesMain
    {
        const int CombinationLength = 9;

        static SortedDictionary<string, int> combinations;
        static KeyValuePair<char, char>[] frames;
        

        static void Main()
        {
            combinations = new SortedDictionary<string, int>();
            //var separators = new char[] {' '};

            var n = int.Parse(Console.ReadLine());

            frames = new KeyValuePair<char, char>[n];
            for (int i = 0; i < n; i++)
            {
                var chars = Console.ReadLine();//.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                frames[i] = new KeyValuePair<char, char>(chars[0], chars[2]);
            }

            SolveRecursive(0, new StringBuilder(), new bool[n]);

            Console.WriteLine(combinations.Count);
            foreach (var combination in combinations)
            {
                Console.WriteLine(combination.Key);
            }
        }

        private static void SolveRecursive(int currIndex, StringBuilder stringBuilder, bool[] used)
        {
            if (currIndex == frames.Length)
            {
                stringBuilder.Length -= 3;
                var currCombination = stringBuilder.ToString();
                
                if (!combinations.ContainsKey(currCombination))
                {
                    combinations.Add(currCombination, 1);
                }
                stringBuilder.Length += 3;

                return;
            }

            for (int i = 0; i < frames.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    stringBuilder.AppendFormat("({0}, {1}) | ", frames[i].Key, frames[i].Value);
                    SolveRecursive(currIndex + 1, stringBuilder, used);
                    stringBuilder.Length -= CombinationLength;

                    if (frames[i].Key != frames[i].Value)
                    {
                        stringBuilder.AppendFormat("({0}, {1}) | ", frames[i].Value, frames[i].Key);
                        SolveRecursive(currIndex + 1, stringBuilder, used);
                        stringBuilder.Length -= CombinationLength;
                    }
                    used[i] = false;
                }                
            }
        }
    }
}
