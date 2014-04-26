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
    public class AttributeController : Controller
    {
        private PFTContext db = new PFTContext();

        //
        // GET: /Attribute/

        public ActionResult Index()
        {
            return View(db.Attributes.ToList());
        }

        //
        // GET: /Attribute/Details/5

        public ActionResult Details(int id = 0)
        {
            PFTApp.Models.Attribute attribute = db.Attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        //
        // GET: /Attribute/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Attribute/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PFTApp.Models.Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                db.Attributes.Add(attribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attribute);
        }

        //
        // GET: /Attribute/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PFTApp.Models.Attribute attribute = db.Attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        //
        // POST: /Attribute/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PFTApp.Models.Attribute attribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attribute);
        }

        //
        // GET: /Attribute/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PFTApp.Models.Attribute attribute = db.Attributes.Find(id);
            if (attribute == null)
            {
                return HttpNotFound();
            }
            return View(attribute);
        }

        //
        // POST: /Attribute/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PFTApp.Models.Attribute attribute = db.Attributes.Find(id);
            db.Attributes.Remove(attribute);
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