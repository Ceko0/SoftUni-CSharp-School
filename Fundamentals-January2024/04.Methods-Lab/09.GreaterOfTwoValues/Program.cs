namespace _09.GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string typeToCheck = Console.ReadLine();
            string firstTocheck = Console.ReadLine();
            string secondTocheck = Console.ReadLine();
            Console.WriteLine(GetMax(typeToCheck, firstTocheck, secondTocheck));
        }
        static string GetMax(string type, string first, string second)
        {
            string maxValue = "";
            if (type == "int")
            {
                if (int.Parse(first) > int.Parse(second))
                {
                    maxValue = first;
                }
                else
                {
                    maxValue = second;
                }
            }
            else if (type == "char")
            {
                if (char.Parse(first) > char.Parse(second))
                {
                    maxValue = first;
                }
                else
                {
                    maxValue = second;
                }
            }
            else if (type == "string")
            {
                if (first[0] > second[0])
                {
                    maxValue = first;
                }
                else
                {
                    maxValue = second;
                }
            }

            return maxValue;
        } 
    }
}


/*
 int, char or string.
 */