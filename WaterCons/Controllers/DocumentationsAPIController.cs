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
    public class DocumentationsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DocumentationsAPI
        public IQueryable<documentation> Getdocumentations()
        {
            return db.documentations;
        }

        // GET: api/DocumentationsAPI/5
        [ResponseType(typeof(documentation))]
        public IHttpActionResult Getdocumentation(int id)
        {
            documentation documentation = db.documentations.Find(id);
            if (documentation == null)
            {
                return NotFound();
            }

            return Ok(documentation);
        }

        // PUT: api/DocumentationsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdocumentation(int id, documentation documentation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentation.ID)
            {
                return BadRequest();
            }

            db.Entry(documentation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!documentationExists(id))
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

        // POST: api/DocumentationsAPI
        [ResponseType(typeof(documentation))]
        public IHttpActionResult Postdocumentation(documentation documentation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.documentations.Add(documentation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentation.ID }, documentation);
        }

        // DELETE: api/DocumentationsAPI/5
        [ResponseType(typeof(documentation))]
        public IHttpActionResult Deletedocumentation(int id)
        {
            documentation documentation = db.documentations.Find(id);
            if (documentation == null)
            {
                return NotFound();
            }

            db.documentations.Remove(documentation);
            db.SaveChanges();

            return Ok(documentation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool documentationExists(int id)
        {
            return db.documentations.Count(e => e.ID == id) > 0;
        }
    }
}