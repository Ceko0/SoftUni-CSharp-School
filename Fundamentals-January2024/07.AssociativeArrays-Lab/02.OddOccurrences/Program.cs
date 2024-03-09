namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] letters = Console.ReadLine()
                .Split()
                .ToArray();
            Dictionary<string , int> oddLetters = new Dictionary<string, int>();
            foreach (var word in letters)
            {
                string wolerWord = word.ToLower();
                if (!oddLetters.ContainsKey(wolerWord))
                {
                    oddLetters.Add(wolerWord, 0);
                }
                oddLetters[wolerWord]++;
            }

            foreach (var word in oddLetters)
            {
                if (word.Value % 2 != 0)
                {
                    Console.Write(word.Key + " ");
                }    
            }
        }
    }
}
