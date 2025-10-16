using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.Tree_Data_Structure
{
    public class TreeNode
    {
        public int Value;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            Value = value;
            left = null;
            right = null;
        }
    }
}
