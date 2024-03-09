namespace _02.OldestFamilyMember
{
    class Family
    {
        public List<Person> FamilyMembers { get; set; } = new List<Person>();

        public void AddMember(string name , int age)
        {
            FamilyMembers.Add(new Person(name , age));
        }

        public static Person GetOldestMember(List<Person> FamilyMembers)
        {
            Person oldestPerson = null;

            foreach (var person in FamilyMembers)
            {
                if (oldestPerson == null || person.Age > oldestPerson.Age)
                {
                    oldestPerson = person;
                }
            }

            return oldestPerson;

        }
    }

    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
    internal class Program
    {
        static void Main()
        {
            Family family = new Family();
            int people = int.Parse(Console.ReadLine());
            for (int i = 0; i < people; i++)
            {
                string[] information = Console.ReadLine()
                    .Split()
                    .ToArray();
                family.AddMember(information[0], int.Parse(information[1]));
            }

            Console.WriteLine($"{Family.GetOldestMember(family.FamilyMembers)}");
        }
    }
}
