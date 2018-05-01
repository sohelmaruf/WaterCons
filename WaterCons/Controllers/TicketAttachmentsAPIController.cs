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
    public class TicketAttachmentsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/TicketAttachmentsAPI
        public IQueryable<ticketattachment> Getticketattachments()
        {
            return db.ticketattachments;
        }

        // GET: api/TicketAttachmentsAPI/5
        [ResponseType(typeof(ticketattachment))]
        public IHttpActionResult Getticketattachment(int id)
        {
            ticketattachment ticketattachment = db.ticketattachments.Find(id);
            if (ticketattachment == null)
            {
                return NotFound();
            }

            return Ok(ticketattachment);
        }

        // PUT: api/TicketAttachmentsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putticketattachment(int id, ticketattachment ticketattachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticketattachment.ID)
            {
                return BadRequest();
            }

            db.Entry(ticketattachment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ticketattachmentExists(id))
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

        // POST: api/TicketAttachmentsAPI
        [ResponseType(typeof(ticketattachment))]
        public IHttpActionResult Postticketattachment(ticketattachment ticketattachment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ticketattachments.Add(ticketattachment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ticketattachment.ID }, ticketattachment);
        }

        // DELETE: api/TicketAttachmentsAPI/5
        [ResponseType(typeof(ticketattachment))]
        public IHttpActionResult Deleteticketattachment(int id)
        {
            ticketattachment ticketattachment = db.ticketattachments.Find(id);
            if (ticketattachment == null)
            {
                return NotFound();
            }

            db.ticketattachments.Remove(ticketattachment);
            db.SaveChanges();

            return Ok(ticketattachment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ticketattachmentExists(int id)
        {
            return db.ticketattachments.Count(e => e.ID == id) > 0;
        }
    }
}