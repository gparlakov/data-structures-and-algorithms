using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSequence
{
    class Program
    {
        static int[,] matrix;
        static string str1;
        static string str2;

        static void Main()
        {
            //str2 = "GCCCTAGCG";
            //str1 = "GCGCAATG";
            str2 = "pisatel";
            str1 = "kosmonavt";

            // empty matrix where row 0 and column 0 represent the problem with one empty string - no common exist
            matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    if (str1[i - 1] == str2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = Math.Max(matrix[i - 1, j], matrix[i, j - 1]);
                    }
                }
            }

            PrintLCS(str1.Length, str2.Length);
            Console.WriteLine();
        }

        static void PrintLCS(int row, int col)
        {
            if (row < 1 || col < 1)
            {
                return;
            }

            if (str1[row - 1] == str2[col - 1])
            {
                PrintLCS(row - 1, col - 1);
                Console.Write(str1[row-1]);
            }
            else if (matrix[row - 1, col] == matrix[row, col])
            {
                PrintLCS(row - 1, col);
            }
            else
            {
                PrintLCS(row, col - 1);
            }
        }
    }
}
