using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTable
{
    /// <summary>
    /// Add(key, value), Find(key)value, Remove( key), Count, 
    /// Clear(), this[], Keys. IEnumerable
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="Tvalue"></typeparam>
    public class HashTableMy<Tkey, Tvalue> : IEnumerable<KeyValuePair<Tkey, Tvalue>>
    {
        #region private fields
        private const int InitialArrayLength = 16;

        private const int PercentFilledToResize = 75;

        private LinkedList<KeyValuePair<Tkey, Tvalue>>[] hashArray;
        
        private int arrayLength;
        #endregion

        #region Contructors
        public HashTableMy()
        {
            this.arrayLength = InitialArrayLength;
            this.hashArray = new LinkedList<KeyValuePair<Tkey, Tvalue>>[this.arrayLength];
            this.Count = 0;
        }

        #endregion

        #region public methods
        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the first occurance found by the given key
        /// </summary>
        /// <param name="key">The key to search by</param>
        /// <returns>key value pair</returns>
        public KeyValuePair<Tkey, Tvalue> this[Tkey key]
        {
            get 
            {
                var hash = GetHash(key);
                if (this.hashArray[hash] == null)
                {
                    throw new ArgumentOutOfRangeException("The given key has a null value!");
                }
                return this.hashArray[hash].First.Value;
            }

            set 
            {
                var hash = GetHash(key);
                if (this.hashArray[hash] == null)
                {
                    throw new ArgumentOutOfRangeException("The given key has a null value!");
                }
                this.hashArray[hash].First.Value = value;
            }
        }

        /// <summary>
        /// Gets key value pair based on and integer index. ReadOnly
        /// </summary>
        /// <param name="i">Zero based index of array of all elements</param>
        /// <returns>Readonly member of array ofall elements</returns>
        public KeyValuePair<Tkey, Tvalue> this[int i]
        {
            get 
            {
                var arrayOfAllPairs = ToArray();

                return arrayOfAllPairs[i];
            }
        }
  

        /// <summary>
        /// Adds a pair of key and value to dictionary
        /// </summary>
        /// <param name="key">Key to add by</param>
        /// <param name="value">Value to add to key</param>
        public void Add(Tkey key, Tvalue value)
        {
            this.AddTo(key, value, this.hashArray);  
            this.Count++;
            this.CheckArray();
        }

        /// <summary>
        /// Removes the last added KeyValuePair with that key
        /// </summary>
        /// <param name="key">Key to find element by</param>
        public void Remove(Tkey key)
        {
            var hash = this.GetHash(key);
            if (this.hashArray[hash] == null)
            {
                throw new NullReferenceException("Trying to remove an nonexisting value");
            }
            this.hashArray[hash].RemoveLast();
            this.Count--;
        }

        /// <summary>
        /// Returns the last added element
        /// </summary>
        /// <param name="key">The key by which to search</param>
        /// <returns>True if found and value in the out parameter. 
        /// If it cannot find the value searched it puts the default literal for the specified type.</returns>
        public bool Find(Tkey key, out Tvalue outValue)
        {            
            var found = false;
            outValue = default(Tvalue);
            var hash = this.GetHash(key);
            if (this.hashArray[hash] != null)
            {
                outValue = this.hashArray[hash].Last.Value.Value;
                found = true;
            }
            
            return found;
        }

        /// <summary>
        /// Returns a collection of all keys in the hashset
        /// </summary>
        /// <returns>IEnumerable of all the keys</returns>
        public IEnumerable<Tkey> Keys()
        {
            var keys = new List<Tkey>();
            foreach (var item in this.hashArray)
            {
                if (item != null)
                {
                    keys.Add(item.First.Value.Key);
                }    
            }

            return keys;
        }

        /// <summary>
        /// Clears the hash table of all elements
        /// </summary>
        public void Clear()
        {
            this.hashArray = new LinkedList<KeyValuePair<Tkey, Tvalue>>[InitialArrayLength];
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            return new EnumeratorObject(this.hashArray);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns an array of all elements in the dictionary
        /// </summary>
        /// <returns>An array of KeyValuePairs</returns>
        public KeyValuePair<Tkey, Tvalue>[] ToArray()
        {
            var arrayOfAllPairs = new KeyValuePair<Tkey, Tvalue>[this.Count];
            var index = 0;
            foreach (var item in this)
            {
                arrayOfAllPairs[index] = item;
                index++;
            }
            return arrayOfAllPairs;
        }
        #endregion

        #region private methods
        private void CheckArray()
        {
            var filledCapacity = (double)this.Count / this.arrayLength * 100;
            if (filledCapacity > PercentFilledToResize)
            {
                this.ResizeArray();
            }
        }

        private void ResizeArray()
        {
            var newHashArray = new LinkedList<KeyValuePair<Tkey, Tvalue>>[this.arrayLength * 2];            
            this.arrayLength *= 2;
            foreach (var item in this)
	        {
		        this.AddTo(item.Key, item.Value, newHashArray);
	        }

            this.hashArray = newHashArray;
        }        
  
        private void AddTo(Tkey key,Tvalue value,LinkedList<KeyValuePair<Tkey,Tvalue>>[] hashSet)
        {
 	        var hash = GetHash(key);
            if (hashSet[hash] == null)
            {
                hashSet[hash] = new LinkedList<KeyValuePair<Tkey, Tvalue>>();
            }
            hashSet[hash].AddLast(new KeyValuePair<Tkey, Tvalue>(key, value));
            
        }

        private int GetHash(Tkey key)
        {
            var hash = Math.Abs(key.GetHashCode()) % this.arrayLength;
            return hash;
        }        
        #endregion

        #region private class
        private class EnumeratorObject: IEnumerator<KeyValuePair<Tkey,Tvalue>>
        {
            private LinkedList<KeyValuePair<Tkey, Tvalue>>[] hashSet;

            private object current;

            private int currentListIndex = -1;

            public EnumeratorObject(LinkedList<KeyValuePair<Tkey,Tvalue>>[] hashSet)
            {
                this.hashSet = hashSet;               
                this.current = null;
                this.currentListIndex = GetNextNonEpmtyListIndex();
            }           

            public KeyValuePair<Tkey, Tvalue> Current
            {
                get 
                {
                    var current = (LinkedListNode<KeyValuePair<Tkey, Tvalue>>)this.current;
                    return current.Value;
                }
            }

            public void Dispose()
            {
                this.Reset();
            }

            object System.Collections.IEnumerator.Current
            {
                get 
                { 
                    return this.Current; 
                }
            }

            public bool MoveNext()
            {
                bool movedToNext = false;

                if (this.current == null)
                {
                    this.current = this.GetFirstNonEpmtyObject();
                }
                else
                {
                    var current = (LinkedListNode<KeyValuePair<Tkey, Tvalue>>)this.current;
                    if (current.Next != null)
                    {
                        this.current = current.Next;                        
                    }
                    else
                    {
                        this.currentListIndex = this.GetNextNonEpmtyListIndex();
                        if (this.currentListIndex > -1)
                        {
                            this.current = this.hashSet[this.currentListIndex].First;
                        }
                        else
                        {
                            this.Reset();
                        }
                                              
                    }
                }

                if (this.current != null)
                {
                    movedToNext = true;
                }                        

                return movedToNext;
            }

            public void Reset()
            {
                this.current = null;
            }

            private int GetNextNonEpmtyListIndex()
            {
                int nextNonEmptyListIndex = -1;
                for (int i = this.currentListIndex + 1; i < this.hashSet.Length; i++)
                {
                    if (this.hashSet[i] != null)
                    {
                        nextNonEmptyListIndex = i;
                        break;
                    }
                }

                return nextNonEmptyListIndex;
            }

            private object GetFirstNonEpmtyObject()
            {
                object first = null;

                for (int i = 0; i < this.hashSet.Length; i++)
                {
                    if (this.hashSet[i] != null)
                    {
                        first = this.hashSet[i].First;
                        break;
                    }
                }

                return first;
            }
        }
        #endregion
    }
}
