namespace _09.PokemonDon_tGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int sumValue = 0;
            while (true)
            {
                if (integerList.Count == 0)
                {
                    Console.WriteLine(sumValue);
                    break;
                }

                int numberOnIndex = 0;
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    numberOnIndex = integerList[0];
                    integerList.RemoveAt(0);
                    sumValue += numberOnIndex;
                    integerList.Insert(0, integerList[integerList.Count-1]);
                    listManipulation(ref integerList, numberOnIndex);
                    continue;
                }

                if (index >= integerList.Count)
                {
                    numberOnIndex = integerList[integerList.Count - 1];
                    integerList.RemoveAt(integerList.Count - 1);
                    sumValue += numberOnIndex;
                    integerList.Add(integerList[0]);
                    listManipulation(ref integerList, numberOnIndex);
                    continue;
                }
                numberOnIndex = integerList[index];
                sumValue += numberOnIndex;
                integerList.RemoveAt(index);
                listManipulation(ref integerList, numberOnIndex);
            }
        }

        private static void listManipulation(ref List<int> integerList, int numberOnIndex)
        {
            for (int i = 0; i < integerList.Count; i++)
            {
                if (integerList[i] <= numberOnIndex) integerList[i] += numberOnIndex;
                else integerList[i] -= numberOnIndex;
            }
        }
    }
}
/*
4 5 3
1 
1
0

5 10 6 3 5
2
4
1
1
3
0
0

 */