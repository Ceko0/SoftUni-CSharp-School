using System;
using System.Reflection;
using System.Text;
using System.Threading.Channels;

namespace PlayCatch
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int exeptionCounter = 0;
            while (exeptionCounter < 3)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = input[0];
                try
                {
                    switch (action)
                    {
                        case "Replace":
                            Replace(input, ref numbers);
                            break;
                        case "Print":
                            Print(input, numbers);
                            break;
                        case "Show":
                            Show(input, numbers);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    exeptionCounter++;
                }
                catch
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exeptionCounter++;
                }
            }
            Console.WriteLine(string.Join(", " , numbers).TrimEnd());
        }
        private static void Show(string[] input, List<int> number)
        {
            int index = int.Parse(input[1]);
            RangeCheck(number, index);
            Console.WriteLine(number[index]);
        }
        private static void Print(string[] input, List<int> number)
        {
            int startIndex = int.Parse(input[1]);
            int endIndex = int.Parse(input[2]);
            RangeCheck(number, startIndex);
            RangeCheck(number, endIndex);

            StringBuilder sb = new();
            for (int i = startIndex; i < endIndex+1; i++)
            {
                sb.Append($"{number[i]}, ");
            }
            Console.WriteLine(sb.ToString().TrimEnd(new char[]{',', ' '}));
        }
        private static void Replace(string[] input, ref List<int> number)
        {
            int index = int.Parse(input[1]);
            RangeCheck(number, index);
            int element = int.Parse(input[2]);
            number.RemoveAt(index);
            number.Insert(index , element);
        }
        private static void RangeCheck(List<int> number, int index)
        {
            if (index < 0 || index >= number.Count) throw new ArgumentException("The index does not exist!");
        }
    }
}
