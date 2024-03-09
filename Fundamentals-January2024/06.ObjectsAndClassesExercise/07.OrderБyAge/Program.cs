namespace _07.OrderБyAge
{
    class People
    {
        public People(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string income;
            List<People> listOfPeoples = new List<People>();
            while ((income = Console.ReadLine()) != "End")
            {
                List<string> information = income
                    .Split()
                    .ToList();
                string personName = information[0];
                int personId = int.Parse(information[1]);
                int personAge = int.Parse(information[2]);
                foreach (People person in listOfPeoples.OrderBy(x => x .Age))
                {
                    if (person.Id == personId)
                    {
                        person.Name = personName;
                        person.Age = personAge;
                        continue;
                    }
                }
                People currentPerson = new People(personName, personId, personAge);
                listOfPeoples.Add(currentPerson);
            }


            foreach (People person in listOfPeoples.OrderBy(x => x.Age))
            {
                Console.WriteLine(person);
            }
        }
    }
}
