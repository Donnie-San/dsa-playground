using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAPlayground.Algorithms
{
    // This algorithm is for solving the max sum of subarray of size k EFFECIENTLY.
    // You can check a similar problem here: https://leetcode.com/problems/maximum-average-subarray-i/description/

    public class FixedSlidingWindow
    {
        public static int MaxSum(int[] nums, int k)
        {
            int sum = 0;
            for (int i = 0; i < k; i++) {
                sum += nums[i];
            }
            int maxSum = sum;

            for (int i = k; i < nums.Length; i++) {
                sum += nums[i] - nums[i - k];
                maxSum = Math.Max(maxSum, sum);
            }

            return maxSum;
        }
    }
}
