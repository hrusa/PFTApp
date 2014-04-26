using PFTApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PFTApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Statistics()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TraineeForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TraineeForm(Trainee model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Statistics");
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
