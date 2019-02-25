using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipesProjects.Models;

namespace RecipesProjects.Controllers
{
    public class MovieAPIs1Controller : Controller
    {
        private DBItemContext db = new DBItemContext();

        // GET: MovieAPIs1
        public ActionResult Index()
        {
            return View(db.MovieAPIs.ToList());
        }

        // GET: MovieAPIs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieAPI movieAPI = db.MovieAPIs.Find(id);
            if (movieAPI == null)
            {
                return HttpNotFound();
            }
            return View(movieAPI);
        }

        // GET: MovieAPIs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieAPIs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( MovieAPI movieAPI)
        {
            if (ModelState.IsValid)
            {
                db.MovieAPIs.Add(movieAPI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieAPI);
        }

        // GET: MovieAPIs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieAPI movieAPI = db.MovieAPIs.Find(id);
            if (movieAPI == null)
            {
                return HttpNotFound();
            }
            return View(movieAPI);
        }

        // POST: MovieAPIs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,Rated,Released,Director,Genre")] MovieAPI movieAPI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieAPI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieAPI);
        }

        // GET: MovieAPIs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieAPI movieAPI = db.MovieAPIs.Find(id);
            if (movieAPI == null)
            {
                return HttpNotFound();
            }
            return View(movieAPI);
        }

        // POST: MovieAPIs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovieAPI movieAPI = db.MovieAPIs.Find(id);
            db.MovieAPIs.Remove(movieAPI);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
