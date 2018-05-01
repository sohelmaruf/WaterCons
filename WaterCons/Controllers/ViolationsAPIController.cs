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
    public class ViolationsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ViolationsAPI
        public IQueryable<violationcas> Getviolationcases()
        {
            return db.violationcases;
        }

        // GET: api/ViolationsAPI/5
        [ResponseType(typeof(violationcas))]
        public IHttpActionResult Getviolationcas(int id)
        {
            violationcas violationcas = db.violationcases.Find(id);
            if (violationcas == null)
            {
                return NotFound();
            }

            return Ok(violationcas);
        }

        // PUT: api/ViolationsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putviolationcas(int id, violationcas violationcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != violationcas.ID)
            {
                return BadRequest();
            }

            db.Entry(violationcas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!violationcasExists(id))
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

        // POST: api/ViolationsAPI
        [ResponseType(typeof(violationcas))]
        public IHttpActionResult Postviolationcas(violationcas violationcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.violationcases.Add(violationcas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = violationcas.ID }, violationcas);
        }

        // DELETE: api/ViolationsAPI/5
        [ResponseType(typeof(violationcas))]
        public IHttpActionResult Deleteviolationcas(int id)
        {
            violationcas violationcas = db.violationcases.Find(id);
            if (violationcas == null)
            {
                return NotFound();
            }

            db.violationcases.Remove(violationcas);
            db.SaveChanges();

            return Ok(violationcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool violationcasExists(int id)
        {
            return db.violationcases.Count(e => e.ID == id) > 0;
        }
    }
}