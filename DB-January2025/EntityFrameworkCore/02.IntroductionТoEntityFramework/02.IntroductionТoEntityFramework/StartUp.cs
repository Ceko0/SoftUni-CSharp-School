using System.Globalization;
using Microsoft.EntityFrameworkCore;
using SoftUni.Models;

namespace SoftUni
{
    using System.Net;
    using System.Text;

    using Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext dbContext = new SoftUniContext();
            //dbContext.Database.EnsureCreated();

            Console.WriteLine(RemoveTown(dbContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees.OrderBy(e => e.EmployeeId).ToList();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }
            return sb.ToString();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context.Employees
                .Include(e => e.Department)
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary.ToString("F2", CultureInfo.InvariantCulture)}"
                );
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            string newAddress = "Vitoshka 15";
            int TownId = 4;

            var employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            if (employee == null)
            {
                return "Employee with last name 'Nakov' not found!";
            }

            employee.Address = new Address()
            {
                AddressText = newAddress,
                TownId = TownId
            };
            context.SaveChanges();

            var addresses = context.Addresses
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .Select(a => a.AddressText)
                .ToList();

            return string.Join(Environment.NewLine, addresses);

        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employeeProjects = context.Employees
                 .Include(e => e.EmployeesProjects)
                 .ThenInclude(ep => ep.Project)
                 .Include(e => e.Manager)
                 .Take(10)
                 .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employeeProjects)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");
                foreach (var project in employee.EmployeesProjects)
                {
                    string startDate = project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = project.Project.EndDate.HasValue
                        ? project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                        : "not finished";

                    if (project.Project.StartDate.Year >= 2001 && project.Project.StartDate.Year <= 2003)
                        sb.AppendLine($"--{project.Project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Include(a => a.Town)
                .Include(a => a.Employees)
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Town.Name} - {address.Employees.Count} employees");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .FirstOrDefault(e => e.EmployeeId == 147);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine(project.Project.Name);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(d => d.Employees)
                .Include(d => d.Manager)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");
                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects.OrderBy(p => p.Name))
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e =>
                    e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services")
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName.ToLower(), "sa%"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }
            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            int projectIdToDelete = 2;

            var projectReferences = context.EmployeesProjects
                .Where(ep => ep.ProjectId == projectIdToDelete)
                .ToList();

            context.EmployeesProjects.RemoveRange(projectReferences);

            var projectToDelete = context.Projects.Find(projectIdToDelete);
            if (projectToDelete != null)
            {
                context.Projects.Remove(projectToDelete);
            }

            context.SaveChanges();

            var projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            return string.Join(Environment.NewLine, projectNames);

        }

        public static string RemoveTown(SoftUniContext context)
        {
            string townName = "Seattle";
            var town = context.Towns
                .FirstOrDefault(t => t.Name == townName);
            var addresses = context.Addresses
                .Where(a => a.Town.Name == townName)
                .ToList();
            foreach (var address in addresses)
            {
                var employee = context.Employees
                    .Where(e => e.Address == address);
                foreach (var emp in employee)
                {
                    emp.AddressId = null;
                }
            }
            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }
            context.Towns.Remove(town);
            context.SaveChanges();
            return $"{addresses.Count} addresses in Seattle were deleted";
        }

    }
}
