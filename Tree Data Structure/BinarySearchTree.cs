using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.Tree_Data_Structure
{
    public class BinarySearchTree
    {
        private TreeNode _root;

        public BinarySearchTree()
        {
            _root = null;
        }

        public void Insert(int value)
        {
            _root = InsertRec(_root, value);
        }

        private TreeNode InsertRec(TreeNode node, int value)
        {
            if (node == null) return new TreeNode(value);

            if (value < node.Value)
                node.left = InsertRec(node.left, value);
            else if (value > node.Value)
                node.right = InsertRec(node.right, value);

            return node;
        }

        public bool Search(int value)
        {
            return SearchRec(_root, value);
        }

        private bool SearchRec(TreeNode node, int value)
        {
            if (node == null) return false;
            if (node.Value == value) return true;

            return value < node.Value ? SearchRec(node.left, value) : SearchRec(node.right, value);
        }

        public void Delete(int value)
        {
            _root = DeleteRec(_root, value);
        }

        private TreeNode DeleteRec(TreeNode node, int value)
        {
            if (node == null) return null;

            if (value < node.Value)
                node.left = DeleteRec(node.left, value);
            else if (value > node.Value)
                node.right = DeleteRec(node.right, value);
            else {
                // Case 1: No child
                if (node.left == null && node.right == null) {
                    return null;
                }

                // Case 2: One child
                if (node.left == null)
                    return node.right;
                if (node.right == null)
                    return node.left;

                // Case 3: Two children
                TreeNode successor = FindMin(node.right);
                node.Value = successor.Value;
                node.right = DeleteRec(node.right, successor.Value);
            }

            return node;
        }

        private TreeNode FindMin(TreeNode node)
        {
            while (node.left != null)
                node = node.left;
            return node;
        }

        public void InOrderTraversal()
        {
            InOrderRec(_root);
        }

        private void InOrderRec(TreeNode node)
        {
            if (node == null) return;

            InOrderRec(node.left);
            Console.Write(node.Value + " ");
            InOrderRec(node.right);
        }

        public void PreOrderTraversal()
        {
            PreOrder(_root);
        }

        private void PreOrder(TreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            PreOrder(node.left);
            PreOrder(node.right);
        }

        public void PostOrderTraversal()
        {
            PostOrderRec(_root);
        }

        private void PostOrderRec(TreeNode node)
        {
            if (node == null) return;

            PostOrderRec(node.left);
            PostOrderRec(node.right);
            Console.Write(node.Value + " ");
        }
    }
}
