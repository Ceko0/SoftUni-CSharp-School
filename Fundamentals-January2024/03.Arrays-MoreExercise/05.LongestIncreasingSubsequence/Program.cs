using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    class Program
    {
        static List<int> LongestIncreasingSubsequence(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return new List<int>();

            int n = nums.Length;
            int[] lisLengths = new int[n];
            int[] prevIndices = new int[n];

            Array.Fill(lisLengths, 1);
            Array.Fill(prevIndices, -1);

            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j] && lisLengths[i] < lisLengths[j] + 1)
                    {
                        lisLengths[i] = lisLengths[j] + 1;
                        prevIndices[i] = j;
                    }
                }
            }

            int maxLength = lisLengths.Max();
            int maxIndex = Array.IndexOf(lisLengths, maxLength);

            List<int> lis = new List<int>();
            while (maxIndex != -1)
            {
                lis.Add(nums[maxIndex]);
                maxIndex = prevIndices[maxIndex];
            }

            lis.Reverse();
            return lis;
        }

        static void Main(string[] args)
        {
            int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            List<int> lis = LongestIncreasingSubsequence(nums);
            foreach (int num in lis)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }

}