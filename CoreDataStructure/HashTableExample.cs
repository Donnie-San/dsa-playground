using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class HashTableExample
    {
        // Hash function examples: division, multiplication, universal hashing, dynamic perfect hashing, static perfect hashing

        private const int Size = 10;
        private LinkedList<KeyValuePair<string, int>>[] buckets;

        public HashTableExample()
        {
            buckets = new LinkedList<KeyValuePair<string, int>>[Size];
            for (int i = 0; i < Size; i++) {
                buckets[i] = new LinkedList<KeyValuePair<string, int>>();
            }
        }

        private int GetIndex(string key)
        {
            int hash = key.GetHashCode();
            return Math.Abs(hash % Size);
        }

        public void Put(string key, int value)
        {
            int index = GetIndex(key);
            var bucket = buckets[index];

            foreach (var pair in bucket) {
                if (pair.Key == key) {
                    bucket.Remove(pair);
                    break;
                }
            }

            bucket.AddLast(new KeyValuePair<string, int>(key, value));
        }

        public int? Get(string key)
        {
            int index = GetIndex(key);
            var bucket = buckets[index];

            foreach (var pair in bucket) {
                if (pair.Key == key)
                    return pair.Value;
            }

            return null;
        }

        public bool Remove(string key)
        {
            int index = GetIndex(key);
            var bucket = buckets[index];

            foreach (var pair in bucket) {
                if (pair.Key == key) {
                    bucket.Remove(pair);
                    return true;
                }
            }

            return false;
        }
    }
}
