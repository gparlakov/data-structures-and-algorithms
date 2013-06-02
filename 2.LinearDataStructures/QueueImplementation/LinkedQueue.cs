using System;

namespace QueueImplementation
{
    /// <summary>
    /// Implement the ADT queue as dynamic linked list. 
    /// Use generics (LinkedQueue<T>) to allow storing 
    /// different data types in the queue.
    /// </summary>
    public class LinkedQueue<T> where T : IComparable<T>
    {
        private LinkedListImplementation.LinkedList<T> elements;

        public LinkedQueue()
        {
            this.elements = new LinkedListImplementation.LinkedList<T>();
            this.Count = 0;
        }

        public int Count { get; private set; }
        
        public void Enqueue(T element)
        {
            this.elements.Add(element);
            this.Count++;
        }

        public T Dequeue()
        {
            if (this.elements.Count < 1)
            {
                throw new ArgumentOutOfRangeException("The queue is empty!");
            }

            var firstElem = this.elements[0];
            this.elements.RemoveAt(0);
            this.Count--;

            return firstElem;
        }

        public T Peek()
        {
            if (this.elements.Count < 1)
            {
                throw new ArgumentOutOfRangeException("The queue is empty!");
            }
            var firstElem = this.elements[0];
            return firstElem;
        }

        public void Clear()
        {
            this.elements = new LinkedListImplementation.LinkedList<T>();
            this.Count = 0;
        }
    }
}