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
            long totalLength = 0;
            for (int i = 1; i <= obeliscsDistances.Length; i++)
            {
                CalculatePermutations(obeliscsDistances, new int[i], 0, 0, ref totalLength);
            }

            Console.WriteLine(totalLength);
        }

        private static void CalculatePermutations(int[] obeliscsDistances, int[] permutation,
            int permutationIndex, int elementsIndex, ref long totalLength)
        {
            if (permutationIndex == permutation.Length)
            {
                for (int i = 0; i < permutation.Length; i++)
                {
                    totalLength += permutation[i];
                }

                return;
            }

            for (int i = elementsIndex; i < obeliscsDistances.Length; i++)
            {
                permutation[permutationIndex] = obeliscsDistances[i];
                CalculatePermutations(obeliscsDistances, permutation, permutationIndex + 1, i + 1, ref totalLength);
            }
        }

        private static int[] ReadObeliscDistances()
        {
            //var n = int.Parse(Console.ReadLine());

            //var obeliscDistances = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    Console.ReadLine();
            //    var line = Console.ReadLine().Split(' ');
            //    var x = int.Parse(line[0].Trim());
            //    var y = int.Parse(line[1].Trim());
            //    obeliscDistances[i] = Math.Abs(x) + Math.Abs(y);
            //}

            //return obeliscDistances;

            return new int[] { 1, 2, 3, 4 };
        }
    }
}