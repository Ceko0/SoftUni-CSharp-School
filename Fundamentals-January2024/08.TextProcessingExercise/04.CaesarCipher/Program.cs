using System.Text;

namespace _04.CaesarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            foreach (var currentChar in text)
            {
                char newChar = (char)((int)currentChar + 3);
                sb.Append(newChar);
            }

            Console.WriteLine(sb);
        }
    }
}