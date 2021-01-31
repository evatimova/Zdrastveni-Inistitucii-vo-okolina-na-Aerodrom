using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalFind88.Models;

namespace HospitalFind88.Controllers
{
    public class HospitalsController : Controller
    {
        private HospitalsContext db = new HospitalsContext();

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.hospitals.ToList());
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
