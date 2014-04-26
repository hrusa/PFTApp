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
    public class MeasureController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Measure/

        public ActionResult Index()
        {
            var measures = db.Measures.Include(m => m.trainee).Include(m => m.attribute);
            return View(measures.ToList());
        }

        //
        // GET: /Measure/Details/5

        public ActionResult Details(int id = 0)
        {
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        //
        // GET: /Measure/Create

        public ActionResult Create()
        {
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name");
            ViewBag.attributeId = new SelectList(db.Attributes, "id", "name");
            return View();
        }

        //
        // POST: /Measure/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Measures.Add(measure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", measure.traineeId);
            ViewBag.attributeId = new SelectList(db.Attributes, "id", "name", measure.attributeId);
            return View(measure);
        }

        //
        // GET: /Measure/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", measure.traineeId);
            ViewBag.attributeId = new SelectList(db.Attributes, "id", "name", measure.attributeId);
            return View(measure);
        }

        //
        // POST: /Measure/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Measure measure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(measure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.traineeId = new SelectList(db.Trainees, "id", "name", measure.traineeId);
            ViewBag.attributeId = new SelectList(db.Attributes, "id", "name", measure.attributeId);
            return View(measure);
        }

        //
        // GET: /Measure/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Measure measure = db.Measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        //
        // POST: /Measure/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Measure measure = db.Measures.Find(id);
            db.Measures.Remove(measure);
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