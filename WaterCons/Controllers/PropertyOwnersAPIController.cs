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
    public class PropertyOwnersAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PropertyOwnersAPI
        public IQueryable<propertyowner> Getpropertyowners()
        {
            return db.propertyowners;
        }

        // GET: api/PropertyOwnersAPI/5
        [ResponseType(typeof(propertyowner))]
        public IHttpActionResult Getpropertyowner(int id)
        {
            propertyowner propertyowner = db.propertyowners.Find(id);
            if (propertyowner == null)
            {
                return NotFound();
            }

            return Ok(propertyowner);
        }

        // PUT: api/PropertyOwnersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpropertyowner(int id, propertyowner propertyowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propertyowner.ID)
            {
                return BadRequest();
            }

            db.Entry(propertyowner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!propertyownerExists(id))
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

        // POST: api/PropertyOwnersAPI
        [ResponseType(typeof(propertyowner))]
        public IHttpActionResult Postpropertyowner(propertyowner propertyowner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.propertyowners.Add(propertyowner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = propertyowner.ID }, propertyowner);
        }

        // DELETE: api/PropertyOwnersAPI/5
        [ResponseType(typeof(propertyowner))]
        public IHttpActionResult Deletepropertyowner(int id)
        {
            propertyowner propertyowner = db.propertyowners.Find(id);
            if (propertyowner == null)
            {
                return NotFound();
            }

            db.propertyowners.Remove(propertyowner);
            db.SaveChanges();

            return Ok(propertyowner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool propertyownerExists(int id)
        {
            return db.propertyowners.Count(e => e.ID == id) > 0;
        }
    }
}