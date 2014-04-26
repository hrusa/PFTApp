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
    public class ExerciseUnitController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /ExerciseUnit/

        public ActionResult Index()
        {
            var exerciseunits = db.ExerciseUnits.Include(e => e.exercise).Include(e => e.workout);
            return View(exerciseunits.ToList());
        }

        //
        // GET: /ExerciseUnit/Details/5

        public ActionResult Details(int id = 0)
        {
            ExerciseUnit exerciseunit = db.ExerciseUnits.Find(id);
            if (exerciseunit == null)
            {
                return HttpNotFound();
            }
            return View(exerciseunit);
        }

        //
        // GET: /ExerciseUnit/Create

        public ActionResult Create()
        {
            ViewBag.exerciseId = new SelectList(db.Exercises, "id", "name");
            ViewBag.workoutId = new SelectList(db.Workouts, "id", "name");
            return View();
        }

        //
        // POST: /ExerciseUnit/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExerciseUnit exerciseunit)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseUnits.Add(exerciseunit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.exerciseId = new SelectList(db.Exercises, "id", "name", exerciseunit.exerciseId);
            ViewBag.workoutId = new SelectList(db.Workouts, "id", "name", exerciseunit.workoutId);
            return View(exerciseunit);
        }

        //
        // GET: /ExerciseUnit/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExerciseUnit exerciseunit = db.ExerciseUnits.Find(id);
            if (exerciseunit == null)
            {
                return HttpNotFound();
            }
            ViewBag.exerciseId = new SelectList(db.Exercises, "id", "name", exerciseunit.exerciseId);
            ViewBag.workoutId = new SelectList(db.Workouts, "id", "name", exerciseunit.workoutId);
            return View(exerciseunit);
        }

        //
        // POST: /ExerciseUnit/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExerciseUnit exerciseunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.exerciseId = new SelectList(db.Exercises, "id", "name", exerciseunit.exerciseId);
            ViewBag.workoutId = new SelectList(db.Workouts, "id", "name", exerciseunit.workoutId);
            return View(exerciseunit);
        }

        //
        // GET: /ExerciseUnit/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExerciseUnit exerciseunit = db.ExerciseUnits.Find(id);
            if (exerciseunit == null)
            {
                return HttpNotFound();
            }
            return View(exerciseunit);
        }

        //
        // POST: /ExerciseUnit/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseUnit exerciseunit = db.ExerciseUnits.Find(id);
            db.ExerciseUnits.Remove(exerciseunit);
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