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
    public class WorkoutController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Workout/

        public ActionResult Index()
        {
            var workouts = db.Workouts.Include(w => w.training);
            return View(workouts.ToList());
        }

        //
        // GET: /Workout/Details/5

        public ActionResult Details(int id = 0)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        //
        // GET: /Workout/Create

        public ActionResult Create()
        {
            ViewBag.trainingId = new SelectList(db.Trainings, "id", "name");
            return View();
        }

        //
        // POST: /Workout/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Workouts.Add(workout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.trainingId = new SelectList(db.Trainings, "id", "name", workout.trainingId);
            return View(workout);
        }

        //
        // GET: /Workout/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            ViewBag.trainingId = new SelectList(db.Trainings, "id", "name", workout.trainingId);
            return View(workout);
        }

        //
        // POST: /Workout/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workout workout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.trainingId = new SelectList(db.Trainings, "id", "name", workout.trainingId);
            return View(workout);
        }

        //
        // GET: /Workout/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        //
        // POST: /Workout/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workout workout = db.Workouts.Find(id);
            db.Workouts.Remove(workout);
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