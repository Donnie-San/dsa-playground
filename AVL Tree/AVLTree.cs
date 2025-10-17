using DSAPlayground.CoreDataStructure;
using DSAPlayground.Tree_Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.AVL_Tree
{
    public class AVLTree
    {
        private AVLTreeNode _root;

        public void Insert(int value)
        {
            _root = InsertRec(_root, value);
        }

        private AVLTreeNode InsertRec(AVLTreeNode node, int value)
        {
            if (node == null)
                return new AVLTreeNode(value);

            if (value < node.Value)
                node.Left = InsertRec(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertRec(node.Right, value);
            else
                return node;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);
            if (balance > 1 && value < node.Left.Value)
                return RightRotate(node); // Left Left
            if (balance < -1 && value > node.Right.Value)
                return LeftRotate(node); // Right Right

            if (balance > 1 && value > node.Left.Value) {
                node.Left = LeftRotate(node.Left); // Left Right
                return RightRotate(node);
            }
            if (balance < -1 && value < node.Right.Value) {
                node.Right = RightRotate(node.Right); // Right Left
                return LeftRotate(node);
            }

            return node;
        }

        private AVLTreeNode LeftRotate(AVLTreeNode node)
        {
            AVLTreeNode rightChild = node.Right;
            AVLTreeNode rightGrandChild = rightChild.Left;

            rightChild.Left = node;
            node.Right = rightGrandChild;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            rightChild.Height = 1 + Math.Max(GetHeight(rightChild.Left), GetHeight(rightChild.Right));

            return rightChild;
        }

        private AVLTreeNode RightRotate(AVLTreeNode node)
        {
            AVLTreeNode leftChild = node.Left;
            AVLTreeNode leftGrandChild = leftChild.Right;

            leftChild.Right = node;
            node.Left = leftGrandChild;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
            leftChild.Height = 1 + Math.Max(GetHeight(leftChild.Left), GetHeight(leftChild.Right));

            return leftChild;
        }

        public bool Search(int value)
        {
            return SearchRec(_root, value);
        }

        private bool SearchRec(AVLTreeNode node, int value)
        {
            if (node == null) return false;

            if (value == node.Value)
                return true;
            else if (value < node.Value) {
                return SearchRec(node.Left, value);
            } else
                return SearchRec(node.Right, value);
        }

        public void Delete(int value)
        {
            _root = DeleteRec(_root, value);
        }

        private AVLTreeNode DeleteRec(AVLTreeNode node, int value)
        {
            if (node == null)
                return null;

            if (value < node.Value)
                node.Left = DeleteRec(node.Left, value);
            else if (value > node.Value)
                node.Right = DeleteRec(node.Right, value);
            else {
                if (node.Left == null || node.Right == null) {
                    node = (node.Left != null) ? node.Left : node.Right;
                } else {
                    AVLTreeNode successor = FindMin(node.Right);
                    node.Value = successor.Value;
                    node.Right = DeleteRec(node.Right, successor.Value);
                }
            }

            if (node == null)
                return null;

            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            int balance = GetBalance(node);

            // Left Left
            if (balance > 1 && GetBalance(node.Left) >= 0)
                return RightRotate(node);

            // Right Right
            if (balance < -1 && GetBalance(node.Right) <= 0)
                return LeftRotate(node);

            // Left Right
            if (balance > 1 && GetBalance(node.Left) < 0) {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left
            if (balance < -1 && GetBalance(node.Right) > 0) {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }

        private int GetHeight(AVLTreeNode node)
        {
            return node == null ? 0 : node.Height;
        }

        private int GetBalance(AVLTreeNode node)
        {
            return node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }

        public void InOrderTraversal()
        {
            InOrderRec(_root);
        }

        private AVLTreeNode FindMin(AVLTreeNode node)
        {
            AVLTreeNode current = node;
            while (current.Left != null)
                current = current.Left;
            return current;
        }

        private void InOrderRec(AVLTreeNode node)
        {
            if (node == null) return;

            InOrderRec(node.Left);
            Console.Write(node.Value + " ");
            InOrderRec(node.Right);
        }

        public void PreOrderTraversal()
        {
            PreOrder(_root);
        }

        private void PreOrder(AVLTreeNode node)
        {
            if (node == null) return;

            Console.Write(node.Value + " ");
            PreOrder(node.Left);
            PreOrder(node.Right);
        }

        public void PostOrderTraversal()
        {
            PostOrderRec(_root);
        }

        private void PostOrderRec(AVLTreeNode node)
        {
            if (node == null) return;

            PostOrderRec(node.Left);
            PostOrderRec(node.Right);
            Console.Write(node.Value + " ");
        }
    }
}
