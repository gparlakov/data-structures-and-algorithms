using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SimulateNLoops
{
    public class NloopsMain
    {
        public static void Main()
        {
            var n = ReadN();
            
            SimulateNLoops(n, 1, "");
        }

        private static void SimulateNLoops(int n, int next, string soFar)
        {
            if (next == n)
            {
                Console.WriteLine(soFar.ToString() + next);
                return;
            }

            soFar += next + " ";
            for (int i = 1; i <= n; i++)
            {
                SimulateNLoops(n, i, soFar); 
            }

            return;
        }

        private static int ReadN()
        {
            int n = 0;
            do
            {
                Console.WriteLine("Give me integer > 0 n: ");
                int.TryParse(Console.ReadLine(), out n);
            } while (n <= 0);

            return n;
        }
    }
}
