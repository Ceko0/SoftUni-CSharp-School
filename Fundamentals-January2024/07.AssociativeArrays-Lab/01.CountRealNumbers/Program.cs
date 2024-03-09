using System.Collections.Specialized;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SortedDictionary<int , int> numbersCount = new SortedDictionary<int, int>();
            foreach (int number in numbers)
            {
                if(!numbersCount.ContainsKey(number ))
                {
                    numbersCount.Add(number , 0);
                }
                numbersCount[number]++;
            }

            foreach (var number in numbersCount)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
