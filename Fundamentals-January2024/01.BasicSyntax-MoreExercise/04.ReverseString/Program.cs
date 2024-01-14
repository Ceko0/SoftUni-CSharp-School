namespace _04.ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toRevers = Console.ReadLine();
            string outPut = Reverse(toRevers);
            Console.WriteLine(outPut);
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
            
        }
    }
}
