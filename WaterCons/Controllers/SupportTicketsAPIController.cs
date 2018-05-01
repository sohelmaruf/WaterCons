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
    public class SupportTicketsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/SupportTicketsAPI
        public IQueryable<supportticket> Getsupporttickets()
        {
            return db.supporttickets;
        }

        // GET: api/SupportTicketsAPI/5
        [ResponseType(typeof(supportticket))]
        public IHttpActionResult Getsupportticket(int id)
        {
            supportticket supportticket = db.supporttickets.Find(id);
            if (supportticket == null)
            {
                return NotFound();
            }

            return Ok(supportticket);
        }

        // PUT: api/SupportTicketsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsupportticket(int id, supportticket supportticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != supportticket.ID)
            {
                return BadRequest();
            }

            db.Entry(supportticket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!supportticketExists(id))
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

        // POST: api/SupportTicketsAPI
        [ResponseType(typeof(supportticket))]
        public IHttpActionResult Postsupportticket(supportticket supportticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.supporttickets.Add(supportticket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = supportticket.ID }, supportticket);
        }

        // DELETE: api/SupportTicketsAPI/5
        [ResponseType(typeof(supportticket))]
        public IHttpActionResult Deletesupportticket(int id)
        {
            supportticket supportticket = db.supporttickets.Find(id);
            if (supportticket == null)
            {
                return NotFound();
            }

            db.supporttickets.Remove(supportticket);
            db.SaveChanges();

            return Ok(supportticket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool supportticketExists(int id)
        {
            return db.supporttickets.Count(e => e.ID == id) > 0;
        }
    }
}