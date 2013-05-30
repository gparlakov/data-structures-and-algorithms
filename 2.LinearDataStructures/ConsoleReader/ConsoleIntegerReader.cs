using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class ConsoleIntegerReader
    {
        public List<int> ReadIntegers()
        {
            Console.WriteLine("Next integer (leave empty for end): ");
            int num;
            string line = Console.ReadLine();
            List<int> integers = new List<int>();

            while(!string.IsNullOrWhiteSpace(line))
            {
                if (int.TryParse(line, out num) && num > 0)
                {
                    integers.Add(num);
                }
                else
                {
                    Console.WriteLine("Only positive integers allowed!");
                }

                Console.WriteLine("Next integer (leave empty for end): ");
                line = Console.ReadLine();
            }

            return integers;
        }
    }
}
