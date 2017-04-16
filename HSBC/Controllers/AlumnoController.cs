using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HSBC.Models;
using HSBC.CustomFilters;

namespace HSBC.Controllers
{
    public class AlumnoController : Controller
    {
        UTTECEntities utt;

        public AlumnoController()
        {
            utt = new UTTECEntities();
        }

        // GET: Alumno
        public ActionResult Index()
        {
            var Student = utt.Alumnos.ToList();
            return View(Student);
        }
        [AuthLog(Roles = "Administrador")]
        public ActionResult Create()
        {
            ViewBag.GradoId = new SelectList(utt.Grados,"Grado1", "Desripcion");
            //var Alumno = new Alumno();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Alumno a)
        {
            utt.Alumnos.Add(a);
            utt.SaveChanges();
            return RedirectToAction("Index");
        }       
    }
}