namespace _02.AsciiSumator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char startingSymbol = char.Parse(Console.ReadLine());
            char endingSymbol = char.Parse(Console.ReadLine());
            string textToCheck = Console.ReadLine();
            int startingValue = startingSymbol;
            int endingValue = endingSymbol;
            int biggerValue = Math.Max(startingValue, endingValue);
            int smallerValue = Math.Min(startingValue, endingValue);
            int sum = 0;
            foreach (var letter in textToCheck)
            {
                if (letter < biggerValue && letter > smallerValue)
                {
                    sum += letter;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
