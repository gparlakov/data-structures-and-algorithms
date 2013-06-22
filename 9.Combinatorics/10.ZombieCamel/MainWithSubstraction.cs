//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ZombieCamel
//{
//    public class ZombieCamelMain
//    {

//        static void Main()
//        {
//            var obeliscsDistances = ReadObeliscDistances();
//            long lengthOfAllObeliscs = Total(obeliscsDistances);
//            long totalLength = 0;
//            CalculatePermutations(obeliscsDistances, new bool[obeliscsDistances.Length],
//                lengthOfAllObeliscs, ref totalLength);

//            Console.WriteLine(totalLength);
//        }

//        // We know the sum of all elements - on each level of recursion 
//        // we extract one of the elements 
//        // from it thus recieving one permutation's sum
//        private static void CalculatePermutations(int[] elements, bool[] used,
//            long totalForThisLevel, ref long totalLenght)
//        {
//            for (int i = 0; i < elements.Length; i++)
//            {
//                if (!used[i])
//                {
//                    used[i] = true;
//                    long newTotal = totalForThisLevel - elements[i];
//                    totalLenght += newTotal;
//                    CalculatePermutations(elements, used, newTotal, ref totalLenght);
//                    used[i] = false;
//                }
//            }
//        }

//        private static long Total(int[] obeliscsDistances)
//        {
//            var totalSum = 0L;
//            for (int i = 0; i < obeliscsDistances.Length; i++)
//            {
//                totalSum += obeliscsDistances[i];
//            }

//            return totalSum;
//        }

//        private static int[] ReadObeliscDistances()
//        {
//            //var n = int.Parse(Console.ReadLine());

//            //var obeliscDistances = new int[n];
//            //for (int i = 0; i < n; i++)
//            //{
//            //    Console.ReadLine();
//            //    var line = Console.ReadLine().Split(' ');
//            //    var x = int.Parse(line[0].Trim());
//            //    var y = int.Parse(line[1].Trim());
//            //    obeliscDistances[i] = Math.Abs(x) + Math.Abs(y);
//            //}

//            //return obeliscDistances;

//            return new int[] { 1, 2, 3, 4 };
//        }
//    }
//}