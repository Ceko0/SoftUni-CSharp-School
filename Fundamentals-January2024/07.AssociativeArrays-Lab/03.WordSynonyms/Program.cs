namespace _03.WordSynonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string , List<string>> dictionary = new Dictionary<string , List<string>>();
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, new List<string>());
                    
                }
                dictionary[word].Add(synonym);
            }

            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} - {string.Join(", ", kvp.Value)}");
            }
        }
    }
}
