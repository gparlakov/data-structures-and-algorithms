using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeOfNNodes
{
    public class Tree
    { 
        private readonly List<TreeNode> treeNodes;

        public Tree()
        {
            this.treeNodes = new List<TreeNode>();
        }

        public TreeNode Root { get; private set; }

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
            var allPaths = new List<string>();

            var queue = new Queue<TreeNode>();
            while (queue.Count > 0)
            {
                var nextNode = queue.Dequeue();
                for (int i = 0; i < nextNode.ChildNodes.Count; i++)
                {
                    queue.Enqueue(nextNode.ChildNodes[i]);
                }

                allPaths.AddRange(this.FindAllPathsStartingFrom(nextNode));
            }

            Array.Sort(allPaths.ToArray());

            return allPaths[0];
        }

        private IEnumerable<string> FindAllPathsStartingFrom(TreeNode nextNode)
        {
            throw new NotImplementedException();
        }

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
    }
}