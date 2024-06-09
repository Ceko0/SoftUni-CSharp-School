namespace _11.TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string , int , bool> assciSumCheck = (name , number) 
                => name.Sum(x=>x) >= number;
            Func<string[], Func<string, int, bool>,int , string> takeFirstName = (names, assciSumCheck , number)
                => names.FirstOrDefault(x => assciSumCheck(x , number ));

            int number = int.Parse(Console.ReadLine()); 
            string[] names = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Console.WriteLine(takeFirstName(names , assciSumCheck , number));
        }
    }
}
