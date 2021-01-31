using Microsoft.EntityFrameworkCore;
using StarWarsMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Persistance
{
    public class FilmsWithRatingContext : DbContext
    {
        public FilmsWithRatingContext(DbContextOptions<FilmsWithRatingContext> options) : base(options)
        {
        }

        public DbSet<FilmWithRatings> Films { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmWithRatings>()
                .HasMany(x => x.Ratings)
                .WithOne(x => x.Film);
            builder.Seed();
        }
    }
}
