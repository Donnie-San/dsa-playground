using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground
{
    public static class MergeSort
    {
        public static int[] Sort(int[] arr)
        {
            if (arr.Length == 1) {
                return arr;
            }

            int mid = arr.Length / 2;

            int[] arr1 = arr.Take(mid).ToArray();
            int[] arr2 = arr.Skip(mid).ToArray();

            arr1 = Sort(arr1);
            arr2 = Sort(arr2);

            return Merge(arr1, arr2);
        }

        private static int[] Merge(int[] arrA, int[] arrB)
        {
            int[] arrC = new int[arrA.Length + arrB.Length];

            int i = 0, j = 0, k = 0;

            while (j < arrA.Length && k < arrB.Length) {
                if (arrA[j] < arrB[k]) {
                    arrC[i++] = arrA[j++];
                } else {
                    arrC[i++] = arrB[k++];
                }
            }

            while (j < arrA.Length) {
                arrC[i++] = arrA[j++];
            }

            while (k < arrB.Length) {
                arrC[i++] = arrB[k++];
            }

            return arrC;
        }
    }
}
