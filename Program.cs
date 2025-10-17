using DSAPlayground.Algorithms;
using DSAPlayground.AVL_Tree;
using DSAPlayground.CoreDataStructure;
using DSAPlayground.Tree_Data_Structure;

namespace DSAPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTreeDemo.Run();

            //Trie trie = new Trie();
            //trie.Insert("cat");
            //trie.Insert("car");
            //trie.Insert("cart");
            //trie.Insert("care");

            //Console.WriteLine(trie.Search("car"));       // True
            //Console.WriteLine(trie.Search("coaxal"));      // False
            //Console.WriteLine(trie.StartsWith("ca"));    // True
            //Console.WriteLine(trie.StartsWith("dog"));   // False

            //trie.Delete("cart");
            //Console.WriteLine(string.Join(", ", trie.GetWordsWithPrefix("ca"))); // cat, car, care

            //BinarySearchTree bst = new BinarySearchTree();
            //bst.Insert(50);
            //bst.Insert(30);
            //bst.Insert(70);
            //bst.Insert(20);
            //bst.Insert(40);
            //bst.Insert(60);
            //bst.Insert(80);

            //Console.WriteLine("In-order:");
            //bst.InOrderTraversal();     // 20 30 40 50 60 70 80

            //Console.WriteLine("Pre-order:");
            //bst.PreOrderTraversal();    // 50 30 20 40 70 60 80

            //Console.WriteLine("Post-order:");
            //bst.PostOrderTraversal();   // 20 40 30 60 80 70 50

            //Console.WriteLine("\nSearch for 60: " + bst.Search(60)); // True
            //Console.WriteLine("Search for 25: " + bst.Search(25)); // False

            //bst.Delete(50); // Deletes root with two children
            //bst.Delete(20); // Deletes leaf
            //bst.Delete(30); // Deletes node with one child

            //Console.WriteLine("In-order:");
            //bst.InOrderTraversal();     // 20 30 40 50 60 70 80
        }
    }

    public class Vehicle
    {
        private string _model;
        private string _make;

        public Vehicle(string model, string make)
        {
            _model = model;
            _make = make;
        }

        public override string ToString()
        {
            return $"({_model}, {_make})";
        }
    }
}
