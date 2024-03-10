using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.LongestIncreasingSubsequence
{
    public class Program
    {
        static double DistanceFromOrigin(int x, int y)
        {
            return Math.Sqrt(x * x + y * y);
        }

        static string LongerLine(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            double distance1 = DistanceFromOrigin(x1, y1) + DistanceFromOrigin(x2, y2);
            double distance2 = DistanceFromOrigin(x3, y3) + DistanceFromOrigin(x4, y4);

            // Compare the distances of both endpoints of each line segment to the origin
            if (distance1 >= distance2)
            {
                // If the lengths are equal, return the first line
                if (distance1 == distance2)
                    return $"({x1}, {y1})({x2}, {y2})";

                // Otherwise, ensure the first point of the first line is closer to the origin
                double distanceFirstLineFirstPoint = DistanceFromOrigin(x1, y1);
                double distanceFirstLineSecondPoint = DistanceFromOrigin(x2, y2);
                if (distanceFirstLineFirstPoint < distanceFirstLineSecondPoint)
                    return $"({x1}, {y1})({x2}, {y2})";
                else
                    return $"({x2}, {y2})({x1}, {y1})";
            }
            else
            {
                // Ensure the first point of the second line is closer to the origin
                double distanceSecondLineFirstPoint = DistanceFromOrigin(x3, y3);
                double distanceSecondLineSecondPoint = DistanceFromOrigin(x4, y4);
                if (distanceSecondLineFirstPoint < distanceSecondLineSecondPoint)
                    return $"({x3}, {y3})({x4}, {y4})";
                else
                    return $"({x4}, {y4})({x3}, {y3})";
            }
        }

        public static void Main(string[] args)
        {
            int x1 = int.Parse(Console.ReadLine());
            int y1 = int.Parse(Console.ReadLine());
            int x2 = int.Parse(Console.ReadLine());
            int y2 = int.Parse(Console.ReadLine());
            int x3 = int.Parse(Console.ReadLine());
            int y3 = int.Parse(Console.ReadLine());
            int x4 = int.Parse(Console.ReadLine());
            int y4 = int.Parse(Console.ReadLine());

            Console.WriteLine(LongerLine(x1, y1, x2, y2, x3, y3, x4, y4));
        }
    }
    //class Program
    //{
    //    static List<int> LongestIncreasingSubsequence(int[] nums)
    //    {
    //        if (nums == null || nums.Length == 0)
    //            return new List<int>();

    //        int n = nums.Length;
    //        int[] lisLengths = new int[n];
    //        int[] prevIndices = new int[n];

    //        Array.Fill(lisLengths, 1);
    //        Array.Fill(prevIndices, -1);

    //        for (int i = 1; i < n; i++)
    //        {
    //            for (int j = 0; j < i; j++)
    //            {
    //                if (nums[i] > nums[j] && lisLengths[i] < lisLengths[j] + 1)
    //                {
    //                    lisLengths[i] = lisLengths[j] + 1;
    //                    prevIndices[i] = j;
    //                }
    //            }
    //        }

    //        int maxLength = lisLengths.Max();
    //        int maxIndex = Array.IndexOf(lisLengths, maxLength);

    //        List<int> lis = new List<int>();
    //        while (maxIndex != -1)
    //        {
    //            lis.Add(nums[maxIndex]);
    //            maxIndex = prevIndices[maxIndex];
    //        }

    //        lis.Reverse();
    //        return lis;
    //    }

    //    static void Main(string[] args)
    //    {
    //        int[] nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    //        List<int> lis = LongestIncreasingSubsequence(nums);
    //        foreach (int num in lis)
    //        {
    //            Console.Write(num + " ");
    //        }
    //        Console.WriteLine();
    //    }
    //}

}