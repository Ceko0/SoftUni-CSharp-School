namespace _06.ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            int div = int.Parse(Console.ReadLine());

            Func<int ,int , bool> divided = (number, divided) => number % div != 0;

            numbers = numbers.Where(number => divided(number ,div)).ToList();
                     
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
