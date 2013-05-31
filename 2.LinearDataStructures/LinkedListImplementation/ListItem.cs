using System;
using System.Linq;

namespace LinkedListImplementation
{
    public class ListItem<T>
    {
        internal ListItem(T value, ListItem<T> nextElement)
        {
            this.Value = value;
            this.NextItem = nextElement;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}