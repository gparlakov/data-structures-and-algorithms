namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                var minIndex = FindMin(collection, i);
                Swap(minIndex, i, collection);
            }
        }

        private void Swap(int indexOfMin, int i, IList<T> collection)
        {
            T buffer = collection[indexOfMin];
            collection[indexOfMin] = collection[i];
            collection[i] = buffer;
        }

        private int FindMin(IList<T> collection, int i)
        {
            int indexOfMin = i;
            for (int j = i + 1; j < collection.Count; j++)
            {
                if (collection[j].CompareTo(collection[indexOfMin]) < 0)
                {
                    indexOfMin = j;
                }
            }

            return indexOfMin;
        }
    }
}
