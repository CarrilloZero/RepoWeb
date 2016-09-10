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
    public class RecorridoController : Controller
    {
        private TesisbdEntities db = new TesisbdEntities();

        // GET: Recorrido
        public ActionResult Index()
        {
            var recorrido = db.recorrido.Include(r => r.ciudad).Include(r => r.ciudad1);
            return View(recorrido.ToList());
        }

        // GET: Recorrido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido recorrido = db.recorrido.Find(id);
            if (recorrido == null)
            {
                return HttpNotFound();
            }
            return View(recorrido);
        }

        // GET: Recorrido/Create
        public ActionResult Create()
        {
            ViewBag.Ciudad_Origen_Id = new SelectList(db.ciudad, "Id", "Nombre");
            ViewBag.Ciudad_Destino_Id = new SelectList(db.ciudad, "Id", "Nombre");
            return View();
        }

        

        // POST: Recorrido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HorarioOrigen,HorarioDestino,Ciudad_Origen_Id,Ciudad_Destino_Id")] recorrido recorrido)
        {
            if (ModelState.IsValid)
            {
                db.recorrido.Add(recorrido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ciudad_Origen_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Origen_Id);
            ViewBag.Ciudad_Destino_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Destino_Id);
            return View(recorrido);
        }
        

        // GET: Recorrido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido recorrido = db.recorrido.Find(id);
            if (recorrido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ciudad_Origen_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Origen_Id);
            ViewBag.Ciudad_Destino_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Destino_Id);
            return View(recorrido);
        }

        // POST: Recorrido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HorarioOrigen,HorarioDestino,Ciudad_Origen_Id,Ciudad_Destino_Id")] recorrido recorrido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recorrido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ciudad_Origen_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Origen_Id);
            ViewBag.Ciudad_Destino_Id = new SelectList(db.ciudad, "Id", "Nombre", recorrido.Ciudad_Destino_Id);
            return View(recorrido);
        }

        // GET: Recorrido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido recorrido = db.recorrido.Find(id);
            if (recorrido == null)
            {
                return HttpNotFound();
            }
            return View(recorrido);
        }

        // POST: Recorrido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recorrido recorrido = db.recorrido.Find(id);
            db.recorrido.Remove(recorrido);
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
