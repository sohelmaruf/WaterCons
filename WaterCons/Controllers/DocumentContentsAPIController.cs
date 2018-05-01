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
    public class DocumentContentsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/DocumentContentsAPI
        public IQueryable<documentcontent> Getdocumentcontents()
        {
            return db.documentcontents;
        }

        // GET: api/DocumentContentsAPI/5
        [ResponseType(typeof(documentcontent))]
        public IHttpActionResult Getdocumentcontent(int id)
        {
            documentcontent documentcontent = db.documentcontents.Find(id);
            if (documentcontent == null)
            {
                return NotFound();
            }

            return Ok(documentcontent);
        }

        // PUT: api/DocumentContentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdocumentcontent(int id, documentcontent documentcontent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documentcontent.ID)
            {
                return BadRequest();
            }

            db.Entry(documentcontent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!documentcontentExists(id))
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

        // POST: api/DocumentContentsAPI
        [ResponseType(typeof(documentcontent))]
        public IHttpActionResult Postdocumentcontent(documentcontent documentcontent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.documentcontents.Add(documentcontent);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documentcontent.ID }, documentcontent);
        }

        // DELETE: api/DocumentContentsAPI/5
        [ResponseType(typeof(documentcontent))]
        public IHttpActionResult Deletedocumentcontent(int id)
        {
            documentcontent documentcontent = db.documentcontents.Find(id);
            if (documentcontent == null)
            {
                return NotFound();
            }

            db.documentcontents.Remove(documentcontent);
            db.SaveChanges();

            return Ok(documentcontent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool documentcontentExists(int id)
        {
            return db.documentcontents.Count(e => e.ID == id) > 0;
        }
    }
}