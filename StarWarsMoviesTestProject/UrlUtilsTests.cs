using NUnit.Framework;
using StarWarsMovies.Services;

namespace StarWarsMoviesTestProject
{
    public class Tests
    {
        [TestCase("https://swapi.dev/api/films/4", 4)]
        [TestCase("http://ex12.com/43", 43)]
        public void GetIdFromUrl_ValidInput_ReturnsId(string url, int id)
        {
            var result = UrlUtils.GetIdFromUrl(url);
            Assert.AreEqual(id, result);
        }
    }
}