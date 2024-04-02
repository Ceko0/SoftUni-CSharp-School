using System.Text;

namespace _03.HeroRecruitment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroesList = new Dictionary<string, List<string>>();

            string income = String.Empty;
            while ((income = Console.ReadLine()) != "End")
            {
                string[] commands = income
                    .Split()
                    .ToArray();

                string command = commands[0];
                string heroName = commands[1];
                switch (command)
                {
                    case "Enroll":
                        if (heroesList.ContainsKey(heroName)) Console.WriteLine($"{heroName} is already enrolled.");
                        else
                        {
                            heroesList.Add(heroName, new List<string>());
                        }
                        break;
                    case "Learn":
                        string spellToAdd = commands[2];
                        bool spellCheck = false;
                        if (!heroesList.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                            continue;
                        }
                        foreach (string spell in heroesList[heroName])
                        {
                            if (spell == spellToAdd)
                            {
                                Console.WriteLine($"{heroName} has already learnt {spellToAdd}.");
                                spellCheck = true;
                                break;
                            }
                        }
                        if (!spellCheck) heroesList[heroName].Add(spellToAdd);
                        break;
                    case "Unlearn":
                        spellToAdd = commands[2];
                        spellCheck = false;
                        if (!heroesList.ContainsKey(heroName))
                        {
                            Console.WriteLine($"{heroName} doesn't exist.");
                            continue;
                        }
                        foreach (string spell in heroesList[heroName])
                        {
                            if (spell == spellToAdd)
                            {
                                heroesList[heroName].Remove(spellToAdd);
                                spellCheck = true;
                                break;
                            }
                        }
                        if (!spellCheck) Console.WriteLine($"{heroName} doesn't know {spellToAdd}.");
                        break;
                }
            }

            Console.WriteLine("Heroes:");

            foreach (var (name, spellBook) in heroesList)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"== {name}: ");
                foreach (string spell in spellBook)
                {
                    sb.Append($"{spell}, ");
                }

                Console.WriteLine(sb.ToString().Trim(',', ' '));
            }
        }
    }
}
