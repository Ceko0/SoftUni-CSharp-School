namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersOne = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> numbersTwo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> combоList = new List<int>();

            if (numbersOne.Count > 0) combоList.Add(numbersOne[0]);
            if (numbersTwo.Count > 0) combоList.Add(numbersTwo[0]);
            int listSize = 0;
            if (numbersOne.Count > numbersTwo.Count) listSize = numbersOne.Count;
            else listSize = numbersTwo.Count;
            for (int i = 1; i < listSize; i++)
            {
                if (numbersOne.Count > i) combоList.Add(numbersOne[i]);
                if (numbersTwo.Count > i) combоList.Add(numbersTwo[i]);
            }
            Console.WriteLine(string.Join(" ", combоList));
        }
    }
}
/*
 
3 5 2 43 12 3 54 10 23
76 5 34 2 4 12
*/
