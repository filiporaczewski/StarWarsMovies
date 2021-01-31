using Microsoft.EntityFrameworkCore;
using StarWarsMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Persistance
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<FilmWithRatings>().HasData(
                new FilmWithRatings { Id = 1 },
                new FilmWithRatings { Id = 2 },
                new FilmWithRatings { Id = 3 },
                new FilmWithRatings { Id = 4 },
                new FilmWithRatings { Id = 5 },
                new FilmWithRatings { Id = 6 }
            );
        }
    }
}
