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
    public class TrainingController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Training/

        public ActionResult Index()
        {
            var trainings = db.Trainings.Include(t => t.trainee);
            return View(trainings.ToList());
        }

        //
        // GET: /Training/Details/5

        public ActionResult Details(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        //
        // GET: /Training/Create

        public ActionResult Create()
        {
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name");
            return View();
        }

        //
        // POST: /Training/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Training training)
        {
            if (ModelState.IsValid)
            {
                db.Trainings.Add(training);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", training.traineeId);
            return View(training);
        }

        //
        // GET: /Training/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", training.traineeId);
            return View(training);
        }

        //
        // POST: /Training/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Training training)
        {
            if (ModelState.IsValid)
            {
                db.Entry(training).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", training.traineeId);
            return View(training);
        }

        //
        // GET: /Training/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Training training = db.Trainings.Find(id);
            if (training == null)
            {
                return HttpNotFound();
            }
            return View(training);
        }

        //
        // POST: /Training/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Training training = db.Trainings.Find(id);
            db.Trainings.Remove(training);
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