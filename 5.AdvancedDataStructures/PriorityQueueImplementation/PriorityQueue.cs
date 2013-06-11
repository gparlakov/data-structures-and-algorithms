using System;
using System.Linq;
using Wintellect.PowerCollections;

namespace PriorityQueueImplementation
{
    public class PriorityQueue<T> where T:IComparable<T>
    {
        private OrderedBag<T> queue;

        public PriorityQueue()
        {
            this.queue = new OrderedBag<T>(new Comparison<T>((x,y) => -x.CompareTo(y)));
        }

        public void Enqueue(T value)
        {
            this.queue.Add(value);
        }

        public T Dequeue()
        {
            var item = this.queue.GetFirst();
            this.queue.RemoveFirst();
            return item;
        }

        public void Clear()
        {
            this.queue = new OrderedBag<T>(new Comparison<T>((x, y) => -x.CompareTo(y)));
        }

        public int Count
        {
            get 
            { 
                return this.queue.Count; 
            }
        }

    }
}
