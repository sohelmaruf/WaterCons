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
    public class DocumentUploadsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DocumentUploadsAPI
        public IQueryable<documentupload> Getdocumentuploads()
        {
            return db.documentuploads;
        }

        // GET: api/DocumentUploadsAPI/5
        [ResponseType(typeof(documentupload))]
        public IHttpActionResult Getdocumentupload(int id)
        {
            documentupload documentupload = db.documentuploads.Find(id);
            if (documentupload == null)
            {
                return NotFound();
            }

            return Ok(documentupload);
        }

        // PUT: api/DocumentUploadsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdocumentupload(int id, documentupload documentupload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentupload.ID)
            {
                return BadRequest();
            }

            db.Entry(documentupload).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!documentuploadExists(id))
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

        // POST: api/DocumentUploadsAPI
        [ResponseType(typeof(documentupload))]
        public IHttpActionResult Postdocumentupload(documentupload documentupload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.documentuploads.Add(documentupload);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentupload.ID }, documentupload);
        }

        // DELETE: api/DocumentUploadsAPI/5
        [ResponseType(typeof(documentupload))]
        public IHttpActionResult Deletedocumentupload(int id)
        {
            documentupload documentupload = db.documentuploads.Find(id);
            if (documentupload == null)
            {
                return NotFound();
            }

            db.documentuploads.Remove(documentupload);
            db.SaveChanges();

            return Ok(documentupload);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool documentuploadExists(int id)
        {
            return db.documentuploads.Count(e => e.ID == id) > 0;
        }
    }
}