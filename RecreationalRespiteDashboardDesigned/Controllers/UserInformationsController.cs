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
    public class UserInformationsController : Controller
    {
        private RecDatabaseModelContainer db = new RecDatabaseModelContainer();

        // GET: UserInformations
        public ActionResult Index()
        {
            return View(db.UserInformations.ToList());
        }

        // GET: UserInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // GET: UserInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "username,city,email,firstname,lastname,phoneNumber,region,userType")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.UserInformations.Add(userInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInformation);
        }

        // GET: UserInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: UserInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "username,city,email,firstname,lastname,phoneNumber,region,userType")] UserInformation userInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInformation);
        }

        // GET: UserInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userInformation = db.UserInformations.Find(id);
            if (userInformation == null)
            {
                return HttpNotFound();
            }
            return View(userInformation);
        }

        // POST: UserInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInformation userInformation = db.UserInformations.Find(id);
            db.UserInformations.Remove(userInformation);
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
