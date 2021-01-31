using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsMovies.Services
{
    public class ApiHelper
    {
        public static async Task<T> GetDeserializedModelFromApi<T>(HttpClient client, string apiUrl)
        {
            using(var response = await client.GetAsync(apiUrl))
            {
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
