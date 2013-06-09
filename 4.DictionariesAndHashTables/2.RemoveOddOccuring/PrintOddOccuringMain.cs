using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintOddOccuring
{
    class PrintOddOccuringMain
    {
        static void Main(string[] args)
        {
            string[] input = ReadInput();
            Dictionary<string, int> occurances = CountOccuraces(input);
            PrintOddOccuring(occurances);

        }

        private static void PrintOddOccuring(Dictionary<string, int> occurances)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in occurances)
            {
                if (item.Value % 2 != 0)
                {
                    sb.AppendFormat("{0}\n", item.Key);
                }
            }
            Console.WriteLine(sb.ToString());
        }

        private static Dictionary<string, int> CountOccuraces(string[] input)
        {
            var occurances = new Dictionary<string, int>();

            foreach (var str in input)
            {
                if (occurances.ContainsKey(str))
                {
                    occurances[str]++;
                }
                else
                {
                    occurances.Add(str, 1);
                }
            }

            return occurances;
        }

        private static string[] ReadInput()
        {
            var input = new string[] {"C#", "C#", "C#","SQL", "PHP", "PHP", "SQL", "SQL"  };
            return input;
        }
    }
}
