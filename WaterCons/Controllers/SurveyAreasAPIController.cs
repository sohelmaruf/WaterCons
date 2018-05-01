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
    public class SurveyAreasAPIController : ApiController
    {
        private waterconsEntities db = new waterconsEntities();

        // GET: api/SurveyAreasAPI
        public IQueryable<surveyarea> Getsurveyareas()
        {
            return db.surveyareas;
        }

        // GET: api/SurveyAreasAPI/5
        [ResponseType(typeof(surveyarea))]
        public IHttpActionResult Getsurveyarea(int id)
        {
            surveyarea surveyarea = db.surveyareas.Find(id);
            if (surveyarea == null)
            {
                return NotFound();
            }

            return Ok(surveyarea);
        }

        // PUT: api/SurveyAreasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsurveyarea(int id, surveyarea surveyarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != surveyarea.ID)
            {
                return BadRequest();
            }

            db.Entry(surveyarea).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!surveyareaExists(id))
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

        // POST: api/SurveyAreasAPI
        [ResponseType(typeof(surveyarea))]
        public IHttpActionResult Postsurveyarea(surveyarea surveyarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.surveyareas.Add(surveyarea);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = surveyarea.ID }, surveyarea);
        }

        // DELETE: api/SurveyAreasAPI/5
        [ResponseType(typeof(surveyarea))]
        public IHttpActionResult Deletesurveyarea(int id)
        {
            surveyarea surveyarea = db.surveyareas.Find(id);
            if (surveyarea == null)
            {
                return NotFound();
            }

            db.surveyareas.Remove(surveyarea);
            db.SaveChanges();

            return Ok(surveyarea);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool surveyareaExists(int id)
        {
            return db.surveyareas.Count(e => e.ID == id) > 0;
        }
    }
}