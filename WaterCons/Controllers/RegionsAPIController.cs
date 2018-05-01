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
    public class RegionsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/RegionsAPI
        public IQueryable<region> Getregions()
        {
            return db.regions;
        }

        // GET: api/RegionsAPI/5
        [ResponseType(typeof(region))]
        public IHttpActionResult Getregion(int id)
        {
            region region = db.regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/RegionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putregion(int id, region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != region.ID)
            {
                return BadRequest();
            }

            db.Entry(region).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!regionExists(id))
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

        // POST: api/RegionsAPI
        [ResponseType(typeof(region))]
        public IHttpActionResult Postregion(region region)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.regions.Add(region);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = region.ID }, region);
        }

        // DELETE: api/RegionsAPI/5
        [ResponseType(typeof(region))]
        public IHttpActionResult Deleteregion(int id)
        {
            region region = db.regions.Find(id);
            if (region == null)
            {
                return NotFound();
            }

            db.regions.Remove(region);
            db.SaveChanges();

            return Ok(region);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool regionExists(int id)
        {
            return db.regions.Count(e => e.ID == id) > 0;
        }
    }
}