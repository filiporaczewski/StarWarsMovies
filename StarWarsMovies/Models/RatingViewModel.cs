using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Models
{
    public class RatingViewModel
    {
        [Range(1, 10)]
        public int Score { get; set; }

        public string EpisodeUrl { get; set; }

        public int FilmId { get; set; }
    }
}
