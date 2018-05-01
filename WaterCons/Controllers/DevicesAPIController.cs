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
    public class DevicesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DevicesAPI
        public IQueryable<device> Getdevices()
        {
            return db.devices;
        }

        // GET: api/DevicesAPI/5
        [ResponseType(typeof(device))]
        public IHttpActionResult Getdevice(int id)
        {
            device device = db.devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        // PUT: api/DevicesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdevice(int id, device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != device.ID)
            {
                return BadRequest();
            }

            db.Entry(device).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!deviceExists(id))
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

        // POST: api/DevicesAPI
        [ResponseType(typeof(device))]
        public IHttpActionResult Postdevice(device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.devices.Add(device);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = device.ID }, device);
        }

        // DELETE: api/DevicesAPI/5
        [ResponseType(typeof(device))]
        public IHttpActionResult Deletedevice(int id)
        {
            device device = db.devices.Find(id);
            if (device == null)
            {
                return NotFound();
            }

            db.devices.Remove(device);
            db.SaveChanges();

            return Ok(device);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool deviceExists(int id)
        {
            return db.devices.Count(e => e.ID == id) > 0;
        }
    }
}