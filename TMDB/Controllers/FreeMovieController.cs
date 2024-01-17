using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TMDB.Models;
using TMDB.ViewModels;

namespace TMDB.Controllers
{
    public class FreeMovieController:Controller
    {
        private TMDBContext _context;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment _environment;

        public FreeMovieController(TMDBContext context, IWebHostEnvironment environment)
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
            return View(_context.FreeMovies.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SelectList = getCategoriesItems();
            return View();
        }

        [HttpPost]
        public IActionResult Create(VM_FreeMovie FreeMovieVM, List<IFormFile> freemovieImages, List<IFormFile> bannerImages)
        {
            if (ModelState.IsValid)
            {
                FreeMovie freemovie = new FreeMovie()
                {
                    Name = FreeMovieVM.Name,
                    ReleaseYear = FreeMovieVM.ReleaseYear,
                    Description = FreeMovieVM.Description,
                    IsNew = FreeMovieVM.IsNew,
                    ThisWeek = FreeMovieVM.ThisWeek,
                    Free = FreeMovieVM.IsFree,
                    UserPoint = FreeMovieVM.UserPoint,
                    Category = _context.Categories.FirstOrDefault(x => x.Id == FreeMovieVM.CategoryId),
                };

                //foreach (var item in movieImages)
                //{
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(freemovieImages[0].FileName);
                var uploads = Path.Combine(_environment.WebRootPath, "img/MovieImage");
                var filePath = Path.Combine(uploads, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    freemovieImages[0].CopyTo(stream);
                }


                freemovie.Image = uniqueFileName;


                var uniqueFileName1 = Guid.NewGuid().ToString() + Path.GetExtension(bannerImages[0].FileName);
                var uploads1 = Path.Combine(_environment.WebRootPath, "img/MovieBanners");
                var filePath1 = Path.Combine(uploads1, uniqueFileName1);
                using (var stream = new FileStream(filePath1, FileMode.Create))
                {
                    bannerImages[0].CopyTo(stream);
                }


                freemovie.BannerImage = uniqueFileName1;

                //}

                _context.FreeMovies.Add(freemovie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SelectList = getCategoriesItems();
            return View();
        }



        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_context.FreeMovies.Include(x => x.Category).FirstOrDefault(x => x.Id == id));
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Del(int id)
        {

            if (!string.IsNullOrEmpty(_context.FreeMovies.FirstOrDefault(x => x.Id == id).Image))
            {
                _context.FreeMovies.Remove(_context.FreeMovies.FirstOrDefault(x => x.Id == id));
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
