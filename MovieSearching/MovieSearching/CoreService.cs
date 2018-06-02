using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSearching
{
    public class CoreService
    {
        public static async Task<MovieModel> GetMovieService(string title)
        {
            //get api key from http://www.omdbapi.com/
            string key = "c102110";
            string queryString = "http://www.omdbapi.com/?t="
                + title+ "&apikey=" + key;
           
            //if (key == "c102110")
            //{
            //    throw new ArgumentException("You must obtain an API key fromhttp://www.omdbapi.com/ and replace it in the 'key' variable.");
            //}

            dynamic results = await MovieData.GetMovieDataFromRemote(queryString).ConfigureAwait(false);

            if (results["Title"] != null)
            {
                MovieModel movie = new MovieModel();
                movie.Title = (string)results["Title"];
                movie.Year = (string)results["Year"];
                movie.Poster = (string)results["Poster"];
                movie.Released = (string)results["Released"];
                movie.Rated = (string)results["Rated"];
                movie.Genre = (string)results["Genre"];
                movie.Director = (string)results["Director"];
                movie.Writer = (string)results["Writer"];
                movie.Writer = (string)results["Writer"];
                movie.Plot = (string)results["Plot"];
                movie.Language = (string)results["Language"];               
                movie.Production = (string)results["Production"];
                movie.Website = (string)results["Website"];
                movie.BoxOffice = (string)results["BoxOffice"];

                return movie;
            }
            else
            {
                return null;
            }
        }
    }
}
