using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LinkedListImplementation;

namespace QueueImplementation
{

    /// <summary>
    /// Implement the ADT queue as dynamic linked list. 
    /// Use generics (LinkedQueue<T>) to allow storing 
    /// different data types in the queue.
    /// </summary>
    public class LinkedQueue<T> where T:IComparable<T>
    {
        private LinkedListImplementation.LinkedList<T> elements;

        public LinkedQueue()
        {
            this.elements = new LinkedListImplementation.LinkedList<T>();
        }

        public void Enqueue(T element)
        {
            elements.Add(element);
        }

        public T Dequeue()
        {
            if (elements.Count < 1)
            {
                throw new ArgumentOutOfRangeException("The queue is empty!");
            }
            var firstElem = elements[0];
            elements.RemoveAt(0);
            return firstElem;
        }

        public T Peek()
        {
            if (elements.Count < 1)
            {
                throw new ArgumentOutOfRangeException("The queue is empty!");
            }
            var firstElem = elements[0];
            return firstElem;
        }

        public void Clear()
        {
            this.elements = new LinkedListImplementation.LinkedList<T>();
        }
       
    }
}
