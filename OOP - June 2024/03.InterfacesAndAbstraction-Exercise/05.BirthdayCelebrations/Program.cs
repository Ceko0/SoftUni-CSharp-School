using System.Diagnostics.Metrics;

namespace BorderControl
{
    public class BorderControl
    {
        public static void Main()
        {
            List<IIdentifiable> citizenList = new();
            List<IBirthdatable> birthdateList = new();

            string input = string.Empty;
            while ((input = Console.ReadLine().TrimEnd()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info[0] == "Robot")
                {
                    IIdentifiable robot = new Robot(info[1], info[2]);
                    citizenList.Add(robot);
                }
                else if (info[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(info[1], int.Parse(info[2]), info[3], info[4]);
                    citizenList.Add(citizen);
                    birthdateList.Add(citizen);
                }
                else if (info[0] == "Pet")
                {
                    Pet pet = new Pet(info[1], info[2]);
                    birthdateList.Add(pet);
                }
            }
            string endOfId = Console.ReadLine();

            List<IIdentifiable> orderedList = citizenList.Where(x => x.Id.EndsWith(endOfId)).ToList();
            List<IBirthdatable> orderedbirthdate = birthdateList.Where(x => x.Birthdate.EndsWith(endOfId)).ToList();

            foreach (IBirthdatable output in orderedbirthdate)
            {
                Console.WriteLine(output.Birthdate);
            }
        }
    }
}
