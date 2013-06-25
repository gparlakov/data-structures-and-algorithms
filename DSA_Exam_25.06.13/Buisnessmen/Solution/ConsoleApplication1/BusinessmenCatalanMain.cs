using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Buisnessmen
{
    public class HardcodedSolution
    {
        //const string Catalan = "1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786, 208012, 742900, 2674440, 9694845, 35357670, 129644790, 477638700, 1767263190, 6564120420, 24466267020, 91482563640, 343059613650, 1289904147324, 4861946401452, 18367353072152, 69533550916004, 263747951750360, 1002242216651368, 3814986502092304";

        static void Main()
        {
            var index = int.Parse(Console.ReadLine());
            //var solutions = Catalan.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            var factorials = CalculateFactorials(index + 1);

            
            var catalanSolution = factorials[index] / (factorials[index/2 + 1] * factorials[index/2]);
            Console.WriteLine(catalanSolution);
        }

        private static BigInteger[] CalculateFactorials(int p)
        {
            var factorials = new BigInteger[p];
            factorials[0] = 1;
            factorials[1] = 1;
            for (int i = 2; i < factorials.Length; i++)
            {
                factorials[i] = i * factorials[i - 1];
            }

            return factorials;
        }
    }
}