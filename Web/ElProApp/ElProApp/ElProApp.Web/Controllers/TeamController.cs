namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using ElProApp.Data;
    using ElProApp.Data.Models;
    using ViewModels.Employee;
    using ViewModels.Team;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class TeamController(ElProAppDbContext DbContext) : Controller
    {
        private readonly ElProAppDbContext dbContext = DbContext;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Team> allTeams = await dbContext
                .teams
                .ToListAsync();
            return View(allTeams);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(TeamInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View(inputModel);
            }

            var employeeTeam = new Team
            {
                Name = inputModel.Name,
            };

            await dbContext.teams.AddAsync(employeeTeam);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            IEnumerable<Employee> allEmployees = await dbContext
                .employees
                .ToListAsync();

            if (allEmployees == null)
            {
                return RedirectToAction(nameof(Index));
            }

            Team? тeam = await dbContext.teams
                .FirstOrDefaultAsync(et => et.Id == guidId);

            TeamViewModel viewModel = new ()
            {
                id = тeam.Id!,
                Name = тeam.Name

            };

            return View(viewModel);
        }

        [HttpGet]

        public async Task<IActionResult> AddToTeam(string? id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Team? тeam = await this.dbContext.teams
                .FirstOrDefaultAsync(et => et.Id == guidId);

            if (тeam == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddEmployeeToTeamInputModel viewModel = new ()
            {
                Id = id!,
                TeamName = тeam.Name,
                Employees = await this.dbContext
                    .employees
                    .Include(e => e.TeamsEmployeeBelongsTo)
                    .ThenInclude(et => et.Team)
                    .Select(e => new EmployeeCheckBoxItemInputModel()
                    {
                        Id = e.Id.ToString(),
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        IsSelected = e.TeamsEmployeeBelongsTo

                            .Any(etm => etm.TeamId == guidId)
                    })
                    .ToArrayAsync()
            };

            return View(viewModel);
        }
    }
}
