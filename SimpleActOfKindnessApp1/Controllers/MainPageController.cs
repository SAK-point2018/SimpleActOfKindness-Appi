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
    public class MainPageController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult HyvaTeko()
        {
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            CultureInfo fiFI = new CultureInfo("fi-FI");

            var hyvateko = (from teot in entities.SAKteot

                            select new
                            {
                                TeonNimi = teot.TeonNimi,
                                TekoID = teot.TekoID

                            }).ToList();

            string json = JsonConvert.SerializeObject(hyvateko);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
            //return Json(json.AsEnumerable().Select(r => new
            //{
            //    voimassaolopvm = r.voimassaolopvm.GetValueOrDefault().ToString("dd.MM.yyyy"),
            //    palkintonimi = r.palkintonimi
            //}), JsonRequestBehavior.AllowGet);

        }

        //tehtyjen tekojen listaaminen
    }
}
