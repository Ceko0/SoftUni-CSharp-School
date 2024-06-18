namespace _06.EqualityLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<Person> peopleHashSet = new();
            SortedSet<Person> peopleSortedSet = new();

            int personCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < personCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person currentPerson = new Person(info[0], int.Parse(info[1]));

                peopleHashSet.Add(currentPerson);
                peopleSortedSet.Add(currentPerson);
            }

            Console.WriteLine(peopleHashSet.Count);
            Console.WriteLine(peopleSortedSet.Count);

        }
    }
}
