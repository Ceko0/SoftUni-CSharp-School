namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using ViewModels.Employee;
    using ViewModels.Team;

    public class EmployeeController(ElProAppDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> allEmployees = await dbContext
                .Employees
                .ToListAsync();

            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Create(string loginId)
        {
            EmployeeInputModel model = new EmployeeInputModel
            {
                LoginId = loginId,
                Id = Guid.NewGuid()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel inputModel)
        {
            if (!this.ModelState.IsValid) return this.View(inputModel);

            string loginId = inputModel.LoginId;

            Employee employee = new()
            {
                LoginId = loginId,
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Wages = inputModel.Wages,
                MoneyToTake = inputModel.MoneyToTake
            };

            await dbContext.Employees.AddAsync(employee);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid) return this.RedirectToAction(nameof(Index));

            Employee? employee = await dbContext
                .Employees
                .Include(e => e.TeamsMapping)
                .ThenInclude(tm => tm.Team)
                .FirstOrDefaultAsync(e => e.Id == guidId);

            if (employee == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EmployeeViewModel? viewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                LoginId = employee.LoginId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Wages = employee.Wages,
                MoneyToTake = employee.MoneyToTake,
                TeamMapping = employee.TeamsMapping
                    .Select(tm => new TeamViewModel
                    {
                        id = tm.Team.Id,
                        Name = tm.Team.Name
                    })
                    .ToHashSet()

            };

            return View(viewModel);
        }

    }
}
