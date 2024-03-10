namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int maxLength = Math.Max(arguments[0].Length, arguments[1].Length);
            int minLength = Math.Min(arguments[0].Length, arguments[1].Length);
            int totalSum = 0;
            for (int i = 0; i < maxLength; i++)
            {
                if (arguments[0].Length == minLength)
                {
                    if (i < arguments[0].Length)
                    {
                        totalSum += arguments[0][i] * arguments[1][i];
                    }
                    else
                    {
                        totalSum += arguments[1][i];
                    }
                }
                else
                {
                    if (i < arguments[1].Length)
                    {
                        totalSum += arguments[0][i] * arguments[1][i];
                    }
                    else
                    {
                        totalSum += arguments[0][i];
                    }
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}