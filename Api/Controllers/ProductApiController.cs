using Api.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Api.Controllers
{
    public class ProductApiController : ApiController
    {

        WebApiEntities obj_databaseContext = new WebApiEntities();

        // GET: api/Staff_Table
        public IQueryable<ProductTable> GetProduct_Table()
        {
            return obj_databaseContext.ProductTables;
        }


        // GET: api/Staff_Table/5
        [ResponseType(typeof(ProductTable))]
        public IHttpActionResult GetProduct_Table(int id)
        {
            ProductTable product_table = obj_databaseContext.ProductTables.Find(id);
            if (product_table == null)
            {
                return NotFound();
            }

            return Ok(product_table);
        }



        private bool product_TableExists(int id)
        {
            return obj_databaseContext.ProductTables.Count(e => e.id == id) > 0;

        }
        // PUT: api/Staff_Table/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaff_Table(int id, ProductTable product_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_Table.id)
            {
                return BadRequest();
            }

            obj_databaseContext.Entry(product_Table).State = EntityState.Modified;

            try
            {
                obj_databaseContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!product_TableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Staff_Table
        [ResponseType(typeof(ProductTable))]
        public IHttpActionResult PostStaff_Table(ProductTable product_Table)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            obj_databaseContext.ProductTables.Add(product_Table);
            obj_databaseContext.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product_Table.id }, product_Table);
        }



        // DELETE: api/Staff_Table/5
        [ResponseType(typeof(ProductTable))]
        public IHttpActionResult Deleteproduct_Table(int id)
        {
            ProductTable product_Table = obj_databaseContext.ProductTables.Find(id);
            if (product_Table == null)
            {
                return NotFound();
            }

            obj_databaseContext.ProductTables.Remove(product_Table);
            obj_databaseContext.SaveChanges();

            return Ok(product_Table);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                obj_databaseContext.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
