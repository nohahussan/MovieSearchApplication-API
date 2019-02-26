using Newtonsoft.Json.Linq;
using MovieAPI_Project.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieAPI_Project.Controllers
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
            if (ModelState.IsValid)
            {
            
                Session["UserInput"] = userChoice;
              
                return RedirectToAction("About");
            }
            else
            {
                UserInput obj = new UserInput();
                return View(obj);
            }
        }
       
        public ActionResult About()
        {
            userChoice =(UserInput) Session["UserInput"];

                MovieAPI obj = new MovieAPI();
                string Movename = userChoice.MovieName.Trim();
                obj = MovieDAL.GetPost("http://www.omdbapi.com/?" + "t=" + Movename + "&apikey=70a772b9&");
                Session["FavoruitMovie"] = obj;//store the searched result inside a Session so when the user decide to add it to his favorite list we get it
                return View(obj);// return the movie details to the view so the user can read it

        }
        public ActionResult AddToFavoruit() // The user reviewed the movie and decided to add it to his favoruit list
        {
            MovieAPI obj = new MovieAPI();
            obj =(MovieAPI) Session["FavoruitMovie"];
            return RedirectToAction("Create", "MovieAPIs1",obj);//pass the movie obj to create action in MovieAPIs1Controller to store this movie in the data base
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        }
        

    }

