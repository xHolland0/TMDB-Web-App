using Microsoft.EntityFrameworkCore;

namespace TMDB.Models
{
    public class TMDBContext:DbContext
    {
        public TMDBContext(DbContextOptions<TMDBContext> options) : base(options) 
        { 

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FreeMovie> FreeMovies { get; set; }

    }
}
