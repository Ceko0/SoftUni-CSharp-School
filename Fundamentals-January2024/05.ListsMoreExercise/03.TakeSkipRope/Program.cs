namespace _03.TakeSkipRope
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string income = Console.ReadLine();

            int[] numbers = income
                .Where(char.IsDigit)
                .Select(c => int.Parse(c.ToString()))
                .ToArray();

            string[] nonNumbers = income
                .Where(c => !char.IsDigit(c))
                .Select(c => c.ToString())
                .ToArray();

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            string text = "";
            foreach (var word in nonNumbers)
            {
                text += word;
            }
            
            string output = "";
            for (int i = 0; i < takeList.Count; i++)
            {
                if (text.Length <= takeList[i])
                {
                    output += text;
                    break;
                }
                output += text.Substring(0, takeList[i]);
                text = text.Remove(0, takeList[i]);
                text = text.Remove(0, skipList[i]);
            }

            Console.WriteLine(output);
        }
    }
}
