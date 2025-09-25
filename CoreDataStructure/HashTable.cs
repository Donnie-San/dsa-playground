using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class HashTable
    {
        private const double LoadFactorThreshold = 0.75;

        private int _count = 0;
        private int _size = 10;
        private LinkedList<KeyValuePair<string, int>>[] _buckets;

        public HashTable()
        {
            _buckets = new LinkedList<KeyValuePair<string, int>>[_size];
            for (int i = 0; i < _size; i++) {
                _buckets[i] = new LinkedList<KeyValuePair<string, int>>();
            }
        }

        private int GetIndex(string key, int size)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % size);
        }

        public void Put(string key, int val)
        {
            if ((_count + 1.0) / _size > LoadFactorThreshold)
                Resize();

            var idx = GetIndex(key, _size);
            var bucket = _buckets[idx];

            foreach (var pair in bucket) {
                if (pair.Key == key) {
                    bucket.Remove(pair);
                    _count--;
                    break;
                }
            }

            bucket.AddLast(new KeyValuePair<string, int>(key, val));
            _count++;
        }

        public bool Remove(string key)
        {
            var idx = GetIndex(key, _size);
            var bucket = _buckets[idx];

            foreach (var pair in bucket) {
                if (pair.Key == key) {
                    bucket.Remove(pair);
                    _count--;
                    return true;
                }
            }

            return false;
        }

        public int? Get(string key)
        {
            var idx = GetIndex(key, _size);
            var bucket = _buckets[idx];

            foreach (var pair in bucket) {
                if (pair.Key == key)
                    return pair.Value;
            }

            return null;
        }

        private void Resize()
        {
            int newSize = _size * 2;
            var newBuckets = new LinkedList<KeyValuePair<string, int>>[newSize];
            for (int i = 0; i < newSize; i++) {
                newBuckets[i] = new LinkedList<KeyValuePair<string, int>>();
            }

            foreach (var bucket in _buckets) {
                foreach (var pair in bucket) {
                    int newIdx = GetIndex(pair.Key, newSize);
                    newBuckets[newIdx].AddLast(pair);
                }
            }

            _buckets = newBuckets;
            _size = newSize;
        }
    }
}
