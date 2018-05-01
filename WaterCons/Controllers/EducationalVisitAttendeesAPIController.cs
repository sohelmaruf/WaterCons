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
    public class EducationalVisitAttendeesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/EducationalVisitAttendeesAPI
        public IQueryable<educationalvisitattendee> Geteducationalvisitattendees()
        {
            return db.educationalvisitattendees;
        }

        // GET: api/EducationalVisitAttendeesAPI/5
        [ResponseType(typeof(educationalvisitattendee))]
        public IHttpActionResult Geteducationalvisitattendee(int id)
        {
            educationalvisitattendee educationalvisitattendee = db.educationalvisitattendees.Find(id);
            if (educationalvisitattendee == null)
            {
                return NotFound();
            }

            return Ok(educationalvisitattendee);
        }

        // PUT: api/EducationalVisitAttendeesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puteducationalvisitattendee(int id, educationalvisitattendee educationalvisitattendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationalvisitattendee.ID)
            {
                return BadRequest();
            }

            db.Entry(educationalvisitattendee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!educationalvisitattendeeExists(id))
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

        // POST: api/EducationalVisitAttendeesAPI
        [ResponseType(typeof(educationalvisitattendee))]
        public IHttpActionResult Posteducationalvisitattendee(educationalvisitattendee educationalvisitattendee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.educationalvisitattendees.Add(educationalvisitattendee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = educationalvisitattendee.ID }, educationalvisitattendee);
        }

        // DELETE: api/EducationalVisitAttendeesAPI/5
        [ResponseType(typeof(educationalvisitattendee))]
        public IHttpActionResult Deleteeducationalvisitattendee(int id)
        {
            educationalvisitattendee educationalvisitattendee = db.educationalvisitattendees.Find(id);
            if (educationalvisitattendee == null)
            {
                return NotFound();
            }

            db.educationalvisitattendees.Remove(educationalvisitattendee);
            db.SaveChanges();

            return Ok(educationalvisitattendee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool educationalvisitattendeeExists(int id)
        {
            return db.educationalvisitattendees.Count(e => e.ID == id) > 0;
        }
    }
}