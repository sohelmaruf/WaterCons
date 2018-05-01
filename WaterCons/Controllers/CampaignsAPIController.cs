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
    public class CampaignsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/CampaignsAPI
        public IQueryable<campaigncas> Getcampaigncases()
        {
            return db.campaigncases;
        }

        // GET: api/CampaignsAPI/5
        [ResponseType(typeof(campaigncas))]
        public IHttpActionResult Getcampaigncas(int id)
        {
            campaigncas campaigncas = db.campaigncases.Find(id);
            if (campaigncas == null)
            {
                return NotFound();
            }

            return Ok(campaigncas);
        }

        // PUT: api/CampaignsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcampaigncas(int id, campaigncas campaigncas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaigncas.ID)
            {
                return BadRequest();
            }

            db.Entry(campaigncas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!campaigncasExists(id))
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

        // POST: api/CampaignsAPI
        [ResponseType(typeof(campaigncas))]
        public IHttpActionResult Postcampaigncas(campaigncas campaigncas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.campaigncases.Add(campaigncas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campaigncas.ID }, campaigncas);
        }

        // DELETE: api/CampaignsAPI/5
        [ResponseType(typeof(campaigncas))]
        public IHttpActionResult Deletecampaigncas(int id)
        {
            campaigncas campaigncas = db.campaigncases.Find(id);
            if (campaigncas == null)
            {
                return NotFound();
            }

            db.campaigncases.Remove(campaigncas);
            db.SaveChanges();

            return Ok(campaigncas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool campaigncasExists(int id)
        {
            return db.campaigncases.Count(e => e.ID == id) > 0;
        }
    }
}