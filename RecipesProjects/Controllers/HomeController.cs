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
        private DBItemContext db = new DBItemContext();
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
            string Movename = userChoice.MovieName.Trim();
            obj = MovieDAL.GetPost("http://www.omdbapi.com/?" + "t="+Movename+ "&apikey=70a772b9&");
            db.MovieAPIs.Add(obj);
            db.SaveChanges();
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