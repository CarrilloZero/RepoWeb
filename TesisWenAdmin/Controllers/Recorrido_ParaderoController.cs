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
    public class Recorrido_ParaderoController : Controller
    {

        private SelectList GetRecorridos()
        {
            List<recorrido> recorridos = db.recorrido.Include(r => r.ciudad).Include(r => r.ciudad1).ToList();
            

            var devuelve = recorridos.Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ciudad.Nombre + " -> " + x.ciudad1.Nombre,
                });

            return new SelectList(devuelve, "Value", "Text");
        }

        private SelectList GetParaderos()
        {
            List<paradero> paraderos = db.paradero.ToList();
            var devuelve = paraderos.Select(x =>
                new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Nombre,
                });

            return new SelectList(devuelve, "Value", "Text");
        }


        private TesisbdEntities db = new TesisbdEntities();

        // GET: Recorrido_Paradero
        public ActionResult Index()
        {
            var recorrido_paradero = db.recorrido_paradero.Include(r => r.paradero).Include(r => r.recorrido);
            return View(recorrido_paradero.ToList());
        }

        // GET: Recorrido_Paradero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido_paradero recorrido_paradero = db.recorrido_paradero.Find(id);
            if (recorrido_paradero == null)
            {
                return HttpNotFound();
            }
            return View(recorrido_paradero);
        }

        // GET: Recorrido_Paradero/Create
        public ActionResult Create()
        {
            var model = new Models.RecorridoParaderoViewModel
            {
                recorridos = GetRecorridos(),
                paraderos = GetParaderos(),
            };
            return View(model);
        }

        // POST: Recorrido_Paradero/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Recorrido_Id,Paradero_Id,Id")] recorrido_paradero recorrido_paradero)
        {
            if (ModelState.IsValid)
            {
                db.recorrido_paradero.Add(recorrido_paradero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Paradero_Id = new SelectList(db.paradero, "Id", "Nombre", recorrido_paradero.Paradero_Id);
            ViewBag.Recorrido_Id = new SelectList(db.recorrido, "Id", "Id", recorrido_paradero.Recorrido_Id);
            return View(recorrido_paradero);
        }

        // GET: Recorrido_Paradero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido_paradero recorrido_paradero = db.recorrido_paradero.Find(id);
            if (recorrido_paradero == null)
            {
                return HttpNotFound();
            }
            ViewBag.Paradero_Id = new SelectList(db.paradero, "Id", "Nombre", recorrido_paradero.Paradero_Id);
            ViewBag.Recorrido_Id = new SelectList(db.recorrido, "Id", "Id", recorrido_paradero.Recorrido_Id);
            return View(recorrido_paradero);
        }

        // POST: Recorrido_Paradero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Recorrido_Id,Paradero_Id,Id")] recorrido_paradero recorrido_paradero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recorrido_paradero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Paradero_Id = new SelectList(db.paradero, "Id", "Nombre", recorrido_paradero.Paradero_Id);
            ViewBag.Recorrido_Id = new SelectList(db.recorrido, "Id", "Id", recorrido_paradero.Recorrido_Id);
            return View(recorrido_paradero);
        }

        // GET: Recorrido_Paradero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recorrido_paradero recorrido_paradero = db.recorrido_paradero.Find(id);
            if (recorrido_paradero == null)
            {
                return HttpNotFound();
            }
            return View(recorrido_paradero);
        }

        // POST: Recorrido_Paradero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recorrido_paradero recorrido_paradero = db.recorrido_paradero.Find(id);
            db.recorrido_paradero.Remove(recorrido_paradero);
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
