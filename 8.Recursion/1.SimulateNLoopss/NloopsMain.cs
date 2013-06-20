using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SimulateNLoopss
{
    /// <summary>
    /// Write a recursive program that simulates the 
    /// execution of n nested loops from 1 to n. Examples:
    /// </summary>
    public class NloopsMain
    {
        public static void Main()
        {
            var n = Utils.Read("n");
            StringBuilder result = new StringBuilder();
            SimulateNLoops(n, 1, "", result);

            Console.WriteLine(result);
        }

        private static void SimulateNLoops(int n, int next, string soFar, StringBuilder result)
        {
            if (next >= n)
            {
                for (int i = 1; i <= n; i++)
                {
                    result.AppendFormat("{0}{1}\n",soFar.ToString(), i);
                }
                
                return;
            }
            
            for (int i = 1; i <= n; i++)
            {                
                SimulateNLoops(n, next + 1, soFar + i + " ", result);               
            }

            return;
        }
              
    }
}
