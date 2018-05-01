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
    public class GridFieldsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/GridFieldsAPI
        public IQueryable<gridfield> Getgridfields()
        {
            return db.gridfields;
        }

        // GET: api/GridFieldsAPI/5
        [ResponseType(typeof(gridfield))]
        public IHttpActionResult Getgridfield(int id)
        {
            gridfield gridfield = db.gridfields.Find(id);
            if (gridfield == null)
            {
                return NotFound();
            }

            return Ok(gridfield);
        }

        // PUT: api/GridFieldsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgridfield(int id, gridfield gridfield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gridfield.ID)
            {
                return BadRequest();
            }

            db.Entry(gridfield).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gridfieldExists(id))
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

        // POST: api/GridFieldsAPI
        [ResponseType(typeof(gridfield))]
        public IHttpActionResult Postgridfield(gridfield gridfield)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gridfields.Add(gridfield);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gridfield.ID }, gridfield);
        }

        // DELETE: api/GridFieldsAPI/5
        [ResponseType(typeof(gridfield))]
        public IHttpActionResult Deletegridfield(int id)
        {
            gridfield gridfield = db.gridfields.Find(id);
            if (gridfield == null)
            {
                return NotFound();
            }

            db.gridfields.Remove(gridfield);
            db.SaveChanges();

            return Ok(gridfield);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gridfieldExists(int id)
        {
            return db.gridfields.Count(e => e.ID == id) > 0;
        }
    }
}