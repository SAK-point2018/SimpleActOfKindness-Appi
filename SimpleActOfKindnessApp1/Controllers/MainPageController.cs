using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;
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

        // GET: Views/Prize
        public ActionResult Prize()
        {
            return RedirectToAction("Prize/Prize");
        }
        public JsonResult getlist()
        {
            SAKEntities entities = new SAKEntities();

            var model = (from t in entities.SAKteot
                         select new
                         {
                             TekoID = t.TekoID,
                             TeonNimi = t.TeonNimi

                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);


        }
    }
}
