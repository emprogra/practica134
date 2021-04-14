using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebInfor.Models;

namespace WebInfor.Controllers
{
    public class SujetoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Sujetoes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Sujetoes.ToList());
        }

        // GET: Sujetoes/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujeto sujeto = db.Sujetoes.Find(id);
            if (sujeto == null)
            {
                return HttpNotFound();
            }
            return View(sujeto);
        }

        // GET: Sujetoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sujetoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PerosnId,Name,CovidCount")] Sujeto sujeto)
        {
            if (ModelState.IsValid)
            {
                db.Sujetoes.Add(sujeto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sujeto);
        }

        // GET: Sujetoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujeto sujeto = db.Sujetoes.Find(id);
            if (sujeto == null)
            {
                return HttpNotFound();
            }
            return View(sujeto);
        }

        // POST: Sujetoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PerosnId,Name,CovidCount")] Sujeto sujeto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sujeto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sujeto);
        }

        // GET: Sujetoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sujeto sujeto = db.Sujetoes.Find(id);
            if (sujeto == null)
            {
                return HttpNotFound();
            }
            return View(sujeto);
        }

        // POST: Sujetoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sujeto sujeto = db.Sujetoes.Find(id);
            db.Sujetoes.Remove(sujeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
