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
    public class SavingsFactorsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/SavingsFactorsAPI
        public IQueryable<savingsfactor> Getsavingsfactors()
        {
            return db.savingsfactors;
        }

        // GET: api/SavingsFactorsAPI/5
        [ResponseType(typeof(savingsfactor))]
        public IHttpActionResult Getsavingsfactor(int id)
        {
            savingsfactor savingsfactor = db.savingsfactors.Find(id);
            if (savingsfactor == null)
            {
                return NotFound();
            }

            return Ok(savingsfactor);
        }

        // PUT: api/SavingsFactorsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsavingsfactor(int id, savingsfactor savingsfactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savingsfactor.ID)
            {
                return BadRequest();
            }

            db.Entry(savingsfactor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!savingsfactorExists(id))
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

        // POST: api/SavingsFactorsAPI
        [ResponseType(typeof(savingsfactor))]
        public IHttpActionResult Postsavingsfactor(savingsfactor savingsfactor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.savingsfactors.Add(savingsfactor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = savingsfactor.ID }, savingsfactor);
        }

        // DELETE: api/SavingsFactorsAPI/5
        [ResponseType(typeof(savingsfactor))]
        public IHttpActionResult Deletesavingsfactor(int id)
        {
            savingsfactor savingsfactor = db.savingsfactors.Find(id);
            if (savingsfactor == null)
            {
                return NotFound();
            }

            db.savingsfactors.Remove(savingsfactor);
            db.SaveChanges();

            return Ok(savingsfactor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool savingsfactorExists(int id)
        {
            return db.savingsfactors.Count(e => e.ID == id) > 0;
        }
    }
}