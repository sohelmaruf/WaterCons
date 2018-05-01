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
    public class PeopleTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PeopleTypesAPI
        public IQueryable<peopletype> Getpeopletypes()
        {
            return db.peopletypes;
        }

        // GET: api/PeopleTypesAPI/5
        [ResponseType(typeof(peopletype))]
        public IHttpActionResult Getpeopletype(int id)
        {
            peopletype peopletype = db.peopletypes.Find(id);
            if (peopletype == null)
            {
                return NotFound();
            }

            return Ok(peopletype);
        }

        // PUT: api/PeopleTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpeopletype(int id, peopletype peopletype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != peopletype.ID)
            {
                return BadRequest();
            }

            db.Entry(peopletype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!peopletypeExists(id))
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

        // POST: api/PeopleTypesAPI
        [ResponseType(typeof(peopletype))]
        public IHttpActionResult Postpeopletype(peopletype peopletype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.peopletypes.Add(peopletype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = peopletype.ID }, peopletype);
        }

        // DELETE: api/PeopleTypesAPI/5
        [ResponseType(typeof(peopletype))]
        public IHttpActionResult Deletepeopletype(int id)
        {
            peopletype peopletype = db.peopletypes.Find(id);
            if (peopletype == null)
            {
                return NotFound();
            }

            db.peopletypes.Remove(peopletype);
            db.SaveChanges();

            return Ok(peopletype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool peopletypeExists(int id)
        {
            return db.peopletypes.Count(e => e.ID == id) > 0;
        }
    }
}