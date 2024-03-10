using System.Text;

namespace _06.ReplaceRepeatingChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < text.Length; i++)
            {
                char previousLetter = text[i - 1];
                if (previousLetter != text[i])
                {
                    sb.Append(previousLetter);
                }
            }
            sb.Append(text[text.Length - 1]);
            Console.WriteLine(sb.ToString());
        }
    }
}