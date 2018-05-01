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
    public class PeopleAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PeopleAPI
        public IQueryable<person> Getpeople()
        {
            return db.people;
        }

        // GET: api/PeopleAPI/5
        [ResponseType(typeof(person))]
        public IHttpActionResult Getperson(int id)
        {
            person person = db.people.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/PeopleAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putperson(int id, person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != person.ID)
            {
                return BadRequest();
            }

            db.Entry(person).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!personExists(id))
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

        // POST: api/PeopleAPI
        [ResponseType(typeof(person))]
        public IHttpActionResult Postperson(person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.people.Add(person);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = person.ID }, person);
        }

        // DELETE: api/PeopleAPI/5
        [ResponseType(typeof(person))]
        public IHttpActionResult Deleteperson(int id)
        {
            person person = db.people.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            db.people.Remove(person);
            db.SaveChanges();

            return Ok(person);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool personExists(int id)
        {
            return db.people.Count(e => e.ID == id) > 0;
        }
    }
}