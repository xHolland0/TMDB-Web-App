using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Project;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TMDB.Models;
using TMDB.ViewModels;

namespace TMDB.Controllers
{
    public class HomeController : Controller
    {
        private TMDBContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, TMDBContext context)
        {
            _logger = logger;
            _context = context; 
        }

        public IActionResult Index()
        {
            HomePage vm = new HomePage();

            vm.Categories = _context.Categories.ToList();
            vm.Movies = _context.Movies.Where(m=>m.IsPopular==true).ToList();

            vm.FreeMovie = _context.FreeMovies.Where(fm=>fm.Free==true).ToList();
            return View(vm);
        }


        public IActionResult Detail(int id)
        {
            var detail = _context.Movies.Where(x => x.Id == id).FirstOrDefault();
            var detailcategory = _context.Movies.Include(x => x.Category).ToList();
            return View(detail);
        }

        public IActionResult FreeMovieDetail(int id)
        {
            var freemoviedetail = _context.FreeMovies.Where(x => x.Id == id).FirstOrDefault();
            var detailcategory = _context.Movies.Include(x => x.Category).ToList();
            return View(freemoviedetail);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}