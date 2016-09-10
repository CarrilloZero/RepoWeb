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
    public class chofersController : Controller
    {
        private TesisbdEntities db = new TesisbdEntities();

        // GET: chofers
        public ActionResult Index()
        {
            var chofer = db.chofer.Include(c => c.bus).Include(c => c.empresa).Include(c => c.usuario);
            return View(chofer.ToList());
        }

        // GET: chofers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // GET: chofers/Create
        public ActionResult Create()
        {
            ViewBag.Bus_Id = new SelectList(db.bus, "Id", "Patente");
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre");
            ViewBag.Usuario_Id = new SelectList(db.usuario, "Id", "Correo");
            return View();
        }

        // POST: chofers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Usuario_Id,Bus_Id,Empresa_Id,Online")] chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.chofer.Add(chofer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bus_Id = new SelectList(db.bus, "Id", "Patente", chofer.Bus_Id);
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", chofer.Empresa_Id);
            ViewBag.Usuario_Id = new SelectList(db.usuario, "Id", "Correo", chofer.Usuario_Id);
            return View(chofer);
        }

        // GET: chofers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bus_Id = new SelectList(db.bus, "Id", "Patente", chofer.Bus_Id);
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", chofer.Empresa_Id);
            ViewBag.Usuario_Id = new SelectList(db.usuario, "Id", "Correo", chofer.Usuario_Id);
            return View(chofer);
        }

        // POST: chofers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Usuario_Id,Bus_Id,Empresa_Id,Online")] chofer chofer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chofer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bus_Id = new SelectList(db.bus, "Id", "Patente", chofer.Bus_Id);
            ViewBag.Empresa_Id = new SelectList(db.empresa, "Id", "Nombre", chofer.Empresa_Id);
            ViewBag.Usuario_Id = new SelectList(db.usuario, "Id", "Correo", chofer.Usuario_Id);
            return View(chofer);
        }

        // GET: chofers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            chofer chofer = db.chofer.Find(id);
            if (chofer == null)
            {
                return HttpNotFound();
            }
            return View(chofer);
        }

        // POST: chofers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            chofer chofer = db.chofer.Find(id);
            db.chofer.Remove(chofer);
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
