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
        UserInput userChoice = new UserInput();
        
        public ActionResult Index()
        {
            
            return View(userChoice);
        }
        [HttpPost]
        public ActionResult Index(UserInput userChoice)
        {
            if (Session["UserInput"] != null)
            {
                userChoice = (UserInput)Session["UserInput"];
            }
            else
            {
                Session["UserInput"] = userChoice;
            }
                   
                return RedirectToAction("About");
        }

        public ActionResult About()
        {
            userChoice =(UserInput) Session["UserInput"];

            MovieAPI obj = new MovieAPI();
            obj = MovieDAL.GetPost("http://www.omdbapi.com/?" + "t="+userChoice.MovieName+"&apikey=70a772b9&");
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
        

    }

}