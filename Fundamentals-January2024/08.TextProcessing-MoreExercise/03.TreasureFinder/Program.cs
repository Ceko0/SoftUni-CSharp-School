using System.Text;

namespace _03.TreasureFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] key = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string input = "";
            StringBuilder sb = new StringBuilder();
            while ((input = Console.ReadLine()) != "find")
            {
                int keyCounter = 0;
                foreach (var letter in input)
                {
                    if (keyCounter % key.Length == 0) keyCounter = 0;
                    keyCounter = KeyCounter(sb, letter, key, keyCounter);
                }

                string message = sb.ToString();
                int startIndexTreasure = message.IndexOf('&');
                int endIndexTreasure = message.LastIndexOf('&');
                int startIndexLocation = message.IndexOf('<');
                int endIndexLocation = message.IndexOf('>');
                string treasure = message.Substring(startIndexTreasure + 1, endIndexTreasure - startIndexTreasure - 1);
                string location = message.Substring(startIndexLocation + 1, endIndexLocation - startIndexLocation - 1);

                Console.WriteLine($"Found {treasure} at {location}");
                sb.Clear();
            }
        }

        private static int KeyCounter(StringBuilder sb, char letter, int[] key, int keyCounter)
        {
            char symbol = (char)(letter - key[keyCounter++]);
            sb.Append(symbol);
            return keyCounter;
        }
    }
}
