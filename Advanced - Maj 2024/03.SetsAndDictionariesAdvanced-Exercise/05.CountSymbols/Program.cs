namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string someText = Console.ReadLine();

            SortedDictionary<char, int> charValues = new();

            foreach(char character in someText)
            {
                if (!charValues.ContainsKey(character))
                {
                    charValues.Add(character, 0);
                }
                charValues[character]++;
            }
            foreach((char character, int value) in charValues)
            {
                Console.WriteLine($"{character}: {value} time/s");
            }
        }
    }
}
