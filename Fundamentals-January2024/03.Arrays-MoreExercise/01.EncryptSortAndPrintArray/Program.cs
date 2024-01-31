namespace _01.EncryptSortAndPrintArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStrings = int.Parse(Console.ReadLine());

            string[] strings = new string[numberOfStrings];
            int[] stringValue = new int[numberOfStrings];
            for (int i = 0; i < numberOfStrings; i++)
            {
                string income = Console.ReadLine();
                strings[i] = income;
                for (int j = 0; j < income.Length; j++)
                {
                    if (income[j] == 'a' || income[j] == 'e' || income[j] == 'i' || income[j] == 'o' || income[j] == 'u' || income[j] == 'A' || income[j] == 'E' || income[j] == 'I' || income[j] == 'O' || income[j] == 'U')
                    {
                        int charValue = (char)income[j];
                        stringValue[i] += charValue * income.Length;
                    }
                    else 
                    {
                        int charValue = (char)income[j];
                        stringValue[i] += charValue / income.Length;
                    }
                    
                }
                
            }
            stringValue = stringValue.OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join("\r\n" , stringValue));
        }
    }
}
