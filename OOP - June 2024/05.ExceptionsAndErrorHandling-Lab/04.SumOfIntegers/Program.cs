namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');

            int sum = 0;

            foreach (var number in numbers)
            {
                try
                {
                    sum += int.Parse(number);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"The element '{number}' is in wrong format!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{number}' is out of range!");
                }
                finally
                { 
                    Console.WriteLine($"Element '{number}' processed - current sum: {sum}");
                }
                
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}
