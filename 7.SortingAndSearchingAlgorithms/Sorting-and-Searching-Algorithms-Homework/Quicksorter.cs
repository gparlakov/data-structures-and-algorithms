namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Get middle index - if mid index < 1 return collection
    /// Find pivot (one out of three)
    /// devide in two - left smaller and right bigger than pivot
    /// callQuickSort ot two
    /// add left to right       
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Quicksort(collection);
            
        }

        private void Quicksort(IList<T> collection)
        {
            int midIndex = collection.Count / 2;
            if (midIndex == 0)
            {
                return;
            }

            var pivot = collection[0];

            var left = new List<T>();
            var right = new List<T>();
            //jump over pivot
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i].CompareTo(pivot) < 0)
                {
                    left.Add(collection[i]);
                }
                else
                {
                    right.Add(collection[i]);
                }
            }

            Quicksort(left);
            Quicksort(right);

            PutBackSorted(left, collection, pivot, right);
        }
  
        private void PutBackSorted(List<T> left, IList<T> collection, T pivot, List<T> right)
        {
            var mainIndex = 0;

            mainIndex = AddCollectionTo(left, collection, mainIndex);

            collection[mainIndex] = pivot;
            mainIndex++;

            AddCollectionTo(right, collection, mainIndex);
        }
  
        private int AddCollectionTo(List<T> left, IList<T> collection, int mainIndex)
        {
            for (int i = 0; i < left.Count; i++)
            {
                collection[mainIndex] = left[i];
                mainIndex++;                
            }
            return mainIndex;
        }
    }
}
