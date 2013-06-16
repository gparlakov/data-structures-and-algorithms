namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            MergeSort(collection);
        }

        private void MergeSort(IList<T> collection)
        {
            var midIndex = collection.Count / 2;
            if (midIndex == 0)
            {
                return;
            }

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i < midIndex)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, collection);
        }

        private void Merge(List<T> left, List<T> right, IList<T> collection)
        {            
            int indexLeft = 0;
            int indexRight = 0;
            int mainIndex = 0;

            while (indexLeft < left.Count && indexRight < right.Count)
            {
                if (left[indexLeft].CompareTo(right[indexRight]) <= 0)
                {
                    collection[mainIndex] = left[indexLeft];
                    indexLeft++;
                }
                else
                {
                    collection[mainIndex] = right[indexRight];
                    indexRight++;
                }
                mainIndex++;
            }

            if (indexLeft < left.Count)
            {
                AddRemaining(indexLeft, left, collection, mainIndex);
            }
            else
            {
                AddRemaining(indexRight, right, collection, mainIndex);
            }
        }
  
        private void AddRemaining(int indexLeft, List<T> remaining, IList<T> merged, int mainIndex )
        {
            for (int i = indexLeft; i < remaining.Count; i++)
            {
                merged[mainIndex] = remaining[i];
            }
        }
    }
}
