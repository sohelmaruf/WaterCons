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
    public class EducationalMaterialsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/EducationalMaterialsAPI
        public IQueryable<educationalmaterial> Geteducationalmaterials()
        {
            return db.educationalmaterials;
        }

        // GET: api/EducationalMaterialsAPI/5
        [ResponseType(typeof(educationalmaterial))]
        public IHttpActionResult Geteducationalmaterial(int id)
        {
            educationalmaterial educationalmaterial = db.educationalmaterials.Find(id);
            if (educationalmaterial == null)
            {
                return NotFound();
            }

            return Ok(educationalmaterial);
        }

        // PUT: api/EducationalMaterialsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puteducationalmaterial(int id, educationalmaterial educationalmaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationalmaterial.ID)
            {
                return BadRequest();
            }

            db.Entry(educationalmaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!educationalmaterialExists(id))
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

        // POST: api/EducationalMaterialsAPI
        [ResponseType(typeof(educationalmaterial))]
        public IHttpActionResult Posteducationalmaterial(educationalmaterial educationalmaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.educationalmaterials.Add(educationalmaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = educationalmaterial.ID }, educationalmaterial);
        }

        // DELETE: api/EducationalMaterialsAPI/5
        [ResponseType(typeof(educationalmaterial))]
        public IHttpActionResult Deleteeducationalmaterial(int id)
        {
            educationalmaterial educationalmaterial = db.educationalmaterials.Find(id);
            if (educationalmaterial == null)
            {
                return NotFound();
            }

            db.educationalmaterials.Remove(educationalmaterial);
            db.SaveChanges();

            return Ok(educationalmaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool educationalmaterialExists(int id)
        {
            return db.educationalmaterials.Count(e => e.ID == id) > 0;
        }
    }
}