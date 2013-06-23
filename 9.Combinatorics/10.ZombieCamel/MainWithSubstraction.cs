using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZombieCamel
{
    public class ZombieCamelMain
    {
        static void Main()
        {
            var obeliscsDistances = ReadObeliscDistances();
            long lengthOfAllObeliscs = Total(obeliscsDistances);
            long totalLength = lengthOfAllObeliscs;
            CalculatePermutations(obeliscsDistances, 0, lengthOfAllObeliscs, ref totalLength);

            Console.WriteLine(totalLength);
        }

        // We know the sum of all elements - on each level of recursion 
        // we extract one of the elements from it
        //thus recieving one combinations' sum
        private static void CalculatePermutations(int[] elements, int indexOfMain,
            long totalForThisLevel, ref long totalLenght)
        {

            for (int i = indexOfMain; i < elements.Length; i++)
            {
                long newTotal = totalForThisLevel - elements[i];
                totalLenght += newTotal;
                CalculatePermutations(elements, i + 1, newTotal, ref totalLenght);
            }
        }

        private static long Total(int[] obeliscsDistances)
        {
            var totalSum = 0L;
            for (int i = 0; i < obeliscsDistances.Length; i++)
            {
                totalSum += obeliscsDistances[i];
            }

            return totalSum;
        }

        private static int[] ReadObeliscDistances()
        {
            var n = int.Parse(Console.ReadLine());

            var obeliscDistances = new int[n];
            var linesOfInput = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                Console.ReadLine();
                linesOfInput.AppendLine(Console.ReadLine());
            }

            var allInputNumbers = linesOfInput.ToString().Split(
                new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < allInputNumbers.Length; i += 2)
            {
                var x = int.Parse(allInputNumbers[i].Trim());
                var y = int.Parse(allInputNumbers[i + 1].Trim());

                obeliscDistances[i / 2] = Math.Abs(x) + Math.Abs(y);
            }
            

            return obeliscDistances;

            //return new int[] { 1, 2, 3 };
        }
    }
}