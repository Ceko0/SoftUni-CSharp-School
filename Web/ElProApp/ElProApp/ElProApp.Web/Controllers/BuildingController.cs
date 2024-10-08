using ElProApp.Data.Models.Mapping;
using ElProApp.Web.ViewModels.Team;

namespace ElProApp.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Data.Models;
    using ViewModels.Building;


    public class BuildingController(ElProAppDbContext dbContext) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Building> allBuildings = await dbContext
                .Buildings
                .ToListAsync();

            return View(allBuildings);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BuildingInputModel model)
        {
            if (!this.ModelState.IsValid) return this.View(model);

            Building building = new()
            {
                Name = model.Name,
                Location = model.Location,
            };

            await dbContext.Buildings.AddAsync(building);
            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {

            if (!Guid.TryParse(id, out Guid guidId)) return RedirectToAction(nameof(Index));

            Building? building = await dbContext
                .Buildings
                .Include(b => b.TeamMappings)
                .ThenInclude(tm => tm.Team)
                .FirstOrDefaultAsync(b => b.Id == guidId);

            if (building == null) return RedirectToAction(nameof(Index));

            BuildingViewModel model = new BuildingViewModel()
            {
                Id = building.Id,
                Name = building.Name,
                Location = building.Location,
                TeamMapping = building
                    .TeamMappings
                    .Select(tm => new TeamViewModel
                    {
                        id = tm.Team.Id,
                        Name = tm.Team.Name
                    })
                    .ToHashSet()

            };
            return View(model);
        }

        public async Task<IActionResult> AddTeamToBuilding(Guid id)
        {

            Building? building = await dbContext.Buildings
                .FirstOrDefaultAsync(b => b.Id == id);

            if (building == null)
            {
                return this.RedirectToAction(nameof(Index));
            }

            AddTeamToBuildingInputModel model = new AddTeamToBuildingInputModel()
            {
                Id = building.Id,
                name = building.Name,
                Location = building.Location,
                TeamMapping = await dbContext
                    .Teams
                    .Include(t => t.BuildingsMapping)
                    .ThenInclude(bm => bm.Building)
                    .Select(t => new TeamCheckBoxItemInputModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        IsSelected = t.BuildingsMapping
                            .Any(tbm => tbm.BuildingId == id)
                    })
                    .ToArrayAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeamToBuilding(Guid id, List<string> TeamIds)
        {

            Building building = await dbContext.Buildings.FirstOrDefaultAsync(b => b.Id == id);
            if (building == null) return RedirectToAction(nameof(Index));
            
            foreach (string teamIdStr in TeamIds)
            {
                if (Guid.TryParse(teamIdStr, out Guid teamId))
                {
                    bool isAlreadyInTeam = await dbContext.BuildingsTeamMappings
                        .AnyAsync(etm => etm.TeamId == teamId && etm.BuildingId == id);

                    if (!isAlreadyInTeam)
                    {
                        var buildingTeamMapping = new BuildingTeamMapping
                        {
                           Id = (id ,teamId).ToString(),
                           TeamId = teamId,
                           BuildingId = id
                        };

                        await dbContext.BuildingsTeamMappings.AddAsync(buildingTeamMapping);
                    }
                }
            }

            await dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
