namespace _07.RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string letterToRepeat = Console.ReadLine();
            int repeats = int.Parse(Console.ReadLine());

            Console.WriteLine(LetterRepeater(letterToRepeat , repeats));
        }

        static string LetterRepeater(string? letterToRepeat, int repeats)
        {
            string repeatedLetter = "";
            for (int i = 0; i < repeats; i++)
            {
                repeatedLetter += letterToRepeat;
            }
            return repeatedLetter;
        }
    }
}
