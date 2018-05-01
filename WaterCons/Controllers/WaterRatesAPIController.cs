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
    public class WaterRatesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/WaterRatesAPI
        public IQueryable<waterrate> Getwaterrates()
        {
            return db.waterrates;
        }

        // GET: api/WaterRatesAPI/5
        [ResponseType(typeof(waterrate))]
        public IHttpActionResult Getwaterrate(int id)
        {
            waterrate waterrate = db.waterrates.Find(id);
            if (waterrate == null)
            {
                return NotFound();
            }

            return Ok(waterrate);
        }

        // PUT: api/WaterRatesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putwaterrate(int id, waterrate waterrate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != waterrate.ID)
            {
                return BadRequest();
            }

            db.Entry(waterrate).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!waterrateExists(id))
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

        // POST: api/WaterRatesAPI
        [ResponseType(typeof(waterrate))]
        public IHttpActionResult Postwaterrate(waterrate waterrate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.waterrates.Add(waterrate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = waterrate.ID }, waterrate);
        }

        // DELETE: api/WaterRatesAPI/5
        [ResponseType(typeof(waterrate))]
        public IHttpActionResult Deletewaterrate(int id)
        {
            waterrate waterrate = db.waterrates.Find(id);
            if (waterrate == null)
            {
                return NotFound();
            }

            db.waterrates.Remove(waterrate);
            db.SaveChanges();

            return Ok(waterrate);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool waterrateExists(int id)
        {
            return db.waterrates.Count(e => e.ID == id) > 0;
        }
    }
}