using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueImplementation
{
    class LinkedQueueMain
    {
        static void Main(string[] args)
        {
            var strings = new LinkedQueue<string>();
            strings.Enqueue("First GrandMa");
            strings.Enqueue("Second GrandMa");
            strings.Enqueue("Third GrandMa");
            strings.Enqueue("Fourhth GrandMa");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(strings.Dequeue());
            }
            
            //
            //var outOfQueue = strings.Dequeue(); //exception
        }
    }
}
