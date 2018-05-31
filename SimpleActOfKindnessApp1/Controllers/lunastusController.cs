using Newtonsoft.Json;
using SimpleActOfKindnessApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleActOfKindnessApp1.Controllers
{
    public class lunastusController : Controller
    {
        // GET: lunastus
        public ActionResult Index()
        {
            //ScrumDB2018KEntities entities = new ScrumDB2018KEntities();
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
                ScrumDB2018KEntities entities = new ScrumDB2018KEntities();
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
            try
            {
                int ipalkintoID = int.Parse(id);
                ScrumDB2018KEntities entities = new ScrumDB2018KEntities();
                var model = (from tt in entities.SAKtehdytteot
                             where tt.PalkintoID == ipalkintoID
                             select new
                             {
                                 TehdytTeotID = tt.TehdytTeotID,
                                 KayttajaID = tt.KayttajaID,
                                 Tekopvm = tt.Tekopvm,
                                 PalkintoID = tt.PalkintoID,
                                 VoimassaOloPvm = tt.VoimassaOloPvm,
                                 TekoID = tt.TekoID
                             }).FirstOrDefault();

                ViewBag.TehdytTeotID = model.TehdytTeotID;
                ViewBag.KayttajaID = model.KayttajaID;
                ViewBag.Tekopvm = model.Tekopvm;
                ViewBag.PalkintoID = model.PalkintoID;
                ViewBag.VoimassaOloPvm = model.VoimassaOloPvm;
                ViewBag.TekoID = model.TekoID;

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

    }
}