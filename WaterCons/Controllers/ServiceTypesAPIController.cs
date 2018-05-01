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
    public class ServiceTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ServiceTypesAPI
        public IQueryable<servicetype> Getservicetypes()
        {
            return db.servicetypes;
        }

        // GET: api/ServiceTypesAPI/5
        [ResponseType(typeof(servicetype))]
        public IHttpActionResult Getservicetype(int id)
        {
            servicetype servicetype = db.servicetypes.Find(id);
            if (servicetype == null)
            {
                return NotFound();
            }

            return Ok(servicetype);
        }

        // PUT: api/ServiceTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putservicetype(int id, servicetype servicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servicetype.ID)
            {
                return BadRequest();
            }

            db.Entry(servicetype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servicetypeExists(id))
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

        // POST: api/ServiceTypesAPI
        [ResponseType(typeof(servicetype))]
        public IHttpActionResult Postservicetype(servicetype servicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.servicetypes.Add(servicetype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = servicetype.ID }, servicetype);
        }

        // DELETE: api/ServiceTypesAPI/5
        [ResponseType(typeof(servicetype))]
        public IHttpActionResult Deleteservicetype(int id)
        {
            servicetype servicetype = db.servicetypes.Find(id);
            if (servicetype == null)
            {
                return NotFound();
            }

            db.servicetypes.Remove(servicetype);
            db.SaveChanges();

            return Ok(servicetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool servicetypeExists(int id)
        {
            return db.servicetypes.Count(e => e.ID == id) > 0;
        }
    }
}