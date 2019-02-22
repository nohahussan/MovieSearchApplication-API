using Newtonsoft.Json.Linq;
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
            ViewBag.Message = "Your application description page.";
             JToken var = Recipes();


            return View();
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

        public JToken Recipes()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://developer.edamam.com/");
            request.Headers.Add("1f3aa5eb", "a1d0eb045f18e2e5bf9a9bab2ae6cbe4");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            JToken anything = JToken.Parse(data);

            return anything;
        }


    }

}