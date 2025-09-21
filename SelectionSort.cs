using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground
{
    public static class SelectionSort
    {
        public static void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++) {
                int min_idx = i;

                for (int j = i + 1; j < arr.Length; j++) {
                    if (arr[j] < arr[min_idx]) {
                        min_idx = j;
                    }
                }

                if (min_idx != i) {
                    int temp = arr[i];
                    arr[i] = arr[min_idx];
                    arr[min_idx] = temp;
                }
            }
        }
    }
}
