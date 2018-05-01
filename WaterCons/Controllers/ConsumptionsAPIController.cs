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
    public class ConsumptionsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ConsumptionsAPI
        public IQueryable<consumption> Getconsumptions()
        {
            return db.consumptions;
        }

        // GET: api/ConsumptionsAPI/5
        [ResponseType(typeof(consumption))]
        public IHttpActionResult Getconsumption(int id)
        {
            consumption consumption = db.consumptions.Find(id);
            if (consumption == null)
            {
                return NotFound();
            }

            return Ok(consumption);
        }

        // PUT: api/ConsumptionsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putconsumption(int id, consumption consumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consumption.ID)
            {
                return BadRequest();
            }

            db.Entry(consumption).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!consumptionExists(id))
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

        // POST: api/ConsumptionsAPI
        [ResponseType(typeof(consumption))]
        public IHttpActionResult Postconsumption(consumption consumption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.consumptions.Add(consumption);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = consumption.ID }, consumption);
        }

        // DELETE: api/ConsumptionsAPI/5
        [ResponseType(typeof(consumption))]
        public IHttpActionResult Deleteconsumption(int id)
        {
            consumption consumption = db.consumptions.Find(id);
            if (consumption == null)
            {
                return NotFound();
            }

            db.consumptions.Remove(consumption);
            db.SaveChanges();

            return Ok(consumption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool consumptionExists(int id)
        {
            return db.consumptions.Count(e => e.ID == id) > 0;
        }
    }
}