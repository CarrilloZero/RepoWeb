using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesisWenAdmin;

namespace TesisWenAdmin.Controllers
{
    public class ParaderoController : Controller
    {
        private TesisbdEntities db = new TesisbdEntities();

        // GET: Paradero
        public ActionResult Index()
        {
            return View(db.paradero.ToList());
        }

        // GET: Paradero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paradero paradero = db.paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // GET: Paradero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paradero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Longitud,Latitud,Nombre")] paradero paradero)
        {
            if (ModelState.IsValid)
            {
                db.paradero.Add(paradero);
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var validationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            
                        }
                    }
                }
                
                return RedirectToAction("Index");
            }

            return View(paradero);
        }

        // GET: Paradero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paradero paradero = db.paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // POST: Paradero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Longitud,Latitud,Nombre")] paradero paradero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paradero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paradero);
        }

        // GET: Paradero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paradero paradero = db.paradero.Find(id);
            if (paradero == null)
            {
                return HttpNotFound();
            }
            return View(paradero);
        }

        // POST: Paradero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            paradero paradero = db.paradero.Find(id);
            db.paradero.Remove(paradero);
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
