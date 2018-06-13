using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization; //Dan 5.6.2018

namespace SimpleActOfKindnessApp1.Controllers
{
    public class lunastusController : Controller
    {
        // GET: lunastus
        public ActionResult Index()
        {
            //ScrumDB2018KEntities1 entities = new ScrumDB2018KEntities1();
            //var model = (from tt in entities.SAKtehdytteot
            //             where tt.PalkintoID == 102
            //             select new
            //             {
            //                 TehdytTeotID = tt.TehdytTeotID,
            //                 KayttajaID = tt.KayttajaID,
            //                 Tekopvm = tt.Tekopvm,
            //                 PalkintoID = tt.PalkintoID,
            //                 VoimassaOloPvm = tt.VoimassaOloPvm,
            //                 TekoID = tt.TekoID
            //             }).ToList();

            ////string json = JsonConvert.SerializeObject(model);
            //entities.Dispose();

            ////return Json(json, JsonRequestBehavior.AllowGet);
            //return View(model);
            

            List<SAKtehdytteot> model = new List<SAKtehdytteot>();  
            try
            {
                ScrumDB2018KEntities1 entities = new ScrumDB2018KEntities1();
                model = entities.SAKtehdytteot.ToList();
                entities.Dispose();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.GetType() + ": " + ex.Message;
            }

            return View(model);
        }
    
        public ActionResult ShowSinglePrize(string id)
        {
            CultureInfo culture = new CultureInfo("fi-FI");  //Dan 5.6.2018
            try
            {
                int ipalkintoID = int.Parse(id);
                ScrumDB2018KEntities1 entities = new ScrumDB2018KEntities1();
                //Dan 5.6.2018: LINQ -kyselyn kehittäminen
                var model = (from p in entities.SAKpalkinto
                                 join t in entities.SAKtehdytteot on p.PalkintoID equals t.PalkintoID
                                 join k in entities.SAKkayttaja on t.KayttajaID equals k.KayttajaID
                                 join r in entities.SAKpalkinnontarjoaja on p.PalkinnonTarjoajaID equals r.PalkinnontarjoajaID
                                 where p.PalkintoID == ipalkintoID //Anne 6.6.2018
                                 select new
                                 {
                                     palkintonimi = p.PalkintoNimi,
                                     yrityksennimi = r.YrityksenNimi,
                                     kayttajatunnus = k.Kayttajatunnus,
                                     TehdytTeotID = t.TehdytTeotID,
                                     KayttajaID = t.KayttajaID,
                                     Tekopvm = t.Tekopvm,
                                     PalkintoNimi = p.PalkintoNimi,
                                     PalkintoID = t.PalkintoID,
                                     VoimassaOloPvm = t.VoimassaOloPvm,
                                     TekoID = t.TekoID

                                 }).FirstOrDefault();

                ViewBag.TehdytTeotID = model.TehdytTeotID;
                ViewBag.KayttajaID = model.KayttajaID;
                ViewBag.Tekopvm = model.Tekopvm.ToString("d", culture);  //Dan 5.6.2018
                ViewBag.PalkintoNimi = model.PalkintoNimi;
                ViewBag.PalkintoID = model.PalkintoID;
                ViewBag.VoimassaOloPvm = model.VoimassaOloPvm.ToString("D",culture);   //Dan 5.6.2018
                ViewBag.TekoID = model.TekoID;
                ViewBag.PalkinnonKayttoPolku = "/lunastus/UseSinglePrize/"+model.PalkintoID;

                ViewBag.DBMessage = "Tietokantahaku onnistui!";
                //string json = JsonConvert.SerializeObject(model);
                entities.Dispose();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.DBMessage = ex.GetType() + ": " + ex.Message;
                return View();
            }
            
            //return Json(json, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UseSinglePrize(string id)
        {
            bool OK = false;
            ScrumDB2018KEntities1 entities = new ScrumDB2018KEntities1();
            int ipalkintoID = int.Parse(id);

            // muokkaus, haetaan id:n perusteella riviä tietokannasta
            SAKtehdytteot db = (from t in entities.SAKtehdytteot
                               where t.PalkintoID == ipalkintoID
                              select t).FirstOrDefault();
            if (db != null)
            {
                db.Status = 1;
                // tallennus tietokantaan
                entities.SaveChanges();
                OK = true;
            }
        
            entities.Dispose();
            return Json(OK, JsonRequestBehavior.AllowGet);
            //return View();
        }
    }
}