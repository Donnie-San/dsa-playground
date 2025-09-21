
namespace DSAPlayground
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 3, 11, 5, 2, 7, 2, 6, 10, 1, 15, 9, 14 };

            SelectionSort.Sort(arr);
            foreach (int num in arr) {
                Console.WriteLine(num);
            }
            Console.WriteLine(BinarySearch.Search(arr, 15));
        }
    }
}
