using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DSAPlayground.Tree_Data_Structure
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children = new Dictionary<char, TrieNode>();
        public bool IsEndOfWord = false;
    }

    public class Trie
    {
        private TrieNode _root;

        public Trie() {
            _root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode node = _root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c))
                    node.Children[c] = new TrieNode();
                node = node.Children[c];
            }
            node.IsEndOfWord = true;
        }

        public bool Search(string word)
        {
            TrieNode node = _root;
            foreach (char c in word) {
                if (!node.Children.ContainsKey(c))
                    return false;
                node = node.Children[c];
            }
            return node.IsEndOfWord;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode node = _root;
            foreach (char c in prefix) {
                if (!node.Children.ContainsKey(c))
                    return false;
                node = node.Children[c];
            }

            return true;
        }

        public List<string> GetWordsWithPrefix(string prefix)
        {
            List<string> results = new List<string>();

            TrieNode node = _root;
            foreach (char c in prefix) {
                if (!node.Children.ContainsKey(c))
                    return results;
                node = node.Children[c];
            }
            CollectWords(node, prefix, results);
            return results;
        }

        private void CollectWords(TrieNode node, string current, List<string> results)
        {
            if (node.IsEndOfWord == true)
                results.Add(current);

            foreach (var pair in node.Children) {
                CollectWords(pair.Value, current + pair.Key, results);
            }
        }

        public bool Delete(string word)
        {
            return DeleteRec(_root, word, 0);
        }

        private bool DeleteRec(TrieNode node, string word, int index)
        {
            if (index == word.Length) {
                if (!node.IsEndOfWord) return false;
                node.IsEndOfWord = false;
                return node.Children.Count == 0;
            }

            char c = word[index];
            if (!node.Children.ContainsKey(c)) return false;

            bool shouldDeleteChild = DeleteRec(node.Children[c], word, index + 1);

            if (shouldDeleteChild) {
                node.Children.Remove(c);
                return !node.IsEndOfWord && node.Children.Count == 0;
            }

            return false;
        }

    }
}
