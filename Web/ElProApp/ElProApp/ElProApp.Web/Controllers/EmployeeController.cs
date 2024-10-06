using ElProApp.Data;
using ElProApp.Data.Models;
using ElProApp.Web.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ElProApp.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ElProAppDbContext dbContext;

        public EmployeeController(ElProAppDbContext DbContext)
        {
            this.dbContext = DbContext;
        }
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
            var model = new EmployeeInputModel
            {
                LoginId = loginId,
                Id = Guid.NewGuid()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            string loginId = inputModel.LoginId;

            Employee employee = new()
            {
                LoginId = loginId,
                FirstName = inputModel.FirstName,
                LastName = inputModel.LastName,
                Wages = inputModel.Wages,
                MoneyToTake = inputModel.MoneyToTake
            };

            await this.dbContext.Employees.AddAsync(employee);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid) return this.RedirectToAction(nameof(Index));

            Employee? employee = await this.dbContext
                .Employees
                .FirstOrDefaultAsync(e => e.Id == guidId);

            if (employee == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }
    }
}
