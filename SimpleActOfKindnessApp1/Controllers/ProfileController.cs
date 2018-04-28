using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleActOfKindnessApp1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult ProfilePage()
        {
            return View();
        }
    }
}