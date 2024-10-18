namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using ViewModels.Employee;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class EmployeeController(ElProAppDbContext DbContext) : Controller
    {
        private readonly ElProAppDbContext dbContext = DbContext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> allEmployees = await dbContext
                .employees
                .ToListAsync();
            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Employee employee = new()
            {
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Wages = inputModel.Wages,
                MoneyToTake = inputModel.MoneyToTake
            };

            await this.dbContext.employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid) return this.RedirectToAction(nameof(Index));

            Employee? employee = await this.dbContext
                .employees
                .FirstOrDefaultAsync(e => e.Id == guidId);

            if (employee == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
    }
}
