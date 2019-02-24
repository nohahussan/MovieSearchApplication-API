using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipesProjects.Models
{
    public class MovieAPI
    {
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

    }
    
}

/*
 * 
 * using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedditAPI.Models
{
    public class RedditPost
    {
        public string Title { get; set; }
        public string ImageURL { get; set; }
        public string LinkURL { get; set; }
        //So we wana put parsing code in here to help make the code more portable

        public RedditPost()
        {

        }

        public RedditPost(string APIText, int i)
        {
            JObject redditJson = JObject.Parse(APIText);

            List<JToken> posts = redditJson["data"]["children"].ToList();

            JToken post = posts[i];

            Title = post["data"]["title"].ToString();
        }
    }
}
 */
 
 