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
    public class ViolationCodesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ViolationCodesAPI
        public IQueryable<violationcode> Getviolationcodes()
        {
            return db.violationcodes;
        }

        // GET: api/ViolationCodesAPI/5
        [ResponseType(typeof(violationcode))]
        public IHttpActionResult Getviolationcode(int id)
        {
            violationcode violationcode = db.violationcodes.Find(id);
            if (violationcode == null)
            {
                return NotFound();
            }

            return Ok(violationcode);
        }

        // PUT: api/ViolationCodesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putviolationcode(int id, violationcode violationcode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != violationcode.ID)
            {
                return BadRequest();
            }

            db.Entry(violationcode).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!violationcodeExists(id))
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

        // POST: api/ViolationCodesAPI
        [ResponseType(typeof(violationcode))]
        public IHttpActionResult Postviolationcode(violationcode violationcode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.violationcodes.Add(violationcode);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = violationcode.ID }, violationcode);
        }

        // DELETE: api/ViolationCodesAPI/5
        [ResponseType(typeof(violationcode))]
        public IHttpActionResult Deleteviolationcode(int id)
        {
            violationcode violationcode = db.violationcodes.Find(id);
            if (violationcode == null)
            {
                return NotFound();
            }

            db.violationcodes.Remove(violationcode);
            db.SaveChanges();

            return Ok(violationcode);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool violationcodeExists(int id)
        {
            return db.violationcodes.Count(e => e.ID == id) > 0;
        }
    }
}