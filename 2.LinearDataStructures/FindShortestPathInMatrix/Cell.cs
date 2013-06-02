using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShortestPathInMatrix
{
    public class Cell<T>
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        public T Value { get; set; }
        
        public Cell(int row, int col, T value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public void SetValue(T value)
        {
            this.Value = value;
        }

    }
}
