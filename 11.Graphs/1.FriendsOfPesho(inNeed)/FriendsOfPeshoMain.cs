using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FriendsOfPesho
{
    public class FriendsOfPeshoMain
    {
        private static char[] Separators = null;

        public static void Main()
        {
            Separators = new char[] { ' ' };

            var allNodes = new Dictionary<int, Node>();
            var graph = new Dictionary<Node, List<Path>>();

            var hospitals = ReadInput(allNodes, graph);

            MarkAsHospitals(hospitals, allNodes);

            var mimumDistance = long.MaxValue;
            
            foreach (var hospital in hospitals)
            {
                var source = allNodes[hospital];
                DijsktraDistance(graph, source);

                mimumDistance = UpdateMinimumDistance(graph, mimumDistance);
            }

            Console.WriteLine(mimumDistance);
        }
  
        private static ICollection<int> ReadInput(Dictionary<int, Node> allNodes, Dictionary<Node, List<Path>> graph)
        {
            var firstLine = Console.ReadLine().Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            var numberOfNodes = int.Parse(firstLine[0]);
            var numberOfPaths = int.Parse(firstLine[1]);
            var numberOfHospitals = int.Parse(firstLine[2]);

            var hospitalsNumbers = Console.ReadLine().Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            var hospitals = ReadHospitals(numberOfHospitals, hospitalsNumbers);
              
            for (int i = 0; i < numberOfPaths; i++)
            {
                var lineArguments = Console.ReadLine().Split(Separators, StringSplitOptions.RemoveEmptyEntries);

                var nodeFrom = int.Parse(lineArguments[0]);
                var nodeTo = int.Parse(lineArguments[1]);
                var length = int.Parse(lineArguments[2]);
                                  
                AddNodesIfMissing(nodeFrom, allNodes, nodeTo);

                var nodeFromObj = allNodes[nodeFrom];
                var nodeToObj = allNodes[nodeTo];

                AddPathListsIfMissing(nodeFromObj, graph, nodeToObj);

                graph[nodeFromObj].Add(new Path(nodeToObj, length));
                graph[nodeToObj].Add(new Path(nodeFromObj, length));
            }

            return hospitals;
        }
  
        private static void AddPathListsIfMissing(Node nodeFromObj, Dictionary<Node, List<Path>> graph, Node nodeToObj)
        {
            if (!graph.ContainsKey(nodeFromObj))
            {
                graph.Add(nodeFromObj, new List<Path>());
            }

            if (!graph.ContainsKey(nodeToObj))
            {
                graph.Add(nodeToObj, new List<Path>());
            }
        }
  
        private static void AddNodesIfMissing(int nodeFrom, Dictionary<int, Node> allNodes, int nodeTo)
        {
            if (!allNodes.ContainsKey(nodeFrom))
            {
                allNodes.Add(nodeFrom, new Node(nodeFrom));                    
            }
                    
            if (!allNodes.ContainsKey(nodeTo))
            {
                allNodes.Add(nodeTo, new Node(nodeTo));
            }
        }
  
        private static void MarkAsHospitals(ICollection<int> hospitals, Dictionary<int, Node> allNodes)
        {
            foreach (var hospital in hospitals)
            {
                allNodes[hospital].IsHospital = true;
            }
        }
  
        private static long UpdateMinimumDistance(Dictionary<Node, List<Path>> graph, long mimumDistance)
        {
            var currentDistance = GetDistance(graph);

            if (currentDistance < mimumDistance)
            {
                mimumDistance = currentDistance;
            }
            return mimumDistance;
        }
  
        private static long GetDistance(Dictionary<Node, List<Path>> graph)
        {
            var currentDistance = 0L;
            foreach (var node in graph)
            {
                if (!node.Key.IsHospital)
                {
                    currentDistance += node.Key.DijkstraDistance;
                }
            }
            return currentDistance;
        }

        private static void DijsktraDistance(Dictionary<Node, List<Path>> graph, Node source)
        {
            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = long.MaxValue;
            }
            source.DijkstraDistance = 0;

            var priorityQueue = new PriorityQueue<Node>();
            priorityQueue.Enqueue(source);
            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.Dequeue();

                if (currentNode.DijkstraDistance == long.MaxValue)
                {
                    break;
                }

                foreach (var path in graph[currentNode])
                {
                    var calculatedPath = currentNode.DijkstraDistance + path.Length;
                    if (calculatedPath < path.ToNode.DijkstraDistance)
                    {
                        path.ToNode.DijkstraDistance = calculatedPath;
                        priorityQueue.Enqueue(path.ToNode);
                    }                   
                }
            }
        }

        private static ICollection<int> ReadHospitals(int numberOfHospitals, string[] hospitalsNumbers)
        {
            var hospitals = new List<int>();
            for (int i = 0; i < numberOfHospitals; i++)
            {
                hospitals.Add(int.Parse(hospitalsNumbers[i]));
            }

            return hospitals;
        }        

        public class Node:IComparable<Node>
        {
            public int Name { get; private set; }
            public long DijkstraDistance { get; set; }
            public bool IsHospital { get; set; }

            public Node(int name)
            {
                this.Name = name;
                this.DijkstraDistance = 0;
                this.IsHospital = false;
            }

            public int CompareTo(Node other)
            {
                return this.DijkstraDistance.CompareTo(other.DijkstraDistance);
            }
        }  

        public class Path
        {
            public Node ToNode { get; set; }
            public int Length { get; set; }

            public Path(Node to, int length)
            {
                this.ToNode = to;
                this.Length = length;
            }
        }

        public class PriorityQueue<T> where T : IComparable<T>
        {
            private T[] heap;
            private int index;

            public int Count
            {
                get
                {
                    return this.index - 1;
                }
            }

            public PriorityQueue()
            {
                this.heap = new T[16];
                this.index = 1;
            }

            public void Enqueue(T element)
            {
                if (this.index >= this.heap.Length)
                {
                    IncreaseArray();
                }

                this.heap[this.index] = element;

                int childIndex = this.index;
                int parentIndex = childIndex / 2;
                this.index++;

                while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
                {
                    T swapValue = this.heap[parentIndex];
                    this.heap[parentIndex] = this.heap[childIndex];
                    this.heap[childIndex] = swapValue;

                    childIndex = parentIndex;
                    parentIndex = childIndex / 2;
                }
            }

            public T Dequeue()
            {
                T result = this.heap[1];

                this.heap[1] = this.heap[this.Count];
                this.index--;

                int rootIndex = 1;

                int minChild;

                while (true)
                {
                    int leftChildIndex = rootIndex * 2;
                    int rightChildIndex = rootIndex * 2 + 1;

                    if (leftChildIndex > this.index)
                    {
                        break;
                    }
                    else if (rightChildIndex > this.index)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                        {
                            minChild = leftChildIndex;
                        }
                        else
                        {
                            minChild = rightChildIndex;
                        }
                    }

                    if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                    {
                        T swapValue = this.heap[rootIndex];
                        this.heap[rootIndex] = this.heap[minChild];
                        this.heap[minChild] = swapValue;

                        rootIndex = minChild;
                    }
                    else
                    {
                        break;
                    }
                }

                return result;
            }

            public T Peek()
            {
                return this.heap[1];
            }

            private void IncreaseArray()
            {
                T[] copiedHeap = new T[this.heap.Length * 2];

                for (int i = 0; i < this.heap.Length; i++)
                {
                    copiedHeap[i] = this.heap[i];
                }

                this.heap = copiedHeap;
            }
        }

    }
}
