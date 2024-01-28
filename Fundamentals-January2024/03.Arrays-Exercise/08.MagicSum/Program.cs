namespace _08.MagicSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToCheck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int equalNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbersToCheck.Length; i++)
            {
                for (int j = numbersToCheck.Length - 1; j > i ; j--)
                {
                    if (numbersToCheck[i] + numbersToCheck[j] == equalNumber)
                    {
                        Console.WriteLine($"{numbersToCheck[i]} {numbersToCheck[j]}");
                    }
                }
                
            }
        }
    }
}
