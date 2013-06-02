using System;
using System.Linq;
using Utils;

namespace LinkedListImplementation
{
    class LinkedListMain
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            linkedList.Add(5);
            linkedList.Add(6);
            Console.WriteLine("Added 5, 6.Indexes of 4,5,6,7:");
            Console.WriteLine(linkedList.IndexOf(4));
            Console.WriteLine(linkedList.IndexOf(5));
            Console.WriteLine(linkedList.IndexOf(6));
            Console.WriteLine(linkedList.IndexOf(7));

            Console.WriteLine("Ten Added:(0 - 9)");
            AddItems(linkedList, 10);
            PrintoutList(linkedList);

            Console.WriteLine("Item added at index 10:");
            linkedList.Insert(10, 100000);
            PrintoutList(linkedList);            

            Console.WriteLine("Remove item with value 1");
            linkedList.Remove(1);
            PrintoutList(linkedList);

            Console.WriteLine("Remove elem at index 6");
            linkedList.RemoveAt(6);
            PrintoutList(linkedList);

            int[] copied = new int[linkedList.Count + 1];

            //linkedList.CopyTo(copied, 0); // leaves one blank element at end
            linkedList.CopyTo(copied, 1);
            Console.WriteLine("Copied to array (first element left blank):\n{0}",
                Utilities.Join(copied));
            //linkedList.CopyTo(copied, 2); // throws exception because copied array isn"t big enough
        }
  
        private static void PrintoutList(LinkedList<int> linkedList)
        {
            Console.WriteLine(Utilities.Join(linkedList.ToArray<int>()));
        }

        private static void AddItems(LinkedList<int> linkedList, int count)
        {
            for (int i = 0; i < count; i++)
            {
                linkedList.Add(i);
            }
        }
    }
}