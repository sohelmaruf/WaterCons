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
    public class CampaignMaterialsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/CampaignmaterialsAPI
        public IQueryable<campaignmaterial> Getcampaignmaterials()
        {
            return db.campaignmaterials;
        }

        // GET: api/CampaignmaterialsAPI/5
        [ResponseType(typeof(campaignmaterial))]
        public IHttpActionResult Getcampaignmaterial(int id)
        {
            campaignmaterial campaignmaterial = db.campaignmaterials.Find(id);
            if (campaignmaterial == null)
            {
                return NotFound();
            }

            return Ok(campaignmaterial);
        }

        // PUT: api/CampaignmaterialsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcampaignmaterial(int id, campaignmaterial campaignmaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaignmaterial.ID)
            {
                return BadRequest();
            }

            db.Entry(campaignmaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!campaignmaterialExists(id))
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

        // POST: api/CampaignmaterialsAPI
        [ResponseType(typeof(campaignmaterial))]
        public IHttpActionResult Postcampaignmaterial(campaignmaterial campaignmaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.campaignmaterials.Add(campaignmaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campaignmaterial.ID }, campaignmaterial);
        }

        // DELETE: api/CampaignmaterialsAPI/5
        [ResponseType(typeof(campaignmaterial))]
        public IHttpActionResult Deletecampaignmaterial(int id)
        {
            campaignmaterial campaignmaterial = db.campaignmaterials.Find(id);
            if (campaignmaterial == null)
            {
                return NotFound();
            }

            db.campaignmaterials.Remove(campaignmaterial);
            db.SaveChanges();

            return Ok(campaignmaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool campaignmaterialExists(int id)
        {
            return db.campaignmaterials.Count(e => e.ID == id) > 0;
        }
    }
}