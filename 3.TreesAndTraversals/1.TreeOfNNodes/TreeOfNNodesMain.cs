using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeOfNNodes
{
    class TreeOfNNodesMain
    {
        static void Main()
        {
            var inputStrings = ReadInput();
            var tree = new Tree();
            var values = GetNodeValues(inputStrings);
            tree.BuildTree(values);
            //1 root
            var root = tree.FindRoot();
            Console.WriteLine("Root is {0}\n", root.Value);

            //2 all middle nodes
            var middleNodes = tree.FindNodes(TypeNodes.Middle);
            Console.WriteLine("MiddleNodes:");
            foreach (var item in middleNodes)
            {
                Console.Write("{0} ",item.Value);
            }

            //3 all leafs
            Console.WriteLine("\n\nLeafs");
            var leafNodes = tree.FindNodes(TypeNodes.Leaf);
            foreach (var item in leafNodes)
            {
                Console.Write("{0} ", item.Value);
            }
            
            //4 
            var longestPath = tree.FindLongestPathInTree();
            Console.WriteLine("\n\nLongest path by number nodes and node values is {0}", longestPath);

            //5
            var searchSum1 = 9;            
            var allPathsWithSum1 = tree.FindAllPathsWithSumOf(searchSum1);
            Console.WriteLine("\nAll paths with sum of {0} are:", searchSum1);
            foreach (var item in allPathsWithSum1)
            {
                Console.Write("{0} ", item);
            }

            var searchSum2 = 8;
            var allPathsWithSum2 = tree.FindAllPathsWithSumOf(searchSum2);
            Console.WriteLine("\n\nAll paths with sum of {0} are:", searchSum2);
            foreach (var item in allPathsWithSum2)
            {
                Console.Write("{0} ", item);
            }

            //6
            var searchSum3 = 21;
            var allTreesWithSum3 = tree.FindAllTreesWithSumOf(searchSum3);
            Console.WriteLine("\n\nAll Trees with sum of {0} are:", searchSum3);
            foreach (var item in allTreesWithSum3)
            {
                Console.Write("{0} ", item);
            }
            var searchsum4 = 6;
            var allTreesWithSum4 = tree.FindAllTreesWithSumOf(searchsum4);
            Console.WriteLine("\n\nAll Trees with sum of {0} are:", searchsum4);
            foreach (var item in allTreesWithSum4)
            {
                Console.Write("{0} ", item);
            }

        }

        private static string[] ReadInput()
        {
            var input = new string[] { "7", "2 4", "3 2", "5 0", "3 5", "5 6", "5 1" };
            return input;
        }

        private static Tuple<int, int>[] GetNodeValues(string[] input)
        {
            var valueChildPair = new List<Tuple<int, int>>();
            for (int i = 1; i < input.Length; i++)
            {
                var parentChild = input[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var value = int.Parse(parentChild[0]);
                var child = int.Parse(parentChild[1]);
                valueChildPair.Add(new Tuple<int, int>(value,child));
            }

            return valueChildPair.ToArray();
        }
    }
}