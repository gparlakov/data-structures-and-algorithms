using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace TreeOfNNodes
{
    public class Tree
    { 
        private readonly List<TreeNode> treeNodes;

        private IEnumerable<string> allPaths;

        public Tree()
        {
            this.treeNodes = new List<TreeNode>();
        }

        public TreeNode Root { get; private set; }

        #region public methods
        public void BuildTree(Tuple<int, int>[] valueChildPairs)
        {
            for (int i = 0; i < valueChildPairs.Length; i++)
            {
                TreeNode parent = this.AddNode(valueChildPairs[i].Item1);
                TreeNode child = this.AddNode(valueChildPairs[i].Item2);
                parent.AddChild(child);
            }

            this.Root = this.FindRoot();
        }

        /// <summary>
        /// Gets all values and then removes the values 
        /// that are being pointed as being children in each of 
        /// the nodes' childNodes lists
        /// </summary>
        /// <returns>First TreeNode that has no parent</returns>
        public TreeNode FindRoot()
        {
            if (this.Root != null)
            {
                return this.Root;
            }

            List<int> values = this.GetAllValues();
            this.RemoveChildValuesFromList(values);

            var root = this.FindNodeByValue(values[0]);

            return root;
        }

        public List<TreeNode> FindNodes(TypeNodes type)
        {
            var list = new List<TreeNode>();
            this.FindInTree(type, list);

            return list;
        }

        public string FindLongestPathInTree()
        {
            var allPaths = FindAllSubPaths();

            var sorted = allPaths.OrderByDescending(x => x.Length).ThenByDescending(x => x).ToArray<string>();

            return sorted[0];
        }

        public IEnumerable<string> FindAllPathsWithSumOf(int sum)
        {
            var allPaths = FindAllSubPaths();

            var sumsPathsPairs = CalcSumsOfPathsOrTrees(allPaths);

            return sumsPathsPairs[sum];            
        }

        public IEnumerable<string> FindAllTreesWithSumOf(int sum)
        {
            var allTrees = FindAllTrees();

            var sumTreePairs = CalcSumsOfPathsOrTrees(allTrees);

            return sumTreePairs[sum];
        }
        
        #endregion

        #region private methods
        //5 & 6
        private IEnumerable<string> FindAllTrees()
        {
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            nodes.Enqueue(this.Root);

            List<string> trees = new List<string>();
            while (nodes.Count > 0)
            {
                var nextNode = nodes.Dequeue();

                var subTree = GetTreeStartingFrom(nextNode);
                trees.Add(subTree);

                foreach (var node in nextNode.ChildNodes)
                {
                    nodes.Enqueue(node);
                }
            }

            return trees;
        }

        private string GetTreeStartingFrom(TreeNode nextNode)
        {
            StringBuilder tree = new StringBuilder();
            Queue<TreeNode> subNodes = new Queue<TreeNode>();
            subNodes.Enqueue(nextNode);
            while (subNodes.Count > 0)
            {
                var node = subNodes.Dequeue();
                tree.AppendFormat("{0}", node.Value);

                foreach (var child in node.ChildNodes)
                {
                    subNodes.Enqueue(child);
                }
            }

            return tree.ToString();
        }

        private MultiDictionary<int, string> CalcSumsOfPathsOrTrees(IEnumerable<string> allPathsOrTrees)
        {
            var sumsPathsPairs = new MultiDictionary<int, string>(true);

            foreach (var path in allPathsOrTrees)
            {
                var sum = CalcSum(path);
                sumsPathsPairs.Add(sum, path);
            }

            return sumsPathsPairs;
        }

        private int CalcSum(string path)
        {
            int sum = 0;
            for (int i = 0; i < path.Length; i++)
            {
                sum += int.Parse(path[i].ToString());
            }

            return sum;
        }
        
        //4
        private IEnumerable<string> FindAllSubPaths()
        {
            if (this.allPaths != null)
            {
                return this.allPaths;
            }

            var allPaths = new List<string>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(this.Root);
            while (queue.Count > 0)
            {
                var nextNode = queue.Dequeue();
                for (int i = 0; i < nextNode.ChildNodes.Count; i++)
                {
                    queue.Enqueue(nextNode.ChildNodes[i]);
                }

                allPaths.AddRange(this.FindAllPathsStartingFrom(nextNode));
            }

            this.allPaths = allPaths;

            return allPaths;
        }

        private IEnumerable<string> FindAllPathsStartingFrom(TreeNode node, string pathToHere = null)
        {
            List<string> nextPaths = new List<string>();

            if (pathToHere == null)
            {
                pathToHere = node.Value.ToString();
            }
            else
            {
                pathToHere += node.Value.ToString();
            }

            if (node.ChildNodes.Count == 0)
            {
                nextPaths.Add(pathToHere);
                return nextPaths;
            }
            nextPaths.Add(pathToHere);
            foreach (var child in node.ChildNodes)
            {
                nextPaths.AddRange(FindAllPathsStartingFrom(child, pathToHere));
            }

            return nextPaths;
        }
        
        //1 2 3
        private void FindInTree(TypeNodes type, List<TreeNode> list)
        {
            var stack = new Stack<TreeNode>();
            stack.Push(this.Root);
            {
                while (stack.Count > 0)
                {
                    var nextNode = stack.Pop();
                    for (int i = 0; i < nextNode.ChildNodes.Count; i++)
                    {
                        stack.Push(nextNode.ChildNodes[i]);
                    }

                    if (this.CheckIfIsSearchedNodeType(nextNode, type))
                    {
                        list.Add(nextNode);
                    }
                }
            }
        }
  
        private bool CheckIfIsSearchedNodeType(TreeNode nextNode, TypeNodes searchedType)
        {
            bool isCorrectTypeOfNode = false;
            
            if (searchedType == TypeNodes.Leaf)
            {
                if (nextNode.ChildNodes.Count == 0)
                {
                    isCorrectTypeOfNode = true;
                }
            }
            else if (searchedType == TypeNodes.Middle)
            {
                if (nextNode.ChildNodes.Count > 1)
                {
                    isCorrectTypeOfNode = true;
                }
            }

            return isCorrectTypeOfNode;            
        }

        private TreeNode AddNode(int value)
        {
            var result = this.FindNodeByValue(value);

            if (result == null)
            {
                result = new TreeNode(value);
                this.treeNodes.Add(result);
            }

            return result;
        }

        private TreeNode FindNodeByValue(int value)
        {
            TreeNode result = null;
            for (int i = 0; i < this.treeNodes.Count; i++)
            {
                if (this.treeNodes[i].Value == value)
                {
                    result = this.treeNodes[i];
                }
            }

            return result;
        }

        private void RemoveChildValuesFromList(List<int> values)
        {
            for (int node = 0; node < this.treeNodes.Count; node++)
            {
                var nextNode = this.treeNodes[node];
                for (int child = 0; child < nextNode.ChildNodes.Count; child++)
                {
                    values.Remove(nextNode.ChildNodes[child].Value);
                }
            }
        }

        private List<int> GetAllValues()
        {
            var values = new List<int>();
            for (int i = 0; i < this.treeNodes.Count; i++)
            {
                if (!values.Contains(this.treeNodes[i].Value))
                {
                    values.Add(this.treeNodes[i].Value);
                }
            }

            return values;
        }
        #endregion
    }
}