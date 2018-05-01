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
    public class CasecontactsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/CasecontactsAPI
        public IQueryable<casecontact> Getcasecontacts()
        {
            return db.casecontacts;
        }

        // GET: api/CasecontactsAPI/5
        [ResponseType(typeof(casecontact))]
        public IHttpActionResult Getcasecontact(int id)
        {
            casecontact casecontact = db.casecontacts.Find(id);
            if (casecontact == null)
            {
                return NotFound();
            }

            return Ok(casecontact);
        }

        // PUT: api/CasecontactsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcasecontact(int id, casecontact casecontact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != casecontact.ID)
            {
                return BadRequest();
            }

            db.Entry(casecontact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!casecontactExists(id))
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

        // POST: api/CasecontactsAPI
        [ResponseType(typeof(casecontact))]
        public IHttpActionResult Postcasecontact(casecontact casecontact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.casecontacts.Add(casecontact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = casecontact.ID }, casecontact);
        }

        // DELETE: api/CasecontactsAPI/5
        [ResponseType(typeof(casecontact))]
        public IHttpActionResult Deletecasecontact(int id)
        {
            casecontact casecontact = db.casecontacts.Find(id);
            if (casecontact == null)
            {
                return NotFound();
            }

            db.casecontacts.Remove(casecontact);
            db.SaveChanges();

            return Ok(casecontact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool casecontactExists(int id)
        {
            return db.casecontacts.Count(e => e.ID == id) > 0;
        }
    }
}