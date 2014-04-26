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
    public class DifficultyController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Difficulty/

        public ActionResult Index()
        {
            return View(db.Difficulties.ToList());
        }

        //
        // GET: /Difficulty/Details/5

        public ActionResult Details(int id = 0)
        {
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        //
        // GET: /Difficulty/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Difficulty/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                db.Difficulties.Add(difficulty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(difficulty);
        }

        //
        // GET: /Difficulty/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        //
        // POST: /Difficulty/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Difficulty difficulty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(difficulty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(difficulty);
        }

        //
        // GET: /Difficulty/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Difficulty difficulty = db.Difficulties.Find(id);
            if (difficulty == null)
            {
                return HttpNotFound();
            }
            return View(difficulty);
        }

        //
        // POST: /Difficulty/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Difficulty difficulty = db.Difficulties.Find(id);
            db.Difficulties.Remove(difficulty);
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