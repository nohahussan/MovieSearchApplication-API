using Newtonsoft.Json.Linq;
using RecipesProjects.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecipesProjects.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            MovieAPI obj = new MovieAPI();
            obj = RecipesDAL.GetPost("http://www.omdbapi.com/?" + "t=" + "hello" + "&apikey=70a772b9&");



            return View(obj);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Breakfast()
        {
            return View();
        }

        public ActionResult Lunch()
        {
            return View();
        }

        public ActionResult Dinner()
        {
            return View();
        }
        /*

        public MovieAPI Recipes(MovieAPI obj)
        {
            string url = "http://www.omdbapi.com/?"+"t="+"hello"+"&apikey=70a772b9&";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            //request.Headers.Add("t", "blade+runner");
            //request.Headers.Add("apikey", "70a772b9");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());

            string APIText = rd.ReadToEnd();

            JToken movieInfo = JToken.Parse(APIText);

            
            obj = new MovieAPI(APIText);
            


            return obj;
        }
        */

    }

}