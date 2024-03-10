namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            int str = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '>')
                {
                    str += text[i + 1] - '0';
                    continue;
                }
                if (str != 0)
                {
                    text = text.Remove(i, 1);
                    str--;
                    i--;
                }
            }

            Console.WriteLine(text);
        }
    }
}