using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Api.Controllers
{
    public class ProductController : Controller
    {
        WebApiEntities obj_databaseContext = new WebApiEntities();
        // GET: Product
        public ActionResult viewProduct()
        {
            return View(obj_databaseContext.ProductTables.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "id")] ProductTable product)
        {
            if (!ModelState.IsValid)
                return View();
            obj_databaseContext.ProductTables.Add(product);
            obj_databaseContext.SaveChanges();
            return RedirectToAction("viewProduct");

        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in obj_databaseContext.ProductTables where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductTable IdToEdit)
        {

            var orignalRecord = (from m in obj_databaseContext.ProductTables where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj_databaseContext.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            obj_databaseContext.SaveChanges();
            return RedirectToAction("viewProduct");


        }

        // GET: Product/Delete/5
        public ActionResult Delete(ProductTable IdToDel)
        {
            var d = obj_databaseContext.ProductTables.Where(x => x.id == IdToDel.id).FirstOrDefault();
            obj_databaseContext.ProductTables.Remove(d);
            obj_databaseContext.SaveChanges();
            return RedirectToAction("viewProduct");
        }

        // POST: Product/Delete/5
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
