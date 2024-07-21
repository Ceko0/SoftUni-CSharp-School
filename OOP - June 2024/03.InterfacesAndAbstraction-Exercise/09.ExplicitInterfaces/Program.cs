using ExplicitInterfaces.interfeces;
using ExplicitInterfaces.Models;

namespace ExplicitInterfaces
{
    public static class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<IPerson> persons = new();
            List<IResident> residents = new();
            while ((input = Console.ReadLine()) != "End")
            {
                string[] citizenInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = citizenInfo[0];
                string country = citizenInfo[1];
                int age = int.Parse(citizenInfo[2]);
                Citizen citizen = new Citizen(name, country, age);
                persons.Add(citizen);
                residents.Add(citizen);
            }
            for (int i = 0; i < persons.Count; i++)
            {
                Console.WriteLine(persons[i].GetName());
                Console.WriteLine(residents[i].GetName());
            }

        }
    }
}
