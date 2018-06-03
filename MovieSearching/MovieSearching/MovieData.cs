using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearching
{
    public class MovieData
    {
        public static async Task<dynamic> GetMovieDataFromRemote(string queryString)
        {
            dynamic data = null;
            try
            {
                HttpClient client = new HttpClient();
               // HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, queryString);
                var response = await client.GetAsync(queryString);


                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject(json);
                }

                return data;
            }catch(Exception ex)
            {
                return data;
            }

        }
    }
}
