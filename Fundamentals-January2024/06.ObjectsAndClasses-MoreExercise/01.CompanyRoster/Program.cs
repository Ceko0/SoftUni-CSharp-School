namespace _01.CompanyRoster
{
    class Employee
    {
        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;

        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public override string ToString()
        {
            return $"{Name} {Salary}\n";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            Dictionary<string, List<Employee>> employees = new Dictionary<string, List<Employee>>();

            for (int i = 0; i < counter; i++)
            {
                string[] information = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (!employees.ContainsKey(information[2]))
                {

                    employees.Add(information[2], new List<Employee>());
                }

                employees[information[2]].Add(new Employee(information[0], decimal.Parse(information[1])));

            }

            Dictionary<string, decimal> salary = new Dictionary<string, decimal>();

            foreach (KeyValuePair<string, List<Employee>> kvp in employees)
            {
                decimal sum = 0;
                foreach (var person in kvp.Value)
                {
                    sum += person.Salary;
                }
                sum /= kvp.Value.Count;
                salary.Add(kvp.Key, sum);
            }

            decimal maxSalary = salary.Values.Max();

            string maxDepartment = salary.FirstOrDefault(x => x.Value == maxSalary).Key;

            Console.WriteLine($"Highest Average Salary: {maxDepartment}");
            var maxDepartmentEmployees = employees
                .FirstOrDefault(x => x.Key == maxDepartment).Value
                .OrderByDescending(x => x.Salary);
            Console.WriteLine(string.Join(" ", maxDepartmentEmployees).Trim());
        }
    }
}
