using DSAPlayground.CoreDataStructure;
using DSAPlayground.Algorithms;

namespace DSAPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new QueueLinked<string>();

            Console.WriteLine("IsEmpty: " + queue.IsEmpty);
            queue.Enqueue("Donnie");
            queue.Enqueue("Raihan");
            queue.Enqueue("Zaki");

            Console.WriteLine("Queue: " + queue);
            Console.WriteLine("Peek: " + queue.Peek());
            Console.WriteLine("Dequeue: " + queue.Dequeue());
            Console.WriteLine("Queue after Dequeue: " + queue);

            queue.Clear();
            Console.WriteLine("Queue after Clear: " + queue);
            Console.WriteLine("IsEmpty: " + queue.IsEmpty);

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
