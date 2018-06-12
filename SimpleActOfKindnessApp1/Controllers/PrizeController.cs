using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;

namespace SimpleActOfKindnessApp1.Controllers
{
    public class PrizeController : Controller
    {
        // GET: Prize
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainPage()
        {
            return View();
        }
        public ActionResult GetPalkinnot(string kayttajaid)
        {
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            var palkinnot = (from p in entities.SAKpalkinto
                             join t in entities.SAKtehdytteot on p.PalkintoID equals t.PalkintoID
                             join k in entities.SAKkayttaja on t.KayttajaID equals k.KayttajaID
                             join r in entities.SAKpalkinnontarjoaja on p.PalkinnonTarjoajaID equals r.PalkinnontarjoajaID
                             select new
                             {
                                 palkintonimi = p.PalkintoNimi,
                                 yrityksennimi = r.YrityksenNimi,
                                 kayttajatunnus = k.Kayttajatunnus

                             }).ToList();

            string json = JsonConvert.SerializeObject(palkinnot);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Palkinto()
        {
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            var palkinto = (from palk in entities.SAKpalkinto

                            select new
                            {
                                PalkintoID = palk.PalkintoID,
                                PalkintoNimi = palk.PalkintoNimi,
                                PalkinnonTarjoajaID = palk.PalkinnonTarjoajaID,
                                PalkintoKuva = palk.PalkintoKuva,
                                KuvanKoko = palk.KuvanKoko                                
                            }).ToList();

            string json = JsonConvert.SerializeObject(palkinto);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}