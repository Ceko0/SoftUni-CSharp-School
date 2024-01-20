namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                for (int j = 0; j < counter; j++)
                {
                    for (int k = 0; k < counter; k++)
                    {
                        char one = (char) (97 + i);
                        char two = (char) (97 + j);
                        char three = (char) (97 + k);
                        Console.WriteLine($"{one}{two}{three}");
                    }
                }
            }
        }
    }
}
