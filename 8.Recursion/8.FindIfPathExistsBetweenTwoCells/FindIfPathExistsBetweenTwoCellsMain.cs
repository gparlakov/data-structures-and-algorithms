using RecursiveMatrixPathFinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindIfPathExistsBetweenTwoCells
{
    /// <summary>
    /// Modify the above program to check whether a path exists between 
    /// two cells without finding all possible paths. 
    /// Test it over an empty 100 x 100 matrix.
    /// </summary>
    class FindIfPathExistsBetweenTwoCellsMain
    {
        static void Main(string[] args)
        {
            var matrix = new char[100, 100];
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var startPos = new Cell(60, 26);
            var endPos = new Cell(99, 88);

            try
            {
                FindPathsInMatrix(startPos, matrix, new bool[rows, cols], endPos);
                Console.WriteLine("Not found");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }

        private static void FindPathsInMatrix(Cell startPostion, char[,] matrix, bool[,] visited, Cell endPostion)
        {      
            
            var row = startPostion.Row;
            var col = startPostion.Col;

            if (row == endPostion.Row && col == endPostion.Col)
            {
                throw new ArgumentException("Found");
            }


            visited[row, col] = true;

            // up
            if (Check(row - 1, col, matrix) && !visited[row - 1, col])
            {
                FindPathsInMatrix(new Cell(row - 1, col), matrix, visited, endPostion);               
            }

            // down
            if (Check(row + 1, col, matrix) && !visited[row + 1, col])
            {
                FindPathsInMatrix(new Cell(row + 1, col), matrix, visited, endPostion);                
            }

            // left
            if (Check(row, col - 1, matrix) && matrix[row, col - 1] != 'x' && !visited[row, col - 1])
            {
                FindPathsInMatrix(new Cell(row, col - 1), matrix, visited, endPostion);               
            }

            //right
            if (Check(row, col + 1, matrix) && !visited[row, col + 1])
            {
                FindPathsInMatrix(new Cell(row, col + 1), matrix, visited, endPostion);               
            }           
        }

        private static bool Check(int row, int col, char[,] matrix)
        {
            bool inRange = true;
            if (row < 0 || row >= matrix.GetLength(0))
            {
                inRange = false;
            }

            if (col < 0 || col >= matrix.GetLength(1))
            {
                inRange = false;
            }

            return inRange;
        }
    }
}
