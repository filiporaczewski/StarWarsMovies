using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsMovies.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 10)]
        public int Score { get; set; }

        [NotMapped]
        public int FilmId { get; set; }

        public virtual FilmWithRatings Film { get; set; }

    }
}