namespace RecursiveMatrixPathFinding
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Col { get; private set; }
        
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
