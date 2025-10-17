using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.AVL_Tree
{
    public static class AVLTreeDemo
    {
        public static void Run()
        {
            var tree = new AVLTree();

            Console.WriteLine("Inserting values: 50, 30, 70, 20, 40, 60, 80");
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(70);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(60);
            tree.Insert(80);

            Console.WriteLine("\nInOrder Traversal (should be sorted):");
            tree.InOrderTraversal(); // Expected: 20 30 40 50 60 70 80

            Console.WriteLine("\nPreOrder Traversal:");
            tree.PreOrderTraversal();

            Console.WriteLine("\nostOrder Traversal:");
            tree.PostOrderTraversal();

            Console.WriteLine("\nSearching for 40:");
            Console.WriteLine(tree.Search(40) ? "✅ Found" : "❌ Not Found");

            Console.WriteLine("Searching for 90:");
            Console.WriteLine(tree.Search(90) ? "✅ Found" : "❌ Not Found");

            Console.WriteLine("\nDeleting 70");
            tree.Delete(70);

            Console.WriteLine("InOrder Traversal after deletion:");
            tree.InOrderTraversal(); // Expected: 20 30 40 50 60 80

            Console.WriteLine("\nDeleting 30");
            tree.Delete(30);

            Console.WriteLine("InOrder Traversal after deletion:");
            tree.InOrderTraversal(); // Expected: 20 40 50 60 80

            Console.WriteLine("\nDeleting 50");
            tree.Delete(50);

            Console.WriteLine("InOrder Traversal after deletion:");
            tree.InOrderTraversal(); // Expected: 20 40 60 80

            Console.WriteLine("\nAll tests completed.");
        }
    }
}
