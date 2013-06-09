using System;
using System.Collections.Generic;
using System.Linq;
using HashTable;

namespace HashedSetImplementation
{
    /// <summary>
    /// Add(T), Find(T), Remove(T), Count, Clear(), union and intersect.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashedSet<T>:IEnumerable<T>
    {
        private HashTableMy<T, bool> hashedSet;
        
        public HashedSet()
        {
            this.hashedSet = new HashTableMy<T,bool>();
        }

        public int Count 
        {
            get 
            { 
                return this.hashedSet.Count; 
            }
        }

        public void Clear()
        {
            this.hashedSet = new HashTableMy<T, bool>();
        }

        /// <summary>
        /// Adds a value in the set if it is not already added
        /// </summary>
        /// <param name="value">True if added. False if value is already in the set</param>
        public bool Add(T value)
        {
            bool added = false;            
            if (!this.Find(value))
            {
                this.hashedSet.Add(value, true);
                added = true;
            }

            return added;
        }

        /// <summary>
        /// Removes an element
        /// </summary>
        /// <param name="value">The element to remove</param>
        /// <returns>True if element is found and removed. False if there is no sush element</returns>
        public bool Remove(T value)
        {
            bool removed = false;
            
            if (Find(value))
            {
                this.hashedSet.Remove(value);
                removed = true;
            }

            return removed;
        }

        /// <summary>
        /// Searches for given element
        /// </summary>
        /// <param name="value">element to search for</param>
        /// <returns>True if found and false otherwise</returns>
        public bool Find(T value)
        {
            bool found = false;
            bool bufferValue ;
            if (this.hashedSet.Find(value, out bufferValue))
            {
                found = true;
            }

            return found;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.hashedSet)
            {
                yield return item.Key;
            }
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            var intersection = new HashedSet<T>();
            foreach (var item in this)
            {
                if (other.Find(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }

        public HashedSet<T> Union(HashedSet<T> other)
        {
            var union = new HashedSet<T>();
            foreach (var item in this)
            {
                union.Add(item);
            }

            foreach (var item in other)
            {
                if (!union.Find(item))
                {
                    union.Add(item);
                }
            }

            return union;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
