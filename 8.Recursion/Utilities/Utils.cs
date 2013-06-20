using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Utils
    {
        public static void WriteOnConsole<T>(T[] combination)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < combination.Length; i++)
            {
                sb.Append(combination[i]);
            }
            Console.WriteLine(sb.ToString());
            return;
        }

        public static int Read(string variableName)
        {
            int n = 0;
            do
            {
                Console.WriteLine("Give me integer > 0 {0}: ", variableName);
                int.TryParse(Console.ReadLine(), out n);
            } while (n <= 0);

            return n;
        }
    }
}
