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
    public class MeterReadsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/MeterReadsAPI
        public IQueryable<meterread> Getmeterreads()
        {
            return db.meterreads;
        }

        // GET: api/MeterReadsAPI/5
        [ResponseType(typeof(meterread))]
        public IHttpActionResult Getmeterread(int id)
        {
            meterread meterread = db.meterreads.Find(id);
            if (meterread == null)
            {
                return NotFound();
            }

            return Ok(meterread);
        }

        // PUT: api/MeterReadsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmeterread(int id, meterread meterread)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != meterread.ID)
            {
                return BadRequest();
            }

            db.Entry(meterread).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!meterreadExists(id))
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

        // POST: api/MeterReadsAPI
        [ResponseType(typeof(meterread))]
        public IHttpActionResult Postmeterread(meterread meterread)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.meterreads.Add(meterread);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = meterread.ID }, meterread);
        }

        // DELETE: api/MeterReadsAPI/5
        [ResponseType(typeof(meterread))]
        public IHttpActionResult Deletemeterread(int id)
        {
            meterread meterread = db.meterreads.Find(id);
            if (meterread == null)
            {
                return NotFound();
            }

            db.meterreads.Remove(meterread);
            db.SaveChanges();

            return Ok(meterread);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool meterreadExists(int id)
        {
            return db.meterreads.Count(e => e.ID == id) > 0;
        }
    }
}