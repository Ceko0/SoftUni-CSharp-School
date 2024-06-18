using System.Text;

namespace _04.Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lake stones = new(Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(string.Join(", ",stones).TrimEnd());
        }
    }
}
