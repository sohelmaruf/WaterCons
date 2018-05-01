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
    public class InterventionsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/InterventionsAPI
        public IQueryable<intervention> Getinterventions()
        {
            return db.interventions;
        }

        // GET: api/InterventionsAPI/5
        [ResponseType(typeof(intervention))]
        public IHttpActionResult Getintervention(int id)
        {
            intervention intervention = db.interventions.Find(id);
            if (intervention == null)
            {
                return NotFound();
            }

            return Ok(intervention);
        }

        // PUT: api/InterventionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putintervention(int id, intervention intervention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != intervention.ID)
            {
                return BadRequest();
            }

            db.Entry(intervention).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!interventionExists(id))
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

        // POST: api/InterventionsAPI
        [ResponseType(typeof(intervention))]
        public IHttpActionResult Postintervention(intervention intervention)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.interventions.Add(intervention);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = intervention.ID }, intervention);
        }

        // DELETE: api/InterventionsAPI/5
        [ResponseType(typeof(intervention))]
        public IHttpActionResult Deleteintervention(int id)
        {
            intervention intervention = db.interventions.Find(id);
            if (intervention == null)
            {
                return NotFound();
            }

            db.interventions.Remove(intervention);
            db.SaveChanges();

            return Ok(intervention);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool interventionExists(int id)
        {
            return db.interventions.Count(e => e.ID == id) > 0;
        }
    }
}