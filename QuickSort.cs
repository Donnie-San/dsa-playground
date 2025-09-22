using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground
{
    public static class QuickSort
    {
        public static void Sort(int[] arr)
        {
            Quicksort(arr, 0, arr.Length - 1);
        }

        public static void Quicksort(int[] arr, int low, int high)
        {
            if (low < high) {
                int pivotIdx = Partition(arr, low, high);
                Quicksort(arr, low, pivotIdx - 1);
                Quicksort(arr, pivotIdx + 1, high);
            }
        }

        public static int Partition(int[] arr, int low, int high)
        {
            Random rand = new Random();
            int pivotIndex = rand.Next(low, high + 1);
            (arr[low], arr[pivotIndex]) = (arr[pivotIndex], arr[low]);

            int pivot = arr[low];
            int leftwall = low;

            for (int i = low + 1; i <= high; i++) {
                if (arr[i] < pivot) {
                    leftwall++;
                    (arr[i], arr[leftwall]) = (arr[leftwall], arr[i]);
                }
            }

            (arr[low], arr[leftwall]) = (arr[leftwall], arr[low]);
            return leftwall;
        }
    }
}
