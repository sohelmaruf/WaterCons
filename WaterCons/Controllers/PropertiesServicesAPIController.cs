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
    public class PropertiesServicesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PropertiesServicesAPI
        public IQueryable<propertiesservice> Getpropertiesservices()
        {
            return db.propertiesservices;
        }

        // GET: api/PropertiesServicesAPI/5
        [ResponseType(typeof(propertiesservice))]
        public IHttpActionResult Getpropertiesservice(int id)
        {
            propertiesservice propertiesservice = db.propertiesservices.Find(id);
            if (propertiesservice == null)
            {
                return NotFound();
            }

            return Ok(propertiesservice);
        }

        // PUT: api/PropertiesServicesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpropertiesservice(int id, propertiesservice propertiesservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertiesservice.ID)
            {
                return BadRequest();
            }

            db.Entry(propertiesservice).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertiesserviceExists(id))
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

        // POST: api/PropertiesServicesAPI
        [ResponseType(typeof(propertiesservice))]
        public IHttpActionResult Postpropertiesservice(propertiesservice propertiesservice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.propertiesservices.Add(propertiesservice);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = propertiesservice.ID }, propertiesservice);
        }

        // DELETE: api/PropertiesServicesAPI/5
        [ResponseType(typeof(propertiesservice))]
        public IHttpActionResult Deletepropertiesservice(int id)
        {
            propertiesservice propertiesservice = db.propertiesservices.Find(id);
            if (propertiesservice == null)
            {
                return NotFound();
            }

            db.propertiesservices.Remove(propertiesservice);
            db.SaveChanges();

            return Ok(propertiesservice);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool propertiesserviceExists(int id)
        {
            return db.propertiesservices.Count(e => e.ID == id) > 0;
        }
    }
}