using Athletes.Models;
using Athletes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Athletes.Controllers
{
    public class AthletesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public AthletesController(ApplicationDbContext context, IWebHostEnvironment environment) {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            var athletes = context.Athletes.OrderByDescending(p => p.Id).ToList();
            return View(athletes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AthleteDto athleteDto)
        {
            if (athleteDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "The image file is required");
            }

            if (!ModelState.IsValid)
            {
                return View(athleteDto);
            }

            // save the image file
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(athleteDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/images/" + newFileName;
            using (var stream = System.IO.File.Create(imageFullPath))
            {
                athleteDto.ImageFile.CopyTo(stream);
            }

            // save the new athelte in the database
            Athlete athlete = new Athlete()
            {
                Name = athleteDto.Name,
                PointsPerGame = athleteDto.PointsPerGame,
                ReboundsPerGame = athleteDto.ReboundsPerGame,
                AssistsPerGame = athleteDto.AssistsPerGame,
                FieldGoalPercentage = athleteDto.FieldGoalPercentage,
                ThreePointPercentage = athleteDto.ThreePointPercentage,
                Championships = athleteDto.Championships,
                ImageFileName = imageFullPath,
                CreatedAt = DateTime.Now
            };

            context.Athletes.Add(athlete);
            context.SaveChanges();

            return RedirectToAction("Index", "Athletes");
        }
    }
}
