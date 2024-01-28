namespace _07.MaxSequenceОfEqualElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToCheck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int equalElements = 1;
            int elementsLength = 1;
            
            int curentEqualElements = 0;
            int curentElementsLength = 1;

            for (int i = numbersToCheck.Length - 2; i >= 0; i--)
            {

                if (numbersToCheck[i] == numbersToCheck[i + 1])
                {

                    curentEqualElements = numbersToCheck[i];
                    curentElementsLength++;

                    if (curentElementsLength >= elementsLength)
                    {
                        equalElements = curentEqualElements;
                        elementsLength = curentElementsLength;
                    }
                    
                }
                else 
                {
                    curentElementsLength = 1;
                }
            }

            int[] output = new int[elementsLength];
            Array.Fill(output, equalElements);
            Console.WriteLine(string.Join(" ", output));
        }
    }
}

