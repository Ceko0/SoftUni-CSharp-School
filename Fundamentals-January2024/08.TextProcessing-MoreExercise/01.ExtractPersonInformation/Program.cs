namespace _01.ExtractPersonInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            for (int i = 0; i < counter; i++)
            {
                string input = Console.ReadLine();

                int nameStart = input.IndexOf('@');
                int nameEnd = input.IndexOf('|');
                int ageStart = input.IndexOf('#');
                int ageEnd = input.IndexOf('*');

                string name = input.Substring(nameStart+1, nameEnd - nameStart-1).Trim();
                string age = input.Substring(ageStart+1, ageEnd - ageStart-1).Trim();
                Console.WriteLine($"{name} is {age} years old.");
            }
        }
    }
}
