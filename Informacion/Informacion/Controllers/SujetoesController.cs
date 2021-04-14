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
using Informacion.Models;

namespace Informacion.Controllers
{
    public class SujetoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Sujetoes
        [Authorize]
        public IQueryable<Sujeto> GetSujetoes()
        {
            return db.Sujetoes;
        }

        // GET: api/Sujetoes/5
        [Authorize]
        [ResponseType(typeof(Sujeto))]
        public IHttpActionResult GetSujeto(int id)
        {
            Sujeto sujeto = db.Sujetoes.Find(id);
            if (sujeto == null)
            {
                return NotFound();
            }

            return Ok(sujeto);
        }

        // PUT: api/Sujetoes/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSujeto(int id, Sujeto sujeto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sujeto.PerosnId)
            {
                return BadRequest();
            }

            db.Entry(sujeto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SujetoExists(id))
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

        // POST: api/Sujetoes
        [Authorize]
        [ResponseType(typeof(Sujeto))]
        public IHttpActionResult PostSujeto(Sujeto sujeto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sujetoes.Add(sujeto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sujeto.PerosnId }, sujeto);
        }

        // DELETE: api/Sujetoes/5
        [Authorize]
        [ResponseType(typeof(Sujeto))]
        public IHttpActionResult DeleteSujeto(int id)
        {
            Sujeto sujeto = db.Sujetoes.Find(id);
            if (sujeto == null)
            {
                return NotFound();
            }

            db.Sujetoes.Remove(sujeto);
            db.SaveChanges();

            return Ok(sujeto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SujetoExists(int id)
        {
            return db.Sujetoes.Count(e => e.PerosnId == id) > 0;
        }
    }
}