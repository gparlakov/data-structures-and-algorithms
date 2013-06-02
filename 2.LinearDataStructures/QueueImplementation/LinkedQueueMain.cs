using System;
using System.Linq;

namespace QueueImplementation
{
    /// <summary>
    /// Implement the ADT queue as dynamic linked list. 
    /// Use generics (LinkedQueue<T>) to allow storing 
    /// different data types in the queueqq
    /// </summary>
    class LinkedQueueMain
    {
        static void Main(string[] args)
        {
            var strings = new LinkedQueue<string>();
            strings.Enqueue("First GrandMa");
            strings.Enqueue("Second GrandMa");
            strings.Enqueue("Third GrandMa");
            strings.Enqueue("Fourhth GrandMa");

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("{0} count: {1}",strings.Dequeue(), strings.Count);
                
            }
            
            //var outOfQueue = strings.Dequeue(); //exception
        }
    }
}