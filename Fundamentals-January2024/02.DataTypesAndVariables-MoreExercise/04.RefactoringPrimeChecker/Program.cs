namespace _04.RefactoringPrimeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            for (int i = 2; i <= counter; i++)
            {
                bool isInGivenRange = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isInGivenRange = false;
                        break;
                    }
                }
                string output = isInGivenRange.ToString();
                Console.WriteLine($"{i} -> {output.ToLower()}");
            }

        }
    }
}
