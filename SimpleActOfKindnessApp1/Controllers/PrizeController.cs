using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace SimpleActOfKindnessApp1.Controllers
{
    public class PrizeController : Controller
    {
        // GET: Prize
        public ActionResult Prize()
        {
            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }

        SqlConnection conn = new SqlConnection("Data Source=vsc");
        SqlCommand command;
        string imgLoc = "";
       

    }

}