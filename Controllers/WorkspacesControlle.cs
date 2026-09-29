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
    }
}
