using StarWarsMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Services
{
    public interface IFilmRepository
    {
        Task<List<EpisodeInfo>> GetEpisodeInfos();
    }
}
