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
    public class ProgramStepsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ProgramStepsAPI
        public IQueryable<programstep> Getprogramsteps()
        {
            return db.programsteps;
        }

        // GET: api/ProgramStepsAPI/5
        [ResponseType(typeof(programstep))]
        public IHttpActionResult Getprogramstep(int id)
        {
            programstep programstep = db.programsteps.Find(id);
            if (programstep == null)
            {
                return NotFound();
            }

            return Ok(programstep);
        }

        // PUT: api/ProgramStepsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprogramstep(int id, programstep programstep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programstep.ID)
            {
                return BadRequest();
            }

            db.Entry(programstep).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!programstepExists(id))
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

        // POST: api/ProgramStepsAPI
        [ResponseType(typeof(programstep))]
        public IHttpActionResult Postprogramstep(programstep programstep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.programsteps.Add(programstep);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programstep.ID }, programstep);
        }

        // DELETE: api/ProgramStepsAPI/5
        [ResponseType(typeof(programstep))]
        public IHttpActionResult Deleteprogramstep(int id)
        {
            programstep programstep = db.programsteps.Find(id);
            if (programstep == null)
            {
                return NotFound();
            }

            db.programsteps.Remove(programstep);
            db.SaveChanges();

            return Ok(programstep);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool programstepExists(int id)
        {
            return db.programsteps.Count(e => e.ID == id) > 0;
        }
    }
}