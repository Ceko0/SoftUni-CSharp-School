namespace _01.Messaging
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine()
                .Split()
                .ToList();
            
            string text = Console.ReadLine();
            char[] charLetters = text.ToCharArray();
            List<string> letters = new List<string>();
            foreach (var currentChar in charLetters)
            {
                string letterToAdd = currentChar.ToString();
                letters.Add(letterToAdd);
            }
                
            string output = "";
            int currentLength = letters.Count;

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = int.Parse(numbers[i]);
                sum = DigitSum(sum);
                int currentIndex = (sum % letters.Count);
                output += letters[currentIndex];
               letters.RemoveAt(currentIndex);
                currentLength--;
            }

            
            Console.WriteLine(output);
        }

        private static int DigitSum(int currentNumbers)
        {
            int sum = 0;
            
            while(currentNumbers != 0)
            {
                sum += currentNumbers % 10;
                currentNumbers /= 10;
            }

            return sum;
        }
    }
}
