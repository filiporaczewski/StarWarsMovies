using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StarWarsMovies.Services
{
    public static class UrlUtils
    {
        public static int GetIdFromUrl(string url)
        {
            var matches = Regex.Matches(url, "[0-9]+");
            if (matches.Count == 0) return 0;
            return Convert.ToInt32(matches.Last().Value);
        }
    }
}
