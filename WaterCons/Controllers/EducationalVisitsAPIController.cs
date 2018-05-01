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
    public class EducationalVisitsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/EducationalVisitsAPI
        public IQueryable<educationalvisitcas> Geteducationalvisitcases()
        {
            return db.educationalvisitcases;
        }

        // GET: api/EducationalVisitsAPI/5
        [ResponseType(typeof(educationalvisitcas))]
        public IHttpActionResult Geteducationalvisitcas(int id)
        {
            educationalvisitcas educationalvisitcas = db.educationalvisitcases.Find(id);
            if (educationalvisitcas == null)
            {
                return NotFound();
            }

            return Ok(educationalvisitcas);
        }

        // PUT: api/EducationalVisitsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puteducationalvisitcas(int id, educationalvisitcas educationalvisitcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != educationalvisitcas.ID)
            {
                return BadRequest();
            }

            db.Entry(educationalvisitcas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!educationalvisitcasExists(id))
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

        // POST: api/EducationalVisitsAPI
        [ResponseType(typeof(educationalvisitcas))]
        public IHttpActionResult Posteducationalvisitcas(educationalvisitcas educationalvisitcas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.educationalvisitcases.Add(educationalvisitcas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = educationalvisitcas.ID }, educationalvisitcas);
        }

        // DELETE: api/EducationalVisitsAPI/5
        [ResponseType(typeof(educationalvisitcas))]
        public IHttpActionResult Deleteeducationalvisitcas(int id)
        {
            educationalvisitcas educationalvisitcas = db.educationalvisitcases.Find(id);
            if (educationalvisitcas == null)
            {
                return NotFound();
            }

            db.educationalvisitcases.Remove(educationalvisitcas);
            db.SaveChanges();

            return Ok(educationalvisitcas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool educationalvisitcasExists(int id)
        {
            return db.educationalvisitcases.Count(e => e.ID == id) > 0;
        }
    }
}