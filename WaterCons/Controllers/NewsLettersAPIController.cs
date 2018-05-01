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
    public class NewsLettersAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/NewsLettersAPI
        public IQueryable<newsletter> Getnewsletters()
        {
            return db.newsletters;
        }

        // GET: api/NewsLettersAPI/5
        [ResponseType(typeof(newsletter))]
        public IHttpActionResult Getnewsletter(int id)
        {
            newsletter newsletter = db.newsletters.Find(id);
            if (newsletter == null)
            {
                return NotFound();
            }

            return Ok(newsletter);
        }

        // PUT: api/NewsLettersAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnewsletter(int id, newsletter newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsletter.ID)
            {
                return BadRequest();
            }

            db.Entry(newsletter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newsletterExists(id))
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

        // POST: api/NewsLettersAPI
        [ResponseType(typeof(newsletter))]
        public IHttpActionResult Postnewsletter(newsletter newsletter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.newsletters.Add(newsletter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newsletter.ID }, newsletter);
        }

        // DELETE: api/NewsLettersAPI/5
        [ResponseType(typeof(newsletter))]
        public IHttpActionResult Deletenewsletter(int id)
        {
            newsletter newsletter = db.newsletters.Find(id);
            if (newsletter == null)
            {
                return NotFound();
            }

            db.newsletters.Remove(newsletter);
            db.SaveChanges();

            return Ok(newsletter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool newsletterExists(int id)
        {
            return db.newsletters.Count(e => e.ID == id) > 0;
        }
    }
}