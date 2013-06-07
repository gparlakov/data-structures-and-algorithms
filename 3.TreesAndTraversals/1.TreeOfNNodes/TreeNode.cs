using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeOfNNodes
{
    public class TreeNode
    {
        public TreeNode(int value)
        {
            this.Value = value;
            this.ChildNodes = new List<TreeNode>();
        }

        public int Value { get; set; }

        public List<TreeNode> ChildNodes { get; set; }

        public void AddChild(TreeNode childNode)
        {
            this.ChildNodes.Add(childNode);
        }
    }
}