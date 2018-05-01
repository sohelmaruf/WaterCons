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
    public class AdvertisementsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/AdvertisementsAPI
        public IQueryable<advertisementcas> Getadvertisementcases()
        {
            return db.advertisementcases;
        }

        // GET: api/AdvertisementsAPI/5
        [ResponseType(typeof(advertisementcas))]
        public IHttpActionResult Getadvertisementcas(int id)
        {
            advertisementcas advertisementcas = db.advertisementcases.Find(id);
            if (advertisementcas == null)
            {
                return NotFound();
            }

            return Ok(advertisementcas);
        }

        // PUT: api/AdvertisementsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putadvertisementcas(int id, advertisementcas advertisementcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != advertisementcas.ID)
            {
                return BadRequest();
            }

            db.Entry(advertisementcas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!advertisementcasExists(id))
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

        // POST: api/AdvertisementsAPI
        [ResponseType(typeof(advertisementcas))]
        public IHttpActionResult Postadvertisementcas(advertisementcas advertisementcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.advertisementcases.Add(advertisementcas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = advertisementcas.ID }, advertisementcas);
        }

        // DELETE: api/AdvertisementsAPI/5
        [ResponseType(typeof(advertisementcas))]
        public IHttpActionResult Deleteadvertisementcas(int id)
        {
            advertisementcas advertisementcas = db.advertisementcases.Find(id);
            if (advertisementcas == null)
            {
                return NotFound();
            }

            db.advertisementcases.Remove(advertisementcas);
            db.SaveChanges();

            return Ok(advertisementcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool advertisementcasExists(int id)
        {
            return db.advertisementcases.Count(e => e.ID == id) > 0;
        }
    }
}