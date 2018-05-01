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
    public class PeoplePeopleTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/PeoplePeopleTypesAPI
        public IQueryable<peoplepeopletype> Getpeoplepeopletypes()
        {
            return db.peoplepeopletypes;
        }

        // GET: api/PeoplePeopleTypesAPI/5
        [ResponseType(typeof(peoplepeopletype))]
        public IHttpActionResult Getpeoplepeopletype(int id)
        {
            peoplepeopletype peoplepeopletype = db.peoplepeopletypes.Find(id);
            if (peoplepeopletype == null)
            {
                return NotFound();
            }

            return Ok(peoplepeopletype);
        }

        // PUT: api/PeoplePeopleTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpeoplepeopletype(int id, peoplepeopletype peoplepeopletype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != peoplepeopletype.ID)
            {
                return BadRequest();
            }

            db.Entry(peoplepeopletype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!peoplepeopletypeExists(id))
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

        // POST: api/PeoplePeopleTypesAPI
        [ResponseType(typeof(peoplepeopletype))]
        public IHttpActionResult Postpeoplepeopletype(peoplepeopletype peoplepeopletype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.peoplepeopletypes.Add(peoplepeopletype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = peoplepeopletype.ID }, peoplepeopletype);
        }

        // DELETE: api/PeoplePeopleTypesAPI/5
        [ResponseType(typeof(peoplepeopletype))]
        public IHttpActionResult Deletepeoplepeopletype(int id)
        {
            peoplepeopletype peoplepeopletype = db.peoplepeopletypes.Find(id);
            if (peoplepeopletype == null)
            {
                return NotFound();
            }

            db.peoplepeopletypes.Remove(peoplepeopletype);
            db.SaveChanges();

            return Ok(peoplepeopletype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool peoplepeopletypeExists(int id)
        {
            return db.peoplepeopletypes.Count(e => e.ID == id) > 0;
        }
    }
}