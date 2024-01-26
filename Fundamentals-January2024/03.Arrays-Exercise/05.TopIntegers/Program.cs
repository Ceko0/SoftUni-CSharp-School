namespace _05.TopIntegers
{
    internal class Program
    {
        static void Main()
        {
            int[] integersToCheck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < integersToCheck.Length; i++)
            {
                bool isBiger = true;
                for (int j = integersToCheck.Length - 1; j > i; j--)
                {
                    if (integersToCheck[i] <= integersToCheck[j])
                    {
                        isBiger = false;
                    }
                }

                if (isBiger)
                {
                    Console.Write($"{integersToCheck[i]} ");
                }
            }
        }
    }
}
