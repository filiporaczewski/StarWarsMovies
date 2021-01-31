using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Models
{
    public class FilmWithRatings
    {
        public FilmWithRatings()
        {
            if (this.Ratings == null)
            {
                this.Ratings = new List<Rating>();
            }
        }

        [Key]
        public int Id { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        [NotMapped]
        public decimal? AverageScore => CalculateAverageScore();

        [NotMapped]
        public EpisodeInfo EpisodeInfo { get; set; }

        private decimal? CalculateAverageScore()
        {
            return (this.Ratings != null && this.Ratings.Count > 0)
                ? (decimal)this.Ratings.Sum(x => x.Score) / this.Ratings.Count() : default(decimal?);
        }
    }
}
