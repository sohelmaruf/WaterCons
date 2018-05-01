﻿using System;
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
    public class OrganizationsAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/OrganizationsAPI
        public IQueryable<organization> Getorganizations()
        {
            return db.organizations;
        }

        // GET: api/OrganizationsAPI/5
        [ResponseType(typeof(organization))]
        public IHttpActionResult Getorganization(int id)
        {
            organization organization = db.organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        // PUT: api/OrganizationsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putorganization(int id, organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != organization.ID)
            {
                return BadRequest();
            }

            db.Entry(organization).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!organizationExists(id))
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

        // POST: api/OrganizationsAPI
        [ResponseType(typeof(organization))]
        public IHttpActionResult Postorganization(organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.organizations.Add(organization);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = organization.ID }, organization);
        }

        // DELETE: api/OrganizationsAPI/5
        [ResponseType(typeof(organization))]
        public IHttpActionResult Deleteorganization(int id)
        {
            organization organization = db.organizations.Find(id);
            if (organization == null)
            {
                return NotFound();
            }

            db.organizations.Remove(organization);
            db.SaveChanges();

            return Ok(organization);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool organizationExists(int id)
        {
            return db.organizations.Count(e => e.ID == id) > 0;
        }
    }
}