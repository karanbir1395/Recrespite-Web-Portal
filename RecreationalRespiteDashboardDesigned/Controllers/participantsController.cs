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
    public class participantsController : Controller
    {
        private RecDatabaseModelContainer db = new RecDatabaseModelContainer();

        // GET: participants
        public ActionResult Index()
        {
            return View(db.participants.ToList());
        }

        // GET: participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participants participants = db.participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            return View(participants);
        }

        // GET: participants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,diagnosis,firstname,gender,lastname,notes,program,username")] participants participants)
        {
            if (ModelState.IsValid)
            {
                db.participants.Add(participants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(participants);
        }

        // GET: participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participants participants = db.participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            return View(participants);
        }

        // POST: participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,diagnosis,firstname,gender,lastname,notes,program,username")] participants participants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participants);
        }

        // GET: participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            participants participants = db.participants.Find(id);
            if (participants == null)
            {
                return HttpNotFound();
            }
            return View(participants);
        }

        // POST: participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            participants participants = db.participants.Find(id);
            db.participants.Remove(participants);
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
