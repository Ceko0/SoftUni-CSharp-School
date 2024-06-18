namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> newList = new(1 ,2 ,3, 4);
            newList.Add(5);
            newList.Add(6);
            newList.Add(7);
            newList.Add(8);
            newList.Add(9);
            Console.WriteLine("All elements");
            newList.ForEach(x => { Console.WriteLine(x); });

            Console.WriteLine($"remove 1-st index, element ->  {newList.RemoveAt(1)}");
            Console.WriteLine("print elements");
            newList.ForEach(x => { Console.WriteLine(x); });

            Console.WriteLine($"contains 5 {newList.Contains(5)}");
            Console.WriteLine($"contains 11 {newList.Contains(11)}");
            Console.WriteLine("swap 1 and 2 elements ");
            newList.Swap(1, 2);
            Console.WriteLine("print elements");
            newList.ForEach(x => { Console.WriteLine(x); });
            Console.WriteLine("insert element 3 on index 0");
            newList.Insert(0, 3);
            Console.WriteLine("insert element 8 on index 3");
            newList.Insert(3, 8);
            Console.WriteLine("print elements");
            newList.ForEach(x => { Console.WriteLine(x); });



            Console.WriteLine("swap 1 and 11 elements ");
            newList.Swap(1, 11);


        }
    }
}
