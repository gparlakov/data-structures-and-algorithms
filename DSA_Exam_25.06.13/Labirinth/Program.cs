using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labirinth
{
    class Program
    {        
        const char PassableCell = '.';
        const char ImpassableCell = '#';
        const char LadderUp = 'U';
        const char LadderDown = 'D';
        
        static int levels;
        static int rows;
        static int cols;
        static Dictionary<string, Cell> allNodes;
        static HashSet<Cell> visited;

        static void Main()
        {
            allNodes = new Dictionary<string, Cell>();
            visited = new HashSet<Cell>();

            var startingPosition = Console.ReadLine();
            var labirinthMetrics = Console.ReadLine().Split(' ');
            levels = int.Parse(labirinthMetrics[0]);
            rows = int.Parse(labirinthMetrics[1]);
            cols = int.Parse(labirinthMetrics[2]);

            for (int level = 0; level < levels; level++)
            {
                for (int row = 0; row < rows; row++)
                {
                    var line = Console.ReadLine();
                    for (int col = 0; col < cols; col++)
                    {                        
                        AddNode(line,level, row, col);
                    }
                }
            }


            var start = allNodes[startingPosition];

            var steps = BFS(start);

            Console.WriteLine(steps);
        }

        private static int BFS(Cell start)
        {
            start.Distance = 0;
            var queue = new Queue<Cell>();
            visited.Add(start);
            queue.Enqueue(start);

            var stepsToExit = 0;

            while (queue.Count > 0)
            {
                var currCell = queue.Dequeue();
                
                if (currCell.IsExit)
                {
                    stepsToExit = currCell.Distance + 1;
                    break;
                }

                foreach (var cell in currCell.Connections)
                {
                    if (!visited.Contains(cell))
                    {
                        queue.Enqueue(cell);
                        cell.Distance = currCell.Distance + 1;
                        visited.Add(cell);
                    }
                }
            }

            return stepsToExit;

        }

        private static void AddNode(string line, int level, int row, int col)
        {
            var nodeName = GetName(level, row, col);
            var symbol = line[col];
            Cell currentNode;

            currentNode = GetOrAddNode(level, row, col);

            currentNode.Symbol = symbol;

            if (symbol == ImpassableCell)
            {
                visited.Add(currentNode);
            }

            else
            {
                BuildConnectionsOfCurrentCell(level, row, col, currentNode);

            }
        }

        private static void BuildConnectionsOfCurrentCell(int level, int row, int col, Cell currentNode)
        {
            if (currentNode.Symbol == PassableCell)
            {
                BuildConnectionsForPassableCell(level, row, col, currentNode);

            }

            if (currentNode.Symbol == LadderUp)
            {
                BuildConnectionLadderUp(level, row, col, currentNode);
            }

            if (currentNode.Symbol == LadderDown)
            {
                BuildConnectionLadderDown(level, row, col, currentNode);
            }
        }

        private static void BuildConnectionLadderDown(int level, int row, int col, Cell currentNode)
        {
            if (level > 0)
            {
                AddConnectionIfMissing(level - 1, row, col, currentNode);
            }
            else if (level == 0)
            {
                currentNode.IsExit = true;
            }
        }

        private static void BuildConnectionLadderUp(int level, int row, int col, Cell currentNode)
        {
            if (level < levels - 1)
            {
                AddConnectionIfMissing(level + 1, row, col, currentNode);
            }
            else if (level == levels - 1)
            {
                currentNode.IsExit = true;
            }
        }

        private static void BuildConnectionsForPassableCell(int level, int row, int col, Cell currentNode)
        {
            if (row > 0)
            {
                AddConnectionIfMissing(level, row - 1, col, currentNode);
            }

            if (row < rows - 1)
            {
                AddConnectionIfMissing(level, row + 1, col, currentNode);
            }

            if (col > 0)
            {
                AddConnectionIfMissing(level, row, col - 1, currentNode);
            }

            if (col < cols - 1)
            {
                AddConnectionIfMissing(level, row, col + 1, currentNode);
            }
        }

        private static void AddConnectionIfMissing(int level, int row, int col, Cell currentNode)
        {
            var neightbour = GetOrAddNode(level, row, col);
            if (!currentNode.Connections.Contains(neightbour))
            {
                currentNode.Connections.Add(neightbour);
            }
        }

        private static Cell GetOrAddNode(int level, int row, int col)
        {
            Cell currentNode;
            var nodeName = GetName(level, row, col);

            if (allNodes.ContainsKey(nodeName))
            {
                currentNode = allNodes[nodeName];
            }
            else
            {
                currentNode = new Cell(level, row, col);
                allNodes.Add(nodeName, currentNode);
            }
            return currentNode;
        }

        private static string GetName(int level, int row, int col)
        {
            var nodeName = string.Format("{0} {1} {2}", level, row, col);
            return nodeName;
        }

        public class Cell
        {
            public int Level { get; private set; }
            public int Row { get; private set; }
            public int Col { get; private set; }
            public char Symbol { get; set; }
            public bool IsExit { get; set; }
            public HashSet<Cell> Connections { get; set; }
            public int Distance { get; set; }

            public Cell(int level, int row, int col)
            {
                this.Level = level;
                this.Row = row;
                this.Col = col;
                this.Symbol = '\0';
                this.IsExit = false;
                this.Connections = new HashSet<Cell>();
                this.Distance = 0;
            }

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", this.Level, this.Row, this.Col);
            }
        }
    }
}
