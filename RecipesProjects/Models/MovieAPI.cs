using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecipesProjects.Models
{
    public class MovieAPI
    {
        
        public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }

        public MovieAPI()
        {}

        public MovieAPI(string APIText)
        {
            //JObject movieJson = JObject.Parse(APIText);
            JToken movieInfo = JToken.Parse(APIText);

            Title = movieInfo["Title"].ToString();
            Year = movieInfo["Year"].ToString();
            Rated = movieInfo["Rated"].ToString();
            Released = movieInfo["Released"].ToString();
            Director = movieInfo["Director"].ToString();
            Genre = movieInfo["Genre"].ToString();

        }
        public class DBItemContext : DbContext
        {
            public DbSet<MovieAPI> Movies { get; set; }
        }

    }
    
}

