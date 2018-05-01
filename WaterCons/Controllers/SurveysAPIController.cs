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
    public class SurveysAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/SurveysAPI
        public IQueryable<surveycas> Getsurveycases()
        {
            return db.surveycases;
        }

        // GET: api/SurveysAPI/5
        [ResponseType(typeof(surveycas))]
        public IHttpActionResult Getsurveycas(int id)
        {
            surveycas surveycas = db.surveycases.Find(id);
            if (surveycas == null)
            {
                return NotFound();
            }

            return Ok(surveycas);
        }

        // PUT: api/SurveysAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsurveycas(int id, surveycas surveycas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveycas.ID)
            {
                return BadRequest();
            }

            db.Entry(surveycas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!surveycasExists(id))
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

        // POST: api/SurveysAPI
        [ResponseType(typeof(surveycas))]
        public IHttpActionResult Postsurveycas(surveycas surveycas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.surveycases.Add(surveycas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = surveycas.ID }, surveycas);
        }

        // DELETE: api/SurveysAPI/5
        [ResponseType(typeof(surveycas))]
        public IHttpActionResult Deletesurveycas(int id)
        {
            surveycas surveycas = db.surveycases.Find(id);
            if (surveycas == null)
            {
                return NotFound();
            }

            db.surveycases.Remove(surveycas);
            db.SaveChanges();

            return Ok(surveycas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool surveycasExists(int id)
        {
            return db.surveycases.Count(e => e.ID == id) > 0;
        }
    }
}