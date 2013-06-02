using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShortestPathInMatrix
{
    class Matrix<T>
    {
        private Cell<T>[,] matrix;

        public Matrix(T[,] matrix)
        {
            this.matrix = new Cell<T>[matrix.GetLength(0), matrix.GetLength(1)];
            this.FillMatrix(matrix);
        }

        public int GetLength(int dimension)
        {
            return this.matrix.GetLength(dimension);
        }

        public Cell<T> GetCell(int row, int col)
        {
            if (InsideMatrix(row, col))
            {
                return this.matrix[row, col];
            }

            return null;
        }

        public Cell<T> GetUpperCell(Cell<T> current)
        {
            var upperRow = current.Row - 1;
            var upperCol = current.Col;

            if (InsideMatrix(upperRow, upperCol))
            {
                return this.matrix[upperRow, upperCol];
            }

            return null;
        }

        public Cell<T> GetLowerCell(Cell<T> current)
        {
            var lowerRow = current.Row + 1;
            var lowerCol = current.Col;

            if (InsideMatrix(lowerRow, lowerCol))
            {
                return this.matrix[lowerRow, lowerCol];
            }

            return null;
        }

        public Cell<T> GetLeftCell(Cell<T> current)
        {
            var leftCellRow = current.Row;
            var leftCellCol = current.Col - 1;

            if (InsideMatrix(leftCellRow, leftCellCol))
            {
                return this.matrix[leftCellRow, leftCellCol];
            }

            return null;
        }

        public Cell<T> GetRightCell(Cell<T> current)
        {
            var rightCellRow = current.Row;
            var rightCellCol = current.Col + 1;

            if (InsideMatrix(rightCellRow, rightCellCol))
            {
                return this.matrix[rightCellRow, rightCellCol];
            }

            return null;
        }

        private bool InsideMatrix(int row, int col)
        {
            bool isInside = true;

            if (row < 0 || row >= this.matrix.GetLength(0))
            {
                isInside = false;
            }

            if (col < 0 || col >= this.matrix.GetLength(1))
            {
                isInside = false;
            }

            return isInside;
        }

        private void FillMatrix(T[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    this.matrix[row, col] = new Cell<T>(row, col, matrix[row, col]);
                }
            }
        }
    }
}
