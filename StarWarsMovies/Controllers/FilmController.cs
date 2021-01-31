using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWarsMovies.Models;
using StarWarsMovies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarsMovies.Controllers
{
    public class FilmController : Controller
    {
        private readonly ILogger<FilmController> _logger;
        private readonly IFilmRepository _filmRepository;

        public FilmController(ILogger<FilmController> logger, IFilmRepository filmRepository)
        {
            _logger = logger;
            _filmRepository = filmRepository;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var episodes = await _filmRepository.GetEpisodeInfos();
            return View(episodes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string url)
        {
            var film = await _filmRepository.GetByUrl(url);
            return View(film);
        }

        [HttpPost]
        public async Task<IActionResult> Rate(RatingViewModel ratingViewModel)
        {
            var film = await _filmRepository.Get(ratingViewModel.FilmId);
            _filmRepository.Rate(film, ratingViewModel.Score);
            return RedirectToAction("Details", new { url = ratingViewModel.EpisodeUrl }); 
        }

    }
}
