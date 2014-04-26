﻿using System;
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
    public class ExerciseController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Exercise/

        public ActionResult Index()
        {
            var exercises = db.Exercises.Include(e => e.difficulty).Include(e => e.musclegroup);
            return View(exercises.ToList());
        }

        //
        // GET: /Exercise/Details/5

        public ActionResult Details(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        //
        // GET: /Exercise/Create

        public ActionResult Create()
        {
            ViewBag.difficultyId = new SelectList(db.Difficulties, "id", "name");
            ViewBag.musclegroupId = new SelectList(db.MuscleGroups, "id", "name");
            return View();
        }

        //
        // POST: /Exercise/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.difficultyId = new SelectList(db.Difficulties, "id", "name", exercise.difficultyId);
            ViewBag.musclegroupId = new SelectList(db.MuscleGroups, "id", "name", exercise.musclegroupId);
            return View(exercise);
        }

        //
        // GET: /Exercise/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.difficultyId = new SelectList(db.Difficulties, "id", "name", exercise.difficultyId);
            ViewBag.musclegroupId = new SelectList(db.MuscleGroups, "id", "name", exercise.musclegroupId);
            return View(exercise);
        }

        //
        // POST: /Exercise/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.difficultyId = new SelectList(db.Difficulties, "id", "name", exercise.difficultyId);
            ViewBag.musclegroupId = new SelectList(db.MuscleGroups, "id", "name", exercise.musclegroupId);
            return View(exercise);
        }

        //
        // GET: /Exercise/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        //
        // POST: /Exercise/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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