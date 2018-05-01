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
    public class GeneralSettingsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/GeneralSettingsAPI
        public IQueryable<generalsetting> Getgeneralsettings()
        {
            return db.generalsettings;
        }

        // GET: api/GeneralSettingsAPI/5
        [ResponseType(typeof(generalsetting))]
        public IHttpActionResult Getgeneralsetting(int id)
        {
            generalsetting generalsetting = db.generalsettings.Find(id);
            if (generalsetting == null)
            {
                return NotFound();
            }

            return Ok(generalsetting);
        }

        // PUT: api/GeneralSettingsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putgeneralsetting(int id, generalsetting generalsetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != generalsetting.ID)
            {
                return BadRequest();
            }

            db.Entry(generalsetting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!generalsettingExists(id))
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

        // POST: api/GeneralSettingsAPI
        [ResponseType(typeof(generalsetting))]
        public IHttpActionResult Postgeneralsetting(generalsetting generalsetting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.generalsettings.Add(generalsetting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = generalsetting.ID }, generalsetting);
        }

        // DELETE: api/GeneralSettingsAPI/5
        [ResponseType(typeof(generalsetting))]
        public IHttpActionResult Deletegeneralsetting(int id)
        {
            generalsetting generalsetting = db.generalsettings.Find(id);
            if (generalsetting == null)
            {
                return NotFound();
            }

            db.generalsettings.Remove(generalsetting);
            db.SaveChanges();

            return Ok(generalsetting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool generalsettingExists(int id)
        {
            return db.generalsettings.Count(e => e.ID == id) > 0;
        }
    }
}