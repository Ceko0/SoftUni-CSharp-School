namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using ViewModels.Building;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]

    public class BuildingController(ElProAppDbContext dbContext) : Controller
    {
        private readonly ElProAppDbContext dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Building> allBuildings = await dbContext
                .buildings
                .ToListAsync();
            return View(allBuildings);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuildingInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            Building building = new()
            {
                Name = inputModel.Name,
                Location = inputModel.Location,
                
            };

            await this.dbContext.buildings.AddAsync(building);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            bool isValidGuid = Guid.TryParse(id, out Guid guidId);
            if (!isValidGuid)
            {
                return this.RedirectToAction(nameof(Index));
            }

            Building? building = await this.dbContext
                .buildings
                //.Include(b => b.BuildingEmployeeTeamMemberships) 
                //.ThenInclude(betm => betm.EmployeeTeam)  
                //.Include(b => b.BuildingJobDoneMembership) 
                //.ThenInclude(bjdm => bjdm.JobDone) 
                //.ThenInclude(jd => jd.JobJobDoneMembership) 
                //.ThenInclude(jjdm => jjdm.Job) 
                .FirstOrDefaultAsync(b => b.Id == guidId); 

            if (building == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(building); 
        }


    }
}
