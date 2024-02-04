namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstIncome = char.Parse(Console.ReadLine());
            char secondIncome = char.Parse(Console.ReadLine());

            simbulBetweenTwoChars(firstIncome, secondIncome);
        }

        static void simbulBetweenTwoChars(char firstIncome, char secondIncome)
        {
            if ((int)firstIncome > (int)secondIncome)
            {
                char current = firstIncome;
                firstIncome = secondIncome;
                secondIncome = current;
            }

            for (int i = firstIncome + 1; i < secondIncome; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
