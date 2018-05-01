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
    public class SystemTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/SystemTypesAPI
        public IQueryable<systemtype> Getsystemtypes()
        {
            return db.systemtypes;
        }

        // GET: api/SystemTypesAPI/5
        [ResponseType(typeof(systemtype))]
        public IHttpActionResult Getsystemtype(int id)
        {
            systemtype systemtype = db.systemtypes.Find(id);
            if (systemtype == null)
            {
                return NotFound();
            }

            return Ok(systemtype);
        }

        // PUT: api/SystemTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsystemtype(int id, systemtype systemtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != systemtype.ID)
            {
                return BadRequest();
            }

            db.Entry(systemtype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!systemtypeExists(id))
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

        // POST: api/SystemTypesAPI
        [ResponseType(typeof(systemtype))]
        public IHttpActionResult Postsystemtype(systemtype systemtype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.systemtypes.Add(systemtype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = systemtype.ID }, systemtype);
        }

        // DELETE: api/SystemTypesAPI/5
        [ResponseType(typeof(systemtype))]
        public IHttpActionResult Deletesystemtype(int id)
        {
            systemtype systemtype = db.systemtypes.Find(id);
            if (systemtype == null)
            {
                return NotFound();
            }

            db.systemtypes.Remove(systemtype);
            db.SaveChanges();

            return Ok(systemtype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool systemtypeExists(int id)
        {
            return db.systemtypes.Count(e => e.ID == id) > 0;
        }
    }
}