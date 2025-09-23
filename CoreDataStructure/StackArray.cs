using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class StackArray<T>
    {
        private T[] _items;
        private int _top;

        public int Count => _top;
        public bool IsEmpty => _top == 0;

        public StackArray(int capacity = 16)
        {
            _items = new T[capacity];
            _top = 0;
        }

        public void Push(T item)
        {
            if (_top == _items.Length)
                Resize();

            _items[_top++] = item;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Stack Underflow");

            return _items[--_top];
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Error: Stack Underflow");

            return _items[_top - 1];
        }

        public void Clear()
        {
            _items = new T[16];
            _top = 0;
        }

        private void Resize()
        {
            Array.Resize(ref _items, _items.Length * 2);
        }

        public override string ToString()
        {
            var activeItems = _items.Take(_top);
            return $"{string.Join(", ", activeItems)} (Top)";
        }
    }
}
