using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HSBC.Models;
using HSBC.CustomFilters;

namespace HSBC.Controllers
{
    public class CalificacionesController : Controller
    {
        private UTTECEntities db = new UTTECEntities();

        // GET: Calificaciones
        [AuthLog(Roles = "Alumno")]
        public ActionResult Index()
        {
            var calificaciones = db.Calificaciones.Include(c => c.Alumno1);
            return View(calificaciones.ToList());
        }

        // GET: Calificaciones/Details/5
        [AuthLog(Roles = "Profesor")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            return View(calificacione);
        }

        // GET: Calificaciones/Create
        public ActionResult Create()
        {
            ViewBag.Alumno = new SelectList(db.Alumnos, "Matricula", "Nombre");
            return View();
        }

        // POST: Calificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CalificacionId,Alumno,Calificacion1,Calificacion2,Calificacion3,Promedio")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                db.Calificaciones.Add(calificacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Alumno = new SelectList(db.Alumnos, "Matricula", "Nombre", calificacione.Alumno);
            return View(calificacione);
        }

        // GET: Calificaciones/Edit/5
        [AuthLog(Roles = "Profesor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.Alumno = new SelectList(db.Alumnos, "Matricula", "Nombre", calificacione.Alumno);
            return View(calificacione);
        }

        // POST: Calificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalificacionId,Alumno,Calificacion1,Calificacion2,Calificacion3,Promedio")] Calificacione calificacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calificacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alumno = new SelectList(db.Alumnos, "Matricula", "Nombre", calificacione.Alumno);
            return View(calificacione);
        }

        // GET: Calificaciones/Delete/5
        [AuthLog(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calificacione calificacione = db.Calificaciones.Find(id);
            if (calificacione == null)
            {
                return HttpNotFound();
            }
            return View(calificacione);
        }

        // POST: Calificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calificacione calificacione = db.Calificaciones.Find(id);
            db.Calificaciones.Remove(calificacione);
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
