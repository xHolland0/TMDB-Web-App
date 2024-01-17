﻿namespace TMDB.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Description { get; set; }
        public bool IsPopular { get; set; }
        public bool IsNew { get; set; }
        public bool ThisWeek { get; set; }
        public int UserPoint { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        internal object ToList()
        {
            throw new NotImplementedException();
        }
    }
}
