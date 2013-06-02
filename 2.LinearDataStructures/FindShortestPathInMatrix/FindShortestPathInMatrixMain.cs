using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShortestPathInMatrix
{
    public class FindShortestPathInMatrixMain
    {
        public static void Main(string[] args)
        {
            var matrix = InputMatrix();

            var matrixWalker = new MatrixWalker(matrix);
            matrixWalker.MarkShortestPath();
            Console.WriteLine(matrixWalker.GetMatrixAsString());
        }
        
        private static string[,] InputMatrix()
        {
            var matrix = new string[,]{
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"}                
            };

            return matrix;
        }
    }
}
