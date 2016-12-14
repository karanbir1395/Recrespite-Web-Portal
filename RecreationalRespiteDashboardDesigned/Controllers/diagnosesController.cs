using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecreationalRespiteDashboardDesigned.Models;

namespace RecreationalRespiteDashboardDesigned.Controllers
{
    public class diagnosesController : Controller
    {
        // private RecDatabaseModelContainer db = new RecDatabaseModelContainer();
        webApiClass eventsHelper = new webApiClass();
        // GET: diagnoses
        public ActionResult Index()
        {
            return View(eventsHelper.GetDiagnosis());
        }

        // GET: diagnoses/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diagnosis diagnosis = eventsHelper.GetDiagnosises(id);
            if (diagnosis == null)
            {
                return HttpNotFound();
            }
            return View(diagnosis);
        }

        // GET: diagnoses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: diagnoses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "diagnosisId,name")] diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                eventsHelper.insertDiagnosis(diagnosis.name);
                return RedirectToAction("Index");
            }

            return View(diagnosis);
        }

        // GET: diagnoses/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diagnosis diagnosis = eventsHelper.GetDiagnosises(id);
            if (diagnosis == null)
            {
                return HttpNotFound();
            }
            return View(diagnosis);
        }

        // POST: diagnoses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "diagnosisId,name")] diagnosis diagnosis)
        {
            if (ModelState.IsValid)
            {
                eventsHelper.EditDiagnosis(diagnosis.name, diagnosis.diagnosisId);
                return RedirectToAction("Index");
            }
            return View(diagnosis);
        }

        // GET: diagnoses/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            diagnosis diagnosis = eventsHelper.GetDiagnosises(id);
            if (diagnosis == null)
            {
                return HttpNotFound();
            }
            return View(diagnosis);
        }

        // POST: diagnoses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            eventsHelper.deleteDiagnosis(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
