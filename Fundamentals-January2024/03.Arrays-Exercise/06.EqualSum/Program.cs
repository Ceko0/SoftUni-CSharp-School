namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersToCheck = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool itswrong = false;
            if (numbersToCheck.Length <= 1)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < numbersToCheck.Length; i++)
            {
                int rightSum = 0;

                for (int j = i + 1; j < numbersToCheck.Length; j++)
                {

                    rightSum += numbersToCheck[j];
                }

                int leftSum = 0;

                for (int j = i - 1; j >= 0; j--)
                {
                    leftSum += numbersToCheck[j];
                }


                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    itswrong = true;
                    break;
                }
            }
            if (!itswrong)
            {
                Console.WriteLine("no");
            }

            //if (numbersToCheck.Length == 1) Console.WriteLine("0");
            //else 
            //{
            //    int index = 0;
            //    int leftSum = 0;

            //    for (int i = 0; i < numbersToCheck.Length-2; i++)
            //    {

            //           leftSum += numbersToCheck[i];
            //        int rightSum = 0;

            //        for (int j = i+2; j < numbersToCheck.Length; j++)
            //        {

            //            rightSum += numbersToCheck[j];

            //            if (leftSum == rightSum)
            //            {
            //                index = i+1; 
            //                break;
            //            }

            //        }                    
            //    }

            //    if (index != 0)
            //    {
            //        Console.WriteLine(index);
            //    }
            //    else
            //    {
            //        Console.WriteLine("no");
            //    }
            //}
        }
    }
}
