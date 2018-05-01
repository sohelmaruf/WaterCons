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
using WaterCons.Helpers;
using WaterCons.Filters;
using System.Web.Security;

namespace WaterCons.Controllers
{

  [RoutePrefix("api/accounts")]
  public class AccountsAPIController : ApiController
    {
       private waterconsEntities db = new waterconsEntities();
    
    // GET: api/AccountsAPI
    public IQueryable<account> Getaccounts()
        {
            return db.accounts;
        }

        // GET: api/AccountsAPI/5
        [ResponseType(typeof(account))]
        public IHttpActionResult Getaccount(int id)
        {
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/AccountsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaccount(int id, account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.ID)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountExists(id))
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

        // POST: api/AccountsAPI
        [ResponseType(typeof(account))]
        public IHttpActionResult Postaccount(account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.accounts.Add(account);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = account.ID }, account);
        }

        // DELETE: api/AccountsAPI/5
        [ResponseType(typeof(account))]
        public IHttpActionResult Deleteaccount(int id)
        {
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            db.accounts.Remove(account);
            db.SaveChanges();

            return Ok(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accountExists(int id)
        {
            return db.accounts.Count(e => e.ID == id) > 0;
        }
    }
}