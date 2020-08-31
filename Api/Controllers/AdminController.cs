using Api.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class AdminController : Controller
    {
        databaseContext object_Sql = new databaseContext();

        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }

        // GET: Admin
        public ActionResult AdminZone()
        {
            return View();
        }

        // GET: Admin
        public ActionResult invalid()
        {
            return View();
        }





        [HttpPost]
        public ActionResult loginAuthenticate(Login user)
        {
            //Pass the data to store the record into the table 

            DataTable tbl = new DataTable();
            tbl=object_Sql.CheckLogin("select * from LoginTable where UserName='" + user.userName + "'and Password='" + user.userPassword + "'");

            if (tbl.Rows.Count > 0)
            {
                return View("AdminZone");
            }
            else {
                return View("invalid");
            }



        }


    }
}