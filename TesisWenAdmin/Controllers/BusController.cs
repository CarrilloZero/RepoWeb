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
    public class BusController : Controller
    {
        private TesisbdEntities db = new TesisbdEntities();


        public ActionResult Actualizar(double latitud,double longitud, string patente)
        {

            //insertar o actualizar estos valores para la micro correcta
            return View();
        }

        // GET: Bus
        public ActionResult Index()
        {
            var bus = db.bus.Include(b => b.empresa);
            return View(bus.ToList());
        }

        // GET: Bus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Bus/Create
        public ActionResult Create()
        {
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre");
            return View();
        }

        // POST: Bus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Empresa_Id,Patente")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.bus.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", bus.Empresa_Id);
            return View(bus);
        }

        // GET: Bus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", bus.Empresa_Id);
            return View(bus);
        }

        // POST: Bus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Empresa_Id,Patente")] bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", bus.Empresa_Id);
            return View(bus);
        }

        // GET: Bus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bus bus = db.bus.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Bus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bus bus = db.bus.Find(id);
            db.bus.Remove(bus);
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
