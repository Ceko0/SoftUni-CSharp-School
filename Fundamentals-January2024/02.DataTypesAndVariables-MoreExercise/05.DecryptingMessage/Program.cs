namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int linesCounter = int.Parse(Console.ReadLine());
            string output = "";

            for (int i = 0; i < linesCounter; i++)
            {
                char income = char.Parse(Console.ReadLine());
                output += (char)(income + key);
            }
            Console.WriteLine(output);
        }
    }
}
