using System.Diagnostics.Metrics;

namespace BorderControl
{
    public class BorderControl
    {
        public static void Main()
        {
            List<IIdentifiable> citizenList = new();

            string input = string.Empty;
            while ((input = Console.ReadLine().TrimEnd()) != "End")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (info.Length == 2)
                {
                    IIdentifiable robot = new Robot(info[0], info[1]);
                    citizenList.Add(robot);
                }
                if (info.Length == 3)
                {
                    IIdentifiable citizen = new Citizen(info[0], int.Parse(info[1]), info[2]);
                    citizenList.Add(citizen);
                }
            }
            string endOfId = Console.ReadLine();

            List<IIdentifiable> orderedList = citizenList.Where(x => x.Id.EndsWith(endOfId)).ToList();

            foreach (IIdentifiable output in orderedList)
            {
                Console.WriteLine(output.Id);
            }
        }
    }
}
