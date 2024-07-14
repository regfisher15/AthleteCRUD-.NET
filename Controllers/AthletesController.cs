using Athletes.Models;
using Athletes.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Athletes.Controllers
{
    [Authorize]
    public class AthletesController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<IdentityUser> userManager;

        public AthletesController(ApplicationDbContext context, IWebHostEnvironment environment, UserManager<IdentityUser> userManager) {
            this.context = context;
            this.environment = environment;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);    
            var athletes = context.Athletes
                .Where(a => a.UserId == userId)
                .OrderByDescending(p => p.Id)
                .ToList();
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

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

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
                ImageFileName = newFileName,
                CreatedAt = DateTime.Now,
                UserId = userId
            };

            context.Athletes.Add(athlete);
            context.SaveChanges();

            return RedirectToAction("Index", "Athletes");
        }

        public IActionResult Edit(int id)
        {
            var athlete = context.Athletes.Find(id);

            if (athlete == null)
            {
                return RedirectToAction("Index", "Athletes");
            }

            // create athleteDto from athlete  
            var athleteDto = new AthleteDto()
            {
                Name = athlete.Name,
                PointsPerGame = athlete.PointsPerGame,
                ReboundsPerGame = athlete.ReboundsPerGame,
                AssistsPerGame = athlete.AssistsPerGame,
                FieldGoalPercentage = athlete.FieldGoalPercentage,
                ThreePointPercentage = athlete.ThreePointPercentage,
                Championships = athlete.Championships,
            };

            ViewData["AthleteId"] = athlete.Id;
            ViewData["ImageFileName"] = athlete.ImageFileName;
            ViewData["CreatedAt"] = athlete.CreatedAt.ToString("MM/dd/yyyy");

            return View(athleteDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, AthleteDto athleteDto)
        {
            var athlete = context.Athletes.Find(id);

            if (athlete == null || athlete.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToAction("Index", "Athletes");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AthleteId"] = athlete.Id;
                ViewData["ImageFileName"] = athlete.ImageFileName;
                ViewData["CreatedAt"] = athlete.CreatedAt.ToString("MM/dd/yyyy");

                return View(athleteDto);
            }


            // update the image file if we have a new image
            string newFileName = athlete.ImageFileName;
            if (athleteDto.ImageFile != null)
            {
                newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFileName += Path.GetExtension(athleteDto.ImageFile!.FileName);

                string imageFullPath = environment.WebRootPath + "/images/" + newFileName;
                using (var stream = System.IO.File.Create(imageFullPath))
                {
                    athleteDto.ImageFile.CopyTo(stream);
                }

                //delete the old image
                //string oldImageFullPath = environment.WebRootPath + "/images/" + athlete.ImageFileName;
                string oldImageFullPath = Path.Combine(environment.WebRootPath, "images", athlete.ImageFileName);
                if (System.IO.File.Exists(oldImageFullPath))
                {
                    System.IO.File.Delete(oldImageFullPath);
                }
            }

            // update the athlete in the database
            athlete.Name = athleteDto.Name;
            athlete.PointsPerGame = athleteDto.PointsPerGame;
            athlete.ReboundsPerGame = athleteDto.ReboundsPerGame;
            athlete.AssistsPerGame = athleteDto.AssistsPerGame;
            athlete.FieldGoalPercentage = athleteDto.FieldGoalPercentage;
            athlete.ThreePointPercentage = athleteDto.ThreePointPercentage;
            athlete.Championships = athleteDto.Championships;
            athlete.ImageFileName = newFileName;

            context.SaveChanges();

            return RedirectToAction("Index", "Athletes");
        }

        public IActionResult Delete(int id)
        {
            var athlete = context.Athletes.Find(id);
            if (athlete == null || athlete.UserId != User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return RedirectToAction("Index", "Athletes");
            }

            // the image file path
            string imageFullPath = Path.Combine(environment.WebRootPath, "images", athlete.ImageFileName);

            // Check if the file exists before attempting to delete it
            if (System.IO.File.Exists(imageFullPath))
            {
                System.IO.File.Delete(imageFullPath);
            }

            context.Athletes.Remove(athlete);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Athletes");
        }
    }
}
