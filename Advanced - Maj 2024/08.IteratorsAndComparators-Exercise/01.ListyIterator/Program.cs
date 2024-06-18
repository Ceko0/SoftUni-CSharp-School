using System.Linq.Expressions;

namespace _01.ListyIterator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            ListyIterator<string> listyIterator = null;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (commands[0])
                {
                    case "Create":
                        listyIterator = new(commands.Skip(1).ToArray());
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            if(listyIterator != null)
                            listyIterator.Print();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(listyIterator.PrintAll());
                        break;
                }

            }
        }
    }
}
