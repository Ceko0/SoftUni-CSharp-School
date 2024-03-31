using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            string barcodeVerification = @"(\@[\#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])(\@[\#]+)";
            string digitFinder = @"(?<digit>[0-9]+)";
            
            for (int i = 0; i < counter; i++)
            {
                string barcode = Console.ReadLine();
                MatchCollection matches = Regex.Matches(barcode, barcodeVerification);
                if (matches.Count != 0)
                {
                    MatchCollection digit = Regex.Matches(matches[0].Groups["barcode"].Value  , digitFinder);
                    if (digit.Count != 0)
                    {
                        string number = String.Empty;
                        foreach (Match d in digit)
                        {
                            number += d.Value;
                        }
                        Console.WriteLine($"Product group: {number}");
                    }
                    else Console.WriteLine("Product group: 00");
                }
                else Console.WriteLine("Invalid barcode");
            }
        }
    }
}
