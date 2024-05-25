namespace _01.CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new();
            
            double[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < input.Length ; i++)
            {
                if (!numbers.ContainsKey(input[i]))
                {
                    numbers.Add(input[i], 0);
                }
                numbers[input[i]]++;
            }
            foreach ( (double number , int count ) in numbers)
            {
                Console.WriteLine($"{number} - {count} times");
            }
        }
    }
}
