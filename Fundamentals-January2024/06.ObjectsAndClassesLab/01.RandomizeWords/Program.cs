namespace _01.RandomizeWords
{
    internal class Program
    {
        static void Main()
        {
            List<string> words = Console.ReadLine()
                .Split()
                .ToList();
                Random random = new Random();

            for (int i = 0; i < words.Count; i++)
            {
                int lastIndex = words.Count;
                int randomNumber = random.Next( lastIndex);
                string wordToMove = words[i];
                words[i] = words[randomNumber];
                words[randomNumber] = wordToMove;
                
            }

            Console.WriteLine(string.Join(Environment.NewLine , words));
        }
    }
}
