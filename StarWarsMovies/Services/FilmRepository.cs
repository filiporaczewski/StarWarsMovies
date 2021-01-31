using StarWarsMovies.Models;
using StarWarsMovies.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsMovies.Services
{
    public class FilmRepository : IFilmRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FilmsWithRatingContext _dbContext;

        public FilmRepository(IHttpClientFactory httpClientFactory, FilmsWithRatingContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _dbContext = dbContext;
        }

        public async Task<FilmWithRatings> Get(int id)
        {
            var film = await _dbContext.Films.FindAsync(id);
            _dbContext.Entry(film).Collection(x => x.Ratings).Load();
            return film;
        }

        public async Task<FilmWithRatings> GetByUrl(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var apiModel = await ApiHelper.GetDeserializedModelFromApi<EpisodeInfo>(client, url);
            var film = await Get(UrlUtils.GetIdFromUrl(url));
            film.EpisodeInfo = apiModel;
            return film;
        }

        public async Task<List<EpisodeInfo>> GetEpisodeInfos()
        {
            var client = _httpClientFactory.CreateClient();
            var apiModel = await ApiHelper
                .GetDeserializedModelFromApi<EpisodeListResponseModel>
                (client, "https://swapi.dev/api/films/");
            return apiModel.Results;
        }
    }
}
