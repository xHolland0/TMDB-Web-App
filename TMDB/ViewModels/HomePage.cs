using TMDB.Models;

namespace TMDB.ViewModels
{
    public class HomePage
    {
        public List<Category> Categories { get; set; }
        public List<Movie> Movies { get; set; }
        public List<FreeMovie> FreeMovie { get; set; }
    }
}
