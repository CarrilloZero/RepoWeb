using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesisWenAdmin;

namespace TesisWenAdmin.Controllers
{
    public class TipopasajeController : Controller
    {
        private TesisbdEntities db = new TesisbdEntities();

        // GET: Tipopasaje
        public ActionResult Index()
        {
            return View(db.tipopasaje.ToList());
        }

        // GET: Tipopasaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipopasaje tipopasaje = db.tipopasaje.Find(id);
            if (tipopasaje == null)
            {
                return HttpNotFound();
            }
            return View(tipopasaje);
        }

        // GET: Tipopasaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipopasaje/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo")] tipopasaje tipopasaje)
        {
            if (ModelState.IsValid)
            {
                db.tipopasaje.Add(tipopasaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipopasaje);
        }

        // GET: Tipopasaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipopasaje tipopasaje = db.tipopasaje.Find(id);
            if (tipopasaje == null)
            {
                return HttpNotFound();
            }
            return View(tipopasaje);
        }

        // POST: Tipopasaje/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo")] tipopasaje tipopasaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipopasaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipopasaje);
        }

        // GET: Tipopasaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipopasaje tipopasaje = db.tipopasaje.Find(id);
            if (tipopasaje == null)
            {
                return HttpNotFound();
            }
            return View(tipopasaje);
        }

        // POST: Tipopasaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipopasaje tipopasaje = db.tipopasaje.Find(id);
            db.tipopasaje.Remove(tipopasaje);
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
