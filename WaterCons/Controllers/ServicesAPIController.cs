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
    public class ServicesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ServicesAPI
        public IQueryable<service> Getservices()
        {
            return db.services;
        }

        // GET: api/ServicesAPI/5
        [ResponseType(typeof(service))]
        public IHttpActionResult Getservice(int id)
        {
            service service = db.services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            return Ok(service);
        }

        // PUT: api/ServicesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putservice(int id, service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != service.ID)
            {
                return BadRequest();
            }

            db.Entry(service).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!serviceExists(id))
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

        // POST: api/ServicesAPI
        [ResponseType(typeof(service))]
        public IHttpActionResult Postservice(service service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.services.Add(service);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = service.ID }, service);
        }

        // DELETE: api/ServicesAPI/5
        [ResponseType(typeof(service))]
        public IHttpActionResult Deleteservice(int id)
        {
            service service = db.services.Find(id);
            if (service == null)
            {
                return NotFound();
            }

            db.services.Remove(service);
            db.SaveChanges();

            return Ok(service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool serviceExists(int id)
        {
            return db.services.Count(e => e.ID == id) > 0;
        }
    }
}