using EduTrack360.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace EduTrack360.Controllers
{
    public class WorkspacesControlle : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkspacesControlle(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Index(
            string? search,
            int? domainId)
        {
            var query =
                _context.StudyWorkspaces
                    .Include(x => x.PreparationDomain)
                    .Include(x => x.PreparationOption)
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.Name.Contains(search));
            }

            if (domainId.HasValue)
            {
                query = query.Where(x =>
                    x.PreparationDomainId == domainId.Value);
            }

            var workspaces =
                await query
                    .OrderBy(x => x.Name)
                    .ToListAsync();

            return View(workspaces);
        }
    }
}
