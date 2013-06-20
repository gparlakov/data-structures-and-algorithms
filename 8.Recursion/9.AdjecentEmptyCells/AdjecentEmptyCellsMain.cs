using System;
using System.Collections.Generic;
using System.Linq;

namespace AdjecentEmptyCells
{
    public class AdjecentEmptyCellsMain
    {
        const char EmptyCellSymbol = '0';
        const char MaxAreaSymbol = ' ';
        const char WallSymbol = 'x';

        static void Main()
        {
            var matrix = ReadMatrix();
            var mark = 'A';

            PrintMatrix(matrix);
            Console.WriteLine();

            
            mark = MarkAllAdjcentEmpty(matrix, mark);

            //task 10
            Console.WriteLine("Adjacent empty cells areas marked with A, B, C.....");
            PrintMatrix(matrix);
            Console.WriteLine();
            
            //task 9
            Console.WriteLine("Largest area marked in dark cyan");
            FindLargestArea(matrix);
            PrintMatrix(matrix);
        }

        private static void FindLargestArea(char[,] matrix)
        {
            var areas = FindAreas(matrix);

            areas = areas.OrderBy(x=>x.Value).ToDictionary(x=>x.Key, x=>x.Value);

            var maxAreaSymbol = areas.Last().Key;

            MarkLargestArea(matrix, maxAreaSymbol);
        }
  
        private static void MarkLargestArea(char[,] matrix, char maxAreaSymbol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == maxAreaSymbol)
                    {
                        matrix[row, col] = MaxAreaSymbol;
                    }
                }
            }
        }
  
        private static Dictionary<char, int> FindAreas(char[,] matrix)
        {
            var areas = new Dictionary<char, int>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var symbol = matrix[row, col];
                    if (symbol != WallSymbol)
                    {
                        if (areas.ContainsKey(symbol))
                        {
                            areas[symbol]++;
                        }
                        else
                        {
                            areas.Add(symbol, 1);
                        }
                    }                    
                }
            }

            return areas;
        }
  
        private static char MarkAllAdjcentEmpty(char[,] matrix, char mark)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == EmptyCellSymbol)
                    {
                        MarkAdjacentEmpty(row, col, matrix, mark);
                        mark = (char)(mark + 1);
                    }
                }
            }

            return mark;
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == MaxAreaSymbol)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    Console.Write("{0,3} ", matrix[row, col]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }            
        }

        private static void MarkAdjacentEmpty(int row, int col, char[,] matrix, char mark)
        {
            if (matrix[row, col] == 'x' || matrix[row, col] == mark)
            {                
                return;
            }

            matrix[row, col] = mark;

            // up
            if (Check(row - 1, col, matrix))
            {
                MarkAdjacentEmpty(row - 1, col, matrix, mark);                
            }

            // down
            if (Check(row + 1, col, matrix))
            {
                MarkAdjacentEmpty(row + 1, col, matrix, mark);                        
            }

            // left
            if (Check(row, col - 1, matrix))
            {
                MarkAdjacentEmpty(row, col - 1, matrix, mark);                
            }

            //right
            if (Check(row, col + 1, matrix))
            {
                MarkAdjacentEmpty(row, col + 1, matrix, mark);               
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

        //x == wall
        private static char[,] ReadMatrix()
        {
            return new char[,]
            {
               {'0', '0', '0', 'x', '0', 'x' },
               {'0', 'x', '0', 'x', '0', 'x' },
               {'0', '0', 'x', '0', 'x', '0' },
               {'0', 'x', '0', 'x', '0', '0' },
               {'0', '0', '0', 'x', 'x', '0' },
               {'0', '0', '0', 'x', '0', 'x' }
            };
        }
    }
}
