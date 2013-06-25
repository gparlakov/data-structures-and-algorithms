//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Buisnessmen
//{
//    class Program
//    {
//        static int counter;

//        static void Main()
//        {

//            var sums = new StringBuilder();
//            for (int i = 2; i < 50; i += 2)
//            {
//                counter = 0;
//                var used = new HashSet<int>();
//                var businessMen = new int[i];
//                Recursive(used, businessMen);
//                sums.Append(counter + " ");
//            }
//            //var businessMen = new int[int.Parse(Console.ReadLine())];

//            //var start = DateTime.Now;
//            //Recursive(used, businessMen);
//            //Console.WriteLine("Time : {0}", (DateTime.Now - start).Milliseconds);
//            //Console.WriteLine(counter);
//            StreamWriter writer = new StreamWriter("..\\..\\results.txt");
//            writer.Write(sums.ToString());
//        }

//        private static void Recursive(HashSet<int> used, int[] businessMen)
//        {
//            if (used.Count == businessMen.Length)
//            {
//                counter++;
//                return;
//            }

//            var currIndex = FindCurrIndex(used, businessMen.Length);
//            used.Add(currIndex);

//            for (int j = currIndex + 1; j < businessMen.Length; j++)
//            {
//                if (!used.Contains(j) && CanConnect(currIndex, j, used))
//                {
//                    used.Add(j);
//                    Recursive(used, businessMen);
//                    used.Remove(j);
//                }
//            }
//            if (currIndex != 0)
//            {
//                used.Remove(currIndex);
//            }

//        }

//        private static int FindCurrIndex(HashSet<int> used, int length)
//        {
//            for (int i = 0; i < length; i++)
//            {
//                if (!used.Contains(i))
//                {
//                    return i;
//                }
//            }

//            return -1;
//        }

//        private static bool CanConnect(int i, int j, HashSet<int> used)
//        {
//            bool canConnect = false;
//            if (i % 2 == 0 && j % 2 == 1 || i % 2 == 1 && j % 2 == 0)
//            {
//                bool separatedByConnection = false;
//                for (int k = i + 1; k < j; k++)
//                {
//                    if (used.Contains(k))
//                    {
//                        separatedByConnection = true;
//                        break;
//                    }
//                }

//                if (!separatedByConnection)
//                {
//                    canConnect = true;
//                }
//            }

//            return canConnect;
//        }
//    }
//}
