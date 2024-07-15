using _08.CollectionHierarchy.Interfeces;

namespace _08.CollectionHierarchy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] addIndexes = new int[input.Length];
            int[] addRemoveIndexes = new int[input.Length];
            int[] myListIndexes = new int[input.Length];           

            int removeOperation = int.Parse(Console.ReadLine());

            string[] addRemoveRemoved = new string[removeOperation];
            string[] myListRemoved = new string[removeOperation];

            AddCollection add = new();
            AddRemoveCollection addRemove = new();
            MyList mylist = new();

            for (int i = 0; i < input.Length; i++)
            {    
                addIndexes[i] = add.Add(input[i]);
                addRemoveIndexes[i] = addRemove.Add(input[i]);
                myListIndexes[i] = mylist.Add(input[i]);
            }
            for (int i = 0;i < removeOperation; i++)
            {
                addRemoveRemoved[i] = addRemove.Remove();
                myListRemoved[i] = mylist.Remove();
            }
            Console.WriteLine(string.Join(" ", addIndexes));
            Console.WriteLine(string.Join(" ", addRemoveIndexes));
            Console.WriteLine(string.Join(" ", myListIndexes));
            Console.WriteLine(string.Join(" ", addRemoveRemoved));
            Console.WriteLine(string.Join(" ", myListRemoved));
        }
    }
}
