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
    public class DeviceModelsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DeviceModelsAPI
        public IQueryable<devicemodel> Getdevicemodels()
        {
            return db.devicemodels;
        }

        // GET: api/DeviceModelsAPI/5
        [ResponseType(typeof(devicemodel))]
        public IHttpActionResult Getdevicemodel(int id)
        {
            devicemodel devicemodel = db.devicemodels.Find(id);
            if (devicemodel == null)
            {
                return NotFound();
            }

            return Ok(devicemodel);
        }

        // PUT: api/DeviceModelsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdevicemodel(int id, devicemodel devicemodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != devicemodel.ID)
            {
                return BadRequest();
            }

            db.Entry(devicemodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!devicemodelExists(id))
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

        // POST: api/DeviceModelsAPI
        [ResponseType(typeof(devicemodel))]
        public IHttpActionResult Postdevicemodel(devicemodel devicemodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.devicemodels.Add(devicemodel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = devicemodel.ID }, devicemodel);
        }

        // DELETE: api/DeviceModelsAPI/5
        [ResponseType(typeof(devicemodel))]
        public IHttpActionResult Deletedevicemodel(int id)
        {
            devicemodel devicemodel = db.devicemodels.Find(id);
            if (devicemodel == null)
            {
                return NotFound();
            }

            db.devicemodels.Remove(devicemodel);
            db.SaveChanges();

            return Ok(devicemodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool devicemodelExists(int id)
        {
            return db.devicemodels.Count(e => e.ID == id) > 0;
        }
    }
}