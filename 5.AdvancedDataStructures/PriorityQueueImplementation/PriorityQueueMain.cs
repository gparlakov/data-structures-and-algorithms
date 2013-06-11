using System;
using System.Collections.Generic;
using System.Linq;

namespace PriorityQueueImplementation
{
    public class PriorityQueueMain
    {
        static void Main()
        {
            var nums = new PriorityQueue<int>();

            nums.Enqueue(5);
            nums.Enqueue(1);
            nums.Enqueue(15);
            nums.Enqueue(-1);
            nums.Enqueue(6);

            Console.WriteLine(nums.Dequeue());
            Console.WriteLine(nums.Dequeue());
            Console.WriteLine(nums.Dequeue());
            Console.WriteLine(nums.Dequeue());

            var strings = new PriorityQueue<string>();
            strings.Enqueue("Ani");  
            strings.Enqueue("Cvetan");
            strings.Enqueue("Pesho");
            strings.Enqueue("Maria");
            strings.Enqueue("Mario");
            strings.Enqueue("1");
            strings.Enqueue("12");

            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Dequeue());
            Console.WriteLine(strings.Dequeue());

        }
    }
}
