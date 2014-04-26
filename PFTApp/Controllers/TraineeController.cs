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
    public class TraineeController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Trainee/

        public ActionResult Index()
        {
            return View(db.Trainees.ToList());
        }

        //
        // GET: /Trainee/Details/5

        public ActionResult Details(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        //
        // GET: /Trainee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Trainee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Trainees.Add(trainee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainee);
        }

        //
        // GET: /Trainee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        //
        // POST: /Trainee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainee);
        }

        //
        // GET: /Trainee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Trainee trainee = db.Trainees.Find(id);
            if (trainee == null)
            {
                return HttpNotFound();
            }
            return View(trainee);
        }

        //
        // POST: /Trainee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
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