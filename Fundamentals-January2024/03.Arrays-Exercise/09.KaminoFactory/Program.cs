namespace _09.KaminoFactory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            int[] dna = new int[5];
            int oneLength = 0;
            int onePosition = int.MaxValue;
            int oneSum = 0;
            int entryDna = 0;
            int counter = 0;
            while (true)
            {
                counter++;
                string income = Console.ReadLine();
                if (income == "Clone them!") break;

                int[] currentDna = income
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                int currentOneLength = 0;
                int currentOnePosition = 0;
                int currentOneSum = 0;
                int previousNumber = 0;
                for (int i = currentDna.Length - 1; i >= 0; i--)
                {
                    if (currentDna[i] == 1)
                    {
                        currentOneSum++;
                        if (previousNumber == currentDna[i])
                        {
                            currentOnePosition = i;
                            currentOneLength++;
                        }
                    }
                    previousNumber = currentDna[i];
                }

                if (currentOneLength > oneLength)
                {
                    oneLength = currentOneLength;
                    onePosition = currentOnePosition;
                    oneSum = currentOneSum;
                    dna = currentDna;
                    entryDna = counter;
                }
                else if (currentOneLength == oneLength) 
                {
                    if(currentOnePosition < onePosition )
                    {
                        oneLength = currentOneLength;
                        onePosition = currentOnePosition;
                        oneSum = currentOneSum;
                        dna = currentDna;
                        entryDna = counter;
                    }
                    else if (currentOnePosition == onePosition)
                    {
                        if(currentOneSum > oneSum)
                        {
                            oneLength = currentOneLength;
                            onePosition = currentOnePosition;
                            oneSum = currentOneSum;
                            dna = currentDna;
                            entryDna = counter;
                        }
                    }
                }

            }
            int dnaSum = 0;
            for (int i = 0; i < dna.Length; i++)
            {
                if (dna[i] == 1)
                {
                    dnaSum += dna[i];
                }
            }
            Console.WriteLine($"Best DNA sample {entryDna} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" " , dna));
        }
    }
}
