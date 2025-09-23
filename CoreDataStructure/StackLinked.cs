using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class StackLinked<T>
    {
        private Node<T> _head;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _head is null;

        public void Push(T val)
        {
            Node<T> newNode = new Node<T>(val) {
                Next = _head
            };
            _head = newNode;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Stack Underflow");

            T returnVal = _head.Val;
            _head = _head.Next;
            _count--;
            return returnVal;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Stack Undeflow");

            return _head.Val;
        }

        public void Clear()
        {
            _head = null;
            _count = 0;
        }

        public override string ToString()
        {
            var current = _head;
            var items = new List<string>();
            
            while (current != null) {
                items.Add(current.Val?.ToString()?? "null");
                current = current.Next;
            }

            return $"Head -> {string.Join(" -> ", items)}";
        }
    }
}
