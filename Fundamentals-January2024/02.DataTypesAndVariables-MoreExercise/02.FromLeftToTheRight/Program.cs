namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
             
            for (int j = 0; j < counter; j++)
            {
                string income = Console.ReadLine();

                long bigestNumber = long.MinValue;

                string[] words = income.Split(' ');

                foreach (string word in words)
                {          
                    long currentNumber = long.Parse(word);
                    if (currentNumber >= bigestNumber)
                    { 
                        bigestNumber = currentNumber;
                    }
                }
                long sum = 0;
                for (int i = 0; i < bigestNumber.ToString().Length; i++)
                {
                    if (bigestNumber.ToString()[i] == '-')
                    {
                        continue;
                    }
                    else
                    {
                        sum += bigestNumber.ToString()[i] - '0';
                    }
                }                    
                Console.WriteLine(sum);
            }
        }
    }
}
