using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecursiveMatrixPathFinding
{
    /// <summary>
    /// 7. We are given a matrix of passable and non-passable cells. Write a
    /// recursive program for finding all paths between two cells in the matrix.
    /// </summary>
    class PathFindingMain
    {
        static List<int[,]> AllPaths = new List<int[,]>();

        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);            
            
            for (int row = 0; row < cols; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != 'x')
                    {
                        FindPathsInMatrix(new Cell(row, col), matrix,
                            new int[rows, cols], new bool[rows, cols], 0);         
                    }
                       
                }
            }

            Console.WriteLine("All paths in this matrix are {0}",
                AllPaths.Count);
            Console.WriteLine("How many to printout?");

            int count = 0;
            int.TryParse(Console.ReadLine(), out count);
            
            for (int i = 0; i < count && i < AllPaths.Count; i++)
            {
                PrintPath(AllPaths[i], matrix);
                Console.WriteLine();
            }
        }

        private static void FindPathsInMatrix(Cell startPostion, char[,] matrix, 
            int[,] steps, bool[,] visited, int stepsCounter)
        {
            //if none of the directions are passable 
            //the bottom will remain true and the path will be saved
            bool bottom = true;
            var row = startPostion.Row;
            var col = startPostion.Col;            


            visited[row, col] = true;
            steps[row, col] = stepsCounter + 1;

            // up
            if (Check(row - 1, col, matrix) && matrix[row - 1, col] != 'x' && !visited[row - 1, col])
            {
                FindPathsInMatrix(new Cell(row - 1, col), matrix, steps, visited, stepsCounter + 1);
                bottom = false;
            }

            // down
            if (Check(row + 1, col, matrix) && matrix[row + 1, col] != 'x' && !visited[row + 1, col])
            {
                FindPathsInMatrix(new Cell(row + 1, col), matrix, steps, visited, stepsCounter + 1);
                bottom = false;
            }

            // left
            if (Check(row, col - 1, matrix) && matrix[row, col - 1] != 'x' && !visited[row, col - 1])
            {
                FindPathsInMatrix(new Cell(row, col - 1), matrix, steps, visited, stepsCounter + 1);
                bottom = false;
            }

            //right
            if (Check(row, col + 1, matrix) && matrix[row, col + 1] != 'x' && !visited[row, col + 1])
            {
                FindPathsInMatrix(new Cell(row, col + 1), matrix, steps, visited, stepsCounter + 1);
                bottom = false;
            }
            
            // none of the four directions are passable
            if (bottom)
            {
                SaveCurrentPath(steps);                
            }

            visited[row, col] = false;
            steps[row, col] = 0;
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
  
        private static void SaveCurrentPath(int[,] steps)
        {
            var rows = steps.GetLength(0);
            var cols = steps.GetLength(1);
            var currentpath = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    currentpath[i, j] = steps[i, j];
                }
            }

            AllPaths.Add(currentpath);
        }

        private static char[,] ReadMatrix()
        {
            return new char[,]
            {
               {'0', '0', '0', 'x', '0', 'x' },
               {'0', 'x', '0', 'x', '0', 'x' },
               {'0', '0', 'x', '0', 'x', '0' },
               {'0', 'x', '0', '0', '0', '0' },
               {'0', '0', '0', 'x', 'x', '0' },
               {'0', '0', '0', 'x', '0', 'x' }
            };
        }

        private static void PrintPath(int[,] pathWithStepsCount, char[,] map )
        {
            for (int row = 0; row < pathWithStepsCount.GetLength(0); row++)
            {
                for (int col = 0; col < pathWithStepsCount.GetLength(1); col++)
                {
                    if (pathWithStepsCount[row, col] > 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write("{0,3} ", pathWithStepsCount[row, col]);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("{0,3} ", map[row, col]);
                    }
                    
                }
                Console.WriteLine();
            }

        }
    }
}
