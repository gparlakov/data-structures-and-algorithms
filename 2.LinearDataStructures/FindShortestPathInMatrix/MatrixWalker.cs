using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShortestPathInMatrix
{
    public class MatrixWalker
    {
        const int NeighbourCellsCount = 4;
        const string UnreachableCellsSymbol = "u";
        const string UnvisitedCellSymbol = "0";
        const string StartingPositionSymbol = "*";
        
        private Matrix<string> matrix;
        private Queue<Cell<string>> unvisitedCells;

        public MatrixWalker(string[,] matrix)
        {
            this.matrix = new Matrix<string>(matrix);
            this.StartingPostion = this.FindStartingPosition(matrix);
            this.unvisitedCells = new Queue<Cell<string>>();
        }

        public Tuple<int, int> StartingPostion { get; private set; }

        public void MarkShortestPath()
        {
            
            var rowStart = this.StartingPostion.Item1;
            var colStart = this.StartingPostion.Item2;

            this.unvisitedCells.Enqueue((Cell<string>)this.matrix.GetCell(rowStart, colStart));

            while (this.unvisitedCells.Count > 0)
            { 
                var currentCell = unvisitedCells.Dequeue();
                
                AddPossibleCellsToQueue(currentCell);                
            }

            MarkUnreachableCells(UnreachableCellsSymbol);            
        }
                
        public string GetMatrixAsString()
        {
            StringBuilder result = new StringBuilder();
            int charsPerCell = 3;
            var widthOfMatrix = 1 + matrix.GetLength(1) * charsPerCell;

            string border = "\n" + new String('-', widthOfMatrix) + "\n";
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                result.Append(border);
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    var cell = (Cell<string>)this.matrix.GetCell(row, col);
                    result.AppendFormat("|{0,2}", cell.Value);
                }
                result.Append("|");
            }
            result.Append(border);
            return result.ToString();
        }

        private Tuple<int, int> FindStartingPosition(string[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            var startingPoint = new Object();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == StartingPositionSymbol)
                    {
                        startingPoint = new Tuple<int, int>(row, col);
                        break;
                    }
                }
            }

            return (Tuple<int, int>)startingPoint;
        }
        
        /// <summary>
        /// Selects the possible cells around the current one to be added to queue
        /// </summary>
        /// <param name="current">The current cell</param>
        private void AddPossibleCellsToQueue(Cell<string> current)
        {
            var neighbourCells = new Cell<string>[NeighbourCellsCount];

            //using enumeration and casting it to int for readability
            neighbourCells[(int)Cells.Up] = this.matrix.GetUpperCell(current);
            neighbourCells[(int)Cells.Down] = this.matrix.GetLowerCell(current);
            neighbourCells[(int)Cells.Left] = this.matrix.GetLeftCell(current);
            neighbourCells[(int)Cells.Right] = this.matrix.GetRightCell(current);

            for (var i = Cells.Up; i <= Cells.Right; i++)
            {
                var currCell = neighbourCells[(int)i];
                if (neighbourCells[(int)i] != null && currCell.Value == UnvisitedCellSymbol)
                {
                    this.unvisitedCells.Enqueue(currCell);
                    currCell.Value = GetNextStepNumber(current);
                }
            }
        }

        /// <summary>
        /// From value of cell calculates next step number 
        /// </summary>
        /// <param name="current">The cell from which to take current step number</param>
        /// <returns>string of the next step number</returns>
        private string GetNextStepNumber(Cell<string> current)
        {
            int n = 0;
            int.TryParse(current.Value, out n);

            return (n + 1).ToString();
        }

        private void MarkUnreachableCells(string symbol)
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    var cell = (Cell<string>)this.matrix.GetCell(row,col);
                    if (cell.Value == UnvisitedCellSymbol)
                    {
                        cell.Value = symbol;
                    }
                }               
            }
        }       
    }
}
