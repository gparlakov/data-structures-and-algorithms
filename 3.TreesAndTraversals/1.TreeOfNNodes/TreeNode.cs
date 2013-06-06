using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeOfNNodes
{
    public class TreeNode
    {
        public int Value { get; set; }
        public List<TreeNode> ChildNodes { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
            this.ChildNodes = new List<TreeNode>();
        }

        public void AddChild(TreeNode childNode)
        {
            this.ChildNodes.Add(childNode);
        }
    }
}
