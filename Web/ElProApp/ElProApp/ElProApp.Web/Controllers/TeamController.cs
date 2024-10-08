namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using Data.Models.Mapping;
    using ViewModels.Employee;
    using ViewModels.Team;
    
    public class TeamController(ElProAppDbContext DbContext) : Controller
    {
        private readonly ElProAppDbContext dbContext = DbContext;

        public async Task<IActionResult> Index()
        {
            IEnumerable<Team> allEmployeeTeams = await dbContext
                .Teams
                .ToListAsync();
            return View(allEmployeeTeams);
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

            await dbContext.Teams.AddAsync(employeeTeam);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            Team? team = await dbContext.Teams
                .Include(t => t.EmployeesMapping)
                .ThenInclude(etm => etm.Employee)
                .FirstOrDefaultAsync(et => et.Id == id);

            if (team == null)
            {
                return RedirectToAction(nameof(Index));
            }

            TeamViewModel viewModel = new TeamViewModel()
            {
                id = team.Id,
                Name = team.Name,
                EmployeeMapping = team.EmployeesMapping
                    .Select(etm => new EmployeeViewModel
                    {
                        Id = etm.Employee.Id,
                        FirstName = etm.Employee.FirstName,
                        LastName = etm.Employee.LastName
                    })
                    .ToList()
            };

            return View(viewModel);
        }

        [HttpGet]

        public async Task<IActionResult> AddToTeam(Guid id)
        {

            Team? team = await this.dbContext.Teams
                .FirstOrDefaultAsync(et => et.Id == id);

            if (team == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddEmployeeToTeamInputModel viewModel = new AddEmployeeToTeamInputModel()
            {
                Id = team.Id!,
                TeamName = team.Name,
                Employees = await this.dbContext
                    .Employees
                    .Include(e => e.TeamsMapping)
                    .ThenInclude(et => et.Team)
                    .Select(e => new EmployeeCheckBoxItemInputModel()
                    {
                        Id = e.Id,
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        IsSelected = e.TeamsMapping
                            .Any(etm => etm.TeamId == id)
                    })
                    .ToArrayAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(Guid teamId, List<string> employeeIds)
        {

            var team = await dbContext.Teams.FirstOrDefaultAsync(t => t.Id == teamId);
            if (team == null)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var employeeIdStr in employeeIds)
            {
                if (Guid.TryParse(employeeIdStr, out Guid employeeId))
                {
                    bool isAlreadyInTeam = await dbContext.EmployeeTeamMappings
                        .AnyAsync(etm => etm.EmployeeId == employeeId && etm.TeamId == teamId);

                    if (!isAlreadyInTeam)
                    {
                        var employeeTeamMapping = new EmployeeTeamMapping
                        {
                            id = (employeeId, teamId).ToString(),
                            EmployeeId = employeeId,
                            TeamId = teamId
                        };

                        await dbContext.EmployeeTeamMappings.AddAsync(employeeTeamMapping);
                    }
                }
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
