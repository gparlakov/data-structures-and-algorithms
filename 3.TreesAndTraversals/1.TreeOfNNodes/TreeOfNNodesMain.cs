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

            var root = tree.FindRoot();

            var middleNodes = tree.FindNodes(TypeNodes.Middle);
            var leafNodes = tree.FindNodes(TypeNodes.Leaf);
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