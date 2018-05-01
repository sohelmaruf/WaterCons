using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WaterCons.Library.Models;

namespace WaterCons.Controllers
{
    public class PropertiesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PropertiesAPI
        public IQueryable<property> Getproperties()
        {
            return db.properties;
        }

        // GET: api/PropertiesAPI/5
        [ResponseType(typeof(property))]
        public IHttpActionResult Getproperty(int id)
        {
            property property = db.properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // PUT: api/PropertiesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproperty(int id, property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != property.ID)
            {
                return BadRequest();
            }

            db.Entry(property).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertyExists(id))
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

        // POST: api/PropertiesAPI
        [ResponseType(typeof(property))]
        public IHttpActionResult Postproperty(property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.properties.Add(property);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = property.ID }, property);
        }

        // DELETE: api/PropertiesAPI/5
        [ResponseType(typeof(property))]
        public IHttpActionResult Deleteproperty(int id)
        {
            property property = db.properties.Find(id);
            if (property == null)
            {
                return NotFound();
            }

            db.properties.Remove(property);
            db.SaveChanges();

            return Ok(property);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool propertyExists(int id)
        {
            return db.properties.Count(e => e.ID == id) > 0;
        }
    }
}