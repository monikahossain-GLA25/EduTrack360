using Microsoft.AspNetCore.Mvc;

namespace EduTrack360.Controllers
{
    public class WorkspacesControlle : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
