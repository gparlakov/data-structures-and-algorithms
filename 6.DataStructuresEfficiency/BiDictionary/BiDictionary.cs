﻿using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace BiDictionaryImplementation
{
    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> keyOneCollection;
        private MultiDictionary<K2, T> keyTwoCollection;

        public BiDictionary()
        {
            this.keyOneCollection = new MultiDictionary<K1, T>(true);
            this.keyTwoCollection = new MultiDictionary<K2, T>(true);
        }

        public void Add(K1 key1, K2 key2, T value)
        {
            this.keyOneCollection.Add(key1, value);
            this.keyTwoCollection.Add(key2, value);
        }

        public ICollection<T> FindAllByFirstKey(K1 key)
        {
            var found = this.keyOneCollection[key];
            return found;
        }

        public ICollection<T> FindAllBySecondKeyKey(K2 key)
        {
            var found = this.keyTwoCollection[key];
            return found;
        }

        public KeyValuePair<string, ICollection<T>> FindAll(K1 key1, K2 key2)
        {
            var resultFromKeyOne = this.FindAllByFirstKey(key1);
            var resultFromKeyTwo = this.FindAllBySecondKeyKey(key2);

            var intersection = this.GetIntersection(resultFromKeyOne, resultFromKeyTwo);

            return intersection;
        }

        private KeyValuePair<string, ICollection<T>> GetIntersection(
            ICollection<T> resultFromKeyOne, 
            ICollection<T> resultFromKeyTwo)
        {
            throw new NotImplementedException();
        }

       
    }
}
