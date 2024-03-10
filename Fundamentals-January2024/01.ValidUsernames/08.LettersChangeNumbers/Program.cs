namespace _08.LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] income = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            decimal result = 0;
            foreach (var currentIncome in income)
            {
                char firstLetter = currentIncome[0];
                char lastLetter = currentIncome[currentIncome.Length - 1];
                decimal number = decimal.Parse(currentIncome.Substring(1, currentIncome.Length - 2));
                decimal currentResult = 0;
                if (char.IsUpper(firstLetter))
                {
                    currentResult += number / (firstLetter - 'A' + 1);
                }
                else
                {
                    currentResult += number * (firstLetter - 'a' + 1);
                }

                if (char.IsUpper(lastLetter))
                {
                    currentResult -= (lastLetter - 'A' + 1);
                }
                else
                {
                    currentResult += (lastLetter - 'a' + 1);
                }
                result += currentResult;
            }
            Console.WriteLine($"{result:f2}");
        }
    }
}
