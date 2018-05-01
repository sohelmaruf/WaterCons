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
    public class PhasesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PhasesAPI
        public IQueryable<phase> Getphases()
        {
            return db.phases;
        }

        // GET: api/PhasesAPI/5
        [ResponseType(typeof(phase))]
        public IHttpActionResult Getphase(int id)
        {
            phase phase = db.phases.Find(id);
            if (phase == null)
            {
                return NotFound();
            }

            return Ok(phase);
        }

        // PUT: api/PhasesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putphase(int id, phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phase.ID)
            {
                return BadRequest();
            }

            db.Entry(phase).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!phaseExists(id))
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

        // POST: api/PhasesAPI
        [ResponseType(typeof(phase))]
        public IHttpActionResult Postphase(phase phase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.phases.Add(phase);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phase.ID }, phase);
        }

        // DELETE: api/PhasesAPI/5
        [ResponseType(typeof(phase))]
        public IHttpActionResult Deletephase(int id)
        {
            phase phase = db.phases.Find(id);
            if (phase == null)
            {
                return NotFound();
            }

            db.phases.Remove(phase);
            db.SaveChanges();

            return Ok(phase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool phaseExists(int id)
        {
            return db.phases.Count(e => e.ID == id) > 0;
        }
    }
}