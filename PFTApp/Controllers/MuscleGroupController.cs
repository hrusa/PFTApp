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
    public class MuscleGroupController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /MuscleGroup/

        public ActionResult Index()
        {
            return View(db.MuscleGroups.ToList());
        }

        //
        // GET: /MuscleGroup/Details/5

        public ActionResult Details(int id = 0)
        {
            MuscleGroup musclegroup = db.MuscleGroups.Find(id);
            if (musclegroup == null)
            {
                return HttpNotFound();
            }
            return View(musclegroup);
        }

        //
        // GET: /MuscleGroup/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MuscleGroup/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MuscleGroup musclegroup)
        {
            if (ModelState.IsValid)
            {
                db.MuscleGroups.Add(musclegroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musclegroup);
        }

        //
        // GET: /MuscleGroup/Edit/5

        public ActionResult Edit(int id = 0)
        {
            MuscleGroup musclegroup = db.MuscleGroups.Find(id);
            if (musclegroup == null)
            {
                return HttpNotFound();
            }
            return View(musclegroup);
        }

        //
        // POST: /MuscleGroup/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MuscleGroup musclegroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musclegroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musclegroup);
        }

        //
        // GET: /MuscleGroup/Delete/5

        public ActionResult Delete(int id = 0)
        {
            MuscleGroup musclegroup = db.MuscleGroups.Find(id);
            if (musclegroup == null)
            {
                return HttpNotFound();
            }
            return View(musclegroup);
        }

        //
        // POST: /MuscleGroup/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MuscleGroup musclegroup = db.MuscleGroups.Find(id);
            db.MuscleGroups.Remove(musclegroup);
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