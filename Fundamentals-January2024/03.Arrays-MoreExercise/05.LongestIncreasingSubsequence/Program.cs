using System.Runtime.CompilerServices;

namespace _05.LongestIncreasingSubsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integersNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = integersNumbers.Length -1;
            int[] len = new int[n];

            for (int i = 0; i < n; i++)
            {
                len[i] = 1

            }
        }
    }
}