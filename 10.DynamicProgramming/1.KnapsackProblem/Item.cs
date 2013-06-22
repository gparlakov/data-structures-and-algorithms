namespace KnapsackProblem
{
    public class Item
    {
        public string Name { get; private set; }
        public int Weight { get; private set; }
        public int Value { get; private set; }
        
        public Item(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }
    }
}
