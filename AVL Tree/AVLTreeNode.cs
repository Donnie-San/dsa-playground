using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.AVL_Tree
{
    public class AVLTreeNode
    {
        public int Value { get; set; }
        public AVLTreeNode? Left { get; set; }
        public AVLTreeNode? Right { get; set; }
        public int Height { get; set; }

        public AVLTreeNode(int value)
        {
            Value = value;
            Height = 1;
        }
    }
}
