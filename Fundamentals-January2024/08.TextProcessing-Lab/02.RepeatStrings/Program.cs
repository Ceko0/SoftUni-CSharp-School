using System.Text;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] income = Console.ReadLine()
                .Split();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < income.Length; i++)
            {
                for (int j = 0; j < income[i].Length; j++)
                {
                    sb.Append(income[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
