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
    public class IrrigationalsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/IrrigationalsAPI
        public IQueryable<irrigationalcas> Getirrigationalcases()
        {
            return db.irrigationalcases;
        }

        // GET: api/IrrigationalsAPI/5
        [ResponseType(typeof(irrigationalcas))]
        public IHttpActionResult Getirrigationalcas(int id)
        {
            irrigationalcas irrigationalcas = db.irrigationalcases.Find(id);
            if (irrigationalcas == null)
            {
                return NotFound();
            }

            return Ok(irrigationalcas);
        }

        // PUT: api/IrrigationalsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putirrigationalcas(int id, irrigationalcas irrigationalcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != irrigationalcas.ID)
            {
                return BadRequest();
            }

            db.Entry(irrigationalcas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!irrigationalcasExists(id))
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

        // POST: api/IrrigationalsAPI
        [ResponseType(typeof(irrigationalcas))]
        public IHttpActionResult Postirrigationalcas(irrigationalcas irrigationalcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.irrigationalcases.Add(irrigationalcas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = irrigationalcas.ID }, irrigationalcas);
        }

        // DELETE: api/IrrigationalsAPI/5
        [ResponseType(typeof(irrigationalcas))]
        public IHttpActionResult Deleteirrigationalcas(int id)
        {
            irrigationalcas irrigationalcas = db.irrigationalcases.Find(id);
            if (irrigationalcas == null)
            {
                return NotFound();
            }

            db.irrigationalcases.Remove(irrigationalcas);
            db.SaveChanges();

            return Ok(irrigationalcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool irrigationalcasExists(int id)
        {
            return db.irrigationalcases.Count(e => e.ID == id) > 0;
        }
    }
}