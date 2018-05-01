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
    public class ProgramsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ProgramsAPI
        public IQueryable<program> Getprograms()
        {
            return db.programs;
        }

        // GET: api/ProgramsAPI/5
        [ResponseType(typeof(program))]
        public IHttpActionResult Getprogram(int id)
        {
            program program = db.programs.Find(id);
            if (program == null)
            {
                return NotFound();
            }

            return Ok(program);
        }

        // PUT: api/ProgramsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprogram(int id, program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != program.ID)
            {
                return BadRequest();
            }

            db.Entry(program).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!programExists(id))
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

        // POST: api/ProgramsAPI
        [ResponseType(typeof(program))]
        public IHttpActionResult Postprogram(program program)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.programs.Add(program);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = program.ID }, program);
        }

        // DELETE: api/ProgramsAPI/5
        [ResponseType(typeof(program))]
        public IHttpActionResult Deleteprogram(int id)
        {
            program program = db.programs.Find(id);
            if (program == null)
            {
                return NotFound();
            }

            db.programs.Remove(program);
            db.SaveChanges();

            return Ok(program);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool programExists(int id)
        {
            return db.programs.Count(e => e.ID == id) > 0;
        }
    }
}