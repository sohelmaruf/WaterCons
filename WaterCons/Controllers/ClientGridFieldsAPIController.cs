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
    public class ClientGridFieldsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ClientgridfieldsAPI
        public IQueryable<clientgridfield> Getclientgridfields()
        {
            return db.clientgridfields;
        }

        // GET: api/ClientgridfieldsAPI/5
        [ResponseType(typeof(clientgridfield))]
        public IHttpActionResult Getclientgridfield(int id)
        {
            clientgridfield clientgridfield = db.clientgridfields.Find(id);
            if (clientgridfield == null)
            {
                return NotFound();
            }

            return Ok(clientgridfield);
        }

        // PUT: api/ClientgridfieldsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclientgridfield(int id, clientgridfield clientgridfield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientgridfield.ID)
            {
                return BadRequest();
            }

            db.Entry(clientgridfield).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientgridfieldExists(id))
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

        // POST: api/ClientgridfieldsAPI
        [ResponseType(typeof(clientgridfield))]
        public IHttpActionResult Postclientgridfield(clientgridfield clientgridfield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.clientgridfields.Add(clientgridfield);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientgridfield.ID }, clientgridfield);
        }

        // DELETE: api/ClientgridfieldsAPI/5
        [ResponseType(typeof(clientgridfield))]
        public IHttpActionResult Deleteclientgridfield(int id)
        {
            clientgridfield clientgridfield = db.clientgridfields.Find(id);
            if (clientgridfield == null)
            {
                return NotFound();
            }

            db.clientgridfields.Remove(clientgridfield);
            db.SaveChanges();

            return Ok(clientgridfield);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientgridfieldExists(int id)
        {
            return db.clientgridfields.Count(e => e.ID == id) > 0;
        }
    }
}