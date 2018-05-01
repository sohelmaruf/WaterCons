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
    public class CitiesAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/CitiesAPI
        public IQueryable<city> Getcities()
        {
            return db.cities;
        }

        // GET: api/CitiesAPI/5
        [ResponseType(typeof(city))]
        public IHttpActionResult Getcity(int id)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/CitiesAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcity(int id, city city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.ID)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cityExists(id))
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

        // POST: api/CitiesAPI
        [ResponseType(typeof(city))]
        public IHttpActionResult Postcity(city city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cities.Add(city);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = city.ID }, city);
        }

        // DELETE: api/CitiesAPI/5
        [ResponseType(typeof(city))]
        public IHttpActionResult Deletecity(int id)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.cities.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cityExists(int id)
        {
            return db.cities.Count(e => e.ID == id) > 0;
        }
    }
}