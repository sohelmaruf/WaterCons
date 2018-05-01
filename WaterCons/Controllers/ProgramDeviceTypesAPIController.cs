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
    public class ProgramDeviceTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ProgramDeviceTypesAPI
        public IQueryable<programdevicetype> Getprogramdevicetypes()
        {
            return db.programdevicetypes;
        }

        // GET: api/ProgramDeviceTypesAPI/5
        [ResponseType(typeof(programdevicetype))]
        public IHttpActionResult Getprogramdevicetype(int id)
        {
            programdevicetype programdevicetype = db.programdevicetypes.Find(id);
            if (programdevicetype == null)
            {
                return NotFound();
            }

            return Ok(programdevicetype);
        }

        // PUT: api/ProgramDeviceTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprogramdevicetype(int id, programdevicetype programdevicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programdevicetype.ID)
            {
                return BadRequest();
            }

            db.Entry(programdevicetype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!programdevicetypeExists(id))
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

        // POST: api/ProgramDeviceTypesAPI
        [ResponseType(typeof(programdevicetype))]
        public IHttpActionResult Postprogramdevicetype(programdevicetype programdevicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.programdevicetypes.Add(programdevicetype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programdevicetype.ID }, programdevicetype);
        }

        // DELETE: api/ProgramDeviceTypesAPI/5
        [ResponseType(typeof(programdevicetype))]
        public IHttpActionResult Deleteprogramdevicetype(int id)
        {
            programdevicetype programdevicetype = db.programdevicetypes.Find(id);
            if (programdevicetype == null)
            {
                return NotFound();
            }

            db.programdevicetypes.Remove(programdevicetype);
            db.SaveChanges();

            return Ok(programdevicetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool programdevicetypeExists(int id)
        {
            return db.programdevicetypes.Count(e => e.ID == id) > 0;
        }
    }
}