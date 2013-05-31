using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    /// <summary>Implement the data structure linked list. Define a class ListItem\<T\> that has two fields: value 
    /// (of type T) and NextItem (of type ListItem<T>). Define additionally a class LinkedList\<T\> with 
    /// a single field FirstElement (of type ListItem<\T\>)</summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedList<T> : IList<T> where T:IComparable<T>
    {
        private ListItem<T> lastItem;       

        public LinkedList()
        {
            this.Count = 0;
            this.FirstItem = null;
            this.lastItem = null;

            //this.Clear();
        }

        #region Properties
        public ListItem<T> FirstItem { get; set; }

        public int Count { get; private set; }
        #endregion

        #region Public Methods
        public int IndexOf(T item)
        {
            int index = -1;
            int indexOfNext = 0;

            var nextItem = this.FirstItem;

            while (nextItem != null)
            {                
                if (nextItem.Value.CompareTo(item) == 0)
                {
                    index = indexOfNext;
                    break;
                }

                nextItem = nextItem.NextItem;
                indexOfNext++;
            }

            return index;
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    var message = string.Format("Invalid index. Must be 0 to {0}", this.Count - 1);
                    throw new ArgumentOutOfRangeException(message);
                }

                T itemValue = GetItemAt(index).Value;

                return itemValue;
            }

            set
            {
                if (index < 0 || index > this.Count)
                {
                    var message = string.Format("Invalid index. Must be 0 to {0}", this.Count);
                    throw new ArgumentOutOfRangeException(message);
                }

                // covers case of empty list and adding and element at index 0
                if (this.FirstItem == null)
                {
                    this.Add(value);
                }                  
                else
                {
                    var elemBefore = GetItemAt(index - 1);
                    var newItem = new ListItem<T>(value, elemBefore.NextItem);
                    elemBefore.NextItem = newItem;
                }
            }
        }       

        public void Add(T item)
        {
            var newItem = new ListItem<T>(item, null);

            if (this.FirstItem == null)
            {
                this.FirstItem = newItem;
                this.lastItem = newItem;
            }

            this.lastItem.NextItem = newItem;
            this.lastItem = newItem;
            this.Count++;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Passed index is ivalid. Can be 0 to {0}",
                        this.Count + 1));
            }

            this[index] = item;
            this.Count++;
        }      

        public void Clear()
        {
            this.FirstItem = null;
            this.lastItem = null;
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            bool containsItem = false;
            if (this.IndexOf(item) >= 0)
            {
                containsItem = true;
            }

            return containsItem;
        }

        public void CopyTo(T[] array, int arrayIndex = 0)
        {
            CheckCopyToInput(array, arrayIndex);

            foreach (var value in this)
            {
                array[arrayIndex] = value;
                arrayIndex++;
            }
        }
  
        /// <summary>
        /// Not implemented
        /// </summary>
        public bool IsReadOnly
        {
            get 
            {
                return false; 
                //throw new NotImplementedException();
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Passed index is ivalid. Can be 0 to {0}",
                        this.Count + 1));
            }

            if (index == 0)
            {
                this.RemoveFirst();
            }
            else if (index == this.Count - 1)
            {
                this.RemoveLast();
            }
            else
            {
                var previusItem = this.GetItemAt(index - 1);
                previusItem.NextItem = this.GetItemAt(index + 1);
            }

            this.Count--;
        }

        public bool Remove(T item)
        {
            bool removed = false;
            var indexOfItemToRemove = this.IndexOf(item);
            if (indexOfItemToRemove > 0)
            {
                this.RemoveAt(indexOfItemToRemove);
                removed = true;
            }

            return removed;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var nextItem = this.FirstItem;
            while (nextItem != null)
            {
                yield return nextItem.Value;
                nextItem = nextItem.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion

        #region Private Methods
        private ListItem<T> GetItemAt(int index)
        {
            var nextIndex = 0;
            var nextItem = this.FirstItem;
            while (nextItem != null)
            {
                if (nextIndex == index)
                {
                    break;
                }
                nextItem = nextItem.NextItem;
                nextIndex++;
            }

            return nextItem;
        }

        private void RemoveLast()
        {
            var elemBeforeLast = this.GetItemAt(this.Count - 2);
            this.lastItem = elemBeforeLast;
        }

        private void RemoveFirst()
        {            
            this.FirstItem = this.FirstItem.NextItem;
        }

        private void CheckCopyToInput(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("The specified array is null.");
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                var message = string.Format(
                    "Specified argument is out of the given array. Should be 0 to {0}", array.Length - 1);
                throw new ArgumentOutOfRangeException(message);
            }

            if (this.Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("The length of array is not enough to take new copied elements.");
            }
        }
        #endregion

    }
}
