namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Trim())
                .ToArray();
            string text = Console.ReadLine();
            for (int i = 0; i < bannedWords.Length; i++)
            {
                string firstWord = replayseMaker(bannedWords[i]);
                text = text.Replace(bannedWords[i], firstWord);
            }
            Console.WriteLine(text);
        }

        private static string replayseMaker(string bannedWords)
        {
            string word = "";
            for (int i = 0; i < bannedWords.Length; i++)
            {
                word += "*";
            }

            return word;
        }
    }
}
