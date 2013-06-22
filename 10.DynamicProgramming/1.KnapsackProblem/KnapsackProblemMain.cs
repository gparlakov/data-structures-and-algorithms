using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnapsackProblem
{
    /// <summary>
    /// I take the 0/1 knapsack problem - where you are allowed to 
    /// use 0 or 1 items (not 0.5 or 2,3 4....) 
    /// </summary>
    public class KnapsackProblemMain
    {
        static void Main()
        {
            var items = GetItems();
            var capacity = 20;
            
            // This is the DP matrix that I use
            // It consists of cells of Value and Keep
            // Value is the maximum value 
            // Keep tells whether or not to keep the element in the solution
            var matrix = new ValueKeep[items.Length, capacity + 1];

            FillMatrixOfValueKeepPairs(items, matrix);

            var maxCost = matrix[items.Length - 1, capacity].Value;            

            var currItemIndex = items.Length - 1;
            var optimumItems = new StringBuilder();

            while(capacity > 0 && currItemIndex > 0)
            {
                if (matrix[currItemIndex, capacity].Keep)
                {
                    optimumItems.Append(items[currItemIndex].Name + ", ");
                    capacity -= items[currItemIndex].Weight;                    
                }

                currItemIndex--;
            }
            optimumItems.Length -= 2;


            PrintMatrix(matrix, items);
            Console.WriteLine();
            Console.WriteLine(maxCost);
            Console.WriteLine(optimumItems.ToString());
        }
  
        private static void FillMatrixOfValueKeepPairs(Item[] items, ValueKeep[,] matrix)
        {
            var capacity = matrix.GetLength(1);

            for (int item = 1; item < items.Length; item++)
            {
                for (int cap = 1; cap < capacity; cap++)
                {
                    if (cap >= items[item].Weight)
                    { 
                        var capacityLeft = cap - items[item].Weight;
                        var valueWithThisItem = items[item].Value + matrix[item - 1, capacityLeft].Value;
                        if (valueWithThisItem > matrix[item - 1, cap].Value)
                        {
                            matrix[item, cap].Value = valueWithThisItem;
                            matrix[item, cap].Keep = true;
                        }
                        else
                        {
                            matrix[item, cap].Value = matrix[item - 1, cap].Value;
                            matrix[item, cap].Keep = false;
                        }
                    }
                    else
                    {
                        matrix[item, cap].Keep = false;
                        matrix[item, cap].Value = matrix[item - 1, cap].Value; 
                    }
                }
            }
        }
                
        private static Item[] GetItems()
        {
            var items = new Item[]
            {
                new Item("", 0, 0),
                new Item("Beer", 3, 8),
                new Item("Vodka", 8, 12),
                new Item("Cheese", 4, 5),
                new Item("Nuts", 1, 4),
                new Item("Ham", 2, 3),
                new Item("Whiskey", 8, 13)
            };

            return items;
        }

        private static void PrintMatrix(ValueKeep[,] matrix, Item[] items)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write("{0, 6} ", items[i].Name);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,2}/{1} ", matrix[i, j].Value, matrix[i,j].Keep? 'Y': 'N');
                }
                Console.WriteLine();
            }
        }
    }
}
