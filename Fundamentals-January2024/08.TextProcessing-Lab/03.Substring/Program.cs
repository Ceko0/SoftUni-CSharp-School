namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letterToRemove = Console.ReadLine();
            string currentLetter = Console.ReadLine();
            while (currentLetter.Contains(letterToRemove))
            {
                currentLetter = currentLetter.Replace(letterToRemove, string.Empty);
            }

            Console.WriteLine(currentLetter);
        }
    }
}
