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
    public class DeviceTypesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DeviceTypesAPI
        public IQueryable<devicetype> Getdevicetypes()
        {
            return db.devicetypes;
        }

        // GET: api/DeviceTypesAPI/5
        [ResponseType(typeof(devicetype))]
        public IHttpActionResult Getdevicetype(int id)
        {
            devicetype devicetype = db.devicetypes.Find(id);
            if (devicetype == null)
            {
                return NotFound();
            }

            return Ok(devicetype);
        }

        // PUT: api/DeviceTypesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdevicetype(int id, devicetype devicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devicetype.ID)
            {
                return BadRequest();
            }

            db.Entry(devicetype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!devicetypeExists(id))
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

        // POST: api/DeviceTypesAPI
        [ResponseType(typeof(devicetype))]
        public IHttpActionResult Postdevicetype(devicetype devicetype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.devicetypes.Add(devicetype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = devicetype.ID }, devicetype);
        }

        // DELETE: api/DeviceTypesAPI/5
        [ResponseType(typeof(devicetype))]
        public IHttpActionResult Deletedevicetype(int id)
        {
            devicetype devicetype = db.devicetypes.Find(id);
            if (devicetype == null)
            {
                return NotFound();
            }

            db.devicetypes.Remove(devicetype);
            db.SaveChanges();

            return Ok(devicetype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool devicetypeExists(int id)
        {
            return db.devicetypes.Count(e => e.ID == id) > 0;
        }
    }
}