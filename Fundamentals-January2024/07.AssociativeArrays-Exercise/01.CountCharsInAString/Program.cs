namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] letters = Console.ReadLine().ToCharArray();

            Dictionary<char, int> characters = new Dictionary<char, int>();

            foreach (char c in letters)
            {
                if (c == ' ')
                {
                    continue;
                }
                if (!characters.ContainsKey(c))
                {
                    characters.Add(c,0);
                }

                characters[c]++;
            }

            foreach (var kvp in characters)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}
