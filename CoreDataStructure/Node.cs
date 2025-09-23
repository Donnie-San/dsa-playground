using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.CoreDataStructure
{
    public class Node<T>
    {
        public T Val { get; }
        public Node<T> Next { get; set; }

        public Node(T val)
        {
            Val = val;
            Next = null;
        }

        public override string ToString()
        {
            return $"{Val}";
        }
    }
}
