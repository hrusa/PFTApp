using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PFTApp.Models;
using PFTApp.DAL;

namespace PFTApp.Controllers
{
    public class SerieController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Serie/

        public ActionResult Index()
        {
            var series = db.Series.Include(s => s.exerciseunit);
            return View(series.ToList());
        }

        //
        // GET: /Serie/Details/5

        public ActionResult Details(int id = 0)
        {
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        //
        // GET: /Serie/Create

        public ActionResult Create()
        {
            ViewBag.exerciseunitId = new SelectList(db.ExerciseUnits, "id", "id");
            return View();
        }

        //
        // POST: /Serie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Series.Add(serie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exerciseunitId = new SelectList(db.ExerciseUnits, "id", "id", serie.exerciseunitId);
            return View(serie);
        }

        //
        // GET: /Serie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            ViewBag.exerciseunitId = new SelectList(db.ExerciseUnits, "id", "id", serie.exerciseunitId);
            return View(serie);
        }

        //
        // POST: /Serie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Serie serie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exerciseunitId = new SelectList(db.ExerciseUnits, "id", "id", serie.exerciseunitId);
            return View(serie);
        }

        //
        // GET: /Serie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Serie serie = db.Series.Find(id);
            if (serie == null)
            {
                return HttpNotFound();
            }
            return View(serie);
        }

        //
        // POST: /Serie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Serie serie = db.Series.Find(id);
            db.Series.Remove(serie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}