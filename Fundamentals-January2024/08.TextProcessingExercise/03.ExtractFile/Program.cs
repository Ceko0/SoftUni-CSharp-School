namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();
            int lastIndex = income.LastIndexOf("\\");
            string output = income.Substring(lastIndex + 1);
            string[] fileInfo = output.Split(".");
            Console.WriteLine($"File name: {fileInfo[0]}");
            Console.WriteLine($"File extension: {fileInfo[1]}");
        }
    }
}