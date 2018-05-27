﻿using Newtonsoft.Json;
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



        public JsonResult Lunastamattomatpalkinnot()
        {
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            var lunastamattomat = (from lun in entities.SAKtehdytteot
                                   join palkinto in entities.SAKpalkinto 
                                   on lun.PalkintoID equals palkinto.PalkintoID
                                   select new
                                   {
                                       palkintonimi = palkinto.PalkintoNimi,
                                       voimassaolopvm = lun.VoimassaOloPvm

                                   }).ToList();

            string json = JsonConvert.SerializeObject(lunastamattomat);
            entities.Dispose();

            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);


        }


        //tehtyjen tekojen listaaminen
        public JsonResult Tehdytteotlista()
        {
            //tietokantahaku
            ScrumDB2018KEntities entities = new ScrumDB2018KEntities();

            //SAKteot- ja SAKtehdytteot-taulujen liitos InnerJoinilla
            //(TeonNimi täytyy hakea SAKteot-taulusta)
            var innerJoinQuery = (from tehtyteko in entities.SAKtehdytteot
                                  join teot in entities.SAKteot 
                                  on tehtyteko.TekoID equals teot.TekoID
                                  select new
                                  {
                                      Tekopvm = tehtyteko.Tekopvm,
                                      TeonNimi = teot.TeonNimi

                                  }).ToList();

            string json = JsonConvert.SerializeObject(innerJoinQuery); //objekti JSON-muotoon
            entities.Dispose(); //muistin vapautus

            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";
            //tulosten palautus
            return Json(json, JsonRequestBehavior.AllowGet);
        }


    }
}