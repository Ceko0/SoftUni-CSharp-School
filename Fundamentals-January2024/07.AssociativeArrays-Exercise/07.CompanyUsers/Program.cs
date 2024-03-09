namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyEmployees = new Dictionary<string, List<string>>();

            string income = "";
            while ((income = Console.ReadLine()) != "End")
            {
                string[] information = income
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string companyName = information[0];
                string employeeId = information[1];

                if (!companyEmployees.ContainsKey(companyName))
                {
                    companyEmployees.Add(companyName, new List<string>());
                }

                if (!companyEmployees[companyName].Contains(employeeId))
                {
                    companyEmployees[companyName].Add(employeeId);
                }
            }

            foreach (var kvp in companyEmployees)
            {
                Console.WriteLine($"{kvp.Key}\n-- {string.Join("\n-- ", kvp.Value)}");
                
            }
        }
    }
}
