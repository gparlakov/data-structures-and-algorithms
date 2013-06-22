using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplusBToTheN
{
    public class AplusBToTheNMain
    {
        static void Main(string[] args)
        {
            //Pascal Pyramid
            var pyramyd = new long[52, 55];            

            PopulatePyramid(pyramyd);
           
           var line = Console.ReadLine();           
           var a = line[1];
           var b = line[3];
           Console.ReadLine();
           var n = int.Parse(Console.ReadLine());
           
           var builder = new StringBuilder();
           for (int i = 0; i < n + 1; i++)
           {
               if (i == 0)
               {
                   builder.AppendFormat("({0}^{1})+", a, n);
               }
               else if (i == n)
               {
                   builder.AppendFormat("({0}^{1})", b, n);
               }
               else
               {                   
                   builder.AppendFormat("{0}({1}^{2})({3}^{4})+", pyramyd[n + 1 , i], a, n - i, b, i );
               }
           
           }
           
           Console.WriteLine(builder.ToString());

           //for (int row = 1; row < pyramyd.GetLength(0); row++)
           //{
           //    for (int col = 0; col <= row; col++)
           //    {
           //        if (pyramyd[row,col] != 0)
	       //        {
           //            Console.Write(pyramyd[row, col] + " ");
	       //        }                    
           //    }
           //    Console.WriteLine();
           //}
        }

        private static void PopulatePyramid(long[,] pyramyd)
        {
            for (int row = 1; row < pyramyd.GetLength(0); row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (col == 0 || col == row - 1)
                    {
                        pyramyd[row, col] = 1;
                    }
                    else
                    {
                        pyramyd[row, col] = pyramyd[row - 1, col - 1] + pyramyd[row - 1, col];
                    }
                }
            }
        }
    }
}
