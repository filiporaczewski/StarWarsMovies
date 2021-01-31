using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarWarsMovies.Models
{
    public class EpisodeInfo
    {
        public string Title { get; set; }

        [JsonProperty("release_date")]
        public DateTime ReleaseDate { get; set; }

        public string Director { get; set; }

        public string Producer { get; set; }

        public string Url { get; set; }
    }
}
