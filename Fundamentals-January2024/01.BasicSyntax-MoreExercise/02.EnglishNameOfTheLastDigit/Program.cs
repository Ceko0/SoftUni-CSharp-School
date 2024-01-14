using System.Threading.Channels;
using System.Xml;

namespace _02.EnglishNameOfTheLastDigit
{
    internal class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            englishSpeeling(number);
        }
        static void englishSpeeling(int income)
        {
            string output = "";
            int needdigit = income % 10;
            output = needdigit == 0 ? "zero" : needdigit == 1 ? "one" : needdigit == 2 ? "two" : needdigit == 3 ? "three" : needdigit == 4 ? "four" : needdigit == 5 ? "five" : needdigit == 6 ? "six" : needdigit == 7 ? "seven" : needdigit == 8 ? "eight" : needdigit == 9 ? "nine" : "error";
            Console.WriteLine(output);
        }
    }
}
