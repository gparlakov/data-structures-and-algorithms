namespace CableCompany
{
    public class Node
    {
        public string Name { get; set; }
        public string Tree { get; set; }
        
        public Node(string name)
        {
            this.Name = name;
            this.Tree = name;
        }
    }
}
