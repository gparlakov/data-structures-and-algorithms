using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CableCompany
{
    public class Path
    {
        public Node FromNode { get; set; }
        public Node ToNode { get; set; }
        public int Length { get; set; }
        
        public Path(Node fromNode, Node toNode, int length)
        {
            this.FromNode = fromNode;
            this.ToNode = toNode;
            this.Length = length;
        }
    }
}
