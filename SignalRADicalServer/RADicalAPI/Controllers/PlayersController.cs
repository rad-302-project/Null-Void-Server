using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using RADicalAPI.Models;

namespace RADicalAPI.Controllers
{
    //[System.Web.Mvc.Authorize] // This line ensures that only logged in players can view the leaderboard.
    public class PlayersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // URL followed by "/Players" to access this view directly.
        // Access will be denied if the user has not been authenticated.
        public ActionResult Leaderboard()
        {
            return View(db.Users.ToList().OrderByDescending(u => u.HighScore));
        }       
    }
}