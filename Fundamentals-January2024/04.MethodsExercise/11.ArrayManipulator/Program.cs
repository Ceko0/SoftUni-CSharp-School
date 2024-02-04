using System;
/*
1 3 5 7 9 
exchange 1 
max odd    
min even 
first 2 odd 
last 2 even 
exchange 3 
end

 */

namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integerArray =Console.ReadLine()
                .Split(" " , StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            while(true) 
            {
                string[] incomeCommands = Console.ReadLine().Split().ToArray();

                switch (incomeCommands[0])
                {
                    case "end":
                        Console.WriteLine($"[{string.Join(", ", integerArray).Trim(',', ' ')}]");
                        return;
                    case "exchange":
                        ExchangeArray(int.Parse(incomeCommands[1]), integerArray);
                        break;
                    case "max":
                        PrintMaxEvenOrOdd(integerArray, incomeCommands);
                        break;
                    case "min":
                        PrintMinEvenOrOdd(integerArray, incomeCommands);
                        break;
                    case "first":
                        PrintFirstNElementEvenOrOdd(integerArray, incomeCommands);
                        break;
                    case "last":
                        PrintLastNElementEvenOrOdd(integerArray, incomeCommands);
                        break;
                }
            }
        }
        static int[] ExchangeArray(int incomeCommand , int[] integerArray)
        {
            if (incomeCommand >= 0 && incomeCommand < integerArray.Length)
            {
                for (int i = 0; i < incomeCommand + 1; i++)
                {
                    int digitToMove = integerArray[0];
                    for (int j = 1; j <= integerArray.Length - 1; j++)
                    {
                        integerArray[j - 1] = integerArray[j];
                    }
                    integerArray[integerArray.Length -1] = digitToMove;
                }
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
            return integerArray;
        }
        static void PrintMaxEvenOrOdd(int[] integerArray, string[] incomeCommands)
        {
            int indexPositionEven = -1;
            int indexPositionOdd = -1;
            int maxEvenNumber = int.MinValue;
            int maxOddNumber = int.MinValue;
            bool isMax = true;
            ReturnMinOrMaxEvenOrOddNumber(integerArray, ref maxEvenNumber, ref maxOddNumber,ref indexPositionEven,
                ref indexPositionOdd, isMax);
           
            EvenOrOddCheckAndPrint(incomeCommands, maxEvenNumber, indexPositionEven, maxOddNumber, indexPositionOdd);
        }
        private static void PrintMinEvenOrOdd(int[] integerArray, string[] incomeCommands)
        {
            int indexPositionEven = -1;
            int indexPositionOdd = -1;
            int minEvenNumber = int.MaxValue;
            int minOddNumber = int.MaxValue;
            bool isMax = false;
            ReturnMinOrMaxEvenOrOddNumber(integerArray, ref minEvenNumber, ref minOddNumber, ref indexPositionEven,
                ref indexPositionOdd, isMax);

            EvenOrOddCheckAndPrint(incomeCommands, minEvenNumber, indexPositionEven, minOddNumber, indexPositionOdd);
        }
        private static void PrintFirstNElementEvenOrOdd(int[] integerArray, string[] incomeCommands)
        {
            if (int.Parse(incomeCommands[1]) > integerArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            string evenNumbers = "";
            int evenCounter = 0;
            string oddNumbers = "";
            int oddCounter = 0;
            for (int i = 0; i < integerArray.Length; i++)
            {
                if (integerArray[i] % 2 == 0)
                {
                    if (evenCounter++ < int.Parse(incomeCommands[1])) evenNumbers +=$"{integerArray[i]}, ";
                        
                }
                else
                {
                    if (oddCounter++ < int.Parse(incomeCommands[1])) oddNumbers += $"{integerArray[i]}, ";
                }
            }

            PrintFirstOrLastEvenOrOddElement(incomeCommands, evenNumbers, oddNumbers);
        }
        private static void PrintLastNElementEvenOrOdd(int[] integerArray, string[] incomeCommands)
        {
            if (int.Parse(incomeCommands[1]) > integerArray.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            string evenNumbers = "";
            int evenCounter = 0;
            string oddNumbers = "";
            int oddCounter = 0;
            for (int i = integerArray.Length - 1 ; i >= 0; i--)
            {
                if (integerArray[i] % 2 == 0)
                { 
                    if (evenCounter++ < int.Parse(incomeCommands[1])) evenNumbers = $"{integerArray[i]}, " + evenNumbers;
                }
                else
                {
                    if (oddCounter++ < int.Parse(incomeCommands[1])) oddNumbers = $"{integerArray[i]}, " + oddNumbers;
                }
            }

            PrintFirstOrLastEvenOrOddElement(incomeCommands, evenNumbers, oddNumbers);
        }
        static void EvenOrOddCheckAndPrint(string[] incomeCommands, int maxEvenNumber, int indexPositionEven, int maxOddNumber,
            int indexPositionOdd)
        {
            if (incomeCommands[1] == "even")
            {
                if (maxEvenNumber == int.MaxValue)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(indexPositionEven);
                }
            }
            else
            {
                if (maxOddNumber == int.MaxValue)
                {
                    Console.WriteLine("No matches");
                }
                else
                {
                    Console.WriteLine(indexPositionOdd);
                }
            }
        }
        private static void PrintFirstOrLastEvenOrOddElement(string[] incomeCommands, string evenNumbers, string oddNumbers)
        {
            if (incomeCommands[2] == "even")
            {
                Console.WriteLine($"[{evenNumbers.Trim(',' , ' ')}]");
            }
            else
            {
                Console.WriteLine($"[{oddNumbers.Trim(',', ' ')}]");
            }
        }
        static int ReturnMinOrMaxEvenOrOddNumber(int[] integerArray, ref int EvenNumber,ref int OddNumber, ref
            int indexPositionEven, ref int indexPositionOdd, bool isMax)
        {

            for (int i = 0; i < integerArray.Length; i++)
            {
                if (integerArray[i] % 2 == 0)
                {
                    if (isMax)
                    {
                        if (integerArray[i] >= EvenNumber)
                        {
                            EvenNumber = integerArray[i];
                            indexPositionEven = i;
                        }
                    }
                    if (!isMax)
                    {
                        if (integerArray[i] <= EvenNumber)
                        {
                            EvenNumber = integerArray[i];
                            indexPositionEven = i;
                        }
                    }
                }
                else
                {
                    if (isMax)
                    {
                        if (integerArray[i] >= OddNumber)
                        {
                            OddNumber = integerArray[i];
                            indexPositionOdd = i;
                        }
                    }

                    if (!isMax)
                    {
                        if (integerArray[i] <= OddNumber)
                        {
                            OddNumber = integerArray[i];
                            indexPositionOdd = i;
                        }
                    }
                }
            }

            return 1;
        }
    }
}
