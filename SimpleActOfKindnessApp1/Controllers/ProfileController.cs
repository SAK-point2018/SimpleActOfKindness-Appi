using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            //tietokantahaku
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            var tehtyteko = (from tt in entities.SAKtehdytteot 
                             select new
                             {
                                 Tekopvm = tt.Tekopvm,

                             }).ToList();

            string json = JsonConvert.SerializeObject(tehtyteko); //objekti JSON-muotoon
            entities.Dispose(); //muistin vapautus

            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";
            //tulosten palautus
            return Json(json, JsonRequestBehavior.AllowGet);
        }

    }
}