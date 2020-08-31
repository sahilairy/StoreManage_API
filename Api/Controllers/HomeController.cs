using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        databaseContext object_Sql = new databaseContext();

        WebApiEntities obj_databaseContext = new WebApiEntities();
        // GET: Product
        public ActionResult viewFeedback()
        {
            return View(obj_databaseContext.FeedbackTables.ToList());
        }

        // GET: Product/Delete/5
        public ActionResult Delete(FeedbackTable IdToDel)
        {
            var d = obj_databaseContext.FeedbackTables.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj_databaseContext.FeedbackTables.Remove(d);
            obj_databaseContext.SaveChanges();
            return RedirectToAction("viewFeedback");
        }


        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult User()
        {
            ViewBag.Title = "Home Page";
            return View();
        }



       public ActionResult Successfull()
        {
            ViewBag.Title = "Sucessfully Register the Account ";
            return View();
        }



        public ActionResult verify()
        {
            ViewBag.Title = "Veerify the Data once Again ";
            return View();
        }

        public ActionResult sentFeedback()
        {
            ViewBag.Title = "Veerify the Data once Again ";
            return View();
        }


        [HttpPost]
        public ActionResult sendFeedback(Contact dataBlock)
        {
            //Pass the data to store the record into the table 

            object_Sql.Addcontact("insert into FeedbackTable(Name,Email,Subject,Message) values('" + dataBlock.Name + "','" + dataBlock.Email + "','"+ dataBlock.Subject+ "','" + dataBlock.Message + "')");

            return View("Successfull");



        }



        [HttpPost]
        public ActionResult SendMessage(Register userBlock)
        {
            //Pass the data to store the record into the table 

            object_Sql.Addcontact("insert into UserTable(Name,Email,Password) values('"+userBlock.Name+"','"+userBlock.Email+"','"+userBlock.Password+"')");

            return View("Successfull");



        }


    }
}