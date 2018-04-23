using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SimpleActOfKindnessApp1.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPage
        public ActionResult MainPage()
        {
            return View(); 
        }

        // GET: MainPage/Prize
        public ActionResult Prize()
        {
            return RedirectToAction("Prize");
        }
    }
}
