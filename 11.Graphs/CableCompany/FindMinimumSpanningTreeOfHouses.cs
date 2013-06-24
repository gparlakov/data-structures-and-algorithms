using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CableCompany
{
    public class FindMinimumSpanningTreeOfHouses
    {
        public static void Main()
        {
            var trees = new Dictionary<string, List<Node>>();
            var allPaths = new SortedDictionary<int, Path>();
            var allNodes = new Node[7];
            for (int i = 0; i < 7; i++)
            {
                allNodes[i] = new Node("House" + i);
                trees.Add("House" + i, new List<Node>());
                trees["House" + i].Add(allNodes[i]);
            }

            allPaths.Add(5, new Path(allNodes[0], allNodes[1], 5));
            allPaths.Add(2, new Path(allNodes[0], allNodes[2], 2));
            allPaths.Add(15, new Path(allNodes[2], allNodes[3], 15));
            allPaths.Add(7, new Path(allNodes[2], allNodes[3], 7));
            allPaths.Add(16, new Path(allNodes[4], allNodes[5], 16));
            allPaths.Add(6, new Path(allNodes[6], allNodes[4], 6));
            allPaths.Add(9, new Path(allNodes[2], allNodes[5], 9));

            var wholePath = new StringBuilder();
            var wholePathLength = 0L;
            foreach (var path in allPaths)
            {
                var fromNode = path.Value.FromNode;
                var toNode = path.Value.ToNode;

                if (fromNode.Tree != toNode.Tree)
                {
                    wholePath.AppendFormat("{0} {2} {1}\n", fromNode.Name, path.Key, toNode.Name);
                    wholePathLength += path.Key;
                    var mergedTree = fromNode.Tree;
                    var oldTree = toNode.Tree;
                    trees[mergedTree].AddRange(trees[oldTree]);
                    foreach (var node in trees[oldTree])
                    {
                        node.Tree = mergedTree;
                    }

                    trees.Remove(oldTree);                 
                }
            }

           
            foreach (var tree in trees)
            {
                Console.WriteLine("minimum spanning tree/forest connecting houses:");
                foreach (var node in tree.Value)
                {
                    Console.WriteLine(node.Name);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Path costists of theese streets:\n{0}\nTotal length : {1} ", wholePath.ToString(), wholePathLength);
        }
    }
}
