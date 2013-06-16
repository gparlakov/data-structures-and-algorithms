namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool found = false;

            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }

        public bool BinarySearch(T item)
        {
            bool found = false;

            var middleItemIndex = this.items.Count / 2;
            var left = 0;
            var right = this.items.Count - 1;

            while (right != left)
            {
                var middleItem = this.items[middleItemIndex];

                if (middleItem.CompareTo(item) == 0)
                {
                    found = true;
                    break;
                }
                
                if (middleItem.CompareTo(item) > 0)
                {
                    right = middleItemIndex - 1;
                }
                else
                {
                    left = middleItemIndex + 1;
                }                
                
                middleItemIndex = left + (right - left) / 2;
            }

            if (this.items[left].CompareTo(item) == 0)
            {
                found = true;
            }

            return found;
        }

        public void Shuffle()
        {
            var rand = new Random();
            for (int i = 0; i < this.items.Count; i++)
            {
                var randomIndex = rand.Next(this.items.Count);
                Swap(i , randomIndex, this.items);
            }
        }

        private void Swap(int index1, int index2, IList<T> collection)
        {
            T buffer = collection[index1];
            collection[index1] = collection[index2];
            collection[index2] = buffer;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
