using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HSBC.Models;
using HSBC.CustomFilters;

namespace HSBC.Controllers
{
    public class ProfesorController : Controller
    {
        UTTECEntities utt;
        public ProfesorController()
        {
            utt = new UTTECEntities();
        }
        // GET: Profesor
        [AuthLog(Roles = "Administrador")]
        public ActionResult Index()
        {
            var Profesor = utt.Profesors.ToList();
            return View(Profesor);
        }
        [AuthLog(Roles = "Administrador")]
        public ActionResult Create()
        {
            var Profesor = new Profesor();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Profesor a)
        {
            utt.Profesors.Add(a);
            utt.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}