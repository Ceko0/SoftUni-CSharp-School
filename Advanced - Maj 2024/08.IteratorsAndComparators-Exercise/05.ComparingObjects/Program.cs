namespace _05.ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Person> people = new();
            while((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new(info[0], int.Parse(info[1]), info[2]);
                people.Add(person);
            }
            int personIndex = int.Parse(Console.ReadLine())-1;
            Person PersonToCompare = people[personIndex];

            int matchers = 0;
            int equal = 0;

            foreach(Person person in people)
            {
                if (person.CompareTo(PersonToCompare) == 0) matchers++;
                else equal++;
            }
            if (matchers > 1)
            {
                Console.WriteLine($"{matchers} {equal} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
