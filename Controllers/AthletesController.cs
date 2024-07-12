using Athletes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Athletes.Controllers
{
    public class AthletesController : Controller
    {
        private readonly ApplicationDbContext context;

        public AthletesController(ApplicationDbContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {
            var athletes = context.Athletes.ToList();
            return View(athletes);
        }
    }
}
