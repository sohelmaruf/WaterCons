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
    public class DeviceEfficiencyLevelsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DeviceEfficiencyLevelsAPI
        public IQueryable<deviceefficiencylevel> Getdeviceefficiencylevels()
        {
            return db.deviceefficiencylevels;
        }

        // GET: api/DeviceEfficiencyLevelsAPI/5
        [ResponseType(typeof(deviceefficiencylevel))]
        public IHttpActionResult Getdeviceefficiencylevel(int id)
        {
            deviceefficiencylevel deviceefficiencylevel = db.deviceefficiencylevels.Find(id);
            if (deviceefficiencylevel == null)
            {
                return NotFound();
            }

            return Ok(deviceefficiencylevel);
        }

        // PUT: api/DeviceEfficiencyLevelsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdeviceefficiencylevel(int id, deviceefficiencylevel deviceefficiencylevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deviceefficiencylevel.ID)
            {
                return BadRequest();
            }

            db.Entry(deviceefficiencylevel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!deviceefficiencylevelExists(id))
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

        // POST: api/DeviceEfficiencyLevelsAPI
        [ResponseType(typeof(deviceefficiencylevel))]
        public IHttpActionResult Postdeviceefficiencylevel(deviceefficiencylevel deviceefficiencylevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.deviceefficiencylevels.Add(deviceefficiencylevel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = deviceefficiencylevel.ID }, deviceefficiencylevel);
        }

        // DELETE: api/DeviceEfficiencyLevelsAPI/5
        [ResponseType(typeof(deviceefficiencylevel))]
        public IHttpActionResult Deletedeviceefficiencylevel(int id)
        {
            deviceefficiencylevel deviceefficiencylevel = db.deviceefficiencylevels.Find(id);
            if (deviceefficiencylevel == null)
            {
                return NotFound();
            }

            db.deviceefficiencylevels.Remove(deviceefficiencylevel);
            db.SaveChanges();

            return Ok(deviceefficiencylevel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool deviceefficiencylevelExists(int id)
        {
            return db.deviceefficiencylevels.Count(e => e.ID == id) > 0;
        }
    }
}