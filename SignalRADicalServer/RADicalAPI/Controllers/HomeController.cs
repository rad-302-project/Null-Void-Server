using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RADicalAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        // Newly-added actions.
        public ActionResult Registration()
        {
            ViewBag.Title = "Player Registration";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";

            return View();
        }

        public ActionResult Launcher()
        {
            ViewBag.Title = "Launcher";

            return View();
        }
    }
}