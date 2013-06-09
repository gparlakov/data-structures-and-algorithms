using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionariesAndHashTables
{
    public class CountOccurancesMain
    {
        static void Main()
        {
            var input = GetInput();
            Dictionary<double, int> occurences = CountOccurances(input);
            PrintOccurances(occurences);
        }

        private static void PrintOccurances(Dictionary<double, int> occurences)
        {
            var occurancesOrdered = occurences.OrderBy(x => x.Key);
            StringBuilder sb = new StringBuilder();
            foreach (var occurance in occurancesOrdered)
            {
                sb.AppendFormat("{0} -> {1}",occurance.Key, occurance.Value);
            }

            Console.WriteLine(sb.ToString());
        }

        private static Dictionary<double, int> CountOccurances(double[] input)
        {
            var occurances = new Dictionary<double, int>();

            foreach (var item in input)
            {
                if (occurances.ContainsKey(item))
                {
                    occurances[item]++;
                }
                else
                {
                    occurances.Add(item, 1);
                }
            }

            return occurances;
        }

        private static double[] GetInput()
        {
            var input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5, 7, 55, 3, 7, -4};
            return input;
        }
    }
}
