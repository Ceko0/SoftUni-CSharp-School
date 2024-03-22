using System.Text.RegularExpressions;

namespace _4.Santa_sSecretHelper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());

            string input = String.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string decryptedMessage = new string(input.Select(c => (char)(c - key)).ToArray());
               
                string pattern = @"(?:\@)(?<name>[A-z][a-z]+)([^\@\-\!\:\>])*(?:\!)(?<type>[G|N])(?:\!)";
                MatchCollection matches = Regex.Matches(decryptedMessage, pattern);
                foreach (Match match in matches)
                {
                    if (match.Groups["type"].Value == "G")
                    {
                        Console.WriteLine(match.Groups["name"].Value);
                    }
                }
            }
        }
    }
}
