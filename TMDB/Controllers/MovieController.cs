using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TMDB.Models;
using TMDB.ViewModels;

namespace TMDB.Controllers
{
    public class MovieController : Controller
    {
        private TMDBContext  _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;

        public MovieController(TMDBContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        List<SelectListItem> getCategoriesItems()
        {
            List<Category> categories = _context.Categories.ToList();
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (Category category in categories)
            {
                SelectListItem item = new SelectListItem();
                item.Text = category.Name;
                item.Value = category.Id.ToString();
                selectList.Add(item);
            }

            return selectList;
        }

        public IActionResult Index()
        {
            return View(_context.Movies.ToList()); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SelectList = getCategoriesItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VM_Movie MovieVM, List<IFormFile> movieImages, List<IFormFile> bannerImages)
        {
            if (ModelState.IsValid)
            {
                Movie movie = new Movie()
                {
                    Name = MovieVM.Name,
                    ReleaseYear = MovieVM.ReleaseYear,
                    Description = MovieVM.Description,
                    IsPopular = MovieVM.IsPopular,
                    IsNew = MovieVM.IsNew,
                    ThisWeek = MovieVM.ThisWeek,    
                    UserPoint = MovieVM.UserPoint,
                    Category = _context.Categories.FirstOrDefault(x => x.Id == MovieVM.CategoryId),
                };

                //foreach (var item in movieImages)
                //{
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(movieImages[0].FileName);
                    var uploads = Path.Combine(_environment.WebRootPath, "img/MovieImage");
                    var filePath = Path.Combine(uploads, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                    movieImages[0].CopyTo(stream);
                    }


                    movie.Image = uniqueFileName;


                var uniqueFileName1 = Guid.NewGuid().ToString() + Path.GetExtension(bannerImages[0].FileName);
                var uploads1 = Path.Combine(_environment.WebRootPath, "img/MovieBanners");
                var filePath1 = Path.Combine(uploads1, uniqueFileName1);
                using (var stream = new FileStream(filePath1, FileMode.Create))
                {
                    bannerImages[0].CopyTo(stream);
                }


                movie.BannerImage = uniqueFileName1;

                //}

                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectList = getCategoriesItems();
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.Movies.Include(x => x.Category).FirstOrDefault(x => x.Id == id));
        }

   
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Del(int id)
        {

            if (!string.IsNullOrEmpty(_context.Movies.FirstOrDefault(x => x.Id == id).Image))
            {
                _context.Movies.Remove(_context.Movies.FirstOrDefault(x => x.Id == id));
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
