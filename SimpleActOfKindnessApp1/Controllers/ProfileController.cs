using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;
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
        //tehtyjen tekojen listaaminen
        public JsonResult Tehdytteotlista()
        {
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            var tehtyteko = (from tt in entities.SAKtehdytteot
                             select new
                             {
                                 Tekopvm = tt.Tekopvm
                             }).ToList();

            string json = JsonConvert.SerializeObject(tehtyteko);
            entities.Dispose(); //muistin vapautus

            Response.Expires = -1;
            Response.CacheControl = "no-cache";
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}