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
    public class ProgramInterventionTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ProgramInterventionTypesAPI
        public IQueryable<programinterventiontype> Getprograminterventiontypes()
        {
            return db.programinterventiontypes;
        }

        // GET: api/ProgramInterventionTypesAPI/5
        [ResponseType(typeof(programinterventiontype))]
        public IHttpActionResult Getprograminterventiontype(int id)
        {
            programinterventiontype programinterventiontype = db.programinterventiontypes.Find(id);
            if (programinterventiontype == null)
            {
                return NotFound();
            }

            return Ok(programinterventiontype);
        }

        // PUT: api/ProgramInterventionTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprograminterventiontype(int id, programinterventiontype programinterventiontype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programinterventiontype.ID)
            {
                return BadRequest();
            }

            db.Entry(programinterventiontype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!programinterventiontypeExists(id))
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

        // POST: api/ProgramInterventionTypesAPI
        [ResponseType(typeof(programinterventiontype))]
        public IHttpActionResult Postprograminterventiontype(programinterventiontype programinterventiontype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.programinterventiontypes.Add(programinterventiontype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programinterventiontype.ID }, programinterventiontype);
        }

        // DELETE: api/ProgramInterventionTypesAPI/5
        [ResponseType(typeof(programinterventiontype))]
        public IHttpActionResult Deleteprograminterventiontype(int id)
        {
            programinterventiontype programinterventiontype = db.programinterventiontypes.Find(id);
            if (programinterventiontype == null)
            {
                return NotFound();
            }

            db.programinterventiontypes.Remove(programinterventiontype);
            db.SaveChanges();

            return Ok(programinterventiontype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool programinterventiontypeExists(int id)
        {
            return db.programinterventiontypes.Count(e => e.ID == id) > 0;
        }
    }
}