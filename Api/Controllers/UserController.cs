using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        WebApiEntities obj_databaseContext = new WebApiEntities();

        public ActionResult AllUser()
        {
            return View(obj_databaseContext.UserTables.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj_databaseContext.UserTables where m.ID == id select m).First();
            return View(IdToEdit);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(UserTable IdToEdit)
        {

            var orignalRecord = (from m in obj_databaseContext.UserTables where m.ID == IdToEdit.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj_databaseContext.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj_databaseContext.SaveChanges();
            return RedirectToAction("AllUser");

        }

        // GET: User/Delete/5
        public ActionResult Delete(UserTable IdToDel)
        {

            var d = obj_databaseContext.UserTables.Where(x => x.ID == IdToDel.ID).FirstOrDefault();
            obj_databaseContext.UserTables.Remove(d);
            obj_databaseContext.SaveChanges();
            return RedirectToAction("AllUser");
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
