using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
	

namespace SimpleActOfKindnessApp1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        //GET: Views/ProfilePage
        public ActionResult ProfilePage()
        {
            return RedirectToAction("Profile/ProfilePage");
        }

        // GET: Views/MainPage
        public ActionResult MainPage()
        {
            return RedirectToAction("MainPage/MainPage");
        }
    }
}