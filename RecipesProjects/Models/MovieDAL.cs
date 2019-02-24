using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace RecipesProjects.Models
{
    

    public class MovieDAL
    {
        
        public static string GetData(string Url)
        {
           
            HttpWebRequest request = WebRequest.CreateHttp(Url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string APIText = rd.ReadToEnd();
            return APIText;
        }
       
        public static MovieAPI GetPost(string Url)
        {
            string APIText = GetData(Url);
            MovieAPI movieObj = new MovieAPI(APIText);
            return movieObj;
        }
       

    }
}