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
    public class NewsLetterContactsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/NewsLetterContactsAPI
        public IQueryable<newslettercontact> Getnewslettercontacts()
        {
            return db.newslettercontacts;
        }

        // GET: api/NewsLetterContactsAPI/5
        [ResponseType(typeof(newslettercontact))]
        public IHttpActionResult Getnewslettercontact(int id)
        {
            newslettercontact newslettercontact = db.newslettercontacts.Find(id);
            if (newslettercontact == null)
            {
                return NotFound();
            }

            return Ok(newslettercontact);
        }

        // PUT: api/NewsLetterContactsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnewslettercontact(int id, newslettercontact newslettercontact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newslettercontact.ID)
            {
                return BadRequest();
            }

            db.Entry(newslettercontact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!newslettercontactExists(id))
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

        // POST: api/NewsLetterContactsAPI
        [ResponseType(typeof(newslettercontact))]
        public IHttpActionResult Postnewslettercontact(newslettercontact newslettercontact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.newslettercontacts.Add(newslettercontact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newslettercontact.ID }, newslettercontact);
        }

        // DELETE: api/NewsLetterContactsAPI/5
        [ResponseType(typeof(newslettercontact))]
        public IHttpActionResult Deletenewslettercontact(int id)
        {
            newslettercontact newslettercontact = db.newslettercontacts.Find(id);
            if (newslettercontact == null)
            {
                return NotFound();
            }

            db.newslettercontacts.Remove(newslettercontact);
            db.SaveChanges();

            return Ok(newslettercontact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool newslettercontactExists(int id)
        {
            return db.newslettercontacts.Count(e => e.ID == id) > 0;
        }
    }
}