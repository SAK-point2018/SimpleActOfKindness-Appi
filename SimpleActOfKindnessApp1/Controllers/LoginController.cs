﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SimpleActOfKindnessApp1.Models;

namespace SimpleActOfKindnessApp1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }

        //GET: Views/ProfilePage
        public ActionResult ProfilePage()
        {
            return RedirectToAction("Profile/ProfilePage");
        }

        // GET: Views/MainPage
        public ActionResult MainPage()
        {
            return RedirectToAction("MainPage/MainPage");
        }
        //protected void ButtonKirjaudu(object sender, EventArgs e)
        //{
        //    //luodaan SQL-connection objekti
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["dbconnection"].ToString());
        //    //avataan tietokantayhteys
        //    conn.Open();
        //    //luodaan Sql-kyselylauseen objektit
        //    //string Ktunnus = sposti.Text;
        //    //string Salas = psw.Text;

        //    //luodaan sql-kyselylause
        //   // string sql = "SELECT*FROM SAKkayttaja WHERE Kayttajatunnus='" + Ktunnus + "' AND Salasana='" + Salas + "'";
        //}


        //entiteetin avulla tietokantakysely
        protected void ButtonKirjaudu(object sender, EventArgs e)
        {
            ScrumDB2018KEntities1 entities = new ScrumDB2018KEntities1();
            //luodaan Sql-kyselylauseen objektit
            //string Ktunnus = sposti.Text;
            //string Salas = psw.Text;

            entities.Dispose(); //muistin vapautus
        }
    }
}