using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class QueueLinked<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _head is null;

        public void Enqueue(T val)
        {
            var newNode = new Node<T>(val);
            
            if (IsEmpty) {
                _head = _tail = newNode;
            } else {
                _tail.Next = newNode;
                _tail = newNode;
            }
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Queue Underflow");

            T returnVal = _head.Val;
            if (_head.Next is null) {
                _head = _tail = null;
            } else {
                _head = _head.Next;
            }
            _count--;

            return returnVal;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Queue Underflow");

            return _head.Val;
        }

        public void Clear()
        {
            _head = _tail = null;
            _count = 0;
        }

        public override string ToString()
        {
            var curr = _head;
            var items = new List<string>();

            while (curr != null) {
                items.Add(curr.Val?.ToString() ?? "null");
                curr = curr.Next;
            }

            return $"Head -> {string.Join(" -> ", items)}"
            ;
        }
    }
}
