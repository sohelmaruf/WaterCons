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
    public class ProgramDeviceModelsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/ProgramDeviceModelsAPI
        public IQueryable<programdevicemodel> Getprogramdevicemodels()
        {
            return db.programdevicemodels;
        }

        // GET: api/ProgramDeviceModelsAPI/5
        [ResponseType(typeof(programdevicemodel))]
        public IHttpActionResult Getprogramdevicemodel(int id)
        {
            programdevicemodel programdevicemodel = db.programdevicemodels.Find(id);
            if (programdevicemodel == null)
            {
                return NotFound();
            }

            return Ok(programdevicemodel);
        }

        // PUT: api/ProgramDeviceModelsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putprogramdevicemodel(int id, programdevicemodel programdevicemodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programdevicemodel.ID)
            {
                return BadRequest();
            }

            db.Entry(programdevicemodel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!programdevicemodelExists(id))
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

        // POST: api/ProgramDeviceModelsAPI
        [ResponseType(typeof(programdevicemodel))]
        public IHttpActionResult Postprogramdevicemodel(programdevicemodel programdevicemodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.programdevicemodels.Add(programdevicemodel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programdevicemodel.ID }, programdevicemodel);
        }

        // DELETE: api/ProgramDeviceModelsAPI/5
        [ResponseType(typeof(programdevicemodel))]
        public IHttpActionResult Deleteprogramdevicemodel(int id)
        {
            programdevicemodel programdevicemodel = db.programdevicemodels.Find(id);
            if (programdevicemodel == null)
            {
                return NotFound();
            }

            db.programdevicemodels.Remove(programdevicemodel);
            db.SaveChanges();

            return Ok(programdevicemodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool programdevicemodelExists(int id)
        {
            return db.programdevicemodels.Count(e => e.ID == id) > 0;
        }
    }
}