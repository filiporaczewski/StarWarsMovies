using StarWarsMovies.Models;
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

        public FilmRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
